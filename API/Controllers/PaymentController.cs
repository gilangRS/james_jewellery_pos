using Connection.Interface;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IPaymentRepository _payment;
        private readonly Common _common;

        public PaymentController(IAccountRepository account, JwtService jwtService, IPaymentRepository payment)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _payment = payment;
            _common = new Common();
        }

        [HttpGet("GetPaymentTypes")]
        public IActionResult GetPaymentTypes()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.GetPaymentTypes();
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetBankIssuers")]
        public IActionResult GetBankIssuers()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.GetBankIssuers();
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetProgramCicilans")]
        public IActionResult GetProgramCicilans()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.GetProgramCicilans();
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetEDCs")]
        public IActionResult GetEDCs(bool islei,bool isqris)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.GetEDCs(islei,isqris);
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetCards")]
        public IActionResult GetCards()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.GetCards();
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("GetJenisKartuKredits")]
        public IActionResult GetJenisKartuKredits()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.GetJenisKartuKredits();
                }
                else return Unauthorized(new { message = "Unauthenticated" });

                return Ok(collection);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpGet("ValidationAddPayment")]
        public IActionResult ValidationAddPayment(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.ValidationAddPayment(id);

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

        [HttpPost("AddPaymentSalesOrder")]
        public IActionResult AddPaymentSalesOrder(RequestSalesReceipt sr)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.AddPaymentToSalesOrder(sr);

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
                return StatusCode(400,ex.Message);
            }
        }

        [HttpPost("PostingSalesOrderToStamps")]
        public IActionResult PostingSalesOrderToStamps(int id, bool isrequireemail)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.PostingSalesOrderToStamps(id, isrequireemail);

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

        [HttpPut("CancelSalesOrderToStamps")]
        public IActionResult CancelSalesOrderToStamps(int id, bool isrequireemail)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.CancelSalesOrderToStamps(id, isrequireemail);

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


        [HttpGet("ValidatePaymentVoucher")]
        public IActionResult ValidatePaymentVoucher(string nomor, string loccode, string customercode)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.ValidatePaymentVoucher(nomor, loccode, customercode);

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

        /*[HttpPut("VoidPaymentSalesOrder")]
        public IActionResult VoidPaymentSalesOrder(int id, string operatorname)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.VoidPaymentSalesOrder(id, operatorname);

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
        }*/

        [HttpPost("AddDownPayment")]
        public IActionResult AddDownPayment(RequestSalesReceiptDPPO rsrpo)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.AddDownPayment(rsrpo);

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

        [HttpGet("ValidateDownPayment")]
        public IActionResult ValidateDownPayment(string nomor, int idcustomer, string kodecustomerlama)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.ValidateDownPayment(nomor, idcustomer, kodecustomerlama);

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

        [HttpGet("GetDownPaymentByCustomer")]
        public IActionResult GetDownPaymentByCustomer(string kw, int idcustomer, string kodecustomerlama)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.GetDownPaymentByCustomer(kw,idcustomer, kodecustomerlama);

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

        [HttpGet("GetDownPaymentByID")]
        public IActionResult GetDownPaymentByID(int id)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.GetDownPaymentByID(id);

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

        [HttpPut("VoidDownPayment")]
        public IActionResult VoidDownPayment(int id, string operatornama, string keterangan)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.VoidDownPayment(id, operatornama, keterangan);

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

        [HttpGet("ReportDownPayment")]
        public IActionResult ReportDownPayment(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.ReportDownPayment(kw, start, end, location, status, page, row, excel);
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

        [HttpPost("UploadImageDownPayment")]
        public IActionResult UploadImageDownPayment(IFormFile files, int id, string brand)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.UploadImageDownPayment(files, id, brand);
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

        [HttpGet("ReportSummaryPaymentSalesOrder")]
        public IActionResult ReportSummaryPaymentSalesOrder(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                object collection;

                if (_auth.IsAuthentic(token))
                {
                    collection = _payment.ReportSummaryPaymentSalesOrder(kw, start, end, location, status, page, row, excel);
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

        [HttpGet("PrintDownPayment")]
        public async Task<IActionResult> PrintDownPayment(string id)
        {
            string url = _common.GetUrlJAWS() + "Print/DownPayment/PaymentDP_Print.aspx?id=" + id;
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

        [HttpGet("PrintDownPaymentPO")]
        public async Task<IActionResult> PrintDownPaymentPO(string id)
        {
            string url = _common.GetUrlJAWS() + "Print/DownPayment/PaymentDP_POPrint.aspx?id=" + id;
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
