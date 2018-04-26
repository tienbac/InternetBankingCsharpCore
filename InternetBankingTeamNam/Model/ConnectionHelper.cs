using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace InternetBankingTeamNam.Model
{
    class ConnectionHelper
    {
        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();
            connBuilder.Add("Database", "internetbanking");
            connBuilder.Add("Data Source", "localhost");
            connBuilder.Add("User Id", "root");
            connBuilder.Add("Password", "");
            connBuilder.Add("CharacterSet", "utf8");

            MySqlConnection connection = new MySqlConnection(connBuilder.ConnectionString);
            return connection;
        }

        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
                //Console.WriteLine("Close success");
            }

        }
    }
}
