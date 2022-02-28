using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoins.Models
{
   public class Photomodel
    {
        public int AuthorId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoSize { get; set; }
        public string PhotoDate { get; set; }
        public int PhotoPrice { get; set; }
        public int PhotoPurchases { get; set; }
        public int PhotoRating { get; set; }
    }
}
