using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public static class Files
    {
        public static void Create()
        {
            if(!Directory.Exists("GroceryStory"))
            {
                Directory.CreateDirectory("GroceryStory");
                 System.Console.WriteLine("Folder is created");
            }
            else
            {
                System.Console.WriteLine("Folder Existing");
            }

            if(!File.Exists("GroceryStory/CustomerRegistration.csv"))
            {
                File.Create("GroceryStory/CustomerRegistration.csv");
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("GroceryStory/ProductDetails.csv"))
            {
                File.Create("GroceryStory/ProductDetails.csv");
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("GroceryStory/BookingDetails.csv"))
            {
                File.Create("GroceryStory/BookingDetails.csv");
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("GroceryStory/OrderDetails.csv"))
            {
                File.Create("GroceryStory/OrderDetails.csv");
                System.Console.WriteLine("File created");
            }
        }

        public static void WriteFile()
        {
            string[] customerDetails = new string[Operation.customerList.Count];

            for(int i=0;i<Operation.customerList.Count;i++)
            {
                customerDetails[i] = Operation.customerList[i].CustomerID+","+Operation.customerList[i].Name+","+Operation.customerList[i].FatherName+","+Operation.customerList[i].Gender+","+Operation.customerList[i].MobileNumber+","+Operation.customerList[i].DOB.ToString("dd/MM/yyyy")+","+Operation.customerList[i].MailID+","+Operation.customerList[i].WalletBalance;
            }
            File.WriteAllLines("GroceryStory/CustomerRegistration.csv",customerDetails);

            string[] productDetails = new string[Operation.productList.Count];

            for(int i=0;i<Operation.productList.Count;i++)
            {
                productDetails[i] = Operation.productList[i].ProductID+","+Operation.productList[i].ProductName+","+Operation.productList[i].QuantityAvailable+","+Operation.productList[i].PricePerQuantity;
            }
            File.WriteAllLines("GroceryStory/ProductDetails.csv",productDetails);

            string[] bookingDetails = new string[Operation.bookList.Count];

            for(int i=0;i<Operation.bookList.Count;i++)
            {
                bookingDetails[i] = Operation.bookList[i].BookID+","+Operation.bookList[i].CustomerID+","+Operation.bookList[i].TotalPrice+","+Operation.bookList[i].DateOfBooking.ToString("dd/MM/yyyy")+","+Operation.bookList[i].BookingStatus;
            }
            File.WriteAllLines("GroceryStory/BookingDetails.csv",bookingDetails);

            string[] orderDetails = new string[Operation.orderList.Count];

            for(int i=0;i<Operation.orderList.Count;i++)
            {
                orderDetails[i] = Operation.orderList[i].OrderID+","+Operation.orderList[i].BookingID+","+Operation.orderList[i].ProductID+","+Operation.orderList[i].PurchaseCount+","+Operation.orderList[i].PriceOfOrder;
            }

            File.WriteAllLines("GroceryStory/OrderDetails.csv",orderDetails);
        }

        public static void ReadFile()
        {
            string[] customerDetails = File.ReadAllLines("GroceryStory/CustomerRegistration.csv");

            foreach(string data in customerDetails)
            {
                CustomerRegistration customer = new CustomerRegistration(data);
                Operation.customerList.Add(customer);
            }

            string[] productDetails = File.ReadAllLines("GroceryStory/ProductDetails.csv");

            foreach(string data in productDetails)
            {
                ProductDetails product = new ProductDetails(data);
                Operation.productList.Add(product);
            }

            string[] bookingDetails = File.ReadAllLines("GroceryStory/BookingDetails.csv");

            foreach(string data in bookingDetails)
            {
                BookingDetails bookOrder = new BookingDetails(data);
                Operation.bookList.Add(bookOrder);

            }

            string[] orderDetails = File.ReadAllLines("GroceryStory/OrderDetails.csv");

            foreach(string orderData in orderDetails)
            {
                OrderDetails order = new OrderDetails(orderData);
                Operation.orderList.Add(order);
            }
        }
    }
}