 
module YC.FST.AbstractLexing.CalcLexer

open Microsoft.FSharp.Collections
open YC.FST.GraphBasedFst
open YC.FSA.GraphBasedFsa
open YC.FST.AbstractLexing.Interpreter
open AbstractAnalysis.Common
open AbstractParser.Tokens
open System.Collections.Generic

let fstLexer () = 
   let startState = ResizeArray.singleton 0
   let finishState = ResizeArray.singleton 65535
   let transitions = new ResizeArray<_>()
   transitions.Add(0, (Smbl (char 65535), Eps), 65535)
   transitions.Add(0, (Smbl '\t', Eps), 1)
   transitions.Add(0, (Smbl '\n', Eps), 1)
   transitions.Add(0, (Smbl '\r', Eps), 1)
   transitions.Add(0, (Smbl ' ', Eps), 1)
   transitions.Add(0, (Smbl '(', Eps), 4)
   transitions.Add(0, (Smbl ')', Eps), 5)
   transitions.Add(0, (Smbl '*', Eps), 8)
   transitions.Add(0, (Smbl '+', Eps), 7)
   transitions.Add(0, (Smbl '-', Eps), 3)
   transitions.Add(0, (Smbl '/', Eps), 6)
   transitions.Add(0, (Smbl '0', Eps), 2)
   transitions.Add(0, (Smbl '1', Eps), 2)
   transitions.Add(0, (Smbl '2', Eps), 2)
   transitions.Add(0, (Smbl '3', Eps), 2)
   transitions.Add(0, (Smbl '4', Eps), 2)
   transitions.Add(0, (Smbl '5', Eps), 2)
   transitions.Add(0, (Smbl '6', Eps), 2)
   transitions.Add(0, (Smbl '7', Eps), 2)
   transitions.Add(0, (Smbl '8', Eps), 2)
   transitions.Add(0, (Smbl '9', Eps), 2)
   transitions.Add(1, (Smbl '\t', Smbl 0), 1)
   transitions.Add(1, (Smbl '\n', Smbl 0), 1)
   transitions.Add(1, (Smbl '\r', Smbl 0), 1)
   transitions.Add(1, (Smbl ' ', Smbl 0), 1)
   transitions.Add(1, (Smbl '(', Smbl 0), 4)
   transitions.Add(1, (Smbl ')', Smbl 0), 5)
   transitions.Add(1, (Smbl '*', Smbl 0), 8)
   transitions.Add(1, (Smbl '+', Smbl 0), 7)
   transitions.Add(1, (Smbl '-', Smbl 0), 3)
   transitions.Add(1, (Smbl '/', Smbl 0), 6)
   transitions.Add(1, (Smbl '0', Smbl 0), 2)
   transitions.Add(1, (Smbl '1', Smbl 0), 2)
   transitions.Add(1, (Smbl '2', Smbl 0), 2)
   transitions.Add(1, (Smbl '3', Smbl 0), 2)
   transitions.Add(1, (Smbl '4', Smbl 0), 2)
   transitions.Add(1, (Smbl '5', Smbl 0), 2)
   transitions.Add(1, (Smbl '6', Smbl 0), 2)
   transitions.Add(1, (Smbl '7', Smbl 0), 2)
   transitions.Add(1, (Smbl '8', Smbl 0), 2)
   transitions.Add(1, (Smbl '9', Smbl 0), 2)
   transitions.Add(1, (Smbl (char 65535), Smbl 0), 65535)
   transitions.Add(4, (Smbl '\t', Smbl 3), 1)
   transitions.Add(4, (Smbl '\n', Smbl 3), 1)
   transitions.Add(4, (Smbl '\r', Smbl 3), 1)
   transitions.Add(4, (Smbl ' ', Smbl 3), 1)
   transitions.Add(4, (Smbl '(', Smbl 3), 4)
   transitions.Add(4, (Smbl ')', Smbl 3), 5)
   transitions.Add(4, (Smbl '*', Smbl 3), 8)
   transitions.Add(4, (Smbl '+', Smbl 3), 7)
   transitions.Add(4, (Smbl '-', Smbl 3), 3)
   transitions.Add(4, (Smbl '/', Smbl 3), 6)
   transitions.Add(4, (Smbl '0', Smbl 3), 2)
   transitions.Add(4, (Smbl '1', Smbl 3), 2)
   transitions.Add(4, (Smbl '2', Smbl 3), 2)
   transitions.Add(4, (Smbl '3', Smbl 3), 2)
   transitions.Add(4, (Smbl '4', Smbl 3), 2)
   transitions.Add(4, (Smbl '5', Smbl 3), 2)
   transitions.Add(4, (Smbl '6', Smbl 3), 2)
   transitions.Add(4, (Smbl '7', Smbl 3), 2)
   transitions.Add(4, (Smbl '8', Smbl 3), 2)
   transitions.Add(4, (Smbl '9', Smbl 3), 2)
   transitions.Add(4, (Smbl (char 65535), Smbl 3), 65535)
   transitions.Add(5, (Smbl '\t', Smbl 4), 1)
   transitions.Add(5, (Smbl '\n', Smbl 4), 1)
   transitions.Add(5, (Smbl '\r', Smbl 4), 1)
   transitions.Add(5, (Smbl ' ', Smbl 4), 1)
   transitions.Add(5, (Smbl '(', Smbl 4), 4)
   transitions.Add(5, (Smbl ')', Smbl 4), 5)
   transitions.Add(5, (Smbl '*', Smbl 4), 8)
   transitions.Add(5, (Smbl '+', Smbl 4), 7)
   transitions.Add(5, (Smbl '-', Smbl 4), 3)
   transitions.Add(5, (Smbl '/', Smbl 4), 6)
   transitions.Add(5, (Smbl '0', Smbl 4), 2)
   transitions.Add(5, (Smbl '1', Smbl 4), 2)
   transitions.Add(5, (Smbl '2', Smbl 4), 2)
   transitions.Add(5, (Smbl '3', Smbl 4), 2)
   transitions.Add(5, (Smbl '4', Smbl 4), 2)
   transitions.Add(5, (Smbl '5', Smbl 4), 2)
   transitions.Add(5, (Smbl '6', Smbl 4), 2)
   transitions.Add(5, (Smbl '7', Smbl 4), 2)
   transitions.Add(5, (Smbl '8', Smbl 4), 2)
   transitions.Add(5, (Smbl '9', Smbl 4), 2)
   transitions.Add(5, (Smbl (char 65535), Smbl 4), 65535)
   transitions.Add(8, (Smbl '\t', Smbl 8), 1)
   transitions.Add(8, (Smbl '\n', Smbl 8), 1)
   transitions.Add(8, (Smbl '\r', Smbl 8), 1)
   transitions.Add(8, (Smbl ' ', Smbl 8), 1)
   transitions.Add(8, (Smbl '(', Smbl 8), 4)
   transitions.Add(8, (Smbl ')', Smbl 8), 5)
   transitions.Add(8, (Smbl '*', Eps), 9)
   transitions.Add(8, (Smbl '+', Smbl 8), 7)
   transitions.Add(8, (Smbl '-', Smbl 8), 3)
   transitions.Add(8, (Smbl '/', Smbl 8), 6)
   transitions.Add(8, (Smbl '0', Smbl 8), 2)
   transitions.Add(8, (Smbl '1', Smbl 8), 2)
   transitions.Add(8, (Smbl '2', Smbl 8), 2)
   transitions.Add(8, (Smbl '3', Smbl 8), 2)
   transitions.Add(8, (Smbl '4', Smbl 8), 2)
   transitions.Add(8, (Smbl '5', Smbl 8), 2)
   transitions.Add(8, (Smbl '6', Smbl 8), 2)
   transitions.Add(8, (Smbl '7', Smbl 8), 2)
   transitions.Add(8, (Smbl '8', Smbl 8), 2)
   transitions.Add(8, (Smbl '9', Smbl 8), 2)
   transitions.Add(8, (Smbl (char 65535), Smbl 8), 65535)
   transitions.Add(7, (Smbl '\t', Smbl 6), 1)
   transitions.Add(7, (Smbl '\n', Smbl 6), 1)
   transitions.Add(7, (Smbl '\r', Smbl 6), 1)
   transitions.Add(7, (Smbl ' ', Smbl 6), 1)
   transitions.Add(7, (Smbl '(', Smbl 6), 4)
   transitions.Add(7, (Smbl ')', Smbl 6), 5)
   transitions.Add(7, (Smbl '*', Smbl 6), 8)
   transitions.Add(7, (Smbl '+', Smbl 6), 7)
   transitions.Add(7, (Smbl '-', Smbl 6), 3)
   transitions.Add(7, (Smbl '/', Smbl 6), 6)
   transitions.Add(7, (Smbl '0', Smbl 6), 2)
   transitions.Add(7, (Smbl '1', Smbl 6), 2)
   transitions.Add(7, (Smbl '2', Smbl 6), 2)
   transitions.Add(7, (Smbl '3', Smbl 6), 2)
   transitions.Add(7, (Smbl '4', Smbl 6), 2)
   transitions.Add(7, (Smbl '5', Smbl 6), 2)
   transitions.Add(7, (Smbl '6', Smbl 6), 2)
   transitions.Add(7, (Smbl '7', Smbl 6), 2)
   transitions.Add(7, (Smbl '8', Smbl 6), 2)
   transitions.Add(7, (Smbl '9', Smbl 6), 2)
   transitions.Add(7, (Smbl (char 65535), Smbl 6), 65535)
   transitions.Add(3, (Smbl '\t', Smbl 2), 1)
   transitions.Add(3, (Smbl '\n', Smbl 2), 1)
   transitions.Add(3, (Smbl '\r', Smbl 2), 1)
   transitions.Add(3, (Smbl ' ', Smbl 2), 1)
   transitions.Add(3, (Smbl '(', Smbl 2), 4)
   transitions.Add(3, (Smbl ')', Smbl 2), 5)
   transitions.Add(3, (Smbl '*', Smbl 2), 8)
   transitions.Add(3, (Smbl '+', Smbl 2), 7)
   transitions.Add(3, (Smbl '-', Smbl 2), 3)
   transitions.Add(3, (Smbl '/', Smbl 2), 6)
   transitions.Add(3, (Smbl '0', Smbl 2), 2)
   transitions.Add(3, (Smbl '1', Smbl 2), 2)
   transitions.Add(3, (Smbl '2', Smbl 2), 2)
   transitions.Add(3, (Smbl '3', Smbl 2), 2)
   transitions.Add(3, (Smbl '4', Smbl 2), 2)
   transitions.Add(3, (Smbl '5', Smbl 2), 2)
   transitions.Add(3, (Smbl '6', Smbl 2), 2)
   transitions.Add(3, (Smbl '7', Smbl 2), 2)
   transitions.Add(3, (Smbl '8', Smbl 2), 2)
   transitions.Add(3, (Smbl '9', Smbl 2), 2)
   transitions.Add(3, (Smbl (char 65535), Smbl 2), 65535)
   transitions.Add(6, (Smbl '\t', Smbl 5), 1)
   transitions.Add(6, (Smbl '\n', Smbl 5), 1)
   transitions.Add(6, (Smbl '\r', Smbl 5), 1)
   transitions.Add(6, (Smbl ' ', Smbl 5), 1)
   transitions.Add(6, (Smbl '(', Smbl 5), 4)
   transitions.Add(6, (Smbl ')', Smbl 5), 5)
   transitions.Add(6, (Smbl '*', Smbl 5), 8)
   transitions.Add(6, (Smbl '+', Smbl 5), 7)
   transitions.Add(6, (Smbl '-', Smbl 5), 3)
   transitions.Add(6, (Smbl '/', Smbl 5), 6)
   transitions.Add(6, (Smbl '0', Smbl 5), 2)
   transitions.Add(6, (Smbl '1', Smbl 5), 2)
   transitions.Add(6, (Smbl '2', Smbl 5), 2)
   transitions.Add(6, (Smbl '3', Smbl 5), 2)
   transitions.Add(6, (Smbl '4', Smbl 5), 2)
   transitions.Add(6, (Smbl '5', Smbl 5), 2)
   transitions.Add(6, (Smbl '6', Smbl 5), 2)
   transitions.Add(6, (Smbl '7', Smbl 5), 2)
   transitions.Add(6, (Smbl '8', Smbl 5), 2)
   transitions.Add(6, (Smbl '9', Smbl 5), 2)
   transitions.Add(6, (Smbl (char 65535), Smbl 5), 65535)
   transitions.Add(2, (Smbl '\t', Smbl 1), 1)
   transitions.Add(2, (Smbl '\n', Smbl 1), 1)
   transitions.Add(2, (Smbl '\r', Smbl 1), 1)
   transitions.Add(2, (Smbl ' ', Smbl 1), 1)
   transitions.Add(2, (Smbl '(', Smbl 1), 4)
   transitions.Add(2, (Smbl ')', Smbl 1), 5)
   transitions.Add(2, (Smbl '*', Smbl 1), 8)
   transitions.Add(2, (Smbl '+', Smbl 1), 7)
   transitions.Add(2, (Smbl '-', Smbl 1), 3)
   transitions.Add(2, (Smbl '.', Eps), 11)
   transitions.Add(2, (Smbl '/', Smbl 1), 6)
   transitions.Add(2, (Smbl '0', Eps), 12)
   transitions.Add(2, (Smbl '1', Eps), 12)
   transitions.Add(2, (Smbl '2', Eps), 12)
   transitions.Add(2, (Smbl '3', Eps), 12)
   transitions.Add(2, (Smbl '4', Eps), 12)
   transitions.Add(2, (Smbl '5', Eps), 12)
   transitions.Add(2, (Smbl '6', Eps), 12)
   transitions.Add(2, (Smbl '7', Eps), 12)
   transitions.Add(2, (Smbl '8', Eps), 12)
   transitions.Add(2, (Smbl '9', Eps), 12)
   transitions.Add(2, (Smbl 'E', Eps), 10)
   transitions.Add(2, (Smbl 'e', Eps), 10)
   transitions.Add(2, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(11, (Smbl '\t', Eps), 1)
   transitions.Add(11, (Smbl '\n', Eps), 1)
   transitions.Add(11, (Smbl '\r', Eps), 1)
   transitions.Add(11, (Smbl ' ', Eps), 1)
   transitions.Add(11, (Smbl '(', Eps), 4)
   transitions.Add(11, (Smbl ')', Eps), 5)
   transitions.Add(11, (Smbl '*', Eps), 8)
   transitions.Add(11, (Smbl '+', Eps), 7)
   transitions.Add(11, (Smbl '-', Eps), 3)
   transitions.Add(11, (Smbl '/', Eps), 6)
   transitions.Add(11, (Smbl '0', Eps), 13)
   transitions.Add(11, (Smbl '1', Eps), 13)
   transitions.Add(11, (Smbl '2', Eps), 13)
   transitions.Add(11, (Smbl '3', Eps), 13)
   transitions.Add(11, (Smbl '4', Eps), 13)
   transitions.Add(11, (Smbl '5', Eps), 13)
   transitions.Add(11, (Smbl '6', Eps), 13)
   transitions.Add(11, (Smbl '7', Eps), 13)
   transitions.Add(11, (Smbl '8', Eps), 13)
   transitions.Add(11, (Smbl '9', Eps), 13)
   transitions.Add(11, (Smbl (char 65535), Eps), 65535)
   transitions.Add(12, (Smbl '\t', Smbl 1), 1)
   transitions.Add(12, (Smbl '\n', Smbl 1), 1)
   transitions.Add(12, (Smbl '\r', Smbl 1), 1)
   transitions.Add(12, (Smbl ' ', Smbl 1), 1)
   transitions.Add(12, (Smbl '(', Smbl 1), 4)
   transitions.Add(12, (Smbl ')', Smbl 1), 5)
   transitions.Add(12, (Smbl '*', Smbl 1), 8)
   transitions.Add(12, (Smbl '+', Smbl 1), 7)
   transitions.Add(12, (Smbl '-', Smbl 1), 3)
   transitions.Add(12, (Smbl '.', Eps), 11)
   transitions.Add(12, (Smbl '/', Smbl 1), 6)
   transitions.Add(12, (Smbl '0', Eps), 12)
   transitions.Add(12, (Smbl '1', Eps), 12)
   transitions.Add(12, (Smbl '2', Eps), 12)
   transitions.Add(12, (Smbl '3', Eps), 12)
   transitions.Add(12, (Smbl '4', Eps), 12)
   transitions.Add(12, (Smbl '5', Eps), 12)
   transitions.Add(12, (Smbl '6', Eps), 12)
   transitions.Add(12, (Smbl '7', Eps), 12)
   transitions.Add(12, (Smbl '8', Eps), 12)
   transitions.Add(12, (Smbl '9', Eps), 12)
   transitions.Add(12, (Smbl 'E', Eps), 10)
   transitions.Add(12, (Smbl 'e', Eps), 10)
   transitions.Add(12, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(10, (Smbl '\t', Eps), 1)
   transitions.Add(10, (Smbl '\n', Eps), 1)
   transitions.Add(10, (Smbl '\r', Eps), 1)
   transitions.Add(10, (Smbl ' ', Eps), 1)
   transitions.Add(10, (Smbl '(', Eps), 4)
   transitions.Add(10, (Smbl ')', Eps), 5)
   transitions.Add(10, (Smbl '*', Eps), 8)
   transitions.Add(10, (Smbl '+', Eps), 7)
   transitions.Add(10, (Smbl '-', Eps), 3)
   transitions.Add(10, (Smbl '/', Eps), 6)
   transitions.Add(10, (Smbl '0', Eps), 15)
   transitions.Add(10, (Smbl '1', Eps), 15)
   transitions.Add(10, (Smbl '2', Eps), 15)
   transitions.Add(10, (Smbl '3', Eps), 15)
   transitions.Add(10, (Smbl '4', Eps), 15)
   transitions.Add(10, (Smbl '5', Eps), 15)
   transitions.Add(10, (Smbl '6', Eps), 15)
   transitions.Add(10, (Smbl '7', Eps), 15)
   transitions.Add(10, (Smbl '8', Eps), 15)
   transitions.Add(10, (Smbl '9', Eps), 15)
   transitions.Add(10, (Smbl (char 65535), Eps), 65535)
   transitions.Add(9, (Smbl '\t', Smbl 7), 1)
   transitions.Add(9, (Smbl '\n', Smbl 7), 1)
   transitions.Add(9, (Smbl '\r', Smbl 7), 1)
   transitions.Add(9, (Smbl ' ', Smbl 7), 1)
   transitions.Add(9, (Smbl '(', Smbl 7), 4)
   transitions.Add(9, (Smbl ')', Smbl 7), 5)
   transitions.Add(9, (Smbl '*', Smbl 7), 8)
   transitions.Add(9, (Smbl '+', Smbl 7), 7)
   transitions.Add(9, (Smbl '-', Smbl 7), 3)
   transitions.Add(9, (Smbl '/', Smbl 7), 6)
   transitions.Add(9, (Smbl '0', Smbl 7), 2)
   transitions.Add(9, (Smbl '1', Smbl 7), 2)
   transitions.Add(9, (Smbl '2', Smbl 7), 2)
   transitions.Add(9, (Smbl '3', Smbl 7), 2)
   transitions.Add(9, (Smbl '4', Smbl 7), 2)
   transitions.Add(9, (Smbl '5', Smbl 7), 2)
   transitions.Add(9, (Smbl '6', Smbl 7), 2)
   transitions.Add(9, (Smbl '7', Smbl 7), 2)
   transitions.Add(9, (Smbl '8', Smbl 7), 2)
   transitions.Add(9, (Smbl '9', Smbl 7), 2)
   transitions.Add(9, (Smbl (char 65535), Smbl 7), 65535)
   transitions.Add(15, (Smbl '\t', Smbl 1), 1)
   transitions.Add(15, (Smbl '\n', Smbl 1), 1)
   transitions.Add(15, (Smbl '\r', Smbl 1), 1)
   transitions.Add(15, (Smbl ' ', Smbl 1), 1)
   transitions.Add(15, (Smbl '(', Smbl 1), 4)
   transitions.Add(15, (Smbl ')', Smbl 1), 5)
   transitions.Add(15, (Smbl '*', Smbl 1), 8)
   transitions.Add(15, (Smbl '+', Smbl 1), 7)
   transitions.Add(15, (Smbl '-', Smbl 1), 3)
   transitions.Add(15, (Smbl '/', Smbl 1), 6)
   transitions.Add(15, (Smbl '0', Eps), 16)
   transitions.Add(15, (Smbl '1', Eps), 16)
   transitions.Add(15, (Smbl '2', Eps), 16)
   transitions.Add(15, (Smbl '3', Eps), 16)
   transitions.Add(15, (Smbl '4', Eps), 16)
   transitions.Add(15, (Smbl '5', Eps), 16)
   transitions.Add(15, (Smbl '6', Eps), 16)
   transitions.Add(15, (Smbl '7', Eps), 16)
   transitions.Add(15, (Smbl '8', Eps), 16)
   transitions.Add(15, (Smbl '9', Eps), 16)
   transitions.Add(15, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(13, (Smbl '\t', Smbl 1), 1)
   transitions.Add(13, (Smbl '\n', Smbl 1), 1)
   transitions.Add(13, (Smbl '\r', Smbl 1), 1)
   transitions.Add(13, (Smbl ' ', Smbl 1), 1)
   transitions.Add(13, (Smbl '(', Smbl 1), 4)
   transitions.Add(13, (Smbl ')', Smbl 1), 5)
   transitions.Add(13, (Smbl '*', Smbl 1), 8)
   transitions.Add(13, (Smbl '+', Smbl 1), 7)
   transitions.Add(13, (Smbl '-', Smbl 1), 3)
   transitions.Add(13, (Smbl '/', Smbl 1), 6)
   transitions.Add(13, (Smbl '0', Eps), 14)
   transitions.Add(13, (Smbl '1', Eps), 14)
   transitions.Add(13, (Smbl '2', Eps), 14)
   transitions.Add(13, (Smbl '3', Eps), 14)
   transitions.Add(13, (Smbl '4', Eps), 14)
   transitions.Add(13, (Smbl '5', Eps), 14)
   transitions.Add(13, (Smbl '6', Eps), 14)
   transitions.Add(13, (Smbl '7', Eps), 14)
   transitions.Add(13, (Smbl '8', Eps), 14)
   transitions.Add(13, (Smbl '9', Eps), 14)
   transitions.Add(13, (Smbl 'E', Eps), 10)
   transitions.Add(13, (Smbl 'e', Eps), 10)
   transitions.Add(13, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(14, (Smbl '\t', Smbl 1), 1)
   transitions.Add(14, (Smbl '\n', Smbl 1), 1)
   transitions.Add(14, (Smbl '\r', Smbl 1), 1)
   transitions.Add(14, (Smbl ' ', Smbl 1), 1)
   transitions.Add(14, (Smbl '(', Smbl 1), 4)
   transitions.Add(14, (Smbl ')', Smbl 1), 5)
   transitions.Add(14, (Smbl '*', Smbl 1), 8)
   transitions.Add(14, (Smbl '+', Smbl 1), 7)
   transitions.Add(14, (Smbl '-', Smbl 1), 3)
   transitions.Add(14, (Smbl '/', Smbl 1), 6)
   transitions.Add(14, (Smbl '0', Eps), 14)
   transitions.Add(14, (Smbl '1', Eps), 14)
   transitions.Add(14, (Smbl '2', Eps), 14)
   transitions.Add(14, (Smbl '3', Eps), 14)
   transitions.Add(14, (Smbl '4', Eps), 14)
   transitions.Add(14, (Smbl '5', Eps), 14)
   transitions.Add(14, (Smbl '6', Eps), 14)
   transitions.Add(14, (Smbl '7', Eps), 14)
   transitions.Add(14, (Smbl '8', Eps), 14)
   transitions.Add(14, (Smbl '9', Eps), 14)
   transitions.Add(14, (Smbl 'E', Eps), 10)
   transitions.Add(14, (Smbl 'e', Eps), 10)
   transitions.Add(14, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(16, (Smbl '\t', Smbl 1), 1)
   transitions.Add(16, (Smbl '\n', Smbl 1), 1)
   transitions.Add(16, (Smbl '\r', Smbl 1), 1)
   transitions.Add(16, (Smbl ' ', Smbl 1), 1)
   transitions.Add(16, (Smbl '(', Smbl 1), 4)
   transitions.Add(16, (Smbl ')', Smbl 1), 5)
   transitions.Add(16, (Smbl '*', Smbl 1), 8)
   transitions.Add(16, (Smbl '+', Smbl 1), 7)
   transitions.Add(16, (Smbl '-', Smbl 1), 3)
   transitions.Add(16, (Smbl '/', Smbl 1), 6)
   transitions.Add(16, (Smbl '0', Eps), 16)
   transitions.Add(16, (Smbl '1', Eps), 16)
   transitions.Add(16, (Smbl '2', Eps), 16)
   transitions.Add(16, (Smbl '3', Eps), 16)
   transitions.Add(16, (Smbl '4', Eps), 16)
   transitions.Add(16, (Smbl '5', Eps), 16)
   transitions.Add(16, (Smbl '6', Eps), 16)
   transitions.Add(16, (Smbl '7', Eps), 16)
   transitions.Add(16, (Smbl '8', Eps), 16)
   transitions.Add(16, (Smbl '9', Eps), 16)
   transitions.Add(16, (Smbl (char 65535), Smbl 1), 65535)
   new FST<_,_>(startState, finishState, transitions)

let actions () =
   [|

      (fun (gr : GraphTokenValue<_>) ->
                              None );
      (fun (gr : GraphTokenValue<_>) ->
                                                           NUMBER(gr) |> Some );
      (fun (gr : GraphTokenValue<_>) ->
                       MINUS(gr) |> Some );
      (fun (gr : GraphTokenValue<_>) ->
                       LBRACE(gr) |> Some );
      (fun (gr : GraphTokenValue<_>) ->
                       RBRACE(gr) |> Some );
      (fun (gr : GraphTokenValue<_>) ->
                       DIV(gr)|> Some );
      (fun (gr : GraphTokenValue<_>) ->
                       PLUS(gr)|> Some );
      (fun (gr : GraphTokenValue<_>) ->
                        POW(gr)|> Some );
      (fun (gr : GraphTokenValue<_>) ->
                       MULT(gr)|> Some );

   |]


let alphabet () = 
 new HashSet<_>([| Smbl (char 65535); Smbl '\t'; Smbl '\n'; Smbl '\r'; Smbl ' '; Smbl '('; Smbl ')'; Smbl '*'; Smbl '+'; Smbl '-'; Smbl '/'; Smbl '0'; Smbl '1'; Smbl '2'; Smbl '3'; Smbl '4'; Smbl '5'; Smbl '6'; Smbl '7'; Smbl '8'; Smbl '9'; Smbl '.'; Smbl 'E'; Smbl 'e';|])

let tokenize eof approximation = Tokenize (fstLexer()) (actions()) (alphabet()) eof approximation
