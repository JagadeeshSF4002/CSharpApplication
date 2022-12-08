using System;
/// <summary>
/// used to process the Bank Account Opening using this application
/// </summary>
namespace BankAccountOpening
{
    /// <summary>
    /// Class <see cref="UserInfo"/> used to select candidates's gender information
    /// </summary>
    public enum Gender
    {
        Default,Male,Female,Transgender
    }
    /// <summary>
    /// Class <see cref="UserRegistration"/> used to collect the user information from this application 
    /// </summary>
    public class UserRegistration
    {
        //field
        /// <summary>
        /// static field used to auto increment and it uniquely indentify an instance of  customer id
        /// </summary>
        private static int s_customerID = 1000;
         /// <summary>
        /// Property ID used to provide name for a customer ID in object of <see cref="UserInfo" /> class
        /// </summary>
        /// <value></value>
        public string CustomerID { get;}
        /// <summary>
        /// Property CustomerName used to provide name for a customer name in object of <see cref="UserInfo" /> class
        /// </summary>
        /// <value></value>
        public string CustomerName { get; set; }
         /// <summary>
        /// Property Balance initially zero <see cref="UserInfo" /> class
        /// </summary>
        /// <value></value>
        public long Balance { get; set; }
         /// <summary>
        /// Property Gender initially we have Male,Female,Transgender <see cref="UserInfo" /> class
        /// </summary>
        /// <value></value>
        public Gender Gender { get; set; }
        /// <summary>
        /// Property Phone Number 10 digits only allowed <see cref="UserInfo" /> class
        /// </summary>
        /// <value></value>
        public ulong PhoneNumber { get; set; }
        /// <summary>
        /// Property MailID provides information about user <see cref="UserInfo" /> class
        /// </summary>
        /// <value></value>
        public string MailID { get; set; }
        /// <summary>
        /// Property DOB date of birth <see cref="UserInfo" /> class
        /// </summary>
        /// <value></value>
        public DateTime DOB { get; set; }


        //parameterized constructor used to initialize the properties of an object with user provided values by using parameter at object created time
        public UserRegistration(string customerName,long balance,Gender gender,ulong phoneNumber,string mailID,DateTime dob)
        {
            s_customerID++;
            CustomerID = "HDFC"+s_customerID;
            CustomerName = customerName;
            Balance = balance;
            Gender = gender;
            PhoneNumber = phoneNumber;
            MailID = mailID;
            DOB = dob; 
        }

        /// <summary>
        /// It is used for amount added to balance
        /// </summary>
        /// <param name="Deposit">used to provide balance</param>
        /// <returns>returns Balance</returns>

        public ulong Deposit(ulong amount)
        {
            Balance = Balance + (long)amount;
            return (ulong)Balance;
        }

        /// <summary>
        /// It is used for amount deducted in balance.show available balance
        /// </summary>
        /// <param name="Withdraw">used to provide balance</param>
        /// <returns>returns Balance</returns>
        public ulong Withdraw(ulong amount)
        {
            Balance = Balance - (long)amount;
            return (ulong)Balance;
        }
        
        /// <summary>
        /// show available balance
        /// </summary>
        /// <param name="Withdraw">used to provide available balance</param>
        /// <returns>returns Balance</returns>
        public ulong DisplayBalance()
        {
            return (ulong)Balance;
        }

    }
}