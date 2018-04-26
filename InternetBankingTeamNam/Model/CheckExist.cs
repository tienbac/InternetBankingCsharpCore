using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Model
{
    class CheckExist
    {
        public bool CheckExistUser(string inputUser, MySqlCommand cmd)
        {

            bool check;
            string checkUser = "SELECT username FROM accounts WHERE username =" + "'" + inputUser + "'";
            cmd.CommandText = checkUser;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            check = reader.Read();

            reader.Close();
            return check;

        }

        public bool CheckExistBankNumber(string inputBankNum, MySqlCommand cmd)
        {
            bool check;
            string checkBankNum = "SELECT bankNumber FROm userinformation WHERE bankNumber = '" + inputBankNum + "'";
            cmd.CommandText = checkBankNum;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            check = reader.Read();

            reader.Close();
            return check;
        }

        public bool CheckExistIdNumber(string inputId, MySqlCommand cmd)
        {
            bool check;
            string checkId = "SELECT idNumber FROM userinformation WHERE idNumber = '" + inputId + "'";
            cmd.CommandText = checkId;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            check = reader.Read();
            reader.Close();
            return check;
        }

        public int IdByUsername(string inputUser, MySqlCommand cmd)
        {
            int rId;
            string idByUser = "SELECT id FROM accounts WHERE username =" + "'" + inputUser + "'";
            cmd.CommandText = idByUser;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            rId = reader.GetInt16("id");

            reader.Close();
            return rId;
        }

        public bool CheckExistPhone(int inputId, MySqlCommand cmd)
        {
            bool check = false;
            string checkPhone = "SELECT phone FROM userinformation INNER JOIN accounts ON userinformation.accountId = accounts.id WHERE id =" + inputId;
            cmd.CommandText = checkPhone;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            check = reader.Read();
            reader.Close();
            return check;
        }

        public bool CheckExistEmail(int inputId, MySqlCommand cmd)
        {
            bool check = false;
            string checkEmail =
                    "SELECT email FROM userinformation INNER JOIN accounts ON userinformation.accountId = accounts.id WHERE id =" +
                    inputId;
            cmd.CommandText = checkEmail;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            check = reader.Read();
            reader.Close();
            return check;
        }

        public bool CheckExistIdNumber(int inputId, MySqlCommand cmd)
        {
            bool check = false;
            string checkIdNumber =
                    "SELECT idNumber FROM userinformation INNER JOIN accounts ON userinformation.accountId = accounts.id WHERE id =" +
                    inputId;
            cmd.CommandText = checkIdNumber;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            check = reader.Read();
            reader.Close();
            return check;
        }

        public string SaltById(int inputId, MySqlCommand cmd)
        {
            string salt = "";
            string saltById =
                    "SELECT salt FROM userinformation INNER JOIN accounts ON userinformation.accountId = accounts.id WHERE id =" +
                    inputId;
            cmd.CommandText = saltById;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            salt = reader.GetString("salt");

            reader.Close();
            return salt;
        }

        public string BankNumberById(int inputId, MySqlCommand cmd)
        {
            string bankNumber = "";
            string bankNumberById =
                "SELECT bankNumber FROM userinformation INNER JOIN accounts ON userinformation.accountId = accounts.id WHERE id =" +
                inputId;
            cmd.CommandText = bankNumberById;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            bankNumber = reader.GetString("bankNumber");
            reader.Close();

            return bankNumber;
        }

        public string NameByBankNumber(string inputBN, MySqlCommand cmd)
        {
            string name = "";
            string bName = "";
            string nameByBN = "SELECT bankName, fullName FROM userinformation WHERE bankNumber = '" + inputBN + "'";
            cmd.CommandText = nameByBN;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            name = reader.GetString("fullName");
            bName = reader.GetString("bankName");

            reader.Close();

            string recBN = "Họ tên: " + name + "\n" + "Ngân hàng: " + bName;

            return recBN;
        }

        public long BalenceById(int inputId, MySqlCommand cmd)
        {
            long balence;
            string balenceById =
                "SELECT bankBalence FROM userinformation INNER JOIN accounts ON userinformation.accountId = accounts.id WHERE id =" +
                inputId;
            cmd.CommandText = balenceById;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            balence = reader.GetInt64("bankBalence");
            reader.Close();

            return balence;
        }

        public int IdByBankNum(string inputBankNum, MySqlCommand cmd)
        {
            int bId;
            string idByBankNum = "SELECT accountId FROM userinformation WHERE bankNumber = " + "'" + inputBankNum + "'";
            cmd.CommandText = idByBankNum;
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            bId = reader.GetInt32("accountId");
            reader.Close();
            return bId;
        }
    }
}
