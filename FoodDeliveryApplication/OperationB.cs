using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public partial class Operation
    {
        static OrderDetails orderCancellingItem;

        /*
            a.	Show the list of Orders placed by current logged in user whose status is “Ordered”.
            b.	Ask the user to pick a Order id. If Order id is present, then change the Order status to “Cancelled”. Refund the total price amount of current Order to user’s WalletBalance then return the food items of the current Order to FoodList. 

        */
        private static void CancelOrder()
        {
            System.Console.WriteLine(line);
            System.Console.WriteLine($"Ordered details for {currentCustomer.CustomerID}");
            System.Console.WriteLine(line);
            //show the list of orders for current logged user

            string lines = "+-----------------------------------------------------------------------+";
            System.Console.WriteLine(lines);
            System.Console.WriteLine("| OrderID  | CustomerID  | Total Price   | Date Of Order  | OrderStatus |");
            System.Console.WriteLine(lines);
            foreach(OrderDetails order in orderList)
            {
                if(order.CustomerID == currentCustomer.CustomerID && order.OrderStatus == OrderStatus.Ordered)
                {
                    System.Console.WriteLine($"| {order.OrderID.PadRight(9)}| {order.CustomerID.PadRight(12)}| {(""+order.TotalPrice).PadRight(14)}| {(""+order.DateOfOrder.ToString("dd/MM/yyyy")).PadRight(15)}| {(""+order.OrderStatus).PadRight(12)}|");
                }
            }
            System.Console.WriteLine(lines);

            System.Console.WriteLine("Enter the Order ID :");
            string orderID = Console.ReadLine().ToUpper();//get the ID and validate the ID

            orderCancellingItem =ValidateOrderID(orderID);

            if(orderCancellingItem != null)
            {
                orderCancellingItem.OrderStatus = OrderStatus.Cancelled; //Update the status
                System.Console.WriteLine(line);
                System.Console.WriteLine("Ordered Item cancelled Succesfully ");
                System.Console.WriteLine(line);
                currentCustomer.WalletRecharge(orderCancellingItem.TotalPrice);//Update the balance

                System.Console.WriteLine($"*************Customer of {currentCustomer.CustomerID} Amount refunded succesfully**********");

                foreach(ItemDetails item in itemList)
                {
                    if(item.OrderID == orderCancellingItem.OrderID)
                    {
                        foreach(FoodDetails food in foodList)
                        {
                            if(food.FoodID == item.FoodID)
                            {
                                food.QuantityAvailable = food.QuantityAvailable + item.PurchaseCount;
                                System.Console.WriteLine($"{food.FoodID} returned to food cart succesfully");//Returned the food to food cart
                            }
                        }
                    }
                }
            }
            else
            {
                System.Console.WriteLine("*****************Invalid Order ID***************");
            }
        }
        //If the orderID is matched for order details it returns object otherwise it returns null
        private static OrderDetails ValidateOrderID(string orderID)
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
    }
}