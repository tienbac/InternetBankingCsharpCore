using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Controller
{
    class Convert
    {
        public static DateTime InputDate(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return dt;
        }

        public static DateTime InputDate2(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return dt;
        }

        public static DateTime InputDate3(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            return dt;
        }
    }
}
