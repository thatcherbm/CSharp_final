using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichLibrary
{
    public class InventoryItem
    {
        private string name;
        private int quantity;
        private string quantityType;
        private decimal price;
        
        //Property Name with validation
        public string Name 
        {
            get 
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        //Property Quantity with validation
        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                if (value >= 0)
                    quantity = value;
                else
                    quantity = 0;
            }
        }
        //Property QuantityType with validation
        public string QuantityType
        {
            get
            {
                return quantityType;
            }

            set
            {
                quantityType = value;
            }
        }
        //Property Price with validation
        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value >= 0)
                    price = value;
                else
                    price = 0;
            }
        }

        //four parameter constructor
        public InventoryItem(string name, int quantity,  string quantityType, decimal price)
        {
            Name = name;
            Quantity = quantity;
            QuantityType = quantityType;
            Price = price;
        }

        public override string ToString()
        {
            string itemString;
            itemString = string.Format("{0,-16}{1,4} {2,-10}{3,7:c}", Name, Quantity, QuantityType, Price);
            return itemString;
        }
    }
}
