//this file was generated by GNESCC
//source grammar:first_grammar.yrd
//date:14.12.2011 21:27:27

module GNESCC.Actions

open Yard.Generators.GNESCCGenerator

let getUnmatched x expectedType =
    "Unexpected type of node\nType " + x.ToString() + " is not expected in this position\n" + expectedType + " was expected." |> failwith
let e0 expr = 
    let inner  = 
        match expr with
        | REAlt(Some(x), None) -> 
            let yardLAltAction expr = 
                match expr with
                | RESeq [gnescc_x0; gnescc_x1] -> 
                    let (gnescc_x0) =
                        let yardElemAction expr = 
                            match expr with
                            | RELeaf tA -> tA :?> 'a
                            | x -> getUnmatched x "RELeaf"

                        yardElemAction(gnescc_x0)
                    let (gnescc_x1) =
                        let yardElemAction expr = 
                            match expr with
                            | RELeaf e -> (e :?> _ ) 
                            | x -> getUnmatched x "RELeaf"

                        yardElemAction(gnescc_x1)
                    (gnescc_x0,gnescc_x1 )
                | x -> getUnmatched x "RESeq"

            yardLAltAction x 
        | REAlt(None, Some(x)) -> 
            let yardRAltAction expr = 
                match expr with
                | RESeq [gnescc_x0] -> 
                    let (gnescc_x0) =
                        let yardElemAction expr = 
                            match expr with
                            | RELeaf tB -> tB :?> 'a
                            | x -> getUnmatched x "RELeaf"

                        yardElemAction(gnescc_x0)
                    (gnescc_x0 )
                | x -> getUnmatched x "RESeq"

            yardRAltAction x 
        | x -> getUnmatched x "REAlt"
    box (inner)

let ruleToAction = dict [|(1,e0)|]

