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
        
        
        public List<PhotoInf> GetPhotoContent(int page)
        {
            db.OpenConnection();
            List<PhotoInf> comand = GetPhotoInf(page);
            db.closeConnection();
            return comand;
        }
        public List<TextInf> GetTextContent()
        {
            db.OpenConnection();
            List<TextInf> comand = GetTextInf();
            db.closeConnection();
            return comand;
        }
        public PhotoInf GetPhotoById(string id) {
            db.OpenConnection();
            PhotoInf comand = GetPhotoInfByid(id);
            db.closeConnection();
            return comand;
        }
        public List<PhotoInf> GetPhotoInf(int page)
        {
            List<PhotoInf> photos = new List<PhotoInf>();
            MySqlCommand command = new MySqlCommand(" Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`photo` ON  qulixtestdb.`author`.id = qulixtestdb.`photo`.authorid;  ", db.getConnection());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                var a = new PhotoInf();
                a.AuthorId = Convert.ToInt32(read[0]);
                a.AuthorNAme = Convert.ToString(read[1]);
                a.AuthorNik = Convert.ToString(read[2]);
                a.AuthorOld = Convert.ToInt32(read[3]);
                a.AuthorDate = Convert.ToString(read[4]);
                a.PhotoName = Convert.ToString(read[6]);
                a.PhotoUrl = Convert.ToString(read[7]);
                a.PhotoSize = Convert.ToString(read[8]);
                a.PhotoDate = Convert.ToString(read[9]);
                a.PhotoPrice = Convert.ToInt32(read[10]);
                a.PhotoPurchases = Convert.ToInt32(read[11]);
                a.PhotoRating = Convert.ToInt32(read[12]);
                photos.Add(a);  
            }
            PageSettings settings = new PageSettings();
            settings.PageNumber = page;
            try
            {
                int diapazone1 = ((settings.PageNumber * settings.PageSize) - settings.PageSize);
                var PhotoPageInformation = photos.GetRange(diapazone1, settings.PageSize);
                return PhotoPageInformation;
            }
            catch (ArgumentException)
            {
                var ExAllInformation = photos.GetRange(photos.Count() - 2, settings.PageSize);
                return ExAllInformation;
            }
        }
        public List<TextInf> GetTextInf()
        {
            string filePath = "F://проекты/QulixTets/text/text.txt";
            List<TextInf> text = new List<TextInf>();
            string Inf=" ";
            FileStream fileStream = File.Open(filePath, FileMode.Create);
            MySqlCommand command = new MySqlCommand("Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`text` ON  qulixtestdb.`author`.id = qulixtestdb.`text`.authorid;", db.getConnection());
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                var a = new TextInf();
                a.AuthorId = Convert.ToInt32(read[0]);
                a.AuthorNAme = Convert.ToString(read[1]);
                a.AuthorNik = Convert.ToString(read[2]);
                a.AuthorOld = Convert.ToInt32(read[3]);
                a.AuthorDate = Convert.ToString(read[4]);
                a.TextName = Convert.ToString(read[6]);
                a.TextContent = Convert.ToString(read[7]);
                a.TextSize = Convert.ToString(read[8]);
                a.TextDate = Convert.ToString(read[9]);
                a.TextPrice = Convert.ToInt32(read[10]);
                a.TextPurchases = Convert.ToInt32(read[11]);
                a.TextRating = Convert.ToInt32(read[12]);
                text.Add(a);
                Inf = String.Format("{0}\nAuthorId:{1}\tAuthorNAme:{2}\tAuthorNik:{3}\tAuthorOld:{4}\tAuthorDate:{5}\tTextName:{6}\tTextContent:{7}\tTextSize:{8}\tTextDate:{9}\tTextPrice:{10}\tTextPurchases:{11}\tTextRating:{12} ", Inf, read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(),  read[6].ToString(), read[7].ToString(), read[8].ToString(), read[9].ToString(), read[10].ToString(), read[11].ToString(), read[12].ToString());
            }
            StreamWriter output = new StreamWriter(fileStream);
            output.Write(Inf);
            output.Close();
            return text;
        }

        public PhotoInf GetPhotoInfByid(string id)
        {
           
            MySqlCommand command = new MySqlCommand($"Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`photo` ON qulixtestdb.`author`.id = qulixtestdb.`photo`.authorid WHERE qulixtestdb.`photo`.name='{id}';", db.getConnection());
            MySqlDataReader read = command.ExecuteReader();
            PhotoInf photo = new PhotoInf();
            while (read.Read())
            {
                photo.AuthorId = Convert.ToInt32(read[0]);
                photo.AuthorNAme = Convert.ToString(read[1]);
                photo.AuthorNik = Convert.ToString(read[2]);
                photo.AuthorOld = Convert.ToInt32(read[3]);
                photo.AuthorDate = Convert.ToString(read[4]);
                photo.PhotoName = Convert.ToString(read[6]);
                photo.PhotoUrl = Convert.ToString(read[7]);
                photo.PhotoSize = Convert.ToString(read[8]);
                photo.PhotoDate = Convert.ToString(read[9]);
                photo.PhotoPrice = Convert.ToInt32(read[10]);
                photo.PhotoPurchases = Convert.ToInt32(read[11]);
                photo.PhotoRating = Convert.ToInt32(read[12]);
            }
            return photo;
        }
        public void ChangePhoto(Photomodel model) {
            Photomodel m = model;   
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand($"UPDATE qulixtestdb.`photo` SET rating='{m.PhotoRating}', authorid='{m.AuthorId}',purchases='{m.PhotoPurchases}', mydate='{m.PhotoDate}', url='{m.PhotoUrl}',price='{m.PhotoPrice}', size='{m.PhotoSize}' WHERE name='{m.PhotoName}';", db.getConnection());
            command.ExecuteNonQuery();
            db.closeConnection();
        }

        public List<CommonModel> GetAllContent(int page) {
            db.OpenConnection();
            
            List<CommonModel> AllInformation = new List<CommonModel>();
            MySqlCommand command1 = new MySqlCommand("Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`text` ON  qulixtestdb.`author`.id = qulixtestdb.`text`.authorid;", db.getConnection());
            MySqlCommand command2 = new MySqlCommand("Select * FROM qulixtestdb.`author` INNER JOIN qulixtestdb.`photo` ON  qulixtestdb.`author`.id = qulixtestdb.`photo`.authorid;  ", db.getConnection());
            MySqlDataReader read1 = command1.ExecuteReader();
            while (read1.Read())
            {
                var a = new CommonModel();
                a.AuthorId = Convert.ToInt32(read1[0]);
                a.AuthorNAme = Convert.ToString(read1[1]);
                a.AuthorNik = Convert.ToString(read1[2]);
                a.AuthorOld = Convert.ToInt32(read1[3]);
                a.AuthorDate = Convert.ToString(read1[4]);
                a.Name = Convert.ToString(read1[6]);
                a.Information = Convert.ToString(read1[7]);
                a.Size = Convert.ToString(read1[8]);
                a.Date = Convert.ToString(read1[9]);
                a.Price = Convert.ToInt32(read1[10]);
                a.Purchases = Convert.ToInt32(read1[11]);
                a.Rating = Convert.ToInt32(read1[12]);
                AllInformation.Add(a);
            }
            db.closeConnection();
            db.OpenConnection();
            MySqlDataReader read2 = command2.ExecuteReader();
            while (read2.Read())
            {
                var a = new CommonModel();
                a.AuthorId = Convert.ToInt32(read2[0]);
                a.AuthorNAme = Convert.ToString(read2[1]);
                a.AuthorNik = Convert.ToString(read2[2]);
                a.AuthorOld = Convert.ToInt32(read2[3]);
                a.AuthorDate = Convert.ToString(read2[4]);
                a.Name = Convert.ToString(read2[6]);
                a.Information = Convert.ToString(read2[7]);
                a.Size = Convert.ToString(read2[8]);
                a.Date = Convert.ToString(read2[9]);
                a.Price = Convert.ToInt32(read2[10]);
                a.Purchases = Convert.ToInt32(read2[11]);
                a.Rating = Convert.ToInt32(read2[12]);
                AllInformation.Add(a);
            }
            db.closeConnection();
            
            PageSettings settings = new PageSettings();
            settings.PageNumber = page;
            try
            {
                int diapazone1 = ((settings.PageNumber * settings.PageSize) - settings.PageSize);
                var PageInformation = AllInformation.GetRange(diapazone1, settings.PageSize);
                return PageInformation;
            }
            catch (ArgumentException)
            {
                var ExAllInformation = AllInformation.GetRange(AllInformation.Count()-2, settings.PageSize);
                return ExAllInformation;
            }
        }
        }


    }

