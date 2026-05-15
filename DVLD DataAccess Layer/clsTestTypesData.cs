using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsTestTypesData
    {
        public static DataTable GetAllTestTypesData()
        {
            DataTable dtTestTypesData = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetAllTestTypes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtTestTypesData.Load(reader);
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

            return dtTestTypesData;
        }

        public static bool GetTestTypeByID(int ID, ref string Title, ref string Description, ref decimal Fees, ref byte DurationMinutes, ref byte PassingPercentage)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetTestTypeByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestTypeID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Title = Convert.ToString(reader["TestTypeTitle"]);
                            Description = Convert.ToString(reader["TestTypeDescription"]);
                            Fees = Convert.ToDecimal(reader["TestTypeFees"]);
                            DurationMinutes = Convert.ToByte(reader["TestDurationMinutes"]);
                            PassingPercentage = Convert.ToByte(reader["PassingPercentage"]);

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

        public static bool UpdateTestType(byte ID, string Title, string Description, decimal Fees, byte DurationMinutes, byte PassingPercentage)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_UpdateTestType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestTypeID", ID);
                    command.Parameters.AddWithValue("@TestTypeTitle", Title);
                    command.Parameters.AddWithValue("@TestTypeDescription", Description);
                    command.Parameters.AddWithValue("@TestTypeFees", Fees);
                    command.Parameters.AddWithValue("@TestDurationMinutes", DurationMinutes);
                    command.Parameters.AddWithValue("@PassingPercentage", PassingPercentage);

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

        public static int AddNewTestType(string Title, string Description, decimal Fees, byte DurationTest, byte PassingPercentage)
        {
            int TestTypeID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_AddNewTestType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestTypeTitle", Title);
                    command.Parameters.AddWithValue("@TestTypeDescription", Description);
                    command.Parameters.AddWithValue("@TestTypeFees", Fees);
                    command.Parameters.AddWithValue("@TestDurationMinutes", DurationTest);
                    command.Parameters.AddWithValue("@PassingPercentage", PassingPercentage);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
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
    }
}
