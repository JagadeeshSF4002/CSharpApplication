using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using System;
namespace ECommerceApplication
{
    class Program
    {
            //Customer details store into customerList
            private static List<CustomerDetails> customerList = new List<CustomerDetails>();
            //Product details store into produectList
            private static List<ProductDetails> productList = new List<ProductDetails>();

            //Once Ordered is confirmed. We have to store the information into orderList
            private static List<OrderDetails> orderList = new List<OrderDetails>();
            
            
        public static void Main(string[] args)
        {
            Default();
             
            DisplayMainMenu();
            /*Main menu is starting of e-commerce application
              It contains 1. registration, 2. Login purchase 3.exit
            */
            void DisplayMainMenu()
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("<            E-Commerce           >");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                System.Console.WriteLine();
                System.Console.WriteLine("1.Customer Registration");
                System.Console.WriteLine("2.Login Purchace");
                System.Console.WriteLine("3.Exit");

                System.Console.WriteLine("Enter the option ");
                int option = int.Parse(Console.ReadLine());

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
            }
            /*Customer Registration method used for collect the information from user and
             store into the list.Once Registration is done show registration
             successful message.*/
            void CustomerRegistration()
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

                System.Console.WriteLine("Registration successfull");
                DisplayMainMenu();
            }

            /*Login purchase used for get the customer id from user and validate 
            the id then show sub menu it contains 
                1. purchase
                2. orderHistory
                3. wallet balance
                4. Exit */
            void LoginPurchase()
            {
                System.Console.WriteLine("Enter your Customer ID :");
                string id = Console.ReadLine().ToUpper();

                bool checker = Validate(id);//validate method used for validate the customer id and returns status

                if(checker)
                {
                    submenu:
                        
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
                    char option = char.Parse(Console.ReadLine());
                    bool select = false;

                    switch(option)
                    {
                        case 'a':
                                {
                                    select = Purchase(id);
                                    if(select)
                                    {
                                        goto submenu;
                                    }
                                    break;
                                }
                        case 'b':
                                {
                                    select = OrderHistory(id);
                                    if(select)
                                    {
                                        goto submenu;
                                    }
                                    break;
                                }
                        case 'c':
                                {
                                    select = CancelOrder(id);
                                    if(select)
                                    {
                                        goto submenu;
                                    }
                                    break;
                                }
                        case 'd':
                                {
                                    select = WalletBalance(id);
                                    if(select)
                                    {
                                        goto submenu;
                                    }
                                    break;
                                }
                        case 'e':
                                {
                                    DisplayMainMenu();
                                    break;
                                }
                        default:
                                {
                                    System.Console.WriteLine("Invalid Option");
                                    break;
                                }
                    }

                }
                else
                {
                    System.Console.WriteLine("Invalid Customer ID");
                }

            }
            //validate customer id
            bool Validate(string id)
            {
                foreach(CustomerDetails customerData in customerList)
                {
                    if(customerData.CustomerID == id)
                    {
                        return true;
                    }
                }
                return false;
            }
            /*purchase method used for list of products in product list.
             *Get product id from user if it is available 
             *then ask how many products then 
             *reduce the item in stocks and 
             *also reduce the item in wallet by using customer id*/
            bool Purchase(string customerID)
            {
               
                
                System.Console.WriteLine("Product ID   |ProductName     |stocks         |Price per Quantity            |shipping Duration");
                System.Console.WriteLine();
                    
                foreach(ProductDetails productData in productList)
                {
                    System.Console.WriteLine($"{productData.ProductID}       |{productData.ProductName}          |{productData.Stock}              |{productData.Price}                         |{productData.ShippingDuration}");
                }

                System.Console.WriteLine("Enter product ID");
                string productID = Console.ReadLine().ToUpper();
                bool flag = true;
                double totalAmount = 0;
                foreach(ProductDetails productData in productList)
                {
                    if(productData.ProductID == productID)
                    {
                        System.Console.WriteLine("How many products do you want?");
                        int count = int.Parse(Console.ReadLine());

                        if(productData.Stock < count)
                        {
                            System.Console.WriteLine($"Required count not available.Current availabilty is {productData.Stock}");
                        }
                        else
                        {
                            int deliveryCharge = 50;

                            totalAmount = (count*productData.Price) + deliveryCharge; // total amount to pay bill

                            long availableBalance = checkBalance(customerID);
                            
                            if(availableBalance >= totalAmount && availableBalance != 0)
                            {
                                long deductedAmount = (long)(availableBalance - totalAmount);
                                
                                //UpdateCustomerDetails used for deduct the amount from wallet by using customer id
                                UpdateCustomerDetails(customerID,deductedAmount); 
                                //UpdateProductDetails used for reduct the stocks from syock by using product id
                                UpdateProductDetails(productID,count);
                                //getProductDuration used for get delivery days
                                int duration = getProductDuration(productID);

                                
                                OrderDetails orderdetails = new OrderDetails(customerID.ToUpper(),productID,(long)totalAmount,DateTime.Now,count,"ordered"); 
                                
                                //order details store into the OrderList
                                orderList.Add(orderdetails);
                                
                                System.Console.WriteLine("**********************************************************************************************************");
                                System.Console.WriteLine($"Order placed successfully. Your order will be delivered on {DateTime.Now.AddDays(duration).ToString("dd/MM/yyyy")}");
                                System.Console.WriteLine("**********************************************************************************************************");   
                                
                            }
                            else
                            {
                                System.Console.WriteLine("Insufficient wallet balance please recharge your wallet");
                            }
                            flag = false;
                        }
                    }
                }
                if(flag)
                {
                    System.Console.WriteLine("Invalid product ID");
                }

                return true;
            }

