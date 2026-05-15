using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsViolationTypesData
    {
        public static bool GetViolationTypeInfoByID(byte ViolationTypeID, ref string Name, ref decimal FineFees, ref string Description)
        {
            bool IsFound = false;
            string query = @"SELECT * FROM dbo.fn_GetViolationTypeByID(@ViolationTypeID)";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ViolationTypeID", ViolationTypeID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Name = reader["Name"].ToString();
                            FineFees = Convert.ToDecimal(reader["FineFees"]);
                            Description = reader["Description"].ToString();

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
    }
}