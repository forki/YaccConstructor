﻿// Driver.fs contains main functions for test user application.
//
//  Copyright 2009, 2010, 2011 Semen Grigorev <rsdpisuy@gmail.com>
//
//  This file is part of YaccConctructor.
//
//  YaccConstructor is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

open Microsoft.FSharp.Text.Lexing
open Yard.Generators.GNESCCGenerator
open Yard.Generators.GNESCCGenerator.Tables_seq
open Microsoft.FSharp.Text.Lexing


//path -- path to input file
let run path =
    //Create lexer
    let content = System.IO.File.ReadAllText(path)
    let reader = new System.IO.StringReader(content)    
    let buf = LexBuffer<_>.FromTextReader reader
    let lexer = Lexer_seq.Lexer(buf)

    //Create tables
    let tables = tables

    //Run parser
    // forest -- derivation forest    
    let forest =
        let ti = new TableInterpreter(tables)
        ti.Run lexer

    let f x =
        match x with
        | NT_gnesccStart -> "start"
        | NT_s -> "s"
        | _ -> "asdas"
    Seq.iter (Yard.Generators.GNESCCGenerator.AST.PrintTree (fun x -> symbolIdx.[x] |> getName |> f)) forest

    let result =
        //run forest interpretation (action code calculation)
        let res = 
            Seq.map 
                (ASTInterpretator.interp GNESCC.Actions.ruleToAction GNESCC.Regexp.ruleToRegex)
                forest
        res

    printfn "Result %A\n" result

do 
    run @"..\..\..\..\Tests\GNESCC\regexp\simple\alt\alt_1.yrd.in "
    |> ignore
    System.Console.ReadLine() |> ignore
