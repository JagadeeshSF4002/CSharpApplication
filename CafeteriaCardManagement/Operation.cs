using System;


namespace CafeteriaCardManagement
{
    
    public static partial class Operation
    {
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<FoodDetails> foodList = new List<FoodDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static List<CartItem> cartList = new List<CartItem>();

        public static event EventManager registration,login,showMyProfile,foodOrder,cancelOrder,orderHistory,walletRecharge;

        public static UserDetails currentUser;
        public static FoodDetails currentFood;
        public static CartItem currentCartItem;
        public static OrderDetails currentOrder;

        public static void subcribe()
        {
            registration = new EventManager(Operation.Registration);
            login = new EventManager(Operation.Login);
            showMyProfile = new EventManager(Operation.ShowMyProfile);
            foodOrder = new EventManager(Operation.FoodOrder);
            cancelOrder = new EventManager(Operation.CancelOrder);
            orderHistory = new EventManager(Operation.OrderHistory);
            walletRecharge = new EventManager(Operation.WalletRecharge);
        }
        public static void MainMenu()
        {
            int option = 0;
            bool status = false;
            do
            {
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<");
                System.Console.WriteLine("          Main Menu       ");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("1.User Registration");
                System.Console.WriteLine("2.Login");
                System.Console.WriteLine("3.Exit");
                System.Console.WriteLine("Enter the option :");
                status = int.TryParse(Console.ReadLine(),out option);

                if(status)
                {
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
                                    System.Console.WriteLine(" Invalid Option ");
                                    break;
                                }
                    }
                }
                else
                {
                    System.Console.WriteLine(" characters or special case not allowed Enter the valid option ");
                }
            }while(option != 3);

        }

        private static void Login()
        {
            System.Console.WriteLine("Enter the User ID :");
            string userID = Console.ReadLine().ToUpper();
            
            currentUser = IsValidUserID(userID);

            if(currentUser != null)
            {
                SubMenu();
            }
            else
            {
                System.Console.WriteLine("***************Invalid ID*****************");
            }
        }

        private static void SubMenu()
        {
            char option = '\0';
            do
            {
                    System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    System.Console.WriteLine("              Sub Menu           ");
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine("a. Show my profile");
                    System.Console.WriteLine("b. Food Order ");
                    System.Console.WriteLine("c. Cancel Order");
                    System.Console.WriteLine("d. Order History");
                    System.Console.WriteLine("e. Wallet Recharge");
                    System.Console.WriteLine("f. Exit");
                    System.Console.WriteLine("Enter the option :");
                    option = char.Parse(Console.ReadLine());

                    switch(option)
                    {
                        case 'a':
                                {
                                    showMyProfile();
                                    break;
                                }
                        case 'b':
                                {
                                    foodOrder();
                                    break;
                                }
                        case 'c':
                                {
                                    cancelOrder();
                                    break;
                                }
                        case 'd':
                                {
                                    orderHistory();
                                    break;
                                }
                        case 'e':
                                {
                                    walletRecharge();
                                    break;
                                }
                        case 'f':
                                {
                                    option = 'f';
                                    break;
                                }
                        default:
                                {
                                    System.Console.WriteLine("************Invalid Option***************");
                                    break;
                                }
                    }
            }while(option != 'f');

        }

        private static void WalletRecharge()
        {
           long amount = 0; 
           bool status = false;
           do
           {
                System.Console.WriteLine("Enter the amount to be recharged :");
                status = long.TryParse(Console.ReadLine(),out amount);
                if(!status)
                {
                    System.Console.WriteLine("**********Invalid cases enter the amount in digit**************");
                }
           }while(!status);

           currentUser.WalletRecharge(amount);
           System.Console.WriteLine("************Recharged succesfully***********");
        }

        private static void OrderHistory()
        {
            foreach(OrderDetails data in orderList)
            {
                if(data.UserID == currentUser.UserID)
                {
                    System.Console.WriteLine(data.OrderID+" "+data.UserID+" "+data.TotalPrice+" "+data.OrderDate.ToString("dd/MM/yyyy")+" "+data.OrderStatus);
                }
            }
        }

       
        
        private static void ShowMyProfile()
        {
            System.Console.WriteLine($"{currentUser.UserID}  {currentUser.Name}  {currentUser.FatherName}  {currentUser.Gender} {currentUser.MobileNumber}  {currentUser.MailID} {currentUser.WorkStationNumber} {currentUser.WalletBalance} ");
        }

        private static UserDetails IsValidUserID(string userID)
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
           bool status = false;
           long mobileNumber;
           Gender gender;
           long balance;

           System.Console.WriteLine("Enter the user name :");
           string userName = Console.ReadLine();

           System.Console.WriteLine("Enter the father name :");
           string fatherName = Console.ReadLine();
          
           do
           {
             System.Console.WriteLine("Enter the mobile Number :");
             status = long.TryParse(Console.ReadLine(),out mobileNumber);
             if(!status)
             {
                System.Console.WriteLine("Invalid data try again");
             }
           }while(!status);
         
            System.Console.WriteLine("Enter the mail ID :");
            string mailID = Console.ReadLine();

           do
           {
            System.Console.WriteLine("Enter the Gender : {Male/Female/Transgender}");
            status = Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
            if(!status)
            {
                System.Console.WriteLine("Invalid data try again");
            }
           }while(!status);

            System.Console.WriteLine("Enter the Work station number :");
            string workStationNumber = Console.ReadLine();

           do
           {
            System.Console.WriteLine("Enter the Balance :");
            status = long.TryParse(Console.ReadLine(),out balance);
            if(!status)
            {
                System.Console.WriteLine("Invalid data try again");
            } 
           }while(!status);   

           UserDetails user = new UserDetails(userName,fatherName,gender,mobileNumber,mailID,workStationNumber,balance);  
           userList.Add(user);
           System.Console.WriteLine($"Your Id is {user.UserID}"); 
        }

        public static void DefaultData()
        {
            UserDetails user = new UserDetails("Ravichandran","Ettaparajan",Gender.Male,987654311,"jaga@gmail.com","WS101",20000);
            UserDetails user2 = new UserDetails("Baskaran","Sethurajan",Gender.Male,947654311,"basker@gmail.com","WS105",30000);
            userList.Add(user);
            userList.Add(user2);

            FoodDetails food1 = new FoodDetails("Coffee",20,100);
            FoodDetails food2 = new FoodDetails("Tea",15,100);
            FoodDetails food3 = new FoodDetails("Biscuit",10,100);
            FoodDetails food4 = new FoodDetails("Juice",50,100);
            FoodDetails food5 = new FoodDetails("Puff",40,100);
            FoodDetails food6 = new FoodDetails("Milk",10,100);
            FoodDetails food7 = new FoodDetails("Popcorn",20,10);
            foodList.Add(food1);
            foodList.Add(food2);
            foodList.Add(food3);
            foodList.Add(food4);
            foodList.Add(food5);
            foodList.Add(food6);
            foodList.Add(food7);

            OrderDetails order = new OrderDetails(user.UserID,DateTime.Now,70,OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails(user2.UserID,DateTime.Now,100,OrderStatus.Ordered);
            orderList.Add(order);
            orderList.Add(order2);

            CartItem cart1 = new CartItem(order.OrderID,food1.FoodID,food1.FoodPrice,1);
            CartItem cart2 = new CartItem(order.OrderID,food2.FoodID,food2.FoodPrice,1);
            CartItem cart3 = new CartItem(order.OrderID,food3.FoodID,food3.FoodPrice,1);
            CartItem cart4 = new CartItem(order2.OrderID,food4.FoodID,food4.FoodPrice,1);
            CartItem cart5 = new CartItem(order2.OrderID,food4.FoodID,food4.FoodPrice,1);
            CartItem cart6 = new CartItem(order2.OrderID,food5.FoodID,food5.FoodPrice,1);
            cartList.Add(cart1);
            cartList.Add(cart2);
            cartList.Add(cart3);
            cartList.Add(cart4);
            cartList.Add(cart5);
            cartList.Add(cart6);

            foreach(UserDetails data in userList)
            {
                System.Console.WriteLine(data.UserID+" "+data.Name+" "+data.FatherName+" "+data.MobileNumber+" "+data.Gender+" "+data.MailID+" "+data.WorkStationNumber);
            }
            System.Console.WriteLine();
            foreach(FoodDetails data in foodList)
            {
                System.Console.WriteLine(data.FoodID+" "+data.FoodName+" "+data.FoodPrice+" "+food1.AvailableQuantity);
            }
            System.Console.WriteLine();
            foreach(OrderDetails data in orderList)
            {
                System.Console.WriteLine(data.OrderID+" "+data.UserID+" "+data.TotalPrice+" "+data.OrderDate.ToString("dd/MM/yyyy")+" "+data.OrderStatus);
            }
            System.Console.WriteLine();
            foreach(CartItem cart in cartList)
            {
                System.Console.WriteLine(cart.ItemID+" "+cart.FoodID+" "+cart.OrderID+" "+cart.OrderPrice+" "+cart.OrderQuantity);
            }
        }     
    }
}