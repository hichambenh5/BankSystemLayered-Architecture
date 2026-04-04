using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BANKSYSTEMWINDOWSFORMS
{
   public class ClsRolesData
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private static void _LogError(Exception ex)
        {
            string source = "RolesDataLibrary";
            string logName = "Application";

            try
            {
                if (!System.Diagnostics.EventLog.SourceExists(source))
                {
                    System.Diagnostics.EventLog.CreateEventSource(source, logName);
                }
                System.Diagnostics.EventLog.WriteEntry(source, ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            catch
            {

            }
        }
        public static bool GetRolesByID(int RoleID,ref string RoleName,ref int Permissions)
        {
            bool IsFound = false;
            string query = "select * from Roles where RoleID=@RoleID";
            using(SqlConnection connection=new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleID", RoleID);
                try
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            RoleName = (string)reader["RoleName"];
                            Permissions = (int)reader["Permissions"];
                        }
                        else
                        {
                            IsFound = false;
                        }
                    }
                }catch(Exception ex)
                {
                    IsFound = false;
                    _LogError(ex);
                }
            }
            return IsFound;
        }
        public static int AddNewRoles(string RoleName, int Permissions)
        {
            int rolesid = -1;
            string query = @"insert into Roles(RoleName,Permissions)
values(@RoleName,@Permissions);
select SCOPE_IDENTITY();";
            using(SqlConnection connection=new SqlConnection(connectionString))
         
            using(SqlCommand command=new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleName", RoleName);
                command.Parameters.AddWithValue("@Permissions", Permissions);
                try {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedId))
                    {
                        rolesid = insertedId;
                    }
                }
                catch(Exception ex)
                {
                    _LogError(ex);

                }
            }
            return rolesid;
        }
        public static bool UpdateRoles(int RoleID,  string RoleName,  int Permissions)
        {
            int rowsAffected = 0;
            string query = @"update Roles 
set RoleName=@RoleName,
Permissions=@Permissions
where RoleID=@RoleID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleID",RoleID);
                command.Parameters.AddWithValue("@RoleName", RoleName);
                command.Parameters.AddWithValue("@Permissions", Permissions);
           
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllRoles()
        {
            DataTable dt = new DataTable();
            string query = "select * from Roles";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }

                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }

            return dt;
        }
        public static bool DeleteRoles(int RoleID)
        {
            int rowsAffected = 0;
            string query = @"delete Roles where RoleID=@RoleID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleID", RoleID);
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }
            return (rowsAffected > 0);
        }
        public static bool IsRolesExist(int RoleID)
        {
            bool isFound = false;
            string query = "select found=1 from Roles where RoleID=@RoleID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleID", RoleID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        isFound = reader.HasRows;
                    }
                }
                catch (Exception ex)
                {
                    isFound = false;
                    _LogError(ex);
                }
            }
            return isFound;
        }
    }
}
