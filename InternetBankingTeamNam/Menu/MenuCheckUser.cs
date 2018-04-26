using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBankingTeamNam.Menu
{
    class MenuCheckUser
    {
        class MenuCheckUser
        {
            public static void MnCheckUser(MySqlCommand cmd)
            {
                Console.WriteLine("+------------------------------+");
                Console.WriteLine("|    USERNAME DOSE NOT EXIST   |");
                Console.WriteLine("+     -----          -----     +");
                Console.WriteLine("|    DO YOU WANT TO SIGN UP?   |");
                Console.WriteLine("+------------------------------+");
                Console.WriteLine("|     1: YES    |    2: NO     |");
                Console.WriteLine("+------------------------------+");
                Console.Write("\n==> Your choice is: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("");

                        break;
                    case 2:
                        Console.WriteLine("");

                        break;
                    default:
                        Console.WriteLine("\n+------------------------------+");
                        Console.WriteLine("|     Please choice 1 or 2!    |");
                        Console.WriteLine("|          THANK YOU!          |");
                        Console.WriteLine("+------------------------------+\n");
                        MnCheckUser(cmd);
                        break;
                }
            }
        }
    }
}
