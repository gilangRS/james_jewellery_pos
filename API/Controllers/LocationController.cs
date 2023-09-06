using Connection.Interface;
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
    public class LocationController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly ILocationRepository _repository;

        public LocationController(IAccountRepository account, JwtService jwtService, ILocationRepository repository)
        {
            _repository = repository;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
        }

        [HttpGet("Warehouse")]
        public IActionResult GetWarehouse()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetLocWarehouses()
                              select new { a.Id, a.Nama }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Outlet")]
        public IActionResult GetOutlet()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetLocOutlets()
                              select new { a.Id, a.Nama, a.Kode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Exhibiiton")]
        public IActionResult GetExhibition()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetLocExhibitions()
                              select new { a.Id, a.Nama, a.Kode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("WarehouseByID")]
        public IActionResult GetSingleWarehouse(int ID)
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetLocWarehouses(ID)
                              select new { a.Id, a.Nama }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("OutletByKode")]
        public IActionResult GetSingleOutlet(string kode)
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetLocOutlets(kode)
                              select new { a.Id, a.Nama, a.Kode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("OutletByID")]
        public IActionResult GetSingleOutlet(int ID)
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetLocOutlets(ID)
                              select new { a.Id, a.Nama, a.Kode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ExhibitonByCode")]
        public IActionResult GetSingleExhibition(string kode)
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetLocExhibitions(kode)
                              select new { a.Id, a.Nama, a.Kode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ExhibitonByID")]
        public IActionResult GetSingleExhibition(int ID)
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetLocExhibitions(ID)
                              select new { a.Id, a.Nama, a.Kode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("SalesLocation")]
        public IActionResult GetSalesLocation(int isso)
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = _repository.SalesLocationByLogin(_auth.UserID, isso);
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("LocationAllBrand")]
        public IActionResult GetAllBrandLocation(int Brand = 0, int Tipe = 9, int Location = 0)
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = _repository.GetLocationAllBrand(Brand, Tipe, Location);
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }
    }
}
