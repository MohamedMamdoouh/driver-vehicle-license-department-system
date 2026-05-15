using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsInternationalLicenseData
    {
        public static DataTable GetAllInternationalLicensesForPerson(int PersonID)
        {
            DataTable dtInternationalLicenses = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetAllInternationalLicensesForPerson", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtInternationalLicenses.Load(reader);
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

            return dtInternationalLicenses;
        }

        public static bool GetInternationalLicesneInfoByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID,
                                                  ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate,
                                                  ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetInternationalLicenseInfoByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            DriverID = Convert.ToInt32(reader["DriverID"]);
                            IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

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

        public static bool IsInternationalLicenseExistByPersonID(int PersonID)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IsInternationalLicenseExistByPersonID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        IsExist = true;
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

            return IsExist;
        }

        public static int IssueInternationalDrivingLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
                                                           DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int LicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IssueInternationalDrivingLicense", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        LicenseID = InsertedID;
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

            return LicenseID;
        }

        public static bool DeactivateInternationalLicense(int InternationalLicenseID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_DeactivateInternationalLicense", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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

        public static bool IsInternationalLicenseActive(int PersonID)
        {
            bool IsActive = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IsInternationalLicenseActive", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        IsActive = true;
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

            return IsActive;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dtInternationalLicensesData = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetAllInternationalLicenses", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtInternationalLicensesData.Load(reader);
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

            return dtInternationalLicensesData;
        }
    }
}
