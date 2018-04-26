using System;
using System.Text;
using InternetBankingTeamNam.Model;
using MySql.Data.MySqlClient;

namespace InternetBankingTeamNam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MySqlConnection connection = ConnectionHelper.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();

            connection.Open();
            MySqlTransaction trs = connection.BeginTransaction();
            // run
            Console.OutputEncoding = Encoding.UTF8;

            MenuSign mn = new MenuSign();
            mn.Menu(cmd, trs);
            Console.ReadLine();

            // run
            connection.Close();
        }
    }
}
