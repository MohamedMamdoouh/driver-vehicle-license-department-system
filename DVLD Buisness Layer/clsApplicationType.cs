using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsApplicationType
    {
        public clsApplication.enApplicationType ApplicationTypeID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private clsApplicationType(clsApplication.enApplicationType Type, string Title, decimal Fees)
        {
            this.ApplicationTypeID = Type;
            this.Title = Title;
            this.Fees = Fees;
            _Mode = enMode.Update;
        }

        public clsApplicationType()
        {
            this.ApplicationTypeID = clsApplication.enApplicationType.NewLocalDrivingLicense;
            this.Title = "";
            this.Fees = 0;
            _Mode = enMode.AddNew;
        }

        public static DataTable GetAllApplicationTypes()
        {
            try
            {
                return clsApplicationTypesData.GetAllApplicationTypes();
            }
            catch
            {
                return null;
            }
        }

        public static clsApplicationType Find(clsApplication.enApplicationType ApplicationType)
        {
            try
            {
                string Title = "";
                decimal Fees = 0;

                if (clsApplicationTypesData.GetApplicationTypeByID((byte)ApplicationType, ref Title, ref Fees))
                {
                    return new clsApplicationType(ApplicationType, Title, Fees);
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

        private bool _AddNewApplicationType()
        {
            try
            {
                this.ApplicationTypeID = (clsApplication.enApplicationType)clsApplicationTypesData.AddNewApplicationType(this.Title, this.Fees);
                return this.ApplicationTypeID != 0;
            }
            catch
            {
                return false;
            }
        }

        private bool _UpdateApplicationType()
        {
            try
            {
                return clsApplicationTypesData.UpdateApplicationType((int)this.ApplicationTypeID, this.Title, this.Fees);
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
                        if (_AddNewApplicationType())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return _UpdateApplicationType();

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
