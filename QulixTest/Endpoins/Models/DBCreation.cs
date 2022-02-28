using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endpoins.Models
{
    public class DBCreation
    {
        DB db = new DB();
        
        public void CreateDB() {
            db.OpenConnection();
            MySqlCommand command0 = new MySqlCommand("CREATE DATABASE qulixtestdb", db.getConnection());
        MySqlCommand command1 = new MySqlCommand("CREATE TABLE qulixtestdb.`author` (id int NOT null AUTO_INCREMENT, name varchar(30), nikname varchar(30), old int, mydate TIMESTAMP DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY(id))", db.getConnection());
        MySqlCommand command2 = new MySqlCommand("CREATE TABLE qulixtestdb.`photo` (authorid int NOT null, name varchar(30), url varchar(1000), size varchar(30), mydate TIMESTAMP DEFAULT CURRENT_TIMESTAMP, price int, purchases int, rating int not null, FOREIGN KEY(authorid) REFERENCES author(id))", db.getConnection());
        MySqlCommand command3 = new MySqlCommand("CREATE TABLE qulixtestdb.`text` (authorid int NOT null, name varchar(100), content varchar(100), size varchar(30), mydate TIMESTAMP DEFAULT CURRENT_TIMESTAMP, price int, purchases int(255), rating int not null, FOREIGN KEY(authorid) REFERENCES author(id))", db.getConnection());
        MySqlCommand command4 = new MySqlCommand("INSERT INTO qulixtestdb.`author` (name, nikname, old) VALUES('Иван Сергеевич','Kozar', '29'), ('Никита Сергеевич', 'Rentgen', '23'), ('Карина Каптур', 'Karikap', '20'), ('Елена Николаевна', 'Elesuk', '24')", db.getConnection());
        MySqlCommand command5 = new MySqlCommand("INSERT INTO qulixtestdb.`photo` (authorid, name, url, size, price, purchases, rating) VALUES('2','Вождение Ренеры', 'https://art-storona.ru/wp-content/uploads/2015/03/2009-1-12-1m.jpg','1,72 м x 2,78 м','250','20','0'), ('1','Лона Миза', 'https://content1.rozetka.com.ua/goods/images/big/181734931.jpg','77 см x 53 см','500','598592','0'),('1','Аотворение Сдама', 'https://www.medswiss.ru/upload/medialibrary/5b9/5b9305d66b0912adbb3db43728997436.png','2,8 м x 5,7 м','550','231','0'),('3','Девушка с жемчужной машкой', 'https://s11.stc.yc.kpcdn.net/share/i/12/11046914/wr-960.webp','44 см x 39 см','100','2490','0'),('3','Керный Чвадрат', 'https://www.theartnewspaper.ru/media/original_images/0f770400-3dac-4bea-ad40-44c13e478f83.jpg','80 см x 80 см','1','0','0'),('1','Кирк', 'https://cdnn21.img.ria.ru/images/57145/75/571457532_0:155:566:721_1920x0_80_0_0_7401411e5b3308b61650379c7f5939fb.jpg','70 см x 90 см','560','514','0')",db.getConnection());
        MySqlCommand command6 = new MySqlCommand("INSERT INTO qulixtestdb.`text` (authorid, name, content, size, price, purchases, rating) VALUES('1','Вышел из воды с ухой', 'Кулинарная книга','1 том','50','100','0'), ('2','Как убежать от Биар Грилса', 'Уроки выживания для насекомых','205 страниц','1','1000000000','0'),('3','Подари розу брату', 'Уроки стеклодува','321 страниц','256','263','0'),('4','От сердца и почек, а что это за комочек?', 'Хирургия стран СНГ','500 страниц','536','23452534','0'),('2','Пять минут полет норма...', 'Краткое обучение о том как сложить парашют','лист','12','0','0'),('4','Ура удаленке!', 'ГДЗ','765 страниц','150','1275','0'), ('1','Я не лучница, а стрелочница!', 'Психология для женщин','1500 страниц','500','10201','0')", db.getConnection());
        command0.ExecuteNonQuery();
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            Thread.Sleep(500);
            command4.ExecuteNonQuery();
            command5.ExecuteNonQuery();
            command6.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}