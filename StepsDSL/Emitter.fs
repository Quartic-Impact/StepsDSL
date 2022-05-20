module StepsDSL.Emitter

open StepsDSL.Types
open System.Text.Json
open System.Text.Json.Serialization
open System.IO

type StepConverter() =
    inherit JsonConverter<Step>()

let genToRet (s: Step[]) = JsonSerializer.Serialize s

let genToConsole = genToRet >> printfn "%s"

let genToFile path s = 
    File.WriteAllText(path, genToRet s)

let genToFileAsync path s =
    File.WriteAllTextAsync(path, genToRet s)
    |> Async.AwaitTask