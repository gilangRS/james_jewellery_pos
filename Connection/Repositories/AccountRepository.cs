using System;
using System.Collections.Generic;
using System.Text;
using Connection.Interface;
using Connection.AccountModels;
using System.Linq;
using System.Security.Cryptography;
using Connection.Models;
using Microsoft.EntityFrameworkCore;
using Connection.Settings;
using System.Data;
using Connection.RequestModels.Account;

namespace Connection.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private AccountContext _account;
        private JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;

        public AccountRepository()
        {
            _account = new AccountContext();
            _context = new JAWSDbContext(); 
            this.connectionStrings = new ConnectionString();
        }

        public UserAccount GetAccountByEmail(string email)
        {
            UserAccount account = _account.UserAccounts.SingleOrDefault(p => p.Email.Equals(email));
            return account;
        }

        public UserAccount GetAccountByID(int ID)
        {
            UserAccount account = _account.UserAccounts.SingleOrDefault(p => p.Id.Equals(ID));
            return account;
        }

        public object GetUserAccount(string Keyword, int Status)
        {
            object account = from a in _account.UserAccounts.Where(p => (p.Email.Equals(Keyword) || p.UserNumber.Equals(Keyword) || p.Nama.Contains(Keyword)) && p.Status.Equals(Status))
                             orderby a.Nama
                             select new {
                                 ID = a.Id,
                                 Nama = a.Nama,
                                 Email = a.Email,
                                 Keterangan = a.Keterangan,
                                 Status = a.Status,
                                 LastLogin = a.LastLogin.Value.ToString("D"),
                             };
            return account;
        }

        public object GetUserDetail(int ID)
        {
            return _account.UserAccounts.SingleOrDefault(p => p.Id.Equals(ID));
        }

        //public List<UserRole> GetUserRole(int ID) 
        //{
        //    List<UserRole> userRoles = _account.UserRoles.Where(p => p.Id.Equals(ID)).ToList();
        //    return userRoles;
        //}

        public DataAdminSale GetUserLocation(int ID)
        {
            return _context.DataAdminSales.FirstOrDefault(p => p.IdNew == ID && p.Draft == false && p.Disable == false);
        }

        public bool Login(string email, string password, ref string message)
        {
            string x = PassEncryption(password);

            var account = _account.UserAccounts.SingleOrDefault(p => p.Email.Equals(email));

            if (account.Pass != x)
            {
                account.PassInvalid++;

                _account.SaveChanges();

                if (account.PassInvalid == 1) message = "Wrong Password 1x";
                if (account.PassInvalid == 2) message = "Wrong Password 2x, Last Attempt";
                if (account.PassInvalid >= 3)
                {
                    message = "Account Blocked for 15 minutes";

                    account.PassInvalid = 0;
                    account.Blokir = DateTime.Now.AddMinutes(15);

                    //Commit
                    _account.SaveChanges();
                }
                return false;
            }
            else
            {
                account.PassInvalid = 0;
                account.PassResetKey = null;
                account.Blokir = null;

                //Recycle-Pass
                if (!account.RecycleLast.HasValue ||
                    (account.RecycleLast.HasValue && account.RecycleLast.Value.AddMonths(12) < DateTime.Now)) //Setiap 12 Bulan
                    account.Recycle = true;
                else
                    account.Recycle = false;

                //Login-Info
                account.LastLogin = DateTime.Now;
                _account.SaveChanges();
            }


            return true;
        }


        public List<Menus> GetUserAccess(int ID)
        {
            List<Menus> datas = GetMenu(ID);

            return datas;
        }

        private List<Menus> GetChildMenu(int ParentID, int UserID)
        {
            List<Menus> child = new List<Menus>();

            string query = "SELECT * FROM Menu A JOIN UserAccess B ON A.ID = B.IDMenu WHERE A.ParentID = " + ParentID.ToString() + " AND B.IDUser = " + UserID.ToString() + "  ORDER BY Sequence";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_AC);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    child.Add(new Menus
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        ParentId = Convert.ToInt32(row["ParentID"]),
                        Menu = row["Menu"].ToString(),
                        Url = row["Url"].ToString(),
                        ChildMenu = GetChildMenu(Convert.ToInt32(row["ID"]), UserID)
                    });
                }
            }
            return child;
        }

        private List<Menus> GetMenu(int UserID)
        {
            List<Menus> menus = new List<Menus>();

            string query = "SELECT A.* FROM Menu A JOIN UserAccess B ON A.ID = B.IDMenu WHERE A.ParentID = 0 AND B.IDUser = " + UserID.ToString() + " ORDER BY Sequence";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_AC);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    menus.Add(new Menus
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        ParentId = Convert.ToInt32(row["ParentID"]),
                        Menu = row["Menu"].ToString(),
                        Url = row["Url"].ToString(),
                        ChildMenu = GetChildMenu(Convert.ToInt32(row["ID"]), UserID)
                    });
                }
            }
            return menus;
        }

        public object GetDataByNIK(string NIK)
        {
            var account = _account.UserAccounts.Where(p => p.UserNumber.Equals(NIK));
            object data = new object();

            if (account.Count() < 1)
            {
                string query = "exec sp_getdatakaryawan '" + NIK + "'";

                DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

                if (dt.Rows.Count == 1)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        data = new
                        {
                            Nama = row["m_nama"].ToString(),
                            Jabatan = row["m_jabatan"].ToString(),
                            Email = row["m_emailkantor"].ToString()
                        };
                    }
                }
            }
            else connection.Execute("exec sp_ThrowError 'Akun dengan NIK " + NIK + " sudah ada'", connectionStrings.ConnectionStrings.Cnn_DB);

            return data;
        }

        public void CreateAccount(string NIK, string Jabatan, string Email)
        {
            UserAccount account = new UserAccount();

            //Input
            account.InputDate = DateTime.Now;

            //Account
            account.Keterangan = Jabatan;
            account.Email = Email;
            account.Sms = string.Empty;
            account.UserNumber = NIK;

            //Password
            account.Pass = PassEncryption("123");
            account.PassStrong = false;

            //Recycle-Pass
            account.Recycle = true;

            //Commit
            _account.UserAccounts.Add(account);
            _account.SaveChanges();
        }

        public void UpdatePassword(int ID, string OldPassword, string NewPassword)
        {
            UserAccount account = _account.UserAccounts.FirstOrDefault(p => p.Id == ID);

            if(account.Pass.Equals(PassEncryption(OldPassword)))
            {
                account.Pass = PassEncryption(NewPassword);
                account.ReadKetentuan = true;

                LogGantiPassword log = new LogGantiPassword();

                log.Email = account.Email;
                log.Nik = account.UserNumber;
                log.OldPassword = PassEncryption(OldPassword);
                log.UpdateDate = DateTime.Now;

                _account.LogGantiPasswords.Add(log);
                _account.SaveChanges();
            }
            else connection.Execute("exec sp_ThrowError 'Password lama tidak sesuai dengan password yang terdaftar'", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void InsertUserAccess(List<Menu> menus)
        {
            var currentAccess = _account.UserAccesses.Where(p => p.Iduser == menus.FirstOrDefault().IDUser);

            foreach(UserAccess x in currentAccess)
            {
                _account.Remove(x);
            }

            UserAccess access = new UserAccess();
            
            foreach(Menu x in menus)
            {
                access.Idmenu = x.IDMenu;
                access.Iduser = x.IDUser;
                _account.Add(access);
            }

            _account.SaveChanges();
        }


        public object GetAllRoles()
        {
            object data = new object();

            data = from a in _account.Roles
                   select new
                   {
                       ID = a.Id,
                       Role = a.Role1
                   };

            return data;
        }

        public List<Menus> GetRoleAccess(int IDRole)
        {
            List<Menus> menus = new List<Menus>();

            string query = "SELECT A.ID, A.ParentID, A.Menu, A.Url, CASE WHEN B.IDRole IS NULL THEN 0 ELSE 1 END IsChecked FROM Menu A LEFT JOIN RoleAccess B ON A.ID = B.IDMenu AND B.IDRole = " + IDRole + " WHERE A.ParentID = 0 ORDER BY Sequence";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_AC);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    menus.Add(new Menus
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        ParentId = Convert.ToInt32(row["ParentID"]),
                        Menu = row["Menu"].ToString(),
                        Url = row["Url"].ToString(),
                        IsChecked = Convert.ToBoolean(row["IsChecked"]),
                        ChildMenu = GetChildAccess(Convert.ToInt32(row["ID"]), IDRole)
                    });
                }
            }
            return menus;
        }

        private List<Menus> GetRoleAccess(int ParentID, int IDRole)
        {
            List<Menus> child = new List<Menus>();

            string query = "SELECT A.ID, A.ParentID, A.Menu, A.Url, CASE WHEN B.IDRole IS NULL THEN 0 ELSE 1 END IsChecked  FROM Menu A LEFT JOIN RoleAccess B ON A.ID = B.IDMenu AND B.IDRole = " + IDRole + " WHERE A.ParentID = " + ParentID.ToString() + " ORDER BY Sequence";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_AC);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    child.Add(new Menus
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        ParentId = Convert.ToInt32(row["ParentID"]),
                        Menu = row["Menu"].ToString(),
                        Url = row["Url"].ToString(),
                        IsChecked = Convert.ToBoolean(row["IsChecked"]),
                        ChildMenu = GetRoleAccess(Convert.ToInt32(row["ID"]), IDRole)
                    });
                }
            }
            return child;
        }

        public List<Menus> GetAllAccess(int UserID)
        {
            List<Menus> menus = new List<Menus>();

            string query = "SELECT A.ID, A.ParentID, A.Menu, A.Url, CASE WHEN B.IDUser IS NULL THEN 0 ELSE 1 END IsChecked FROM Menu A LEFT JOIN UserAccess B ON A.ID = B.IDMenu AND B.IDUser = " + UserID + " WHERE A.ParentID = 0 ORDER BY Sequence";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_AC);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    menus.Add(new Menus
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        ParentId = Convert.ToInt32(row["ParentID"]),
                        Menu = row["Menu"].ToString(),
                        Url = row["Url"].ToString(),
                        IsChecked = Convert.ToBoolean(row["IsChecked"]),
                        ChildMenu = GetChildAccess(Convert.ToInt32(row["ID"]), UserID)
                    });
                }
            }
            return menus;
        }

        public bool GetApprovalAccess(string Module, int IDRole)
        {
            return _account.UserApprovals.Any(p => p.Approval.Equals(Module) && p.Idrole == IDRole);
        }

        private List<Menus> GetChildAccess(int ParentID, int UserID)
        {
            List<Menus> child = new List<Menus>();

            string query = "SELECT A.ID, A.ParentID, A.Menu, A.Url, CASE WHEN B.IDUser IS NULL THEN 0 ELSE 1 END IsChecked  FROM Menu A LEFT JOIN UserAccess B ON A.ID = B.IDMenu AND B.IDUser = " + UserID + " WHERE A.ParentID = " + ParentID.ToString() + " ORDER BY Sequence";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_AC);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    child.Add(new Menus
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        ParentId = Convert.ToInt32(row["ParentID"]),
                        Menu = row["Menu"].ToString(),
                        Url = row["Url"].ToString(),
                        IsChecked = Convert.ToBoolean(row["IsChecked"]),
                        ChildMenu = GetChildAccess(Convert.ToInt32(row["ID"]), UserID)
                    });
                }
            }
            return child;
        }

        private string PassEncryption(string Password)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(Password);
            SHA1 sha = new SHA1CryptoServiceProvider();

            byte[] data = sha.ComputeHash(bytes);

            string x = "";
            for (int i = 0; i < data.Length; i++)
                x += data[i].ToString("x2");

            return x;
        }

        
    }
}
