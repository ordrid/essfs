namespace Chapter7.FizzBuzz

module ``using if-else`` =

    let calculate i =
        if i % 3 = 0 && i % 5 = 0 then "FizzBuzz"
        elif i % 3 = 0 then "Fizz"
        elif i % 5 = 0 then "Buzz"
        else i |> string

module ``using pattern matching`` =

    let calculate i =
        match (i % 3, i % 5) with
        | (0, 0) -> "FizzBuzz"
        | (0, _) -> "Fizz"
        | (_, 0) -> "Buzz"
        | _ -> i |> string

    let calculate2 i =
        match (i % 3 = 0, i % 5 = 0) with
        | (true, true) -> "FizzBuzz"
        | (true, _) -> "Fizz"
        | (_, true) -> "Buzz"
        | _ -> i |> string

module ``using partial active pattern`` =

    let (|IsDivisibleBy|_|) divisor n =
        if n % divisor = 0 then Some() else None

    let calculate i =
        match i with
        | IsDivisibleBy 3 & IsDivisibleBy 5 -> "FizzBuzz"
        | IsDivisibleBy 3 -> "Fizz"
        | IsDivisibleBy 5 -> "Buzz"
        | _ -> i |> string

    let calculate2 i =
        match i with
        | IsDivisibleBy 3 & IsDivisibleBy 5 & IsDivisibleBy 7 -> "FizzBuzzBazz"
        | IsDivisibleBy 3 & IsDivisibleBy 5 -> "FizzBuzz"
        | IsDivisibleBy 3 & IsDivisibleBy 7 -> "FizzBazz"
        | IsDivisibleBy 5 & IsDivisibleBy 7 -> "BuzzBazz"
        | IsDivisibleBy 3 -> "Fizz"
        | IsDivisibleBy 5 -> "Buzz"
        | IsDivisibleBy 7 -> "Bazz"
        | _ -> i |> string

module ``using partial active pattern 2`` =

    let (|IsDivisibleBy|_|) divisors n =
        if divisors |> List.forall (fun div -> n % div = 0) then
            Some()
        else
            None

    let calculate i =
        match i with
        | IsDivisibleBy [ 3; 5; 7 ] -> "FizzBuzzBazz"
        | IsDivisibleBy [ 3; 5 ] -> "FizzBuzz"
        | IsDivisibleBy [ 3; 7 ] -> "FizzBazz"
        | IsDivisibleBy [ 5; 7 ] -> "BuzzBazz"
        | IsDivisibleBy [ 3 ] -> "Fizz"
        | IsDivisibleBy [ 5 ] -> "Buzz"
        | IsDivisibleBy [ 7 ] -> "Bazz"
        | _ -> i |> string

module ``alternative approach`` =

    let calculate mapping n =
        mapping
        |> List.map (fun (divisor, result) -> if n % divisor = 0 then result else "")
        |> List.reduce (+)
        |> fun input -> if input = "" then string n else input

    [ 1..15 ] |> List.map (calculate [ (3, "Fizz"); (5, "Buzz"); (7, "Bazz") ])

namespace Chapter7.LeapYear

module ``is leap year`` =

    let isLeapYear year =
        year % 400 = 0 || (year % 4 = 0 && year % 100 <> 0)

    [ 2000; 2001; 2020 ] |> List.map isLeapYear = [ true; false; true ]

module ``using parameterized partial active pattern`` =

    let (|IsDivisibleBy|_|) divisor n =
        if n % divisor = 0 then Some() else None

    let (|NotDivisibleBy|_|) divisor n =
        if n % divisor <> 0 then Some() else None

    let isLeapYear year =
        match year with
        | IsDivisibleBy 400 -> true
        | IsDivisibleBy 4 & NotDivisibleBy 100 -> true
        | _ -> false

module ``using helper functions`` =

    let isDivisibleBy divisor year = year % divisor = 0

    let notDivisible divisor year = not (year |> isDivisibleBy divisor)

    let isLeapYear year =
        year |> isDivisibleBy 400
        || (year |> isDivisibleBy 4 && year |> notDivisible 100)

    let isLeapYear2 input =
        match input with
        | year when year |> isDivisibleBy 400 -> true
        | year when year |> isDivisibleBy 4 && year |> notDivisible 100 -> true
        | _ -> false

    let isLeapYear3 input =
        match input with
        | year when year |> isDivisibleBy 400 -> true
        | year when year |> isDivisibleBy 4 && year |> isDivisibleBy 100 |> not -> true
        | _ -> false
