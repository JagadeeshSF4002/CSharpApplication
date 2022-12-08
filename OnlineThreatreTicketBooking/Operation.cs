using System.Xml.Schema;
using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public partial class Operation
    {

        public static EventManager registration,login,ticketBooking,ticketCancellation,bookingHistory,walletRecharge;

        public static void Subcribe()
        {
            registration = new EventManager(Operation.Registration);
            login = new EventManager(Operation.Login);
            ticketBooking = new EventManager(Operation.TicketBooking);
            ticketCancellation = new EventManager(Operation.TicketCancellation);
            bookingHistory = new EventManager(Operation.BookingHistory);
            walletRecharge = new EventManager(Operation.WalletRecharge);
        }
        public static List<UserDetails> userList  = new List<UserDetails>();
        public static List<TheatreDetails> theatreList = new List<TheatreDetails>();
        public static List<MovieDetails> movieList = new List<MovieDetails>();
        public static List<ScreeningDetails> screenList = new List<ScreeningDetails>();
        public static List<BookingDetails> bookingList = new List<BookingDetails>();

        static UserDetails currentUser;
        static TheatreDetails currentTheatre;

        static MovieDetails currentMovie;

        public static void MainMenu()
        {
            int option = 0;
            do
            {
                System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                System.Console.WriteLine("             Main Menu               ");
                System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                System.Console.WriteLine("1.User Registration");
                System.Console.WriteLine("2.Login");
                System.Console.WriteLine("3.Exit");
                System.Console.WriteLine("Enter the Option :");
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                registration();
                                break;
                            }
                    case 2:
                            {
                                login();
                                break;
                            }
                    case 3:
                            {
                                option = 3;
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("Invalid Option");
                                break;
                            }
                }
            }while(option != 3);
        }

        private static void Login()
        {
            System.Console.WriteLine("*************Login****************");
            System.Console.WriteLine("Enter the user ID :");
            string userID = Console.ReadLine().ToUpper();
            
            currentUser = ValidateUserID(userID);

            if(currentUser != null)
            {
               SubMenu();
            }
            else
            {
                System.Console.WriteLine("***********************Invalid ID********************");
            }
        }

        private static void SubMenu()
        {
            char option = '\0';
            do
            {
                System.Console.WriteLine("::::::::::::::::::::::::::::::::::::");
                System.Console.WriteLine("                Sub Menu            ");
                System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                System.Console.WriteLine("a. Ticket Booking");
                System.Console.WriteLine("b. Ticket Cancellation");
                System.Console.WriteLine("c. Booking History");
                System.Console.WriteLine("d. Wallet Recharge");
                System.Console.WriteLine("e. Exit");
                System.Console.WriteLine("Select the option :");
                option = char.Parse(Console.ReadLine());

                switch(option)
                {
                    case 'a':
                            {
                                ticketBooking();
                                break;
                            }
                    case 'b':
                            {
                                ticketCancellation();
                                break;
                            }
                    case 'c':
                            {
                                bookingHistory();
                                break;
                            }
                    case 'd':
                            {
                                walletRecharge();
                                break;
                            }
                    case 'e':
                            {
                                option = 'e';
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("Invalid Option");
                                break;
                            }
                }
            }while(option != 'e');
            
        }

        private static void WalletRecharge()
        {
            System.Console.WriteLine("Wallet Recharge");
            System.Console.WriteLine("Enter the amount to be recharge :");
            double amount = double.Parse(Console.ReadLine());
            currentUser.RechargeWallet(amount);
            System.Console.WriteLine("::::::::::::::::::::::::::::::::");
            System.Console.WriteLine("      Recharged Successfully    ");
            System.Console.WriteLine("::::::::::::::::::::::::::::::::");
        }

        private static void BookingHistory()
        {
            System.Console.WriteLine("Booking History");

            System.Console.WriteLine();

            foreach(BookingDetails booking in bookingList)
            {
                if(booking.UserID == currentUser.UserID) 
                {
                    System.Console.WriteLine($"{booking.BookingID} {booking.UserID} {booking.MovieID} {booking.TheatreID} {booking.SeatCount} {booking.TotalAmount} {booking.BookingStatus}");
             
                }
            }
        }

        

        

        private static UserDetails ValidateUserID(string userID)
        {
            foreach(UserDetails user in userList)
            {
                if(user.UserID == userID)
                {
                    return user;
                }
            }
            return null;
        }

        private static void Registration()
        {
            System.Console.WriteLine(":::::::::::::::::::::::::::::");
            System.Console.WriteLine("      Registration Form      ");
            System.Console.WriteLine("::::::::::::::::::::::::::::::");
            System.Console.WriteLine();
            System.Console.WriteLine("Enter your name :");
            string name = Console.ReadLine();
            
            System.Console.WriteLine("Enter your age :");
            int age = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter you phone Number :");
            ulong phoneNumber = ulong.Parse(Console.ReadLine());

            System.Console.WriteLine("Initial Balance :");
            int balance = int.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(name,age,phoneNumber,balance);            
            userList.Add(user);

            System.Console.WriteLine($"Your ID is {user.UserID}");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("********Registration successfull***********");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        }

        public static void DefaultData()
        {
            UserDetails user1 = new UserDetails("Ravichandran",30,9876543210,1000);
            UserDetails user2 = new UserDetails("Baskaran",30,987654212,2000);
            userList.Add(user1);
            userList.Add(user2);

            TheatreDetails theatre1 = new TheatreDetails("inox","AnnaNagar");
            TheatreDetails theatre2 = new TheatreDetails("Ega Theatre","Chetpet");
            TheatreDetails theatre3 = new TheatreDetails("Kamala","Vadapalani");
            theatreList.Add(theatre1);
            theatreList.Add(theatre2);
            theatreList.Add(theatre3);

            MovieDetails movie1 = new MovieDetails("Bagubali2","tamil");
            MovieDetails movie2 = new MovieDetails("Ponniyen selvan","tamil");
            MovieDetails movie3 = new MovieDetails("Cobra","tamil");
            MovieDetails movie4 = new MovieDetails("Vikram","tamil");
            MovieDetails movie5 = new MovieDetails("Love Today","tamil");
            MovieDetails movie6 = new MovieDetails("Black Panther","english");
            movieList.Add(movie1);
            movieList.Add(movie2);
            movieList.Add(movie3);
            movieList.Add(movie4);
            movieList.Add(movie5);
            movieList.Add(movie6);

            ScreeningDetails screen1 = new ScreeningDetails(movie1.MovieID,theatre1.TheatreID,200,5);
            ScreeningDetails screen2 = new ScreeningDetails(movie2.MovieID,theatre1.TheatreID,300,2);
            ScreeningDetails screen3 = new ScreeningDetails(movie1.MovieID,theatre2.TheatreID,200,1);
            ScreeningDetails screen4 = new ScreeningDetails(movie3.MovieID,theatre1.TheatreID,400,11);
            ScreeningDetails screen5 = new ScreeningDetails(movie4.MovieID,theatre3.TheatreID,400,20);
            ScreeningDetails screen6 = new ScreeningDetails(movie5.MovieID,theatre2.TheatreID,300,3);
            screenList.Add(screen1);
            screenList.Add(screen2);
            screenList.Add(screen3);
            screenList.Add(screen4);
            screenList.Add(screen5);
            screenList.Add(screen6);

            BookingDetails booking1 = new BookingDetails(user1.UserID,movie1.MovieID,theatre1.TheatreID,1,200,BookingStatus.Booked);
            BookingDetails booking2 = new BookingDetails(user2.UserID,movie4.MovieID,theatre2.TheatreID,3,400,BookingStatus.Booked);
            BookingDetails booking3 = new BookingDetails(user1.UserID,movie3.MovieID,theatre3.TheatreID,2,100,BookingStatus.Booked);
            bookingList.Add(booking1);
            bookingList.Add(booking2);
            bookingList.Add(booking3);

            System.Console.WriteLine("User Details");
            foreach(UserDetails user in userList)
            {
                System.Console.WriteLine($"{user.UserID} {user.Name} {user.Age}  {user.PhoneNumber} {user.WalletBalance}");
            }

            System.Console.WriteLine("Theatre details ");
            foreach(TheatreDetails theatre in theatreList)
            {
                System.Console.WriteLine($"{theatre.TheatreID} {theatre.TheatreName} {theatre.TheatreLocation}");
            }
            System.Console.WriteLine("Movie Details");
            foreach(MovieDetails movie in movieList)
            {
                System.Console.WriteLine($"{movie.MovieID} {movie.MovieName} {movie.Language}");
            }

            System.Console.WriteLine("Screening Details");
            foreach(ScreeningDetails screen in screenList)
            {
                System.Console.WriteLine($"{screen.MovieID} {screen.TheatreID} {screen.TotalPrice} {screen.NoOfSeatsAvailable}");
            }

            System.Console.WriteLine("Booking Details");
            foreach(BookingDetails booking in bookingList)
            {
                System.Console.WriteLine($"{booking.BookingID} {booking.UserID} {booking.MovieID} {booking.TheatreID} {booking.SeatCount} {booking.TotalAmount} {booking.BookingStatus}");
            }

        }
    }
}