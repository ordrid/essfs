sealed trait Customer

case class Registered(id: String) extends Customer
case class EligibleRegistered(id: String) extends Customer
case class Guest(id: String) extends Customer

def calculateTotal(customer: Customer)(spend: Double) = {
    val discount = customer match {
        case EligibleRegistered(_) if spend >= 100.0 => spend * 0.1
        case _ => 0.0
    }

    spend - discount
}

val john = EligibleRegistered("John")
val assertJohn = (calculateTotal (john) (100.0)) == 90.0

@main def main(): Unit =
  println(assertJohn)
