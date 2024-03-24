let calculateTotal customer spend = ...

let partial = calculateTotal john

let complete = partial 100.0M

//Trying to add a parameter out of order does not compile
let doesNotWork = calculateTotal 100M

// Decimal -> Decimal
let partial = calculateTotal john

// Decimal = partial 100.0M
let complete = partial 100.0M

let complete = 100.0M |> calculate john

let assertJohn = calculateTotal john 100.0M = 90.0M

let areEqual expected actual =
    expected = actual

let assertJohn = areEqual 90.0M (calculateTotal john 100.0M)

// 'a -> 'a -> bool
let isEqualTo expected actual =
    expected = actual

let assertJohn = calculateTotal john 100.0M |> isEqualTo 90.0m

// 'a -> ('a -> 'b) -> 'b
let (|>) v f = f v

