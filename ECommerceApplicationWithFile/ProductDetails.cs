using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplicationWithFile
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

        public ProductDetails(string data)
        {
            string[] values = data.Split(",");
            s_productID = int.Parse(values[0].Remove(0,3));
            ProductID = values[0];
            ProductName = values[1];
            Stock = int.Parse(values[2]);
            Price = long.Parse(values[3]);
            ShippingDuration = int.Parse(values[4]);

        }
    }
}