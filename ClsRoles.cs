using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClsRoles
    {
        [Flags] 
        public  enum enPermissions
        {
            eAll = -1,
            eNone = 0,
            eManageClients = 1,
            eManageUsers = 2,
            eTransactions = 4,
            eManageRegisters = 8,
            eUpdatePermissions = 16
        }
        enPermissions permission = enPermissions.eNone;
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
       
        public int RoleID{
            set;
            get;
        }
        public string RoleName
        {
            set;
            get;
        }
       public int Permissions
        {
            set; get;
        }

       public ClsRoles()
        {
            this.RoleID = -1;
            this.RoleName = "";
            Mode = enMode.AddNew;
            permission = enPermissions.eNone;
        }
        public ClsRoles(int Roleid, string rolename, int permesion) {

            this.RoleID = Roleid;
            this.RoleName = rolename;
            Mode = enMode.Update;
            this.Permissions = permesion;

        }
        public static ClsRoles Find(int roleid)
        {
           
            string rolename = "";
            int permesion = 0;
            bool isfound = ClsRolesData.GetRolesByID(roleid,ref rolename,ref permesion);
            if (isfound)
            {
                return new ClsRoles(roleid, rolename, permesion);
            }
            else
                return null;
        }

      private bool _AddNewRoles()
        {
            this.RoleID = ClsRolesData.AddNewRoles(this.RoleName, this.Permissions);
            return (this.RoleID != -1);
        }
        private bool _UpdateRoles()
        {
            return ClsRolesData.UpdateRoles(this.RoleID, this.RoleName,this.Permissions);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoles())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateRoles();
                    
            }
            return false;
        }
        public static DataTable GetAllRoles()
        {
            return ClsRolesData.GetAllRoles();
        }
        public static bool DeleteRoles(int roleid)
        {
          
            return ClsRolesData.DeleteRoles(roleid);
        }
        public void SetPermissionsFromList(List<enPermissions> selectedPermissions)
        {
            this.Permissions = 0;
            foreach(enPermissions p in selectedPermissions)
            {
                this.Permissions = AddPermission(this.Permissions, p);
            }
        }
      
        public static bool IsRolesExist(int RoleID)
        {
            return ClsRolesData.IsRolesExist(RoleID);
        }
        public static int AddPermission(int CurrentPermissions,enPermissions NewPermission)
        {
           
            return CurrentPermissions | (int) NewPermission;
        }
        public static bool CheckAccess(int UserPermissions, int PermissionToCheck)
        {

           return (UserPermissions & PermissionToCheck) == PermissionToCheck;

           
        }

    }
    
}
