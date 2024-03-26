// Sum of the squares of the odd numbers
let nums = [ 1..10 ]

// Step by step
nums
|> List.filter (fun v -> v % 2 = 1)
|> List.map (fun v -> v * v)
|> List.sum

// Using option and choose
nums
|> List.choose (fun v -> if v % 2 = 1 then Some(v * v) else None)
|> List.sum

// Fold
nums |> List.fold (fun acc v -> acc + if v % 2 = 1 then (v * v) else 0) 0

// Do not use reduce for this.
// Firstly, reduce is partial function, so we need to handle empty list
// More importantly, the first item in the list is not processed by the function,
// So the result will probably be incorrect
match nums with
| [] -> 0
| items -> items |> List.reduce (fun acc v -> acc + if v % 2 = 1 then (v * v) else 0)

// The recommended version
nums |> List.sumBy (fun v -> if v % 2 = 1 then (v * v) else 0)
