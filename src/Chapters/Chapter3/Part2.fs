type PersonName =
    { FirstName: string
      MiddleName: string option
      LastName: string }

let person =
    { FirstName = "Ian"
      MiddleName = None
      LastName = "Russel" }

let person2 =
    { person with
        MiddleName = Some "Thomas" }
