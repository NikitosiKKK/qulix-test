using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoins.Models
{
    public class GetContent
    {
        DB db = new DB();
        

        public string GetPhotoContent()
        {
            db.OpenConnection();
            string comand =db.GetPhotoInf();
            db.closeConnection();
            return comand;
        }
        public string GetTextContent()
        {
            db.OpenConnection();
            string comand = db.GetTextInf();
            db.closeConnection();
            return comand;
        }
        public string GetPhotoById(string id) {
            db.OpenConnection();
            string comand = db.GetPhotoById(id);
            db.closeConnection();
            return comand;
        }
    }
}
