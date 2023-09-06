using Connection.Interface;
using Connection.RequestModels.PCS;
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
    public class CetakanController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly ICetakanRepository _cetakan;

        public CetakanController(IAccountRepository account, JwtService jwtService, ICetakanRepository cetakan)
        {
            _cetakan = cetakan;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
        }

        [HttpGet("Cetakan")]
        public IActionResult GetCetakan()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = _cetakan.GetCetakan();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ListCetakan")]
        public IActionResult GetListCetakan(string keyword = "", int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _cetakan.GetListCetakan(keyword, status);
                }

                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpGet("DetailCetakan")]
        public IActionResult GetDetailCetakan(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _cetakan.GetDetailCetakan(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpPost("InsertCetakan")]
        public IActionResult InsertCetakan([FromForm] PCS product)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _cetakan.InsertCetakan(product);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }


        [HttpPut("UpdateCetakan")]
        public IActionResult UpdateCetakan([FromForm] PCS product)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _cetakan.UpdateCetakan(product, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpGet("ListReceiveCetakan")]
        public IActionResult GetListReceiveCetakan(int idlokasi, string from, string to)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _cetakan.GetReceiveCetakan(idlokasi, from, to, _auth.isApproval("PCS"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpGet("DetailReceiveCetakan")]
        public IActionResult GetDetailReceiveCetakan(int id = 0, int idlokasi = 0, int idproduct = 0, string from = "", string to = "", int issummary = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _cetakan.GetDetailReceiveCetakan(id, idlokasi, idproduct, from, to, issummary, _auth.isApproval("PCS"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpPost("InsertReceiveCetakan")]
        public IActionResult InsertReceiveCetakan(ReceivePCS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _cetakan.InsertReceivingCetakan(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpPut("ApproveReceiveCetakan")]
        public IActionResult ApproveReceiveCetakan(ReceivePCS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _cetakan.ApproveReceivingCetakan(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpDelete("DeleteReceiveCetakan")]
        public IActionResult DeleteReceiveCetakan(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _cetakan.DeleteReceivingCetakan(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpDelete("DeleteReceivedCetakan")]
        public IActionResult DeleteReceivedCetakan(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _cetakan.DeleteReceivedCetakan(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }

        [HttpGet("ListPemakaianCetakan")]
        public IActionResult GetListPemakaianCetakan(int tipelokasi = 0, int idlokasi = 0, int idproduct = 0, string from = "1900-01-01", string to = "1900-01-01", string keyword = "")
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _cetakan.GetPemakaianCetakan(tipelokasi, idlokasi, idproduct, from, to, keyword);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    messsage = ex.Message
                });
            }
        }
    }
}
