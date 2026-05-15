using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsQuestionsBankData
    {
        public static DataTable GenerateTestQuestions(byte TestTypeID, byte NumberOfEasyQuestions, byte NumberOfMediumQuestions, byte NumberOfHardQuestions)
        {
            DataTable dtTestQuestions = new DataTable();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.sp_GetTestQuestions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@NumberOfEasyQuestions", NumberOfEasyQuestions);
                        command.Parameters.AddWithValue("@NumberOfMediumQuestions", NumberOfMediumQuestions);
                        command.Parameters.AddWithValue("@NumberOfHardQuestions", NumberOfHardQuestions);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtTestQuestions.Load(reader);
                            }
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

            return dtTestQuestions;
        }
    }
}
