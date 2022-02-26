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
            return content.GetAllContent();
        }
        [HttpGet("allphotos")]
        public string GetAllPhotos()
        {
            return "The Value is ";
        }

        [HttpGet("photobyid")]
        public string GetPhotoById()
        {
            return "The Value is ";
        }
        [HttpGet("getalltext")]
        public string GetAllText()
        {
            return "The Value is ";
        }
    }
}