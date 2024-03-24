open System

// Reference type
let nullObj: string = null

// Nullable type
let nullPri = Nullable<int>()

let fromNullObj = Option.ofObj nullObj
let fromNullPri = Option.ofNullable nullPri

let toNullObj = Option.toObj fromNullObj
let toNullPri = Option.toNullable fromNullPri

let resultPM input =
    match input with
    | Some value -> value
    | None -> "-------"

let resultDV = Option.defaultValue "--------" fromNullObj

let resultFP = fromNullObj |> Option.defaultValue "--------"

let resultFPA = fromNullObj |> Option.defaultValue "-------"

// string option -> string
let setUnknownAsDefault = Option.DefaultValue "????"

let result = setUnknownAsDefault fromNullObj

let result = fromNullObj |> setUnknownAsDefault
