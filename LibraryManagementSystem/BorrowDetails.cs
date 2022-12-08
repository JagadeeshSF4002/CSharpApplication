using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public enum BorrowedStatus    
    {
        Default,Borrowed,Returned
    }
    public class BorrowDetails
    {
        private static int s_borrowID = 300;
        public string BorrowID { get; set; }
        public string BookID { get; set; }
        public string RegistrationID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public BorrowedStatus BorrowedStatus { get; set; }

        public BorrowDetails(string bookID,string registrationID,DateTime borrowedDate,BorrowedStatus borrowedStatus)
        {
            s_borrowID++;
            BorrowID = "LB"+s_borrowID;
            BookID = bookID;
            RegistrationID = registrationID;
            BorrowedDate = borrowedDate;
            BorrowedStatus = borrowedStatus;
        }
    }
}