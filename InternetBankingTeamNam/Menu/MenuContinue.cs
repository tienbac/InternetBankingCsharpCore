using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Menu
{
    class MenuContinue
    {
        public static void MnContinue(int id, MySqlCommand cmd, MySqlTransaction trs)
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|          DO YOU WANT TO CONTINUE?          |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|            1: YES    |    2: NO            |");
            Console.WriteLine("+--------------------------------------------+");

            Console.Write("\n==> Your choice is: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|                 CONTINUE !                 |");
                    Console.WriteLine("+--------------------------------------------+");
                    MenuManager.MnManager(id, cmd, trs);
                    break;
                case 2:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|          You choice NO! GOOD BYE!          |");
                    Console.WriteLine("+--------------------------------------------+");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n+--------------------------------------------+");
                    Console.WriteLine("|            Please choice 1 or 2!           |");
                    Console.WriteLine("|                 THANK YOU!                 |");
                    Console.WriteLine("+--------------------------------------------+\n");
                    MnContinue(id, cmd, trs);
                    break;
            }
        }
    }
}
