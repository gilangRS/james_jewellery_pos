using Connection.Models;
using Connection.Interface;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connection.RequestModels.PointOfSales;
using System.Net;
using System.IO;
using System.Text;
using System.Collections;
using System.Net.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesOrderController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly ISalesOrderRepository _salesorder;
        private readonly Common _common;

        public SalesOrderController(IAccountRepository account, JwtService jwtService, ISalesOrderRepository salesorder)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _salesorder = salesorder;
            _common = new Common();
        }

        [HttpGet("GetSalesOrderByID")]
        public IActionResult GetSalesOrderByID(int id, int tipelokasi, int idlokasi)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.GetSalesOrder(id, tipelokasi, idlokasi);

                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    //var data = collection.GetType().GetProperty("data").GetValue(collection, null);
                    //string noso = data.GetType().GetProperty("nomor").GetValue(data, null).ToString();
                    if(message == "")
                    {
                        return Ok(collection);
                    }
                    else
                    {
                        return StatusCode(400,collection);
                    }
                }
                else return Unauthorized(new { message = "Unauthenticated" });
            }
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("GetSalesOrderPLUByStore")]
        public IActionResult GetSalesOrderPLUByStore(int tipelokasi, int idlokasi, string kw, int idcustomer)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    string tipeproduct = "";
                    collection = _salesorder.GetSalesOrderItemByStore(tipelokasi,idlokasi, kw, tipeproduct, idcustomer);
                    
                    string message = collection.GetType().GetProperty("message").GetValue(collection, null).ToString();
                    if(message == "")
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
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("GetSalesOrderPackagingByStore")]
        public IActionResult GetSalesOrderPackagingByStore(int idlokasi, int tipelokasi, string kw)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    string tipeproduct = "PK";
                    collection = _salesorder.GetSalesOrderItemByStore(tipelokasi,idlokasi,kw,tipeproduct, 0);

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
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("GetSalesOrderSouvenirByStore")]
        public IActionResult GetSalesOrderSouvenirByStore(int idlokasi, int tipelokasi, string kw)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    string tipeproduct = "SV";
                    collection = _salesorder.GetSalesOrderItemByStore(tipelokasi,idlokasi,kw,tipeproduct, 0);

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
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("GetSalesOrderCetakanByStore")]
        public IActionResult GetSalesOrderCetakanByStore(int idlokasi, int tipelokasi, string kw)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    string tipeproduct = "CT";
                    collection = _salesorder.GetSalesOrderItemByStore(tipelokasi, idlokasi, kw, tipeproduct, 0);

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

        [HttpPost("AddSalesOrder")]
        public IActionResult AddSalesOrder(RequestSalesOrder so)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.AddSalesOrder(so);

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
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut("UpdateSalesOrder")]
        public IActionResult UpdateSalesOrder(RequestSalesOrder so, int idsolama)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.UpdateSalesOrder(so, idsolama);

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

        [HttpDelete("DeleteSalesOrder")]
        public IActionResult DeleteSalesOrder(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.DeleteSalesOrder(id);

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

        [HttpPut("VoidSalesOrder")]
        public IActionResult VoidSalesOrderByID(int id, string operatornama, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.VoidSalesOrder(id, operatornama, keterangan);

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
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("ReportSalesOrder")]
        public IActionResult ReportSalesOrder(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.ReportSalesOrder(kw, start, end, location, status, page, row, excel);

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
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("ReportSalesDetail")]
        public IActionResult ReportSalesDetail(string kw, string start, string end, string location, string producttype, int status, int page, int row, bool excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.ReportSalesDetail(kw,start,end,location,producttype,status,page,row,excel);

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

        [HttpGet("ReportTradeIn")]
        public IActionResult ReportTradeIn(string kw, string start, string end, int location, int locationtype, int status)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.ReportTradeIn(kw, start, end, location, locationtype, status);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("ReportTradeInDetail")]
        public IActionResult ReportTradeInDetail(string kw, string start, string end, string location, string producttype, int item, int category, int status, int page, int row, bool excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.ReportTradeInDetail(kw, start, end, location, producttype, item, category, status, page, row, excel);

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

        [HttpGet("ValidateDiscountVoucher")]
        public IActionResult ValidateDiscountVoucher(string nomor, string loccode)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.ValidateDiscountVoucher(nomor, loccode);

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
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("PrintSalesOrder")]
        public IActionResult PrintSalesOrder(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.PrintSalesOrder(id);

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
        [HttpGet("PrintSalesOrderDJ")]
        public IActionResult PrintSalesOrderDJ(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.PrintSalesOrderDJ(id);

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
        [HttpGet("PrintSalesOrderPG")]
        public IActionResult PrintSalesOrderPG(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.PrintSalesOrderPG(id);

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
        [HttpGet("PrintSalesOrderGJ")]
        public IActionResult PrintSalesOrderGJ(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.PrintSalesOrderGJ(id);

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
        [HttpGet("PrintSalesOrderLD")]
        public IActionResult PrintSalesOrderLD(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.PrintSalesOrderLD(id);

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

        [HttpPost("AddPackagingPK")]
        public IActionResult AddPackaging(RequestSalesPackaging rpk)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.AddPackaging(rpk);

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

        [HttpPut("VoidPackagingPK")]
        public IActionResult VoidPackaging(int id, string operatornama, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.VoidPackaging(id, operatornama, keterangan);

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

        [HttpGet("ReportPackagingPK")]
        public IActionResult ReportPackaging(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.ReportPackaging(kw, start, end, location, status, page, row, excel);

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

        [HttpGet("GetReferenceNumberPackaging")]
        public IActionResult GetReferenceNumberPackaging(string kw, string tipe)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.GetReferenceNumberPackaging(kw,tipe);

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

        [HttpPost("AddSouvenirSV")]
        public IActionResult AddSouvenir(RequestSalesSouvenir rsv)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.AddSouvenir(rsv);

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

        [HttpPut("VoidSouvenirSV")]
        public IActionResult VoidSouvenir(int id, string operatornama, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.VoidSouvenir(id, operatornama, keterangan);

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

        [HttpGet("ReportSouvenirSV")]
        public IActionResult ReportSouvenir(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.ReportSouvenir(kw, start, end, location, status, page, row, excel);

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

        [HttpPost("AddCetakanCT")]
        public IActionResult AddCetakan(RequestSalesCetakan rsc)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.AddCetakan(rsc);

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

        [HttpPut("VoidCetakanCT")]
        public IActionResult VoidCetakan(int id, string operatornama, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.VoidCetakan(id, operatornama, keterangan);

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

        [HttpGet("ReportCetakanCT")]
        public IActionResult ReportCetakan(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.ReportCetakan(kw, start, end, location, status, page, row, excel);

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

        [HttpGet("PrintProductCard")]
        public IActionResult PrintProductCard(int idso, string invoice, string plu)
        {
            string xidso = Convert.ToBase64String(Encoding.UTF8.GetBytes(idso.ToString()));

            string xidinv = Convert.ToBase64String(Encoding.UTF8.GetBytes(_salesorder.GetIDInvoice(invoice, "DJ").ToString()));

            string xplu = Convert.ToBase64String(Encoding.UTF8.GetBytes(plu));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_common.GetUrlJAWS() + "Print_Certificate_DJ4.aspx?SO=" + xidso + "&INV=" + xidinv + "&PLU=" + xplu);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = string.Empty;
            var stream = new MemoryStream();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                int start = data.IndexOf("src=\"") + 5;

                // Get the substring that starts at start, and goes up to first \".
                string src = data.Substring(start, data.IndexOf("\"", start) - start);
                string path = src.Replace(src, src.Substring(src.IndexOf('=') + 1));
                path = path.Replace("D:\\", "").Replace("\\", "/").ToUpper();

                var requests = HttpContext.Request;

                var baseUrl = "https://images-james.cmk.co.id/" + path;

                data = data.Replace(src, baseUrl);
                var writer = new StreamWriter(stream);
                writer.Write(data);
                writer.Flush();
                stream.Position = 0;
            }

            return File(stream, "text/html");
        }

        [HttpGet("PrintInvoiceDJ")]
        public async Task<IActionResult> PrintInvoiceDJ(string invoice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_common.GetUrlJAWS() + "Print_InvoiceDJ.aspx?id=" + _salesorder.GetIDInvoice(invoice, "DJ"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = string.Empty;
            var stream = new MemoryStream();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                var writer = new StreamWriter(stream);
                writer.Write(data);
                writer.Flush();
                stream.Position = 0;
            }

            return File(stream, "text/html");
        }

        [HttpGet("PrintInvoicePG")]
        public async Task<IActionResult> PrintInvoicePG(string invoice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_common.GetUrlJAWS() + "Print_InvoicePG.aspx?id=" + _salesorder.GetIDInvoice(invoice, "PG"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = string.Empty;
            var stream = new MemoryStream();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                int start = data.IndexOf("src=\"") + 5;

                // Get the substring that starts at start, and goes up to first \".
                string src = data.Substring(start, data.IndexOf("\"", start) - start);
                string path = src.Replace(src, src.Substring(src.IndexOf('=') + 1));
                path = path.Replace("D:\\", "").Replace("\\", "/").ToUpper();

                var requests = HttpContext.Request;

                var baseUrl = "https://images-james.cmk.co.id/" + path;

                data = data.Replace(src, baseUrl);

                var writer = new StreamWriter(stream);
                writer.Write(data);
                writer.Flush();
                stream.Position = 0;
            }

            return File(stream, "text/html");
        }

        [HttpGet("PrintInvoiceLD")]
        public async Task<IActionResult> PrintInvoiceLD(string invoice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_common.GetUrlJAWS() + "Print_InvoiceLD.aspx?id=" + _salesorder.GetIDInvoice(invoice, "LD"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = string.Empty;
            var stream = new MemoryStream();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                var writer = new StreamWriter(stream);
                writer.Write(data);
                writer.Flush();
                stream.Position = 0;
            }

            return File(stream, "text/html");
        }

        [HttpGet("PrintSOGabungan")]
        public async Task<IActionResult> PrintSOGabungan(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_common.GetUrlJAWS() + "Sales_Invoice.aspx?id=" + id);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = string.Empty;
            var stream = new MemoryStream();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                var writer = new StreamWriter(stream);
                writer.Write(data);
                writer.Flush();
                stream.Position = 0;
            }

            return File(stream, "text/html");
        }

        [HttpPost("PostingSalesOrderToMyapps")]
        public IActionResult PostingSalesOrderToMyapps(int idso)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.PostingSalesOrderToMyapps(idso);

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

        [HttpPost("PostingVoidSalesOrderToMyapps")]
        public IActionResult PostingVoidSalesOrderToMyapps(int idso)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.PostingVoidSalesOrderToMyapps(idso);

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

        [HttpGet("SummarySalesOrder")]
        public IActionResult SummarySalesOrder(string location, string start, string end, int selection)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _salesorder.SummarySalesOrder(location,start,end,selection);

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

        [HttpGet("PrintSouvenirPLU")]
        public async Task<IActionResult> PrintSouvenirPLU(string id, int idstock)
        {
            string idproduct = idstock > 0 ? "&sid=" + idstock : "";
            string url = _common.GetUrlJAWS() + "Print/SalesPackaging/Sales_Packaging.aspx?id=" + id + idproduct;
            using (HttpClient httpClient = new HttpClient())
            {
                string result = await httpClient.GetStringAsync(url);
                return new ContentResult
                {
                    Content = result,
                    ContentType = "text/html"
                };
            }
        }
    }
}
