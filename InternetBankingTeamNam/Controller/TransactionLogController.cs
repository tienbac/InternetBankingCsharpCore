using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Controller
{
    class TransactionLogController
    {
        public static void TransactionLog(int id, MySqlCommand cmd, MySqlTransaction trs)
        {
            DateTime date;
            List<Entity.TransactionLog> listLog = ManagerModel.TransactionLog(id, cmd);
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|  TRANSACTION CODE  |\t TRANSACTION TITLE \t|\t BANK NUMBER \t|\t MONEY \t|\t DATE \t     |");
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");
            if (listLog.Count != 0)
            {
                for (int i = 0; i < listLog.Count; i++)
                {
                    Console.WriteLine("|     " + listLog[i].TransactionCode +
                                      "      |\t     " + listLog[i].TransactionTitle +
                                      "\t        |   " + listLog[i].BankNumber +
                                      "   |     " + listLog[i].Money +
                                      "\t| " + (date = new DateTime(listLog[i].TransactionDate)) + " |");
                }
            }
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");
            MenuContinue.MnContinue(id, cmd, trs);
        }
    }
}
