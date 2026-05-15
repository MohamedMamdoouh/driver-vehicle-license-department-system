using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsDetainedLicensesData
    {
        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref decimal FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID,
            ref int? ReleaseApplicationID, ref byte ViolationTypeID, ref string ViolationLocation)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetDetainedLicenseInfoByLicenseID", connection))
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
                            DetainID = Convert.ToInt32(reader["DetainID"]);
                            DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                            FineFees = Convert.ToDecimal(reader["FineFees"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                            ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ReleaseDate"]);
                            ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReleasedByUserID"]);
                            ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReleaseApplicationID"]);

                            ViolationTypeID = Convert.ToByte(reader["ViolationTypeID"]);
                            ViolationLocation = Convert.ToString(reader["ViolationLocation"]);

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

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_IsLicenseDetained", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static int DetainDrivingLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased,
            DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID, byte ViolationTypeID, string ViolationLocation)
        {
            int DetainID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_DetainDrivingLicense", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@DetainDate", DetainDate);
                command.Parameters.AddWithValue("@FineFees", FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsReleased", IsReleased);
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.HasValue ? (object)ReleaseDate.Value : DBNull.Value);
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.HasValue ? (object)ReleasedByUserID : DBNull.Value);
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID.HasValue ? (object)ReleaseApplicationID : DBNull.Value);
                command.Parameters.AddWithValue("@ViolationTypeID", ViolationTypeID);
                command.Parameters.AddWithValue("@ViolationLocation", ViolationLocation);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        DetainID = InsertedID;
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

            return DetainID;
        }

        public static DataTable GetAllDetainedLicensesData()
        {
            DataTable dtDetainedLicenses = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetAllDetainedLicensesData", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtDetainedLicenses.Load(reader);
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

            return dtDetainedLicenses;
        }
    }
}
