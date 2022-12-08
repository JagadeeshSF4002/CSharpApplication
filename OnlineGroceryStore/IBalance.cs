using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public interface IBalance
    {
        public long WalletBalance { get;}
        public void WalletRecharge(long amount);
    }
}