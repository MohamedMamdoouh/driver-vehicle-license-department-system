using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsTestAppointment
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        public int LDLA_ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int? RetakeTestApplictionID { get; set; }
        public clsApplication RetakeTestAppInfo { get; set; }

        public clsTestAppointment()
        {
            _Mode = enMode.AddNew;

            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.LDLA_ID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = true;
            this.RetakeTestApplictionID = -1;
            this.RetakeTestAppInfo = null;
        }

        private clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LDLA_ID, DateTime AppointmentDate,
                                  decimal PaidFees, int CreatedByUserID, bool IsLocked, int? RetakeTestApplictionID)
        {
            _Mode = enMode.Update;

            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LDLA_ID = LDLA_ID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplictionID = RetakeTestApplictionID;
            this.RetakeTestAppInfo = RetakeTestApplictionID.HasValue ?
                clsApplication.FindApplicationByApplicationID(RetakeTestApplictionID.Value) : null;
        }

        public static DataTable GetAllAppointmentsForTest(int LDLA_ID, byte TestTypeID)
        {
            try
            {
                return clsTestAppointmentsData.GettAllApointmentsForTest(LDLA_ID, TestTypeID);
            }
            catch
            {
                return null;
            }
        }

        public static bool IsPersonHasActiveTestAppointment(int LDLA_ID, byte TestTypeID)
        {
            try
            {
                return clsTestAppointmentsData.IsPersonHasActiveTestAppointment(LDLA_ID, TestTypeID);
            }
            catch
            {
                return false;
            }
        }

        private bool _AddNewTestAppointment()
        {
            try
            {
                this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment((byte)this.TestTypeID, this.LDLA_ID, this.AppointmentDate,
                    this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplictionID);

                return (this.TestAppointmentID != -1);
            }
            catch
            {
                return false;
            }
        }

        private bool _UpdateTestAppointment()
        {
            try
            {
                return clsTestAppointmentsData.UpdateTestAppointment(this.TestAppointmentID, this.AppointmentDate);
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
                switch (_Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewTestAppointment())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return _UpdateTestAppointment();

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static clsTestAppointment GetTestAppointmentInfoByID(int TestAppointmentID)
        {
            try
            {
                byte TestTypeID = 0;
                int LDLA_ID = -1;
                DateTime AppointmentDate = DateTime.Now;
                decimal PaidFees = 0;
                int CreatedByUserID = -1;
                bool IsLocked = false;
                int? RetakeTestAppointmentID = null;

                if (clsTestAppointmentsData.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LDLA_ID,
                    ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestAppointmentID))

                    return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LDLA_ID, AppointmentDate,
                                                  PaidFees, CreatedByUserID, IsLocked, RetakeTestAppointmentID);

                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsPersonHasAnyTestAppointments(int LDLA_ID)
        {
            try
            {
                return clsTestAppointmentsData.IsPersonHasAnyTestAppointments(LDLA_ID);
            }
            catch
            {
                return false;
            }
        }
    }
}
