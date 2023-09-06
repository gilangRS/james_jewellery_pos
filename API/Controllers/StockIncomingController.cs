using Connection.Interface;
using Connection.RequestModels.StockTransfer;
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
    public class StockIncomingController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IStockOutgoingRepository _outgoing;
        private readonly ILocationRepository _location;
        private Common _common;
        private readonly IStockIncomingRepository _incoming;

        public StockIncomingController(IAccountRepository account, JwtService jwtService, IStockOutgoingRepository outgoing, ILocationRepository location, IStockIncomingRepository incoming)
        {
            _outgoing = outgoing;
            _incoming = incoming;
            _jwtService = jwtService;
            _account = account;
            _location = location;
            _auth = new Auth(_account, _jwtService);
            _common = new Common();
        }

        #region Incoming DJ
        [HttpGet("RegisterStockIncomingDJ")]
        public IActionResult GetRegisterStockIncomingDJ(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockOutgoingDJ(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan,  nomor);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingDJDetail")]
        public IActionResult GetStockIncomingDJDetail(int id, int iscrossbrand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingDJDetail(id, iscrossbrand);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingDJ")]
        public IActionResult GetStockIncomingDJ(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingDJ(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Incoming"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPost("InsertStockIncomingDJ")]
        public IActionResult InsertStockIncomingDJ(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    _incoming.InsertStockIncomingDJ(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockIncomingDJ")]
        public IActionResult ApproveStockIncomingDJ(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    _incoming.ApprovalIncomingDJ(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockIncomingDJ")]
        public IActionResult DeleteStockIncomingDJ(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    _incoming.DeleteStockIncomingDJ(ID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        #endregion 

        #region Incoming PG
        [HttpGet("RegisterStockIncomingPG")]
        public IActionResult GetRegisterStockIncomingPG(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockOutgoingPG(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan, nomor);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingPGDetail")]
        public IActionResult GetStockIncomingPGDetail(int id, int iscrossbrand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingPGDetail(id, iscrossbrand);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingPG")]
        public IActionResult GetStockIncomingPG(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingPG(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Incoming"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPost("InsertStockIncomingPG")]
        public IActionResult InsertStockIncomingPG(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.InsertStockIncomingPG(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockIncomingPG")]
        public IActionResult ApproveStockIncomingPG(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.ApprovalIncomingPG(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockIncomingPG")]
        public IActionResult DeleteStockIncomingPG(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.DeleteStockIncomingPG(ID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        #endregion

        #region Incoming LD
        [HttpGet("RegisterStockIncomingLD")]
        public IActionResult GetRegisterStockIncomingLD(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockOutgoingLD(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan, nomor);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingLDDetail")]
        public IActionResult GetStockIncomingLDDetail(int id, int iscrossbrand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingLDDetail(id, iscrossbrand);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingLD")]
        public IActionResult GetStockIncomingLD(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingLD(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Incoming"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPost("InsertStockIncomingLD")]
        public IActionResult InsertStockIncomingLD(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.InsertStockIncomingLD(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockIncomingLD")]
        public IActionResult ApproveStockIncomingLD(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.ApprovalIncomingLD(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockIncomingLD")]
        public IActionResult DeleteStockIncomingLD(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.DeleteStockIncomingLD(ID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        #endregion

        #region Incoming GJ
        [HttpGet("RegisterStockIncomingGJ")]
        public IActionResult GetRegisterStockIncomingGJ(string nomor, string from, string to, int brand= 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockOutgoingGJ(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, nomor);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingGJDetail")]
        public IActionResult GetStockIncomingGJDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingGJDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingGJ")]
        public IActionResult GetStockIncomingGJ(string nomor, string from, string to, int brand = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingGJ(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Incoming"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPost("InsertStockIncomingGJ")]
        public IActionResult InsertStockIncomingGJ(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.InsertStockIncomingGJ(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockIncomingGJ")]
        public IActionResult ApproveStockIncomingGJ(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.ApprovalIncomingGJ(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockIncomingGJ")]
        public IActionResult DeleteStockIncomingGJ(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.DeleteStockIncomingGJ(ID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        #endregion

        #region Incoming Packaging
        [HttpGet("RegisterStockIncomingPackaging")]
        public IActionResult GetRegisterStockIncomingPackaging(string nomor, string from, string to, int brand = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockOutgoingPackaging(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, nomor);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingPackagingDetail")]
        public IActionResult GetStockIncomingPackagingDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingPackagingDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingPackaging")]
        public IActionResult GetStockIncomingPackaging(string nomor, string from, string to, int brand = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingPackaging(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Incoming"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingPackagingDetailList")]
        public IActionResult GetStockIncomingPackagingDetailList(string nomor, string from, string to, int brand = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0, int idproduct = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingPackagingDetailList(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, idproduct);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPost("InsertStockIncomingPackaging")]
        public IActionResult InsertStockIncomingPackaging(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.InsertStockIncomingPackaging(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockIncomingPackaging")]
        public IActionResult ApproveStockIncomingPackaging(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.ApprovalIncomingPackaging(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockIncomingPackaging")]
        public IActionResult DeleteStockIncomingPackaging(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.DeleteStockIncomingPackaging(ID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        #endregion

        #region Incoming Souvenir
        [HttpGet("RegisterStockIncomingSouvenir")]
        public IActionResult GetRegisterStockIncomingSouvenir(string nomor, string from, string to, int brand = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockOutgoingSouvenir(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, nomor);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingSouvenirDetail")]
        public IActionResult GetStockIncomingSouvenirDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingSouvenirDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingSouvenir")]
        public IActionResult GetStockIncomingSouvenir(string nomor, string from, string to, int brand = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingSouvenir(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Incoming"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }


        [HttpGet("StockIncomingSouvenirDetailList")]
        public IActionResult GetStockIncomingSouvenirDetailList(string nomor, string from, string to, int brand = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0, int idproduct = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingSouvenirDetailList(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, idproduct);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPost("InsertStockIncomingSouvenir")]
        public IActionResult InsertStockIncomingSouvenir(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.InsertStockIncomingSouvenir(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockIncomingSouvenir")]
        public IActionResult ApproveStockIncomingSouvenir(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.ApprovalIncomingSouvenir(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockIncomingSouvenir")]
        public IActionResult DeleteStockIncomingSouvenir(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.DeleteStockIncomingSouvenir(ID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        #endregion

        #region Incoming Cetakan
        [HttpGet("RegisterStockIncomingCetakan")]
        public IActionResult GetRegisterStockIncomingCetakan(string nomor, string from, string to, int brand = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockOutgoingCetakan(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, nomor);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingCetakanDetail")]
        public IActionResult GetStockIncomingCetakanDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingCetakanDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockIncomingCetakan")]
        public IActionResult GetStockIncomingCetakan(string nomor, string from, string to, int brand = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingCetakan(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Incoming"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }


        [HttpGet("StockIncomingCetakanDetailList")]
        public IActionResult GetStockIncomingCetakanDetailList(string nomor, string from, string to, int brand = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0, int idproduct = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _incoming.GetStockIncomingCetakanDetailList(from, to, brand, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, idproduct);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPost("InsertStockIncomingCetakan")]
        public IActionResult InsertStockIncomingCetakan(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.InsertStockIncomingCetakan(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockIncomingCetakan")]
        public IActionResult ApproveStockIncomingCetakan(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.ApprovalIncomingCetakan(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockIncomingCetakan")]
        public IActionResult DeleteStockIncomingCetakan(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                if (_auth.IsAuthentic(token))
                {
                    _incoming.DeleteStockIncomingCetakan(ID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        #endregion

        [HttpGet("CheckCertificateDJ")]
        public IActionResult CheckCertificateDJ(int ID, bool isCrossBrand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    int IDOutgoing = _incoming.GetIDOutgoing(ID, isCrossBrand);
                    collection = _outgoing.GetCertificate(IDOutgoing, isCrossBrand);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
    }
}
