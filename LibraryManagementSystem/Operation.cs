using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public static class Operation
    {
        private static List<UserDetails> userList = new List<UserDetails>();
        private static List<BookDetails> bookList = new List<BookDetails>();
        private static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        private static List<BorrowDetails> borrowList2 = new List<BorrowDetails>();
        
        private static UserDetails currentUser;
        private static BookDetails currentBook;
        public static void MainMenu()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("         Welcome to BankAccount       ");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
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
                                Operation.Registration();
                                break;
                            }
                    case 2:
                            {
                                Operation.Login();
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
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("       Registration Form         ");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine();
            System.Console.WriteLine("Enter your Name :");
            string userName = Console.ReadLine();
            
            System.Console.WriteLine("Enter your Gender : { Male / Female / Transgender }");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

            System.Console.WriteLine("Enter your Department :");
            Department department = Enum.Parse<Department>(Console.ReadLine().ToUpper());

            System.Console.WriteLine("Enter your mobile Number :");
            long mobileNumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your mail ID :");
            string mailID = Console.ReadLine();

            UserDetails user = new UserDetails(userName,gender,department,mobileNumber,mailID);
            userList.Add(user);

            System.Console.WriteLine($"Your ID is {user.RegistrationID}");

        }

        public static void Login()
        {
           System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
           System.Console.WriteLine("           User Login             ");
           System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
           
           System.Console.WriteLine("Enter your user ID :");
           string userID = Console.ReadLine().ToUpper();
           
            currentUser = isValidID(userID);

            if(currentUser != null)
            {
                SubMenu();
            }
            else
            {
                System.Console.WriteLine(" Invalid User ID ");
            }
        }

        static void SubMenu()
        {
            int option = 0;
            do
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("          Sub Menu           ");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("1.Borrow Book");
                System.Console.WriteLine("2.Showed Borrowed History");
                System.Console.WriteLine("3.Return Book");
                System.Console.WriteLine("4.Exit");
                System.Console.WriteLine("Enter the option");
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                BorrowBook();
                                break;
                            }
                    case 2:
                            {
                                ShowBorrowedHistory();
                                break;
                            }
                    case 3:
                            {
                                ReturnBooks();
                                break;
                            }
                    case 4:
                            {
                                option = 4;
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("Invalid Option");
                                break;
                            }
                }
            }while(option != 4);

        }

        private static void ReturnBooks()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("       Return Book       ");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>");
            DateTime date;
            foreach(BorrowDetails borrowedBook in borrowList)
            {
                if(borrowedBook.RegistrationID == currentUser.RegistrationID  && borrowedBook.BorrowedStatus == BorrowedStatus.Borrowed)
                {
                    System.Console.WriteLine($"You have to return the book {borrowedBook.BookID}  on {borrowedBook.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy")}");
                    date = borrowedBook.BorrowedDate.AddDays(15);
                    
                    if(borrowedBook.BorrowedDate  > borrowedBook.BorrowedDate.AddDays(15) )
                    {
                        double days = (date-borrowedBook.BorrowedDate).TotalDays;
                        int charge = 1;
                        double amount = days*charge;
                        System.Console.WriteLine($"Amount to be paid for {borrowedBook.BorrowID} is {amount}");  
                    }
                
                }
            }

            System.Console.WriteLine("Enter the Borrowed Book ID :");
            string borrowedID = Console.ReadLine().ToUpper();
            
            foreach(BorrowDetails borrowedBook in borrowList)
            {
                if(borrowedBook.BookID == borrowedID)
                {
                    double days = (borrowedBook.BorrowedDate.AddDays(15)-borrowedBook.BorrowedDate).TotalDays;
                    
                    if(days < 0)
                    {
                        int charge = 1;
                        double amount = days*charge;
                        System.Console.WriteLine($"You have to pay {amount} ");
                        int getAmount = int.Parse(Console.ReadLine());
                        if(getAmount == amount)
                        {
                            borrowedBook.BorrowedStatus = BorrowedStatus.Returned;
                            currentBook.BookCount++;
                            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                            System.Console.WriteLine(" Book Returned Successfully");
                            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                        }
                    }
                    else
                    {
                            borrowedBook.BorrowedStatus = BorrowedStatus.Returned;
                            currentBook.BookCount++;
                            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                            System.Console.WriteLine(" Book Returned Successfully");
                            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
 
                    }
                }
            }
        }

        public static void ShowBorrowedHistory()
        {
            foreach(BorrowDetails borrowBook in borrowList)
            {
                if(borrowBook.RegistrationID == currentUser.RegistrationID)
                {
                    System.Console.WriteLine($"{borrowBook.BookID} {borrowBook.BookID} {borrowBook.RegistrationID} {borrowBook.BorrowedDate.ToString("dd/MM/yyyy")} {borrowBook.BorrowedStatus}");
                }
            }
        } 

        public static void BorrowBook()
        {
            foreach(BookDetails book in bookList)
            {
                System.Console.WriteLine($"{book.BookID} {book.BookName} {book.AuthorName}  {book.BookCount}");
            }

            System.Console.WriteLine("Enter the Book ID :");
            string bookID = Console.ReadLine().ToUpper();
            int countBooks = 0;
            foreach(BookDetails book in bookList)
            {
                if(book.BookID == bookID)
                {
                    currentBook = book;
                    if(book.BookCount <= 0)
                    {
                        System.Console.WriteLine("Books are not available for the selected count");
                        foreach(BorrowDetails borrowBook in borrowList)
                        {
                            if(borrowBook.BookID == bookID)
                            {
                                System.Console.WriteLine($"The book will be available on {borrowBook.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy")}");
                            }
                        }
                    }
                    else
                    {
                        foreach(BorrowDetails borrowBook in borrowList)
                        {
                            if(borrowBook.RegistrationID == currentUser.RegistrationID)
                            {
                                countBooks++;
                            }
                        }
                        if(countBooks < 3)
                        {
                            BorrowDetails borrow = new BorrowDetails(currentBook.BookID,currentUser.RegistrationID,DateTime.Now,BorrowedStatus.Borrowed);
                            borrowList.Add(borrow);
                            currentBook.BookCount--;
                            System.Console.WriteLine(" Book Borrowed Successfully ");
                        }
                        else
                        {
                            System.Console.WriteLine("You have reached your limits");
                        }
                    }
                }
            }
        }
        public static UserDetails isValidID(string userID)
        {
            foreach(UserDetails user in userList)
            {
                if(user.RegistrationID == userID)
                {
                    return user;
                }
            }
            return null;
        }

        public static void DefaultData()
        {
            UserDetails user1 = new UserDetails("Jagadeesh",Gender.Male,Department.CSE,9876543210,"kanchipuram");
            UserDetails user2 = new UserDetails("Praveen",Gender.Male,Department.CSE,9876543510,"Chennai");
            UserDetails user3 = new UserDetails("Rajesh",Gender.Male,Department.CSE,9876543230,"kanchipuram");

            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);

            BookDetails book1 = new BookDetails("c#","Author1",3);
            BookDetails book2= new BookDetails("Java","Author3",13);
            BookDetails book3 = new BookDetails("c++","Author5",33);
            BookDetails book4 = new BookDetails("python","Author4",15);
            bookList.Add(book1);
            bookList.Add(book2);
            bookList.Add(book3);
            bookList.Add(book4);

            BorrowDetails borrowDetails1 = new BorrowDetails(book1.BookID,user1.RegistrationID,DateTime.Now,BorrowedStatus.Borrowed);
            BorrowDetails borrowDetails2 = new BorrowDetails(book2.BookID,user2.RegistrationID,DateTime.Now,BorrowedStatus.Borrowed);
            BorrowDetails borrowDetails3 = new BorrowDetails(book3.BookID,user3.RegistrationID,DateTime.Now,BorrowedStatus.Borrowed);
            BorrowDetails borrowDetails4 = new BorrowDetails(book4.BookID,user1.RegistrationID,DateTime.Now,BorrowedStatus.Returned);
            borrowList.Add(borrowDetails1);
            borrowList.Add(borrowDetails2);
            borrowList.Add(borrowDetails3);
            borrowList.Add(borrowDetails4);
        
        }    
    }

}