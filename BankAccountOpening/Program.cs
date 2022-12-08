using System.Collections.Generic;
using System;
namespace BankAccountOpening
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<UserRegistration> customers = new List<UserRegistration>();
            string choice = "";
            bool flag = true;
            System.Console.WriteLine("********Bank Account Opening************");
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("****************************************");
                System.Console.WriteLine("Enter your name :");
                string customerName = Console.ReadLine();
                
                System.Console.WriteLine("Initial Balance :");
                long balance = Convert.ToInt64(Console.ReadLine());

                System.Console.WriteLine("Enter your gender : say {Male/Female/Transgender}");
                Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);//true means any case acceptable example lower or upper character

                System.Console.WriteLine("Enter your mobile number :");
                ulong phoneNumber = Convert.ToUInt64(Console.ReadLine());

                System.Console.WriteLine("Enter your mail ID :");
                string mailID = Console.ReadLine();
                
                System.Console.WriteLine("Enter your Date of Birth : say{dd/MM/yyyy}");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                UserRegistration userDetails = new UserRegistration(customerName,balance,gender,phoneNumber,mailID,dob);
                
                System.Console.WriteLine($"Customer ID is : {userDetails.CustomerID}");

                customers.Add(userDetails);

                System.Console.WriteLine("Do you want to continue? say {yes / no}");
                choice = Console.ReadLine();
                
            }while(choice == "yes");

            System.Console.WriteLine();
            System.Console.WriteLine("**********************************************");
            System.Console.WriteLine("Customers List in HDFC ");
            System.Console.WriteLine("************************");
            foreach(UserRegistration customerDetails in customers)
            {
                System.Console.WriteLine($"Customer ID is : {customerDetails.CustomerID}");
                System.Console.WriteLine($"Customer Name is : {customerDetails.CustomerName}");
                System.Console.WriteLine($"Customer Balance is : {customerDetails.Balance}");
                System.Console.WriteLine($"Customer Gender is : {customerDetails.Gender}");
                System.Console.WriteLine($"Customer Phone Number is : {customerDetails.PhoneNumber}");
                System.Console.WriteLine($"Customer Mail ID is : {customerDetails.MailID}");
                System.Console.WriteLine($"Customer Date of Birth is : {customerDetails.DOB.ToString("dd/MM/yyyy")}");
                System.Console.WriteLine();
            }

            do
            {
                System.Console.WriteLine("If you want to deposit ,please Enter the user ID otherwise say { NO }");
                string userID = Console.ReadLine();
                System.Console.WriteLine("**********************************************");
                foreach(UserRegistration customerData in customers)
                {
                    if(userID == customerData.CustomerID)
                    {
                        System.Console.WriteLine("Enter the Amount :");
                        ulong depositAmount = Convert.ToUInt64(Console.ReadLine());

                        ulong displayCurrentBalance = customerData.Deposit(depositAmount);
                        System.Console.WriteLine($"The current Balance is {displayCurrentBalance}");
                        flag = false;
                    }
                    if(userID == "NO")
                    {
                        break;
                    }
                }
                System.Console.WriteLine();
                
                isValidID(flag);
                
                System.Console.WriteLine("If you want to withdraw ,please Enter the user ID otherwise say { NO }");
                userID = Console.ReadLine();
                System.Console.WriteLine("**********************************************");
                flag = true;
                foreach(UserRegistration customerData in customers)
                {
                    if(userID == customerData.CustomerID)
                    {
                        System.Console.WriteLine("Enter the Amount :");
                        ulong withdrawnAmount = Convert.ToUInt64(Console.ReadLine());

                        ulong displayCurrentBalance = customerData.Withdraw(withdrawnAmount);
                        System.Console.WriteLine($"The current Balance is {displayCurrentBalance}");
                        flag = false;
                    }
                    if(userID == "NO")
                    {
                        break;
                    }
                }
                System.Console.WriteLine();
                
                isValidID(flag);
                
                System.Console.WriteLine("If you want to display the balance, please Enter the user ID otherwise say { NO }");
                userID = Console.ReadLine().ToUpper();
                System.Console.WriteLine("**********************************************");
                flag = true;
                foreach(UserRegistration customerData in customers)
                {
                    if(userID == customerData.CustomerID)
                    {
                        ulong displayCurrentBalance = customerData.DisplayBalance();
                        System.Console.WriteLine($"The current Balance is {displayCurrentBalance}");
                        flag = false;   
                    }
                    if(userID == "NO")
                    {
                        break;
                    }
                }
                System.Console.WriteLine();
                
                isValidID(flag);

                System.Console.WriteLine("Do you want to continue ? say { yes / no } otherwise say { NO }");
                choice = Console.ReadLine();
            }while(choice == "yes");

            void isValidID(bool flags)
            { 
                if(flags)
                {
                    System.Console.WriteLine("Invalid user Id");
                }
            }
        }
    }
}