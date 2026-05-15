using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsCountryDataAccess
    {
        public static string GetCountryByID(int ID)
        {
            string CountryName = string.Empty;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetCountryByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryID", ID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    CountryName = Convert.ToString(result);
                }
                catch (SqlException ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
                catch (Exception ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
            }

            return string.IsNullOrEmpty(CountryName) ? null : CountryName;
        }

        public static int GetCountryID(string CountryName)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetCountryIDByName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryName", CountryName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        ID = InsertedID;
                    }
                }
                catch (SqlException ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
                catch (Exception ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
            }

            return ID;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dtCountries = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetAllCountries", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtCountries.Load(reader);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
                catch (Exception ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
            }

            return dtCountries;
        }

        public static bool IsCountryExistByID(int ID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IsCountryExistByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryID", ID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        IsFound = true;
                    }
                }
                catch (SqlException ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
                catch (Exception ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
            }

            return IsFound;
        }

        public static bool IsCountryExistByName(string CountryName)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IsCountryExistByName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryName", CountryName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        IsFound = true;
                    }
                }
                catch (SqlException ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
                catch (Exception ex)
                {
                    clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                    throw;
                }
            }

            return IsFound;
        }
    }
}
