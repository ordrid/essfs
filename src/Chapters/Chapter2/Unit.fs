open System

let now () = DateTime.UtcNow

let log msg =
    // Log message or similar task that doesn't return a value
    ()

let fixedNow = DateTime.UtcNow

let theTimeIs = fixedNow
