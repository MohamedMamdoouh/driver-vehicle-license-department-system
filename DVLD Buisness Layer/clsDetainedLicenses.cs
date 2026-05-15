using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsDetainedLicenses
    {
        public enum enViolationType
        {
            Unknown = 0, Speeding = 1, RunningRedLight = 2, IllegalParking = 3, DrivingWithoutSeatbelt = 4, UsingMobilePhone = 5,
            DrivingWithoutValidLicense = 6, FailureToYield = 7, RecklessDriving = 8, ExpiredVehicleRegistration = 9,
            DrivingUnderInfluence = 10, DrivingWithoutLights = 11
        }

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }
        public enViolationType ViolationTypeID { get; set; }
        public string ViolationLocation { get; set; }
        public clsViolationTypes ViolationTypeInfo { get; set; }

        public clsDetainedLicenses()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
            this.ViolationTypeID = enViolationType.Speeding;
            this.ViolationLocation = "";
            ViolationTypeInfo = null;
        }

        private clsDetainedLicenses(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
             bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID,
             enViolationType ViolationTypeID, string ViolationLocation)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ViolationTypeID = ViolationTypeID;
            this.ViolationLocation = ViolationLocation;
            ViolationTypeInfo = clsViolationTypes.Find((byte)ViolationTypeID);
        }

        public static bool IsLicenseDetained(int LicesneID)
        {
            try
            {
                return clsDetainedLicensesData.IsLicenseDetained(LicesneID);
            }
            catch
            {
                return false;
            }
        }

        public string ViolationTypeString()
        {
            switch (this.ViolationTypeID)
            {
                case enViolationType.Speeding:
                    return "Speeding";

                case enViolationType.RunningRedLight:
                    return "Running a red light";

                case enViolationType.IllegalParking:
                    return "Illegal Parking";

                case enViolationType.DrivingWithoutSeatbelt:
                    return "Driving without seatbelt";

                case enViolationType.UsingMobilePhone:
                    return "Using mobile phone";

                case enViolationType.DrivingWithoutValidLicense:
                    return "Driving without valid license";

                case enViolationType.FailureToYield:
                    return "Failure to yield";

                case enViolationType.RecklessDriving:
                    return "Reckless driving";

                case enViolationType.ExpiredVehicleRegistration:
                    return "Expired vehicle registration";

                case enViolationType.DrivingUnderInfluence:
                    return "Driving under influence";

                case enViolationType.DrivingWithoutLights:
                    return "Driving without lights";

                default:
                    return "Unknown";
            }
        }

        public bool DetainDrivingLicense()
        {
            try
            {
                this.DetainID = clsDetainedLicensesData.DetainDrivingLicense(this.LicenseID, this.DetainDate, this.FineFees,
                    this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID,
                    (byte)this.ViolationTypeID, this.ViolationLocation);

                return this.DetainID != -1;
            }
            catch
            {
                return false;
            }
        }

        public static clsDetainedLicenses Find(int LicenseID)
        {
            try
            {
                int DetainID = -1;
                DateTime DetainDate = DateTime.Now;
                decimal FineFees = 0;
                int CreatedByUserID = -1;
                bool IsReleased = false;
                DateTime? ReleaseDate = DateTime.Now;
                int? ReleasedByUserID = -1;
                int? ReleaseApplicationID = -1;
                byte ViolationTypeID = 0;
                string ViolationLocation = "";

                if (clsDetainedLicensesData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees,
                                            ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID,
                                            ref ReleaseApplicationID, ref ViolationTypeID, ref ViolationLocation))
                    return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                                                   ReleaseDate, ReleasedByUserID, ReleaseApplicationID,
                                                   (clsDetainedLicenses.enViolationType)ViolationTypeID, ViolationLocation);

                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetAllDetainedLicenses()
        {
            try
            {
                return clsDetainedLicensesData.GetAllDetainedLicensesData();
            }
            catch
            {
                return null;
            }
        }
    }
}
