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
        [HttpGet]
        public  string GetAll()
        {
            return content.GetAllContent();
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "The Value is " + id;
        }

    }
}
