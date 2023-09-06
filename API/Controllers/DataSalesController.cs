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
    public class DataSalesController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IDataSalesRepository _datasales;

        public DataSalesController(IAccountRepository account, JwtService jwtService, IDataSalesRepository datasales)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _datasales = datasales;
        }

        [HttpGet("SalesByStore")]
        public IActionResult GetDataSalesByStore(int idlokasi, int tipelokasi)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _datasales.GetDataSalesByStore(idlokasi, tipelokasi);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("SalesById")]
        public IActionResult GetDataSalesById(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _datasales.GetDataSalesByID(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("SalesByKeyword")]
        public IActionResult GetDataSalesByKeyword(string keyword = "", string kode = "")
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _datasales.GetDataSalesByKeyword(keyword, "");
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpGet("SalesCrossBrandByStore")]
        public IActionResult GetDataSalesCrossBrandByStore(string brand, string locationcode, string keyword)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _datasales.GetDataSalesCrossBrandByStore(brand,locationcode, keyword);
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
