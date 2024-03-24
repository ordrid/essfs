open System

let tryParseDateTime (input: string) =
    let (success, value) = DateTime.TryParse input
    if success then Some value else None

let tryParseDateTime (input: string) =
    match DateTime.TryParse input with
    | true, result -> Some result
    | false, _ -> None

let tryParseDateTime (input: string) =
    match DateTime.TryParse input with
    | true, result -> Some result
    | _, _ -> None

let tryParseDateTime (input: string) =
    match DateTime.TryParse input with
    | true, result -> Some result
    | _ -> None

let isDate = tryParseDateTime "2019-08-01"

let isNotDate = tryParseDateTime "Hello"
