using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsLocalLicense
    {
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public byte LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public clsDriver DriverInfo { get; set; }
        public clsLocalLicenseClass LicenseClassInfo { get; set; }
        public bool IsDetained { get; set; }

        public clsLocalLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = 0;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = null;
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
            this.DriverInfo = null;
            this.LicenseClassInfo = null;
            this.IsDetained = false;
        }

        private clsLocalLicense(int LicenseID, int ApplicationID, int DriverID, byte LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
                            string Notes, decimal PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.DriverInfo = clsDriver.GetDriverInfoByDriverID(DriverID);
            this.LicenseClassInfo = clsLocalLicenseClass.FindByLicenseClassID(LicenseClassID);
            this.IsDetained = clsDetainedLicenses.IsLicenseDetained(LicenseID);
        }

        public static clsLocalLicense GetLicenseInfoByID(int LicenseID)
        {
            try
            {
                int ApplicationID = -1, DriverID = -1;
                DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
                string Notes = "";
                decimal PaidFees = 0;
                bool IsActive = false;
                byte LicenseClassID = 0, IssueReason = 1;
                int CreatedByUserID = -1;

                if (clsLocalLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                                                    ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                                                    ref IssueReason, ref CreatedByUserID))

                    return new clsLocalLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes,
                                        PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);

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

        public static clsLocalLicense GetLicenseInfoByLDLA_ID(int LDLA_ID)
        {
            try
            {
                int LicenseID = -1, ApplicationID = -1, DriverID = -1;
                DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
                string Notes = "";
                decimal PaidFees = 0;
                bool IsActive = false;
                byte IssueReason = 0, LicenseClassID = 0;
                int CreatedByUserID = -1;

                if (clsLocalLicenseData.GetLicenseInfoByLDLA_ID(LDLA_ID, ref LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                                                    ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                                                    ref IssueReason, ref CreatedByUserID))

                    return new clsLocalLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes,
                                        PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);

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

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            try
            {
                return clsLocalLicenseData.IsLicenseExistByPersonID(PersonID, LicenseClassID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsLicenseExistByLDLA_ID(int LDLA_ID)
        {
            try
            {
                return clsLocalLicenseData.IsLicenseExistByLDLA_ID(LDLA_ID);
            }
            catch
            {
                return false;
            }
        }

        public bool IssueLocalDrivingLicense()
        {
            try
            {
                this.LicenseID = clsLocalLicenseData.IssueDrivingLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate,
                                                                     this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
                return this.LicenseID != -1;
            }
            catch
            {
                return false;
            }
        }

        public bool RenewLocalDrivingLicesne(int OldLicenseID)
        {
            try
            {
                this.LicenseID = clsLocalLicenseData.RenewDrivingLicense(OldLicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID,
                                                                 this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive,
                                                                (byte)this.IssueReason, this.CreatedByUserID);
                return this.LicenseID != -1;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable GetAllLocalLicensesForDriver(int PersonID)
        {
            try
            {
                return clsLocalLicenseData.GetAllLocalLicensesForDriver(PersonID);
            }
            catch
            {
                return null;
            }
        }

        public string GetIssueReasonText()
        {
            try
            {
                switch (this.IssueReason)
                {
                    case clsLocalLicense.enIssueReason.FirstTime:
                        return "First Time";

                    case clsLocalLicense.enIssueReason.Renew:
                        return "Renew";

                    case clsLocalLicense.enIssueReason.DamagedReplacement:
                        return "Replacement for Damaged";

                    case clsLocalLicense.enIssueReason.LostReplacement:
                        return "Replacement for Lost";

                    default:
                        return "Unknown";
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        public bool IsLicenseExpired()
        {
            try
            {
                return this.ExpirationDate < DateTime.Now;
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
                return clsLocalLicenseData.DeactivateLicense(this.LicenseID);
            }
            catch
            {
                return false;
            }
        }

        public bool ReplaceLocalDrivingLicense(int OldLicenseID)
        {
            try
            {
                this.LicenseID = clsLocalLicenseData.ReplaceDrivingLicense(OldLicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID,
                                  this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
                return this.LicenseID != -1;
            }
            catch
            {
                return false;
            }
        }

        public bool ReleaseDrivingLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            try
            {
                return clsLocalLicenseData.ReleaseDrivingLicense(this.LicenseID, ReleasedByUserID, ReleaseApplicationID);
            }
            catch
            {
                return false;
            }
        }
    }
}
