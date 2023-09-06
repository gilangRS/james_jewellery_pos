using Connection.Interface;
using Connection.Settings;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly JwtService _jwtService;
        private readonly Auth _auth;
        private readonly IAccountingRepository _accounting;
        public AccountingController(IAccountRepository account, JwtService jwtService, IAccountingRepository accounting)
        {
            _account = account;
            _jwtService = jwtService;
            _auth = new Auth(_account, _jwtService);
            _accounting = accounting;
        }
    }
}
