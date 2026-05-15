using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsViolationTypes
    {
        public byte ViolationTypeID { get; set; }
        public string Name { get; set; }
        public decimal FineFees { get; set; }
        public string Description { get; set; }

        public clsViolationTypes()
        {
            this.ViolationTypeID = 0;
            this.Name = "";
            this.FineFees = 0;
            this.Description = "";
        }

        private clsViolationTypes(byte ViolationTypeID, string Name, decimal FineFees, string Description)
        {
            this.ViolationTypeID = ViolationTypeID;
            this.Name = Name;
            this.FineFees = FineFees;
            this.Description = Description;
        }

        public static clsViolationTypes Find(byte ViolationTypeID)
        {
            try
            {
                string Name = "", Description = "";
                decimal FindFees = 0;

                if (clsViolationTypesData.GetViolationTypeInfoByID(ViolationTypeID, ref Name, ref FindFees, ref Description))
                    return new clsViolationTypes(ViolationTypeID, Name, FindFees, Description);

                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
