using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public partial class Operation
    {
        private static void CancelOrder()
        {
            foreach(OrderDetails order in orderList)
            {
                if(order.UserID == currentUser.UserID && order.OrderStatus == OrderStatus.Ordered)
                {
                    System.Console.WriteLine(order.OrderID+" "+order.UserID+" "+order.TotalPrice+" "+order.OrderDate+" "+order.OrderStatus);
                }
            }

            System.Console.WriteLine("Enter the Order ID :");
            string orderID = Console.ReadLine().ToUpper();

            currentOrder = IsValidOrderID(orderID);

            if(currentOrder != null)
            {
                foreach(CartItem cart in cartList)
                {
                    if(cart.OrderID == currentOrder.OrderID)
                    {
                        foreach(FoodDetails food in foodList)
                        {
                            if(food.FoodID == cart.FoodID)
                            {
                                food.AvailableQuantity = food.AvailableQuantity + cart.OrderQuantity;
                                System.Console.WriteLine($"*********{food.FoodName} Returned successfully***********");
                            }
                        }
                        currentUser.WalletRecharge(currentOrder.TotalPrice);
                        currentOrder.OrderStatus = OrderStatus.Cancelled;
                        System.Console.WriteLine($"*************{currentOrder.OrderID}  Order cancelled Successfully*****************");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("*******************Invalid ID****************");
            }
        }

        private static OrderDetails IsValidOrderID(string orderID)
        {
            foreach(OrderDetails data in orderList)
            {
                if(data.OrderID == orderID && data.OrderStatus == OrderStatus.Ordered) 
                {
                    return data;
                }
            }
            return null;
        }
    }
}