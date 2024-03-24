type Customer =
    { Id: int
      IsVip: bool
      Credit: decimal }

// Customer -> Customer * decimal
let getPurchases customer =
    let purchases = if customer.Id % 2 = 0 then 120M else 80M
    (customer, purchases)

// Customer * decimal -> Customer
let tryPromoteToVip purchases =
    let (customer, amount) = purchases

    if amount > 100M then
        { customer with IsVip = true }
    else
        customer

// Customer -> Customer
let increaseCreditIfVip customer =
    let increase = if customer.IsVip then 100M else 50M

    { customer with
        Credit = customer.Credit + increase }

// Composition operator
let upgradeCustomerComposed = getPurchases >> tryPromoteToVip >> increaseCreditIfVip

// Nested
let upgradeCustomerNested customer =
    increaseCreditIfVip (tryPromoteToVip (getPurchases customer))

// Procedural
let upgradeCustomerProcedural customer =
    let customerWithPurchases = getPurchases customer
    let promotedCustomer = tryPromoteToVip customerWithPurchases
    let increasedCreditCustomer = increaseCreditIfVip promotedCustomer
    increasedCreditCustomer

// Forward pipe operator
let upgradeCustomerPiped customer =
    customer |> getPurchases |> tryPromoteToVip |> increaseCreditIfVip

let customerVIP = { Id = 1; IsVip = true; Credit = 0.0M }

let customerStD =
    { Id = 2
      IsVip = false
      Credit = 100.0M }

let assertVIP =
    upgradeCustomerComposed customerVIP = { Id = 1
                                            IsVip = true
                                            Credit = 100.0M }

let assertSTDtoVIP =
    upgradeCustomerComposed customerSTD = { Id = 2
                                            IsVip = true
                                            Credit = 200.0M }

let assertSTD =
    upgradeCustomerComposed
        { customerSTD with
            Id = 3
            Credit = 50.0M } = { Id = 3
                                 IsVip = false
                                 Credit = 100.0M }
