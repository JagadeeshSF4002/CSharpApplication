using System.Globalization;
using System.Net.WebSockets;
using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public static partial class Operation
    {
        public static EventManager registration,login,showProfile,orderFood,cancelOrder,orderHistory,rechargeWallet,showBalance;
        //Subcribe method used for Indirect call for all the methods
        public static void Subcribe()
        {
            registration = new EventManager(Operation.Registration);
            login = new EventManager(Operation.Login);
            showProfile = new EventManager(Operation.ShowProfile);
            orderFood = new EventManager(Operation.OrderFood);
            cancelOrder = new EventManager(Operation.CancelOrder);
            orderHistory = new EventManager(Operation.OrderHistory);
            rechargeWallet = new EventManager(Operation.RechargeWallet);
            showBalance = new EventManager(Operation.ShowBalance);
        }
        public static List<CustomerDetails> customerList = new List<CustomerDetails>();
        public static List<FoodDetails> foodList = new List<FoodDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static List<ItemDetails> itemList = new List<ItemDetails>();

        public static CustomerDetails currentCustomer; 

        static string line = ":::::::::::::::::::::::::::::::::::::::::::::::::::::::";

        //User view food cart delivery
        public static void MainMenu()
        {
            int option = 0;
            bool status = false;

            do
            {   
                System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                System.Console.WriteLine("             WELCOME TO FOOD CART DELIVERY             ");
                System.Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                System.Console.WriteLine();
                System.Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                System.Console.WriteLine("                       Main Menu                        ");
                System.Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                System.Console.WriteLine();

                System.Console.WriteLine("1. Customer Registration ");
                System.Console.WriteLine("2. Customer Login");
                System.Console.WriteLine("3. Exit");
                System.Console.WriteLine("Enter the Option");
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
                                    System.Console.WriteLine("**************Invalid Option*************");
                                    break;
                                }
                    }
                }
                else
                {
                    System.Console.WriteLine("Please enter the digit format ");
                }
            }while(option != 3);
            
        }
        //Login method used to get the customer id and validate the id
        private static void Login()
        {
            System.Console.WriteLine(line);
            System.Console.WriteLine("                    Customer Login       ");
            System.Console.WriteLine(line);
            System.Console.WriteLine();
            
            System.Console.WriteLine("Enter the Customer ID :");
            string customerID = Console.ReadLine().ToUpper();//Getting  ID from user

            currentCustomer = ValidateCustomerID(customerID); //returns object 

            if(currentCustomer != null)
            {
                SubMenu();
            }
            else
            {
                System.Console.WriteLine("*****************Invalid Customer ID***************");
            }
            
        }
        //Display the sub items for ordering and cancelling the food
        private static void SubMenu()
        {
           int option = 0;
           bool status = false;
           do
           {
                System.Console.WriteLine(line);
                System.Console.WriteLine("                   Sub Menu                 ");
                System.Console.WriteLine(line);
                System.Console.WriteLine();
                System.Console.WriteLine("1. Show Profile ");
                System.Console.WriteLine("2. Order Food ");
                System.Console.WriteLine("3. Cancel order");
                System.Console.WriteLine("4. Order History");
                System.Console.WriteLine("5. Recharge Wallet");
                System.Console.WriteLine("6. Show Balance");
                System.Console.WriteLine("7. Exit");
                System.Console.WriteLine("Enter the Option :");
                status = int.TryParse(Console.ReadLine(),out option);
                if(status)
                {
                        switch(option)
                        {
                            case 1:
                                    {
                                        showProfile(); 
                                        break;
                                    }
                            case 2:
                                    {
                                        orderFood();
                                        break;
                                    }
                            case 3:
                                    {
                                        cancelOrder();
                                        break;
                                    }
                            case 4:
                                    {
                                        orderHistory();
                                        break;
                                    }
                            case 5:
                                    {
                                        rechargeWallet();
                                        break;
                                    }
                            case 6:
                                    {
                                        showBalance();
                                        break;
                                    }
                            case 7:
                                    {
                                        option = 7;
                                        break;
                                    }
                            default:
                                    {
                                        System.Console.WriteLine("*************Invalid Option**************");
                                        break;
                                    }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Enter the option in digit format");
                    }
          }while(option != 7);
        }
        //It is used for show a balance for current logged in user
        private static void ShowBalance()
        {
            System.Console.WriteLine($"Current Available balance is {currentCustomer.WalletBalance}");
        }
        /*Recharge Wallet method used for get the amount user and store into the current
        logged user wallet*/
        private static void RechargeWallet()
        {
            bool status = false;
            double amount = 0;
            System.Console.WriteLine(line);
            System.Console.WriteLine("Recharging the Wallet ");
            System.Console.WriteLine(line);
            do
            {
                System.Console.WriteLine("Enter the amount to be recharged :");
                status = double.TryParse(Console.ReadLine(),out amount);
                if(!status)
                {
                    System.Console.WriteLine("Invalid please enter digit format");
                }
            }while(!status);
            currentCustomer.WalletRecharge(amount);
            System.Console.WriteLine($"Recharged successfully your current balance is {currentCustomer.WalletBalance}");
            
        }
        //Order History of current logged in user
        private static void OrderHistory()
        {
            System.Console.WriteLine($"Order History of {currentCustomer.CustomerID}");
            string lines = "+-----------------------------------------------------------------------+";
            System.Console.WriteLine(lines);
            System.Console.WriteLine("| OrderID  | CustomerID  | Total Price   | Date Of Order  | OrderStatus |");
            System.Console.WriteLine(lines);
            foreach(OrderDetails order in orderList)
            {
                if(order.CustomerID == currentCustomer.CustomerID && order.OrderStatus == OrderStatus.Ordered)
                {
                    System.Console.WriteLine($"| {order.OrderID.PadRight(9)}| {order.CustomerID.PadRight(12)}| {(""+order.TotalPrice).PadRight(14)}| {(""+order.DateOfOrder.ToString("dd/MM/yyyy")).PadRight(15)}| {(""+order.OrderStatus).PadRight(12)}|");
                }
            }
            System.Console.WriteLine(lines);
            System.Console.WriteLine();


        }

        

       
        /*ShowProfile method used to show current logged customer */
        private static void ShowProfile()
        { 
           string liner = "+-------------------------------------------------------------------------------------------------------------------------------------------------------+";
           System.Console.WriteLine(liner);
           System.Console.WriteLine("| Customer ID  | Customer Name     | Father's Name    | Gender   | Mobile Number   | Date Of Birth   | Mail ID         | Location     | Wallet Balance  |");
           System.Console.WriteLine(liner);
           System.Console.WriteLine($"| {currentCustomer.CustomerID.PadRight(13)}| {currentCustomer.Name.PadRight(18)}| {currentCustomer.FatherName.PadRight(17)}| {(""+currentCustomer.Gender).PadRight(9)}| {(""+currentCustomer.MobileNumber).PadRight(16)}| {(""+currentCustomer.DOB.ToString("dd/MM/yyyy")).PadRight(16)}| {currentCustomer.MailID.PadRight(16)}| {currentCustomer.Location.PadRight(13)}| {(""+currentCustomer.WalletBalance).PadRight(16)}|");
           System.Console.WriteLine(liner);
        }
        /* ValidateCustomerID method used validate ID in customer List if it is there it 
            returns current object otherwise null.
        */
        private static CustomerDetails ValidateCustomerID(string customerID)
        {
            foreach(CustomerDetails customer in customerList)
            {
                if(customer.CustomerID == customerID)
                {
                    return customer;
                }
            }
            return null;
        }

        /*Get the information from user and pass into the Customer Details and also store
        a infomation into the customer list*/
        private static void Registration()
        {
            bool status = false;
            Gender gender;
            ulong mobileNumber;
            double balance;
            DateTime dob ;
            System.Console.WriteLine(line);
            System.Console.WriteLine(" Customer Registration ");
            System.Console.WriteLine(line);
            System.Console.WriteLine();
            
            System.Console.WriteLine("Enter your name :");
            string name = Console.ReadLine();

            System.Console.WriteLine("Enter your Father name :");
            string fatherName = Console.ReadLine();
            do
            {
                System.Console.WriteLine("Enter the Gender : say {Male/Female/Transgender}");
                status = Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
                if(!status)
                {
                    System.Console.WriteLine("Invalid say {Male/Female/Transgender}");// Validate the status
                }
            }while(!status);

            do
            {
                System.Console.WriteLine("Enter the Mobile Number :");
                status = ulong.TryParse(Console.ReadLine(),out mobileNumber);
                if(!status)
                {
                    System.Console.WriteLine("Invalid Enter the number in digits ");
                }
            }while(!status);

            do
            {
                System.Console.WriteLine("Enter the Date of Birth : {dd/MM/yyyy}");
                status = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,DateTimeStyles.None,out dob);
                if(!status)
                {
                    System.Console.WriteLine("Invalid Format try again");
                }
            }while(!status);

            System.Console.WriteLine("Enter the Mail ID :");
            string mailID = Console.ReadLine();
            
            System.Console.WriteLine("Enter the location :");
            string location = Console.ReadLine();

            do
            {
                System.Console.WriteLine("Initial Balance :");
                status = double.TryParse(Console.ReadLine(),out balance);
                if(!status)
                {
                    System.Console.WriteLine("Invalid Enter the number in digits ");
                }
            }while(!status);
            
            CustomerDetails customer = new CustomerDetails(name,fatherName,gender,mobileNumber,dob,mailID,location,balance);
            customerList.Add(customer);
            System.Console.WriteLine($"Your ID is {customer.CustomerID}");

            System.Console.WriteLine("*********************Registration Succesfull**********************");
            
        }
        //Default Data for all Models like customer details,food details,item details, order details
        public static void DefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails("Ravichanran","Ettaparajan",Gender.Male,9876543210,new DateTime(1999,11,11),"ravi@gmail.com","chennai",10000);
            CustomerDetails customer2 = new CustomerDetails("Baskarn","Sethurajan",Gender.Male,9876544210,new DateTime(1999,11,11),"baskar@gmail.com","chennai",15000);
            customerList.Add(customer1);
            customerList.Add(customer2);

            FoodDetails food1 = new FoodDetails("Chicken Briyani 1KG",100,12);
            FoodDetails food2 = new FoodDetails("Mutton Briyani 1KG",150,10);
            FoodDetails food3 = new FoodDetails("Veg Full Meals",80,30);
            FoodDetails food4 = new FoodDetails("Noodles ",100,40);
            FoodDetails food5 = new FoodDetails("Dosa",40,40);
            FoodDetails food6 = new FoodDetails("Idly(2 pieces)",20,50);
            FoodDetails food7 = new FoodDetails("Pongal",40,20);
            FoodDetails food8 = new FoodDetails("Vegetable Briyani",80,15);
            FoodDetails food9 = new FoodDetails("Lemon Rice",50,30);
            FoodDetails food10 = new FoodDetails("Veg Pulav",120,30);
            FoodDetails food11 = new FoodDetails("Chicken 65(200 Grams)",75,30);
            foodList.Add(food1);
            foodList.Add(food2);
            foodList.Add(food3);
            foodList.Add(food4);
            foodList.Add(food5);
            foodList.Add(food6);
            foodList.Add(food7);
            foodList.Add(food8);
            foodList.Add(food9);
            foodList.Add(food10);
            foodList.Add(food11);

            OrderDetails order1 = new OrderDetails(customer1.CustomerID,580,DateTime.Now,OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails(customer2.CustomerID,870,DateTime.Now,OrderStatus.Ordered);
            OrderDetails order3 = new OrderDetails(customer1.CustomerID,820,DateTime.Now,OrderStatus.Cancelled);
            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);

            ItemDetails item1 = new ItemDetails(order1.OrderID,food1.FoodID,2,200);
            ItemDetails item2 = new ItemDetails(order1.OrderID,food2.FoodID,2,300);
            ItemDetails item3 = new ItemDetails(order1.OrderID,food3.FoodID,1,80);
            ItemDetails item4 = new ItemDetails(order2.OrderID,food1.FoodID,1,100);
            ItemDetails item5 = new ItemDetails(order2.OrderID,food2.FoodID,4,600);
            ItemDetails item6 = new ItemDetails(order2.OrderID,food10.FoodID,1,120);
            ItemDetails item7 = new ItemDetails(order2.OrderID,food9.FoodID,1,50);
            ItemDetails item8 = new ItemDetails(order3.OrderID,food2.FoodID,2,300);
            ItemDetails item9 = new ItemDetails(order3.OrderID,food8.FoodID,4,320);
            ItemDetails item10 = new ItemDetails(order3.OrderID,food1.FoodID,2,200);
            itemList.Add(item1);
            itemList.Add(item2);
            itemList.Add(item3);
            itemList.Add(item4);
            itemList.Add(item5);
            itemList.Add(item6);
            itemList.Add(item7);
            itemList.Add(item8);
            itemList.Add(item9);
            itemList.Add(item10);
        
        }
    }
}