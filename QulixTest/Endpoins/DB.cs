using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoins
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=qulixtestdb");
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
        public string GetInf(string comand) {
            string i="";
            MySqlCommand command = new MySqlCommand(comand, connection);
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read()) {
                i = String.Format("%1$d %2$d ", i, read[0].ToString());
            }
            return i;
        }
    }
}

