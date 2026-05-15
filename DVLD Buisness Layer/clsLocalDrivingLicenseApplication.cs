using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        private new enum enMode { AddNew, Update };
        private enMode _Mode;

        public int LDLA_ID { get; set; }
        public byte LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            LDLA_ID = -1;
            LicenseClassID = 0;

            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = clsApplication.enApplicationType.NewInternationalLicense;
            this.ApplicationStatus = clsApplication.enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int lDLA_ID, byte ClassLicenseID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
                                clsApplication.enApplicationType ApplicationTypeID, clsApplication.enApplicationStatus ApplicationStatus,
                                DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
                                : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus,
                                LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LDLA_ID = lDLA_ID;
            this.LicenseClassID = ClassLicenseID;

            _Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            try
            {
                this.LDLA_ID = clsLocalDrivingLicenseApplictionData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);
                return this.LDLA_ID != -1;
            }
            catch
            {
                return false;
            }
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            try
            {
                return clsLocalDrivingLicenseApplictionData.UpdateLocalDrivingLicenseApplication(LDLA_ID, this.ApplicationID, this.LicenseClassID);
            }
            catch
            {
                return false;
            }
        }

        public static DataTable GetLDLAData()
        {
            try
            {
                return clsLocalDrivingLicenseApplictionData.GetLDLAData();
            }
            catch
            {
                return null;
            }
        }

        public static clsLocalDrivingLicenseApplication GetLocalDrivingLicenseApplicationByLDLA_ID(int LDLA_ID)
        {
            try
            {
                int ApplicationID = -1;
                byte LicenseClassID = 0;
                bool IsFound = clsLocalDrivingLicenseApplictionData.GetLocalDrivingLicenseApplicationInfoByID(LDLA_ID, ref ApplicationID, ref LicenseClassID);

                if (IsFound)
                {
                    clsApplication Application = clsApplication.FindApplicationByApplicationID(ApplicationID);
                    return new clsLocalDrivingLicenseApplication(LDLA_ID, LicenseClassID, ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                                                      Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate,
                                                      Application.PaidFees, Application.CreatedByUserID);
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

        public new bool Save()
        {
            try
            {
                base.Mode = (clsApplication.enMode)_Mode;

                if (!base.Save())
                    return false;

                switch (_Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return _UpdateLocalDrivingLicenseApplication();

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public new bool Delete()
        {
            try
            {
                bool IsDeleted = clsLocalDrivingLicenseApplictionData.DeleteLocalDrivingLicenseApplication(this.LDLA_ID);

                if (!IsDeleted)
                    return false;

                return base.Delete();
            }
            catch
            {
                return false;
            }
        }
    }

}
