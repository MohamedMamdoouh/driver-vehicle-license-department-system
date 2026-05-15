using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsUserData
    {
        public static bool FindByUsernameAndPassword(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool IsFound = false;
            string query = "SELECT * FROM dbo.fn_FindUserByCredentials(@UserName, @Password)";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserID = (int)reader["UserID"];
                            PersonID = (int)reader["PersonID"];
                            IsActive = (bool)reader["IsActive"];

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

        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();

            string query = @"SELECT * FROM dbo.fn_GetAllUsers();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtUsers.Load(reader);
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

            return dtUsers;
        }

        public static bool GetUserInfoByID(int UserID, ref int PersonID, ref string Username, ref bool IsActive)
        {
            bool IsFound = false;
            string query = "SELECT * FROM dbo.fn_GetUserInfoByID(@UserID)";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            Username = Convert.ToString(reader["Username"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);

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

        public static bool GetUserInfoByUsername(string Username, ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            string query = "SELECT * FROM dbo.fn_GetUserInfoByUsername(@Username)";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserID = Convert.ToInt32(reader["UserID"]);
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            Password = Convert.ToString(reader["Password"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);

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

        public static int AddNewUser(int PersonID, string Username, string Password, bool IsActive)
        {
            int UserID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_AddNewUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    SqlParameter OutputParmeter = new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(OutputParmeter);

                    connection.Open();
                    command.ExecuteNonQuery();
                    UserID = (int)OutputParmeter.Value;
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

            return UserID;
        }

        public static bool UpdateUser(int UserID, string Username, string Password, bool IsActive)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);

            }
            catch (Exception ex)
            {
                clsLoggingData.LogException(ex.ToString(), EventLogEntryType.Error);
                throw;
            }

            return RowsAffected > 0;
        }

        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_DeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
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

        public static bool IsUserExistByUserID(int UserID)
        {
            bool IsFound = false;
            string query = "SELECT dbo.fn_IsUserExistByUserID(@UserID)";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        IsFound = Convert.ToBoolean(result);
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

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool IsFound = false;
            string query = "SELECT dbo.fn_IsUserExistByPersonID(@PersonID)";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    connection.Open();


                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        IsFound = Convert.ToBoolean(result);
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

        public static bool IsUserExistByUsername(string Username)
        {
            bool IsFound = false;
            string query = "SELECT dbo.fn_IsUserExistByUsername(@Username)";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        IsFound = Convert.ToBoolean(result);
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

        public static bool UpdateUserPassword(int UserID, string NewPassword, string OldPassword)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("dbo.sp_UpdateUserPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@NewPassword", NewPassword);
                    command.Parameters.AddWithValue("@OldPassword", OldPassword);

                    var OutputParameter = new SqlParameter("@RowsAffected", SqlDbType.Int) {Direction = ParameterDirection.Output };
                    command.Parameters.Add(OutputParameter);

                    connection.Open();
                    command.ExecuteNonQuery();

                    RowsAffected = (int)OutputParameter.Value;
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