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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocQCController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IDocQCRepository _docqc;
        private readonly Common _common;

        public DocQCController(IAccountRepository account, JwtService jwtService, IDocQCRepository docqc)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _docqc = docqc;
            _common = new Common();
        }

        [HttpPost("AddQCDJ")]
        public IActionResult AddQCDJ(RequestDocQCDJ dj)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.AddQCDJ(dj, _auth.UserName);

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

        [HttpPost("AddQCPG")]
        public IActionResult AddQCPG(RequestDocQCPG pg)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.AddQCPG(pg, _auth.UserName);

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

        [HttpPost("AddQCGJ")]
        public IActionResult AddQCGJ(RequestDocQCGJ gj)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.AddQCGJ(gj, _auth.UserName);

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

        [HttpPost("AddQCLD")]
        public IActionResult AddQCLD(RequestDocQCLD ld)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.AddQCLD(ld, _auth.UserName);

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

        [HttpPost("AddQCDJTitipan")]
        public IActionResult AddQCPG(RequestDocQCDJCustomer dj)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.AddQCDJTitipan(dj, _auth.UserName);

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

        [HttpPut("ApprovalQCLD")]
        public IActionResult ApprovalQCLD(int id, decimal harga, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.ApprovalQCLD(id, harga, keterangan, _auth.UserName, _auth.UserID);
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

        [HttpGet("GetQC")]
        public IActionResult GetQC(int id, string tipe)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.GetQC(id, tipe);
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

        [HttpGet("GetQCByProduct")]
        public IActionResult GetQCByProduct(int id, string tipe)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.GetQCByProduct(id, tipe);
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

        [HttpGet("ReportQC")]
        public IActionResult ReportQC(string kw, string start, string end, string location, string tipe, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.ReportQC(kw, start, end, location, tipe, page, row, excel);
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

        [HttpGet("GetProductListQC")]
        public IActionResult GetProductListQC(string kw, string tipe)
        {
            try
            {
                kw = (string.IsNullOrEmpty(kw) ? "" : kw);
                kw = _common.ChangeStringWildCardCharacterSQL(kw);
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.GetProductList(kw,tipe);
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

        [HttpGet("GetProductDetailQC")]
        public IActionResult GetProductDetailQC(int id, string tipe)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.GetProductDetail(id, tipe);
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

        [HttpGet("GetRoleApprovalQCLD")]
        public IActionResult GetRoleApprovalQCLD()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.GetRoleApprovalQCLD(_auth.UserID);
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

        [HttpGet("GetListQCLDNotApproved")]
        public IActionResult GetListQCLDNotApproved(string kw,string start, string end, int excel, int page, int row)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _docqc.GetListQCLDNotApproved(kw, start, end, _auth.UserID , excel, page, row);
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

        [HttpGet("GetListSizeLD")]
        public IActionResult GetListSizeLD()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = _docqc.GetListSizeLD();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("GetListClarityCharLD")]
        public IActionResult GetListClarityCharLD()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = _docqc.GetListClarityCharLD();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("GetListPositionLD")]
        public IActionResult GetListPositionLD()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = _docqc.GetListPositionLD();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }
    }
}
