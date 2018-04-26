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

        public static MySqlConnection GetConnection1()
        {
            if (connection == null)
            {
                try
                {
                    connection = GetConnectionEntity();
                    connection.Open();
                    //Console.WriteLine("Success");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

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

        private static MySqlConnection GetConnectionEntity()
        {
            string server = "localhost";
            int port = 3306;
            string database = "internetbanking";
            string username = "root";
            string passwrod = "";

            return GetConnectionEntity(server, port, database, username, passwrod);
        }

        private static MySqlConnection GetConnectionEntity(string server, int port, string database, string username,
            string password)
        {
            string ConnectString = "Server = " + server + ";Database = " + database + ";port = " + port + ";username = " + username + ";password = " + password + ";CharSet=utf8;";
            MySqlConnection connection = new MySqlConnection(ConnectString);
            return connection;
        }
    }
}
