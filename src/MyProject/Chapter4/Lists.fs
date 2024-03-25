let empty = []

let fiveIntegers = [ 2; 3; 4; 1; 4 ]

let ascendingIntegers = [ 1..5 ]

let listComprehensionIntegers =
    [ for x in 1..5 do
          x ]

// head :: tail
let extendItems = 6 :: ascendingIntegers

let readList items =
    match items with
    | [] -> "Empty list"
    | [ head ] -> $"Head: {head}"
    | head :: tail -> sprintf "Head: %A and Tail: %A" head tail

// let emptyList = readList []

let multipleList = readList [ 1; 2; 3; 4; 5 ]

let singleItemList = readList [ 1 ]


let list1 = [ 1..5 ]
let list2 = [ 3..7 ]
let emptyList = []

let joined = list2 @ list2
let joinedEmpty = list1 @ emptyList
let emptyJoined = emptyList @ list1

let joined2 = List.concat [ list1; list2 ]

let myList = [ 1..9 ]

let getEvens items =
    items |> List.filter (fun x -> x % 2 = 0)

let evens = getEvens myList

let sum items = items |> List.sum

let mySum = sum myList

let triple items = items |> List.map (fun x -> x * 3)

let myTriples = triple [ 1..5 ]

let tuples = [ (1, 0.25M); (5, 0.25M); (1, 2.25M); (1, 125M); (7, 10.9M) ]

let sumTuples tuples =
    tuples |> List.map (fun (q, p) -> decimal q * p) |> List.sum

let sumTuples2 tuples =
    tuples |> List.sumBy (fun (q, p) -> decimal q * p)

[ 1..10 ] |> List.fold (fun acc v -> acc + v) 0

[ 1..10 ] |> List.fold (+) 0

[ 1..10 ] |> List.fold (fun acc v -> acc * v) 1

[ 1..10 ] |> List.fold (*) 1

let getTotal tuples =
    tuples |> List.fold (fun acc (q, p) -> acc + decimal q * p) 0M

let getTotal2 tuples =
    (0M, tuples) ||> List.fold (fun acc (q, p) -> acc + decimal q * p)
