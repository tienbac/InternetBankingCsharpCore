using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Controller
{
    class CheckAmountController
    {
        public static void CheckAmount(int id, MySqlCommand cmd, MySqlTransaction trs)
        {
            UserSignUp user = ManagerModel.CheckAmount(id, cmd);
            string fullName = user.FullName;
            string bankName = user.BankName;
            string bankNumber = user.BankNumber;
            //long bankBalence = user.BankBalence;
            string bankBalence = String.Format("{0:C}", user.BankBalence);


            Console.WriteLine("\n+--------------------------------------------+");
            Console.WriteLine("| FULL NAME    : " + fullName);
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("| BANK NAME    : " + bankName);
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("| BANK NUMBER  : " + bankNumber);
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("| BANK BALENCE : " + bankBalence + " VND");
            Console.WriteLine("+--------------------------------------------+\n");


            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|                                          THE LAST 5 TRANSACTIONS !                                         |");
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");
            DateTime date;
            List<Entity.TransactionLog> listLog1 = ManagerModel.TransactionLog(id, cmd);
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|  TRANSACTION CODE  |\t TRANSACTION TITLE \t|\t BANK NUMBER \t|\t MONEY \t|\t DATE \t     |");
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");
            if (listLog1.Count != 0)
            {
                for (int i = 0; i < Math.Min(listLog1.Count, 5); i++)
                {
                    Console.WriteLine("|     " + listLog1[i].TransactionCode +
                                      "      |\t     " + listLog1[i].TransactionTitle +
                                      "\t        |   " + listLog1[i].BankNumber +
                                      "   |     " + listLog1[i].Money +
                                      "\t| " + (date = new DateTime(listLog1[i].TransactionDate)) + " |");
                }
            }
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");

            MenuContinue.MnContinue(id, cmd, trs);
        }
    }
}
