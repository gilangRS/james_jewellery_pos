using Connection.Models;
using Connection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Web;

namespace Connection.Settings
{
    public class Common
    {
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        public Common()
        {
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
        }

        public bool IsAdminSales(int ID)
        {
            AdminSalesRepository repository = new AdminSalesRepository();
            List<DataAdminSale> adminSales = repository.GetDataAdminSales(ID);
            return adminSales.Count > 0 ? true : false;
        }

        public int IsStore(int ID)
        {
            AdminSalesRepository repository = new AdminSalesRepository();
            List<DataAdminSale> adminSales = repository.GetDataAdminSales(ID);
            return adminSales.Count > 0 ? 1 : 0;
        }

        public string ChangeStringWildCardCharacterSQL(string input = "")
        {
            string x = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == "'")
                    x += input[i] + "'";
                else
                    x += input[i];
            }
            return x;
        }

        public int IDBrand()
        {
            string fileName = "../appsettings.json";
            string jsonString = File.ReadAllText(fileName);
            AppConfig AppConfig = JsonSerializer.Deserialize<AppConfig>(jsonString);

            return AppConfig.Brand;
        }

        public string KodeBrand()
        {
            string fileName = "../appsettings.json";
            string jsonString = File.ReadAllText(fileName);
            AppConfig AppConfig = JsonSerializer.Deserialize<AppConfig>(jsonString);

            return AppConfig.BrandCode;
        }

        public string Image(string img)
        {
            string ContentType = string.Empty;
            string Ext = img.Split('.', StringSplitOptions.None).Last();

            if (Ext == "png") ContentType = "image/png";
            else if (Ext == "jpg") ContentType = "image/jpeg";
            else if (Ext == "jpeg") ContentType = "image/jpeg";
            else if (Ext == "bmp") ContentType = "image/bmp";


            byte[] b;

            if (!System.IO.File.Exists(img) || string.IsNullOrEmpty(ContentType))
            {
                ContentType = "image/png";
                b = System.IO.File.ReadAllBytes("D:\\Web\\api-jaws-frank\\assets\\no_image.png");
            }
            else b = System.IO.File.ReadAllBytes(img);
            return Convert.ToBase64String(b);
        }

        public enum ActionUpload
        {
            DocRepair,
            DocRepairResult,
            DocTitipan,
            DownPayment,
            StockProductDJCustomer
        }

        public string ReturnError()
        {
            return "Terjadi Masalah Teknis. Silakan Hubungi IT Support.";
        }

        public string FolderUpload(ActionUpload action)
        {
            string Folder = "";
            if (action == ActionUpload.DocRepair)
            {
                Folder = "DocRepair";
            }
            else if (action == ActionUpload.DocTitipan)
            {
                Folder = "DocTitipan";
            }
            else if (action == ActionUpload.DownPayment)
            {
                Folder = "DownPayment";
            }
            else if (action == ActionUpload.StockProductDJCustomer)
            {
                Folder = "StockProductDJCustomer";
            }
            return Folder;
        }

        public string FolderSave(ActionUpload action, int id, string filepath)
        {
            string query = "EXEC sp_update_link_upload_new " + id + ",'" + filepath + "'";
            if (action == ActionUpload.DocRepair)
            {
                query += ",'RPR'";
            }
            else if (action == ActionUpload.DocRepairResult)
            {
                query += ", 'RPRRESULT'";
            }
            else if (action == ActionUpload.DocTitipan)
            {
                query += ",'TITIP'";
            }
            else if (action == ActionUpload.DownPayment)
            {
                query += ",'DP'";
            }
            else if (action == ActionUpload.StockProductDJCustomer)
            {
                query += ",'DJCustomer'";
            }
            return _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public object UploadImageSO(IFormFile files, int id, string filename, string brand, ActionUpload action)
        {
            try
            {
                if (files.Length > 0)
                {
                    string result = "";
                    string Direktori = "";
                    if (brand == "M" || brand == "S")
                    {
                        Direktori = "D:/ImagesMondial/Images/" + FolderUpload(action);
                    }
                    else if (brand == "P")
                    {
                        Direktori = "D:/ImagesPalace/Images/" + FolderUpload(action);
                    }
                    else
                    {
                        Direktori = "D:/Frank/Images/" + FolderUpload(action);
                    }
                    UploadImage(files, Direktori, ref filename);
                    result = FolderSave(action, id, filename);
                    return new { success = true, message = result, filename };
                }
                else
                {
                    return new { success = false, message = "Upload Failed." };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }

        public void UploadImage(IFormFile files, string Direktori, ref string filename)
        {
            string Extension = System.IO.Path.GetExtension(files.FileName);
            filename = Direktori + "/" + filename + Extension;
            if (!System.IO.Directory.Exists(Direktori))
            {
                System.IO.Directory.CreateDirectory(Direktori);
            }
            using (System.IO.FileStream filestream = System.IO.File.Create(filename))
            {
                files.CopyTo(filestream);
                filestream.Flush();
            }
        }

        public string GetUrlJAWS()
        {
            return _connectionStrings.AppConfig.UrlJAWS;
        }

        public string ImageCDN(string path)
        {
            return path.Replace(@"D:\", "").Replace(@"\", "/").ToUpper();
        }

        public decimal GetOngkosPB(string Item, string StoneDist, string Type, int IDStone, int TotalButir, decimal TotalCarat)
        {
            string query = "SELECT dbo.fx_pricing_ongkospb ('" + Item + "', '" + StoneDist + "', '" + Type + "', " + IDStone + ", " + TotalCarat + ", " + TotalButir + ")";
            return _openConnection.SingleDecimal(query, _connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public string GetModeApprovalQCLD(int iduser)
        {
            string query = "EXEC sp_get_role_user_for_approval_qc_ld " + iduser;
            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_AC);
            int rowcount = dt.Rows.Count;
            if (rowcount == 1)
            {
                return dt.Rows[0]["ROLE"].ToString();
            }
            else
            {
                return "UNKNOWN";
            }
        }

        public int GetStampsIDLocationQuery(string loccode)
        {
            int production = _connectionStrings.AppConfig.Level;
            DataTable dt = _openConnection.Rs("SELECT TOP 1 IDStamps FROM LocStampsMapping WHERE Kode = '" + loccode + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
            if (production == 1)
            {
                if (dt.Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(dt.Rows[0]["IDStamps"]);
                }
            }
            else
            {
                return 1;//development
            }
        }

        public object PostingSalesOrderMyapps(int idso)
        {
            using (JAWSDbContext _context = new JAWSDbContext())
            {
                string brand = _connectionStrings.AppConfig.BrandCode;
                SalesOrder so = _context.SalesOrders.SingleOrDefault(x => x.Id == idso && x.StatusPembayaran == true && x.StatusVoid == false);
                if (so != null)
                {
                    string result = "";
                    string noso = so.Nomor;
                    TradeIn ti = _context.TradeIns.Include(x => x.Resell).SingleOrDefault(x => x.IdsalesOrder == idso);
                    if (ti != null && ti.Resell != null)
                    {
                        string querypostingso = "SELECT 'TEST' [MSG]";
                        string querypostingtradein = "SELECT 'TEST' [MSG]";
                        if (brand == "F")
                        {
                            querypostingso = "EXEC sp_getpos @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                            querypostingtradein = "EXEC sp_gettradein @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                        }
                        else if (brand == "M" || brand == "S")
                        {
                            querypostingso = "EXEC sp_getposmd @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                            querypostingtradein = "EXEC sp_gettradeinmd @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                        }
                        else if (brand == "P")
                        {
                            querypostingso = "EXEC sp_getpostp @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                            querypostingtradein = "sp_gettradeintp @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                        }

                        result = _openConnection.SingleString("BEGIN TRY " + querypostingso + " " + querypostingtradein + " SELECT '' [MSG] END TRY BEGIN CATCH SELECT ERROR_MESSAGE() [MSG] END CATCH", _connectionStrings.ConnectionStrings.Cnn_CMK);
                    }
                    else
                    {
                        string querypostingso = "SELECT 'TEST' [MSG]";
                        if (brand == "F")
                        {
                            querypostingso = "EXEC sp_getpos @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                        }
                        else if (brand == "M" || brand == "S")
                        {
                            querypostingso = "EXEC sp_getposmd @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                        }
                        else if (brand == "P")
                        {
                            querypostingso = "EXEC sp_getpostp @p_nomor = N'" + noso + "'," + "@id_pos = " + idso;
                        }

                        result = _openConnection.SingleString("BEGIN TRY " + querypostingso + " SELECT '' [MSG] END TRY BEGIN CATCH SELECT ERROR_MESSAGE() [MSG] END CATCH", _connectionStrings.ConnectionStrings.Cnn_CMK);
                    }
                    return new { message = result };
                }
                else
                {
                    return new { message = "SO tidak ditemukan." };
                }
            }
        }

        public object PostingVoidSalesOrderMyapps(int idso)
        {
            using (JAWSDbContext _context = new JAWSDbContext())
            {
                string brand = _connectionStrings.AppConfig.BrandCode;
                SalesOrder so = _context.SalesOrders.SingleOrDefault(x => x.Id == idso && x.StatusPembayaran == true && x.StatusVoid == true);
                if (so != null)
                {
                    string query = "EXEC sp_repost_all_void_transaction 0, '" + brand + "','so','" + so.Nomor + "'";
                    _openConnection.Execute("BEGIN TRY " + query + " SELECT '' [MSG] END TRY BEGIN CATCH SELECT ERROR_MESSAGE() [MSG] END CATCH", _connectionStrings.ConnectionStrings.Cnn_CMK);
                    return new { message = "" };
                }
                else
                {
                    return new { message = "SO tidak ditemukan." };
                }
            }
        }
    }
}
