using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsPerson PersonInfo { get; set; }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            this.PersonInfo = null;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPerson.Find(PersonID);
        }

        public static DataTable GetAllDrivers()
        {
            try
            {
                return clsDriversData.GetAllDrivers();
            }
            catch
            {
                return null;
            }
        }

        public static clsDriver GetDriverInfoByDriverID(int DriverID)
        {
            try
            {
                int PersonID = -1, CreatedByUserID = -1;
                DateTime CreationDate = DateTime.Now;

                if (clsDriversData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreationDate))
                    return new clsDriver(DriverID, PersonID, CreatedByUserID, CreationDate);

                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static clsDriver GetDriverInfoByPersonID(int PersonID)
        {
            try
            {
                int DriverID = -1, CreatedByUserID = -1;
                DateTime CreationDate = DateTime.Now;

                if (clsDriversData.GetDriverInfoByPerosnID(PersonID, ref DriverID, ref CreatedByUserID, ref CreationDate))
                    return new clsDriver(DriverID, PersonID, CreatedByUserID, CreationDate);

                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewDriver()
        {
            try
            {
                this.DriverID = clsDriversData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
                return this.DriverID != -1;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateDriver()
        {
            try
            {
                return clsDriversData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDriver()
        {
            try
            {
                return clsDriversData.DeleteDriver(this.DriverID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDriverExistByPersonID(int PersonID)
        {
            try
            {
                return clsDriversData.IsDriverExistByPersonID(PersonID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDriverExistByDriverID(int DriverID)
        {
            try
            {
                return clsDriversData.IsDriverExistByDriverID(DriverID);
            }
            catch
            {
                return false;
            }
        }
    }
}
