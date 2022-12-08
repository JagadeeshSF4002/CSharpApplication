using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    public static class Operation
    {
        //customer detail class
        private static List<CustomerDetails> customersList = new List<CustomerDetails>();
        private static List<TransactionDetails> transactionList = new List<TransactionDetails>();
        static CustomerDetails currentCustomer;
        static CustomerDetails userAccount;
        public static void MainMenu()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("           Main Menu             ");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            int option = 0;
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("1.User Registration");
                System.Console.WriteLine("2.User Login");
                System.Console.WriteLine("3.Exit");
                System.Console.WriteLine("Enter the option :");
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                Registration();
                                break;
                            }
                    case 2:
                            {
                                Login();
                                break;
                            }
                    case 3:
                            {
                                option = 3;
                                System.Environment.Exit(0);
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("invalid option");
                                break;
                            }
                }

            }while(option != 3);
        }

        public static void Registration()
        {   
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("<       Registration Form        >");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine();

            System.Console.WriteLine("Enter your name :");
            string customerName = Console.ReadLine();

            System.Console.WriteLine("Enter your gender :");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

            System.Console.WriteLine("Enter your mobile number :");
            long mobileNumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your AccountType : {CA / SB / RD / FD}");
            AccountType accountType = Enum.Parse<AccountType>(Console.ReadLine(),true);

            System.Console.WriteLine("Enter the balance :");
            long balance = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the Date of Birth :");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            System.Console.WriteLine("Enter maild id :");
            string maild = Console.ReadLine();
            
            System.Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();
            
            CustomerDetails customer = new CustomerDetails(customerName,gender,accountType,balance,dob,maild,address);

            customersList.Add(customer);    

            System.Console.WriteLine($"Account Added Successfully. your account number is {customer.AccountNumber}");        
        }

        public static void Login()
        {
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine("<            Login               >");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine();

            System.Console.WriteLine("Enter Customer Account Number :");
            long accountNumber = long.Parse(Console.ReadLine());

            currentCustomer = ValidateAccountNumber(accountNumber);

            System.Console.WriteLine(currentCustomer.AccountNumber);
            
            if(currentCustomer!=null)
            {
                SubMenu();   
            }
            else
            {
                System.Console.WriteLine("Invalid User ID");
            }
        }

        public static void SubMenu()
        {
           
            int option;
            do
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("        Sub Menu            ");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine();
                System.Console.WriteLine("1.Show Account Details");
                System.Console.WriteLine("2.Deposit");
                System.Console.WriteLine("3.Withdraw");
                System.Console.WriteLine("4.Balance");
                System.Console.WriteLine("5.Transfer Amount");
                System.Console.WriteLine("6.Show Transaction History");
                System.Console.WriteLine("7.Exit");
                System.Console.WriteLine("Enter the option :");
                option= int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                ShowAccountDetail();
                                break;
                            }
                    case 2:
                            {
                                Deposit();
                                break;
                            }
                    case 3:
                            {
                                Withdraw();
                                break;
                            }
                    case 4:
                            {
                                ShowBalance();
                                break;
                            }
                    case 5:
                            {
                                TransferAmount();
                                break;
                            }
                    case 6:
                            {
                                ShowTransactionHistory();
                                break;
                            }
                    case 7:
                            {
                                option = 7;
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("Invalid Option");
                                break;
                            }
                    }
            }while(option != 7);
            
        }

        private static void ShowTransactionHistory()
        {
            System.Console.WriteLine("<<<<<<<<<<<>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("    Transaction History     ");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine();
            foreach(TransactionDetails transaction in transactionList)
            {
                 if(currentCustomer.AccountNumber == transaction.FromAccount)
                 {
                    System.Console.WriteLine($"{transaction.FromAccount}  {transaction.ToAccount} {transaction.AccountType} {transaction.TransactionType} {transaction.TransactionDate.ToString("dd/MM/yyyy")}");
                 }
            }
            
        }

        static void ShowAccountDetail()
        {
            foreach(CustomerDetails customer in customersList)
            {
                if(customer.AccountNumber == currentCustomer.AccountNumber)
                {
                    System.Console.WriteLine("Call");
                    System.Console.WriteLine(customer.AccountNumber+" "+customer.AccountType+" "+customer.CustomerName+"  "+customer.DOB.ToString("dd/MM/yyyy")+"  "+customer.Balance+"  "+customer.Address+" "+customer.MailID+" ");
                    
                }
            }
        }

        static void Deposit()
        {
            foreach(CustomerDetails customer in customersList)
            {
                if(customer.AccountNumber == currentCustomer.AccountNumber)
                {
                    System.Console.WriteLine("Enter the amount to be deposited :");
                    long amount = long.Parse(Console.ReadLine());

                    TransactionDetails transaction = new TransactionDetails(customer.AccountNumber,customer.AccountNumber,customer.AccountType,TransactionType.Deposit,amount,DateTime.Now);
                    transactionList.Add(transaction);

                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine($" {customer.AccountNumber} Amount Deposited successfully.");
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                }
            }
        }

        static void Withdraw()
        {
            foreach(CustomerDetails customer in customersList)
            {
                if(customer.AccountNumber == currentCustomer.AccountNumber)
                {
                    System.Console.WriteLine("Enter the amount to be withdrawn :");
                    long amount = long.Parse(Console.ReadLine());


                    if(currentCustomer.Balance >= amount)
                    {
                        currentCustomer.Withdraw(amount);
                        TransactionDetails transaction = new TransactionDetails(customer.AccountNumber,customer.AccountNumber,customer.AccountType,TransactionType.Withdraw,amount,DateTime.Now);
                        transactionList.Add(transaction);
                    }
                    else
                    {
                        System.Console.WriteLine("Insufficient Balance");
                    }
                }
            }
        }

        static void TransferAmount()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("          Transfer Amount        ");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine();
           

            System.Console.WriteLine("Enter the account number :");
            long accountNumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the Account Type :");
            AccountType accountType = Enum.Parse<AccountType>(Console.ReadLine());

            bool customerFlag = false;
            foreach(CustomerDetails customer in customersList)
            {
                if(customer.AccountNumber == accountNumber && customer.AccountType == accountType)
                {
                     userAccount = customer;
                     System.Console.WriteLine("Enter the amount to be Deposited :");
                     long amount = long.Parse(Console.ReadLine());

                     if(amount >= currentCustomer.Balance)
                     {
                            userAccount.Deposit(amount);
                            System.Console.WriteLine("***********Transaction successfull**************");
                            TransactionDetails transaction = new TransactionDetails(currentCustomer.AccountNumber,userAccount.AccountNumber,userAccount.AccountType,TransactionType.Deposit,amount,DateTime.Now);
                            transactionList.Add(transaction);
                     }
                     else
                     {
                        System.Console.WriteLine("Insufficient fund to transfer");
                     }

                    customerFlag = true;   
                }
            }
            if(!customerFlag)
            {
                System.Console.WriteLine("Invalid Account Information");
            }
        }

        static void ShowBalance()
        {
            foreach(CustomerDetails customer in customersList)
            {
                if(customer.AccountNumber == currentCustomer.AccountNumber)
                {
                  System.Console.WriteLine($"Available Balance is {customer.Balance}");   
                }
            }   
        }

        

        public static CustomerDetails ValidateAccountNumber(long accountNumber)
        {
            foreach(CustomerDetails customer in customersList)
            {
                if(customer.AccountNumber == accountNumber)
                {
                    return customer;
                }
            }
            return null;
        }

        public static void DefaultData()
        {

            CustomerDetails customer1 = new CustomerDetails("Ravi",Gender.Male,AccountType.CA,10000,DateTime.Now,"ravi@123","chennai");
            CustomerDetails customer2 = new CustomerDetails("Kavi",Gender.Male,AccountType.FD,20000,DateTime.Now,"kavi@123","theni");
            CustomerDetails customer3 = new CustomerDetails("pavi",Gender.Female,AccountType.CA,30000,DateTime.Now,"pavi@123","chennai");

            customersList.Add(customer1);
            customersList.Add(customer2);
            customersList.Add(customer3);

            TransactionDetails transaction1 = new TransactionDetails(customer1.AccountNumber,customer1.AccountNumber,customer1.AccountType,TransactionType.Deposit,10000,DateTime.Now);
            TransactionDetails transaction2 = new TransactionDetails(customer1.AccountNumber,customer2.AccountNumber,customer1.AccountType,TransactionType.Transfer,10000,DateTime.Now);
            TransactionDetails transaction3 = new TransactionDetails(customer2.AccountNumber,customer1.AccountNumber,customer2.AccountType,TransactionType.Transfer,10000,DateTime.Now);
            TransactionDetails transaction4 = new TransactionDetails(customer3.AccountNumber,customer1.AccountNumber,customer3.AccountType,TransactionType.Transfer,10000,DateTime.Now);
        }
        
    }
}