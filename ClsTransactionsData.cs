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
    public class ClsTransactionsData
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private static void _LogError(Exception ex)
        {
            string source = "TransactionsDataLibrary";
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
        public static DataTable GetTransactionsByAccountID(int AccountID)
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection=new SqlConnection(connectionString))
          
            using (SqlCommand command=new SqlCommand("SP_GettTransactionsByAccountID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountID", AccountID);
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
        public static DataTable GetAllTransaction()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))

            using (SqlCommand command = new SqlCommand("SP_GetAllTransactions", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
               
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
        public static bool Transfer(int FromAccountID, int ToAccountID, decimal Amount)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Transfer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                   
                    command.Parameters.AddWithValue("@FromAccountID", FromAccountID);
                    command.Parameters.AddWithValue("@ToAccountID", ToAccountID);
                    command.Parameters.AddWithValue("@Amount", Amount);

                    try
                    {
                        connection.Open();
                       
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                       
                        _LogError(ex);
                        return false;
                    }
                }
            }

            
            return (rowsAffected > 0);
        }
        public static bool Deposit(int AccountID, decimal Amount)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Deposit", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    
                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    command.Parameters.AddWithValue("@Amount", Amount);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                       
                        _LogError(ex);
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static bool Withdraw(int AccountID, decimal Amount)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Withdraw", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    command.Parameters.AddWithValue("@Amount", Amount);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        
                        _LogError(ex);
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }
    }
}
