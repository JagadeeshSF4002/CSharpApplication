using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
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
    }
}