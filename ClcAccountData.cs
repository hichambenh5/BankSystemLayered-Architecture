using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClcAccountData
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private static void _LogError(Exception ex)
        {
            string source = "AccountDataLibrary";
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
        private static void _FillAccountData(SqlDataReader reader,
 ref int AccountID, ref int PersonID, ref int AccountTypeID, ref decimal Balance,
 ref string Status, ref int CreatedByUserID, ref DateTime CreationDate,
 ref string AccountNumber,  ref bool IsDeleted )
        {
            AccountID = (int)reader["AccountID"];
            PersonID = (int)reader["PersonID"];
            AccountTypeID = (int)reader["AccountTypeID"];
            Balance = (decimal)reader["Balance"];
            Status = (string)reader["Status"];
            CreatedByUserID = (int)reader["CreatedByUserID"];
            CreationDate = (DateTime)reader["CreationDate"];
            AccountNumber = (string)reader["AccountNumber"];



            IsDeleted = (bool)reader["IsDeleted"];


        }
        public static bool GetAccountbyID(
   int AccountID,ref int PersonID, ref int AccountTypeID, ref decimal Balance, ref string Status, ref int CreatedByUserID,  ref DateTime CreationDate,
   ref string AccountNumber, ref bool IsDeleted
 )
        {
            bool isfound = false;

            using(SqlConnection connection=new SqlConnection(connectionString))
            using(SqlCommand command=new SqlCommand("SP_GetAccountByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountID", AccountID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isfound = true;
                            _FillAccountData(reader,
                         ref AccountID, ref PersonID, ref AccountTypeID, ref Balance,
                         ref Status, ref CreatedByUserID, ref CreationDate,
                         ref AccountNumber,  ref IsDeleted);
                        }
                        else
                        {
                            isfound = false;
                        }
                    }
                }catch(Exception ex)
                {
                    isfound = false;
                    _LogError(ex);
                }
            }
            return isfound;
        }
        public static bool GetAccountbyAccountNumber(ref int AccountID,ref int PersonID, ref int AccountTypeID,ref decimal Balance,
ref string Status, ref int CreatedByUserID,ref  DateTime CreationDate, string AccountNumber,
ref bool IsDeleted)
        {
            bool isfound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_GetAccountByAccountNumber", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isfound = true;
                            _FillAccountData(reader,
                       ref AccountID, ref PersonID, ref AccountTypeID, ref Balance,
                       ref Status, ref CreatedByUserID, ref CreationDate,
                       ref AccountNumber,  ref IsDeleted);
                        }
                        else
                        {
                            isfound = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    isfound = false;
                    _LogError(ex);
                }
            }
            return isfound;
        }
        public static bool GetAccountbyPersonID(ref int AccountID,  int PersonID, ref int AccountTypeID, ref decimal Balance,
ref string Status, ref int CreatedByUserID, ref DateTime CreationDate,ref string AccountNumber, 
 ref bool IsDeleted)
        {
            bool isfound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_GetAccountByPersonID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isfound = true;
                            _FillAccountData(reader,
                       ref AccountID, ref PersonID, ref AccountTypeID, ref Balance,
                       ref Status, ref CreatedByUserID, ref CreationDate,
                       ref AccountNumber,  ref IsDeleted);
                        }
                        else
                        {
                            isfound = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    isfound = false;
                    _LogError(ex);
                }
            }
            return isfound;
        }
        public static int AddNewAccount(int PersonID,  int AccountTypeID,  decimal Balance, string Status,  int CreatedByUserID, 
            string AccountNumber,  
            bool IsDeleted)
        {
            int AccountID = -1;
            using(SqlConnection connection=new SqlConnection(connectionString))
            using(SqlCommand command=new SqlCommand("SP_AddNewAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
                command.Parameters.AddWithValue("@Balance", Balance);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
               
                
                command.Parameters.AddWithValue("@IsDeleted", IsDeleted);
               
                SqlParameter outputId = new SqlParameter("@NewID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);

                
                try {
                    connection.Open();
                    command.ExecuteNonQuery();
                    AccountID = (int)outputId.Value;

                }
                
                catch(Exception ex)
                {
                    _LogError(ex);

                }
            }
            return AccountID;
        }
        public static bool UpdateAccount(
    int PersonID,
    int AccountTypeID,
    decimal Balance,
    string Status,
    int CreatedByUserID,
    string AccountNumber,
   
    bool IsDeleted,
   
    int AccountID)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_UpdateAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
                command.Parameters.AddWithValue("@Balance", Balance);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@AccountNumber", AccountNumber);


              
                command.Parameters.AddWithValue("@IsDeleted", IsDeleted);
               

                command.Parameters.AddWithValue("@ID", AccountID);

                try
                {
                    connection.Open();
                    isUpdated = command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }

            return isUpdated;
        }
        public static bool DeleteAccount(int AccountID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_DeleteAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", AccountID);
                try {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        isDeleted = true;
                    }
                
                }catch(Exception ex)
                {
                    _LogError(ex);
                }
            }
            return isDeleted;
        }
        public static DataTable GetAllAccount()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection=new SqlConnection(connectionString))
            using(SqlCommand command=new SqlCommand("SP_GetAllAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                try {

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
        public static bool CheckAccountExistsByID(int AccountID)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_CheckAccountExistsByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", AccountID);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        isExists = true;
                    }
                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }

            return isExists;
        }
        public static bool CheckAccountExistsByAccountNumber(string AccountNumber)
        {
            bool isExists = false;
            using(SqlConnection connection=new SqlConnection(connectionString))
            using(SqlCommand command=new SqlCommand("SP_CheckAccountExistsByAccountNumber", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                try {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        isExists = true;
                    }
                }catch(Exception ex)
                {
                    _LogError(ex);
                }
            }
            return isExists;
        }
        public static bool CheckAccountExistsByPersonID(int PersonID)
        {
            bool isExists = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_CheckAccountExistsByPersonID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        isExists = true;
                    }
                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }
            return isExists;
        }
        public static bool IsAccountActive(int AccountID)
        {
            bool isActive = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SP_CheckAccountIsActive", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AccountID", AccountID);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        isActive = true;
                    }
                }
                catch (Exception ex)
                {
                    _LogError(ex);
                }
            }

            return isActive;
        }
    }
}
