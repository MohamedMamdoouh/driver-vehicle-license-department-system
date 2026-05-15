using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfo(byte LicenseClassID, ref string LicenseClassName, ref string ClassDescription,
                                               ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetLicenseClassInfo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LicenseClassName = Convert.ToString(reader["ClassName"]);
                            ClassDescription = Convert.ToString(reader["ClassDescription"]);
                            MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                            DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                            ClassFees = Convert.ToDecimal(reader["ClassFees"]);

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

        public static DataTable GetAllLicenseClassesNames()
        {
            DataTable dtClassesNames = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetAllLicenseClassesNames", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtClassesNames.Load(reader);
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

            return dtClassesNames;
        }

        public static decimal GetLicenseClassFees(byte LicenseClassID)
        {
            decimal Fees = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetLicenseClassFees", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal ClassFess))
                    {
                        Fees = ClassFess;
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

            return Fees;
        }

        public static bool GetLicenceClassInfoByLDL_ID(int LDLA_ID, ref byte LicesneClassID, ref string LicenseClassName, ref string ClassDescription,
                                                       ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.sp_GetLicenceClassInfoByLDL_ID", connection))
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
                            LicesneClassID = Convert.ToByte(reader["LicenseClassID"]);
                            LicenseClassName = Convert.ToString(reader["ClassName"]);
                            ClassDescription = Convert.ToString(reader["ClassDescription"]);
                            MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                            DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                            ClassFees = Convert.ToDecimal(reader["ClassFees"]);

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
    }
}
