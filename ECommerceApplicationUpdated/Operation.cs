using System;
using System.Collections.Generic; 

namespace ECommerceApplication
{
    
    public static class Operation
    {
        static List<CustomerDetails> customerList = new List<CustomerDetails>();
        static List<ProductDetails> productList = new List<ProductDetails>();
        private static List<OrderDetails> orderList = new List<OrderDetails>();  

        static CustomerDetails currentCustomer;
        static ProductDetails currentProduct;

        public static void DisplayMainMenu()
        {
            int option;
            do
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("<            E-Commerce           >");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                System.Console.WriteLine();
                System.Console.WriteLine("1.Customer Registration");
                System.Console.WriteLine("2.Login Purchace");
                System.Console.WriteLine("3.Exit");

                System.Console.WriteLine("Enter the option ");
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                CustomerRegistration();
                                break;
                            }
                    case 2:
                            {
                                LoginPurchase();
                                break;
                            }
                    case 3:
                            {
                                System.Environment.Exit(0);
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("Invalid option");
                                break;
                            }
                   }
              }while(option != 3);
        }

        private static void LoginPurchase()
        {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("                LOGIN           ");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine();
                System.Console.WriteLine("Enter your Customer ID :");
                string id = Console.ReadLine().ToUpper();

                bool checker = ValidateCustomer(id);//validate method used for validate the customer id and returns status

                if(checker)
                {
                    SubMenu();
                }
                else
                {
                    System.Console.WriteLine("Invalid Customer ID");
                }
        }

        private static bool ValidateCustomer(string customerID)
        {
            foreach(CustomerDetails customer in customerList)
            {
                if(customer.CustomerID == customerID)
                {
                    currentCustomer = customer;
                    return true;
                }
            }
            return false;
        }

        private static void SubMenu()
        {
                char option = '\0';
            do
            {        
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("<            Main Menu           >");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                System.Console.WriteLine();
                System.Console.WriteLine("a.Purchase");
                System.Console.WriteLine("b.Order History");
                System.Console.WriteLine("c.Cancel Order");
                System.Console.WriteLine("d.Wallet Balance");
                System.Console.WriteLine("e.Exit");
                System.Console.WriteLine("Enter the option :");
                option = char.Parse(Console.ReadLine());
                switch(option)
                {
                    case 'a':
                            {
                                Purchase();  
                                break;
                            }
                    case 'b':
                            {
                                OrderHistory();
                                break;
                            }
                    case 'c':
                            {
                                CancelOrder();
                                break;
                            }
                    case 'd':
                            {
                                WalletBalance();
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

        private static void WalletBalance()
        {
                string choices = "";
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("Wallat Balance of customer");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine();
    
                System.Console.WriteLine($"Wallet Available Balance is {currentCustomer.WalletBalance}");
                System.Console.WriteLine("Do you want to recharge? say {yes / no}");
                choices = Console.ReadLine();
                        
                if(choices == "yes")
                {
                    System.Console.WriteLine("Enter the amount to be recharge ");
                    long amount = long.Parse(Console.ReadLine());
                    
                    currentCustomer.WalletRecharge(amount);
                    
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine($"The current balance After recharge is {currentCustomer.WalletBalance}");
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                }
        }
        private static void CancelOrder()
        {
            OrderHistory();   
            System.Console.WriteLine("Enter OrderID for cancel order :");
            string orderID = Console.ReadLine().ToUpper();

            foreach(OrderDetails order in orderList)
            {
                if(orderID == order.OrderID)
                {
                    currentProduct.Stock = currentProduct.Stock + order.Quantity;
                    currentCustomer.WalletBalance = currentCustomer.WalletBalance+order.TotalPrice;
                    order.Status = OrderStatus.Cancelled;
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine("     Your order is cancelled successfully ");
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                }
            }
        }

        private static void OrderHistory()
        {
                string line ="+---------------------------------------------------------------------------------------------------+";
                System.Console.WriteLine(line);
                System.Console.WriteLine("| Order ID     | Customer ID  | ProductID    | TotalPrice    |PurchaseDate   |QuantityPurchase  |OrderStatus");
                System.Console.WriteLine(line);
                foreach(OrderDetails orderData in orderList)
                {
                    if(currentCustomer.CustomerID == orderData.CustomerID)
                    {
                        System.Console.WriteLine($"{orderData.OrderID.PadRight(15)}{orderData.CustomerID.PadRight(14)} |{orderData.ProductID.PadRight(14)} |{(""+orderData.TotalPrice).PadRight(15)} |{(""+orderData.PurchaseDate.ToString("dd/MM/yyyy")).PadRight(15)}|{(""+orderData.Quantity).PadRight(15)}|{(""+orderData.Status).PadRight(15)}");
                    }
                }
                System.Console.WriteLine(line);
        }

        private static void Purchase()
        {
             bool orderPlaced = false;
             double totalAmount = 0;

             System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
             System.Console.WriteLine("        Purchase the product      ");
             System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
             System.Console.WriteLine();
             foreach(ProductDetails productData in productList)
             {
                System.Console.WriteLine($"{productData.ProductID}       |{productData.ProductName}          |{productData.Stock}              |{productData.Price}        |{productData.ShippingDuration}");
             }

             System.Console.WriteLine("Enter product ID");
             string productID = Console.ReadLine().ToUpper();
             foreach(ProductDetails product in productList)
                {
                    
                    if(product.ProductID == productID)
                    {
                        currentProduct = product;
                        System.Console.WriteLine("How many products do you want?");
                        int count = int.Parse(Console.ReadLine());

                        if(product.Stock < count)
                        {
                            System.Console.WriteLine($"Required count not available.Current availabilty is {product.Stock}");
                        }
                        else
                        {
                            int deliveryCharge = 50;

                            totalAmount = (count*product.Price) + deliveryCharge; // total amount to pay bill

                            long availableBalance = currentCustomer.WalletBalance;
                            
                            if(availableBalance >= totalAmount && availableBalance != 0)
                            {
                                long deductedAmount = (long)(availableBalance - totalAmount);
                                
                                currentCustomer.WalletBalance = currentCustomer.WalletBalance-deductedAmount;      //UpdateCustomerDetails used for deduct the amount from wallet by using customer id
                                 //UpdateProductDetails used for reduct the stocks from syock by using product id
                                product.Stock = product.Stock - count;                                
                                //getProductDuration used for get delivery days
                                int duration = product.ShippingDuration;

                                OrderDetails order = new OrderDetails(currentCustomer.CustomerID,product.ProductID,(long)totalAmount,DateTime.Now,count,OrderStatus.Ordered); 
                                
                                //order details store into the OrderList
                                orderList.Add(order);

                                System.Console.WriteLine("Your Order ID is "+order.OrderID);
                                
                                System.Console.WriteLine("**********************************************************************************************************");
                                System.Console.WriteLine($"Order placed successfully. Your order will be delivered on {DateTime.Now.AddDays(duration).ToString("dd/MM/yyyy")}");
                                System.Console.WriteLine("**********************************************************************************************************");   
                                
                            }
                            else
                            {
                                System.Console.WriteLine("Insufficient wallet balance please recharge your wallet");
                               
                            }
                            orderPlaced = true;
                        }
                    }
                }
                if(!orderPlaced)
                {
                    System.Console.WriteLine("Invalid product ID");
                }

        }

        private static void CustomerRegistration()
        {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("<       Customer Registration     >");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                System.Console.WriteLine();
                
                System.Console.WriteLine("Enter your name :");
                string name = Console.ReadLine();
                
                System.Console.WriteLine("Enter your city :");
                string city = Console.ReadLine();
                
                System.Console.WriteLine("Enter your phone number :");
                ulong phoneNumber = Convert.ToUInt64(Console.ReadLine());

                System.Console.WriteLine("Enter your mail ID");
                string emailID = Console.ReadLine();

                System.Console.WriteLine("Initial Balance");
                long balance = long.Parse(Console.ReadLine());
                
                //Update the value in customer details class
                CustomerDetails customer = new CustomerDetails(name,city,phoneNumber,balance,emailID);
                
                //Add the details in customer list
                customerList.Add(customer); 
                customer.WalletRecharge(balance);
                System.Console.WriteLine($"Your ID is {customer.CustomerID}");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("Registration successfull");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        }

        public static void DefaultData()
        {
              //initialy i have declared 2 customers default
            CustomerDetails Defaultcustomer1 = new CustomerDetails("Ravi","chennai",9876543210,50000,"ravi@gmail.com");
            CustomerDetails Defaultcustomer2 = new CustomerDetails("Bhaskaran","chennai",9876743210,60000,"bhaskaran@gmail.com");
            customerList.Add(Defaultcustomer1);
            customerList.Add(Defaultcustomer2);     
            
            //purchase date calculation
            DateTime dat = DateTime.Now;
            
            OrderDetails DefaultOrder1 = new OrderDetails(Defaultcustomer1.CustomerID,"PID101",20000,dat,2,OrderStatus.Ordered);
            OrderDetails DefaultOrder2 = new OrderDetails(Defaultcustomer2.CustomerID,"PID103",40000,dat,2,OrderStatus.Ordered);

            orderList.Add(DefaultOrder1);
            orderList.Add(DefaultOrder2);
          
            ProductDetails DefaultProduct1 = new ProductDetails("Mobile",10,10000,3);
            ProductDetails DefaultProduct2 = new ProductDetails("Tablet",5,15000,2);
            ProductDetails DefaultProduct3 = new ProductDetails("Camera",3,20000,4);
            ProductDetails DefaultProduct4 = new ProductDetails("iphone",5,50000,6);
            ProductDetails DefaultProduct5 = new ProductDetails("Laptop",3,40000,3);

            productList.Add(DefaultProduct1);
            productList.Add(DefaultProduct2);
            productList.Add(DefaultProduct3);
            productList.Add(DefaultProduct4);
            productList.Add(DefaultProduct5);    
        }
    }
}