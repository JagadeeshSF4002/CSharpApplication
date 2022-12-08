using System.Collections.Concurrent;
using System;



namespace CafeteriaCardManagement
{
    public static partial class Operation
    {
        
        /*
        
           1.create do while loop and test the loop , create order object with total amount 0 , status initiated
           2.inside dowhile print the food items list
           3.Ask food ID and validate and also ask count and check count is available
           4.Calculate cart amount and total amount
           5.get food id, food count
           6.Using foreach and if condition check food id is valid, if not show invalid id
           7.If valid id,check count available - yes-count available , no - count is not available
           8.Calculate amount of product - food price * count
           9.add amount to total count
           10.create cart object with available values and add in local cart list
           11.ask do you want to continue if yes proceed adding cart - if no exit loop
           12.after exixting loop - ask do you want to confirm wishlist
           13.if yes - create a recharge flag with false and put a do while to proceed after recharge
           14. Inside do while check the user has enough balance by checking wallet amount with total amount
           15. if he has enough balance deduct the amount , order ovject status to ordered, order amount to total amount. add order object to list.
           16.using add range add the local cart list to global cart details , show order successfull.
           17.if he doesn't have enough balance ask the user to proceed with recharging with total amount
           18.ask whether he want to recharge or not , if yes finish recharge and using do - while go to step 14.
           19.if he doesn't want to recharge then show existing without purchase and return local cart detail food quantity to food list 
           20.in the step 12 if he dont want to confirm wish list then return local cart detail food quantity to food list
        
        */
        private static void FoodOrders()
        {
            string choice = "";
            long totalAmount = 0;
            List<CartItem> localCartItems = new List<CartItem>();
            OrderDetails order = new OrderDetails(currentUser.UserID,DateTime.Now,0,OrderStatus.Initiated);
           
            System.Console.WriteLine("     Food order     ");
            do
            {
                foreach(FoodDetails food in foodList)
                {
                    System.Console.WriteLine($"{food.FoodID} {food.FoodName} {food.FoodPrice} {food.AvailableQuantity}");
                }
                
                System.Console.WriteLine("Enter te food ID :");
                string foodID = Console.ReadLine().ToUpper();

                currentFood  = IsValidFoodID(foodID);

                if(currentFood != null)
                {
                    System.Console.WriteLine("*************Food ID Available****************");
                    
                    System.Console.WriteLine("How much do you want ?");
                    int count = int.Parse(Console.ReadLine());

                   
                        if(currentFood.AvailableQuantity >= count)
                        {
                            System.Console.WriteLine("******count is available******");
                            currentFood.AvailableQuantity -= count;

                            long amount = count * currentFood.FoodPrice;
                            totalAmount = totalAmount + amount;


                            CartItem cart = new CartItem(order.OrderID,foodID,amount,count);
                            localCartItems.Add(cart);
                            orderList.Add(order);
                            cartList.AddRange(localCartItems);
       
                        }
                        else
                        {
                            System.Console.WriteLine("*****Not available*******");

                        }
                    
                }
                else
                {
                    System.Console.WriteLine("*****************Not Available****************");
                }

                System.Console.WriteLine("Do you want to continue to purchase : say yes or no");
                choice = Console.ReadLine().ToLower();
                
            }while(choice == "yes");

            System.Console.WriteLine("Do you want to confirm your order ? say yes or no");
            string option = Console.ReadLine().ToLower();
            bool flag = false;
            if(option == "yes")
            {
                do
                {
                    if(totalAmount <= currentUser.WalletBalance)
                    {
                        currentUser.DeductAmount(totalAmount);
                        order.TotalPrice = totalAmount;
                        order.OrderStatus = OrderStatus.Ordered;
                        System.Console.WriteLine($"*********Ordered Confirmed Succesfully ,your order id is {order.OrderID}*******************");
                        flag = true;
                    }
                    else
                    {
                        System.Console.WriteLine($" Insufficient balance Recharge {totalAmount}");
                        System.Console.WriteLine("Do you want to continue to recharge ?");
                        choice = Console.ReadLine().ToLower();
                        if(choice == "yes")
                        {
                            currentUser.WalletRecharge(totalAmount);
                        }
                        else
                        {
                            System.Console.WriteLine("Exiciting without recharge");
                            flag = true;
                        }               
                    }
                }while(!flag);
            }
            else
            {
                foreach(CartItem cart in localCartItems)
                {
                    foreach(FoodDetails food in foodList)
                    {
                        if(food.FoodID == cart.FoodID)
                        {
                            food.AvailableQuantity = food.AvailableQuantity + cart.OrderQuantity;
                            System.Console.WriteLine("**************Returned in shop****************");
                        }
                    }
                }
            }
            

        }


















