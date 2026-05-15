using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsTestType
    {
        public enum enTestType { Unknown = 0, VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        public clsTestType.enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }
        public byte DurationMinutes { get; set; }
        public byte PassingPercentage { get; set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private clsTestType(clsTestType.enTestType ID, string Title, string Description, decimal Fees, byte DurationMinutes, byte PassingPercentage)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            this.DurationMinutes = DurationMinutes;
            this.PassingPercentage = PassingPercentage;

            _Mode = enMode.Update;
        }

        public clsTestType()
        {
            this.ID = clsTestType.enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            this.DurationMinutes = 0;
            this.PassingPercentage = 0;

            _Mode = enMode.AddNew;
        }

        public static DataTable GetAllTestTypes()
        {
            try
            {
                return clsTestTypesData.GetAllTestTypesData();
            }
            catch
            {
                return null;
            }
        }

        public static clsTestType Find(clsTestType.enTestType ID)
        {
            try
            {
                string Title = "", Description = "";
                decimal Fees = 0;
                byte DurationMinutes = 0, PassingPercentage = 0;

                if (clsTestTypesData.GetTestTypeByID((int)ID, ref Title, ref Description, ref Fees, ref DurationMinutes, ref PassingPercentage))
                {
                    return new clsTestType(ID, Title, Description, Fees, DurationMinutes, PassingPercentage);
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

        private bool _AddNewTestType()
        {
            try
            {
                this.ID = (clsTestType.enTestType)clsTestTypesData.AddNewTestType(this.Title, this.Description, this.Fees, this.DurationMinutes, this.PassingPercentage);
                return this.Title != "";
            }
            catch
            {
                return false;
            }
        }

        private bool _UpdateTestType()
        {
            try
            {
                return clsTestTypesData.UpdateTestType((byte)this.ID, this.Title, this.Description, this.Fees, this.DurationMinutes, this.PassingPercentage);
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
                        if (_AddNewTestType())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return _UpdateTestType();

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
