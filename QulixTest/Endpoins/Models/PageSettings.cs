using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoins.Models
{
    public class PageSettings
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public  PageSettings(){
            PageSize = 2;
            PageNumber = 1;
}

    }
}
