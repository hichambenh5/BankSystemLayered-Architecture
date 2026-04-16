using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClsTransaction
    {
        public int TransactionID { get; private set; }
        public int? AccountFrom { get; set; }
        public int? AccountTo { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; }
        public DateTime TransactionDate { get; set; }

        
        public static bool Deposit(int AccountID, decimal Amount)
        {
            if (Amount <= 0) return false; 

            return ClsTransactionsData.Deposit(AccountID, Amount);
        }

       
        public static bool Withdraw(int AccountID, decimal Amount)
        {
            if (Amount <= 0) return false;

           
            return ClsTransactionsData.Withdraw(AccountID, Amount);
        }

       
        public static bool Transfer(int FromAccountID, int ToAccountID, decimal Amount)
        {
            if (Amount <= 0 || FromAccountID == ToAccountID) return false;

            return ClsTransactionsData.Transfer(FromAccountID, ToAccountID, Amount);
        }

      
        public static DataTable GetAccountHistory(int AccountID)
        {
            return ClsTransactionsData.GetTransactionsByAccountID(AccountID);
        }

       
        public static DataTable GetAllTransactions()
        {
            return ClsTransactionsData.GetAllTransaction();
        }
    }
}
