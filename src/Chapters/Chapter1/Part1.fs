(* Naive modelling using the tuple type *)

// type Customer = string * bool * bool

// Customer = string * bool * bool
// let fred: Customer = ("Fred", true, true)

// decomposing a tuple
// let (id, isEligible, isRegistered) = fred

(* Modelling using the record type *)

type Customer =
    { Id: string
      IsEligible: bool
      IsRegistered: bool }

// Customer -> decimal -> decimal
let calculateTotal customer spend =
    let discount =
        if customer.IsEligible && spend >= 100.0M then
            (spend * 0.1M)
        else
            0.0M

    let total = spend - discount
    total

let john =
    { Id = "John"
      IsEligible = true
      IsRegistered = true }

let mary =
    { Id = "Mary"
      IsEligible = true
      IsRegistered = true }

let richard =
    { Id = "Richard"
      IsEligible = false
      IsRegistered = true }

let sarah =
    { Id = "Sarah"
      IsEligible = false
      IsRegistered = true }

let assertJohn = calculateTotal john 100.0M = 90.0M
let assertMary = calculateTotal mary 99.0M = 99.0M
let assertRichard = calculateTotal mary 100.0M = 100.0M
let assertSarah = calculateTotal mary 100.0M = 100.0M
