module StepsDSL.Tests

open NUnit.Framework
open StepsDSL

let testData: Events = [|
    SetMapSounds ""
    SetZoomBlur(Light, 4, 0, 2, "")
|]

(*[<SetUp>]
let Setup () =
    ()*)

[<Test>]
let FullTest () =
    let expected = """{
  "event": []
}
"""
    
    let actual = genCutscene testData
    
    Assert.AreEqual(expected, actual)