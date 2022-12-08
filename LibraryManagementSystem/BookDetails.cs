using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BookDetails
    {
        private static int s_bookID = 100;
        public string BookID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount{ get; set; }

        public BookDetails(string bookName,string authorName,int bookCount)
        {
            s_bookID++;
            BookID = "BID"+s_bookID;
            BookName = bookName;
            AuthorName = authorName;
            BookCount = bookCount;
        }
    }
}