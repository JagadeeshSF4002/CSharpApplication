
/// <summary>
/// used to process the Online medical item purchasing using this application
/// </summary>

namespace OnlineMedicalStore
{
    /// <summary>
    /// Class <see cref="UserDetails"/> used to collect candidates's  information
    /// </summary>
    public class UserDetails
    {
        ///field
        /// <summary>
        /// static field used to auto increment and it uniquely indentify an instance of  user id
        /// </summary>
        private static int s_userID = 1000;
         /// <summary>
        /// Initial balance we provide  to object of  class
        /// </summary>
        /// <value></value>
        private  long _balance;
        /// <summary>
        /// Property ID used to  customer ID in object of <see cref="UserID" /> class
        /// </summary>
        /// <value></value>
        public string UserID { get;}
         /// <summary>
        /// Property UserName used to  provide name to customer Name in object of <see cref="UserName" /> class
        /// </summary>
        /// <value></value>
        public string  UserName { get; set; } 
        
        /// <summary>
        /// Property Age used to  provide age to customer age in object of <see cref="Age" /> class
        /// </summary>
        /// <value></value>
        public int Age { get; set; }
        /// <summary>
        /// Property City used to  provide city to customer city in object of <see cref="City" /> class
        /// </summary>
        /// <value></value>
        public string City { get; set; }
        /// <summary>
        ///  Property Phone Number 10 digits only allowed  <see cref="MobileNumber" /> class
        /// </summary>
        /// <value></value>
        public ulong MobileNumber { get; set; }
        /// <summary>
        /// Property ID used to  intial balance for Balance in object of <see cref="Balance" /> class
        /// </summary>
        /// <value></value>
        public long Balance { get{return _balance;} }  

         //parameterized constructor used to initialize the properties of an object with user provided values by using parameter at object created time
        public UserDetails(string userName,int age,string city,ulong mobileNumber,long balance)
        {
            s_userID++;
            UserID = "UID"+s_userID;
            UserName = userName;
            Age = age;
            City = city;
            _balance = _balance+balance;
            MobileNumber = mobileNumber;
        }


        /// <summary>
        /// Reduct balance
        /// </summary>
        /// <param name="ReductBalance">used to reduct the balance</param>
        
        public void ReductBalance(long balance)
        {
            _balance = _balance - balance;
        }
        /// <summary>
        /// Update balance 
        /// </summary>
        /// <param name="UpdateBalance">used to update the balance</param> 
        public void UpdateBalance(long balance)
        {
            _balance = _balance + balance;
        }    
    }
}