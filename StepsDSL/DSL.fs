module StepsDSL.DSL

open StepsDSL.Types

let inline private unionToStr u = (string u).ToUpper()

let private toObjArr (arr: Step[]) = arr |> Array.map (fun f -> f.raw)

let (>>>) (s1: Step[]) s2 = Array.append s1 s2

let setMapSounds s = [| SetMapSounds { mapSounds = s }|]

let pauseBGM (mode: PauseBGMTime) = [| PauseBgm { mode = unionToStr mode }|]

let setZoomBlur name dur fIn fOut (t: ZoomType) = 
    [| SetZoomBlur
        {
            zoomType = unionToStr t
            name = name
            duration = dur
            fadeIn = fIn
            fadeOut = fOut
        } 
    |]

let setMobilityBlock value = [| SetMobilityBlock { value = value } |]

let setOverlay time col alpha overMsg =
    [| SetOverlay 
        {
            color = col
            alpha = alpha
            time = time
            overMessage = overMsg
        }
    |]

let changeVarBool vName (cType: ChangeVarType) value = 
    [| ChangeVarBool 
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