using System;
using System.Collections.Generic;

namespace OnlineMedicalStore
{
    public class Operation
    {
        //collect the information about all users 
        static List<UserDetails> userList = new List<UserDetails>();
        //collect the information about all medical item
        static List<MedicineDetails> medicineList = new List<MedicineDetails>();
        //collect the information about all ordered item
        static List<OrderDetails> orderList = new List<OrderDetails>();
        //To store current user details
        static UserDetails currentUser;
        //To store current medicine purchased item
        static MedicineDetails currentMedicine;
        //To store current ordered detatils
        static OrderDetails currentOrder;


        //Main menu for registration,login and exit area 
        public static void MainMenu()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("                    ONLINE MEDICAL STORE                     ");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            
            int option = 0;
            do
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("       Main  Menu        ");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<");
                System.Console.WriteLine();

                System.Console.WriteLine("1.User Registration");
                System.Console.WriteLine("2.User Login");
                System.Console.WriteLine("3.Exit");
                System.Console.WriteLine("Enter the option :");
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                Registration();
                                break;
                            }
                    case 2:
                            {
                                Login();
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

        /*Login method used for Ask the user id and validate the id afterwards get into submenu
          if userd doesnot exit show invalid id*/
        private static void Login()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("   User Login ");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine();
            
            System.Console.WriteLine("Enter User ID :");
            string userID = Console.ReadLine().ToUpper();

            currentUser = ValidateUserID(userID);

            if(currentUser != null)
            {
                System.Console.WriteLine("************Login successful************");
                SubMenu();
            }
            else
            {
                System.Console.WriteLine("********Invalid User ID**********");
            }
            

        }
        //submenu used for purchasing the items, recharge the balance, medicine list
        private static void SubMenu()
        {
            char option = '\0';
            do
            {
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                System.Console.WriteLine("          Sub Menu          ");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine();
                System.Console.WriteLine("a.Show Medicine List");
                System.Console.WriteLine("b.Purchase Medicine");
                System.Console.WriteLine("c.Cancel Purchase");
                System.Console.WriteLine("d.Show Purchase History");
                System.Console.WriteLine("e.Recharge");
                System.Console.WriteLine("f.Exit");
                System.Console.WriteLine("Enter the Option :");
                option = char.Parse(Console.ReadLine());

                switch(option)
                {
                    case 'a':
                            {
                                ShowMedicineList();
                                break;
                            }
                    case 'b':
                            {
                                PurchaseMedicine();
                                break;
                            }
                    case 'c':
                            {
                                CancelPurchase();
                                break;
                            }
                    case 'd':
                            {
                                ShowPurchaseHistory();
                                break;
                            }
                    case 'e':
                            {
                                Recharge();
                                break;
                            }
                    case 'f':
                            {
                                option = 'f';
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("     Invalid Option    ");
                                break;
                            }
                }
            }while(option != 'f');

        }


        //Recharge method is to amount add to current logged in user balance
        private static void Recharge()
        {
          System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<");
          System.Console.WriteLine("   Recharge  ");
          System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>");
          System.Console.WriteLine();
          
          System.Console.WriteLine("Enter the amount to be recharged :");
          long amount = long.Parse(Console.ReadLine());

          currentUser.UpdateBalance(amount);

          System.Console.WriteLine("****************************");
          System.Console.WriteLine("    Recharged Successfully  ");
          System.Console.WriteLine("****************************");
        }

        private static void ShowPurchaseHistory()
        {
           System.Console.WriteLine($" Purchase history of {currentUser.UserName} {currentUser.UserID}");

           string line = "+--------------------------------------------------------------------------------------------------------------------+";
           System.Console.WriteLine(line);
           System.Console.WriteLine("| OrderID  | User ID  | Medicine ID    | Medicine Count  | Total Price  | OrderDate              | Ordered Status    |");
           System.Console.WriteLine(line);
           foreach(OrderDetails order in orderList)
           {
                if(order.UserID == currentUser.UserID &&  order.OrderStatus == OrderStatus.Purchased)
                {
                         System.Console.WriteLine($"| {(order.OrderID).PadRight(9)}| {(order.UserID).PadRight(9)}| {(order.MedicineID).PadRight(14)}|  {(""+order.MedicineCount).PadRight(15)}| {(""+order.TotalPrice).PadRight(14)}| {(""+order.OrderDate.ToString("dd/MM/yyyy")).PadRight(23)}| {(""+order.OrderStatus).PadRight(15)}   |");
                }
           }   
           System.Console.WriteLine(line);
        }
        
