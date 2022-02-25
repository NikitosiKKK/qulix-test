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
        

        public string GetAllContent()
        {
            string comand = "Select * from qulixtestdb.`author`";
            db.OpenConnection();
            comand= db.GetInf(comand);
            db.closeConnection();
            return comand;
        }
    }
}
