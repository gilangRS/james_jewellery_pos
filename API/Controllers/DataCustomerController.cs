using Connection.Interface;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataCustomerController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IDataCustomerRepository _datacustomer;

        public DataCustomerController(IAccountRepository account, JwtService jwtService, IDataCustomerRepository datacustomer)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _datacustomer = datacustomer;
        }

        [HttpGet("CustomerByKeywords")]
        public IActionResult GetDataCustomerByStore(string kw, int searchby = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    kw = string.IsNullOrEmpty(kw) ? "" : kw;
                    collection = _datacustomer.GetDataCustomerByKeyword(kw, searchby);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("CustomerByID")]
        public IActionResult GetDataCustomerByID(int id = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _datacustomer.GetDataCustomerByID(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