        /*Cancel the purchase using current logged in user
         get information from orderlist*/
        private static void CancelPurchase()
        {
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine(" Cancel Purchasing    ");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine();
            
            string line = "+--------------------------------------------------------------------------------------------------------------------+";
            System.Console.WriteLine(line);
            System.Console.WriteLine("| OrderID  | User ID  | Medicine ID    | Medicine Count  | Total Price  | OrderDate              | Ordered Status    |");
            System.Console.WriteLine(line);
            foreach(OrderDetails order in orderList)
            {
                if(order.OrderStatus == OrderStatus.Purchased)
                {
                    System.Console.WriteLine($"| {(order.OrderID).PadRight(9)}| {(order.UserID).PadRight(9)}| {(order.MedicineID).PadRight(14)}|  {(""+order.MedicineCount).PadRight(15)}| {(""+order.TotalPrice).PadRight(14)}| {(""+order.OrderDate).PadRight(23)}| {(""+order.OrderStatus).PadRight(15)}   |");
                }
            }
            System.Console.WriteLine(line);

            System.Console.WriteLine("Enter Order ID :");
            string orderID = Console.ReadLine().ToUpper();
            
            currentOrder = IsPresentInOrderList(orderID);//order id is present it returns the object

            if(currentOrder != null)
            {
                if(currentOrder.OrderStatus == OrderStatus.Purchased)//check current order is purchased or not
                {
                    foreach(MedicineDetails medicine in medicineList)
                    {
                        if(medicine.MedicineID == currentOrder.MedicineID)//check item present in list or not
                        {
                           medicine.UpdateStock(currentOrder.MedicineCount); //Update the medicine stock
                           System.Console.WriteLine("***************************************");
                           System.Console.WriteLine("Item added to medicine stock succesfully");
                           System.Console.WriteLine("*****************************************");
                        }
                    }
                    
                    currentUser.UpdateBalance(currentOrder.TotalPrice);//Amount added to current logged in user
                    System.Console.WriteLine("************Amount Refunded Successfully***************");
                    
                    currentOrder.OrderStatus = OrderStatus.Cancelled;//current order status is changed to cancelled

                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine($"{currentOrder.OrderID} was cancelled successfully ");
                    System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                }
                else
                {
                    System.Console.WriteLine($"*******{currentOrder.OrderID}  Order is not purchased*****************");
                }
            }
            else
            {
                System.Console.WriteLine("****************Order ID is invalid****************");
            }
        }


        private static OrderDetails IsPresentInOrderList(string orderID)//check order id present in orderlist
        {
            foreach(OrderDetails order in orderList)
            {
                if(order.OrderID == orderID)
                {
                    return order;
                }
            }
            return null;
        }

        //Purchase medicine used to purchase the product 
        private static void PurchaseMedicine()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("      purchasing medicine ");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine();
            ShowMedicineList();
            System.Console.WriteLine();
            
            System.Console.WriteLine("Enter the medicine ID :");
            string medicineID = Console.ReadLine().ToUpper();
            
         
            currentMedicine = ValidateMedicineID(medicineID);//validate the id

