using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClsUsersData
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private static void _LogError(Exception ex)
        {
            string source = "UsersDataLibrary";
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
        public static bool GetUsersByID(int UserID,ref string UserName,ref string Password,ref int RoleID)
        {
            bool IsFound = false;
            string query = "select * from Users where UserID=@UserID";
            using(SqlConnection connection=new SqlConnection(connectionString))
            using(SqlCommand command=new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if ((reader.Read()))
                        {
                            IsFound = true;
                            UserName = (string)reader["UserName"];
                            Password = (string)reader["Password"];
                            RoleID = (int)reader["RoleID"];
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
        public static bool GetUserInfoByUsernameAndPassword(ref int UserID,  string UserName,  string Password, ref int RoleID)
        {
            bool IsFound = false;
            string query = "select * from Users where UserName=@UserName and Password=@Password";
            using(SqlConnection connection=new SqlConnection(connectionString))
            using(SqlCommand command=new SqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                try
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            UserID = (int)reader["UserID"];
                            UserName = (string)reader["UserName"];
                            Password = (string)reader["Password"];
                            RoleID = (int)reader["RoleID"];
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
       public static int AddNewUsers( string UserName, string Password,  int RoleID)
        {
            int UserID = -1;
            string query = @"insert into Users(UserName,Password,RoleID)
values(@UserName,@Password,@RoleID);
select SCOPE_IDENTITY();";
            using(SqlConnection connection=new SqlConnection(connectionString))
            using(SqlCommand command=new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@RoleID", RoleID);
                try {
                    connection.Open();
                    Object result = command.ExecuteScalar();
                    if(result!=null && result != DBNull.Value)
                    {
                        UserID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }
            return UserID;
        }
        public static bool UpdateUser(int UserID, string UserName, string Password, int RoleID)
        {
            int rowsAffected = 0;
            string query = @"update Users
set UserName=@UserName,

RoleID=@RoleID
where UserID=@UserID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@UserName", UserName);
               
                command.Parameters.AddWithValue("@RoleID", RoleID);
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }catch(Exception ex)
                {
                    _LogError(ex);
                }
            }
            return (rowsAffected > 0);
        }
        public static DataTable GetAllUsers()
        {
            DataTable dt=new DataTable();
            string query = @"select Users.UserID,Users.UserName,Users.RoleID,Roles.RoleName,Roles.Permissions
from Users inner join Roles on Users.RoleID=Roles.RoleID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }catch(Exception ex)
                {
                    _LogError(ex);
                }
            }
            return dt;

            }
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            string query = "delete Users where UserID=@UserID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                try {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    _LogError(ex);
                }
            }
            return (rowsAffected > 0);
        }

        public static bool IsUserExist(int UserID)
        {
            bool IsFound = false;
            string query = "select found=1 from Users where UserID=@UserID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        IsFound = reader.HasRows;

                    }

                }catch(Exception ex)
                {
                    IsFound = false;
                    _LogError(ex);
                }
            }
            return IsFound;
            }
        public static bool IsUserExist(string UserName)
        {
            bool IsFound = false;
            string query = "select found=1 from Users where UserName=@UserName";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName",UserName);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IsFound = reader.HasRows;

                    }

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    _LogError(ex);
                }
            }
            return IsFound;
        }
        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int rowsAffected = 0;
            string query = @"update Users set Password=@Password where UserID=@UserID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID",UserID);
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }catch(Exception ex)
                {
                    _LogError(ex);
                }
            }
            return (rowsAffected > 0);
            }
    }
}
