using System;
using System.Configuration;

namespace DVLD_DataAccess_Layer
{
    internal static class clsDataAccessSettings
    {
        //public static string ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"]?.ConnectionString;
        public static string ConnectionString = "Server=Localhost;Database=DVLD;Integrated Security=true;";
    }
}
