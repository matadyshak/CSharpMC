namespace AbstractClassDemo
{
    //Class must be abstract and cannot be instantiated if there are any abstract properties or methods
    public abstract class Product : ISellable
    {
        // These are required to implement ISellable in the base class
        // Derived classes inherit these properties
        public int SKU { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        // this is a regular method that get inherited also
        public int QuantityInStock { get; private set; }

        // Constructor to initialize QuantityInStock
        protected Product(int quantityInStock)
        {
            QuantityInStock = quantityInStock;
        }

        // These must be defined in each child class of Product as override methods
        public abstract decimal CalculateDeliveryFee();
        public abstract decimal Sale();
        public abstract decimal Refund();
    }
}