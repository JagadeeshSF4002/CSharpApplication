using System;
namespace OnlineGroceryStore
{
    public partial class Operation
    {
        public static List<CustomerRegistration> customerList = new List<CustomerRegistration>();
        public static List<ProductDetails> productList = new List<ProductDetails>();
        public static List<BookingDetails> bookList = new List<BookingDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static CustomerRegistration currentUser;
        public static ProductDetails currentProduct;

        public static EventManager registration,login,showCustomerDetails ,showProductDetails , walletRecharge , takeOrder , modifyOrderQuantity , cancelOrder ;

        public static void Subcribe()
        {
            registration = new EventManager(Operation.Registration);
            login = new EventManager(Operation.Login);
            showCustomerDetails = new EventManager(Operation.ShowCustomerDetails);
            showProductDetails = new EventManager(Operation.ShowProductDetails);
            walletRecharge = new EventManager(Operation.WalletRecharge);
            takeOrder = new EventManager(Operation.TakeOrder);
            modifyOrderQuantity = new EventManager(Operation.ModifyOrderQuantity);
            cancelOrder = new EventManager(Operation.CancelOrder);
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

        public static void Login()
        {
            System.Console.WriteLine("Enter the User ID :");
            string userID = Console.ReadLine().ToUpper();
            
            currentUser = IsValidUserID(userID);
            System.Console.WriteLine(currentUser.CustomerID);
            if(currentUser != null)
            {
                SubMenu();
            }
            else
            {
                System.Console.WriteLine("***************Invalid ID*****************");
            }
        }

        public static void Registration()
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

           System.Console.WriteLine("Enter the Date Of Birth :");
           DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

           do
           {
            System.Console.WriteLine("Enter the Balance :");
            status = long.TryParse(Console.ReadLine(),out balance);
            if(!status)
            {
                System.Console.WriteLine("Invalid data try again");
            } 
           }while(!status);   

           CustomerRegistration customer = new CustomerRegistration(userName,fatherName,gender,mobileNumber,dob,mailID,balance);
           System.Console.WriteLine($"Your ID is {customer.CustomerID}");

           customerList.Add(customer);

           System.Console.WriteLine("************************Registration successfull**************************");
        }

        public static void SubMenu()
        {
             char option = '\0';
            do
            {
                    System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    System.Console.WriteLine("              Sub Menu           ");
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine("a. Show customer details");
                    System.Console.WriteLine("b. Show Product details ");
                    System.Console.WriteLine("c. Wallet Recharge");
                    System.Console.WriteLine("d. Take Order");
                    System.Console.WriteLine("e. Modify Order Quantity");
                    System.Console.WriteLine("f. Cancel Order");
                    System.Console.WriteLine("g. Exit");
                    System.Console.WriteLine("Enter the option :");
                    option = char.Parse(Console.ReadLine());

                    switch(option)
                    {
                        case 'a':
                                {
                                    showCustomerDetails(); 
                                    break;
                                }
                        case 'b':
                                {
                                    showProductDetails();
                                    break;
                                }
                        case 'c':
                                {
                                    walletRecharge();
                                    break;
                                }
                        case 'd':
                                {
                                    takeOrder();
                                    break;
                                }
                        case 'e':
                                {
                                    modifyOrderQuantity();
                                    break;
                                }
                        case 'f':
                                {
                                    cancelOrder();
                                    break;
                                }
                        case 'g':
                                {
                                    option = 'g';
                                    break;
                                }
                        default:
                                {
                                    System.Console.WriteLine("************Invalid Option***************");
                                    break;
                                }
                    }
            }while(option != 'g');
        }

        public static void WalletRecharge()
        {
           System.Console.WriteLine("Enter the amount to be recharged :");
           long amount = long.Parse(Console.ReadLine());

           currentUser.WalletRecharge(amount);

        }

        public static void ShowProductDetails()
        {
            foreach(ProductDetails productData in productList)
            {
                System.Console.WriteLine(productData.ProductID+" "+productData.ProductName+" "+productData.QuantityAvailable+" "+productData.PricePerQuantity);
            }
        }

        public static void ShowCustomerDetails()
        {
            foreach(CustomerRegistration customerData in customerList)
            {
                if(customerData.CustomerID == currentUser.CustomerID)
                {
                    System.Console.WriteLine(customerData.CustomerID+" "+customerData.Name+" "+customerData.FatherName+" "+customerData.Gender+" "+customerData.MobileNumber+" "+customerData.MailID+" "+customerData.WalletBalance);
                }
            }   
        }

