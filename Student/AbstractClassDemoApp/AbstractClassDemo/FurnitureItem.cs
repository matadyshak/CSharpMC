namespace AbstractClassDemo
{
    // ISellable interface inherited and does not need to be specified
    public class FurnitureItem : Product
    {
        public FurnitureItem(int quantityInStock) : base(quantityInStock) { }
        public override decimal Sale()
        {
            return 2000.00m;
        }

        public override decimal Refund()
        {
            return Sale() * 0.90m;
        }

        public override decimal CalculateDeliveryFee()
        {
            return 144.99m;
        }
    }
}