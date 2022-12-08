using System;
using System.Collections.Generic;
namespace EB_Bill_Calculation
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<EBRegistration> userList = new List<EBRegistration>();
            string choice = "";
            bool flag = true;
            System.Console.WriteLine("**********************************************");
            System.Console.WriteLine("*************EB Bill Calculation**************");
            System.Console.WriteLine("**********************************************");
            System.Console.WriteLine();
            System.Console.WriteLine("*************User Registration****************");
            System.Console.WriteLine();
            do
            {
                System.Console.WriteLine("Enter your name :");
                string name = Console.ReadLine();
                
                System.Console.WriteLine("Enter your phone number :");
                ulong phoneNumber = Convert.ToUInt64(Console.ReadLine());

                System.Console.WriteLine("Enter your mailID");
                string mailID = Console.ReadLine();

                EBRegistration EBuser = new EBRegistration(name,phoneNumber,mailID);

                System.Console.WriteLine($"your ID is {EBuser.MeterID}");

                userList.Add(EBuser);

                System.Console.WriteLine("Do you want to continue to add user ? say {yes or no}");
                choice = Console.ReadLine();

            }while(choice == "yes");

            System.Console.WriteLine("*************************************");
            System.Console.WriteLine("*************Users List**************");
            System.Console.WriteLine("*************************************");
            foreach(EBRegistration userData in userList)
            {
                System.Console.WriteLine($"User ID is {userData.MeterID}");
                System.Console.WriteLine($"User Name is {userData.UserName}");
                System.Console.WriteLine($"User Phone Number is {userData.PhoneNumber}");
                System.Console.WriteLine($"User Mail ID is {userData.MailID}");
                System.Console.WriteLine($"Units consumed {userData.UnitsUsed}");
                System.Console.WriteLine();
            }
            do
            {
                System.Console.WriteLine("if you want to generate bill,please Enter User ID :");
                string userID = Console.ReadLine().ToUpper();

                foreach(EBRegistration userData in userList)
                {
                    if(userID == userData.MeterID)
                    {
                            System.Console.WriteLine("Enter unit Details :");
                            int unitsConsumed = int.Parse(Console.ReadLine());

                            long payableAmount = userData.unitCalculation(unitsConsumed);
                            
                            System.Console.WriteLine("**********Your BILL****************");
                            System.Console.WriteLine();
                            System.Console.WriteLine($"User ID is {userData.MeterID}");
                            System.Console.WriteLine($"User Name is {userData.UserName}");
                            System.Console.WriteLine($"Units consumed {userData.UnitsUsed}");
                            System.Console.WriteLine($"you have to pay Rs.{payableAmount}"); 
                            System.Console.WriteLine();
                            flag = false;    
                    }
                }
                isVaildID(flag);

                System.Console.WriteLine("if you want to display the details of EB user ,please Enter user ID :");
                userID = Console.ReadLine().ToUpper();
                flag = true;
                foreach(EBRegistration userData in userList)
                {
                    if(userData.MeterID == userID)
                    {
                        System.Console.WriteLine("***********User Details***********");
                        System.Console.WriteLine();
                        System.Console.WriteLine($"User ID is {userData.MeterID}");
                        System.Console.WriteLine($"User Name is {userData.UserName}");
                        System.Console.WriteLine($"User Phone Number is {userData.PhoneNumber}");
                        System.Console.WriteLine($"User Mail ID is {userData.MailID}");
                        System.Console.WriteLine();
                        flag = false;
                    }
                }
                isVaildID(flag);

                System.Console.WriteLine("Do you want to continue for calculate Amount and display user details ? say yes / no");
                choice = Console.ReadLine();

            }while(choice == "yes");   

            void isVaildID(bool flag)
            {
                if(flag)
                {
                    System.Console.WriteLine("Invalid User ID");
                }
            }
        }
    }
}