using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Project.Global
{
    public class clsFormat
    {
        public static string ToShortDateString(DateTime Date)
        {
            return Date.ToString("dd/MM/yyyy");
        }

        public static string ToShortDateString()
        {
            return "dd/MM/yyyy";
        }

        public static string ToShortMoneyString(decimal Money)
        {
            return Money.ToString("F2");
        }

        public static string ToShortMoneyString()
        {
            return "F2";
        }
    }
}
