module StepsDSL.Types


type PauseBGMTime = | Immediately

type ZoomType =
    | Light
    | Dark

type ChangeVarType = | Set

type SET_MAP_SOUNDS =
    {mapSounds: string}
    member this.``type`` = this.GetType().Name

type PAUSE_BGM =
    {mode: string}
    member this.``type`` = this.GetType().Name

type SET_ZOOM_BLUR =
    {zoomType: string
     fadeIn: double 
     fadeOut: double
     duration: double
     name: string}
    member this.``type`` = this.GetType().Name

type SET_MOBILITY_BLOCK =
    {value: string}
    member this.``type`` = this.GetType().Name

type SET_OVERLAY =
    {color: string
     alpha: double
     time: double
     overMessage: bool}
    member this.``type`` = this.GetType().Name

type CHANGE_VAR_BOOL =
    {varName: string
     changeType: string
     value: bool}
    member this.``type`` = this.GetType().Name

type IF =
    {withElse: bool
     condition: string
     thenStep: obj []
     elseStep: obj []}
    member this.``type`` = this.GetType().Name

type Step =
    | SetMapSounds of SET_MAP_SOUNDS
    | PauseBgm of PAUSE_BGM
    | SetZoomBlur of SET_ZOOM_BLUR
    | SetMobilityBlock of SET_MOBILITY_BLOCK
    | SetOverlay of SET_OVERLAY
    | ChangeVarBool of CHANGE_VAR_BOOL
    | If' of IF

    member this.raw: obj =
        match this with
        | If' item -> item
        | PauseBgm bgm -> bgm
        | SetOverlay olay -> olay
        | ChangeVarBool cvb -> cvb
        | SetMapSounds sms -> sms
        | SetMobilityBlock smb -> smb
        | SetZoomBlur szb -> szb