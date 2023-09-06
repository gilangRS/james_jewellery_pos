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
    public class ParcelController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IParcelRepository _parcel;

        public ParcelController(IAccountRepository account, JwtService jwt, IParcelRepository parcel)
        {
            _account = account;
            _parcel = parcel;
            _jwtService = jwt;
            _auth = new Auth(_account, _jwtService);
        }

        [HttpGet("Parcel101")]
        public IActionResult GetParcel101()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel101s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel102")]
        public IActionResult GetParcel102()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel102s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel103")]
        public IActionResult GetParcel103()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel103s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel104")]
        public IActionResult GetParcel104()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel104s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel105")]
        public IActionResult GetParcel105()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel105s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel106")]
        public IActionResult GetParcel106()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel106s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel107")]
        public IActionResult GetParcel107()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel107s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel201")]
        public IActionResult GetParcel201()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel201s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel202")]
        public IActionResult GetParcel202()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel202s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel203")]
        public IActionResult GetParcel203()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel203s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel204")]
        public IActionResult GetParcel204()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel204s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel205")]
        public IActionResult GetParcel205()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel205s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel206")]
        public IActionResult GetParcel206()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel206s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel207")]
        public IActionResult GetParcel207()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel207s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel301")]
        public IActionResult GetParcel301()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel301s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel302")]
        public IActionResult GetParcel302()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel302s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel303")]
        public IActionResult GetParcel303()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel303s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel304")]
        public IActionResult GetParcel304()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel304s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel305")]
        public IActionResult GetParcel305()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel305s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel306")]
        public IActionResult GetParcel306()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel306s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel307")]
        public IActionResult GetParcel307()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel307s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel308")]
        public IActionResult GetParcel308()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel308s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel309")]
        public IActionResult GetParcel309()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel309s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel310")]
        public IActionResult GetParcel310()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel310s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel311")]
        public IActionResult GetParcel311()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel311s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel312")]
        public IActionResult GetParcel312()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel312s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel401")]
        public IActionResult GetParcel401()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel401s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel402")]
        public IActionResult GetParcel402()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel402s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

        [HttpGet("Parcel403")]
        public IActionResult GetParcel403()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel403s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel501")]
        public IActionResult GetParcel501()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel501s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel502")]
        public IActionResult GetParcel502()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel502s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel503")]
        public IActionResult GetParcel503()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel503s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel504")]
        public IActionResult GetParcel504()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel504s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel505")]
        public IActionResult GetParcel505()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel505s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel506")]
        public IActionResult GetParcel506()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel506s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel507")]
        public IActionResult GetParcel507()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel507s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel508")]
        public IActionResult GetParcel508()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel508s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }


        [HttpGet("Parcel509")]
        public IActionResult GetParcel509()
        {
            string token = Request.Headers["Authorization"];
            object collection;

            if (_auth.IsAuthentic(token))
            {
                collection = (from a in _parcel.GetParcel509s()
                              select new { ID = a.Id, Nama = a.Nama + " (" + a.NamaKode + ")" }).ToList();
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(collection);
        }

    }
}
