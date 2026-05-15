using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsTestAppointmentsData
    {
        public static DataTable GettAllApointmentsForTest(int LDLA_ID, byte TestTypeID)
        {
            DataTable dtApointmentsData = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetAllAppointmentsForTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtApointmentsData.Load(reader);
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

            return dtApointmentsData;
        }

        public static bool IsPersonHasActiveTestAppointment(int LDLA_ID, byte TestTypeID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_IsPersonHasActiveTestAppointment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
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

            return IsFound;
        }

        public static int AddNewTestAppointment(byte TestTypeID, int LDLA_ID, DateTime AppointmentDate, decimal PaidFees,
                                                int CreatedByUserID, bool IsLocked, int? RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_AddNewTestAppointment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID ?? (object)DBNull.Value);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(Convert.ToString(result), out int InsertedID))
                    {
                        TestAppointmentID = InsertedID;
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

            return TestAppointmentID;
        }

        public static bool GetTestAppointmentInfoByID(int TestAppointmentID, ref byte TestTypeID, ref int LDLA_ID,
                                                      ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID,
                                                      ref bool IsLocked, ref int? RetakeTestApplicationID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetTestAppointmentInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TestTypeID = Convert.ToByte(reader["TestTypeID"]);
                            LDLA_ID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                            RetakeTestApplicationID = reader["RetakeTestApplicationID"] == DBNull.Value
                                                      ? (int?)null
                                                      : Convert.ToInt32(reader["RetakeTestApplicationID"]);
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

        public static bool UpdateTestAppointment(int TestAppointmentID, DateTime NewTestAppointmentDate)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_UpdateTestAppointment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@NewTestAppointmentDate", NewTestAppointmentDate);

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

        public static bool IsPersonHasAnyTestAppointments(int LDLA_ID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_IsPersonHasAnyTestAppointments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
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

            return IsFound;
        }
    }
}
