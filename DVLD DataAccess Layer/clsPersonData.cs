using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsPersonData
    {
        public static bool GetPerosnInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
                                             ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone,
                                             ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetPersonInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NationalNo = Convert.ToString(reader["NationalNo"]);
                            FirstName = Convert.ToString(reader["FirstName"]);
                            SecondName = Convert.ToString(reader["SecondName"]);
                            ThirdName = reader["ThirdName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ThirdName"]);
                            LastName = Convert.ToString(reader["LastName"]);
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            Gendor = Convert.ToByte(reader["Gendor"]);
                            Address = Convert.ToString(reader["Address"]);
                            Phone = Convert.ToString(reader["Phone"]);
                            Email = reader["Email"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Email"]);
                            NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                            ImagePath = reader["ImagePath"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ImagePath"]);
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

        public static bool GetPerosnInfoByNationalNo(string NationalNo, ref int ID, ref string FirstName, ref string SecondName, ref string ThirdName,
                                                     ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone,
                                                     ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetPersonInfoByNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ID = Convert.ToInt32(reader["PersonID"]);
                            FirstName = Convert.ToString(reader["FirstName"]);
                            SecondName = Convert.ToString(reader["SecondName"]);
                            ThirdName = reader["ThirdName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ThirdName"]);
                            LastName = Convert.ToString(reader["LastName"]);
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            Gendor = Convert.ToByte(reader["Gendor"]);
                            Address = Convert.ToString(reader["Address"]);
                            Phone = Convert.ToString(reader["Phone"]);
                            Email = reader["Email"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Email"]);
                            NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                            ImagePath = reader["ImagePath"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ImagePath"]);
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

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                       DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email,
                                       int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_AddNewPerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(Convert.ToString(result), out int InsertedID))
                    {
                        PersonID = InsertedID;
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
            return PersonID;
        }

        public static bool UpdatePerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                         DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email,
                                         int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_UpdatePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", ID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

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

        public static bool DeletePerson(int ID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_DeletePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", ID);

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

        public static DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetAllPeople", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtPeople.Load(reader);
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
            return dtPeople;
        }

        public static bool IsPersonExist(int ID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_IsPersonExistByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", ID);

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

        public static bool IsPersonExist(string NationalNo)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_IsPersonExistByNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            int PersonID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_GetPersonIDByNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int ID))
                    {
                        PersonID = ID;
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
            return PersonID;
        }

        public static bool DoesPersonHasAnyLicense(int PersonID)
        {
            bool IsExist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_DoesPersonHasAnyLicenseByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        IsExist = true;
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
            return IsExist;
        }

        public static bool DoesPersonHasAnyLicense(string NationalNo)
        {
            bool IsExist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_DoesPersonHasAnyLicenseByNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        IsExist = true;
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
            return IsExist;
        }

        public static bool DoesPersonHasAnActiveLicenseClass(int PersonID, byte LicenseClassID)
        {
            bool IsExist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("sp_DoesPersonHasAnActiveLicenseClass", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        IsExist = true;
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
            return IsExist;
        }
    }
}
