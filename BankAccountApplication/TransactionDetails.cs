using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    public enum TransactionType
    {
        Default,Deposit,Withdraw,Transfer
    }
    public class TransactionDetails
    {
        private static int s_transaction = 5000;
        public string TransactionID { get; set; }
        public long FromAccount { get; set; }
        public long ToAccount{get;set;}
        public AccountType AccountType{ get; set; }
        public TransactionType TransactionType { get; set; }
        public long Amount { get; set; }
        public DateTime TransactionDate{get;set;}

        public TransactionDetails(long fromAccount,long toAccount,AccountType accountType,TransactionType transactionType,long amount,DateTime transactionDate)
        {
            s_transaction++;
            TransactionID = "TID"+s_transaction;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            AccountType = accountType;
            TransactionType = transactionType;
            Amount = Amount+amount;
            TransactionDate = transactionDate;
        }
    }
}