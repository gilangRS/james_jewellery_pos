using Connection.Interface;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using System.IO.Pipes;
using Connection.RequestModels.Images;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly Common _common;

        public ImageController(IAccountRepository account, JwtService jwtService, IProductRepository product)
        {
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
            _common = new Common();
        }


        [HttpGet]
        public async Task<IActionResult> Get(string img)
        {
            string ContentType = string.Empty;
            string Ext = img.Split('.', StringSplitOptions.None).Last();

            if (Ext == "png") ContentType = "image/png";
            else if (Ext == "jpg") ContentType = "image/jpeg";
            else if (Ext == "jpeg") ContentType = "image/jpeg";
            else if (Ext == "bmp") ContentType = "image/bmp";


            byte[] b;

            if (!System.IO.File.Exists(img) || string.IsNullOrEmpty(ContentType))
            {
                ContentType = "image/png";
                b = System.IO.File.ReadAllBytes("D:\\Web\\api-jaws-frank\\assets\\no_image.png");
            }
            else b = System.IO.File.ReadAllBytes(img);
            return File(b, ContentType);
        }


        [HttpGet("Image64")]
        public async Task<IActionResult> Get64(string img)
        {
            string ContentType = string.Empty;
            string Ext = img.Split('.', StringSplitOptions.None).Last();

            if (Ext == "png") ContentType = "image/png";
            else if (Ext == "jpg") ContentType = "image/jpeg";
            else if (Ext == "jpeg") ContentType = "image/jpeg";
            else if (Ext == "bmp") ContentType = "image/bmp";


            byte[] b;

            if (!System.IO.File.Exists(img) || string.IsNullOrEmpty(ContentType))
            {
                ContentType = "image/png";
                b = System.IO.File.ReadAllBytes("D:\\Web\\api-jaws-frank\\assets\\no_image.png");
            }
            else b = System.IO.File.ReadAllBytes(img);

            return Ok(Convert.ToBase64String(b));
        }

        [HttpGet("CheckImage")]
        public IActionResult CheckImage(string path, DateTime tgl)
        {
            try
            {
                string pathnew = path.ToUpper();
                if (!System.IO.File.Exists(pathnew))
                {
                    return Ok();
                }
                else
                {
                    var filetime = System.IO.File.GetLastWriteTime(pathnew);
                    if (filetime < tgl)
                    {
                        return Ok();
                    }
                    else return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UploadImage")]
        public IActionResult UploadImage([FromForm] RequestUploadImages request)
        {
            try
            {
                using (System.IO.FileStream filestream = System.IO.File.Create(request.Path.ToUpper()))
                {
                    request.File.CopyTo(filestream);
                    filestream.Flush();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
