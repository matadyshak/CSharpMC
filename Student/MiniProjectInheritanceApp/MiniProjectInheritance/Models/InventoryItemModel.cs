using MiniProjectInheritance.Interfaces;

namespace MiniProjectInheritance.Models
{
    public class InventoryItemModel : IInventoryItem
    {
        protected int _availableQuantity;
        public virtual int AvailableQuantity
        {
            get { return _availableQuantity; }
            set { _availableQuantity = value; }
        }

        protected decimal _price;
        public virtual decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        protected string _productName;
        public virtual string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
    }
}