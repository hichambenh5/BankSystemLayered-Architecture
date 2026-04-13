using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClsAccount
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int AccountID { get; set; }
        public int PersonID { get; set; }
        public int AccountTypeID { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public string AccountNumber { get; set; }
       
        public bool IsDeleted { get; set; }
       
       public ClsAccount()
        {
            this.AccountID = -1;
            this.PersonID = -1;
            this.AccountTypeID = -1;
            this.Balance = 0;
            this.Status = "";
            this.CreatedByUserID = -1;
            this.CreationDate = DateTime.Now;
            this.AccountNumber = "";
           
            this.IsDeleted = false;
           
            Mode = enMode.AddNew;
        }
        private ClsAccount(
         int accountID,
         int personid,
         int accounttypeid,
         decimal balance,
         string status,
         int createdbyuserid,
         DateTime creationdate,
         string accountnumber,
         
         bool isdeleted
       )
        {
            this.AccountID = accountID;
            this.PersonID = personid;
            this.AccountTypeID = accounttypeid;
            this.Balance = balance;
            this.Status = status;
            this.CreatedByUserID = createdbyuserid;
            this.CreationDate = creationdate;
            this.AccountNumber = accountnumber;

           
           
            this.IsDeleted = isdeleted;
           

            Mode = enMode.Update;
        }
        public static ClsAccount Find(int accountid)
        {
            int PersonID = 0, AccountTypeID = 0, CreatedByUserID = 0;
            decimal Balance = 0;
            string Status = "", AccountNumber = "";
            DateTime CreationDate = DateTime.Now;
         
            bool IsDeleted = false;
            bool isfound = ClcAccountData.GetAccountbyID(accountid,ref PersonID,ref AccountTypeID,ref Balance, ref Status,
                ref CreatedByUserID,ref CreationDate,ref AccountNumber
                ,ref IsDeleted);
            if (isfound)
            {
                return new ClsAccount(accountid, PersonID, AccountTypeID, Balance, Status,
                    CreatedByUserID, CreationDate, AccountNumber, 
                    IsDeleted);
            }
            else
            {
                return null;
            }
        }
        public static ClsAccount Find(string accountNumber)
        {
            int AccountID = 0, PersonID = 0, AccountTypeID = 0, CreatedByUserID = 0;
            decimal Balance = 0;
            string Status = "";
            DateTime CreationDate = DateTime.Now;
           
            bool IsDeleted = false;

            bool isFound = ClcAccountData.GetAccountbyAccountNumber(
                ref AccountID,
                ref PersonID,
                ref AccountTypeID,
                ref Balance,
                ref Status,
                ref CreatedByUserID,
                ref CreationDate,
                accountNumber,
               
                ref IsDeleted
               
            );

            if (isFound)
            {
                return new ClsAccount(
                    AccountID,
                    PersonID,
                    AccountTypeID,
                    Balance,
                    Status,
                    CreatedByUserID,
                    CreationDate,
                    accountNumber,
                  
                    IsDeleted
                  
                );
            }

            return null;
        }
        public static ClsAccount FindByPersonID(int personID)
        {
            int AccountID = 0, AccountTypeID = 0, CreatedByUserID = 0;
            decimal Balance = 0;
            string Status = "", AccountNumber = "";
            DateTime CreationDate = DateTime.Now;
          
            bool IsDeleted = false;

            bool isFound = ClcAccountData.GetAccountbyPersonID(
                ref AccountID,
                personID,
                ref AccountTypeID,
                ref Balance,
                ref Status,
                ref CreatedByUserID,
                ref CreationDate,
                ref AccountNumber,
               
                ref IsDeleted
              
            );

            if (isFound)
            {
                return new ClsAccount(
                    AccountID,
                    personID,
                    AccountTypeID,
                    Balance,
                    Status,
                    CreatedByUserID,
                    CreationDate,
                    AccountNumber,
                   
                    IsDeleted
                   
                );
            }

            return null;
        }
        private bool _AddNewAccount()
        {
            int accountid = ClcAccountData.AddNewAccount(this.PersonID, this.AccountTypeID, this.Balance, this.Status, this.CreatedByUserID, this.AccountNumber,
                 this.IsDeleted);
            return (accountid != -1);
        }
        private bool _UpdateAccount()
        {
            return ClcAccountData.UpdateAccount(this.PersonID, this.AccountTypeID, this.Balance, this.Status, this.CreatedByUserID, this.AccountNumber,
                 this.IsDeleted, this.AccountID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAccount())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateAccount();
            }
            return false;
        }
        public static DataTable GetAllAccount()
        {
            return ClcAccountData.GetAllAccount();
        }
        public static bool DeleteAccount(int AccountID)
        {
           return ClcAccountData.DeleteAccount(AccountID);
        }
        public static bool IsAccountExistByAccountID(int AccountID)
        {
            return ClcAccountData.CheckAccountExistsByID(AccountID);
        }
        public static bool IsAccountExistByAccountNumber(string AccountNumber)
        {
            return ClcAccountData.CheckAccountExistsByAccountNumber(AccountNumber);
        }
        public static bool IsAccountExistByPersonID(int PersonID)
        {
            return ClcAccountData.CheckAccountExistsByPersonID(PersonID);
        }
        public static bool IsActive(int accountID)
        {
            return ClcAccountData.IsAccountActive(accountID);
        }
    }
}
