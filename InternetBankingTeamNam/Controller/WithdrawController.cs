using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Controller
{
    class WithDrawController
    {
        public static void WithDraw(int id, MySqlCommand cmd, MySqlTransaction trs)
        {
            string message = "";
            string errorMessage = "";
            CheckExist ctx = new CheckExist();
            long balence = ctx.BalenceById(id, cmd);

            string title = "WITHDRAWAL";
            string verifiCode = Securitys.VerificationCode();
            string bankNumber = ctx.BankNumberById(id, cmd);
            string bankCode = bankNumber.Substring(0, 3);
            string transactionCode = Securitys.TransactionCode(bankCode);

            Console.WriteLine("\n+--------------------------------------------+");
            DateTime now = DateTime.Now;
            long updated = now.Ticks;
            while (true)
            {
                Console.Write("| THE MONEY YOU WANT TO WITHDRAW : ");
                long money = Int64.Parse(Console.ReadLine());
                bool check = ValidateDataInput.IsValidMoney(id, money, out errorMessage, cmd);
                if (check)
                {
                    Console.WriteLine("| VERIFICATION CODE              : " + verifiCode);
                    Console.WriteLine("+--------------------------------------------+");
                    Console.Write("| REENTER VERIFICATION CODE      : ");
                    string reEnter = Console.ReadLine();
                    if (reEnter.Equals(verifiCode))
                    {
                        Console.WriteLine("+--------------------------------------------+");
                        Console.WriteLine("|         VERIFICATION CODE MATCHING         |");
                        Console.WriteLine("+--------------------------------------------+");
                        Console.WriteLine("|        PERFORMING TRANSACTION . . .        |");
                        Console.WriteLine("+--------------------------------------------+");
                        balence -= money;
                        ManagerModel.MoneyWithDraw(transactionCode, title, bankNumber, money, balence, updated, id, cmd, trs, out message);
                        Console.WriteLine(message);

                        MenuContinue.MnContinue(id, cmd, trs);
                        break;
                    }

                    Console.WriteLine("\n+--------------------------------------------+\n" +
                                      "|        VERIFICATION CODE IS WRONG !        |\n" +
                                      "+--------------------------------------------+\n");
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}
