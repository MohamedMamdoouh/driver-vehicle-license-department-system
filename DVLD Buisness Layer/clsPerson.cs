using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsPerson
    {
        public enum enGendor { Male = 0, Female = 1 };
        private enum enMode { AddNew, Update };
        private enMode _Mode;

        public int ID { private set; get; } // Prevent misuse of ID
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public enGendor Gendor { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }
        public string FullName { set; get; }

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
                     clsPerson.enGendor Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.FullName = FirstName + " " + SecondName + " " + (string.IsNullOrEmpty(ThirdName) ? "" : ThirdName) + " " + LastName;

            _Mode = enMode.Update;
        }

        public clsPerson()
        {
            this.ID = -1;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.Today;
            this.Gendor = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.NationalityCountryID = -1;
            this.ImagePath = string.Empty;
            this.FullName = string.Empty;

            _Mode = enMode.AddNew;
        }

        private bool _AddNewPerson()
        {
            try
            {
                this.ID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                                                       (byte)this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

                return (this.ID != -1);
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
                return clsPersonData.UpdatePerson(this.ID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                                    this.DateOfBirth, (byte)this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
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
                        if (_AddNewPerson())
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

        public static clsPerson Find(int ID)
        {
            try
            {
                string NationalNo = string.Empty, FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty,
                LastName = string.Empty; DateTime DateOfBirth = DateTime.Today;
                byte Gendor = 0; string Address = string.Empty, Phone = string.Empty, Email = string.Empty;
                int NationalityCountryID = -1; string ImagePath = string.Empty;

                if (clsPersonData.GetPerosnInfoByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                                      ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
                {
                    return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (clsPerson.enGendor)Gendor,
                                        Address, Phone, Email, NationalityCountryID, ImagePath);
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

        public static clsPerson Find(string NationalNo)
        {
            try
            {
                string FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty,
                LastName = string.Empty; DateTime DateOfBirth = DateTime.Today;
                byte Gendor = 0; string Address = string.Empty, Phone = string.Empty, Email = string.Empty;
                int NationalityCountryID = -1, ID = -1; string ImagePath = string.Empty;

                if (clsPersonData.GetPerosnInfoByNationalNo(NationalNo, ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                                          ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
                {
                    return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (clsPerson.enGendor)Gendor,
                                        Address, Phone, Email, NationalityCountryID, ImagePath);
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

        public static bool DeletePerson(int ID)
        {
            try
            {
                return clsPersonData.DeletePerson(ID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPersonExist(int ID)
        {
            try
            {
                return clsPersonData.IsPersonExist(ID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPersonExist(string NationalNo)
        {
            try
            {
                return clsPersonData.IsPersonExist(NationalNo);
            }
            catch
            {
                return false;
            }
        }

        public static DataTable GetAllPeople()
        {
            try
            {
                return clsPersonData.GetAllPeople();
            }
            catch
            {
                return null;
            }
        }

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            try
            {
                return clsPersonData.GetPersonIDByNationalNo(NationalNo);
            }
            catch
            {
                return -1;
            }
        }

        public static bool DoesPersonHasAnyLicense(int PersonID)
        {
            try
            {
                return clsPersonData.DoesPersonHasAnyLicense(PersonID);
            }
            catch
            {
                return false;
            }
        }

        public static bool DoesPersonHasAnyLicense(string NationalNo)
        {
            try
            {
                return clsPersonData.DoesPersonHasAnyLicense(NationalNo);
            }
            catch
            {
                return false;
            }
        }

        public static bool DoesPersonHasAnActiveLicenseClass(int PersonID, byte LicenseClassID)
        {
            try
            {
                return clsPersonData.DoesPersonHasAnActiveLicenseClass(PersonID, LicenseClassID);
            }
            catch
            {
                return false;
            }
        }
    }
}
