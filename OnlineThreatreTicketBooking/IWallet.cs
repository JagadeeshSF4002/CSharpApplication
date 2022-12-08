using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public interface IWallet
    {
        public double WalletBalance { get;}
        public double RechargeWallet(double amount);
    }
}