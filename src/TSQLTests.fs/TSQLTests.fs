﻿module TSQLTests

open Graphviz4Net.Dot.AntlrParser
open System.IO
open Graphviz4Net.Dot
open QuickGraph
open NUnit.Framework
open AbstractLexer.Common
open AbstractLexer.Core
open QuickGraph.Algorithms
open QuickGraph.Graphviz
open Microsoft.FSharp.Text
open Yard.Examples.MSParser
open Yard.Utils.SourceText
open YC.FST.AbstractLexing.Interpreter
open YC.FSA.FsaApproximation
open Microsoft.FSharp.Collections
open YC.FSA.GraphBasedFsa
open YC.FST.GraphBasedFst

let baseInputGraphsPath = "../../../Tests/AbstractPerformance/TSQL"
let eofToken = Yard.Examples.MSParser.RNGLR_EOF (new GraphTokenValue<_>())

let path baseInputGraphsPath name = System.IO.Path.Combine(baseInputGraphsPath,name)

let loadGraphFromDOT filePath =
    let parser = AntlrParserAdapter<string>.GetParser()
    parser.Parse(new StreamReader(File.OpenRead filePath))

let loadDotToQG baseInputGraphsPath gFile =
    let qGraph = loadGraphFromDOT(path baseInputGraphsPath gFile)
    let graphAppr = new Appr<_>()
    graphAppr.InitState <- ResizeArray.singleton 0

    for e in qGraph.Edges do
        let edg = e :?> DotEdge<string>
        new TaggedEdge<_,_>(int edg.Source.Id, int edg.Destination.Id, (edg.Label, new CalcHighlighting.CalcBaseTreeNode("", 0))) |> graphAppr.AddVerticesAndEdge |> ignore

    graphAppr.FinalState <- ResizeArray.singleton (Seq.max graphAppr.Vertices)
    graphAppr

let loadLexerInputGraph gFile = loadDotToQG baseInputGraphsPath gFile

let resultDirectoryPath = ref @"../../result"

let getResultFileName path pref =
    // 1) для получения имени файла есть  System.IO.Path.GetFileName
    // 2) Собирать путь лучше через System.IO.Path.Combine Он сам отследит все слеши на границах и т.д.
    System.IO.Path.Combine (!resultDirectoryPath, pref + System.IO.Path.GetFileName path)
                                  //path.Substring(path.LastIndexOf("\\") + 1)

//let flg = ref false
let LexerTSQL (srcFilePath:string) =
    let lexerInputGraph = loadLexerInputGraph srcFilePath
    let graphFsa = lexerInputGraph.ApprToFSA()
    let transform x = (x, match x with |Smbl(y, _) -> Smbl y |_ -> Eps)
    let smblEOF = Smbl(char 65535,  Unchecked.defaultof<Position<_>>)
    let graphFst = FST<_,_>.FSAtoFST(graphFsa, transform, smblEOF)
    let tokenize srcFilePath = 
        let start = System.DateTime.Now
        for i in 1..10 do YC.TSQLLexer.tokenize eofToken graphFst  |> ignore
        printf  "%s " (System.IO.Path.GetFileNameWithoutExtension(srcFilePath))
        printf " %A " <| (System.DateTime.Now - start).TotalMilliseconds / 10.0
        printfn " "
        System.GC.Collect()
    tokenize srcFilePath

let LexerTSQLAllDirectory (directoryName:string) =
    resultDirectoryPath := System.IO.Path.Combine(directoryName, "results")
        // directoryName + @"\results\"
    System.IO.Directory.GetFiles(directoryName,"*.dot")
    |> Array.iter LexerTSQL

do 
    let inPath = ref @"..\..\tests\s2.dot"
    let lexerDir = ref false
    let commandLineSpecs =
        [
         "-f", ArgType.String (fun s -> inPath := path baseInputGraphsPath s), "Input file."
         "-d", ArgType.String (fun s -> lexerDir := true; inPath := s), "Input dir. Use for parse all files in specified directory."
         ] |> List.map (fun (shortcut, argtype, description) -> ArgInfo(shortcut, argtype, description))
    ArgParser.Parse commandLineSpecs

    !inPath
    |> if !lexerDir
       then LexerTSQLAllDirectory
       else LexerTSQL