            if(currentMedicine != null)
            {
                System.Console.WriteLine("How many medicine do you want ?");
                int medicineCount = int.Parse(Console.ReadLine());
                
                if(currentMedicine.AvailableCount >= medicineCount)
                {
                    long totalPrice = currentMedicine.Price * medicineCount;//calculate the total price for purchased medicine
                    if(currentUser.Balance >= totalPrice)//check the balance is available
                    {
                        if(currentMedicine.DOE >= DateTime.Now) //check the medicine is expired or not
                        {
                            currentMedicine.AvailableCount = currentMedicine.AvailableCount - medicineCount;//Reduce the count in medicine stock
                            currentUser.ReductBalance(totalPrice);//reduct the balance current logged in user

                            OrderDetails order = new OrderDetails(currentUser.UserID,currentMedicine.MedicineID,medicineCount,totalPrice,DateTime.Now,OrderStatus.Purchased);//store the item in orderlist
                            orderList.Add(order);
                            System.Console.WriteLine("*****************************************");
                            System.Console.WriteLine("   Medicine was purchased successfully ");
                            System.Console.WriteLine("*****************************************");
                        }
                        else
                        {
                            System.Console.WriteLine("*****************Medicine is Expired***************");
                        }                 
                    }
                    else
                    {
                        System.Console.WriteLine("*************Insufficient Balance***************");
                    }
                }
                else
                {
                    System.Console.WriteLine("***********Medicine is out of stock**********");
                }
            }
            else
            {
                System.Console.WriteLine("*******************Invalid medicineID**********************");
            }

            
        }

        //ValidationMedicineID used for Validate the current logged in MEDICINE ID
        private static MedicineDetails ValidateMedicineID(string medicineID)
        {
            foreach(MedicineDetails medicine in medicineList) 
            {
                if(medicine.MedicineID == medicineID)
                {
                    return medicine;
                }
            }
            return null;
        }
        /*MedicineList method used to collect the information about medicines in medicine list.
          It is used to show the user for list of available medicine  */
        private static void ShowMedicineList()
        {
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine(" List of availale medicine ");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            string line = "+----------------------------------------------------------------------------------+";
            System.Console.WriteLine(line);
            System.Console.WriteLine("| Medicine ID  | MedicineName        | Available Count  | Price  | Date Of Expiry  |");
            System.Console.WriteLine(line);
            foreach(MedicineDetails medicine in medicineList) 
            {
                System.Console.WriteLine($"|{(medicine.MedicineID).PadRight(14)}| {(medicine.MedicineName).PadRight(20)}|{ (""+medicine.AvailableCount).PadRight(18)}|{ (""+medicine.Price).PadRight(8)}|{(""+medicine.DOE.ToString("dd/MM/yyyy")).PadLeft(12)}     |");
            }
            System.Console.WriteLine(line);  
        }

        //ValidationUserID used for Validate the current logged in user 
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
        /*Registration method used for collect the information about
        new user and store it in list*/ 
        private static void Registration()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("        Registration Form     ");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine();
            
            System.Console.WriteLine("Enter your Name");
            string userName =Console.ReadLine();
            
            System.Console.WriteLine("Enter your Age :");
            int age = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your city :");
            string city = Console.ReadLine();
            
            System.Console.WriteLine("Enter your phone number :");
            ulong phoneNumber = ulong.Parse(Console.ReadLine());

            System.Console.WriteLine("Initial Balance");
            long balance = long.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(userName,age,city,phoneNumber,balance);

            userList.Add(user);

            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine($"Your registration is successfull. your ID is {user.UserID}");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

        }

        /*Default data used to collect the information about user details,medicine details
        order details.InBuild users in list*/

        public static void DefaultData()
        {
            //Default user add to userlist
            UserDetails user1 = new UserDetails("Ravi",33,"Theni",9876543210,400);
            UserDetails user2 = new UserDetails("Jagadeesh",21,"Chennai",9846543210,400);
            userList.Add(user1);
            userList.Add(user2);
            
            //Default medicine add to medicine list
            MedicineDetails medicine1 = new MedicineDetails("Paracitamol",40,5,new DateTime(2022,06,30));
            MedicineDetails medicine2 = new MedicineDetails("Calpol",10,5,new DateTime(2023,11,30));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil",3,40,new DateTime(2023,02,12));
            MedicineDetails medicine4 = new MedicineDetails("MetroGel",5,40,new DateTime(2024,04,15));
            MedicineDetails medicine5 = new MedicineDetails("Povidin lodin",5,50,new DateTime(2022,06,28));
            medicineList.Add(medicine1);
            medicineList.Add(medicine2);
            medicineList.Add(medicine3);
            medicineList.Add(medicine4);
            medicineList.Add(medicine5);

            //default order added to orderlist
            OrderDetails order1 = new OrderDetails(user1.UserID,medicine1.MedicineID,3,medicine1.Price,DateTime.Now,OrderStatus.Purchased);
            OrderDetails order2 = new OrderDetails(user1.UserID,medicine2.MedicineID,2,medicine2.Price,DateTime.Now,OrderStatus.Cancelled);
            OrderDetails order3 = new OrderDetails(user1.UserID,medicine3.MedicineID,2,medicine3.Price,DateTime.Now,OrderStatus.Purchased);
            OrderDetails order4 = new OrderDetails(user2.UserID,medicine3.MedicineID,2,medicine3.Price,DateTime.Now,OrderStatus.Purchased);
            OrderDetails order5 = new OrderDetails(user2.UserID,medicine4.MedicineID,2,medicine4.Price,DateTime.Now,OrderStatus.Purchased);
            OrderDetails order6 = new OrderDetails(user2.UserID,medicine5.MedicineID,2,medicine4.Price,DateTime.Now,OrderStatus.Purchased);
            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);
            orderList.Add(order4);
            orderList.Add(order5);
            orderList.Add(order6);
        } 
    }
}