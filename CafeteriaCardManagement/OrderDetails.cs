using System.Net.Mime;
using System;

namespace CafeteriaCardManagement
{
    public enum OrderStatus
    {
        Default,Initiated,Ordered,Cancelled
    }
    public class OrderDetails
    {
        private static int s_orderID = 1000;
        public string OrderID { get; }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public long TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string userID,DateTime orderDate,long totalPrice,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID = "OID"+s_orderID;
            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            OrderStatus = orderStatus;
        }

        public OrderDetails(string orderData)
        {
            string[] values = orderData.Split(',');
            s_orderID = int.Parse(values[0].Remove(0,3));
            OrderID = values[0];
            UserID = values[1];
            OrderDate = DateTime.ParseExact(values[2],"dd/MM/yyyy",null);
            TotalPrice = long.Parse(values[3]);
            OrderStatus = Enum.Parse<OrderStatus>(values[4]);
        }
    }
}