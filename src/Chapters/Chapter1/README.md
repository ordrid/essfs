# The Problem

**Feature**: Applying a discount
**Scenario**: Eligible Registered Customers get 10% discount when spend  &pound;100 or more

Given the following Registered Customers

| Customer Id | Is Eligible |
| ----------- | ----------- |
| John        | true        |
| Mary        | true        |
| Richard     | true        |

When `[Customer Id]` spends `[Spend]`
Then their order total will be `[TotaL]`

**Examples**:

| Customer Id | Spend  | Total  |
| ----------- | ------ | ------ |
| Mary        | 99.00  | 99.00  |
| John        | 100.00 | 90.00  |
| Richard     | 100.00 | 100.00 |
| Sarah       | 100.00 | 100.00 |

**Notes**:
Sarah is not a Registered Customer
Only Registered Customers can be Eligible

