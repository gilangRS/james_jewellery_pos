using Connection.Interface;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IEventRepository _events;

        public EventController(IAccountRepository account, JwtService jwtService, IEventRepository events)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _events = events;
        }

        [HttpPost("AddPromoEvent")]
        public IActionResult AddPromoEvent(RequestPromoEvent pe)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.AddPromoEvent(pe);

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

        [HttpGet("GetPromoEventByID")]
        public IActionResult GetPromoEvent(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.GetPromoEvent(id);

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

        [HttpGet("GetActivePromoEvent")]
        public IActionResult GetActivePromoEvent()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.GetActivePromoEvent();
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("ReportPromoEvent")]
        public IActionResult ReportPromoEvent(string kw, string startdate, string enddate, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.ReportPromoEvent(kw, startdate, enddate, status, page, row, excel);

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

        [HttpPut("ApprovalPromoEvent")]
        public IActionResult ApprovalPromoEvent(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.ApprovalPromoEvent(id, _auth.UserName);

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

        [HttpPut("DisablePromoEvent")]
        public IActionResult DisablePromoEvent(int id, string operatornama, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.DisablePromoEvent(id, operatornama, keterangan);

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

        [HttpPost("AddPromoBank")]
        public IActionResult AddPromoBank(RequestPromoBank rb)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.AddPromoBank(rb);

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

        [HttpGet("GetPromoBankByID")]
        public IActionResult GetPromoBank(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.GetPromoBank(id);

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

        [HttpGet("GetActivePromoBank")]
        public IActionResult GetActivePromoBank(int id, string producttype)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.GetActivePromoBank(id, producttype);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("ReportPromoBank")]
        public IActionResult ReportPromoBank(string kw, string startdate, string enddate, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.ReportPromoBank(kw, startdate, enddate, status, page, row, excel);

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

        [HttpPut("ApprovalPromoBank")]
        public IActionResult ApprovalPromoBank(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.ApprovalPromoBank(id, _auth.UserName);

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

        [HttpPut("DisablePromoBank")]
        public IActionResult DisablePromoBank(int id, string operatornama, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.DisablePromoBank(id, operatornama, keterangan);

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

        [HttpGet("GetRoleApproval")]
        public IActionResult GetRoleApproval(int iduser)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.GetRoleApproval(iduser);

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

        [HttpGet("ReportPromoBank")]
        public IActionResult ReportPromoBank(string kw, string startdate, string enddate, string location, int tipe, int status, int page, int rows, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _events.ReportPemakaianPromo(kw, startdate, enddate, location, tipe, status, page, rows, excel);

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
