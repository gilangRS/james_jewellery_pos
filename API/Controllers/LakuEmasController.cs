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
    public class LakuEmasController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly ICharacterRepository _repository;
        private readonly ILakuEmasRepository _lakuemas;

        public LakuEmasController(IAccountRepository account, JwtService jwtService, ICharacterRepository repository, ILakuEmasRepository lakuemas)
        {
            _repository = repository;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
            _lakuemas = lakuemas;
        }

        [HttpGet("GetRateLEI")]
        public IActionResult GetRateLEI()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _lakuemas.GetRateLEI();
                    return Ok(collection);
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
