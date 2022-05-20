module StepsDSL.Tests

open NUnit.Framework
open StepsDSL.DSL
open StepsDSL.Types
open StepsDSL.Emitter

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

    let testData =
      setMapSounds ""
      >>> pauseBGM Immediately
      >>> setZoomBlur "" 4 0 1 Light
      >>> setMobilityBlock "SAVE"
      >>> setOverlay 0 "black" 1 false
      >>> ifElse 
          "g.exploreNotified == true"
          noneStep
          (changeVarBool "g.exploreNotified" Set false)

    let actual = genToRet testData
    
    Assert.AreEqual(expected, actual)