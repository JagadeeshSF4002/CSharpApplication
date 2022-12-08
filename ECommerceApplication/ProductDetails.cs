using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class ProductDetails
    {
        private static int s_productID = 100;
        public string ProductID { get;}
        public string ProductName { get; set; }
        public long Price { get; set; }
        public int Stock { get; set; }
        public int ShippingDuration { get; set; }

        public DateTime DateTime { get; set; }

        public ProductDetails(string productName,int stock,long price,int shippingDuration)
        {
            s_productID++;
            ProductID = "PID"+s_productID;
            ProductName = productName;
            Stock = stock;
            Price = price;
            ShippingDuration = shippingDuration;
        }

        public ProductDetails()
        {
            
        }

        public void UpdateProductItem(int quantity)
        {
            Stock = Stock + quantity;
        }
    }
}