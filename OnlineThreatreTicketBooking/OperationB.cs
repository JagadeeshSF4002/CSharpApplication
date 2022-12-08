using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    
    public static partial class Operation
    {
        static BookingDetails currentCancellation;
        private static void TicketCancellation()
        {
           System.Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::");
           System.Console.WriteLine("            Ticket Cancellation            ");
           System.Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::");

           foreach(BookingDetails booking in bookingList)
           {
                if(booking.UserID == currentUser.UserID)
                {
                    System.Console.WriteLine($"{booking.BookingID} {booking.UserID} {booking.MovieID} {booking.TheatreID} {booking.SeatCount} {booking.TotalAmount} {booking.BookingStatus}");
           
                }
           }
           System.Console.WriteLine("Enter the Booking ID :");
           string bookingID = Console.ReadLine().ToUpper();
           
           currentCancellation = ValidateBookingID(bookingID);

           if(currentCancellation != null)
           {
                foreach(ScreeningDetails screen in screenList)
                {
                    if(screen.MovieID == currentCancellation.MovieID && screen.TheatreID == currentCancellation.TheatreID)
                    {
                        System.Console.WriteLine(screen.MovieID);
                        screen.NoOfSeatsAvailable = screen.NoOfSeatsAvailable + currentCancellation.SeatCount;
                        currentCancellation.TotalAmount = currentCancellation.TotalAmount - 20;
                        currentUser.RechargeWallet(currentCancellation.TotalAmount);
                        currentCancellation.BookingStatus = BookingStatus.Cancelled;
                        System.Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
                        System.Console.WriteLine("          Ticket Cancellation Succesfull        ");
                        System.Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");                        
                    }
                }
           }
           else
           {
            System.Console.WriteLine(":::::::::::::::::::::::::::::::::::");
            System.Console.WriteLine("        Invalid Booking ID");
            System.Console.WriteLine(":::::::::::::::::::::::::::::::::::");
           }
        }

        private static BookingDetails ValidateBookingID(string bookingID)
        {
            foreach(BookingDetails booking in bookingList)
            {
                if(booking.BookingID == bookingID && booking.BookingStatus == BookingStatus.Booked)
                {
                    return booking;
                }
            }
            return null;
        }
    }
}