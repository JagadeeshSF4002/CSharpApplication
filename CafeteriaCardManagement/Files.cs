
using System.IO;


namespace CafeteriaCardManagement
{
    public class Files
    {
        public static void Create()
        {
            if(!Directory.Exists("CafeteriaCard"))
            {
                Directory.CreateDirectory("CafeteriaCard");
                System.Console.WriteLine("Folder created");
            }
            else
            {
                System.Console.WriteLine("Already Exists");
            }

            if(!File.Exists("CafeteriaCard/UserDetails.csv"))
            {
                File.Create("CafeteriaCard/UserDetails.csv");
                System.Console.WriteLine("User File is created succesfully");   
            }
            if(!File.Exists("CafeteriaCard/FoodDetails.csv"))
            {
                File.Create("CafeteriaCard/FoodDetails.csv");
                System.Console.WriteLine("Food File is created succesfully");   
            }
            if(!File.Exists("CafeteriaCard/OrderDetails.csv"))
            {
                File.Create("CafeteriaCard/OrderDetails.csv");
                System.Console.WriteLine("Order File is created succesfully");   
            }
            if(!File.Exists("CafeteriaCard/CartItems.csv"))
            {
                File.Create("CafeteriaCard/CartItems.csv");
                System.Console.WriteLine("Order File is created succesfully");   
            }
        }

        public static void WriteFiles()
        {
            string[] userDetails = new string[Operation.userList.Count];

            for(int i=0;i<Operation.userList.Count;i++)
            {
                userDetails[i] = Operation.userList[i].UserID+","+Operation.userList[i].Name+","+Operation.userList[i].FatherName+","+Operation.userList[i].Gender+","+Operation.userList[i].MobileNumber+","+Operation.userList[i].MailID+","+Operation.userList[i].WorkStationNumber+","+Operation.userList[i].WalletBalance;
            }
            File.WriteAllLines("CafeteriaCard/UserDetails.csv",userDetails);

            string[] foodDetails = new string[Operation.foodList.Count];

            for(int i=0;i<Operation.foodList.Count;i++)
            {
                foodDetails[i] = Operation.foodList[i].FoodID+","+Operation.foodList[i].FoodName+","+Operation.foodList[i].FoodPrice+","+Operation.foodList[i].AvailableQuantity;
            }

            File.WriteAllLines("CafeteriaCard/FoodDetails.csv",foodDetails);
            
            string[] orderDetails = new string[Operation.orderList.Count];

            for(int i=0;i<Operation.orderList.Count;i++)
            {
                orderDetails[i] = Operation.orderList[i].OrderID+","+ Operation.orderList[i].UserID+","+ Operation.orderList[i].OrderDate.ToString("dd/MM/yyyy")+","+ Operation.orderList[i].TotalPrice+","+ Operation.orderList[i].OrderStatus;
            }
            File.WriteAllLines("CafeteriaCard/OrderDetails.csv",orderDetails);

            string[] cartItems = new string[Operation.cartList.Count];

            for(int i=0;i<Operation.cartList.Count;i++)
            {
                cartItems[i] = Operation.cartList[i].ItemID+","+Operation.cartList[i].OrderID+","+Operation.cartList[i].FoodID+","+Operation.cartList[i].OrderPrice+","+Operation.cartList[i].OrderQuantity;
            }
            File.WriteAllLines("CafeteriaCard/CartItems.csv",cartItems);
        }

        public static void ReadLines()
        {
            string[] userDetails = File.ReadAllLines("CafeteriaCard/UserDetails.csv");

            foreach(string data in userDetails)
            {
                UserDetails userData = new UserDetails(data);
                Operation.userList.Add(userData);
            }

            string[] foodDetails = File.ReadAllLines("CafeteriaCard/FoodDetails.csv");

            foreach(string data in foodDetails)
            {
                FoodDetails foodData = new FoodDetails(data);
                Operation.foodList.Add(foodData);
            }

            string[] orderDetails = File.ReadAllLines("CafeteriaCard/OrderDetails.csv");

            foreach(string orderData in orderDetails)
            {
                OrderDetails order = new OrderDetails(orderData);
                Operation.orderList.Add(order);
            }

            string[] cartItems = File.ReadAllLines("CafeteriaCard/CartItems.csv");

            foreach(string cartData in cartItems)
            {
                CartItem cart = new CartItem(cartData);
                Operation.cartList.Add(cart);
            }

            
        } 
    }
}