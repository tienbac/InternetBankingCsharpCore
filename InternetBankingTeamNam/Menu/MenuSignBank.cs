using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Menu
{
    class MenuSignBank
    {
        public void SignUpBank(MySqlCommand cmd, MySqlTransaction trs)
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|                  MENU BANK                 |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|               1: TECHCOMBANK               |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|               2: VIETCOMBANK               |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|               3: TPBANK                    |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|               4: MARITIME BANK             |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|               5: BACK                      |");
            Console.WriteLine("+--------------------------------------------+");
            Console.Write("\n==> Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|               1: TECHCOMBANK               |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    TechcomBank tec = new TechcomBank();
                    string tecBankNumber = tec.BankNumber();
                    string tecBankName = "TECHCOMBANK";
                    long tecBankBalen = 50000000;
                    Controller.SignUpController.SignUpControl(tecBankName, tecBankNumber, tecBankBalen, cmd, trs);
                    break;
                case 2:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|               2: VIETCOMBANK               |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    VietcomBank vie = new VietcomBank();
                    string vieBankNumber = vie.BankNumber();
                    string vieBankName = "VIETCOMBANK";
                    long vieBankBalen = 40000000;
                    Controller.SignUpController.SignUpControl(vieBankName, vieBankNumber, vieBankBalen, cmd, trs);
                    break;
                case 3:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|               3: TPBANK                    |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    TPBank tp = new TPBank();
                    string tpBankNumber = tp.BankNumber();
                    string tpBankName = "TPBANK";
                    long tpBankBalen = 30000000;
                    Controller.SignUpController.SignUpControl(tpBankName, tpBankNumber, tpBankBalen, cmd, trs);
                    break;
                case 4:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|               4: MARITIME BANK             |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    MaritimeBank mar = new MaritimeBank();
                    string marBankNumber = mar.BankNumber();
                    string marBankName = "MARITIME BANK";
                    long marBankBalen = 25000000;
                    Controller.SignUpController.SignUpControl(marBankName, marBankNumber, marBankBalen, cmd, trs);
                    break;
                case 5:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|               5: BACK                      |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    MenuSign mn = new MenuSign();
                    mn.Menu(cmd, trs);
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
