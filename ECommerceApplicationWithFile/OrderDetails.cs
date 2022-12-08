using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplicationWithFile
{
    public enum OrderStatus
    {
        Default,Ordered,Cancelled
    }
    public class OrderDetails
    {
        public static int s_orderID = 1000;
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID{get;set;}
        public long TotalPrice { get; set; }
        public DateTime  PurchaseDate{ get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }

        public OrderDetails(string customerID,string productID,long totalPrice,DateTime purchaseDate,int quantity,OrderStatus status)
        {
            s_orderID++;
            OrderID = "OID"+s_orderID;
            CustomerID = customerID;
            ProductID = productID;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            Status = status;
        }

        public OrderDetails(string data)
        {
            string[] values = data.Split(",");

            s_orderID = int.Parse(values[0].Remove(0,3));
            OrderID = values[0];
            CustomerID = values[1];
            ProductID = values[2];
            TotalPrice = long.Parse(values[3]);
            PurchaseDate = DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            Quantity = int.Parse(values[5]);
            Status = Enum.Parse<OrderStatus>(values[6]);
        }
    }
}