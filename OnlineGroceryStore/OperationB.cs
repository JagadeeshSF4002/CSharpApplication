using System.Runtime.ConstrainedExecution;
using System;
namespace OnlineGroceryStore
{
    public static partial class Operation
    {
        static BookingDetails currentBookings;
        static OrderDetails currentOrderModification;
        public static void ModifyOrderQuantity()
        {
            foreach(BookingDetails bookingData in bookList)
            {
                if(bookingData.CustomerID == currentUser.CustomerID)
                {
                    System.Console.WriteLine(bookingData.BookID+" "+bookingData.CustomerID+" "+bookingData.TotalPrice+" "+bookingData.DateOfBooking.ToString("dd/MM/yyyy")+" "+bookingData.BookingStatus);
           
                }
            }

            System.Console.WriteLine("Pick the booking ID");
            string bookingID = Console.ReadLine().ToUpper();

            currentBookings = ValidateBookingID(bookingID);

            if(currentBookings != null)
            {

                foreach(OrderDetails order in orderList)
                {
                    if(order.BookingID == currentBookings.BookID)
                    {
                        System.Console.WriteLine(order.OrderID+" "+order.BookingID+" "+order.ProductID+" "+order.PurchaseCount+" "+order.PriceOfOrder);
                    }
                }

                System.Console.WriteLine("Pick the order ID");
                string orderID = Console.ReadLine().ToUpper();

                currentOrderModification = ValidateOrderID(orderID);

                if(currentOrderModification != null)
                {
                    System.Console.WriteLine("Enter the quantity :");
                    int quantity = int.Parse(Console.ReadLine());
                    
                    foreach (ProductDetails product in productList)
                    {
                        if(product.ProductID == currentOrderModification.ProductID)
                        {
                           long amount = quantity * product.PricePerQuantity;
                           currentOrderModification.PriceOfOrder = amount;
                           currentBookings.TotalPrice = amount;
                           System.Console.WriteLine("***********************Order Modified Successfully********************************");
                        }
                    }
                    
                }
                else
                {
                    System.Console.WriteLine("******************************Invalid Order ID*************************");
                }
            }
            else
            {
                System.Console.WriteLine("***************************Invalid Booking ID**********************");
            }

        }

        private static OrderDetails ValidateOrderID(string orderID)
        {
           foreach(OrderDetails order in orderList)
            {
                if(order.OrderID == orderID)
                {
                    return order;
                }
            }
            return null;
        }

        public static BookingDetails ValidateBookingID(string bookingID)
        {
            foreach(BookingDetails booking in bookList)
            {
                if(booking.BookID == bookingID && booking.BookingStatus == BookingStatus.Booked && booking.CustomerID == currentUser.CustomerID)
                {
                    return booking;
                }
            }
            return null;
        }
    }
}