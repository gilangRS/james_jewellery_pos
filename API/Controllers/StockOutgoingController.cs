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
    public class StockOutgoingController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IStockOutgoingRepository _outgoing;
        private readonly ILocationRepository _location;
        private Common _common;

        public StockOutgoingController(IAccountRepository account, JwtService jwtService, IStockOutgoingRepository outgoing, ILocationRepository location)
        {
            _outgoing = outgoing;
            _jwtService = jwtService;
            _account = account;
            _location = location;
            _auth = new Auth(_account, _jwtService);
            _common = new Common();
        }

        #region Outgoing DJ
        [HttpGet("StockOutgoingDJ")]
        public IActionResult GetStockOutgoingDJ(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingDJ(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Outgoing"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockOutgoingDJDetail")]
        public IActionResult GetStockOutgoingDJDetail(int id, int iscrossbrand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingDJDetail(id, iscrossbrand);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }


        [HttpPost("InsertStockOutgoingDJ")]
        public IActionResult InsertStockOutgoingDJ(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    datas.BrandAsal = _location.GetDataLocation(_common.IDBrand(), datas.TipeAsal, datas.IDAsal).IDBrand;
                    datas.NamaAsal = _location.GetDataLocation(_common.IDBrand(), datas.TipeAsal, datas.IDAsal).NamaLokasi;
                    datas.NamaTujuan = _location.GetDataLocation(datas.BrandTujuan, datas.TipeTujuan, datas.IDTujuan).NamaLokasi;
                    _outgoing.InsertStockOutgoingDJ(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("UpdateStockOutgoingDJ")]
        public IActionResult UpdateStockOutgoingDJ(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                
                if (_auth.IsAuthentic(token))
                {
                    _outgoing.UpdateStockOutgoingDJ(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockOutgoingDJ")]
        public IActionResult ApproveStockOutgoingDJ(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.ApprovalOutgoingDJ(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockOutgoingDJ")]
        public IActionResult DeleteStockOutgoingDJ(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.DeleteStockOutgoingDJ(ID);
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

        #region Outgoing PG
        [HttpGet("StockOutgoingPG")]
        public IActionResult GetStockOutgoingPG(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingPG(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Outgoing"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }


        [HttpGet("StockOutgoingPGDetail")]
        public IActionResult GetStockOutgoingPGDetail(int id, int iscrossbrand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingPGDetail(id, iscrossbrand);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPost("InsertStockOutgoingPG")]
        public IActionResult InsertStockOutgoingPG(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    datas.BrandAsal = _location.GetDataLocation(_common.IDBrand(), datas.TipeAsal, datas.IDAsal).IDBrand;
                    datas.NamaAsal = _location.GetDataLocation(_common.IDBrand(), datas.TipeAsal, datas.IDAsal).NamaLokasi;
                    datas.NamaTujuan = _location.GetDataLocation(datas.BrandTujuan, datas.TipeTujuan, datas.IDTujuan).NamaLokasi;
                    _outgoing.InsertStockOutgoingPG(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("UpdateStockOutgoingPG")]
        public IActionResult UpdateStockOutgoingPG(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.UpdateStockOutgoingPG(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockOutgoingPG")]
        public IActionResult ApproveStockOutgoingPG(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.ApprovalOutgoingPG(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockOutgoingPG")]
        public IActionResult DeleteStockOutgoingPG(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.DeleteStockOutgoingPG(ID);
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

        #region Outgoing LD
        [HttpGet("StockOutgoingLD")]
        public IActionResult GetStockOutgoingLD(string nomor, string from, string to, int brandasal = 0, int brandtujuan = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingLD(from, to, brandasal, brandtujuan, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Outgoing"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }


        [HttpGet("StockOutgoingLDDetail")]
        public IActionResult GetStockOutgoingLDDetail(int id, int iscrossbrand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingLDDetail(id, iscrossbrand);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPost("InsertStockOutgoingLD")]
        public IActionResult InsertStockOutgoingLD(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    datas.BrandAsal = _location.GetDataLocation(_common.IDBrand(), datas.TipeAsal, datas.IDAsal).IDBrand;
                    datas.NamaAsal = _location.GetDataLocation(_common.IDBrand(), datas.TipeAsal, datas.IDAsal).NamaLokasi;
                    datas.NamaTujuan = _location.GetDataLocation(datas.BrandTujuan, datas.TipeTujuan, datas.IDTujuan).NamaLokasi;
                    _outgoing.InsertStockOutgoingLD(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("UpdateStockOutgoingLD")]
        public IActionResult UpdateStockOutgoingLD(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.UpdateStockOutgoingLD(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockOutgoingLD")]
        public IActionResult ApproveStockOutgoingLD(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.ApprovalOutgoingLD(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockOutgoingLD")]
        public IActionResult DeleteStockOutgoingLD(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.DeleteStockOutgoingLD(ID);
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

        #region Outgoing GJ

        [HttpGet("StockOutgoingGJ")]
        public IActionResult GetStockOutgoingGJ(string nomor, string from, string to, int brandasal = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingGJ(from, to, brandasal, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Outgoing"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }


        [HttpGet("StockOutgoingGJDetail")]
        public IActionResult GetStockOutgoingGJDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingGJDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPost("InsertStockOutgoingGJ")]
        public IActionResult InsertStockOutgoingGJ(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    datas.BrandAsal = _location.GetDataLocation(_common.IDBrand(), datas.TipeAsal, datas.IDAsal).IDBrand;
                    datas.NamaAsal = _location.GetDataLocation(_common.IDBrand(), datas.TipeAsal, datas.IDAsal).NamaLokasi;
                    datas.NamaTujuan = _location.GetDataLocation(datas.BrandTujuan, datas.TipeTujuan, datas.IDTujuan).NamaLokasi;
                    _outgoing.InsertStockOutgoingGJ(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("UpdateStockOutgoingGJ")]
        public IActionResult UpdateStockOutgoingGJ(RequestStockOutgoingBRJ datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.UpdateStockOutgoingGJ(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockOutgoingGJ")]
        public IActionResult ApproveStockOutgoingGJ(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.ApprovalOutgoingGJ(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockOutgoingGJ")]
        public IActionResult DeleteStockOutgoingGJ(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.DeleteStockOutgoingGJ(ID);
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

        #region Outgoing Packaging
        [HttpGet("StockOutgoingPackaging")]
        public IActionResult GetStockOutgoingPackaging(string nomor, string from, string to, int brandasal = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingPackaging(from, to, brandasal, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Outgoing"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockOutgoingPackagingDetailList")]
        public IActionResult GetStockOutgoingPackagingDetailList(string nomor, string from, string to, int brandasal = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int idproduct = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingPackagingDetailList(from, to, brandasal, tipeasal, tipetujuan, idasal, idtujuan, nomor, idproduct, status);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockOutgoingPackagingDetail")]
        public IActionResult GetStockOutgoingPackagingDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingPackagingDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPost("InsertStockOutgoingPackaging")]
        public IActionResult InsertStockOutgoingPackaging(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.InsertStockOutgoingPackaging(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("UpdateStockOutgoingPackaging")]
        public IActionResult UpdateStockOutgoingPackaging(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.UpdateStockOutgoingPackaging(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockOutgoingPackaging")]
        public IActionResult ApproveStockOutgoingPackaging(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.ApprovalOutgoingPackaging(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockOutgoingPackaging")]
        public IActionResult DeleteStockOutgoingPackaging(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.DeleteStockOutgoingPackaging(ID);
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

        #region Outgoing Souvenir
        [HttpGet("StockOutgoingSouvenir")]
        public IActionResult GetStockOutgoingSouvenir(string nomor, string from, string to, int brandasal = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingSouvenir(from, to, brandasal, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Outgoing"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockOutgoingSouvenirDetailList")]
        public IActionResult GetStockOutgoingSouvenirDetailList(string nomor, string from, string to, int brandasal = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int idproduct = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingSouvenirDetailList(from, to, brandasal, tipeasal, tipetujuan, idasal, idtujuan, nomor, idproduct, status);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }


        [HttpGet("StockOutgoingSouvenirDetail")]
        public IActionResult GetStockOutgoingSouvenirDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingSouvenirDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPost("InsertStockOutgoingSouvenir")]
        public IActionResult InsertStockOutgoingSouvenir(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.InsertStockOutgoingSouvenir(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("UpdateStockOutgoingSouvenir")]
        public IActionResult UpdateStockOutgoingSouvenir(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.UpdateStockOutgoingSouvenir(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockOutgoingSouvenir")]
        public IActionResult ApproveStockOutgoingSouvenir(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.ApprovalOutgoingSouvenir(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockOutgoingSouvenir")]
        public IActionResult DeleteStockOutgoingSouvenir(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.DeleteStockOutgoingSouvenir(ID);
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

        #region Outgoing Cetakan
        [HttpGet("StockOutgoingCetakan")]
        public IActionResult GetStockOutgoingCetakan(string nomor, string from, string to, int brandasal = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingCetakan(from, to, brandasal, tipeasal, tipetujuan, idasal, idtujuan, status, nomor, _auth.isApproval("Transfer Outgoing"));
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockOutgoingCetakanDetailList")]
        public IActionResult GetStockOutgoingCetakanDetailList(string nomor, string from, string to, int brandasal = 0, int tipeasal = 9, int tipetujuan = 9, int idasal = 0, int idtujuan = 0, int idproduct = 0, int status = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingCetakanDetailList(from, to, brandasal, tipeasal, tipetujuan, idasal, idtujuan, nomor, idproduct, status);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("StockOutgoingCetakanDetail")]
        public IActionResult GetStockOutgoingCetakanDetail(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _outgoing.GetStockOutgoingCetakanDetail(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPost("InsertStockOutgoingCetakan")]
        public IActionResult InsertStockOutgoingCetakan(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.InsertStockOutgoingCetakan(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("UpdateStockOutgoingCetakan")]
        public IActionResult UpdateStockOutgoingCetakan(RequestStockOutgoingPS datas)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.UpdateStockOutgoingCetakan(datas, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpPut("ApproveStockOutgoingCetakan")]
        public IActionResult ApproveStockOutgoingCetakan(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.ApprovalOutgoingCetakan(ID, _auth.UserName);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("DeleteStockOutgoingCetakan")]
        public IActionResult DeleteStockOutgoingCetakan(int ID)
        {
            try
            {
                string token = Request.Headers["Authorization"];

                if (_auth.IsAuthentic(token))
                {
                    _outgoing.DeleteStockOutgoingCetakan(ID);
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
                    collection = _outgoing.GetCertificate(ID, isCrossBrand);
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
