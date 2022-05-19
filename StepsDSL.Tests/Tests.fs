module StepsDSL.Tests

open NUnit.Framework
open StepsDSL

(*[<SetUp>]
let Setup () =
    ()*)

[<Test>]
let FullTest () =
    let expected = """{
  "event": [
    {
      "type": "SET_MAP_SOUNDS"
    },
    {
      "type": "SET_ZOOM_BLUR"
    }
  ]
}"""
    let testData: Events =
        [|
            SetMapSounds ""
            SetZoomBlur(Light, 4, 0, 2, "")
        |]

    let actual = genCutscene testData
    
    Assert.AreEqual(expected, actual)