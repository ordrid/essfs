type LogLevel =
    | Error
    | Warning
    | Info

// (LogLevel * string) -> unit
let log (level: LogLevel, message: string) = printfn "[%A]: %s" level message
