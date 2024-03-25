let myList = [ 1; 2; 3; 4; 5; 7; 6; 5; 4; 3 ]

let gbResult = myList |> List.groupBy (fun x -> x)

let unique items =
    items |> List.groupBy id |> List.map (fun (i, _) -> i)

let unResult = unique myList

let distinct = myList |> List.distinct

let uniqueSet items = items |> Set.ofList

let setResult = uniqueSet myList
