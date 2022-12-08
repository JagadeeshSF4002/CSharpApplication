using System.Net.NetworkInformation;
using System.IO;

namespace ECommerceApplicationWithFile
{
    public class Files
    {
        public static void Create()
        {
            if(!Directory.Exists("ECommerceApplication"))
            {
                Directory.CreateDirectory("ECommerceApplication");
                System.Console.WriteLine("Folder is created");
            }
            else
            {
                System.Console.WriteLine("Folder found");
            }

            if(!File.Exists("ECommerceApplication/CustomerDetails.csv"))
            {
                File.Create("ECommerceApplication/CustomerDetails.csv").Close();
                System.Console.WriteLine("File is created");
            }

            if(!File.Exists("ECommerceApplication/OrderDetails.csv"))
            {
                File.Create("ECommerceApplication/OrderDetails.csv").Close();
                System.Console.WriteLine("File is created");
            }

            if(!File.Exists("ECommerceApplication/ProductDetails.csv"))
            {
                File.Create("ECommerceApplication/ProductDetails.csv").Close();
                System.Console.WriteLine("File is created");
            }
        }

        public static void WriteFiles()
        {
            string[] customerDetails = new string[Operation.customerList.Count];

            for(int i=0;i<Operation.customerList.Count;i++)
            {
                customerDetails[i] = Operation.customerList[i].CustomerID+","+Operation.customerList[i].Name+","+Operation.customerList[i].City+","+Operation.customerList[i].MobileNumber+","+Operation.customerList[i].WalletBalance+","+Operation.customerList[i].EmailID;
            }

            File.WriteAllLines("ECommerceApplication/CustomerDetails.csv",customerDetails);

            string[] productDetails = new string[Operation.productList.Count];

            for(int i=0;i<Operation.productList.Count;i++)
            {
                productDetails[i] = Operation.productList[i].ProductID+","+Operation.productList[i].ProductName+","+Operation.productList[i].Stock+","+Operation.productList[i].Price+","+Operation.productList[i].ShippingDuration;
            }

            File.WriteAllLines("ECommerceApplication/ProductDetails.csv",productDetails);

            string[] orderDetails = new string[Operation.orderList.Count];

            for(int i=0;i<Operation.orderList.Count;i++)
            {
                orderDetails[i] = Operation.orderList[i].OrderID+","+Operation.orderList[i].CustomerID+","+Operation.orderList[i].ProductID+","+Operation.orderList[i].TotalPrice+","+Operation.orderList[i].PurchaseDate.ToString("dd/MM/yyyy")+","+Operation.orderList[i].Quantity+","+Operation.orderList[i].Status;
            }

            File.WriteAllLines("ECommerceApplication/Orderdetails.csv",orderDetails);

        }

        public static void ReadLines()
        {
            string[] customerDetails = File.ReadAllLines("ECommerceApplication/CustomerDetails.csv");

            foreach(string data in customerDetails)
            {
                CustomerDetails cutomer = new CustomerDetails(data);
                Operation.customerList.Add(cutomer);
            }

            string[] productDetails = File.ReadAllLines("ECommerceApplication/ProductDetails.csv");

            foreach(string data in productDetails)
            {
                ProductDetails product = new ProductDetails(data);
                Operation.productList.Add(product);
            }

            string[] orderDetails = File.ReadAllLines("ECommerceApplication/Orderdetails.csv");

            foreach(string data in orderDetails)
            {
                OrderDetails order = new OrderDetails(data);
                Operation.orderList.Add(order);
            }
        }
    }
}