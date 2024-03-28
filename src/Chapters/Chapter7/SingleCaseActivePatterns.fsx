open System

let (|CharacterCount|) (input: string) = input.Length

let (|ContainsANumber|) (input: string) =
    input |> Seq.filter Char.IsDigit |> Seq.length > 0

let (|IsValidPassword|) input =
    match input with
    | CharacterCount len when len < 8 -> (false, "Password must be at least 8 characters")
    | ContainsANumber false -> (false, "Password must contain at lease 1 digit")
    | _ -> (true, "")

let setPassword input =
    match input with
    | IsValidPassword(true, _) as pwd -> Ok pwd
    | IsValidPassword(false, failureReason) -> Error $"Password not set: %s{failureReason}"

let badPassword = setPassword "password"
let goodPassword = setPassword "passw0rd"
