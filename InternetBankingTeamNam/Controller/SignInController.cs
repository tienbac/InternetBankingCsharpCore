using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Controller
{
    class SignInController
    {
        public static void SignInControl(MySqlCommand cmd, MySqlTransaction trs)
        {
            while (true)
            {
                ConsoleKeyInfo key;
                Console.Write("USERNAME: ");
                string inputUser = Console.ReadLine();

                Console.Write("PASSWORD: ");

                string inputPass = Console.ReadLine();

                CheckExist ctx = new CheckExist();
                bool check = ctx.CheckExistUser(inputUser, cmd);
                if (check)
                {
                    int ids = ctx.IdByUsername(inputUser, cmd);
                    string salt = ctx.SaltById(ids, cmd);
                    string pass = Securitys.MD5Crypto(inputPass) + salt;

                    Account account = SignInModel.SignIn(ids, inputUser, inputPass, cmd);
                    string username = account.Username;
                    string password = account.Password;

                    if (inputUser.Equals(username))
                    {
                        if (pass.Equals(password))
                        {
                            Console.WriteLine("\n+--------------------------------------------+\n" +
                                              "|              SIGN IN SUCCESSFUL            |\n" +
                                              "+--------------------------------------------+");
                            MenuManager.MnManager(ids, cmd, trs);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n+--------------------------------------------+\n" +
                                              "|        WRONG USER OR PASSWORD ENTERED      |\n" +
                                              "+--------------------------------------------+\n");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("\n+--------------------------------------------+\n" +
                                      "|        WRONG USER OR PASSWORD ENTERED      |\n" +
                                      "+--------------------------------------------+\n");
                }

            }

        }
    }
}
