using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public enum BookingStatus
    {
        Default,Booked,Cancelled
    }
    public class BookingDetails
    {
        private static int s_bookingID = 7000;

        public string BookingID { get; set; }

        public string UserID { get;}
        public string MovieID { get; set; }
        public string TheatreID { get; set; }
        public int SeatCount { get; set; }
        public double TotalAmount { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public BookingDetails(string userID,string movieID,string theatreID,int seatCount,double totalAmount,BookingStatus bookingStatus)
        {
            s_bookingID++;
            BookingID = "BID"+s_bookingID;
            UserID = userID;
            MovieID = movieID;
            TheatreID = theatreID;
            SeatCount = seatCount;
            TotalAmount = totalAmount;
            BookingStatus = bookingStatus;
        }

        public BookingDetails(string data)
        {
            string[] values = data.Split(',');
            s_bookingID = int.Parse(values[0].Remove(0,3));
            BookingID = values[0];
            UserID = values[1];
            MovieID = values[2];
            TheatreID = values[3];
            SeatCount = int.Parse(values[4]);
            TotalAmount = double.Parse(values[5]);
            BookingStatus = Enum.Parse<BookingStatus>(values[6]);
        }

    }
}