using Connection.Interface;
using Connection.RequestModels.PCS;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SouvenirController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly ISouvenirRepository _souvenir;
        private Common _common;

        public SouvenirController(IAccountRepository account, JwtService jwtService, ISouvenirRepository souvenir)
        {
            _souvenir = souvenir;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
            _common = new Common();
        }

        [HttpGet("Souvenir")]
        public IActionResult GetSouvenir()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = _souvenir.GetSouvenir();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ListSouvenir")]
        public IActionResult GetListSouvenir(string keyword = "", int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _souvenir.GetListSouvenir(keyword, status);
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

        [HttpGet("DetailSouvenir")]
        public IActionResult GetDetailSouvenir(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _souvenir.GetDetailSouvenir(id);
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

        [HttpPost("InsertSouvenir")]
        public IActionResult InsertSouvenir([FromForm] PCS product)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _souvenir.InsertSouvenir(product);
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


        [HttpPut("UpdateSouvenir")]
        public IActionResult UpdateSouvenir([FromForm] PCS product)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _souvenir.UpdateSouvenir(product, _auth.UserName);
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



        [HttpGet("ListReceiveSouvenir")]
        public IActionResult GetListReceiveSouvenir(int idlokasi, string from, string to)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _souvenir.GetReceiveSouvenir(idlokasi, from, to, _auth.isApproval("PCS"));
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

        [HttpGet("DetailReceiveSouvenir")]
        public IActionResult GetDetailReceiveSouvenir(int id = 0, int idlokasi = 0, int idproduct = 0, string from = "", string to = "", int issummary = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _souvenir.GetDetailReceiveSouvenir(id, idlokasi, idproduct, from, to, issummary, _auth.isApproval("PCS"));
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

        [HttpPost("InsertReceiveSouvenir")]
        public IActionResult InsertReceiveSouvenir(ReceivePCS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _souvenir.InsertReceivingSouvenir(datas, _auth.UserName);
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

        [HttpPut("ApproveReceiveSouvenir")]
        public IActionResult ApproveReceiveSouvenir(ReceivePCS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _souvenir.ApproveReceivingSouvenir(datas, _auth.UserName);
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

        [HttpDelete("DeleteReceiveSouvenir")]
        public IActionResult DeleteReceiveSouvenir(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _souvenir.DeleteReceivingSouvenir(id);
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

        [HttpDelete("DeleteReceivedSouvenir")]
        public IActionResult DeleteReceivedSouvenir(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _souvenir.DeleteReceivedSouvenir(id);
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

        [HttpGet("ListPemakaianSouvenir")]
        public IActionResult GetListPemakaianSouvenir(int tipelokasi = 0, int idlokasi = 0, int idproduct = 0, string from = "1900-01-01", string to = "1900-01-01", string keyword = "")
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _souvenir.GetPemakaianSouvenir(tipelokasi, idlokasi, idproduct, from, to, keyword);
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
