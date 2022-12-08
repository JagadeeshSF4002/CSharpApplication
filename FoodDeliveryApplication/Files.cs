using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public class Files
    {
        public static void Create()
        {
            if(!Directory.Exists("FoodDeliveryCart"))
            {
                Directory.CreateDirectory("FoodDeliveryCart");
                System.Console.WriteLine("Folder created succesfully");
            }

            if(!File.Exists("FoodDeliveryCart/CustomerDetails.csv"))
            {
                File.Create("FoodDeliveryCart/CustomerDetails.csv").Close();
            }

            if(!File.Exists("FoodDeliveryCart/FoodDetails.csv"))
            {
                File.Create("FoodDeliveryCart/FoodDetails.csv").Close();
            }

            if(!File.Exists("FoodDeliveryCart/ItemDetails.csv"))
            {
                File.Create("FoodDeliveryCart/ItemDetails.csv").Close();
            }

            if(!File.Exists("FoodDeliveryCart/OrderDetails.csv"))
            {
                File.Create("FoodDeliveryCart/OrderDetails.csv").Close();
            }

        }
        //Write the data into specified directory
        public static void WriteFiles()
        {
            string[] customerDetails = new string[Operation.customerList.Count];
            int i = 0;
            foreach(CustomerDetails customer in Operation.customerList)
            {
                customerDetails[i] = customer.CustomerID+","+customer.Name+","+customer.FatherName+","+customer.Gender+","+customer.MobileNumber+","+customer.DOB.ToString("dd/MM/yyyy")+","+customer.MailID+","+customer.Location+","+customer.WalletBalance;
                i++;
            }
            File.WriteAllLines("FoodDeliveryCart/CustomerDetails.csv",customerDetails);

            string[] foodDetails = new string[Operation.foodList.Count];
            i=0;
            foreach(FoodDetails food in Operation.foodList)
            {
                foodDetails[i] = food.FoodID+","+food.FoodName+","+food.PricePerQuantity+","+food.QuantityAvailable;
                i++;
            }
            File.WriteAllLines("FoodDeliveryCart/FoodDetails.csv",foodDetails);

            string[] itemDetails = new string[Operation.itemList.Count];
            i=0;
            foreach(ItemDetails item in Operation.itemList)
            {
                itemDetails[i] = item.ItemID+","+item.OrderID+","+item.FoodID+","+item.PurchaseCount+","+item.PriceOfOrder;
                i++;
            }
            File.WriteAllLines("FoodDeliveryCart/ItemDetails.csv",itemDetails);

            string[] orderDetails = new string[Operation.orderList.Count];
            i=0;
            foreach(OrderDetails order in Operation.orderList)
            {
                orderDetails[i] = order.OrderID+","+order.CustomerID+","+order.TotalPrice+","+order.DateOfOrder.ToString("dd/MM/yyyy")+","+order.OrderStatus;
                i++;
            }
            File.WriteAllLines("FoodDeliveryCart/OrderDetails.csv",orderDetails);

        }

        public static void ReadFiles()
        {
            string[] customerDetails = File.ReadAllLines("FoodDeliveryCart/CustomerDetails.csv");

            foreach(string customerData in customerDetails)
            {
                CustomerDetails customer = new CustomerDetails(customerData);
                Operation.customerList.Add(customer);
            }

            string[] foodDetails = File.ReadAllLines("FoodDeliveryCart/FoodDetails.csv");

            foreach(string food in foodDetails)
            {
                FoodDetails food1 = new FoodDetails(food);
                Operation.foodList.Add(food1);
            }

            string[] itemDetails = File.ReadAllLines("FoodDeliveryCart/ItemDetails.csv");

            foreach(string items in itemDetails)
            {
                ItemDetails item = new ItemDetails(items);
                Operation.itemList.Add(item);
            }

            string[] orderDetails = File.ReadAllLines("FoodDeliveryCart/OrderDetails.csv");

            foreach(string order in orderDetails)
            {
                OrderDetails orders = new OrderDetails(order);
                Operation.orderList.Add(orders);
            }
        }
    }
}