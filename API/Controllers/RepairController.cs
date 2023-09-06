using Connection.Interface;
using Connection.Models;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IRepairRepository _repair;
        private Common _common;

        public RepairController(IAccountRepository account, JwtService jwtService, IRepairRepository repair)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _repair = repair;
            _common = new Common();
        }

        [HttpGet("GetCharProcessRepair")]
        public IActionResult GetCharProcessRepair()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.GetCharProcessRepair();
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetRepairByID")]
        public IActionResult GetRepairByID(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.GetRepair(id);

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

        [HttpGet("GetRepairResultByID")]
        public IActionResult GetRepairResultByID(int id_repair_result)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.GetRepairResult(id_repair_result);

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

        [HttpPost("AddRepair")]
        public IActionResult AddRepair([FromForm] RequestRepair rr)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.AddRepair(rr);

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

        [HttpGet("GetRepairItemByCustomer")]
        public IActionResult GetRepairItemByCustomer(int idcustomer, string custlama)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.GetRepairItemByCustomer(idcustomer, custlama);

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

        [HttpGet("ReportRepair")]
        public IActionResult ReportRepair(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.ReportRepair(kw, start, end, location, status, page, row, excel);

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

        [HttpGet("ReportRepairResult")]
        public IActionResult ReportRepairResult(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.ReportRepairResult(kw, start, end, location, status, page, row, excel);

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

        [HttpGet("GetListInvoiceRepair")]
        public IActionResult GetListInvoiceRepair(string kw, string location, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.GetListInvoiceRepair(kw,location,page,row,excel);

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

        [HttpPost("AddRepairInvoice")]
        public IActionResult AddRepairInvoice(RequestRepairResult rr)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.AddRepairInvoice(rr);

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

        [HttpPost("AddPaymentRepair")]
        public IActionResult AddPaymentRepair(RequestSalesOrderRepair ror)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.AddPaymentRepair(ror, _auth.UserName);

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

        [HttpPost("PostRepairCS")]
        public IActionResult AddPaymentRepair(string nomor)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.PostingRepairToMyapps(nomor);

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

        [HttpPost("UploadImageRepair")]
        public IActionResult UploadImageRepair([FromForm] IFormFile files, int id, string brand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _repair.UploadImageRepair(files, id, brand);
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

        [HttpGet("PrintRepair")]
        public async Task<IActionResult> PrintRepair(string id, int idstock)
        {
            string idproduct = idstock > 0 ? "&idstock=" + idstock : "";
            string url = _common.GetUrlJAWS() + "Print/Repair/Repair_Print.aspx?id=" + id + idproduct;
            using (HttpClient httpClient = new HttpClient())
            {
                string result = await httpClient.GetStringAsync(url);
                return new ContentResult
                {
                    Content = result,
                    ContentType = "text/html"
                };
            }
        }

        [HttpGet("PrintRepair2")]
        public async Task<IActionResult> PrintRepair2(string id, int idstock)
        {
            string idproduct = idstock > 0 ? "&idstock=" + idstock : "";
            string url = _common.GetUrlJAWS() + "Print/Repair/Repair_Print2.aspx?id=" + id + idproduct;
            using (HttpClient httpClient = new HttpClient())
            {
                string result = await httpClient.GetStringAsync(url);
                return new ContentResult
                {
                    Content = result,
                    ContentType = "text/html"
                };
            }
        }

        [HttpGet("PrintRepairInvoice")]
        public async Task<IActionResult> PrintRepairInvoice(string id)
        {
            string url = _common.GetUrlJAWS() + "Print/Repair/RepairInvoice_Print.aspx?id=" + id;
            using (HttpClient httpClient = new HttpClient())
            {
                string result = await httpClient.GetStringAsync(url);
                return new ContentResult
                {
                    Content = result,
                    ContentType = "text/html"
                };
            }
        }
    }
}