using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    /// <summary>
    /// CustomerDetails inherits a personalDetails and IBALANCE
    /// </summary>
    public class CustomerDetails : PersonalDetails, IBalance
    {
        
        /// <summary>
        /// It is field to store amount
        /// </summary>
        private double _balance;
        /// <summary>
        /// Auto Generated customer ID static field used
        /// </summary>
        private static int s_customerID = 1000;
        /// <summary>
        /// Auto Generated property it is used only read
        /// </summary>
        /// <value></value>
        public string CustomerID { get; }
        /// <summary>
        /// Balance property used only for read 
        /// </summary>
        /// <value></value>
        
        public double WalletBalance { get{return _balance;}}
        /// <summary>
        /// Get the values from user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="gender"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="dob"></param>
        /// <param name="mailID"></param>
        /// <param name="location"></param>
        /// <param name="balance"></param>
        /// <returns></returns>

        public CustomerDetails(string name, string fatherName, Gender gender, ulong mobileNumber, DateTime dob, string mailID, string location,double balance) : base(name, fatherName, gender, mobileNumber, dob, mailID, location)
        {
            s_customerID++;
            CustomerID = "CID"+s_customerID;
            _balance = balance;
        }

        /// <summary>
        /// Get the values from file read and assigned to specified property
        /// </summary>
        /// <param name="customerData"></param>
        public CustomerDetails(string customerData)
        {
            string[] values = customerData.Split(',');
            s_customerID = int.Parse(values[0].Remove(0,3));
            CustomerID = values[0];
            Name = values[1];
            FatherName = values[2];
            Gender = Enum.Parse<Gender>(values[3],true);
            MobileNumber = ulong.Parse(values[4]);
            DOB = DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
            MailID = values[6];
            Location = values[7];
            _balance = double.Parse(values[8]);
        }
        /// <summary>
        /// Deduct the amount from user
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double DeductBalance(double amount)
        {
            _balance = _balance - amount;
            return _balance;
        }
        /// <summary>
        /// Recharge the amount from user
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double WalletRecharge(double amount)
        {
            _balance = _balance+amount;
           return _balance;
        }
    }
}