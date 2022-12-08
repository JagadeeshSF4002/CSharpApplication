using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class ProductDetails
    {
        private static int s_productID = 100;
        public string ProductID { get;  }
        public string ProductName { get; set; }
        public int QuantityAvailable { get; set; }
        public long PricePerQuantity { get; set; }

        public ProductDetails(string productName,int quantityAvailable,int pricePerQuantity)
        {
            s_productID++;
            ProductID = "PID"+s_productID;
            ProductName = productName;
            QuantityAvailable = quantityAvailable;
            PricePerQuantity = pricePerQuantity;
        }

        public ProductDetails(string data)
        {
            string[] values = data.Split(',');
            s_productID=int.Parse(values[0].Remove(0,3));
            ProductID = values[0];
            ProductName = values[1];
            QuantityAvailable = int.Parse(values[2]);
            PricePerQuantity = long.Parse(values[3]);
        }

        public void ShowProductDetails()
        {

        }        
    }
}