using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public static partial class Operation
    {
        static FoodDetails currentFood;
        /*
        a.	Create OrderDetails object
        b.	Create localItemList 
        c.	Show all the list of food items 
        d.	Ask the FoodID, order quantity from user and check whether it is available. If not show FoodID Invalid or FoodQuantity 
        e.	If it is available then, create ItemDetails object 
        f.	Ask the user whether he want to order more. If “Yes” means again show food details and repeat from step “c” to create new ItemDetails object. Repeat this process until he says “No”.
        g.	If user select “No” then show “Do you want to confirm purchase.” If he says “No” return the localItemList of items count back to FoodDetails list.
        j.	If he has balance then, modify OrderDetails object which was created at beginning with TotalPrice and OrderStatus to “Ordered”. Deduct the total amount from user’s wallet balance. Add the localItemList to ItemList. 
        k.	If the balance is insufficient, inform the customer that the wallet has insufficient balance and whether wish to recharge /not.
        l.	If he says “No” return the localItemList item’s count to FoodList.
        m.	If “Yes” ask for the amount to be recharged. Show the balance after recharge and goto step “i” to proceed purchase again.

        */
        private static void OrderFood()
        {
            bool status = false;
            int orderQuantity = 0;
            double totalAmount = 0;
            string option = "";
            OrderDetails order = new OrderDetails(currentCustomer.CustomerID,0,DateTime.Now,OrderStatus.Initiated);
            List<ItemDetails> localItemList = new List<ItemDetails>();
            string line = "+----------------------------------------------------------------------------+";
            do
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine("| FoodID   | Food Name             | Price Per Quantity  | Quantity Available|");
                System.Console.WriteLine(line);
                foreach(FoodDetails food in foodList)
                {
                    System.Console.WriteLine($"|{food.FoodID.PadRight(9)} |{food.FoodName.PadRight(22)} |{(""+food.PricePerQuantity).PadRight(19)} |{(""+food.QuantityAvailable).PadRight(20)}|");
                }
                System.Console.WriteLine(line);
                System.Console.WriteLine();

                System.Console.WriteLine("Enter the Food ID :");
                string foodID = Console.ReadLine().ToUpper();
                
                currentFood = ValidateFoodID(foodID); // validate the food id is present or not if it is it returns current object

                if(currentFood != null)
                {
                    do
                    {
                        System.Console.WriteLine("How much do you want ?");
                        status = int.TryParse(Console.ReadLine(),out orderQuantity);
                        if(!status)
                        {
                            System.Console.WriteLine("Invalid say digit format");
                        }
                    }while(!status);

                    if(currentFood.QuantityAvailable >= orderQuantity) //Check the quantity is available or not 
                    {
                        double amount = orderQuantity * currentFood.PricePerQuantity; // Calculate the total amount
                        totalAmount = totalAmount + amount; //Overall amount
                    
                        ItemDetails item = new ItemDetails(order.OrderID,currentFood.FoodID,orderQuantity,amount);//stores into the item list

                        DeductFoodQuantity(orderQuantity,currentFood);//deduct the quantity
                        
                        localItemList.Add(item);//temporary storage
                    }
                    else
                    {
                        System.Console.WriteLine($"{currentFood.FoodID} not available");
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid Food ID ");
                }

                System.Console.WriteLine("Do you want one more item ? say yes or no ");
                option = Console.ReadLine();

            }while(option == "yes");

            System.Console.WriteLine("Do you want to confirm purchase ? say yes or no");
            option = Console.ReadLine();
            
            if(option == "yes")
            {
                sufficient:

                if(currentCustomer.WalletBalance >= totalAmount)//check current logged in user wallet balance
                {
                    order.TotalPrice = totalAmount;     // update the amount
                    order.OrderStatus = OrderStatus.Ordered;// update the status
                    currentCustomer.DeductBalance(totalAmount);//deduct the balance
                    itemList.AddRange(localItemList);//store into item list
                    orderList.Add(order);//store into order list
                    
                    System.Console.WriteLine(line);
                    System.Console.WriteLine($"Your Order placed succesfully , your Order ID is {order.OrderID}");
                }
                else
                {
                    System.Console.WriteLine("***********Your Balance is insufficient*****************");
                    System.Console.WriteLine("Do you want to recharge ? say yes or no ");
                    option = Console.ReadLine();
                    double amount = 0;
                    if(option == "yes")
                    {
                        do
                        {
                            System.Console.WriteLine($"Enter the amount to be recharged  with {totalAmount}:");
                            status = double.TryParse(Console.ReadLine(),out amount);
                            if(!status)
                            {
                                System.Console.WriteLine("Invalid Enter Digit Format");
                            }
                        }while(!status);

                        currentCustomer.WalletRecharge(amount);
                        System.Console.WriteLine("*****************Recharged Succesfully****************");
                        System.Console.WriteLine($"Current Balance After recharge {currentCustomer.WalletBalance}");  
                        goto sufficient; 
                    }
                    else
                    {
                        foreach(ItemDetails item in localItemList)
                        {
                            foreach(FoodDetails food in foodList)
                            {
                                if(food.FoodID == item.FoodID)
                                {
                                    food.QuantityAvailable = food.QuantityAvailable + item.PurchaseCount; //Add the item to stock
                                    System.Console.WriteLine(line);
                                    System.Console.WriteLine($"{food.FoodID}Food returned to the food cart");
                                    System.Console.WriteLine(line);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach(ItemDetails item in localItemList)
                {
                    foreach(FoodDetails food in foodList)
                    {
                        if(food.FoodID == item.FoodID)
                        {
                            food.QuantityAvailable = food.QuantityAvailable + item.PurchaseCount;
                            System.Console.WriteLine(line);
                            System.Console.WriteLine($"{food.FoodID} returned to the food cart");
                            System.Console.WriteLine(line);
                        }
                    }
                }
            }
            


        }

        //DeductFoodQuantity used for reduce the stock in foodlist
        private static void DeductFoodQuantity(int orderQuantity, FoodDetails currentFood)
        {
            foreach(FoodDetails food in foodList)
            {
                if(food.FoodID == currentFood.FoodID)
                {
                    food.QuantityAvailable = food.QuantityAvailable - orderQuantity;//Deduct the quantity in stock
                }
            }
        }
       // ValidateFoodID method used for validate the food id returns object
        private static FoodDetails ValidateFoodID(string foodID)
        {
            foreach(FoodDetails food in foodList)
            {
                if(food.FoodID == foodID)
                {
                    return food;
                }
            }
            return null;
        }
    }
}