module StepsDSL.DSL

open StepsDSL.Types

let inline private unionToStr u = (string u).ToUpper()

let private toObjArr (arr: 'a[]) = arr |> Array.map (fun f -> f :> obj)

let (>>>) (s1: Step[]) s2 = Array.append s1 s2

let setMapSounds s = [| Smsds { mapSounds = s }|]

let pauseBGM (mode: PauseBGMTime) = [| Pbgm { mode = unionToStr mode }|]

let setZoomBlur name dur fIn fOut (t: ZoomType) = 
    [| Szmblr
        {
            zoomType = unionToStr t
            name = name
            duration = dur
            fadeIn = fIn
            fadeOut = fOut
        } 
    |]

let setMobilityBlock value = [| Smbb { value = value } |]

let setOverlay time col alpha overMsg =
    [| Solay 
        {
            color = col
            alpha = alpha
            time = time
            overMessage = overMsg
        }
    |]

let changeVarBool vName (cType: ChangeVarType) value = 
    [| Cvb 
        {
            varName = vName
            changeType = unionToStr cType
            value = value
        }
    |]

let ifElse cond thenS elseS =
    [|
        If'
            {
                withElse = elseS <> null
                condition = cond
                thenStep = toObjArr thenS
                elseStep = toObjArr elseS
            }
    |]

let ifThen cond thenS = ifElse cond thenS null

let noneStep: Step[] = [||]