        private static void FoodOrder()
        {
            List<CartItem> localCartList = new List<CartItem>();
            System.Console.WriteLine("     Food order     ");
            foreach(FoodDetails food in foodList)
            {
                System.Console.WriteLine($"{food.FoodID} {food.FoodName} {food.FoodPrice} {food.AvailableQuantity}");
            }

            OrderDetails order = new OrderDetails(currentUser.UserID,DateTime.Now,0,OrderStatus.Initiated);
            long totalPrice = 0;
            string choice = "";
            do
            {
                System.Console.WriteLine("Enter the food ID :");
                string foodID = Console.ReadLine().ToUpper();
                
                currentFood = IsValidFoodID(foodID);

                if(currentFood != null)
                {
                    System.Console.WriteLine("How much do you want ?");
                    int quantity = int.Parse(Console.ReadLine());
                    totalPrice = 0;
                    
                    if(currentFood.AvailableQuantity >= quantity)
                    {
                        totalPrice += currentFood.CalculatePrice(quantity,currentFood.FoodPrice);

                        foreach(FoodDetails food in foodList)
                        {
                            if(food.FoodID == foodID)
                            {
                                food.AvailableQuantity= food.AvailableQuantity-quantity;
                                CartItem cart = new CartItem(order.OrderID,foodID,totalPrice,quantity);
                                localCartList.Add(cart);
                                break;
                            }
                        }
                        
                        System.Console.WriteLine("Do you want another product : say yes or no");
                        choice = Console.ReadLine();
                            
                    }
                    else
                    {
                        System.Console.WriteLine("****************Out of stock*******************");
                    }
                }
                else
                {
                    System.Console.WriteLine("****************Invalid Food ID*********************");
                }
            }while(choice == "yes");

            System.Console.WriteLine("if you want to confirm order say yes otherwise say no");
            string confirmOrder = Console.ReadLine();
            
            if(confirmOrder == "yes")
            {
                recharged:
                if(currentUser.WalletBalance >= totalPrice)
                {
                    currentUser.DeductAmount(totalPrice);
                    cartList.AddRange(localCartList);
                    order.OrderStatus = OrderStatus.Ordered;
                    order.TotalPrice = totalPrice;
                    orderList.Add(order);
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine($"Ordered Placed succesfully and OrderID is {order.OrderID}");
                    System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                }
                else
                {
                    System.Console.WriteLine("*************Insufficient Balance to purchase*******************");
                    System.Console.WriteLine("Are you willing to recharge ? ");
                    string status = Console.ReadLine();
                    

                    if(status == "yes")
                    {
                        System.Console.WriteLine($"Recharge amount to be {totalPrice}");
                        long amount = long.Parse(Console.ReadLine());
                        currentUser.WalletRecharge(amount);
                        goto recharged;
                    }
                    else
                    {
                        System.Console.WriteLine("Existing without order due to insufficient balance");
                    }

                }
            }
            else
            {
                foreach(CartItem cart in localCartList)
                {
                    foreach(FoodDetails food in foodList)
                    {
                        if(food.FoodID == cart.FoodID)
                        {
                            food.AvailableQuantity += cart.OrderQuantity;
                        }
                    }
                    localCartList.Remove(cart);       
                }
                
            }
        
        }

        private static FoodDetails IsValidFoodID(string foodID)
        {
            foreach(FoodDetails data in foodList)
            {
                if(data.FoodID == foodID)
                {
                    return data;
                }
            }
            return null;
        }
   
    }
}