using Connection.Interface;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly ICharacterRepository _repository;

        public CharacterController(IAccountRepository account, JwtService jwtService, ICharacterRepository repository)
        {
            _repository = repository;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
        }

        [HttpGet("ProductItem")]
        public IActionResult GetProductItem()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetProductItems()
                                  select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ProductCategory")]
        public IActionResult GetProductCategory()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetProductCategories()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ProductCategory2")]
        public IActionResult GetProductCategory2()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetProductCategory2s()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ProductLevel")]
        public IActionResult GetProductLevel()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetProductLevels()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("StoneDist")]
        public IActionResult GetStoneDist()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetStoneDists()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("SettingStoneDist")]
        public IActionResult GetSettingStoneDist(int category, int level)
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetStoneDists(category, level)
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("StoneBrand")]
        public IActionResult GetStoneBrand()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetStoneBrand()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("FrameColor")]
        public IActionResult GetFrameColor()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetFrameColors()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("FrameMaterial")]
        public IActionResult GetFrameMaterial()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetFrameMaterials()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("FrameFinishing")]
        public IActionResult GetFrameFinishing()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetFrameFinishings()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("GoldLevel")]
        public IActionResult GetGoldLevel()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetGoldLevels()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("GoldModel")]
        public IActionResult GetGoldModel()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetGoldModels()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ProcessCon")]
        public IActionResult GetProcessCon()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetProcessCons()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("DesignCategory")]
        public IActionResult GetDesignCategory()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetDesignCategories()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("DesignConcept")]
        public IActionResult GetDesignConcept()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetDesignConcepts()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("DesignProcess")]
        public IActionResult GetDesignProcess()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetDesignProcesses()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("TargetGender")]
        public IActionResult GetTargetGender()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetTargetGenders()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("TargetAge")]
        public IActionResult GetTargetAge()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetTargetAges()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("ProcessFinishing")]
        public IActionResult GetProcessFinishing()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetCharProcessFinishings()
                              select new { a.Id, a.Nama, a.NamaKode }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Supplier")]
        public IActionResult GetSuppierData()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _repository.GetSupplier()
                              select new { a.Id, a.Nama }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }
    }
}


