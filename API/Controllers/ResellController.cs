using Connection.Interface;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Connection.Settings.StampsConfiguration;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResellController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IResellRepository _resell;
        private readonly ILocationRepository _location;
        private Common _common;

        public ResellController(IAccountRepository account, JwtService jwtService, IResellRepository resell, ILocationRepository location)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _resell = resell;
            _common = new();
            _location = location;
        }

        [HttpGet("GetResellByID")]
        public IActionResult GetResellByID(int id, int tipelokasi, int idlokasi)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.GetResell(id);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("GetResellItemByCustomer")]
        public IActionResult GetResellItemByCustomer(int idcustomer, string custlama, string tipetransaksi)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.GetResellItemByCustomer(idcustomer, custlama, tipetransaksi);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut("VoidResell")]
        public IActionResult VoidResell(int id, string operatornama, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.VoidResell(id, operatornama, keterangan);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("ValidationAddResell")]
        public IActionResult ValidationAddResell(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.ValidationAddResell(id);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost("AddResell")]
        public IActionResult AddResell(RequestResell rr)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.AddResell(rr);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("ReportResell")]
        public IActionResult ReportResell(string kw, string start, string end, string location, int reselltype, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.ReportResell(kw, start, end, location, reselltype, status, page, row, excel);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("ReportResellDetail")]
        public IActionResult ReportResellDetail(string kw, string start, string end, string location, string producttype, int reselltype, int item, int kategori, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.ReportResellDetail(kw, start, end, location, producttype, reselltype, item, kategori, status, page, row, excel);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost("CheckPLUResell")]
        public IActionResult AddPLUDJ(string nomor, string brand, string tipe)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;
                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.CheckPLUResell(nomor, brand, tipe);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost("AddPLUDJ")]
        public IActionResult AddPLUDJ(RequestAddPLUDJ product)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;
                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.AddPLUDJ(product, _auth.UserName, _location.GetDataLocation(_common.IDBrand(), product.TipeLokasi, product.IDLokasi).IDBrand);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost("AddPLULD")]
        public IActionResult AddPLULD(RequestAddPLULD product)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;
                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.AddPLULD(product, _auth.UserName, _location.GetDataLocation(_common.IDBrand(), product.TipeLokasi, product.IDLokasi).IDBrand);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost("AddPLUPG")]
        public IActionResult AddPLUPG(RequestAddPLUPG product)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;
                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.AddPLUPG(product, _auth.UserName, _location.GetDataLocation(_common.IDBrand(), product.TipeLokasi, product.IDLokasi).IDBrand);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("DeletePLUDJ")]
        public IActionResult DeletePLUDJ(string nomor)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;
                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.DeletePLUDJ(nomor);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("DeletePLUPG")]
        public IActionResult DeletePLUPG(string nomor)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;
                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.DeletePLUPG(nomor);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("DeletePLULD")]
        public IActionResult DeletePLULD(string nomor)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;
                if (_auth.IsAuthentic(token))
                {
                    collection = _resell.DeletePLULD(nomor);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if (message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400, collection);
                    }
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
