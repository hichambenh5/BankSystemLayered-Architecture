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
            return (this.PersonID != -1);
        }
        private bool _UpdateCustomer()
        {
            return ClsCustomerData.UpdateCustomers(this.PersonID, this.FirstName, this.LastName,
                this.Email, this.Phone, this.NationalID);
        }
        public static ClsCustomer Find(int PersonID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", NationalID = "";
            bool Isfound = ClsCustomerData.GetCustomerByID(PersonID, ref FirstName, ref LastName, ref Email, ref Phone, ref NationalID);
            if (Isfound)
            {
                return new ClsCustomer(PersonID, FirstName, LastName, Email, Phone, NationalID);
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
                return new ClsCustomer(PersonID, FirstName, LastName, Email, Phone, NationalID);
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
            return ClsCustomerData.DeleteCustomers(PersonID);
        }
        public static bool IsCustomerExist(int PersonID)
        {
            return ClsCustomerData.IsCustomerExist(PersonID);
        }
        public static bool IsCustomerExist(string NationalID)
        {
            return ClsCustomerData.IsCustomerExist(NationalID);
        }
    }
}
