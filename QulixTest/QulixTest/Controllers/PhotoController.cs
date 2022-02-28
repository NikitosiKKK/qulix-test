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

        //Получаем вывод всех данных.В page указываем номер страницы.
        [HttpGet("getalltext_page={page}")]
        public List<CommonModel> GetAllContent(int page)
        {
            return content.GetAllContent(page);
        }
        //Получаем вывод всех фото.В page указываем номер страницы.
        [HttpGet("allphotos_page={page}")]
        public List<PhotoInf> GetAllPhotos(int page)
        {
            return content.GetPhotoContent(page);
        }
        //Получаем фото по Id.
        [HttpGet("id={id}")]
        public PhotoInf GetPhotoById(string id)
        {

            return content.GetPhotoById(id);
        }
        //Получаем все сущности text, с записью в файл txt.
        [HttpGet("getalltext")]
        public List<TextInf> GetAllText()
        {
            return content.GetTextContent();
        }
        //Меняем сущность фото по имени.
        [HttpPost("change")]
        public void Create([FromBody]Photomodel model)
        {
         content.ChangePhoto(model);
        }
        //Вызов для создани БД.
        [HttpGet("createdb")]
        public void CreateDB([FromBody] Photomodel model)
        {
            DBCreation db = new DBCreation();
            db.CreateDB();
        }

    }
} 