module RNGLR.ParseList
open Yard.Generators.RNGLR.Parser
open Yard.Generators.RNGLR
open Yard.Generators.RNGLR.AST
type Token =
    | A of int
    | B of int
    | C of int
    | EOF of int

let numToString = function 
    | 0 -> "elem"
    | 1 -> "list"
    | 2 -> "yard_start_rule"
    | 3 -> "A"
    | 4 -> "B"
    | 5 -> "C"
    | 6 -> "EOF"
    | _ -> ""
let tokenToNumber = function
    | A _ -> 3
    | B _ -> 4
    | C _ -> 5
    | EOF _ -> 6

let leftSide = [|1; 1; 2; 0; 0|]
let private rules = [|0; 1; 5; 0; 1; 4; 3|]
let private rulesStart = [|0; 1; 4; 5; 6; 7|]
let startRule = 2

let acceptEmptyInput = false

let defaultAstToDot = 
    (fun (tree : Yard.Generators.RNGLR.AST.Tree<Token>) -> tree.AstToDot numToString tokenToNumber leftSide)

let inline unpack x = x >>> 16, x <<< 16 >>> 16
let private small_gotos =
        [|0, [|0,1; 1,2; 3,5; 4,6|]; 2, [|5,3|]; 3, [|0,4; 3,5; 4,6|]|]
let private gotos = Array.zeroCreate 7
for i = 0 to 6 do
        gotos.[i] <- Array.create 7 None
for (i,t) in small_gotos do
        for (j,x) in t do
            gotos.[i].[j] <- Some  x
let private lists_reduces = [|[||]; [|0,1|]; [|1,3|]; [|4,1|]; [|3,1|]|]
let private small_reduces =
        [|65538; 327681; 393217; 262146; 327682; 393218; 327682; 327683; 393219; 393218; 327684; 393220|]
let reduces = Array.zeroCreate 7
for i = 0 to 6 do
        reduces.[i] <- Array.create 7 [||]
let init_reduces =
        let mutable cur = 0
        while cur < small_reduces.Length do
            let i,length = unpack small_reduces.[cur]
            cur <- cur + 1
            for k = 0 to length-1 do
                let j,x = unpack small_reduces.[cur + k]
                reduces.[i].[j] <-  lists_reduces.[x]
            cur <- cur + length
let private lists_zeroReduces = [|[||]|]
let private small_zeroReduces =
        [||]
let zeroReduces = Array.zeroCreate 7
for i = 0 to 6 do
        zeroReduces.[i] <- Array.create 7 [||]
let init_zeroReduces =
        let mutable cur = 0
        while cur < small_zeroReduces.Length do
            let i,length = unpack small_zeroReduces.[cur]
            cur <- cur + 1
            for k = 0 to length-1 do
                let j,x = unpack small_zeroReduces.[cur + k]
                zeroReduces.[i].[j] <-  lists_zeroReduces.[x]
            cur <- cur + length
let private small_acc = [2]
let private accStates = Array.zeroCreate 7
for i = 0 to 6 do
        accStates.[i] <- List.exists ((=) i) small_acc
let eofIndex = 6
let private parserSource = new ParserSource<Token> (gotos, reduces, zeroReduces, accStates, rules, rulesStart, leftSide, startRule, eofIndex, tokenToNumber, acceptEmptyInput)
let buildAst : (seq<Token> -> ParseResult<Token>) =
    buildAst<Token> parserSource

