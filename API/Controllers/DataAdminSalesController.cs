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
    public class DataAdminSalesController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IDataAdminSalesRepository _dataadminsales;

        public DataAdminSalesController(IAccountRepository account, JwtService jwtService, IDataAdminSalesRepository dataadminsales)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _dataadminsales = dataadminsales;
        }

        [HttpGet("AdminSalesById")]
        public IActionResult GetDataAdminSalesById(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _dataadminsales.GetDataAdminSalesByID(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("AdminSalesByUserId")]
        public IActionResult GetDataAdminSalesByUserId(int userid)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _dataadminsales.GetDataAdminSalesByUserID(userid);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("AdminSalesByKeyword")]
        public IActionResult GetDataAdminSalesByKeyword(string kw)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    kw = string.IsNullOrEmpty(kw) ? "" : kw;
                    collection = _dataadminsales.GetDataAdminSalesByKeyword(kw);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("AdminSalesByStore")]
        public IActionResult GetDataAdminSalesByStore(int idlokasi, int tipelokasi)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _dataadminsales.GetDataAdminSalesByStore(idlokasi, tipelokasi);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("AdminSalesByLogin")]
        public IActionResult GetDataAdminSalesByLogin()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _dataadminsales.GetDataAdminSalesByUserID(_auth.UserID);
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
