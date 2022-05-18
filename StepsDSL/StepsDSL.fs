module StepsDSL

open System.Text.Json
open System.Text.Json.Serialization

let inline unionToStr u = (string u).ToUpper()

// TODO: Remove my OOP code ew -- sink

type EventBase(t: string) =
    [<JsonPropertyName "type">]
    member _.TYPE = t

type Events = EventBase[]

type SetMapSounds(sounds: string) =
    inherit EventBase("SET_MAP_SOUNDS")
    member _.mapSounds = sounds

type PauseBGMTime = | Immediately

type PauseBGM(mode: PauseBGMTime) =
    inherit EventBase("PAUSE_BGM")
    member _.mode = unionToStr mode

type ZoomType = Light | Dark
type SetZoomBlur(zType: ZoomType, duration: double, fadeIn: double, fadeOut: double, name: string) =
    inherit EventBase("SET_ZOOM_BLUR")
    member _.zoomType = unionToStr zType
    member _.fadeIn = fadeIn
    member _.fadeOut = fadeOut
    member _.duration = duration
    member _.name = name

type SetMobilityBlock(value: string) =
    inherit EventBase("SET_MOBILITY_BLOCK")
    member _.value = value

type SetOverlay(color: string, alpha: double, time: double, overMsg: bool) =
    inherit EventBase("SET_OVERLAY")
    member _.color = color
    member _.alpha = alpha
    member _.time = time
    member _.overMessage = overMsg

type ChangeVarType = | Set
type ChangeVarBool(name: string, changeType: ChangeVarType, value: bool) =
    inherit EventBase("CHANGE_VAR_BOOL")
    member _.varName = name
    member _.changeType = changeType.ToString().ToLower()
    member _.value = value

type If(condition: string, thenStep: Events, ?elseStep: Events) =
    inherit EventBase("IF")
    member _.withElse with get() = Option.isSome elseStep
    member _.condition = condition

    member _.thenStep = thenStep
    member _.elseStep = defaultArg elseStep null

type Cutscene(events: Events) =
    member _.event = events

let genCutscene (events: Events) =
    let options = JsonSerializerOptions()
    options.WriteIndented <- true // not minified!
    options.IncludeFields <- true

    // TODO polymorphic recursive serialisation doesnt work, SH*T
    JsonSerializer.Serialize(Cutscene events, options)