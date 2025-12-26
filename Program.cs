/*Create a Logistic App where the customer will place a order to transport the consignment through the trucking company 
1. once the order is placed approval from the company side.
2. If the capacity of the consignment more than 100 kg for every con. we will charge 500 will value as added tax.
3. Generate Bill.
4. NUnit testing for the functionalities.(Check Weight lessthan or greaterthan,NotApproved )
to implement (Logic)
Consignment 
orderDetails
approval
charge/price(condition)
generate bills = (weight condition,tax),amount
have to add tax to the total amount if it exceeds the weight of 100kg
*/
using System;
namespace LogisticApp
{
    public class Consignment
    {
        public double Weight { get; set; }
        public Consignment(double weight)
        {
            Weight = weight;
        }
    }
    public class Order
    {
        public int OrderId { get; }
        public Consignment consignment { get; set; }
        public bool IsApproved { get; set; }
        public Order(int orderId,double consignment)
        {
            OrderId = orderId;
            double Consignment = consignment;
            IsApproved = false;
        }
    }

    public class Bill
    {
        public int BillId { get; }
        public double Amount { get; set; }
        public double Tax { get; set; }
        public double TotalAmount {  get; set; }

        public double FinalAmount { get; set; }
    }

    public class Approval
    {
        public Approval(Order order)
        {
            order.IsApproved = true;
        }
    }

    public class Billing
    {
        public double BaseCharge = 2000;
        public double ExtraCharge = 500;

        public Bill GenerateBill(Order order)
        {
            if (!order.IsApproved)
            {
                throw new Exception("Order Not Found");
            }
            
            Bill bill = new Bill();
            bill.Amount = BaseCharge;
            bill.TotalAmount = bill.Amount + ExtraCharge;
            //Tax Logic to the bill
            if (order.consignment.Weight > 100)
            {
                bill.Tax = bill.TotalAmount * 0.18;
            }

            bill.FinalAmount = bill.TotalAmount + bill.Tax;

            return bill;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Consignment consignment = new Consignment(150);
            Order order = new Order(101, 150);
            
            Approval approval = new Approval(order);
            Billing billing = new Billing();
            Bill bill = billing.GenerateBill(order);

            Console.WriteLine($"The Base Price is {bill.Amount}");
            Console.WriteLine($"The Tax Price is {bill.Tax}");
            Console.WriteLine($"The Total Amount is {bill.TotalAmount}");
        }
    }
}