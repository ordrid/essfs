enum Customer:
  case Registered(val id: String)
  case EligibleRegistered(val id: String)
  case Guess(val id: String)

def calculateTotal(customer: Customer)(spend: Double) =
  val discount = customer match
    case Customer.EligibleRegistered(_) if spend >= 100.0 => spend * 0.1
    case _ => 0.0
  spend - discount
end calculateTotal

val john = Customer.EligibleRegistered("John")
val assertJohn = (calculateTotal (john) (100.0)) == 90.0

@main def main(): Unit =
  println(assertJohn)
