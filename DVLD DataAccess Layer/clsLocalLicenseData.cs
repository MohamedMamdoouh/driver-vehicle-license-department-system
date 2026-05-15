using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess_Layer
{
    public class clsLocalLicenseData
    {
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref byte LicenseClassID,
                                               ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
                                               ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetLicenseInfoByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            DriverID = Convert.ToInt32(reader["DriverID"]);
                            LicenseClassID = Convert.ToByte(reader["LicenseClassID"]);
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            Notes = reader["Notes"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Notes"]);
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                            IssueReason = Convert.ToByte(reader["IssueReason"]);
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

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            bool IsExist = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IsLicenseExistByPersonID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool GetLicenseInfoByLDLA_ID(int LDLA_ID, ref int LicenseID, ref int ApplicationID, ref int DriverID, ref byte LicenseClassID,
                                                   ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
                                                   ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetLicenseInfoByLDLA_ID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LicenseID = Convert.ToInt32(reader["LicenseID"]);
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            DriverID = Convert.ToInt32(reader["DriverID"]);
                            LicenseClassID = Convert.ToByte(reader["LicenseClassID"]);
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            Notes = reader["Notes"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Notes"]);
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                            IssueReason = Convert.ToByte(reader["IssueReason"]);
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

        public static int IssueDrivingLicense(int ApplicationID, int DriverID, byte LicenseClassID, DateTime IssueDate,
                                              DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive,
                                              byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IssueDrivingLicense", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        public static int RenewDrivingLicense(int OldLicesneID, int ApplicationID, int DriverID, byte LicenseClassID, DateTime IssueDate,
                                              DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive,
                                              byte IssueReason, int CreatedByUserID)
        {
            int NewLicenseID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_RenewDrivingLicense", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OldLicesneID", OldLicesneID);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        NewLicenseID = InsertedID;
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
            return NewLicenseID;
        }

        public static int ReplaceDrivingLicense(int OldLicesneID, int ApplicationID, int DriverID, byte LicenseClassID, DateTime IssueDate,
                                       DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive,
                                       byte IssueReason, int CreatedByUserID)
        {
            int NewLicenseID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_ReplaceDrivingLicense", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OldLicesneID", OldLicesneID);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        NewLicenseID = InsertedID;
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
            return NewLicenseID;
        }

        public static bool ReleaseDrivingLicense(int LicenseID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_ReleaseDrivingLicense", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

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

        public static bool IsLicenseExistByLDLA_ID(int LDLA_ID)
        {
            bool IsExist = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IsLicenseExistByLDLA_ID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);

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

        public static DataTable GetAllLocalLicensesForDriver(int PersonID)
        {
            DataTable dtLocalLicenses = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetAllLocalLicensesForDriver", connection))
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
                            dtLocalLicenses.Load(reader);
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
            return dtLocalLicenses;
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_DeactivateLicense", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
    }
}
