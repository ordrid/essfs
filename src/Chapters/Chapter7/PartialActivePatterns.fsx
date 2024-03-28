open System

let (|ValidDate|_|) (input: string) =
    match DateTime.TryParse(input) with
    | true, value -> Some value
    | false, _ -> None

let parse input =
    match input with
    | ValidDate dt -> printfn "%A" dt
    | _ -> printfn $"'%s{input}' is not a valid date"

let isDate = parse "2019-12-20"

let isNotDate = parse "Hello"
