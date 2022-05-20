module StepsDSL.Types


type PauseBGMTime = | Immediately
type ZoomType = Light | Dark
type ChangeVarType = | Set

type  SET_MAP_SOUNDS = 
    { mapSounds: string }
    member this.``type`` = this.GetType().Name

type  PAUSE_BGM = 
    { mode: string }
    member this.``type`` = this.GetType().Name

type  SET_ZOOM_BLUR =
    {
        zoomType: string
        fadeIn: double // TODO: are these ints?
        fadeOut: double
        duration: double
        name: string
    }
    member this.``type`` = this.GetType().Name

type  SET_MOBILITY_BLOCK = 
    { value: string }
    member this.``type`` = this.GetType().Name

type  SET_OVERLAY =
    {
        color: string
        alpha: double
        time: double
        overMessage: bool
    }
    member this.``type`` = this.GetType().Name

type  CHANGE_VAR_BOOL =
    {
        varName: string
        changeType: string
        value: bool
    }
    member this.``type`` = this.GetType().Name

type  IF =
    {
        withElse: bool
        condition: string
        thenStep: obj[]
        elseStep: obj[]
    }
    member this.``type`` = this.GetType().Name

type  Step =
    | Smsds of SET_MAP_SOUNDS
    | Pbgm of PAUSE_BGM
    | Szmblr of SET_ZOOM_BLUR
    | Smbb of SET_MOBILITY_BLOCK
    | Solay of SET_OVERLAY
    | Cvb of CHANGE_VAR_BOOL
    | If' of IF