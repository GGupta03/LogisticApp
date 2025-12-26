using NUnit.Framework;


namespace LogisticApp
{
    public class BillingTest
    {
        public Billing _billing;
        public Bill _bill;
        
        [Test]
        public void GenerateBill_WeightMorethan100()
        {
            Consignment consignment = new Consignment(150);
            Order order = new Order(101, 150);
            Assert.Equals(2000, _bill.Amount);
            Assert.Equals(450,_bill.Tax);
            Assert.Equals(2450,_bill.FinalAmount);
        }

        [Test]
        public void GenerateBill_Weightlessthan100()
        {
            Consignment consignment = new Consignment(90);
            Order order = new Order(102, 90);
            Assert.Equals(2000,_bill.Amount);
            Assert.Equals(0,_bill.Tax);
            Assert.Equals(2000,_bill.FinalAmount);
        }

        [Test]
        public void OrderNotAApproved()
        {
            Consignment consignment = new Consignment(90);
            Order order = new Order(102, 90);
            Assert.Throws<Exception>(() => _billing.GenerateBill(order));
        }
    }
}