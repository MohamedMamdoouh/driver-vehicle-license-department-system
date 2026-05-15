using System;
using System.Diagnostics;
using System.Data.SqlClient;

namespace DVLD_DataAccess_Layer
{
    public class clsTestsData
    {
        public static int AddNewTestType(string Title, string Description, decimal Fees, byte DurationTest, byte PassingPercentage)
        {
            int TestTypeID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_AddNewTestType", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestTypeTitle", Title);
                    command.Parameters.AddWithValue("@TestTypeDescription", Description);
                    command.Parameters.AddWithValue("@TestTypeFees", Fees);
                    command.Parameters.AddWithValue("@TestDurationMinutes", DurationTest);
                    command.Parameters.AddWithValue("@PassingPercentage", PassingPercentage);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(Convert.ToString(result), out int InsertedID))
                    {
                        TestTypeID = InsertedID;
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
            return TestTypeID;
        }

        public static sbyte GetPassedTestsCount(int LDLA_ID)
        {
            sbyte PassedTestsCount = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetPassedTestsCount", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && sbyte.TryParse(Convert.ToString(result), out sbyte TestsCount))
                    {
                        PassedTestsCount = TestsCount;
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
            return PassedTestsCount;
        }

        public static byte GetTotalTrialsPerTest(int LDLA_ID, byte TestTypeID)
        {
            byte TestTrialsCount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetTotalTrialsPerTest", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LDLA_ID", LDLA_ID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && byte.TryParse(Convert.ToString(result), out byte Count))
                    {
                        TestTrialsCount = Count;
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
            return TestTrialsCount;
        }

        public static bool IsPersonPassedTest(int LDLA_ID, byte TestTypeID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_IsPersonPassedTest", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
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

        public static bool IsPersonPassedTestForThisAppointment(int TestAppointmentID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_IsPersonPassedTestForThisAppointment", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        public static int AddNewTestResult(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID,
                                           short? PersonTestScore, short? TotalTestScore)
        {
            int TestRecordID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_AddNewTestResult", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@PersonTestScore", PersonTestScore == null ? (object)DBNull.Value : PersonTestScore);
                    command.Parameters.AddWithValue("@TotalTestScore", TotalTestScore == null ? (object)DBNull.Value : TotalTestScore);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(Convert.ToString(result), out int InsertedID))
                    {
                        TestRecordID = InsertedID;
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
            return TestRecordID;
        }

        public static bool DidPersonAttendTest(int LDLA_ID, byte TestTypeID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_DidPersonAttendTest", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
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

        public static bool SetTestLocked(int TestAppointmentID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_SetTestLocked", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
    }
}
