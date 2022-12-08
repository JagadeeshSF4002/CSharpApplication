using System.Net.NetworkInformation;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public static class Files
    {
        public static void Create()
        {
            if(!Directory.Exists("TicketHistory"))
            {
                Directory.CreateDirectory("TicketHistory");
                System.Console.WriteLine("*****************Folder created successfully******************");
            }

            if(!File.Exists("TicketHistory/UserDetails.csv"))
            {
                File.Create("TicketHistory/UserDetails.csv").Close();
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("TicketHistory/MovieDetails.csv"))
            {
                File.Create("TicketHistory/MovieDetails.csv").Close();
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("TicketHistory/TheatreDetails.csv"))
            {
                File.Create("TicketHistory/TheatreDetails.csv").Close();
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("TicketHistory/ScreeningDetails.csv"))
            {
                File.Create("TicketHistory/ScreeningDetails.csv");
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("TicketHistory/BookingDetails.csv"))
            {
                File.Create("TicketHistory/BookingDetails.csv");
                System.Console.WriteLine("File is created");
            }
        }

        public static void WriteFile()
        {
            string[] userDetail = new string[Operation.userList.Count];

            int i = 0;
            foreach(UserDetails user in Operation.userList)
            {
                userDetail[i] = user.UserID+","+user.Name+","+user.Age+","+user.PhoneNumber+","+user.WalletBalance;
                i++;
            }
            File.WriteAllLines("TicketHistory/UserDetails.csv",userDetail);

            string[] movieDetails = new string[Operation.movieList.Count];
            i=0;
            foreach(MovieDetails movies in Operation.movieList)
            {
                movieDetails[i] = movies.MovieID+","+movies.MovieName+","+movies.Language;
                i++;
            }
            File.WriteAllLines("TicketHistory/MovieDetails.csv",movieDetails);

            string[] theatreDetails = new string[Operation.theatreList.Count];
            i = 0;
            foreach(TheatreDetails theatre in Operation.theatreList)
            {
                theatreDetails[i] = theatre.TheatreID+","+theatre.TheatreName+","+theatre.TheatreLocation;
                i++;
            }
            File.WriteAllLines("TicketHistory/TheatreDetails.csv",theatreDetails);

            string[] bookingDetails = new string[Operation.bookingList.Count];
            i=0;
            foreach(BookingDetails bookings in Operation.bookingList)
            {
                bookingDetails[i] = bookings.BookingID+","+bookings.UserID+","+bookings.MovieID+","+bookings.TheatreID+","+bookings.SeatCount+","+bookings.TotalAmount+","+bookings.BookingStatus;
                i++;
            }
            File.WriteAllLines("TicketHistory/BookingDetails.csv",bookingDetails);

            string[] screenDetails = new string[Operation.screenList.Count];
            i=0;
            foreach(ScreeningDetails screens in Operation.screenList)
            {
                screenDetails[i] = screens.MovieID+","+screens.TheatreID+","+screens.NoOfSeatsAvailable+","+screens.TotalPrice;
                i++;
            }
            File.WriteAllLines("TicketHistory/ScreeningDetails.csv",screenDetails);
        }

        public static void ReadFiles()
        {
            string[] userDetails = File.ReadAllLines("TicketHistory/UserDetails.csv");

            foreach(string data in userDetails)
            {
                UserDetails user = new UserDetails(data);
                Operation.userList.Add(user);
            }

            string[] moviesDetails = File.ReadAllLines("TicketHistory/MovieDetails.csv");

            foreach(string data in moviesDetails)
            {
                MovieDetails movies = new MovieDetails(data);
                Operation.movieList.Add(movies);
            }

            string[] theatreDetails = File.ReadAllLines("TicketHistory/TheatreDetails.csv");

            foreach(string data in theatreDetails)
            {
                TheatreDetails theatre = new TheatreDetails(data);
                Operation.theatreList.Add(theatre);
            }

            string[] screensDetails = File.ReadAllLines("TicketHistory/ScreeningDetails.csv");

            foreach(string data in screensDetails)
            {
                ScreeningDetails screens = new ScreeningDetails(data);
                Operation.screenList.Add(screens);
            }

            string[] bookingDetails = File.ReadAllLines("TicketHistory/BookingDetails.csv");

            foreach(string data in bookingDetails)
            {
                BookingDetails bookings = new BookingDetails(data);
                Operation.bookingList.Add(bookings);
            }
        }
    }
}