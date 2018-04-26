using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Controller
{
    class TransferController
    {
        public static void TransferMoney(int idSend /*ID send 12 */, MySqlCommand cmd, MySqlTransaction trs)
        {
            string message = "";
            string errorMessage = "";
            int id = idSend;

            CheckExist ctx = new CheckExist();
            long balenceSend = ctx.BalenceById(idSend, cmd);
            DateTime now = DateTime.Now;
            long date = now.Ticks; // Date 10

            string titleSend = "TRANSFERS MONEY";//Title Send 3
            string titleRece = "RECEIVER MONEY";//Title Rece 4
            string verificode = Securitys.VerificationCode();
            string bankNumSend = ctx.BankNumberById(idSend, cmd);//BankNum Send 5
            string bankCodeSend = bankNumSend.Substring(0, 3);
            string transCodeSend = Securitys.TransactionCode(bankCodeSend);//TransCode Send 1

            Console.WriteLine("\n+--------------------------------------------+");
            while (true)
            {
                Console.Write("| BANK NUMBER RECEVIE MONEY      : ");
                string bankNumRece = Console.ReadLine(); // BankNum Rece 6
                bool check1 = ctx.CheckExistBankNumber(bankNumRece, cmd);
                if (check1)
                {
                    int idRece = ctx.IdByBankNum(bankNumRece, cmd); // ID Rece 13
                    long balenRece = ctx.BalenceById(idRece, cmd);
                    string bankCodeRece = bankNumRece.Substring(0, 3);
                    string transCodeRece = Securitys.TransactionCode(bankCodeRece);//TransCode Rece 2
                    Console.WriteLine("+--------------------------------------------+");
                    Console.Write("| THE MONEY YOU WANT TO TRANSFER : ");
                    long money = Int64.Parse(Console.ReadLine()); // Money 7
                    bool check = ValidateDataInput.IsValidMoney(idSend, money, out errorMessage, cmd);
                    if (check)
                    {
                        Console.WriteLine("+--------------------------------------------+");
                        Console.Write("| NOTE : ");
                        string note = Console.ReadLine(); // Note 11
                        Console.WriteLine("+--------------------------------------------+");
                        Console.WriteLine("| VERIFICATION CODE              : " + verificode);
                        Console.WriteLine("+--------------------------------------------+");
                        Console.Write("| REENTER VERIFICATION CODE      : ");
                        string reEnter = Console.ReadLine();
                        if (reEnter.Equals(verificode))
                        {
                            Console.WriteLine("+--------------------------------------------+");
                            Console.WriteLine("|         VERIFICATION CODE MATCHING         |");
                            Console.WriteLine("+--------------------------------------------+");
                            Console.WriteLine("|        PERFORMING TRANSACTION . . .        |");
                            Console.WriteLine("+--------------------------------------------+");
                            balenceSend -= money; // Balen Send 8
                            balenRece += money; // Balen Rece 9

                            MoneyTransfer moneyTransfer = new MoneyTransfer(transCodeSend, transCodeRece, titleSend, titleRece, bankNumSend, bankNumRece, money, balenceSend, balenRece, date, note, id, idRece);
                            ManagerModel.MoneyTransfer(moneyTransfer, trs, cmd, out message);
                            ManagerModel.MonneyTransferLog(transCodeSend, titleSend, bankNumSend, money, date, bankNumRece, note, id, cmd, out message);

                            ManagerModel.MoneyTransferLog(transCodeRece, titleRece, bankNumRece, money, date, bankNumSend, note, idRece, cmd, out message);

                            Console.WriteLine(message);


                            MenuContinue.MnContinue(idSend, cmd, trs);
                            break;
                        }

                        Console.WriteLine("\n+--------------------------------------------+\n" +
                                          "|        VERIFICATION CODE IS WRONG !        |\n" +
                                          "+--------------------------------------------+\n");
                    }
                }
                Console.WriteLine(errorMessage);
            }

        }
    }
}
