using System;

/// <summary>
/// used to process the Online medical item purchasing using this application
/// </summary>

namespace OnlineMedicalStore
{
    /// <summary>
    /// Property OrderStatus initially we have Purchased,Cancelled <see cref="OrderStatus" /> class
    /// </summary>
    /// <value></value>
    public enum OrderStatus
    {
        Default,Purchased,Cancelled
    }
    
    /// <summary>
    /// Used to collect the information about ordered product <see cref="OrderDetails" /> class
    /// </summary>
    /// <value></value>
    public class OrderDetails
    {
        ///field
        /// <summary>
        /// static field used to auto increment and it uniquely indentify an instance of  order id
        /// </summary>
        private static int s_orderID;
        /// <summary>
        /// Property Order ID used to  purchased item in object of <see cref="OrderID" /> class
        /// </summary>
        /// <value></value>
        public string OrderID { get;}
        /// <summary>
        /// Property User ID used to  purchased user in object of <see cref="UserID" /> class
        /// </summary>
        /// <value></value>
        public string  UserID { get; set; }
        /// <summary>
        /// Property User ID used to  purchased medicine item ID in object of <see cref="MedicineID" /> class
        /// </summary>
        /// <value></value>
        public string MedicineID { get; set; }
        /// <summary>
        /// Property used to count the  medicine item  in medicine list in object of <see cref="MedicineCount" /> class
        /// </summary>
        /// <value></value>
        public int MedicineCount { get; set; }
        /// <summary>
        /// Property used total price for purchased medicine  in object of <see cref="TotalPrice" /> class
        /// </summary>
        /// <value></value>
        public  long TotalPrice { get; set; }
        /// <summary>
        /// Property used Ordered date in object of <see cref="Ordered Date" /> class
        /// </summary>
        /// <value></value>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Property OrderStatus initially we have Purchased,Cancelled <see cref="OrderStatus" /> class
        /// </summary>
        /// <value></value>
        public OrderStatus OrderStatus { get; set; }

        
        
        //parameterized constructor used to initialize the properties of an object with user provided values by using parameter at object created time
        public OrderDetails(string userID,string medicineID,int medicineCount,long totalPrice,DateTime orderDate,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID = "OID"+s_orderID;
            UserID = userID;
            MedicineID = medicineID;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
        }
    }
}