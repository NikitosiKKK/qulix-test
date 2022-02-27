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
        public string GetPhotoInf() {
            string i= "Id\tName\tNickname\tOld\tAuthor Date\tAID\tName of photo\tUrl\tsize\tPhoto Date\tPrice\tPurchases\tRating";
            MySqlCommand command = new MySqlCommand("Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`photo` ON  qulixtestdb.`author`.id = qulixtestdb.`photo`.authorid;", connection);
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read()) {
                i = String.Format("{0}\n{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13} ", i, read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), read[5].ToString(), read[6].ToString(), read[7].ToString(), read[8].ToString(), read[9].ToString(), read[10].ToString(), read[11].ToString(), read[12].ToString());
            }
            return i;
        }
        public string GetTextInf() {
            string i = "Id\tName\tNickname\tOld\tAuthor Date\tAID\tName of text\tcontent\tsize\tText Date\tPrice\tPurchases\tRating";
            MySqlCommand command = new MySqlCommand("Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`text` ON  qulixtestdb.`author`.id = qulixtestdb.`text`.authorid;", connection);
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                i = String.Format("{0}\n{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13} ", i, read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), read[5].ToString(), read[6].ToString(), read[7].ToString(), read[8].ToString(), read[9].ToString(), read[10].ToString(), read[11].ToString(), read[12].ToString());
            }
            return i;
        }

        public string GetPhotoById(string id)
        {
            string i = "Id\tName\tNickname\tOld\tAuthor Date\tAID\tName of photo\tUrl\tsize\tPhoto Date\tPrice\tPurchases\tRating";
            MySqlCommand command = new MySqlCommand($"Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`photo` ON qulixtestdb.`author`.id = qulixtestdb.`photo`.authorid WHERE qulixtestdb.`photo`.name='{id}';", connection);
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                i = String.Format("{0}\n{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13} ", i, read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), read[5].ToString(), read[6].ToString(), read[7].ToString(), read[8].ToString(), read[9].ToString(), read[10].ToString(), read[11].ToString(), read[12].ToString());
            }
            return i;
        }
    }
}

