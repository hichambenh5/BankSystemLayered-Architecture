using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSYSTEMWINDOWSFORMS
{
   public class ClsAccountTypeData
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private static void _LogError(Exception ex)
        {
            string source = "AccountTypeDataLibrary";
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
         public static bool GetAccountTypebyID(int AccountTypeID,ref string TypeName,ref decimal MinimumBalance)
        {
            bool Isfound=false;
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            using(SqlCommand command=new SqlCommand("SP_GetAccountTypesPyID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
                try
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Isfound = true;
                            TypeName = (string)reader["TypeName"];
                            MinimumBalance = (decimal)reader["MinimumBalance"];
                        }
                        else
                        {
                            Isfound = false;
                        }
                    }
                }catch(Exception ex)
                {
                    Isfound = false;
                    _LogError(ex);
                }

            }
            return Isfound;

        }
        public static bool GetAccountTypebyName(ref int AccountTypeID,  string TypeName, ref decimal MinimumBalance)
        {
            bool Isfound = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_GetAccountTypesPyTypeName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TypeName", TypeName);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Isfound = true;
                            AccountTypeID = (int)reader["AccountTypeID"];
                            MinimumBalance = (decimal)reader["MinimumBalance"];
                        }
                        else
                        {
                            Isfound = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Isfound = false;
                    _LogError(ex);
                }

            }
            return Isfound;

        }
        public static int AddNewAccountType(string TypeName,  decimal MinimumBalance)
        {
            int AccountTypeID = -1;
            using(SqlConnection connection=new SqlConnection(connectionString))
             using(SqlCommand command=new SqlCommand("SP_AddNewAccountType", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TypeName", TypeName);
                command.Parameters.AddWithValue("@MinimumBalance", MinimumBalance);
                SqlParameter parameter = new SqlParameter("@NewID", SqlDbType.Int)
                {
                    Direction=ParameterDirection.Output
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    AccountTypeID = (int)parameter.Value;
                    
                }catch(Exception ex)
                {
                    _LogError(ex);
                }

            }
            return AccountTypeID;
        }
        public static bool UpdateAccountType(int AccountTypeID, string TypeName,  decimal MinimumBalance)
        {
            int rowsaffected = 0;
            using(SqlConnection connection=new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_UpdateAccountType", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", AccountTypeID);
                command.Parameters.AddWithValue("@TypeName", TypeName);
                command.Parameters.AddWithValue("@MinimumBalance", MinimumBalance);
                try {
                    connection.Open();
                    rowsaffected = command.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    _LogError(ex);
                }
            }
            return (rowsaffected > 0);
        }
        public static bool DeleteAccountType(int AccountTypeID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_DeleteAccountType", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", AccountTypeID);

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
        public static DataTable GetAllAccountTypes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_GetAllAccountTypes", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }
            return dt;
        }
        public static bool IsAccountTypeExist(int AccountTypeID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_CheckAccountTypesExists", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

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
