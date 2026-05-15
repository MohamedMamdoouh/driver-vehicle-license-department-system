using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsApplicationData
    {
        public static DataTable GetAllApplications()
        {
            DataTable dtApplications = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_GetAllApplications", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtApplications.Load(reader);
                        }
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

            return dtApplications;
        }

        public static bool GetApplicationInfoByApplicationID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
                                                  ref byte ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate,
                                                  ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_GetApplicationInfoByApplicationID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                            ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                            ApplicationTypeID = Convert.ToByte(reader["ApplicationTypeID"]);
                            ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                            LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                            IsFound = true;
                        }
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

            return IsFound;
        }

        public static bool GetApplicationInfoByLocalLicenseApplicationID(int LocalLicenseApplicationID, ref int ApplicationID,
                                                                        ref int ApplicatntPersonID, ref DateTime ApplicationDate,
                                                                        ref byte ApplicationTypeID, ref byte ApplicationStatus,
                                                                        ref DateTime LastStatusDate, ref decimal PaidFees,
                                                                        ref int CreatedByUserID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_GetApplicationInfoByLocalLicenseApplicationID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            ApplicatntPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                            ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                            ApplicationTypeID = Convert.ToByte(reader["ApplicationTypeID"]);
                            ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                            LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                            IsFound = true;
                        }
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

            return IsFound;
        }

        public static int GetActiveApplicationID(int PersonID, byte ApplicationTypeID)
        {
            int ActiveApplicationID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_GetActiveApplicationID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int AppID))
                    {
                        ActiveApplicationID = AppID;
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

            return ActiveApplicationID;
        }

        public static bool DoesPersonHasActiveApplicaton(int PersonID, byte ApplicationTypeID)
        {
            return GetActiveApplicationID(PersonID, ApplicationTypeID) != -1;
        }

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, byte ApplicationTypeID,
                                            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_AddNewApplication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        ApplicationID = InsertedID;
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

            return ApplicationID;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_DeleteApplication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
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

            return RowsAffected > 0;
        }

        public static bool UpdateStatus(int ApplicationID, byte NewStatus)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_UpdateApplicationStatus", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@NewStatus", NewStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
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

            return RowsAffected > 0;
        }

        public static bool SetComplete(int ApplicationID)
        {
            return UpdateStatus(ApplicationID, 3);
        }

        public static bool Cancel(int ApplicationID)
        {
            return UpdateStatus(ApplicationID, 2);
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, byte ApplicationTypeID,
                                             byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_UpdateApplication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
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

            return RowsAffected > 0;
        }

        public static int GetActiveApplicationID_ForLicenseClass(int PersonID, byte LicenseClassID)
        {
            int ActiveApplicationID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_GetActiveApplicationID_ForLicenseClass", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int AppID))
                    {
                        ActiveApplicationID = AppID;
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

            return ActiveApplicationID;
        }
    }
}
