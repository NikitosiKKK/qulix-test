using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoins.Models
{

    public class GetContent
    {
        DB db = new DB();
        string filePath = "F://проекты/QulixTets/text";
        ArrayList DBPhotoCollection = new ArrayList();
        string[] PItems = new string[13];
        ArrayList DBTextCollection = new ArrayList();
        string[] TItems = new string[13];
        public string GetPhotoContent()
        {
            db.OpenConnection();
            string comand =GetPhotoInf();
            db.closeConnection();
            return comand;
        }
        public string GetTextContent()
        {
            db.OpenConnection();
            string comand = GetTextInf();
            db.closeConnection();
            return comand;
        }
        public string GetPhotoById(string id) {
            db.OpenConnection();
            string comand = GetPhotoInfByid(id);
            db.closeConnection();
            return comand;
        }
        public string GetPhotoInf()
        {
            string i = "Id\tName\tNickname\tOld\tAuthor Date\tAID\tName of photo\tUrl\tsize\tPhoto Date\tPrice\tPurchases\tRating";
            MySqlCommand command = new MySqlCommand("Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`photo` ON  qulixtestdb.`author`.id = qulixtestdb.`photo`.authorid;", db.getConnection());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                i = String.Format("{0}\n{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13} ", i, read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), read[5].ToString(), read[6].ToString(), read[7].ToString(), read[8].ToString(), read[9].ToString(), read[10].ToString(), read[11].ToString(), read[12].ToString());
            }
            return i;
        }
        public string GetTextInf()
        {
            FileStream fileStream = File.Open(filePath, FileMode.Create);
            string Inf = "Id\tName\tNickname\tOld\tAuthor Date\tAID\tName of text\tcontent\tsize\tText Date\tPrice\tPurchases\tRating";
            MySqlCommand command = new MySqlCommand("Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`text` ON  qulixtestdb.`author`.id = qulixtestdb.`text`.authorid;", db.getConnection());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                for (int i = 0; i == 13; i++) {
                    TItems[i] = read[i].ToString();
                }
                DBTextCollection.Add(TItems);
                Inf = String.Format("{0}\n{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13} ", Inf, read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), read[5].ToString(), read[6].ToString(), read[7].ToString(), read[8].ToString(), read[9].ToString(), read[10].ToString(), read[11].ToString(), read[12].ToString());
            }
            StreamWriter output = new StreamWriter(fileStream);
            output.Write(Inf);
            output.Close();
            return Inf;
        }

        public string GetPhotoInfByid(string id)
        {
            string i = "Id\tName\tNickname\tOld\tAuthor Date\tAID\tName of photo\tUrl\tsize\tPhoto Date\tPrice\tPurchases\tRating";
            MySqlCommand command = new MySqlCommand($"Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`photo` ON qulixtestdb.`author`.id = qulixtestdb.`photo`.authorid WHERE qulixtestdb.`photo`.name='{id}';", db.getConnection());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                i = String.Format("{0}\n{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13} ", i, read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), read[5].ToString(), read[6].ToString(), read[7].ToString(), read[8].ToString(), read[9].ToString(), read[10].ToString(), read[11].ToString(), read[12].ToString());
            }
            return i;
        }
    }
}
