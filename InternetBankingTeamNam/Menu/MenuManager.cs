using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Menu
{
    class MenuManager
    {
        public static void MnManager(int id, MySqlCommand cmd, MySqlTransaction trs)
        {

            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|                MENU MANAGER                |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|             1: Check the amount            |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|             2: Money Withdraw              |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|             3: Money Transfer              |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|             4: Transaction Log             |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|             5: EXIT                        |");
            Console.WriteLine("+--------------------------------------------+");
            Console.Write("\n==> Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|             1: Check the amount            |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    // Gọi hàm check số dư tài khoản
                    CheckAmountController.CheckAmount(id, cmd, trs);
                    break;
                case 2:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|             2: Money Withdraw              |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    // Gọi hàm rút tiền
                    WithDrawController.WithDraw(id, cmd, trs);
                    break;
                case 3:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|             3: Money Transfer              |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    // Gọi hàm chuyển tiền
                    TransferController.TransferMoney(id, cmd, trs);
                    break;
                case 4:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|             4: Transaction Log             |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    // Gọi hàm show lịch sử giao dịch
                    TransactionLogController.TransactionLog(id, cmd, trs);
                    break;
                case 5:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|                  GOOD BYE                  |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|          Please choice from 1 to 5         |");
                    Console.WriteLine("|                 THANK YOU!                 |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    break;
            }
        }
    }
}
