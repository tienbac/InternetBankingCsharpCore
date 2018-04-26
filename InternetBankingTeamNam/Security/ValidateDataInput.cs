using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Security
{
    class ValidateDataInput
    {
        //Validate Input Gender:
        public static bool Gender(string inputGender, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(inputGender))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|         GENDER SHOULD NOT BE EMPTY         |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            if (Regex.Match(inputGender, @"[0-9]", RegexOptions.ECMAScript).Success)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|         GENDER SHOULD'N BE DIGITS!         |\n" +
                               "|    (Ex: male/nam, female/nữ, other/khác)   |\n" +
                               "+--------------------------------------------+";
                return false;
            }

            if (inputGender.Length < 2)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|          GENDER NOT ENOUGH LENGTH          |\n" +
                               "|    (Ex: male/nam, female/nữ, other/khác)   |\n" +
                               "+--------------------------------------------+";
                return false;
            }

            if (inputGender.Length > 6)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|             GENDER IS TOO LONG!            |\n" +
                               "|    (Ex: male/nam, female/nữ, other/khác)   |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else
            {
                return true;
            }
        }

        // Convert Gender from string to int
        public static int ExGender(string input)
        {
            int gender = -1;
            if (String.Compare("MALE", input, true) == 0 || String.Compare("NAM", input, true) == 0)
            {
                gender = 1;
            }
            if (String.Compare("FEMALE", input, true) == 0 || String.Compare("NỮ", input, true) == 0)
            {
                gender = 0;
            }
            if (String.Compare("OTHER", input, true) == 0 || String.Compare("KHÁC", input, true) == 0)
            {
                gender = 2;
            }
            return gender;
        }

        //Convert birthday from Datetime to long
        public static long Birthday(string inputBirth)
        {
            long birthday = 0;
            char sym = inputBirth[2];
            char sym2 = inputBirth[5];
            if (sym == sym2)
            {
                switch (sym)
                {
                    case '/':
                        DateTime birth = Controller.Convert.InputDate(inputBirth);
                        birthday = birth.Ticks;
                        break;
                    case '-':
                        DateTime birth2 = Controller.Convert.InputDate2(inputBirth);
                        birthday = birth2.Ticks;
                        break;
                    case '.':
                        DateTime birth3 = Controller.Convert.InputDate3(inputBirth);
                        birthday = birth3.Ticks;
                        break;
                }
            }

            return birthday;
        }

        // Validate input birthday
        public static bool IsValidBirth(string inputB, out string errorMessage)
        {
            char sym1 = inputB[2];
            char sym2 = inputB[5];
            DateTime birth = DateTime.Now;
            switch (sym1)
            {
                case '/':
                    birth = Controller.Convert.InputDate(inputB);
                    break;
                case '-':
                    birth = Controller.Convert.InputDate2(inputB);
                    break;
                case '.':
                    birth = Controller.Convert.InputDate3(inputB);
                    break;
            }
            errorMessage = string.Empty;
            var hasUpperChar = new Regex(@"[A-Z]");
            var hasLowerChar = new Regex(@"[a-z]");
            if (string.IsNullOrWhiteSpace(inputB))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|         BIRTHDAY SHOULD NOT BE EMPTY       |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (hasLowerChar.IsMatch(inputB))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|       BIRTHDAY CAN NOT CONTAIN LETTERS     |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (hasUpperChar.IsMatch(inputB))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|      BIRTHDAY CAN NOT CONTAIN LETTERS      |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (sym1 != sym2)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|        YOU ENTERED THE WRONG FORMAT!       |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if ((DateTime.Now.Year - birth.Year) < 18)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|     YOU MUST ENOUGH 18 AGE GOR SIGN UP!    |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else
            {
                return true;
            }
        }

        //Validate input password
        public static bool IsValidPass(string inputPa, out string errorMessage)
        {
            errorMessage = string.Empty;
            //var hasNumber = new Regex(@"[0-9]+");
            //var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (string.IsNullOrWhiteSpace(inputPa))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|       PASSWORD SHOULD NOT BE EMPTY!        |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (!hasLowerChar.IsMatch(inputPa))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|      PASSWORD SHOULD CONTAIN AT LEAST      |\n" +
                               "|           ONE LOWER CASE LETTER            |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            /*else if(!hasUpperChar.IsMatch(inputPa))
            {
                errorMessage = "PASSWORD SHOULD CONTAIN AT LEAST ONE UPPER CASE LETTER";
                return false;
            }*/
            else if (!hasMiniMaxChars.IsMatch(inputPa))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "| PASSWORD SHOULD'N BE LESS THAN 6 CHARACTER |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            /*else if(!hasNumber.IsMatch(inputPa))
            {
                errorMessage = "PASSWORD SHOULD CONTAIN AT LEAST ONE NUMERIC VALUE";
                return false;
            }
            else if(!hasSymbols.IsMatch(inputPa))
            {
                errorMessage = "PASSWORD SHOULD CONTAIN AT LEAST ONE SPECIAL CASE CHARACTER";
                return false;
            }*/
            else
            {
                return true;
            }
        }

        //validate input username
        public static bool IsValidString(string inputS, out string errorMessage, MySqlCommand cmd)
        {
            errorMessage = string.Empty;
            var hasSymbols = new Regex(@"[!@#$%^&*()_+= \[{\]};:<>|./?,-]");
            string userSugg3 = Securitys.Suggestions1(inputS);
            string userSugg2 = Securitys.Suggestions2(inputS);
            CheckExist ctx = new CheckExist();
            var check = ctx.CheckExistUser(inputS, cmd);
            if (string.IsNullOrWhiteSpace(inputS))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|        USERNAME SHOULD NOT BE EMPTY        |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (hasSymbols.IsMatch(inputS))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "| USERNAME INCORRECT CHARACTER (a-z,A-Z,0-9) |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (inputS.Length < 6)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|  USERNAME NOT ENOUGH LENGTH (6 CHARACTER)  |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (check)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|          USERNAME ALREADY EXISTS!          |\n" +
                               "+--------------------------------------------+\n" +
                               "| SUGGESTIONS : " + userSugg2 + " , " + userSugg3 + "\n" +
                               "+--------------------------------------------+\n";
                return false;
            }
            else
            {
                return true;
            }

        }

        // Validate input fullname
        public static bool IsValidFullName(string inputN, out string errorMessage)
        {
            errorMessage = string.Empty;
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            var hasNumber = new Regex(@"[0-9]+");
            if (string.IsNullOrWhiteSpace(inputN))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|        FULL NAME SHOULD'N BE EMPTY         |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (hasNumber.IsMatch(inputN))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|        FULL NAME SHOULD'N BE DIGITS        |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (hasSymbols.IsMatch(inputN))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|  FULL NAME INCORRECT CHARACTER (a-z, A-Z)  |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (inputN.Length < 9)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|  FULL NAME NOT ENOUGH LENGTH (9 CHARACTER) |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else
            {
                return true;
            }

        }

        // Validate input address
        public static bool IsValidAdd(string inputA, out string errorMessage)
        {
            errorMessage = string.Empty;
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]");
            if (string.IsNullOrWhiteSpace(inputA))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|          ADDRESS SHOULD'N BE EMPTY         |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (inputA.Length < 8)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|   ADDRESS NOT ENOUGH LENGTH (8 CHARACTER)  |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (hasSymbols.IsMatch(inputA))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "| ADDRESS INCORRECT CHARACTER (a-z,A-Z, 0-9) |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else
            {
                return true;
            }
        }

        //Validate input email
        public static bool IsValidEmail(string inputE, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var addr = new MailAddress(inputE);
                return addr.Address == inputE;
            }
            catch (Exception e)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "| EMAIL INCORRECT FORMART(abcxx@example.com) |\n" +
                               "+--------------------------------------------+";
                return false;
            }
        }

        //Validate input Id Number
        public static bool IsValidIdNumber(string inputI, out string errorMessage, MySqlCommand cmd)
        {
            errorMessage = string.Empty;
            CheckExist ctx = new CheckExist();
            var check = ctx.CheckExistIdNumber(inputI, cmd);
            if (string.IsNullOrWhiteSpace(inputI))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|          ID NUMBER SHOULD'N EMPTY          |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (check)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|          ID NUMBER ALREADY EXISTS!         |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            else if (inputI.Length > 0 && inputI.Length < 9)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|  ID NUMBER NOT ENOUGH LENGTH (9 CHARACTER) |\n" +
                               "+--------------------------------------------+";
                return false;
            }

            foreach (char c in inputI)
            {
                if (c < '0' || c > '9')
                {
                    errorMessage = "\n+--------------------------------------------+\n" +
                                   "|    ID NUMBER INCORRECT CHARACTER (0 - 9)   |\n" +
                                   "+--------------------------------------------+";
                    return false;
                }
            }

            return true;
        }

        //Validate input phone
        public static bool IsDigitOnly(string inputP, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(inputP))
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|            PHONE SHOULD'N EMPTY            |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            foreach (char c in inputP)
            {
                if (c < '0' || c > '9')
                {
                    errorMessage = "\n+--------------------------------------------+\n" +
                                   "|     PHONE INCORRECT CHARACTER ( 0 - 9 )    |\n" +
                                   "+--------------------------------------------+";
                    return false;
                }
            }
            if (inputP.Length < 10)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                               "|   PHONE NOT ENOUGH LENGTH (10 CHARACTER)   |\n" +
                               "+--------------------------------------------+";
                return false;
            }
            return true;
        }

        public static bool IsValidMoney(int id, long money, out string errorMessage, MySqlCommand cmd)
        {
            errorMessage = string.Empty;
            CheckExist ctx = new CheckExist();
            long balence = ctx.BalenceById(id, cmd);
            if (money < 0)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                          "|         MONEY SHOULD'N LESS THAN 0         |\n" +
                          "+--------------------------------------------+";
                return false;
            }
            else if (money > balence)
            {
                errorMessage = "\n+--------------------------------------------+\n" +
                          "|  THE AMOUNT OF MONEY IN THE ACCOUNT IS NOT |\n" +
                          "|         ENOUGH FOR THIS TRANSACTION        |\n" +
                          "+--------------------------------------------+";
                return false;
            }

            return true;
        }
    }
}
