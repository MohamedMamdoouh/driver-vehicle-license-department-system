using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsLocalLicenseClass
    {
        public byte LicenseClassID { get; set; }
        public string LicenseClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        private clsLocalLicenseClass(byte LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge,
                                byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static clsLocalLicenseClass FindByLicenseClassID(byte LicenseClassID)
        {
            try
            {
                string LicenseClassName = "", ClassDescription = "";
                byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
                decimal ClassFees = 0;

                if (clsLicenseClassData.GetLicenseClassInfo(LicenseClassID, ref LicenseClassName, ref ClassDescription,
                                                            ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                    return new clsLocalLicenseClass(LicenseClassID, LicenseClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);

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

        public static clsLocalLicenseClass FindByLDLA_ID(int LDLA_ID)
        {
            try
            {
                string LicenseClassName = "", ClassDescription = "";
                byte LicenseClassID = 0, MinimumAllowedAge = 0, DefaultValidityLength = 0;
                decimal ClassFees = 0;

                if (clsLicenseClassData.GetLicenceClassInfoByLDL_ID(LDLA_ID, ref LicenseClassID, ref LicenseClassName, ref ClassDescription,
                                                            ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                    return new clsLocalLicenseClass(LicenseClassID, LicenseClassName, ClassDescription,
                        MinimumAllowedAge, DefaultValidityLength, ClassFees);

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

        public static DataTable GetAllLicenseClassesInfo()
        {
            try
            {
                return clsLicenseClassData.GetAllLicenseClassesNames();
            }
            catch
            {
                return null;
            }
        }

        public static decimal GetLicenseClassFees(byte LicenseClassID)
        {
            try
            {
                return clsLicenseClassData.GetLicenseClassFees(LicenseClassID);
            }
            catch
            {
                return -1;
            }
        }
    }
}
