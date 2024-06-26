namespace MyProjectTests

open FsUnit
open Xunit
open MyProject.Customer

module ``When upgrading customer`` =

    let customerVip = { Id = 1; IsVip = true; Credit = 0.0M }

    let customerSTD =
        { Id = 2
          IsVip = false
          Credit = 100.M }

    [<Fact>]
    let ``should give VIP customer more credit`` () =
        let expected =
            { customerVip with
                Credit = customerVip.Credit + 100M }

        let actual = upgradeCustomer customerVip

        actual |> should equal expected

    [<Fact>]
    let ``should convert eligible STD customer to VIP`` () =
        let expected =
            { Id = 2
              IsVip = true
              Credit = 200.0M }

        let actual = upgradeCustomer customerSTD

        actual |> should equal expected

    [<Fact>]
    let ``should not upgrade ineligible STD customer to VIP`` () =
        let expected =
            { Id = 3
              IsVip = false
              Credit = 100.0M }

        let actual =
            upgradeCustomer
                { customerSTD with
                    Id = 3
                    Credit = 50.0M }

        actual |> should equal expected
