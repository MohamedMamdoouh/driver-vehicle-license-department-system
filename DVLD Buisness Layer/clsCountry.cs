using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsCountry
    {
        public static DataTable GetAllCountries()
        {
            try
            {
                return clsCountryDataAccess.GetAllCountries();
            }
            catch
            {
                return null;
            }
        }

        public static string GetCountryName(int ID)
        {
            try
            {
                return clsCountryDataAccess.GetCountryByID(ID);
            }
            catch
            {
                return null;
            }
        }

        public static int GetCountryID(string CountryName)
        {
            try
            {
                return clsCountryDataAccess.GetCountryID(CountryName);
            }
            catch
            {
                return -1;
            }
        }
    }
}
