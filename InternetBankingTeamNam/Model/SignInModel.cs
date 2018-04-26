using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Model
{
    class SignInModel
    {
        public static Account SignIn(int ids, string inputUser, string inputPass, MySqlCommand cmd)
        {
            string username = "";
            string password = "";

            string signIn = "SELECT username, password FROM accounts WHERE id =" + ids;
            cmd.CommandText = signIn;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                username = reader.GetString("username");
                password = reader.GetString("password");
            }
            reader.Close();
            Account acc = new Account(username, password);

            return acc;
        }
    }
}
