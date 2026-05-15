using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public clsLocalLicense LocalLicenseInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            DriverInfo = null;
            IssuedUsingLocalLicenseID = -1;
            LocalLicenseInfo = null;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
            this.CreatedByUserID = -1;
        }

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
                                        DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            DriverInfo = clsDriver.GetDriverInfoByDriverID(this.DriverID);
            LocalLicenseInfo = clsLocalLicense.GetLicenseInfoByID(this.IssuedUsingLocalLicenseID);
        }

        public static DataTable GetAllInternationalLicensesForDriver(int PersonID)
        {
            try
            {
                return clsInternationalLicenseData.GetAllInternationalLicensesForPerson(PersonID);
            }
            catch
            {
                return null;
            }
        }

        public static clsInternationalLicense GetInternationalLicesneInfoByID(int InternationalLicenseID)
        {
            try
            {
                int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
                DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
                bool IsActive = false;

                if (clsInternationalLicenseData.GetInternationalLicesneInfoByID(InternationalLicenseID, ref ApplicationID,
                   ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))

                    return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                                       IssueDate, ExpirationDate, IsActive, CreatedByUserID);

                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsInternationalLicenseExistByPersonID(int PersonID)
        {
            try
            {
                return clsInternationalLicenseData.IsInternationalLicenseExistByPersonID(PersonID);
            }
            catch
            {
                return false;
            }
        }

        public bool IssueInternationalDrivingLicense()
        {
            try
            {
                this.InternationalLicenseID = clsInternationalLicenseData.IssueInternationalDrivingLicense(this.ApplicationID, this.DriverID,
                                              this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
                return this.InternationalLicenseID != -1;
            }
            catch
            {
                return false;
            }
        }

        public bool DeactivateCurrentLicense()
        {
            try
            {
                return clsInternationalLicenseData.DeactivateInternationalLicense(this.InternationalLicenseID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsInternationalLicenseActive(int PersonID)
        {
            try
            {
                return clsInternationalLicenseData.IsInternationalLicenseActive(PersonID);
            }
            catch
            {
                return false;
            }
        }

        public static DataTable GetAllInternationalLicenses()
        {
            try
            {
                return clsInternationalLicenseData.GetAllInternationalLicenses();
            }
            catch
            {
                return null;
            }
        }
    }
}
