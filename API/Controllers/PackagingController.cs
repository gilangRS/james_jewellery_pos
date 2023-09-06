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
    public class PackagingController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IPackagingRepository _packaging;

        public PackagingController(IAccountRepository account, JwtService jwtService, IPackagingRepository packaging)
        {
            _packaging = packaging;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
        }

        [HttpGet("Packaging")]
        public IActionResult GetPackaging()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = _packaging.GetPackaging();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ListPackaging")]
        public IActionResult GetListPackaging(string keyword = "", int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _packaging.GetListPackaging(keyword, status);
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

        [HttpGet("DetailPackaging")]
        public IActionResult GetDetailPackaging(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _packaging.GetDetailPackaging(id);
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

        [HttpPost("InsertPackaging")]
        public IActionResult InsertPackaging([FromForm] PCS product)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _packaging.InsertPackaging(product);
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


        [HttpPut("UpdatePackaging")]
        public IActionResult UpdatePackaging([FromForm] PCS product)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _packaging.UpdatePackaging(product, _auth.UserName);
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



        [HttpGet("ListReceivePackaging")]
        public IActionResult GetListReceivePackaging(int idlokasi, string from, string to)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _packaging.GetReceivePackaging(idlokasi, from, to, _auth.isApproval("PCS"));
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

        [HttpGet("DetailReceivePackaging")]
        public IActionResult GetDetailReceivePackaging(int id = 0, int idlokasi = 0, int idproduct = 0, string from = "", string to = "", int issummary = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _packaging.GetDetailReceivePackaging(id, idlokasi, idproduct, from, to, issummary, _auth.isApproval("PCS"));
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

        [HttpPost("InsertReceivePackaging")]
        public IActionResult InsertReceivePackaging(ReceivePCS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _packaging.InsertReceivingPackaging(datas, _auth.UserName);
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

        [HttpPut("ApproveReceivePackaging")]
        public IActionResult ApproveReceivePackaging(ReceivePCS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _packaging.ApproveReceivingPackaging(datas, _auth.UserName);
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

        [HttpDelete("DeleteReceivePackaging")]
        public IActionResult DeleteReceivePackaging(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _packaging.DeleteReceivingPackaging(id);
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

        [HttpDelete("DeleteReceivedPackaging")]
        public IActionResult DeleteReceivedPackaging(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _packaging.DeleteReceivedPackaging(id);
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


        [HttpGet("ListPemakaianPackaging")]
        public IActionResult GetListPemakaianPackaging(int tipelokasi = 0, int idlokasi = 0, int idproduct = 0, string from = "1900-01-01", string to = "1900-01-01", string keyword = "")
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _packaging.GetPemakaianPackaging(tipelokasi, idlokasi, idproduct, from, to, keyword);
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
