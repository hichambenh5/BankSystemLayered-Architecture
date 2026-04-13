using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClsAccountType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int AccountTypeID
        {
            get;
            set;
        }
        public string TypeName
        {
            get;
            set;
        }
        public decimal MinimumBalance
        {
            get;
            set;
        }
        public ClsAccountType()
        {
            this.AccountTypeID = -1;
            this.TypeName = "";
            this.MinimumBalance = 0;
            Mode = enMode.AddNew;
        }
        private ClsAccountType(int accounttypeid,string typename,decimal minimumbalance)
        {
            this.AccountTypeID = accounttypeid;
            this.TypeName = typename;
            this.MinimumBalance = minimumbalance;
            Mode = enMode.Update;
        }
        public static ClsAccountType find(int accounttypeid)
        {
            string typename = "";
            decimal minimumbalance = 0;
            bool isfound = ClsAccountTypeData.GetAccountTypebyID(accounttypeid, ref typename, ref minimumbalance);
            if (isfound)
            {
                return new ClsAccountType(accounttypeid, typename,  minimumbalance);
            }
            else
            {
                return null;
            }
        }
        public static ClsAccountType find(string typename)
        {
            int accounttypeid = -1;
            decimal minimumbalance = 0;
            bool isFound = ClsAccountTypeData.GetAccountTypebyName(ref accounttypeid, typename, ref minimumbalance);
            if (isFound)
            {
                return new ClsAccountType(accounttypeid, typename, minimumbalance);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewAccountType()
        {
            int accounttypeid = ClsAccountTypeData.AddNewAccountType(this.TypeName, this.MinimumBalance);
            return (accounttypeid != -1);
        }
        private bool _UpdateAccountType()
        {
            return ClsAccountTypeData.UpdateAccountType(this.AccountTypeID, this.TypeName, this.MinimumBalance);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAccountType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateAccountType();
            }
            return false;

        }
        public static DataTable GetAllAccountType()
        {
            return ClsAccountTypeData.GetAllAccountTypes();
        }
        public static bool DeleteAccountType(int AccountTypeID)
        {
            return ClsAccountTypeData.DeleteAccountType(AccountTypeID);
        }
        public static bool IsAccountTypeExist(int AccountTypeID)
        {
            return ClsAccountTypeData.IsAccountTypeExist(AccountTypeID);
        }
    }
}
