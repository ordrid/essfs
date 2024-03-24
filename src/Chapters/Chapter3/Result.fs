open System

let tryDivide (x: decimal) (y: decimal) =
    try
        x / y
    with :? DivideByZeroException as ex ->
        raise ex

// type Result<'TSuccess, 'TFailure> =
//     | Success of 'TSuccess
//     | Failure of 'TFailure

let tryDivide (x: decimal) (y: decimal) =
    try
        Ok(x / y)
    with :? DivideByZeroException as ex ->
        Error ex

// Error "System.DivideByZeroException: Attempted to divide by zero..."
let badDivide = tryDivide 1M 0M

let goodDivide = tryDivide 1M 1M // Some 1M
