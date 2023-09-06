using System;
using Connection.Interface;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoneController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IParcelRepository _parcel;
        private readonly IStoneRepository _stone;
        private Common _common;

        public StoneController(IAccountRepository account, JwtService jwtService, IParcelRepository parcel, IStoneRepository stone)
        {
            _parcel = parcel;
            _stone = stone;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
            _common = new Common();
        }

        [HttpGet("GetStone1AOutlet")]
        public IActionResult GetStone1AOutlet(int parcel01, int parcel02, int parcel03, int parcel04)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stone.GetStone1A(parcel01, parcel02, parcel03, parcel04);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetStone1BOutlet")]
        public IActionResult GetStone1BOutlet(int parcel01, int parcel02, int parcel03, int parcel04, int parcel05, int parcel06, int parcel07)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stone.GetStone1B(parcel01, parcel02, parcel03, parcel04, parcel05, parcel06, parcel07);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetStone2Outlet")]
        public IActionResult GetStone2Outlet(int parcel01, int parcel02, int parcel03, int parcel04)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stone.GetStone2(parcel01, parcel02, parcel03, parcel04);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetStone3Outlet")]
        public IActionResult GetStone3Outlet(int parcel01, int parcel02, int parcel03, int parcel04)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stone.GetStone3(parcel01, parcel02, parcel03, parcel04);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetStone4Outlet")]
        public IActionResult GetStone4Outlet(int parcel01, int parcel02, int parcel03)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stone.GetStone4(parcel01, parcel02, parcel03);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetStone5Outlet")]
        public IActionResult GetStone5Outlet(int parcel01, int parcel02, int parcel03, int parcel04, int parcel05, int parcel06, int parcel07, int parcel08)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stone.GetStone5(parcel01, parcel02, parcel03, parcel04, parcel05, parcel06, parcel07, parcel08);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetHargaStone")]
        public IActionResult GetHargaStone(int idstone, string tipe, int totalbutir, decimal totalcarat, int item, int stonedist)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stone.GetHargaTotalBatu(item, stonedist, idstone, tipe, totalbutir, totalcarat);
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
