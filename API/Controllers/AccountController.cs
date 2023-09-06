using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connection.Interface;
using API.ViewModel;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Connection.AccountModels;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {


        private readonly IAccountRepository _repository;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;

        public AccountController(IAccountRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
            _auth = new Auth(_repository, _jwtService);
        }

        [HttpPost("Login")]
        public IActionResult Login(UserViewModel login)
        {
            string message = string.Empty;
            string Token = string.Empty;

            var account = _repository.GetAccountByEmail(login.Email);

            if (account == null) return BadRequest(new { messsage = "Invalid Credential" });
            if(_repository.Login(login.Email, login.Password, ref message))
            {
                Token = _jwtService.Generate(account.Id);
                Response.Cookies.Append("token", Token, new CookieOptions 
                { 
                    HttpOnly = true
                });
            }
            else return BadRequest(new { messsage = message });

            return Ok(new
            {
                token = Token,
                message = "Success"
            }); ;
        }

        [HttpGet("CheckNIK")]
        public IActionResult CheckNIK(string nik)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repository.GetDataByNIK(nik);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("UserAccount")]
        public IActionResult GetUserAccount(string keyword, int status)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repository.GetUserAccount(keyword, status);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("UserDetail")]
        public IActionResult GetUserDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repository.GetUserDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount(string nik, string jabatan, string email)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _repository.CreateAccount(nik, jabatan, email);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpPut("UpdatePassword")]
        public IActionResult UpdatePassword(string oldpass, string newpass)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _repository.UpdatePassword(_auth.UserID, oldpass, newpass);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("GetAllAccess")]
        public IActionResult GetAllAccess(int userid)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repository.GetAllAccess(userid);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetRoleAccess")]
        public IActionResult GetRoleAccess(int roleid)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repository.GetRoleAccess(roleid);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("User")]
        public IActionResult GetUser()
        {
            UserViewModel user;
            try
            {
                user = _auth.GetUser(Request.Headers["Authorization"]);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = "Hasn't Log in" });
            }
            return Ok(new 
            {
                email = user.Email,
                nama = user.Nama,
                nik = user.NIK,
                isFrank = user.IsFrank,
                isMondial = user.IsMondial,
                isPalace = user.IsPalace,
                firstLogin = user.FirstLogin
            });
        }

        [HttpGet("UserRole")]
        public IActionResult GetUserAccess() 
        {
            UserViewModel user;
            try
            {
                user = _auth.GetUser(Request.Headers["Authorization"]);
            }
            catch
            {
                return BadRequest(new { messsage = "Hasn't Log in" });
            }
            return Ok(new { userrole = user.UserRole });
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("token");

            return Ok(new { message = "Success" });
        }

        [HttpGet("Menu")]
        public IActionResult GetMenu()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<Menus> collection;
                if (_auth.IsAuthentic(token))
                {
                    collection = _repository.GetUserAccess(_auth.UserID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });
                return Ok(collection);
            }

            catch { return StatusCode(400); }
        }

    }
}
