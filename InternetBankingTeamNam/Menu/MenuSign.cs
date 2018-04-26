using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Menu
{
    class MenuSign
    {
        public void Menu(MySqlCommand cmd, MySqlTransaction trs)
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|        WELCOME TO INTERNET BANKING!        |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|                 1: SIGN IN                 |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|                 2: SIGN UP                 |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|                 3: EXIT                    |");
            Console.WriteLine("+--------------------------------------------+");
            Console.Write("\n==> Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|                 1: SIGN IN                 |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    // Gọi hàm đăng nhập: 
                    Controller.SignInController.SignInControl(cmd, trs);
                    break;
                case 2:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|                 2: SIGN UP                 |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    // Gọi hàm đăng ký: 
                    MenuSignBank mnBank = new MenuSignBank();
                    mnBank.SignUpBank(cmd, trs);
                    break;
                case 3:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|                 3: GOOD BYE                |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|          Please choice from 1 to 3         |");
                    Console.WriteLine("|                 THANK YOU!                 |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    break;
            }
        }
    }
}
