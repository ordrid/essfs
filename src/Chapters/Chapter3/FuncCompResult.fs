open System

type Customer =
    { Id: int
      IsVip: bool
      Credit: decimal }

// Customer -> Result<(Customer * decimal), exn>
let getPurchases customer =
    try
        let purchases =
            if customer.Id % 2 = 0 then
                (customer, 120M)
            else
                (customer, 80M)

        Ok purchases
    with ex ->
        Error ex

// Customer * decimal -> Customer
let tryPromoteToVip purchases =
    let customer, amount = purchases

    if amount > 100M then
        { customer with IsVip = true }
    else
        customer

// Customer -> Result<Customer, exn>
let increaseCreditIfVip customer =
    try
        let increase =
            if customer.IsVip then 100.0M else 50.0M
        Ok { customer with Credit = customer.Credit + inc }

getPurchases { Id = 1, IsVip = false, Credit = 10.0M }

let upgradeCustomer customer =
    customer
    |> getPurchases
    |> fun result ->
        match result with
        | Ok x -> Ok (tryPromoteToVip x)
        | Error ex -> Error ex
    |> increaseCreditIfVip // Compiler problem

let upgradeCustomer customer =
    customer
    |> getPurchases
    |> fun result ->
        match result with
        | Ok x -> Ok (tryPromoteToVip x)
        | Error ex -> Error ex
    |> fun result ->
        match result with
        | Ok x -> increaseCreditIfVip x
        | Error ex -> Error ex

let upgradeCustomer customer =
    customer
    |> getPurchases
    |> function
        | Ok x -> Ok (tryPromoteToVip x)
        | Error ex -> Error ex
    |> function
        | Ok x -> increaseCreditIfVip x
        | Error ex -> Error ex

let map f result =
    match result with
    | Ok x -> Ok (f x)
    | Error ex -> Error ex

let tryParseDateTime (input: string) =
    let success, value = DateTime.TryParse input
    if success then Some value else None

let getResult =
    try
        Ok "Hello"
    with ex ->
        Error ex

let parseDT = getResult |> map tryParseDateTime

let upgradeCustomer customer =
    customer
    |> getPurchases
    |> map tryPromoteToVip
    |> function
        | Ok x -> increaseCreditIfVip x
        | Error ex -> Error ex

let bind f result =
    match result with
    | Ok x -> f x
    | Error ex -> Error ex

let upgradeCustomer customer =
    customer
    |> getPurchases
    |> map tryPromoteToVip
    |> bind increaseCreditIfVip

let upgradeCustomer customer =
    customer
    |> getPurchases
    |> Result.map tryPromoteToVip
    |> Result.bind increaseCreditIfVip