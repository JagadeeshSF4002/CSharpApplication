
using System;
namespace OnlineGroceryStore
{
    public static partial class Operation
    {
        static BookingDetails currentBooks;
        static OrderDetails currentOrderCancellation;
        public static void CancelOrder()
        {
            foreach(BookingDetails bookings in bookList)
            {
                if(bookings.CustomerID == currentUser.CustomerID && bookings.BookingStatus == BookingStatus.Booked)
                {
                    System.Console.WriteLine(bookings.BookID+" "+bookings.CustomerID+" "+bookings.TotalPrice+" "+bookings.DateOfBooking.ToString("dd/MM/yyyy")+" "+bookings.BookingStatus);
                }
            }

            System.Console.WriteLine("Pick the booking ID");
            string bookingID = Console.ReadLine().ToUpper();

            currentBooks =ValidateBookingID(bookingID);         

            foreach(OrderDetails order in orderList)
            {
                if(order.BookingID == currentBooks.BookID)
                {
                    currentOrderCancellation = order;
                }
            }

            if(currentBooks != null)
            {
                currentBooks.BookingStatus = BookingStatus.Cancelled;
                currentUser.WalletRecharge(currentBookings.TotalPrice);
                System.Console.WriteLine("**************Redunded succesfully***************");
                foreach(ProductDetails productData in productList)
                {
                    if(productData.ProductID == currentOrderCancellation.ProductID)
                    {
                        productData.QuantityAvailable = productData.QuantityAvailable + currentOrderCancellation.PurchaseCount;
                        System.Console.WriteLine("**************Booking Cancelled Succesfully*******************");
                    }
                }

            }   
            else
            {
                System.Console.WriteLine("***************Invalid ID********************");
            }
            

        }
    }
}