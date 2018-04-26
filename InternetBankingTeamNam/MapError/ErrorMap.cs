using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.MapError
{
    class ErrorMap
    {
        public static Dictionary<string, Error> MapErrors = new Dictionary<string, Error>();

        static ErrorMap()
        {
            Error username = new Error("USERNAME SHOULD NOT BE EMPTY", "USERNAME NOT ENOUGH LENGTH (6 CHARACTER)", "USERNAME INCORRECT CHARACTER (a-z, A-Z, 0-9)");
            Error password = new Error("PASSWORD SHOULD NOT BE EMPTY", "PASSWORD NOT ENOUGH LENGTH (6 CHARACTER)", "PASSWORD INCORRECT CHARACTER (0-9, a-z, A-Z, ...");
            Error fullname = new Error("FULL NAME SHOULD NOT BE EMPTY", "FULL NAME NOT ENOUGH LENGTH (10 CHARACTER)", "FULL NAME INCORRECT CHARACTER (A-Z, a-z)");
            Error birthday = new Error("BIRTHDAY SHOULD NOT BE EMPTY", "DO NOT ENOUGH FOR SIGN UP ( 18+ )", "BIRTHDAT INCORRECT FORMART (dd/(-, .)mm/(-, .)yyyy) ");
            Error phone = new Error("PHONE SHOULD NOT BE EMPTY", "PHONE NOT ENOUGH LENGTH (10 CHARACTER)", "PHONE INCORRECT CHARACTER ( 0- 9 )");
            Error idNumber = new Error("ID NUMBER SHOULD NOT BE EMPTY", "ID NUMBER NOT ENOUGH LENGTH (9 CHARACTER)", "ID NUMBER INCORRECT CHARACTER (0 - 9)");
            Error email = new Error("EMAIL SHOULD NOT BE EMPTY", "EMAIL NOT ENOUGH LENGTH (8 CHARACTER)", "EMAIL INCORRECT FORMART(abcxxx@example.com)");

            MapErrors.Add("username", username);
            MapErrors.Add("password", password);
            MapErrors.Add("fullName", fullname);
            MapErrors.Add("birthday", birthday);
            MapErrors.Add("phone", phone);
            MapErrors.Add("idNumber", idNumber);
            MapErrors.Add("email", email);
        }
    }
}
