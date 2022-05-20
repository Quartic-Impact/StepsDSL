module StepsDSL.Tests

open NUnit.Framework
open StepsDSL.DSL
open StepsDSL.Types
open StepsDSL.Emitter

[<Test>]
let FullTest () =
    let expected =
        """[{
  "mapSounds": "",
  "type": "SET_MAP_SOUNDS"
},{
  "mode": "IMMEDIATELY",
  "type": "PAUSE_BGM"
},{
  "zoomType": "LIGHT",
  "fadeIn": 0,
  "fadeOut": 1,
  "duration": 4,
  "name": "",
  "type": "SET_ZOOM_BLUR"
},{
  "value": "SAVE",
  "type": "SET_MOBILITY_BLOCK"
},{
  "color": "black",
  "alpha": 1,
  "time": 0,
  "overMessage": false,
  "type": "SET_OVERLAY"
},{
  "withElse": true,
  "condition": "g.exploreNotified == true",
  "thenStep": [],
  "elseStep": [
    {
      "varName": "g.exploreNotified",
      "changeType": "SET",
      "value": false,
      "type": "CHANGE_VAR_BOOL"
    }
  ],
  "type": "IF"
}
]"""

    let testData =
        setMapSounds ""
        >>> pauseBGM Immediately
        >>> setZoomBlur "" 4 0 1 Light
        >>> setMobilityBlock "SAVE"
        >>> setOverlay 0 "black" 1 false
        >>> ifElse "g.exploreNotified == true" noneStep (changeVarBool "g.exploreNotified" Set false)

    let actual = genToRet testData

    printfn $"%s{actual}"
    
    Assert.AreEqual(expected, actual)