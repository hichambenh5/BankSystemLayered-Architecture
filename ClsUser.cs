using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public string UserName { get; set; }
      
        public string Password { get; private set; }
        public int RoleID { get; set; }
        public int Permissions
        {
            get
            {
                
                ClsRoles role = ClsRoles.Find(this.RoleID);
                return (role != null) ? role.Permissions : 0;
            }
        }
        public ClsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.RoleID = -1;
            Mode = enMode.AddNew;
        }
        private ClsUser(int UserID, string UserName, string Password, int RoleID)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.RoleID = RoleID;
            Mode = enMode.Update;
        }
        public static ClsUser Find(int UserID)
        {
            string UserName = "", PasswordHash = "";
            int RoleID = -1;
          
            bool IsFound = ClsUsersData.GetUsersByID(UserID,ref UserName,ref PasswordHash, ref RoleID);
            if (IsFound)
            {
                return new ClsUser(UserID, UserName, PasswordHash, RoleID);
            }
            else
            {
                return null;
            }
        }

        public static ClsUser Find(string UserName,string Password)
        {
            int UserID = -1;
            int RoleID = -1;
            string HashedPassword = ClsUtil.ComputeHash(Password);
            bool IsFound = ClsUsersData.GetUserInfoByUsernameAndPassword(ref UserID, UserName,  HashedPassword, ref RoleID);
            if (IsFound)
            {
                return new ClsUser(UserID, UserName,HashedPassword, RoleID);
            }
            else
            {
                return null;
            }
        }
        
        private bool _AddNewUser()
        {
           
            this.UserID = ClsUsersData.AddNewUsers(this.UserName, this.Password, this.RoleID);
            return (this.UserID != -1);
        }
        public bool ChangePassword(string newPassword)
        {
            string newHashedPassword = ClsUtil.ComputeHash(newPassword);
            return ClsUsersData.ChangePassword(this.UserID, newHashedPassword);
        }
        private bool _UpdateUser()
        {
           
            return ClsUsersData.UpdateUser(this.UserID, this.UserName, this.Password, this.RoleID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }
        public static DataTable GetAllUsers()
        {
            return ClsUsersData.GetAllUsers();
        }
        public static bool DeleteUser(int UserID)
        {
            return ClsUsersData.DeleteUser(UserID);
        }
        public static bool IsUserExist(int UserID)
        {
            return ClsUsersData.IsUserExist(UserID);
        }
        public static bool IsUserExist(string UserName)
        {
            return ClsUsersData.IsUserExist(UserName);
        }
        public bool VerifyOldPassword(string oldPasswordRaw)
        {
            return ClsUtil.CompureHash(oldPasswordRaw, this.Password);
        }
        public void SetPassword(string PlainPassword)
        {
            
           this.Password = ClsUtil.ComputeHash(PlainPassword);
        }
    }
}
