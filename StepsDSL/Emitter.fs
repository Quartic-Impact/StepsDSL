module StepsDSL.Emitter

open StepsDSL.Types
open System.Text.Json
open System.Text.Json.Serialization
open System.IO

type StepConverter() =
    inherit JsonConverter<Step>()

    // We never deserialize cry about it
    override _.Read(_, _, _) = failwith "Balls"

    override _.Write(writer, step, opts) =
        (step.raw, opts)
        |> JsonSerializer.SerializeToUtf8Bytes
        |> writer.WriteRawValue

let genToRet (s: Step []) =
    let opts = JsonSerializerOptions()
    opts.Converters.Add(StepConverter())
    opts.WriteIndented <- true
    JsonSerializer.Serialize(s, opts)

let genToConsole = genToRet >> printfn "%s"

let genToFile path s = File.WriteAllText(path, genToRet s)

let genToFileAsync path s =
    File.WriteAllTextAsync(path, genToRet s)
    |> Async.AwaitTask