module StepsDSL


let inline unionToStr u = (string u).ToUpper()

type PauseBGMTime = | Immediately
type ZoomType = Light | Dark
type ChangeVarType = | Set

type internal SET_MAP_SOUNDS = 
    { mapSounds: string }
    member this.``type`` = this.GetType().Name

type internal PAUSE_BGM = 
    { mode: string }
    member this.``type`` = this.GetType().Name

type internal SET_ZOOM_BLUR =
    {
        zoomType: string
        fadeIn: double // TODO: are these ints?
        fadeOut: double
        duration: double
        name: string
    }
    member this.``type`` = this.GetType().Name

type internal SET_MOBILITY_BLOCK = 
    { value: string }
    member this.``type`` = this.GetType().Name

type internal SET_OVERLAY =
    {
        color: string
        alpha: double
        time: double
        overMessage: string
    }
    member this.``type`` = this.GetType().Name

type internal CHANGE_VAR_BOOL =
    {
        varName: string
        changeType: string
        value: bool
    }
    member this.``type`` = this.GetType().Name

type internal IF =
    {
        withElse: bool
        condition: string
        thenStep: obj[]
        elseStep: obj[]
    }
    member this.``type`` = this.GetType().Name

type internal Step =
    | SET_MAP_SOUNDS of SET_MAP_SOUNDS
    | PAUSE_BGM of PAUSE_BGM
    | SET_ZOOM_BLUR of SET_ZOOM_BLUR
    | SET_MOBILITY_BLOCK of SET_MOBILITY_BLOCK
    | SET_OVERLAY of SET_OVERLAY
    | CHANGE_VAR_BOOL of CHANGE_VAR_BOOL
    | IF of IF