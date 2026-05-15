using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsApplication
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }
        public enum enApplicationType
        {
            NewLocalDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }

        public enum enMode { AddNew, Update };
        public enMode Mode;

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public enApplicationType ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser User;
        public clsPerson Person;

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = enApplicationType.NewLocalDrivingLicense;
            this.ApplicationStatus = enApplicationStatus.New;
            User = null;
            Person = null;

            Mode = enMode.AddNew;
        }

        protected clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, enApplicationType ApplicationTypeID,
                               enApplicationStatus ApplicationStatusID, DateTime LastStatusDate, decimal PaidFees,
                               int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatusID;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            Person = clsPerson.Find(ApplicantPersonID);
            User = clsUser.Find(CreatedByUserID);

            Mode = enMode.Update;
        }

        public static clsApplication FindApplicationByApplicationID(int ApplicationID)
        {
            try
            {
                int ApplicantPersonID = -1, CreatedByUserID = -1;
                decimal PaidFees = 0;
                byte ApplicationTypeID = 1, ApplicationStatusID = 1;
                DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;

                if (clsApplicationData.GetApplicationInfoByApplicationID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
                                                         ref ApplicationStatusID, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                    return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate,
                                             (enApplicationType)ApplicationTypeID, (enApplicationStatus)ApplicationStatusID,
                                             LastStatusDate, PaidFees, CreatedByUserID);
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

        public static clsApplication FindApplicationByLocalLicenseApplicationID(int LocalLicenseApplicationID)
        {
            try
            {
                int ApplicantPersonID = -1, CreatedByUserID = -1, ApplicationID = -1;
                byte ApplicationStatusID = 1, ApplicationTypeID = 1;
                decimal PaidFees = 0;
                DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;

                if (clsApplicationData.GetApplicationInfoByLocalLicenseApplicationID(LocalLicenseApplicationID, ref ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
                                                         ref ApplicationStatusID, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                    return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate,
                                             (enApplicationType)ApplicationTypeID, (enApplicationStatus)ApplicationStatusID,
                                             LastStatusDate, PaidFees, CreatedByUserID);
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

        public static DataTable GetAllApplications()
        {
            try
            {
                return clsApplicationData.GetAllApplications();
            }
            catch
            {
                return null;
            }
        }

        private bool _AddNewApplication()
        {
            try
            {
                this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, (byte)this.ApplicationTypeID,
                                    (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
                return (this.ApplicationID != -1);
            }
            catch
            {
                return false;
            }
        }

        private bool _UpdateApplication()
        {
            try
            {
                return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                   (byte)this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
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
                switch (this.Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return _UpdateApplication();

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static int GetActiveApplicationID(int PersonID, byte ApplicationTypeID)
        {
            try
            {
                return clsApplicationData.GetActiveApplicationID(PersonID, ApplicationTypeID);
            }
            catch
            {
                return -1;
            }
        }

        public static int GetActiveApplication_ForLicenseClass(int PersonID, byte LicenseClassID)
        {
            try
            {
                return clsApplicationData.GetActiveApplicationID_ForLicenseClass(PersonID, LicenseClassID);
            }
            catch
            {
                return -1;
            }
        }

        public static bool DoesPersonHasActiveApplication(int PersonID, byte ApplicatiobTypeID)
        {
            try
            {
                return clsApplicationData.DoesPersonHasActiveApplicaton(PersonID, ApplicatiobTypeID);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                return clsApplicationData.DeleteApplication(this.ApplicationID);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateStatus(int ApplicationID, byte NewStatus)
        {
            try
            {
                return clsApplicationData.UpdateStatus(ApplicationID, NewStatus);
            }
            catch
            {
                return false;
            }
        }

        public bool SetComplete()
        {
            try
            {
                return clsApplicationData.SetComplete(this.ApplicationID);
            }
            catch
            {
                return false;
            }
        }

        public bool Cancel()
        {
            try
            {
                return clsApplicationData.Cancel(this.ApplicationID);
            }
            catch
            {
                return false;
            }
        }

        public static string GetApplicationTypeFullName(clsApplication.enApplicationType ApplicationType)
        {
            switch (ApplicationType)
            {
                case clsApplication.enApplicationType.NewInternationalLicense:
                    return "New International License";

                case clsApplication.enApplicationType.NewLocalDrivingLicense:
                    return "New Local Driving License";

                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                    return "Release Detained DrivingLicsense";

                case clsApplication.enApplicationType.RenewDrivingLicense:
                    return "Renew Driving License";

                case clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense:
                    return "Replacement For Damaged Driving License";

                case clsApplication.enApplicationType.ReplacementForLostDrivingLicense:
                    return "Replacement For Lost Driving License";

                case clsApplication.enApplicationType.RetakeTest:
                    return "Retake Test";

                default:
                    return null;
            }
        }
    }
}
