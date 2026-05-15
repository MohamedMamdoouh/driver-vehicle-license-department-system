using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson PersonInfo;

        private enum enMode { AddNew, Update };
        enMode _Mode;

        private clsUser(int UserID, int PersonID, string Username, string Password, bool IsActive)
        {
                this.UserID = UserID;
                this.PersonID = PersonID;
                this.UserName = Username;
                this.Password = Password;
                this.IsActive = IsActive;
                PersonInfo = clsPerson.Find(this.PersonID);

                _Mode = enMode.Update;
        }

        public clsUser()
        {
                this.UserID = -1;
                this.PersonID = -1;
                this.UserName = "";
                this.Password = "";
                this.IsActive = false;
                this.PersonInfo = null;

                _Mode = enMode.AddNew;
        }

        public static clsUser Find(string Username, string Password)
        {
            int PersonID = -1, UserID = -1;
            bool IsActive = false;

            try
            {
                if (clsUserData.FindByUsernameAndPassword(Username, Password, ref UserID, ref PersonID, ref IsActive))
                {
                    return new clsUser(UserID, PersonID, Username, Password, IsActive);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetAllUsers()
        {
            try
            {
                return clsUserData.GetAllUsers();
            }
            catch
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            try
            {
                this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
                return (this.UserID != -1);
            }
            catch
            {
                return false;
            }
        }

        private bool _UpdatePerson()
        {
            try
            {
                return clsUserData.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
            }
            catch
            {
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                switch (this._Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return _UpdatePerson();

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static clsUser Find(int UserID)
        {
            try
            {
                int PersonID = -1;
                string Username = "", Password = "";
                bool IsActive = false;

                if (clsUserData.GetUserInfoByID(UserID, ref PersonID, ref Username, ref IsActive))
                {
                    return new clsUser(UserID, PersonID, Username, Password, IsActive);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static clsUser Find(string Username)
        {
            try
            {
                int UserID = -1, PersonID = -1;
                string Password = "";
                bool IsActive = false;

                if (clsUserData.GetUserInfoByUsername(Username, ref UserID, ref PersonID, ref Password, ref IsActive))
                {
                    return new clsUser(UserID, PersonID, Username, Password, IsActive);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteUser(int UserID)
        {
            try
            {
                return clsUserData.DeleteUser(UserID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsUserExistByUserID(int UserID)
        {
            try
            {
                return clsUserData.IsUserExistByPersonID(UserID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsUserExistByPerosnID(int PersonID)
        {
            try
            {
                return clsUserData.IsUserExistByPersonID(PersonID);
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateUserPassword(int UserID, string NewPassword, string OldPassword)
        {
            try
            {
                return clsUserData.UpdateUserPassword(UserID, NewPassword, OldPassword);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsUserExistByUsername(string UserName)
        {
            try
            {
                return clsUserData.IsUserExistByUsername(UserName);
            }
            catch
            {
                return false;
            }
        }
    }
}
