using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsApplicationTypesData
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dtApplicationTypes = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetAllApplicationTypes", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtApplicationTypes.Load(reader);
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

            return dtApplicationTypes;
        }

        public static bool GetApplicationTypeByID(byte ApplicationTypeID, ref string Title, ref decimal Fees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetApplicationTypeByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Title = Convert.ToString(reader["ApplicationTypeTitle"]);
                            Fees = Convert.ToDecimal(reader["ApplicationFees"]);

                            IsFound = true;
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

            return IsFound;
        }

        public static bool UpdateApplicationType(int ID, string Title, decimal Fees)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_UpdateApplicationType", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ApplicationID", ID);
                command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
                command.Parameters.AddWithValue("@ApplicationFees", Fees);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
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

            return RowsAffected > 0;
        }

        public static int AddNewApplicationType(string Title, decimal Fees)
        {
            int ApplicationTypeID = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_AddNewApplicationType", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
                command.Parameters.AddWithValue("@ApplicationFees", Fees);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(Convert.ToString(result), out int InsertedID))
                    {
                        ApplicationTypeID = InsertedID;
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

            return ApplicationTypeID;
        }
    }
}