        private static CustomerRegistration IsValidUserID(string userID)
        {
            foreach(CustomerRegistration customer in customerList)
            {
                if(customer.CustomerID == userID)
                {
                    return customer;
                }
            }
            return null;
        }

        public static void DefaultData()
        {
            CustomerRegistration customer = new CustomerRegistration("Ravichandran","Ettaparajan",Gender.Male,9876543210,new DateTime(1999,11,20),"jaga@gmail.com",15000);
            CustomerRegistration customer2 = new CustomerRegistration("Bhaskaran","Sethurajan",Gender.Male,9876553210,new DateTime(2000,10,25),"bhaskaran@gmail.com",15000);
            customerList.Add(customer);
            customerList.Add(customer2);

            ProductDetails product1 = new ProductDetails("Sugar",20,40);
            ProductDetails product2 = new ProductDetails("Rice",100,50);
            ProductDetails product3 = new ProductDetails("Milk",10,40);
            ProductDetails product4 = new ProductDetails("Coffee",10,10);
            ProductDetails product5 = new ProductDetails("Tea",10,10);
            ProductDetails product6 = new ProductDetails("Masala Powder",10,20);
            ProductDetails product7 = new ProductDetails("Salt",10,10);
            ProductDetails product8 = new ProductDetails("Tumeric Powder",10,25);
            ProductDetails product9 = new ProductDetails("Chilli Powder",10,20);
            ProductDetails product10 = new ProductDetails("Groundnut Oil",10,140);
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);
            productList.Add(product6);
            productList.Add(product7);
            productList.Add(product8);
            productList.Add(product9);
            productList.Add(product10);

            BookingDetails bookOrder = new BookingDetails(customer.CustomerID,220,DateTime.Now,BookingStatus.Booked);
            BookingDetails bookOrder1 = new BookingDetails(customer2.CustomerID,220,DateTime.Now,BookingStatus.Booked);
            BookingDetails bookOrder2 = new BookingDetails(customer.CustomerID,220,DateTime.Now,BookingStatus.Initiated);
            BookingDetails bookOrder3 = new BookingDetails(customer2.CustomerID,220,DateTime.Now,BookingStatus.Cancelled);
            bookList.Add(bookOrder);
            bookList.Add(bookOrder1);
            bookList.Add(bookOrder2);
            bookList.Add(bookOrder3);

            OrderDetails order1 = new OrderDetails(bookOrder.BookID,product2.ProductID,2,80);
            OrderDetails order2 = new OrderDetails(bookOrder.BookID,product2.ProductID,2,100);
            OrderDetails order3 = new OrderDetails(bookOrder.BookID,product2.ProductID,1,40);
            OrderDetails order4 = new OrderDetails(bookOrder.BookID,product2.ProductID,1,40);
            OrderDetails order5 = new OrderDetails(bookOrder.BookID,product2.ProductID,4,200);
            OrderDetails order6 = new OrderDetails(bookOrder.BookID,product2.ProductID,1,140);
            OrderDetails order7 = new OrderDetails(bookOrder.BookID,product2.ProductID,1,20);
            OrderDetails order8 = new OrderDetails(bookOrder.BookID,product2.ProductID,2,100);
            OrderDetails order9 = new OrderDetails(bookOrder.BookID,product2.ProductID,4,100);
            OrderDetails order10 = new OrderDetails(bookOrder.BookID,product2.ProductID,2,80);
            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);
            orderList.Add(order4);
            orderList.Add(order5);
            orderList.Add(order6);
            orderList.Add(order7);
            orderList.Add(order8);
            orderList.Add(order9);
            orderList.Add(order10);


            foreach(CustomerRegistration customerData in customerList)
            {
                System.Console.WriteLine(customerData.CustomerID+" "+customerData.Name+" "+customerData.FatherName+" "+customerData.Gender+" "+customerData.MobileNumber+" "+customerData.MailID+" "+customerData.WalletBalance);
            }

            foreach(ProductDetails productData in productList)
            {
                System.Console.WriteLine(productData.ProductID+" "+productData.ProductName+" "+productData.QuantityAvailable+" "+productData.PricePerQuantity);
            }

            foreach(BookingDetails bookData in bookList)
            {
                System.Console.WriteLine(bookData.BookID+" "+bookData.CustomerID+" "+bookData.TotalPrice+" "+bookData.DateOfBooking.ToString("dd/MM/yyyy")+" "+bookData.BookingStatus);
            }

            foreach(OrderDetails order in orderList)
            {
                System.Console.WriteLine(order.OrderID+" "+order.BookingID+" "+order.ProductID+" "+order.PurchaseCount+" "+order.PriceOfOrder);
            }
        }
    }
}