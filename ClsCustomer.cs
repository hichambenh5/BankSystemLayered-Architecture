using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSYSTEMWINDOWSFORMS
{
  public class ClsCustomer
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        private static Dictionary<int, ClsCustomer> _CustomersCache = new Dictionary<int, ClsCustomer>();
        private static HashSet<string> _NationalIDsSet = new HashSet<string>();
        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string NationalID { set; get; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }
        public ClsCustomer()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.NationalID = "";
            Mode = enMode.AddNew;

        }
        private ClsCustomer(int PersonID, string FirstName, string LastName, string Email,
           string Phone, string NationalID)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.NationalID = NationalID;
            Mode = enMode.Update;
        }
        private bool _AddNewCustomer()
        {
            this.PersonID = ClsCustomerData.AddNewCustomer(this.FirstName, this.LastName, this.Email, this.Phone, this.NationalID);
            if (this.PersonID != -1) {
                _CustomersCache[this.PersonID] = this;
                _NationalIDsSet.Add(this.NationalID);
                return true;
            
            }
            return false;
        }
        private bool _UpdateCustomer()
        {
            bool isUpdated = ClsCustomerData.UpdateCustomers(this.PersonID, this.FirstName, this.LastName,
                this.Email, this.Phone, this.NationalID);
            if (isUpdated)
            {
                _CustomersCache[this.PersonID] = this;
                _NationalIDsSet.Add(this.NationalID);
                return true;
            }
            return false;
        }
        public static ClsCustomer Find(int PersonID)
        {
            if(_CustomersCache.TryGetValue(PersonID,out ClsCustomer customer))
            {
                return customer;
            }
            string FirstName = "", LastName = "", Email = "", Phone = "", NationalID = "";
            bool Isfound = ClsCustomerData.GetCustomerByID(PersonID, ref FirstName, ref LastName, ref Email, ref Phone, ref NationalID);
            if (Isfound)
            {
                ClsCustomer foundCustomer = new ClsCustomer(PersonID, FirstName, LastName, Email, Phone, NationalID);
                _CustomersCache[PersonID] = foundCustomer;
                _NationalIDsSet.Add(NationalID);
                return foundCustomer;
            }
            else
                return null;
        }
        public static ClsCustomer Find(string NationalID)
        {
            int PersonID = -1;
            string FirstName = "", LastName = "", Email = "", Phone = "";
            bool Isfound = ClsCustomerData.GetCustomerByNationalID(ref PersonID, ref FirstName, ref LastName,
                ref Email, ref Phone, NationalID);
            if (Isfound)
            {
                ClsCustomer foundCustomer = new ClsCustomer(PersonID, FirstName, LastName, Email, Phone, NationalID);
                _CustomersCache[PersonID] = foundCustomer;
                _NationalIDsSet.Add(NationalID);
                return foundCustomer;
            }
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCustomer())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCustomer();
            }
            return false;
        }
        public static DataTable GetAllCustomer()
        {
            return ClsCustomerData.GetAllCustomer();
        }
        public static bool DeleteCustomers(int PersonID)
        {
            ClsCustomer customer = ClsCustomer.Find(PersonID);
            string nationalIDToDelete = (customer != null) ? customer.NationalID : null;
            bool isDeleted = ClsCustomerData.DeleteCustomers(PersonID);
            if (isDeleted)
            {
                _CustomersCache.Remove(PersonID);
                if (nationalIDToDelete != null)
                {
                    _NationalIDsSet.Remove(nationalIDToDelete);
                }
                return true;
            }
            return false;
        }
        public static bool IsCustomerExistQuick(string NationalID)
        {
            if (_NationalIDsSet.Contains(NationalID)) return true;
            return ClsCustomerData.IsCustomerExist(NationalID);
        }
        public static bool IsCustomerExist(int PersonID)
        {
            if (_CustomersCache.ContainsKey(PersonID)) return true;
            return ClsCustomerData.IsCustomerExist(PersonID);
        }
        public static bool IsCustomerExist(string NationalID)
        {
            return IsCustomerExistQuick(NationalID);
        }
    }
}
