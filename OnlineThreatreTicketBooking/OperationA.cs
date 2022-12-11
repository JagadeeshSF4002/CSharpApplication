using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public static partial class Operation
    {
        private static void TicketBooking()
        {
            System.Console.WriteLine("Ticket Booking");
            System.Console.WriteLine();
            System.Console.WriteLine("********************Theatre details**********************");
            foreach(TheatreDetails theatre in theatreList)
            {
                System.Console.WriteLine($"{theatre.TheatreID} {theatre.TheatreName} {theatre.TheatreLocation}");
            }

            System.Console.WriteLine("Enter the theatre ID :");
            string theaterID = Console.ReadLine().ToUpper();
            
            currentTheatre = IsValidTheatreID(theaterID);

            if(currentTheatre != null)
            {
                foreach(ScreeningDetails screens in screenList)
                {
                    if(screens.TheatreID == currentTheatre.TheatreID)
                    {
                        foreach(MovieDetails movies in movieList)
                        {
                            if(movies.MovieID == screens.MovieID)
                            {
                                System.Console.WriteLine($"{movies.MovieID} {movies.MovieName} {movies.Language}");
                            }
                        }
                    }
                }

                System.Console.WriteLine("Enter the Movie ID :");
                string movieID = Console.ReadLine().ToUpper();
                        
                currentMovie = ValidateMovieID(movieID);
                if(currentMovie != null)
                {
                    System.Console.WriteLine("How many seats do you want :");
                    int seats = int.Parse(Console.ReadLine());

                    foreach(ScreeningDetails screen in screenList)
                    {
                        if(screen.MovieID == currentMovie.MovieID && screen.TheatreID == currentTheatre.TheatreID)
                        {
                            System.Console.WriteLine(screen.MovieID);
                            if(screen.NoOfSeatsAvailable >= seats)
                            {
                                double totalAmount = (seats*screen.TotalPrice)+(seats*screen.TotalPrice*0.18);

                                if(currentUser.WalletBalance >= totalAmount)
                                {
                                    currentUser.DeductBalance(totalAmount);
                                    screen.NoOfSeatsAvailable = screen.NoOfSeatsAvailable - seats;
                                    BookingDetails booking = new BookingDetails(currentUser.UserID,currentMovie.MovieID,currentTheatre.TheatreID,seats, totalAmount,BookingStatus.Booked);
                                    bookingList.Add(booking);
                                    System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                                    System.Console.WriteLine("********************Booking Successful*************************");
                                    System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                                }
                                else
                                {
                                    System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                                    System.Console.WriteLine("       Insufficient Balance . please recharge your wallet      ");
                                    System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                                }
                            }
                            else
                            {
                                    System.Console.WriteLine($"****************Required count is not . Current Availablity is {screen.NoOfSeatsAvailable}**************");
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("******************INVALID MOVIE ID*******************");
                }
            }
            else
            {
                System.Console.WriteLine("**************Invalid ID**************");
            }

        }

        private static MovieDetails ValidateMovieID(string movieID)
        {
            foreach(MovieDetails movie in movieList)
            {
                if(movie.MovieID == movieID)
                {
                    return movie;
                }
            }
            return null;
        }

        private static TheatreDetails IsValidTheatreID(string theaterID)
        {
            foreach(TheatreDetails theatre in theatreList)
            {
                if(theatre.TheatreID == theaterID)
                {
                    return theatre;
                }
            }
            return null;
        }
    }
}