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
    public class StampsController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly ICharacterRepository _repository;
        private readonly IStampsRepository _stamps;

        public StampsController(IAccountRepository account, JwtService jwtService, ICharacterRepository repository, IStampsRepository stamps)
        {
            _repository = repository;
            _jwtService = jwtService;
            _account = account;
            _auth = new Auth(_account, _jwtService);
            _stamps = stamps;
        }

        [HttpGet("MemberSuggestion")]
        public IActionResult MemberSuggestion(string query = "ER")
        {
            string token = Request.Cookies["token"];

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.MemberSuggestion(query);
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(result);
        }

        [HttpGet("GetMembership")]
        public IActionResult GetMembership(string user = "ER")
        {
            string token = Request.Cookies["token"];

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.GetMembership(user);
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(result);
        }

        [HttpGet("GetMembershipByCode")]
        public IActionResult GetMembershipByCode(string code)
        {
            string token = Request.Cookies["token"];

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.GetMembershipByCode(code);
            }
            else return Unauthorized(new { message = "Unauthenticated" });

            return Ok(result);
        }

        [HttpGet("ValidateVoucherCode")]
        public IActionResult ValidateVoucherCode(string vouchercode, short stampsstore)
        {
            string token = Request.Cookies["token"];

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.ValidateVoucherCode(vouchercode, stampsstore);
            }
            else return Unauthorized(new { message = "Unauthenticated" });
            return Ok(result);
        }

        [HttpPost("AddTransaction")]
        public IActionResult AddTransaction(string invoicenumber)
        {
            string token = Request.Cookies["token"];
            string user = "";
            short stampsstore = 0;
            int stamps = 0;
            int totalvalue = 0;
            int subtotal = 0;
            string employeecode = "";
            int numberofpeople = 0;
            int tax = 0;
            string createdatetime = "";
            string requireemailnotif = "";

            List<StampsConfiguration.Item> items = new List<StampsConfiguration.Item>();
            List<StampsConfiguration.ExtraData> extradata = new List<StampsConfiguration.ExtraData>();
            List<StampsConfiguration.StampsPayment> payments = new List<StampsConfiguration.StampsPayment>();

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.AddTransaction(user, stampsstore, stamps, invoicenumber, totalvalue, subtotal, employeecode, numberofpeople, tax, createdatetime, requireemailnotif, items, extradata, payments);
            }
            else return Unauthorized(new { message = "Unauthenticated" });
            return Ok(result);
        }

        [HttpPost("CancelTransaction")]
        public IActionResult CancelTransaction(int id)
        {
            string token = Request.Cookies["token"];

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.CancelTransaction(id);
            }
            else return Unauthorized(new { message = "Unauthenticated" });
            return Ok(result);
        }

        [HttpPost("ModifyTransaction")]
        public IActionResult ModifyTransaction(int id, int totalvalue, int subtotal, int stamps)
        {
            string token = Request.Cookies["token"];

            List<StampsConfiguration.Item> items = new List<StampsConfiguration.Item>();

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.ModifyTransaction(id, totalvalue, subtotal, stamps, items);
            }
            else return Unauthorized(new { message = "Unauthenticated" });
            return Ok(result);
        }

        [HttpPost("RedeemVoucher")]
        public IActionResult RedeemVoucher(string identifier, string vouchercode, short store)
        {
            string token = Request.Cookies["token"];

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.RedeemVoucher(identifier, vouchercode, store);
            }
            else return Unauthorized(new { message = "Unauthenticated" });
            return Ok(result);
        }

        [HttpPost("CancelVoucher")]
        public IActionResult CancelVoucher(int id)
        {
            string token = Request.Cookies["token"];

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.CancelVoucher(id);
            }
            else return Unauthorized(new { message = "Unauthenticated" });
            return Ok(result);
        }

        [HttpPost("AddTransactionWithRedemptionVoucher")]
        public IActionResult AddTransactionWithRedemptionVoucher(string redemptionid, string invoicenumber)
        {
            string token = Request.Cookies["token"];

            dynamic result;

            if (_auth.IsAuthentic(token))
            {
                result = _stamps.AddTransactionWithRedemptionVoucher(redemptionid,invoicenumber);
            }
            else return Unauthorized(new { message = "Unauthenticated" });
            return Ok(result);
        }
    }
}
