//this tables was generated by RACC
//source grammar:..\Tests\RACC\test_cls\\test_cls.yrd
//date:12/8/2010 16:59:51

#light "off"
module Yard.Generators.RACCGenerator.Tables_Cls

open Yard.Generators.RACCGenerator

let autumataDict = 
dict [|("raccStart",{ 
   DIDToStateMap = dict [|(0,(State 0));(1,(State 1));(2,DummyState)|];
   DStartState   = 0;
   DFinaleStates = Set.ofArray [|1|];
   DRules        = Set.ofArray [|{ 
   FromStateID = 0;
   Symbol      = (DSymbol "s");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbS 0))|]|];
   ToStateID   = 1;
}
;{ 
   FromStateID = 1;
   Symbol      = Dummy;
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 0))|]|];
   ToStateID   = 2;
}
|];
}
);("s",{ 
   DIDToStateMap = dict [|(0,(State 0));(1,(State 1));(2,(State 2));(3,DummyState);(4,DummyState);(5,DummyState)|];
   DStartState   = 2;
   DFinaleStates = Set.ofArray [|0;1;2|];
   DRules        = Set.ofArray [|{ 
   FromStateID = 0;
   Symbol      = (DSymbol "MINUS");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6))|]|];
   ToStateID   = 0;
}
;{ 
   FromStateID = 0;
   Symbol      = (DSymbol "PLUS");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6))|]|];
   ToStateID   = 1;
}
;{ 
   FromStateID = 0;
   Symbol      = Dummy;
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TAlt1E 6))|]|];
   ToStateID   = 3;
}
;{ 
   FromStateID = 1;
   Symbol      = (DSymbol "MINUS");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7))|]|];
   ToStateID   = 0;
}
;{ 
   FromStateID = 1;
   Symbol      = (DSymbol "PLUS");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7))|]|];
   ToStateID   = 1;
}
;{ 
   FromStateID = 1;
   Symbol      = Dummy;
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5));(FATrace (TAlt2E 7))|]|];
   ToStateID   = 4;
}
;{ 
   FromStateID = 2;
   Symbol      = (DSymbol "MINUS");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1))|]|];
   ToStateID   = 0;
}
;{ 
   FromStateID = 2;
   Symbol      = (DSymbol "PLUS");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1))|]|];
   ToStateID   = 1;
}
;{ 
   FromStateID = 2;
   Symbol      = Dummy;
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TAlt1S 6));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TAlt2S 7));(FATrace (TSeqS 5));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1));(FATrace (TClsE 1));(FATrace (TSeqE 8))|];List.ofArray [|(FATrace (TSeqS 8));(FATrace (TClsS 1))|]|];
   ToStateID   = 5;
}
|];
}
)|]

let items = 
List.ofArray [|("raccStart",0);("raccStart",1);("raccStart",2);("s",0);("s",1);("s",2);("s",3);("s",4);("s",5)|]

let gotoSet = 
Set.ofArray [|(-1144263691,("s",0));(-1144264106,("s",0));(-1144264172,("s",0));(-1239003080,("raccStart",2));(-1239003111,("s",3));(-635149922,("raccStart",1));(-946926030,("s",1));(1723491585,("s",0));(1800920813,("s",4));(1800920844,("s",3));(1800920910,("s",5));(452886726,("s",1));(452886823,("s",1));(452886885,("s",1))|]

