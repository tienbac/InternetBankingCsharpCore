using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Model
{
    class SignUpModel
    {
        public static void SignUp(string inUser, string inPass, string inBankNum, string inBankName, string inSalt, long inBankBalen, string inName, int inGen, long inBirth, string inIdNum, string inPhone, string inEmail, string inAddress, long inCreated, MySqlCommand cmd, MySqlTransaction trs, out string message)
        {
            message = string.Empty;
            string signUpAcc = "INSERT INTO accounts(username, password) VALUE(@user, @pass)";
            cmd.CommandText = signUpAcc;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = trs;
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = inUser;
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = inPass;

            cmd.ExecuteNonQuery();

            CheckExist ctx = new CheckExist();
            int id = ctx.IdByUsername(inUser, cmd);


            string signUpInfor =
                "INSERT INTO userinformation(bankNumber, bankName, accountId, salt, bankBalence, fullName, gender, birthday, idNumber, phone, email, address, createdAt) " +
                "VALUE(@bankNum, @bankName, @accId, @salt, @bankBalen, @name, @gender, @birthday, @idNum, @phone, @email, @address, @created)";
            cmd.CommandText = signUpInfor;

            cmd.Parameters.Add("@bankNum", MySqlDbType.VarChar).Value = inBankNum;//
            cmd.Parameters.Add("@bankName", MySqlDbType.VarChar).Value = inBankName;
            cmd.Parameters.Add("@accId", MySqlDbType.Int32).Value = id;//
            cmd.Parameters.Add("@salt", MySqlDbType.VarChar).Value = inSalt;//
            cmd.Parameters.Add("@bankBalen", MySqlDbType.LongText).Value = inBankBalen;//
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = inName;
            cmd.Parameters.Add("@gender", MySqlDbType.Int32).Value = inGen;
            cmd.Parameters.Add("@birthday", MySqlDbType.LongText).Value = inBirth;
            cmd.Parameters.Add("@idNum", MySqlDbType.VarChar).Value = inIdNum;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = inPhone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = inEmail;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = inAddress;
            cmd.Parameters.Add("@created", MySqlDbType.LongText).Value = inCreated;//

            cmd.ExecuteNonQuery();
            trs.Commit();
            message = "\n+--------------------------------------------+\n" +
                       "|             SIGN UP SUCCESSFUL!            |\n" +
                       "+--------------------------------------------+";

        }
    }
}
