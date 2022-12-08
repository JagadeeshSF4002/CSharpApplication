using System;

namespace MetroCardManagement
{
    public partial class Operation
    {
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<TicketFairDetails> ticketList = new List<TicketFairDetails>();
        public static List<TravelDetails> travelList = new List<TravelDetails>();

        static UserDetails currentUser;
        static TicketFairDetails currentTicketFair;


        public static EventManager registration,login,balanceCheck,recharge,viewTravelHistory,travel;
        public static void Subcribe()
        {
            registration = new EventManager(Operation.Registration);
            login = new EventManager(Operation.Login);
            balanceCheck = new EventManager(Operation.BalanceCheck);
            recharge = new EventManager(Operation.Recharge);
            viewTravelHistory = new EventManager(Operation.ViewTravelHistory);
            travel = new EventManager(Operation.Travel);
        }


        public static void MainMenu()
        {
            int option = 0;
            do
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("              Main Menu           ");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("1.User Registration");
                System.Console.WriteLine("2.Login");
                System.Console.WriteLine("3.Exit ");
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
                                System.Console.WriteLine("Invalid option");
                                break;
                            }
                }
            }while(option!=3);
        }

        private static void Login()
        {
            System.Console.WriteLine("***************Login**********");
            System.Console.WriteLine("Enter the Card Number :");
            string cardNumber = Console.ReadLine().ToUpper(); 

            currentUser = IsValidCardNumber(cardNumber);
           

            if(currentUser != null)
            {
                SubMenu();
            }
            else
            {
                System.Console.WriteLine("Invalid Card Number");
            }
        }

        private static void SubMenu()
        {
            int option = 0;
            do
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("          Sub Menu          ");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("1.Balance Check");
                System.Console.WriteLine("2.Recharge");
                System.Console.WriteLine("3.View Travel History");
                System.Console.WriteLine("4.Travel");
                System.Console.WriteLine("5.Exit");
                System.Console.WriteLine("Enter the option :");
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                balanceCheck();
                                break;
                            }
                    case 2:
                            {
                                recharge();
                                break;
                            }
                    case 3:
                            {
                                viewTravelHistory();
                                break;
                            }
                    case 4:
                            {
                                travel();
                                break;
                            }
                    case 5:
                            {
                                option = 5;
                                break;
                            }
                }
            }while(option != 5);

        }

        
        private static void ViewTravelHistory()
        {
            System.Console.WriteLine("****************Travel history *******************");
            System.Console.WriteLine();
            foreach(TravelDetails history in travelList)
            {
                if(currentUser.CardNumber == history.CardNumber)
                {
                    System.Console.WriteLine($"{history.TravelID}  {history.CardNumber}  {history.FromLocation} {history.ToLocation} {history.Date.ToString("dd/MM/yyyy")}   {history.TravelCost}");
                }
            }
        }

        private static void Recharge()
        {
            System.Console.WriteLine("Enter the amount to be Recharge ");
            int amount = int.Parse(Console.ReadLine());

            currentUser.Recharge(amount);
            System.Console.WriteLine("*****************Amount recharged successfully******************");
        }

        private static void BalanceCheck()
        {

            System.Console.WriteLine($"Available Balance : {currentUser.Balance}");
        }

        public static UserDetails IsValidCardNumber(string cardNumber)
        {
            foreach(UserDetails user in userList)
            {
                if(user.CardNumber == cardNumber)
                {
                    return user;
                }
            }
            return null;
        }
        private static void Registration()
        {
            System.Console.WriteLine("****************Registration form*****************");
            
            System.Console.WriteLine("Enter your name :");
            string name = Console.ReadLine();
            
            System.Console.WriteLine("Enter the phone number :");
            ulong mobileNumber = ulong.Parse(Console.ReadLine());

            System.Console.WriteLine("Initial Balance :");
            long Balance = long.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(name,mobileNumber,200);
            userList.Add(user);

            System.Console.WriteLine($"Your Card Number is {user.CardNumber}");
            System.Console.WriteLine("*********************Registration successfull*********************");
            
        }

        public static void DefaultData()
        {
            UserDetails user1 = new UserDetails("jagadeesh",987543210,1000);
            UserDetails user2 = new UserDetails("Abhi",987523210,2000);
            userList.Add(user1);
            userList.Add(user2);

            TravelDetails travelPerson1 = new TravelDetails(user1.CardNumber,"Anna nagar","kilpauk",DateTime.Now,50);
            TravelDetails travelPerson2 = new TravelDetails(user2.CardNumber,"chennai egmore","beach",DateTime.Now,20);
            TravelDetails travelPerson3 = new TravelDetails(user1.CardNumber,"Guindy","thousand lights",DateTime.Now,30);
            TravelDetails travelPerson4 = new TravelDetails(user2.CardNumber,"tambaram","guindy",DateTime.Now,60);
            travelList.Add(travelPerson1);
            travelList.Add(travelPerson2);
            travelList.Add(travelPerson3);
            travelList.Add(travelPerson4);

            TicketFairDetails fair = new TicketFairDetails("Airport","Egmore",50);
            TicketFairDetails fair2 = new TicketFairDetails("Airport","Koyambedu",25);
            TicketFairDetails fair3 = new TicketFairDetails("Airport","Koyambedu",30);
            TicketFairDetails fair4 = new TicketFairDetails("koyambedu","Egmore",40);
            TicketFairDetails fair5 = new TicketFairDetails("guindy","Airport",30);
            TicketFairDetails fair6 = new TicketFairDetails("guindy","Thousand lights",40);
            TicketFairDetails fair7 = new TicketFairDetails("Saidapet","Meenambakkam",20);
            TicketFairDetails fair8 = new TicketFairDetails("vadapalani","Koyambedu",16);
            ticketList.Add(fair);
            ticketList.Add(fair2);
            ticketList.Add(fair3);
            ticketList.Add(fair4);
            ticketList.Add(fair5);
            ticketList.Add(fair6);
            ticketList.Add(fair7);
            ticketList.Add(fair8);



            foreach(UserDetails user in userList)
            {
                System.Console.WriteLine($"{user.CardNumber}  {user.UserName}  {user.MobileNumber} {user.Balance}");
            }

            foreach(TicketFairDetails ticket in ticketList)
            {
                System.Console.WriteLine($"{ticket.TicketID} {ticket.FromLocation} {ticket.ToLocation} {ticket.TicketPrice}");
            }

            foreach(TravelDetails travel in travelList)
            {
                System.Console.WriteLine($"{travel.TravelID} {travel.CardNumber} {travel.FromLocation} {travel.ToLocation} {travel.Date.ToString("dd/MM/yy")} {travel.TravelCost}");
            }


        }
    }
}