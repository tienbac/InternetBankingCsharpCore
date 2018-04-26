using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Model
{
    class ManagerModel
    {
        public static UserSignUp CheckAmount(int id, MySqlCommand cmd)
        {
            string checkAmount =
                "SELECT bankName, bankNumber, bankBalence, fullName FROM userinformation WHERE accountId = '" + id + "'";
            cmd.CommandText = checkAmount;
            cmd.CommandType = CommandType.Text;
            string bankName = "", bankNumber = "", fullName = "";
            long bankBalence = 0;

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bankName = reader.GetString("bankName");
                bankNumber = reader.GetString("bankNumber");
                bankBalence = reader.GetInt64("bankBalence");
                fullName = reader.GetString("fullName");
            }
            reader.Close();
            UserSignUp user = new UserSignUp(bankName, bankNumber, bankBalence, fullName);
            return user;
        }

        public static void MoneyWithDraw(string code, string title, string bankNum, long money, long newBalence, long updated, int id, MySqlCommand cmd, MySqlTransaction trs, out string message)
        {
            message = string.Empty;
            long balence2 = 0;
            string moneyWithDraw =
                "UPDATE userinformation SET bankBalence = @bankBalence, updatedAt = @updated WHERE accountId = @id";
            cmd.CommandText = moneyWithDraw;
            cmd.Transaction = trs;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@bankBalence", MySqlDbType.Int64).Value = newBalence;
            cmd.Parameters.Add("@updated", MySqlDbType.LongText).Value = updated;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();

            string insertTransaction =
                "INSERT INTO transactionlog(transactionCode, transactionTitle, bankNumber, money, transactionDate, accountId)" +
                "VALUES(@code, @title, @bankNum, @money, @date, @idtr)";
            cmd.CommandText = insertTransaction;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
            cmd.Parameters.Add("@bankNum", MySqlDbType.VarChar).Value = bankNum;
            cmd.Parameters.Add("@money", MySqlDbType.Int64).Value = money;
            cmd.Parameters.Add("@date", MySqlDbType.LongText).Value = updated;
            cmd.Parameters.Add("@idtr", MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();
            //cmd.Parameters.Clear();
            trs.Commit();
            message = "\n+--------------------------------------------+\n" +
                      "|          SUCCESSFUL TRANSACTIONS!          |\n" +
                      "+--------------------------------------------+\n";

        }

        public static void MoneyTransfer(MoneyTransfer money, MySqlTransaction trs, MySqlCommand cmd, out string message)
        {
            message = string.Empty;
            cmd.Transaction = trs;
            try
            {
                string sendBalence =
                    "UPDATE userinformation SET bankBalence = @bankBalence1, updatedAt = @updated1 WHERE accountId = @id1";
                cmd.CommandText = sendBalence;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@bankBalence1", MySqlDbType.Int64).Value = money.BalenSend;
                cmd.Parameters.Add("@updated1", MySqlDbType.Int64).Value = money.Date;
                cmd.Parameters.Add("@id1", MySqlDbType.Int32).Value = money.IdSend;
                cmd.ExecuteNonQuery();

                string receBalence =
                    "UPDATE userinformation SET bankBalence = @bankBalence2, updatedAt = @updated2 WHERE accountId = @id2";
                cmd.CommandText = receBalence;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@bankBalence2", MySqlDbType.Int64).Value = money.BalenRece;
                cmd.Parameters.Add("@updated2", MySqlDbType.Int64).Value = money.Date;
                cmd.Parameters.Add("@id2", MySqlDbType.Int32).Value = money.IdRece;
                cmd.ExecuteNonQuery();

                trs.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    trs.Rollback();
                }
                catch (MySqlException exception)
                {
                    if (trs.Connection != null)
                    {
                        message = "\n+--------------------------------------------+\n" +
                                  "|             TRANSACTIONS FAIL !            |\n" +
                                  "+--------------------------------------------+\n";
                    }
                }
                message = "\n+--------------------------------------------+\n" +
                          "|             TRANSACTIONS FAIL !            |\n" +
                          "+--------------------------------------------+\n";
            }
        }

        public static void MonneyTransferLog(string transcode, string titleSend, string bankNumSend, long money, long date, string bankNumRece, string note, int id, MySqlCommand cmd, out string message)
        {

            message = string.Empty;
            string insertTransactionSend =
                "INSERT INTO transactionlog(transactionCode, transactionTitle, bankNumber, money, transactionDate, receiveBankNumber, transactionNote, accountId)" +
                "VALUES(@code1, @title1, @bankNum5, @money, @date, @receBankNum5, @note1, @id5)";
            cmd.CommandText = insertTransactionSend;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@code1", MySqlDbType.VarChar).Value = transcode;
            cmd.Parameters.Add("@title1", MySqlDbType.VarChar).Value = titleSend;
            cmd.Parameters.Add("@bankNum5", MySqlDbType.VarChar).Value = bankNumSend;
            cmd.Parameters.Add("@money", MySqlDbType.LongText).Value = money;
            cmd.Parameters.Add("@date", MySqlDbType.LongText).Value = date;
            cmd.Parameters.Add("@receBankNum5", MySqlDbType.VarChar).Value = bankNumRece;
            cmd.Parameters.Add("@note1", MySqlDbType.VarChar).Value = note;
            cmd.Parameters.Add("@id5", MySqlDbType.Int64).Value = id;

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void MoneyTransferLog(string transcode, string titleRece, string bankNumRece, long money, long date, string bankNumSend, string note, int id, MySqlCommand cmd, out string message)
        {
            string insertTransactionRece =
                "INSERT INTO transactionlog(transactionCode, transactionTitle, bankNumber, money, transactionDate, receiveBankNumber, transactionNote, accountId)" +
                "VALUES(@code2, @title2, @bankNum2, @money, @date, @sendBankNum2, @note2, @id2)";
            cmd.CommandText = insertTransactionRece;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@code2", MySqlDbType.VarChar).Value = transcode;
            cmd.Parameters.Add("@title2", MySqlDbType.VarChar).Value = titleRece;
            cmd.Parameters.Add("@bankNum2", MySqlDbType.VarChar).Value = bankNumRece;
            cmd.Parameters.Add("@money", MySqlDbType.LongText).Value = money;
            cmd.Parameters.Add("@date", MySqlDbType.LongText).Value = date;
            cmd.Parameters.Add("@sendBankNum2", MySqlDbType.VarChar).Value = bankNumSend;
            cmd.Parameters.Add("@note2", MySqlDbType.VarChar).Value = note;
            cmd.Parameters.Add("@id2", MySqlDbType.Int64).Value = id;

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            message = "\n+--------------------------------------------+\n" +
                      "|          SUCCESSFUL TRANSACTIONS!          |\n" +
                      "+--------------------------------------------+\n";
        }

        public static List<TransactionLog> listLog = new List<TransactionLog>();
        public static List<TransactionLog> TransactionLog(int id, MySqlCommand cmd)
        {
            string checkTransacLog = "SELECT transactionCode, transactionTitle, bankNumber, money, transactionDate FROM transactionlog WHERE accountId = '" + id + "'";
            cmd.CommandText = checkTransacLog;
            cmd.CommandType = CommandType.Text;
            string transactionCode = "", transactionTitle = "", bankNumber = "";
            long money = 0, transactionDate = 0;
            TransactionLog transactionlog = null;
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    transactionCode = reader.GetString("transactionCode");
                    transactionTitle = reader.GetString("transactionTitle");
                    bankNumber = reader.GetString("bankNumber");
                    money = reader.GetInt64("money");
                    transactionDate = reader.GetInt64("transactionDate");
                    transactionlog = new TransactionLog(transactionCode, transactionTitle, bankNumber, money, transactionDate);
                    listLog.Add(transactionlog);
                }
            }

            reader.Close();
            //TransactionLog transactionlog = new TransactionLog(transactionCode, transactionTitle, bankNumber, money, transactionDate);
            return listLog;
        }
    }
}
