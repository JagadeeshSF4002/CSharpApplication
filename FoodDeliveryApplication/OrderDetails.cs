using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    /// <summary>
    /// Enum used for order status 
    /// </summary>
    public enum OrderStatus
    {
        Default,Initiated,Ordered,Cancelled
    }
    /// <summary>
    /// Get the information from user
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// static field used
        /// </summary>
        private static int s_orderID = 3000;
        /// <summary>
        /// Auto Generated property
        /// </summary>
        /// <value></value>
        public string OrderID { get;}
        /// <summary>
        /// Unique Customer ID
        /// </summary>
        /// <value></value>
        public string CustomerID { get; set; }
        /// <summary>
        /// used to store Amount for Ordered Items 
        /// </summary>
        /// <value></value>
        public double TotalPrice { get; set; }
        /// <summary>
        /// Used to store dates
        /// </summary>
        /// <value></value>
        public DateTime DateOfOrder { get; set; }
        /// <summary>
        /// Status for ordered items
        /// </summary>
        /// <value></value>
        public OrderStatus OrderStatus { get; set; }


        /// <summary>
        /// Parameterized Constructor used for get the values from user store into specified property
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="totalPrice"></param>
        /// <param name="dateOfOrder"></param>
        /// <param name="orderStatus"></param>
        public OrderDetails(string customerID,double totalPrice,DateTime dateOfOrder,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID = "BID"+s_orderID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfOrder = dateOfOrder;
            OrderStatus = orderStatus;
        }
        /// <summary>
        /// Get the values from files and store into specified properties
        /// </summary>
        /// <param name="orderData"></param>
        public OrderDetails(string orderData)
        {
            string[] values = orderData.Split(',');
            s_orderID = int.Parse(values[0].Remove(0,3));
            OrderID = values[0];
            CustomerID = values[1];
            TotalPrice = double.Parse(values[2]);
            DateOfOrder = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            OrderStatus = Enum.Parse<OrderStatus>(values[4],true);
        }
    }
}