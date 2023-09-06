using API.ViewModel;
using Connection.Interface;
using Connection.Models;
using Connection.Repositories;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Auth
    {
        private readonly IAccountRepository _repository;
        private readonly JwtService _jwtService;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string NIK { get; set; }
        public string Email { get; set; }
        public int LocationType { get; set; }
        public int IDLocation { get; set; }
        public bool IsStore { get; set; }
        public int IDRole { get; set; }
        public int LevelApproval { get; set; }
        public Auth(IAccountRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
            IsStore = false;
        }

        public UserViewModel GetUser(string jwt)
        {
            UserViewModel user = new UserViewModel();
            var token = _jwtService.Verify(jwt);

            int userId = Convert.ToInt32(token.Issuer);
            var userAccount = _repository.GetAccountByID(userId);

            if(userAccount != null)
            {
                user = new UserViewModel
                {
                    Id = userAccount.Id,
                    Nama = userAccount.Nama,
                    Email = userAccount.Email,
                    Password = userAccount.Pass,
                    NIK = userAccount.UserNumber,
                    IsFrank = (bool) userAccount.IsFrank,
                    IsMondial = (bool) userAccount.IsMondial,
                    IsPalace = (bool) userAccount.IsPalace,
                    FirstLogin = !userAccount.ReadKetentuan
                };
            } 
            
            return user;
        }

        public bool IsAuthentic(string jwt)
        {
            if (jwt.IsNullOrEmpty()) return false;

            bool isAuth = false;
            UserViewModel user = new UserViewModel();
            JwtSecurityToken token = new JwtSecurityToken();
            try
            {
                token = _jwtService.Verify(jwt);
            }
            catch { return false; }
            int userId = Convert.ToInt32(token.Issuer);
            var userAccount = _repository.GetAccountByID(userId);

            if (userAccount != null)
            {
                isAuth = true;
                UserName = userAccount.Nama;
                NIK = userAccount.UserNumber;
                Email = userAccount.Email;
                UserID = userAccount.Id;
                IDRole = (int) userAccount.IDRole;

                DataAdminSale data = _repository.GetUserLocation(userId);

                if(data != null)
                {
                    LocationType = data.TipeLokasi;
                    IDLocation = data.Idlokasi;
                    IsStore = true;
                }

            }

            return isAuth;
        }

        public bool isApproval(string module)
        {
            return _repository.GetApprovalAccess(module, IDRole);
        }
    }
}
