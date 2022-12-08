using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class OrderDetails
    {
        private static int s_orderID = 100;
        public string OrderID{ get; }
        public string BookingID { get; set; }
        public string ProductID { get; set; }
        public int PurchaseCount{ get; set; }
        public long PriceOfOrder { get; set; }

        public OrderDetails(string bookingID,string productID,int purchaseCount,long priceOfOrder)
        {
            s_orderID++;
            OrderID = "OID"+s_orderID;
            BookingID = bookingID;
            ProductID = productID;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }

        public OrderDetails(string data)
        {
            string[] values = data.Split(',');
            s_orderID = int.Parse(values[0].Remove(0,3));
            OrderID = values[0];
            BookingID = values[1];
            ProductID = values[2];
            PurchaseCount = int.Parse(values[3]);
            PriceOfOrder = long.Parse(values[4]);
        }
    }
}