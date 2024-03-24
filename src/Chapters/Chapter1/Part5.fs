(* Alternative Approach 2 of 2: Using data structures of discriminated unions. *)
type Customer =
    | Registered of Id: string * IsEligible: bool
    | Guest of Id: string

// let calculateTotal customer spend =
//     let discount =
//         match customer with
//         | Registered(IsEligible = true) when spend >= 100.0M -> spend * 0.1M
//         | _ -> 0.0M
//     spend - discount

// Customer -> unit option
let (|IsEligible|_|) customer =
    match customer with
    | Registered(IsEligible = true) -> Some()
    | _ -> None

// Customer -> decimal -> decimal
let calculateTotal customer spend =
    let discount =
        match customer with
        | IsEligible when spend >= 100.0M -> spend * 0.1M
        | _ -> 0.0M

    spend - discount

let john = Registered(Id = "John", IsEligible = true)
let mary = Registered(Id = "Mary", IsEligible = true)
let richard = Registered(Id = "Richard", IsEligible = false)
let sarah = Guest(Id = "Sarah")
