//#nowarn "47" // recursive initialization of LexBuffer


namespace AbstractLexer.Core

open System.Collections.Generic
open AbstractLexer.Common
open QuickGraph.Algorithms
open Microsoft.FSharp.Collections

[<Struct>]
type StateInfo<'a> =
    val StartV: int
    val AccumulatedString: 'a
    new (startV, str) = {StartV = startV; AccumulatedString = str}

[<Struct>]
type State<'a> =
    val StateID: int
    val AcceptAction: int
    val Info: ResizeArray<StateInfo<'a>>
    new (stateId:int, acceptAction, info) =  {StateID = stateId; AcceptAction = acceptAction; Info = info}

[<Sealed>]
type AsciiTables(trans: uint16[] array, accept: uint16[]) =
    let rec scanUntilSentinel(lexBuffer, state) =
        let sentinel = 255 * 256 + 255 
        // Return an endOfScan after consuming the input 
        let a = int accept.[state] 
        if a <> sentinel then () 
            //onAccept (lexBuffer,a)
        
        // read a character - end the scan if there are no further transitions 
        let inp = 1//int(lexBuffer.Buffer.[lexBuffer.BufferScanPos])
        let snew = int trans.[state].[inp] 
        if snew = sentinel then ()
            //lexBuffer.EndOfScan()
        else 
            //lexBuffer.BufferScanLength <- lexBuffer.BufferScanLength + 1;
            scanUntilSentinel(lexBuffer, snew)
            
    /// Interpret tables for an ascii lexer generated by fslex. 
    member tables.Interpret(initialState,lexBuffer) = 
        //startInterpret(lexBuffer)
        //scanUntilSentinel(lexBuffer, initialState)
        1

    static member Create(trans,accept) = new AsciiTables(trans,accept)

[<Sealed>]
type UnicodeTables(trans: uint16[] array, accept: uint16[]) = 
    let sentinel = 255 * 256 + 255 
    let numUnicodeCategories = 30 
    let numLowUnicodeChars = 128 
    let numSpecificUnicodeChars = (trans.[0].Length - 1 - numLowUnicodeChars - numUnicodeCategories)/2
    let lookupUnicodeCharacters (state,inp) = 
        let inpAsInt = int inp
        // Is it a fast ASCII character?
        if inpAsInt < numLowUnicodeChars then
            int trans.[state].[inpAsInt]
        else 
            // Search for a specific unicode character
            let baseForSpecificUnicodeChars = numLowUnicodeChars
            let rec loop i = 
                if i >= numSpecificUnicodeChars then 
                    // OK, if we failed then read the 'others' entry in the alphabet,
                    // which covers all Unicode characters not covered in other
                    // ways
                    let baseForUnicodeCategories = numLowUnicodeChars+numSpecificUnicodeChars*2
                    let unicodeCategory = System.Char.GetUnicodeCategory(inp)
                    //System.Console.WriteLine("inp = {0}, unicodeCategory = {1}", [| box inp; box unicodeCategory |]);
                    int trans.[state].[baseForUnicodeCategories + int32 unicodeCategory]
                else 
                    // This is the specific unicode character
                    let c = char (int trans.[state].[baseForSpecificUnicodeChars+i*2])
                    //System.Console.WriteLine("c = {0}, inp = {1}, i = {2}", [| box c; box inp; box i |]);
                    // OK, have we found the entry for a specific unicode character?
                    if c = inp
                    then int trans.[state].[baseForSpecificUnicodeChars+i*2+1]
                    else loop(i+1)
                
            loop 0
    let eofPos    = numLowUnicodeChars + 2*numSpecificUnicodeChars + numUnicodeCategories 
        
    let rec scanUntilSentinel inp (state:State<_>) =
        // Return an endOfScan after consuming the input 
        let a = int accept.[state.StateID]
        let onAccept = if a <> sentinel then a else state.AcceptAction
        // Find the new state
        let snew = lookupUnicodeCharacters (state.StateID,inp)
        snew = sentinel, onAccept, snew

    let tokenize actions (inG:LexerInputGraph<_>) =
        let g = new LexerInnerGraph<_>(inG)
        let newEdges = new ResizeArray<_>()
        let states = new Dictionary<_,_>(g.VertexCount)
        let startState = new State<_>(0,-1,new ResizeArray<_>([|new StateInfo<_>(0,new ResizeArray<_>())|]))
        states.Add(g.StartVertex, new ResizeArray<_>([startState]))
        let add (e:AEdge<_,_>) (newStt:State<_>) =
            if states.ContainsKey e.Target
            then
                match states.[e.Target] 
                        |> ResizeArray.tryFind(fun x -> x.AcceptAction = newStt.AcceptAction && x.StateID = newStt.StateID)
                    with
                | Some x -> x.Info.AddRange newStt.Info
                | None -> states.[e.Target].Add newStt
            else states.Add(e.Target,new ResizeArray<_>([newStt]))           
        let sorted = g.TopologicalSort() |> Array.ofSeq
        for v in sorted do
            let reduced = ref false
            for e in g.OutEdges v do                
                printfn "%A" e.Label
                let ch = e.Label                
                for stt in states.[v] do                     
                    match ch with
                    | Some x ->
                        let rec go stt =
                            let reduce, onAccept, news = scanUntilSentinel x stt
                            if reduce
                            then
                                stt.Info
                                |> ResizeArray.iter
                                    (fun (i:StateInfo<_>) -> 
                                        new string(i.AccumulatedString |> Array.ofSeq)
                                        |> actions onAccept  
                                        |> fun x -> 
                                            newEdges.Add(i.StartV,x,v)
                                            printfn "%A" x)
                                let newStt = new State<_>(0,-1,new ResizeArray<_>())                            
                                go newStt                            
                            else 
                                let acc = 
                                    if stt.Info.Count > 0
                                    then
                                        stt.Info
                                        |> ResizeArray.map (fun i -> new StateInfo<_>(i.StartV, ResizeArray.concat [i.AccumulatedString; new ResizeArray<_>([ch.Value])]))
                                    else new ResizeArray<_>([new StateInfo<_>(v, new ResizeArray<_>([ch.Value]))])
                                if not !reduced
                                then
                                    let newStt = new State<_>(news,onAccept,acc)
                                    add e newStt
                                reduced := true
                        go stt
                    | None -> ()

        let ac = states.[sorted.[sorted.Length-1]] 
        ac
        |> ResizeArray.iter(
            fun x ->
                x.Info
                |> ResizeArray.iter
                    (fun (i:StateInfo<_>) ->                        
                        new string(i.AccumulatedString |> Array.ofSeq)
                        |> actions (if x.AcceptAction > -1 then x.AcceptAction else int accept.[x.StateID])
                        |> fun x -> 
                            newEdges.Add(i.StartV,x,sorted.[sorted.Length-1])
                            printfn "%A" x))
        newEdges |> Seq.iter (printfn "%A")
        let res = new DAG<_,_>()
        newEdges |> Seq.map (fun (s,t,e) -> new AEdge<_,_>(s,e,(Some t,None)))
        |> res.AddEdgesForsed
        res
                          
    // Each row for the Unicode table has format 
    //      128 entries for ASCII characters
    //      A variable number of 2*UInt16 entries for SpecificUnicodeChars 
    //      30 entries, one for each UnicodeCategory
    //      1 entry for EOF
        

    member tables.Tokenize actions g =
        tokenize actions g

    static member Create(trans,accept) = new UnicodeTables(trans,accept)
