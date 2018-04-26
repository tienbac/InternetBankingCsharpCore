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
            Console.WriteLine("Open");


            Console.ReadLine();

            // run
            connection.Close();
            Console.WriteLine("Close");
        }
    }
}
