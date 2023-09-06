using System;
using System.Collections.Generic;
using System.Text;
using Connection.AccountModels;
using Connection.Models;
using Connection.RequestModels.Account;

namespace Connection.Interface
{
    public interface IAccountRepository
    {
        UserAccount GetAccountByEmail(string email);
        UserAccount GetAccountByID(int ID);
        object GetUserDetail(int ID);
        object GetUserAccount(string Keyword, int Status);
        DataAdminSale GetUserLocation(int ID);
        bool Login(string email, string password, ref string message);
        List<Menus> GetUserAccess(int ID);
        object GetDataByNIK(string NIK);
        void CreateAccount(string NIK, string Jabatan, string Email);
        void UpdatePassword(int ID, string OldPassword, string NewPassword);
        void InsertUserAccess(List<Menu> menus);
        List<Menus> GetAllAccess(int UserID);
        List<Menus> GetRoleAccess(int IDRole);
        bool GetApprovalAccess(string Module, int IDRole);
    }
}
