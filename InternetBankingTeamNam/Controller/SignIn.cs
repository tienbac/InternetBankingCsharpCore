using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Controller
{
    class SignIn
    {
        public static void SignInControl(Account account, MySqlTransaction trs, MySqlCommand cmd, out string message)
        {
            message = string.Empty;

            CheckExist ctx = new CheckExist();
            int ids = ctx.IdByUsername(account.Username, cmd);
            string salt = ctx.SaltById(ids, cmd);
            string pass = Securitys.MD5Crypto(account.Password) + salt;

            Account acc = SignInModel.SignIn(ids, account.Username, pass, cmd);
            string username = acc.Username;
            string password = acc.Password;

            if (account.Username.Equals(username))
            {
                if (pass.Equals(password))
                {
                    MenuManager.MnManager(ids, cmd, trs);

                }
                else
                {
                    message = "\n+----------------------------------+\n" +
                                  "| WRONG USER OR PASSWORD ENTERED ! |\n" +
                                  "+----------------------------------+";
                }
            }
            else
            {
                message = "\n+----------------------------------+\n" +
                              "| WRONG USER OR PASSWORD ENTERED ! |\n" +
                              "+----------------------------------+";
            }


        }
    }
}
