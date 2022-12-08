using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public enum BookingStatus
    {
        Default,Initiated,Booked,Ordered,Cancelled
    }
    public class BookingDetails
    {
        private static int s_bookID = 3000;
        public string BookID { get; }
        public string CustomerID { get; set; }
        public long TotalPrice { get; set; }

        public DateTime DateOfBooking { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public BookingDetails(string customerID,long totalPrice,DateTime dateOfBooking,BookingStatus bookingStatus)
        {
            s_bookID++;
            BookID = "BID"+s_bookID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfBooking = dateOfBooking;
            BookingStatus = bookingStatus;
        }

        public BookingDetails(string data)
        {
            string[] values = data.Split(',');

            s_bookID = int.Parse(values[0].Remove(0,3));
            BookID = values[0];
            CustomerID = values[1];
            TotalPrice = long.Parse(values[2]);
            DateOfBooking = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            BookingStatus = Enum.Parse<BookingStatus>(values[4]);
        }
        public void ShowBookingDetails()
        {
            
        }
    }

}