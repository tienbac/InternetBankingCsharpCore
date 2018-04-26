using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Controller
{
    class SignUpController
    {
        public static void SignUpControl(string bankName, string bankNumber, long bankBalence, MySqlCommand cmd, MySqlTransaction trs)
        {
            //Lấy ra muối theo hàm random salt của class SECURITY
            string salt = Securitys.MD5Crypto(Securitys.Salt());
            //Lấy thời điểm hiện tại
            string message = "";
            string mess = "\n+--------------------------------------------+\n" +
                          "|             SIGN UP SUCCESSFUL!            |\n" +
                          "+--------------------------------------------+";
            DateTime now = DateTime.Now;
            long createdAt = now.Ticks;
            string error = "";
            bool check;
            UserSignUp user = new UserSignUp();
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("| BANK NAME   : " + bankName);
            Console.WriteLine("| BANK NUMBER : " + bankNumber);

            string username;
            while (true)
            {
                Console.Write("| USERNAME    : ");
                string iUsername = Console.ReadLine();
                check = ValidateDataInput.IsValidString(iUsername, out error, cmd);
                if (check)
                {
                    username = iUsername;
                    break;
                }

                Console.WriteLine(error);
            }

            string password = "";
            while (true)
            {
                Console.Write("| PASSWORD    : ");
                string iPassword = Console.ReadLine();
                check = ValidateDataInput.IsValidPass(iPassword, out error);
                // Show password strength
                if (check)
                {
                    PasswordScore passwordStrength = CheckPasswordScore.CheckStrength(iPassword);
                    switch (passwordStrength)
                    {
                        case PasswordScore.Blank:
                        case PasswordScore.VeryWeak:
                        case PasswordScore.Weak:
                        //Console.WriteLine("+--------------------------------------------+\n" +
                        //"|            < PASSWORD WEAK: * * >          |\n" +
                        //"+--------------------------------------------+");
                        //break;
                        case PasswordScore.Medium:
                            Console.WriteLine("+--------------------------------------------+\n" +
                                              "|          < PASSWORD MEDIUM: * * * >        |\n" +
                                              "+--------------------------------------------+");
                            break;
                        case PasswordScore.Strong:
                            Console.WriteLine("+--------------------------------------------+\n" +
                                              "|         < PASSWORD STRONG: * * * * >       |\n" +
                                              "+--------------------------------------------+");
                            break;
                        case PasswordScore.VeryStrong:
                            Console.WriteLine("+--------------------------------------------+\n" +
                                              "|     < PASSWORD VERY STRONG: * * * * * >    |\n" +
                                              "+--------------------------------------------+");
                            break;
                    }

                    password = Securitys.MD5Crypto(iPassword) + salt;
                    break;
                }
                Console.WriteLine(error);
            }

            Console.WriteLine("| BANK BALENCE: " + bankBalence + " VND");

            string fullName;
            while (true)
            {
                Console.Write("| FULL NAME   : ");
                string iFullName = Console.ReadLine();
                check = ValidateDataInput.IsValidFullName(iFullName, out error);
                if (check)
                {
                    fullName = iFullName;
                    break;
                }

                Console.WriteLine(error);
            }

            int gender;
            while (true)
            {
                Console.Write("| GENDER      : ");
                string iGender = Console.ReadLine();
                check = ValidateDataInput.Gender(iGender, out error);
                if (check)
                {
                    gender = ValidateDataInput.ExGender(iGender);
                    break;
                }

                Console.WriteLine(error);
            }

            long birthday;
            while (true)
            {
                Console.Write("| BIRTHDAY    : ");
                string iBirth = Console.ReadLine();
                check = ValidateDataInput.IsValidBirth(iBirth, out error);
                if (check)
                {
                    birthday = ValidateDataInput.Birthday(iBirth);
                    break;
                }

                Console.WriteLine(error);
            }

            string idNumber;
            while (true)
            {
                Console.Write("| ID NUMBER   : ");
                string iIdnumber = Console.ReadLine();
                check = ValidateDataInput.IsValidIdNumber(iIdnumber, out error, cmd);
                if (check)
                {
                    idNumber = iIdnumber;
                    break;
                }

                Console.WriteLine(error);
            }

            string phone;
            while (true)
            {
                Console.Write("| PHONE       : ");
                string iPhone = Console.ReadLine();
                check = ValidateDataInput.IsDigitOnly(iPhone, out error);
                if (check)
                {
                    phone = iPhone;
                    break;
                }

                Console.WriteLine(error);
            }

            string email;
            while (true)
            {
                Console.Write("| EMAIL       : ");
                string iEmail = Console.ReadLine();
                check = ValidateDataInput.IsValidEmail(iEmail, out error);
                if (check)
                {
                    email = iEmail;
                    break;
                }

                Console.WriteLine(error);
            }

            string address;
            while (true)
            {
                Console.Write("| ADDRESS     : ");
                string iAddress = Console.ReadLine();
                check = ValidateDataInput.IsValidAdd(iAddress, out error);
                if (check)
                {
                    address = iAddress;
                    break;
                }

                Console.WriteLine(error);
            }

            SignUpModel.SignUp(username, password, bankNumber, bankName, salt, bankBalence, fullName, gender, birthday, idNumber, phone, email, address, createdAt, cmd, trs, out message);

            Console.WriteLine(message);
            CheckExist ctx = new CheckExist();
            int id = ctx.IdByUsername(username, cmd);
            string bankNumbers = ctx.BankNumberById(id, cmd);
            if (String.Compare(mess, message, true) == 0)
            {
                MenuManager.MnManager(id, cmd, trs);
            }
        }
    }
}
