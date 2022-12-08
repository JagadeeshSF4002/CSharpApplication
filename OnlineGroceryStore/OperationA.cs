using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public static partial class Operation
    {
        public static void TakeOrder()
        {
            string option = "";
            long totalAmount = 0;
            List<OrderDetails> localOrderList = new List<OrderDetails>();
            // List<BookingDetails> localOrderList = new List<BookingDetails>(); 
            BookingDetails booking = new BookingDetails(currentUser.CustomerID,0,DateTime.Now,BookingStatus.Initiated);
                
            System.Console.WriteLine("Do you want to purchase or not ? Say yes or no ");
            string purchase = Console.ReadLine().ToLower();
            do
            {
                // localOrderList.Add(booking);

                foreach(ProductDetails productData in productList)
                {
                    System.Console.WriteLine(productData.ProductID+" "+productData.ProductName+" "+productData.QuantityAvailable+" "+productData.PricePerQuantity);
                }
                System.Console.WriteLine();
                System.Console.WriteLine("Enter the product ID :");
                string productID = Console.ReadLine().ToUpper();
                
                currentProduct = ValidateProductID(productID);

                if(currentProduct != null)
                {
                    System.Console.WriteLine("How much do you want :");
                    int quantity = int.Parse(Console.ReadLine());
                    if(currentProduct.QuantityAvailable <= quantity)
                    {
                        long totalPrice = quantity * currentProduct.PricePerQuantity;
                        totalAmount = totalAmount + totalPrice;
                        
                        OrderDetails order = new OrderDetails(booking.BookID,productID,quantity,totalPrice);
                        localOrderList.Add(order);

                        foreach(ProductDetails productData in productList)
                        {
                            if(productData.ProductID == productID)
                            {
                                productData.QuantityAvailable = productData.QuantityAvailable-quantity;
                                System.Console.WriteLine("Deducted from stock");
                            }
                        }

                        System.Console.WriteLine("Product Successfully added to the stock ");
                    }
                }
                else
                {
                    System.Console.WriteLine("************Invalid ID*******************");
                }
                
                System.Console.WriteLine("Do you want to another product : ");
                option = Console.ReadLine();
            }while(option == "yes");
        
            System.Console.WriteLine("Do you wish to confirm the order ? say yes or no ");
            option = Console.ReadLine();
            bool flag = false;
            if(option == "yes")
            {
                do
                {
                    if(currentUser.WalletBalance >= totalAmount)
                    {
                        currentUser.DeductAmount(totalAmount);
                        booking.BookingStatus = BookingStatus.Booked;
                        booking.TotalPrice = totalAmount;
                        orderList.AddRange(localOrderList);
                        System.Console.WriteLine("********************Booking Succesfull***********************");
                        flag = true;
                    }
                    else
                    {
                        System.Console.WriteLine("**************InSufficient Balance*********************");
                        System.Console.WriteLine($"Recharge the amount {totalAmount}");
                        long amount = long.Parse(Console.ReadLine());

                        currentUser.WalletRecharge(amount);
                    }
                }while(!flag);
            }
            else
            {
                foreach(OrderDetails order in localOrderList)
                {
                    foreach(ProductDetails product in productList)
                    {
                        if(product.ProductID == order.ProductID)
                        {
                            product.QuantityAvailable = product.QuantityAvailable + order.PurchaseCount;
                            localOrderList.Remove(order);
                        }
                    }
                }
                System.Console.WriteLine("***************Removed Successfully**************");
            }
            
        }

        private static ProductDetails ValidateProductID(string productID)
        {
           foreach(ProductDetails product in productList)
           {
                if(product.ProductID == productID)
                {
                    return product;
                }
           }
            return null;
        }
    }
}