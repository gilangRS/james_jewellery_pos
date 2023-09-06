using Connection.Interface;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockInventoryController : ControllerBase
    {
        private readonly IAccountRepository _repository;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IStockInventoryRepository _stockInventory;
        private readonly IPackagingRepository _packaging;
        private readonly ISouvenirRepository _souvenir;
        private readonly ICetakanRepository _cetakan;

        public StockInventoryController(IAccountRepository repository, JwtService jwtService, IStockInventoryRepository stockInventory, IPackagingRepository packaging, ISouvenirRepository souvenir, ICetakanRepository cetakan)
        {
            _repository = repository;
            _jwtService = jwtService;
            _auth = new Auth(_repository, _jwtService);
            _stockInventory = stockInventory;
            _packaging = packaging;
            _souvenir = souvenir;
            _cetakan = cetakan;
        }

        [HttpGet("StockDJRekap")]
        public IActionResult GetStockDJRekap(string nomor = "", int tipelokasi = 9, int idlokasi = 0, int productitem = 0, int productcategory = 0, int substorage = 0, int groupby = 1)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    if (_auth.IsStore) collection = _stockInventory.GetStockDJRekapOutlet(nomor, tipelokasi, idlokasi, productitem, productcategory, substorage, groupby);
                    else collection = _stockInventory.GetStockDJRekapOutlet(nomor, tipelokasi, idlokasi, productitem, productcategory, substorage, groupby);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockDJList")]
        public IActionResult GetStockDJList(string nomor = "", int tipelokasi = 9, int idlokasi = 0, int productitem = 0, int productcategory = 0, int substorage = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    if (_auth.IsStore) collection = _stockInventory.GetStockDJListOutlet(nomor, tipelokasi, idlokasi, productitem, productcategory, substorage);
                    else collection = _stockInventory.GetStockDJListOutlet(nomor, tipelokasi, idlokasi, productitem, productcategory, substorage);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch(Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockPGList")]
        public IActionResult GetStockPGList(string nomor = "", int tipelokasi = 9, int idlokasi = 0, int productitem = 0, int goldlevel = 0, int model = 0, int framecolor = 0, int substorage = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    if (_auth.IsStore) collection = _stockInventory.GetStockPGListOutlet(nomor, tipelokasi, idlokasi, productitem, goldlevel, model, framecolor, substorage);
                    else collection = _stockInventory.GetStockPGListOutlet(nomor, tipelokasi, idlokasi, productitem, goldlevel, model, framecolor, substorage);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch(Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockPackagingSummary")]
        public IActionResult GetStockPackagingSummary(int tipelokasi = 0, int idlokasi = 0, int packaging = 0, string from = "", string to = "", int groupby = 1)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _packaging.GetStockPackagingSummary(tipelokasi, idlokasi, packaging, from, to, groupby, _auth.IsStore, _auth.NIK);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockPackagingActual")]
        public IActionResult GetStockPackagingActual(int tipelokasi = 9, int idlokasi = 0, int packaging = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _packaging.GetStockPackagingActual(tipelokasi, idlokasi, packaging);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockCetakanSummary")]
        public IActionResult GetStockCetakanSummary(int tipelokasi = 0, int idlokasi = 0, int cetakan = 0, string from = "", string to = "", int groupby = 1)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _cetakan.GetStockCetakanSummary(tipelokasi, idlokasi, cetakan, from, to, groupby, _auth.IsStore, _auth.NIK);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockCetakanActual")]
        public IActionResult GetStockCetakanActual(int tipelokasi = 9, int idlokasi = 0, int cetakan = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _cetakan.GetStockCetakanActual(tipelokasi, idlokasi, cetakan);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockSouvenirSummary")]
        public IActionResult GetStockSouvenirSummary(int tipelokasi = 0, int idlokasi = 0, int souvenir = 0, string from = "", string to = "", int groupby = 1)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _souvenir.GetStockSouvenirSummary(tipelokasi, idlokasi, souvenir, from, to, groupby, _auth.IsStore, _auth.NIK);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockSouvenirActual")]
        public IActionResult GetStockSouvenirActual(int tipelokasi = 9, int idlokasi = 0, int souvenir = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _souvenir.GetStockSouvenirActual(tipelokasi, idlokasi, souvenir);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockLDList")]
        public IActionResult GetStockLDList(int tipelokasi = 9, int idlokasi = 0, string nomor = "", int shape = 0, int size = 0, int color = 0, int clarity = 0, int cutting = 0, int brand = 0, int category = 0, int substorage = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    if (_auth.IsStore) collection = _stockInventory.GetStockLDListOutlet(nomor, tipelokasi, idlokasi, shape, size, color, clarity, cutting, brand, category, substorage);
                    else collection = _stockInventory.GetStockLDList(nomor, tipelokasi, idlokasi, shape, size, color, clarity, cutting, brand, category, substorage);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockGJRekap")]
        public IActionResult GetStockGJRekap(string nomor = "", int tipelokasi = 9, int idlokasi = 0, int productitem = 0, int productcategory = 0, int substorage = 0, int groupby = 1)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    if (_auth.IsStore) collection = _stockInventory.GetStockGJRekapOutlet(nomor, tipelokasi, idlokasi, productitem, productcategory, substorage, groupby);
                    else collection = _stockInventory.GetStockGJRekapOutlet(nomor, tipelokasi, idlokasi, productitem, productcategory, substorage, groupby);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockGJList")]
        public IActionResult GetStockGJList(string nomor = "", int tipelokasi = 9, int idlokasi = 0, int productitem = 0, int productcategory = 0, int substorage = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    if (_auth.IsStore) collection = _stockInventory.GetStockGJListOutlet(nomor, tipelokasi, idlokasi, productitem, productcategory, substorage);
                    else collection = _stockInventory.GetStockGJListOutlet(nomor, tipelokasi, idlokasi, productitem, productcategory, substorage);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockSummary")]
        public IActionResult GetStockSummary(int tipelokasi = 9, int idlokasi = 0, int productitem = 0, int productcategory = 0, int substorage = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    if (_auth.IsStore) collection = _stockInventory.GetStockSummary(tipelokasi, idlokasi, productitem, productcategory, substorage);
                    else collection = _stockInventory.GetStockSummary(tipelokasi, idlokasi, productitem, productcategory, substorage);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockLedger")]
        public IActionResult GetStockLedger(string nomor = "")
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stockInventory.GetStockLedger(nomor);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("ItemRekap")]
        public IActionResult GetItemRekap(int tipelokasi = 9, int idlokasi = 0, int productitem = 0,  int substorage = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    if(_auth.IsStore) collection = _stockInventory.GetItemRekap(tipelokasi, idlokasi, productitem, substorage);
                    else collection = _stockInventory.GetItemRekap(tipelokasi, idlokasi, productitem, substorage);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("ItemDetail")]
        public IActionResult GetItemDetail(int tipelokasi = 9, int idlokasi = 0, int productitem = 0, int substorage = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    if (_auth.IsStore) collection = _stockInventory.GetItemDetail(tipelokasi, idlokasi, productitem, substorage);
                    else collection = _stockInventory.GetItemDetail(tipelokasi, idlokasi, productitem, substorage);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("StockActualDJ")]
        public IActionResult GetStockActualDJ(string keyword, int tipelokasi, int idlokasi)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                   //collection = _stockInventory.GetItemDetail(tipelokasi, idlokasi, productitem, substorage);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("PLUDJOutgoing")]
        public IActionResult GetStockDJOutgoing(string nomor = "", int tipelokasi = 9, int idlokasi = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stockInventory.GetDJOutgoing(nomor, tipelokasi, idlokasi, 98);
                    if (collection.Count > 0) return BadRequest(new { messsage = "Data sedang dioutgoing" });
                    else collection = _stockInventory.GetDJOutgoing(nomor, tipelokasi, idlokasi, 0);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("PLUPGOutgoing")]
        public IActionResult GetStockPGOutgoing(string nomor = "", int tipelokasi = 9, int idlokasi = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stockInventory.GetPGOutgoing(nomor, tipelokasi, idlokasi, 98);
                    if (collection.Count > 0) return BadRequest(new { messsage = "Data sedang dioutgoing" });
                    else collection = _stockInventory.GetPGOutgoing(nomor, tipelokasi, idlokasi, 0);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("PLULDOutgoing")]
        public IActionResult GetStockLDOutgoing(string nomor = "", int tipelokasi = 9, int idlokasi = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stockInventory.GetLDOutgoing(nomor, tipelokasi, idlokasi, 98);
                    if (collection.Count > 0) return BadRequest(new { messsage = "Data sedang dioutgoing" });
                    else collection = _stockInventory.GetLDOutgoing(nomor, tipelokasi, idlokasi, 0);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }

        [HttpGet("PLUGJOutgoing")]
        public IActionResult GetStockGJOutgoing(string nomor = "", int tipelokasi = 9, int idlokasi = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                List<object> collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _stockInventory.GetGJOutgoing(nomor, tipelokasi, idlokasi, 98);
                    if (collection.Count > 0) return BadRequest(new { messsage = "Data sedang dioutgoing" });
                    else collection = _stockInventory.GetGJOutgoing(nomor, tipelokasi, idlokasi, 0);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }
    }
}
