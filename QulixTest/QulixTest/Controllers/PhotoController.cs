using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Endpoins.Models;
namespace QulixTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        GetContent content = new GetContent();
        //string AuthorNAme, AuthorNik, PhotoName, PhotoUrl, PhotoSize, PhotaRating, TextName, TextContent, TextSize, TextRating;
        //int AuthorOld, PhotoPrice, PhotoPurchases, TextPrice, TextPurchases;
      
        [HttpGet]
        public string GetAll()
        {
            return content.GetPhotoContent();
        }
        [HttpGet("allphotos")]
        public string GetAllPhotos()
        {
            return content.GetPhotoContent();
        }

        [HttpGet("{id}")]
        public string GetPhotoById(string id)
        {
            
            return content.GetPhotoById(id);
        }
        [HttpGet("getalltext")]
        public string GetAllText()
        {
            return content.GetTextContent();
        }
    }
}