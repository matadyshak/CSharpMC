namespace AbstractClassDemo
{
    // ISellable interface inherited and does not need to be specified
    public class ApplianceItem : Product
    {
        public ApplianceItem(int quantityInStock) : base(quantityInStock) { }
        public override decimal Sale()
        {
            return 1000.00m;
        }

        public override decimal Refund()
        {
            return Sale() * 0.85m;
        }

        public override decimal CalculateDeliveryFee()
        {
            return 29.99m;
        }
    }
}