using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsTests
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public short? PersonTestScore { get; set; }
        public short? TestTotalScore { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }

        public clsTests()
        {
                this.TestID = -1;
                this.TestAppointmentID = -1;
                this.TestResult = false;
                this.Notes = string.Empty;
                this.CreatedByUserID = -1;
                this.PersonTestScore = null;
                this.TestTotalScore = null;
                this.TestAppointmentInfo = null;
        }

        public static sbyte GetPassedTestsCount(int LDLA_ID)
        {
            try
            {
                return clsTestsData.GetPassedTestsCount(LDLA_ID);
            }
            catch
            {
                return -1;
            }
        }

        public static bool IsPassedAllTests(int LDLA_ID)
        {
            try
            {
                return GetPassedTestsCount(LDLA_ID) == 3;
            }
            catch
            {
                return false;
            }
        }

        public static byte GetTotalTrialsPerTest(int LDLA_ID, clsTestType.enTestType TestTypeID)
        {
            try
            {
                return clsTestsData.GetTotalTrialsPerTest(LDLA_ID, (byte)TestTypeID);
            }
            catch
            {
                return 0;
            }
        }

        public static bool IsPersonPassedTest(int LDLA_ID, clsTestType.enTestType TestTypeID)
        {
            try
            {
                return clsTestsData.IsPersonPassedTest(LDLA_ID, (byte)TestTypeID);
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewTestResult()
        {
            try
            {
                this.TestID = clsTestsData.AddNewTestResult(this.TestAppointmentID, this.TestResult, this.Notes,
                                                            this.CreatedByUserID, this.PersonTestScore, this.TestTotalScore);
                return this.TestID != -1;
            }
            catch
            {
                return false;
            }
        }

        public static bool DidPersonAttendTest(int LDLA_ID, byte TestTypeID)
        {
            try
            {
                return clsTestsData.DidPersonAttendTest(LDLA_ID, TestTypeID);
            }
            catch
            {
                return false;
            }
        }

        public bool SetTestLocked()
        {
            try
            {
                return clsTestsData.SetTestLocked(this.TestAppointmentID);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPersonPassedTestForThisAppointment(int TestAppointmentID)
        {
            try
            {
                return clsTestsData.IsPersonPassedTestForThisAppointment(TestAppointmentID);
            }
            catch
            {
                return false;
            }
        }
    }
}
