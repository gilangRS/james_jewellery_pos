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
    public class ProductController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IProductRepository _product;

        public ProductController(IAccountRepository account, JwtService jwtService, IProductRepository product)
        {
            _product = product;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
        }

        [HttpGet("CatalogDJ")]
        public IActionResult GetCatalogProductDJ(string keyword = "", int productitem = -1, int productcategory = -1, int productlevel = -1, int stonedist = -1, int framematerial = -1, int framecolor = -1, decimal hargamin = 0, decimal hargamax = 0, int basic = 0, int stock = 0, int stonebrand = 0, int brand = 0, int page = 1, int itemperpage = 20)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    int isStore = _auth.IsStore ? 1 : 0;
                    collection = _product.GetProductCatalogDJ(keyword, productitem, productcategory, productlevel, stonedist, framematerial, framecolor, hargamin, hargamax, basic, stock, stonebrand, brand, page, itemperpage, isStore);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("DetailProductDJ")]
        public IActionResult GetDetailProductDJ(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _product.GetDetailProductDJ(id);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex) { return StatusCode(400); }
        }

        [HttpGet("DetailCatalogDJ")]
        public IActionResult GetDetailCatalogDJ(string keyword = "", decimal hargamin = 0, decimal hargamax = 0, int stone = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    int isStore = _auth.IsStore ? 1 : 0;
                    collection = _product.GetDetailCatalogDJ(keyword, hargamin, hargamax, isStore, stone);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex) { return StatusCode(400); }
        }

        [HttpGet("CatalogPG")]
        public IActionResult GetCatalogProductPG(string keyword = "", int productitem = -1, int goldlevel = -1, int goldmodel = -1, int framecolor = -1, decimal hargamin = 0, decimal hargamax = 0, int basic = 0, int stock = 0, int brand = 0, int page = 1, int itemperpage = 20, int fixrate = 0, decimal minweight = 0, decimal maxweight = 0, decimal minsize = 0, decimal maxsize = 0)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _product.GetProductCatalogPG(keyword, productitem, goldlevel, goldmodel, framecolor, hargamin, hargamax, basic, stock, brand, page, itemperpage, fixrate, minweight, maxweight, minsize, maxsize, _auth.UserID);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("DetailCatalogPG")]
        public IActionResult GetDetailCatalogPG(string keyword, decimal sizemin, decimal sizemax, decimal weightmin, decimal weightmax, decimal hargamin, decimal hargamax)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _product.GetDetailCatalogPG(keyword, sizemin, sizemax, weightmin, weightmax, hargamin, hargamax);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex) { return StatusCode(400); }
        }

        [HttpGet("GetTrendingProduct")]
        public IActionResult GetTrendingProduct()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _product.GetTrendingProduct();
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex) { return StatusCode(400); }
        }
    }
}
