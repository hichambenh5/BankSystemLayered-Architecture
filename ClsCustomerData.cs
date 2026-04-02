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
    internal class ClsCustomerData
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private static void _LogError(Exception ex)
        {
            string source = "CustomerDataLibrary";
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
        public static bool GetCustomerByID(int PersonID, ref string FirstName, ref string LastName, ref string Email,
           ref string Phone, ref string NationalID)
        {
            bool isfound = false;
            string query = "select * from Customers where PersonID=@PersonID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isfound = true;
                            FirstName = (string)reader["FirstName"];
                            LastName = (string)reader["LastName"];
                            if (reader["Email"] != DBNull.Value)
                            {
                                Email = (string)reader["Email"];
                            }
                            else
                            {
                                Email = "";
                            }
                            if (reader["Phone"] != DBNull.Value)
                            {
                                Phone = (string)reader["Phone"];
                            }
                            else
                            {
                                Phone = "";
                            }
                            NationalID = (string)reader["NationalID"];
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
        public static bool GetCustomerByNationalID(ref int PersonID, ref string FirstName, ref string LastName, ref string Email,
          ref string Phone, string NationalID)
        {
            bool isfound = false;
            string query = "select * from Customers where NationalID=@NationalID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NationalID", NationalID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isfound = true;
                            PersonID = (int)reader["PersonID"];
                            FirstName = (string)reader["FirstName"];
                            LastName = (string)reader["LastName"];
                            if (reader["Email"] != DBNull.Value)
                            {
                                Email = (string)reader["Email"];
                            }
                            else
                            {
                                Email = "";
                            }
                            if (reader["Phone"] != DBNull.Value)
                            {
                                Phone = (string)reader["Phone"];
                            }
                            else
                            {
                                Phone = "";
                            }

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

        public static int AddNewCustomer(string FirstName, string LastName, string Email,
           string Phone, string NationalID)
        {
            int personid = -1;
            string query = @"insert into Customers(FirstName,LastName,Email,Phone,NationalID)
values(@FirstName,@LastName,@Email,@Phone,@NationalID);
select SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                if (Email != "" && Email != null)
                {
                    command.Parameters.AddWithValue("@Email", Email);
                }
                else
                    command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                if (Phone != "" && Phone != null)
                {
                    command.Parameters.AddWithValue("@Phone", Phone);
                }
                else
                    command.Parameters.AddWithValue("@Phone", System.DBNull.Value);
                command.Parameters.AddWithValue("@NationalID", NationalID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        personid = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {

                    _LogError(ex);
                }
            }
            return personid;
        }
        public static bool UpdateCustomers(int PersonID, string FirstName, string LastName, string Email,
           string Phone, string NationalID)
        {
            int rowsAffected = 0;
            string query = @"update Customers
set FirstName=@FirstName,
LastName=@LastName,
Email=@Email,
Phone=@Phone,
NationalID=@NationalID
where PersonID=@PersonID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                if (Email != "" && Email != null)
                {
                    command.Parameters.AddWithValue("@Email", Email);
                }
                else
                    command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                if (Phone != "" && Phone != null)
                {
                    command.Parameters.AddWithValue("@Phone", Phone);
                }
                else
                    command.Parameters.AddWithValue("@Phone", System.DBNull.Value);
                command.Parameters.AddWithValue("@NationalID", NationalID);
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
        public static DataTable GetAllCustomer()
        {
            DataTable dt = new DataTable();
            string query = "select * from Customers";
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
        public static bool DeleteCustomers(int PersonID)
        {
            int rowsAffected = 0;
            string query = @"delete Customers
where PersonID=@PersonID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
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
        public static bool IsCustomerExist(int PersonID)
        {
            bool isFound = false;
            string query = "select found=1 from Customers where PersonID=@PersonID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
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
        public static bool IsCustomerExist(string NationalID)
        {
            bool isFound = false;
            string query = "select found=1 from Customers where NationalID=@NationalID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NationalID", NationalID);
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
