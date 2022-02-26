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
            db.OpenConnection();
            string comand =db.GetInf();
            db.closeConnection();
            return comand;
        }
    }
}