            long checkBalance(string customerID)
            {
                foreach(CustomerDetails customerData in customerList)
                {
                    if(customerID.ToUpper() == customerData.CustomerID)
                    {
                        return customerData.WalletBalance;
                    }
                }
                return 0;
            }

            void UpdateCustomerDetails(string customerID,long deductedAmount)
            {
                foreach(CustomerDetails customerData in customerList)
                {
                    if(customerID == customerData.CustomerID)
                    {
                        customerData.WalletRecharge(deductedAmount);
                    }
                }   
            }

            void UpdateProductDetails(string productID,int count)
            {
                foreach(ProductDetails productData in productList)
                {
                    if(productID == productData.ProductID)
                    {
                        productData.Stock = productData.Stock - count;
                    }
                }
            }

            int getProductDuration(string productID)
            {
                foreach(ProductDetails productData in productList)
                {
                    if(productID == productData.ProductID)
                    {
                        return productData.ShippingDuration;
                    }
                }
                return 0;
            }

            //get information about orders
            bool OrderHistory(string id)
            {
                System.Console.WriteLine("Order ID     Customer ID   |ProductID          |TotalPrice         |PurchaseDate       |QuantityPurchase    |OrderStatus");
                foreach(OrderDetails orderData in orderList)
                {
                    if(id == orderData.CustomerID)
                    {
                        System.Console.WriteLine($"{orderData.OrderID}      {orderData.CustomerID}       |{orderData.ProductID}             |{orderData.TotalPrice}              |{orderData.PurchaseDate.ToString("dd/MM/yyyy")}         |{orderData.Quantity}                   |{orderData.Status}");
                    }
                }

                return true;
            }

            //If you want to cancel the order ask the order id and cancel the order.Afterwards update the information in orderList
            bool CancelOrder(string id)
            {
                OrderHistory(id);   
                System.Console.WriteLine("Enter OrderID for cancel order :");
                string orderID = Console.ReadLine().ToUpper();

                foreach(OrderDetails orderData in orderList)
                {
                    if(orderID == orderData.OrderID)
                    {
                        UpdateProductStocks(orderData.Quantity,orderData.ProductID);
                        UpdateWallet(orderData.TotalPrice,orderData.CustomerID);
                        orderData.Status = "Cancelled";
                    }
                }
                return true;
            }

            void UpdateProductStocks(int quantity,string productID)
            {
                foreach(ProductDetails productData in productList)
                {
                    if(productID == productData.ProductID)
                    {
                        productData.UpdateProductItem(quantity);
                    }
                }
            }

            void UpdateWallet(long totalPrice,string customerID)
            {   
                foreach(CustomerDetails customer in customerList)
                {
                    if(customer.CustomerID == customerID)
                    {
                        customer.UpdateWallet(totalPrice);
                        System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                        System.Console.WriteLine("Cancelled successfully");
                        System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    }
                }
            }

            //WalletBalance - get the wallet balance and also recharge
            bool WalletBalance(string userID)
            {
                string choices = "";
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("Wallat Balance of customer");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine();
                foreach(CustomerDetails customer in customerList)
                {
                    if(userID == customer.CustomerID)
                    {
                        System.Console.WriteLine($"Wallet Available Balance is {customer.WalletBalance}");
                        System.Console.WriteLine("Do you want to recharge? say {yes / no}");
                        choices = Console.ReadLine();
                        
                        if(choices == "yes")
                        {
                            System.Console.WriteLine("Enter the amount to be recharge ");
                            long amount = long.Parse(Console.ReadLine());
                            customer.WalletRecharge(amount);
                            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            System.Console.WriteLine($"The current balance After recharge is {customer.WalletBalance}");
                            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            
                        }
                    }
                }
                return true;
            }
            

        }

        static void Default()
        {
             //initialy i have declared 2 customers default
            CustomerDetails Defaultcustomer1 = new CustomerDetails("Ravi","chennai",9876543210,50000,"ravi@gmail.com");
            CustomerDetails Defaultcustomer2 = new CustomerDetails("Bhaskaran","chennai",9876743210,60000,"bhaskaran@gmail.com");
            customerList.Add(Defaultcustomer1);
            customerList.Add(Defaultcustomer2);     
            
            //purchase date calculation
            DateTime dat = DateTime.Now;
            
            OrderDetails DefaultOrder1 = new OrderDetails(Defaultcustomer1.CustomerID,"PID101",20000,dat,2,"ordered");
            OrderDetails DefaultOrder2 = new OrderDetails(Defaultcustomer2.CustomerID,"PID103",40000,dat,2,"ordered");

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