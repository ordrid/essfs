// let add x y = x + y
// let sum = add 1 4
// let add = fun x y -> x + y
// let sum = add 1 4
// let apply f x y = f x y
// let sum = apply (fun x y -> x + y) 1 4

open System

// unit -> int
let rnd () =
    let rand = Random()
    rand.Next(100)

// NOTE: uses scoping rules to re-use the same instance of Random class each time `rnd` is called.
// unit -> int
let rnd =
    let rand = Random()
    fun () -> rand.Next(100)


List.init 50 (fun _ -> rnd ())
