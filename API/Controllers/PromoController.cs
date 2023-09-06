using Connection.Interface;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IPromoRepository _promo;

        public PromoController(IAccountRepository account, JwtService jwt, IPromoRepository promo)
        {
            _account = account;
            _promo = promo;
            _jwtService = jwt;
            _auth = new Auth(_account, _jwtService);
        }

        [HttpGet("PromoDJList")]
        public IActionResult GetPromoDJList(string keyword = "", int tipelokasi = 9, int idlokasi = 0, int status = 1)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _promo.GetPromoDJList(keyword, tipelokasi, idlokasi, status);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("PromoPGList")]
        public IActionResult GetPromoPGList(string keyword = "", int tipelokasi = 9, int idlokasi = 0, int status = 1)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _promo.GetPromoDJList(keyword, tipelokasi, idlokasi, status);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
    }

    
}
