using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    /// <summary>
    /// Balance of current logged customer
    /// </summary>
    public interface IBalance
    {
        /// <summary>
        /// Balance property used only for read 
        /// </summary>
        /// <value></value>
        public double WalletBalance { get; }
        /// <summary>
        /// In this method used to store a amount of current looged user 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double WalletRecharge(double amount);
        /// <summary>
        /// It is used deduct the amount from user
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double DeductBalance(double amount); 
    }
}