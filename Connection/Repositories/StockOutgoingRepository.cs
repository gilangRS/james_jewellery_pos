using Connection.Interface;
using Connection.Models;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Connection.RequestModels.StockTransfer;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Connection.Repositories
{
    public class StockOutgoingRepository : IStockOutgoingRepository
    {
        private readonly JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;
        private Common common;
        public StockOutgoingRepository()
        {
            common = new Common();
            _context = new JAWSDbContext();
            this.connectionStrings = new ConnectionString();
        }

        #region Get Stock Outgoing
        public List<object> GetStockOutgoingDJ(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingDJ_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + BrandTujuan + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsCrossBrand = Convert.ToBoolean(row["IsCrossBrand"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        IDStatus = Convert.ToInt32(row["IDStatus"]),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                        AllowedApprove = string.IsNullOrEmpty(row["Approval"].ToString()) && IsApproval ? true : false
                    });
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingPG(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingPG_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + BrandTujuan + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsCrossBrand = Convert.ToBoolean(row["IsCrossBrand"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        IDStatus = Convert.ToInt32(row["IDStatus"]),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                        AllowedApprove = string.IsNullOrEmpty(row["Approval"].ToString()) && IsApproval ? true : false
                    });
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingLD(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingLD_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + BrandTujuan + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsCrossBrand = Convert.ToBoolean(row["IsCrossBrand"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                        AllowedApprove = string.IsNullOrEmpty(row["Approval"].ToString()) && IsApproval ? true : false
                    });
                }
            }

            return datas;
        }
        public List<object> GetStockOutgoingGJ(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingGJ_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsCrossBrand = Convert.ToBoolean(row["IsCrossBrand"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                        AllowedApprove = string.IsNullOrEmpty(row["Approval"].ToString()) && IsApproval ? true : false
                    });
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingPackaging(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingPackaging_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                        AllowedApprove = string.IsNullOrEmpty(row["Approval"].ToString()) && IsApproval ? true : false
                    });
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingSouvenir(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingSouvenir_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                        AllowedApprove = string.IsNullOrEmpty(row["Approval"].ToString()) && IsApproval ? true : false
                    });
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingCetakan(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingCetakan_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                        AllowedApprove = string.IsNullOrEmpty(row["Approval"].ToString()) && IsApproval ? true : false
                    });
                }
            }

            return datas;
        }

        public object GetStockOutgoingDJDetail(int ID, int isCrossBrand)
        {
            object data = new object();
            object outgoing = new object();

            if (isCrossBrand == 1)
            {
                var singleOutgoing = _context.CrossBrandStockOutgoingDJs
                    .Include(p => p.BrandAsal)
                    .Include(p => p.BrandTujuan)
                    .Where(p => p.Id == ID);

                outgoing = (from a in singleOutgoing
                            select new { 
                                ID = a.Id,
                                BrandAsal = a.BrandAsal.Nama,
                                IDBrandAsal = a.IdbrandAsal,
                                BrandTujuan = a.BrandTujuan.Nama,
                                IDBrandTujuan = a.IdbrandTujuan,
                                TipeAsal = a.TipeAsal,
                                TIpeTujuan = a.TipeTujuan,
                                LokasiAsal = a.NamaAsal,
                                IDAsal = a.Idasal,
                                LokasiTujuan = a.NamaTujuan,
                                IDTujuan = a.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }
            else 
            {
                var singleOutgoing = _context.StockOutgoingDjs
                    .Include(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

                outgoing = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.CompanyBrand.Nama,
                                IDBrandAsal = a.Idbrand,
                                BrandTujuan = a.CompanyBrand.Nama,
                                IDBrandTujuan = a.Idbrand,
                                TipeAsal = a.TipeAsal,
                                TIpeTujuan = a.TipeTujuan,
                                LokasiAsal = a.NamaAsal,
                                IDAsal = a.Idasal,
                                LokasiTujuan = a.NamaTujuan,
                                IDTujuan = a.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }

            data = new
            {
                outgoing,
                product = GetStockOutgoingDJProduct(ID, isCrossBrand)
            };
            return data;
        }

        private List<object> GetStockOutgoingDJProduct(int ID, int isCrossBrand)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingDJ_Detail "
                + ID + ", "
                + isCrossBrand;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        ProductCategory = row["ProductCategory"].ToString(),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        StoneCarat = Convert.ToDecimal(row["StoneCarat"]),
                        StoneQty = Convert.ToDecimal(row["StoneQty"]),
                        HargaRupiah = Convert.ToDecimal(row["HargaRupiahRound"]),
                        HargaPromo = Convert.ToDecimal(row["PromoHarga"]),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        Substorage = row["Substorage"].ToString()
                    });
                }
            }

            return datas;
        }

        public object GetStockOutgoingPGDetail(int ID, int isCrossBrand)
        {
            object data = new object();
            object outgoing = new object();

            if (isCrossBrand == 1)
            {
                var singleOutgoing = _context.CrossBrandStockOutgoingPgs
                    .Include(p => p.BrandAsal)
                    .Include(p => p.BrandTujuan)
                    .Where(p => p.Id == ID);

                outgoing = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.BrandAsal.Nama,
                                IDBrandAsal = a.IdbrandAsal,
                                BrandTujuan = a.BrandTujuan.Nama,
                                IDBrandTujuan = a.IdbrandTujuan,
                                TipeAsal = a.TipeAsal,
                                TIpeTujuan = a.TipeTujuan,
                                LokasiAsal = a.NamaAsal,
                                IDAsal = a.Idasal,
                                LokasiTujuan = a.NamaTujuan,
                                IDTujuan = a.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }
            else
            {
                var singleOutgoing = _context.StockOutgoingPgs
                    .Include(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

                outgoing = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.CompanyBrand.Nama,
                                IDBrandAsal = a.Idbrand,
                                BrandTujuan = a.CompanyBrand.Nama,
                                IDBrandTujuan = a.Idbrand,
                                TipeAsal = a.TipeAsal,
                                TIpeTujuan = a.TipeTujuan,
                                LokasiAsal = a.NamaAsal,
                                IDAsal = a.Idasal,
                                LokasiTujuan = a.NamaTujuan,
                                IDTujuan = a.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }

            data = new
            {
                outgoing,
                product = GetStockOutgoingPGProduct(ID, isCrossBrand)
            };
            return data;
        }

        private List<object> GetStockOutgoingPGProduct(int ID, int isCrossBrand)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingPG_Detail "
                + ID + ", "
                + isCrossBrand;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        GoldLevel = row["GoldLevel"].ToString(),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        HargaRupiah = Convert.ToDecimal(row["TotalHargaJual"]),
                        HargaPromo = Convert.ToDecimal(row["PromoHarga"]),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        Substorage = row["Substorage"].ToString()
                    });
                }
            }

            return datas;
        }

        public object GetStockOutgoingLDDetail(int ID, int isCrossBrand)
        {
            object data = new object();
            object outgoing = new object();

            if (isCrossBrand == 1)
            {
                var singleOutgoing = _context.CrossBrandStockOutgoingLDs
                    .Include(p => p.BrandAsal)
                    .Include(p => p.BrandTujuan)
                    .Where(p => p.Id == ID);

                outgoing = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.BrandAsal.Nama,
                                IDBrandAsal = a.IdbrandAsal,
                                BrandTujuan = a.BrandTujuan.Nama,
                                IDBrandTujuan = a.IdbrandTujuan,
                                TipeAsal = a.TipeAsal,
                                TIpeTujuan = a.TipeTujuan,
                                LokasiAsal = a.NamaAsal,
                                IDAsal = a.Idasal,
                                LokasiTujuan = a.NamaTujuan,
                                IDTujuan = a.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }
            else
            {
                var singleOutgoing = _context.StockOutgoingLds
                    .Include(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

                outgoing = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.CompanyBrand.Nama,
                                IDBrandAsal = a.Idbrand,
                                BrandTujuan = a.CompanyBrand.Nama,
                                IDBrandTujuan = a.Idbrand,
                                TipeAsal = a.TipeAsal,
                                TIpeTujuan = a.TipeTujuan,
                                LokasiAsal = a.NamaAsal,
                                IDAsal = a.Idasal,
                                LokasiTujuan = a.NamaTujuan,
                                IDTujuan = a.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }

            data = new
            {
                outgoing,
                product = GetStockOutgoingLDProduct(ID, isCrossBrand)
            };
            return data;
        }

        private List<object> GetStockOutgoingLDProduct(int ID, int isCrossBrand)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingLD_Detail "
                + ID + ", "
                + isCrossBrand;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        GIA = row["GIA"].ToString(),
                        TotalButir = Convert.ToDecimal(row["TotalButir"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        HargaRupiah = Convert.ToDecimal(row["HargaTotal"]),
                        Substorage = row["Substorage"].ToString()
                    });
                }
            }

            return datas;
        }
        public object GetStockOutgoingGJDetail(int ID)
        {
            object data = new object();
            object outgoing = new object();

            var singleOutgoing = _context.StockOutgoingGjs
                    .Include(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

            outgoing = (from a in singleOutgoing
                        select new
                        {
                            ID = a.Id,
                            BrandAsal = a.CompanyBrand.Nama,
                            IDBrandAsal = a.Idbrand,
                            BrandTujuan = a.CompanyBrand.Nama,
                            IDBrandTujuan = a.Idbrand,
                            TipeAsal = a.TipeAsal,
                            TIpeTujuan = a.TipeTujuan,
                            LokasiAsal = a.NamaAsal,
                            IDAsal = a.Idasal,
                            LokasiTujuan = a.NamaTujuan,
                            IDTujuan = a.Idtujuan,
                            Nomor = a.Nomor,
                            Kurir = a.NamaKurir,
                            Description = a.Keterangan,
                            ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                        }).SingleOrDefault();

            data = new
            {
                outgoing,
                product = GetStockOutgoingGJProduct(ID)
            };
            return data;
        }

        private List<object> GetStockOutgoingGJProduct(int ID)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingGJ_Detail " + ID;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        TotalButir = Convert.ToDecimal(row["TotalButir"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        HargaRupiah = Convert.ToDecimal(row["HargaTotal"]),
                        Substorage = row["Substorage"].ToString()
                    });
                }
            }

            return datas;
        }

        public object GetStockOutgoingPackagingDetail(int ID)
        {
            object data = new object();
            object outgoing = new object();

            var singleOutgoing = _context.StockOutgoingPackagings
                    .Include(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

            outgoing = (from a in singleOutgoing
                        select new
                        {
                            ID = a.Id,
                            BrandAsal = a.CompanyBrand.Nama,
                            IDBrandAsal = a.Idbrand,
                            BrandTujuan = a.CompanyBrand.Nama,
                            IDBrandTujuan = a.Idbrand,
                            TipeAsal = a.TipeAsal,
                            TIpeTujuan = a.TipeTujuan,
                            LokasiAsal = a.NamaAsal,
                            IDAsal = a.Idasal,
                            LokasiTujuan = a.NamaTujuan,
                            IDTujuan = a.Idtujuan,
                            Nomor = a.Nomor,
                            Kurir = a.NamaKurir,
                            Description = a.Keterangan,
                            ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                        }).SingleOrDefault();

            data = new
            {
                outgoing,
                product = GetStockOutgoingPackagingProduct(ID)
            };
            return data;
        }

        private List<object> GetStockOutgoingPackagingProduct(int ID)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingPackaging_Detail " + ID;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nama = row["Nama"].ToString(),
                        Kode = row["Kode"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        InHand = Convert.ToInt32(row["InHand"]),
                        Qty = Convert.ToInt32(row["Qty"]),
                    });
                }
            }

            return datas;
        }

        public object GetStockOutgoingPackagingDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor, int IDProduct, int Status)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingPackagingDetail_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + IDProduct + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        Kode = row["Kode"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D")
                    });
                }
            }

            return datas;
        }

        public object GetStockOutgoingSouvenirDetail(int ID)
        {
            object data = new object();
            object outgoing = new object();

            var singleOutgoing = _context.StockOutgoingSouvenirs
                    .Include(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

            outgoing = (from a in singleOutgoing
                        select new
                        {
                            ID = a.Id,
                            BrandAsal = a.CompanyBrand.Nama,
                            IDBrandAsal = a.Idbrand,
                            BrandTujuan = a.CompanyBrand.Nama,
                            IDBrandTujuan = a.Idbrand,
                            TipeAsal = a.TipeAsal,
                            TIpeTujuan = a.TipeTujuan,
                            LokasiAsal = a.NamaAsal,
                            IDAsal = a.Idasal,
                            LokasiTujuan = a.NamaTujuan,
                            IDTujuan = a.Idtujuan,
                            Nomor = a.Nomor,
                            Kurir = a.NamaKurir,
                            Description = a.Keterangan,
                            ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                        }).SingleOrDefault();

            data = new
            {
                outgoing,
                product = GetStockOutgoingSouvenirProduct(ID)
            };
            return data;
        }

        private List<object> GetStockOutgoingSouvenirProduct(int ID)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingSouvenir_Detail " + ID;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nama = row["Nama"].ToString(),
                        Kode = row["Kode"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        InHand = Convert.ToInt32(row["InHand"]),
                        Qty = Convert.ToInt32(row["Qty"]),
                    });
                }
            }

            return datas;
        }

        public object GetStockOutgoingSouvenirDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor, int IDProduct, int Status)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingSouvenirDetail_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + IDProduct + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        Kode = row["Kode"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D")
                    });
                }
            }

            return datas;
        }


        public object GetStockOutgoingCetakanDetail(int ID)
        {
            object data = new object();
            object outgoing = new object();

            var singleOutgoing = _context.StockOutgoingCetakans
                    .Include(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

            outgoing = (from a in singleOutgoing
                        select new
                        {
                            ID = a.Id,
                            BrandAsal = a.CompanyBrand.Nama,
                            IDBrandAsal = a.Idbrand,
                            BrandTujuan = a.CompanyBrand.Nama,
                            IDBrandTujuan = a.Idbrand,
                            TipeAsal = a.TipeAsal,
                            TIpeTujuan = a.TipeTujuan,
                            LokasiAsal = a.NamaAsal,
                            IDAsal = a.Idasal,
                            LokasiTujuan = a.NamaTujuan,
                            IDTujuan = a.Idtujuan,
                            Nomor = a.Nomor,
                            Kurir = a.NamaKurir,
                            Description = a.Keterangan,
                            ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                        }).SingleOrDefault();

            data = new
            {
                outgoing,
                product = GetStockOutgoingCetakanProduct(ID)
            };
            return data;
        }

        private List<object> GetStockOutgoingCetakanProduct(int ID)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingCetakan_Detail " + ID;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nama = row["Nama"].ToString(),
                        Kode = row["Kode"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        InHand = Convert.ToInt32(row["InHand"]),
                        Qty = Convert.ToInt32(row["Qty"]),
                    });
                }
            }

            return datas;
        }

        public object GetStockOutgoingCetakanDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor, int IDProduct, int Status)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockOutgoingCetakanDetail_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + IDProduct + ", "
                + Status;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorOutgoing = row["NomorOutgoing"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        Kode = row["Kode"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D")
                    });
                }
            }

            return datas;
        }
        #endregion

        #region Insert Stock Outgoing
        public void InsertStockOutgoingDJ(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = MappingOutgoing(datas, Username);

            int ID = connection.SingleInteger(dt, "dbo.sp_InsertCrossBrandOutgoingDJ", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingOutgoingProduct(datas, ID);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandOutgoingDJ_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void InsertStockOutgoingPG(RequestStockOutgoingBRJ datas, string Username)
        {
            if(datas.BrandAsal != datas.BrandTujuan)
            {
                List<int> IDs = new List<int>();
                foreach(Product x in datas.Products)
                {
                    IDs.Add(x.ID);
                }

                if (_context.StockProductPgs.Include(p => p.CharGoldLevel).Any(p => (!p.CharGoldLevel.Nama.Contains("PGE") && !p.KodeBarang.Contains("TinyTAN") && !p.CharGoldLevel.NamaKode.Contains("VLEI")) && IDs.Contains(p.Id))) connection.Execute("exec sp_ThrowError 'List mengandung barang selain PGE'", connectionStrings.ConnectionStrings.Cnn_DB);
            }

            DataTable dt = MappingOutgoing(datas, Username);

            int ID = connection.SingleInteger(dt, "dbo.sp_InsertCrossBrandOutgoingPG", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingOutgoingProduct(datas, ID);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandOutgoingPG_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void InsertStockOutgoingLD(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = MappingOutgoing(datas, Username);

            int ID = connection.SingleInteger(dt, "dbo.sp_InsertCrossBrandOutgoingLD", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingOutgoingProduct(datas, ID);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandOutgoingLD_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }
        public void InsertStockOutgoingGJ(RequestStockOutgoingBRJ datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockOutgoingGJ outgoing = new StockOutgoingGJ();
                    outgoing.Idbrand = datas.BrandAsal;
                    outgoing.TipeAsal = datas.TipeAsal;
                    outgoing.TipeTujuan = datas.TipeTujuan;
                    outgoing.Idasal = datas.IDAsal;
                    outgoing.Idtujuan = datas.IDTujuan;
                    outgoing.NamaAsal = datas.NamaAsal;
                    outgoing.NamaTujuan = datas.NamaTujuan;
                    outgoing.Tgl = Convert.ToDateTime(datas.Tgl);
                    outgoing.TglEta = Convert.ToDateTime(datas.TglETA);
                    outgoing.NamaKurir = datas.NamaKurir;
                    outgoing.Keterangan = datas.Keterangan;
                    outgoing.StatusTransOut = 1;
                    outgoing.Operator = Username;
                    outgoing.OperatorTgl = DateTime.Now;

                    _context.StockOutgoingGjs.Add(outgoing);
                    _context.SaveChanges();

                    foreach (Product x in datas.Products)
                    {
                        int substorage = _context.Substorages.SingleOrDefault(p => p.Nama == x.Substorage).Id;

                        StockOutgoingGJ_Product product = new StockOutgoingGJ_Product();

                        product.Idform = outgoing.Id;
                        product.Idproduct = x.ID;
                        product.SubStorage = substorage;

                        _context.StockOutgoingGjProducts.Add(product);
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void InsertStockOutgoingPackaging(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockOutgoingPackaging outgoing = new StockOutgoingPackaging();
                    outgoing.Idbrand = datas.Brand;
                    outgoing.TipeAsal = datas.TipeAsal;
                    outgoing.TipeTujuan = datas.TipeTujuan;
                    outgoing.Idasal = datas.IDAsal;
                    outgoing.Idtujuan = datas.IDTujuan;
                    outgoing.NamaAsal = datas.NamaAsal;
                    outgoing.NamaTujuan = datas.NamaTujuan;
                    outgoing.Tgl = Convert.ToDateTime(datas.Tgl);
                    outgoing.TglEta = Convert.ToDateTime(datas.TglETA);
                    outgoing.NamaKurir = datas.NamaKurir;
                    outgoing.Keterangan = datas.Keterangan;
                    outgoing.StatusTransOut = 1;
                    outgoing.Operator = Username;
                    outgoing.OperatorTgl = DateTime.Now;

                    _context.StockOutgoingPackagings.Add(outgoing);
                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockOutgoingPackaging_Product product = new StockOutgoingPackaging_Product();

                        product.Idform = outgoing.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;

                        _context.StockOutgoingPackagingProducts.Add(product);
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void InsertStockOutgoingSouvenir(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockOutgoingSouvenir outgoing = new StockOutgoingSouvenir();
                    outgoing.Idbrand = datas.Brand;
                    outgoing.TipeAsal = datas.TipeAsal;
                    outgoing.TipeTujuan = datas.TipeTujuan;
                    outgoing.Idasal = datas.IDAsal;
                    outgoing.Idtujuan = datas.IDTujuan;
                    outgoing.NamaAsal = datas.NamaAsal;
                    outgoing.NamaTujuan = datas.NamaTujuan;
                    outgoing.Tgl = Convert.ToDateTime(datas.Tgl);
                    outgoing.TglEta = Convert.ToDateTime(datas.TglETA);
                    outgoing.NamaKurir = datas.NamaKurir;
                    outgoing.Keterangan = datas.Keterangan;
                    outgoing.StatusTransOut = 1;
                    outgoing.Operator = Username;
                    outgoing.OperatorTgl = DateTime.Now;

                    _context.StockOutgoingSouvenirs.Add(outgoing);
                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockOutgoingSouvenir_Product product = new StockOutgoingSouvenir_Product();

                        product.Idform = outgoing.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;

                        _context.StockOutgoingSouvenirProducts.Add(product);
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void InsertStockOutgoingCetakan(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockOutgoingCetakan outgoing = new StockOutgoingCetakan();
                    outgoing.Idbrand = datas.Brand;
                    outgoing.TipeAsal = datas.TipeAsal;
                    outgoing.TipeTujuan = datas.TipeTujuan;
                    outgoing.Idasal = datas.IDAsal;
                    outgoing.Idtujuan = datas.IDTujuan;
                    outgoing.NamaAsal = datas.NamaAsal;
                    outgoing.NamaTujuan = datas.NamaTujuan;
                    outgoing.Tgl = Convert.ToDateTime(datas.Tgl);
                    outgoing.TglEta = Convert.ToDateTime(datas.TglETA);
                    outgoing.NamaKurir = datas.NamaKurir;
                    outgoing.Keterangan = datas.Keterangan;
                    outgoing.StatusTransOut = 1;
                    outgoing.Operator = Username;
                    outgoing.OperatorTgl = DateTime.Now;

                    _context.StockOutgoingCetakans.Add(outgoing);
                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockOutgoingCetakan_Product product = new StockOutgoingCetakan_Product();

                        product.Idform = outgoing.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;

                        _context.StockOutgoingCetakanProducts.Add(product);
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }
        #endregion

        #region Update Stock Outgoing
        public void UpdateStockOutgoingDJ(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = MappingOutgoing(datas, Username);

            connection.Execute(dt, "dbo.sp_UpdateCrossBrandOutgoingDJ", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingOutgoingProduct(datas, datas.ID);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandOutgoingDJ_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void UpdateStockOutgoingPG(RequestStockOutgoingBRJ datas, string Username)
        {
            if (datas.BrandAsal != datas.BrandTujuan)
            {
                List<int> IDs = new List<int>();
                foreach (Product x in datas.Products)
                {
                    IDs.Add(x.ID);
                }

                if (_context.StockProductPgs.Include(p => p.CharGoldLevel).Any(p => !p.CharGoldLevel.Nama.Contains("PGE") && IDs.Contains(p.Id))) connection.Execute("exec sp_ThrowError 'List mengandung barang selain PGE'", connectionStrings.ConnectionStrings.Cnn_DB);
            }

            DataTable dt = MappingOutgoing(datas, Username);

            connection.Execute(dt, "dbo.sp_UpdateCrossBrandOutgoingPG", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingOutgoingProduct(datas, datas.ID);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandOutgoingPG_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void UpdateStockOutgoingLD(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = MappingOutgoing(datas, Username);

            connection.Execute(dt, "dbo.sp_UpdateCrossBrandOutgoingLD", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingOutgoingProduct(datas, datas.ID);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandOutgoingLD_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void UpdateStockOutgoingGJ(RequestStockOutgoingBRJ datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockOutgoingGJ outgoing = _context.StockOutgoingGjs.Include(p => p.StockOutgoingGJ_Products).SingleOrDefault(p => p.Id == datas.ID);
                    outgoing.Idbrand = datas.BrandAsal;
                    outgoing.TipeAsal = datas.TipeAsal;
                    outgoing.TipeTujuan = datas.TipeTujuan;
                    outgoing.Idasal = datas.IDAsal;
                    outgoing.Idtujuan = datas.IDTujuan;
                    outgoing.NamaAsal = datas.NamaAsal;
                    outgoing.NamaTujuan = datas.NamaTujuan;
                    outgoing.Tgl = Convert.ToDateTime(datas.Tgl);
                    outgoing.TglEta = Convert.ToDateTime(datas.TglETA);
                    outgoing.NamaKurir = datas.NamaKurir;
                    outgoing.Keterangan = datas.Keterangan;
                    outgoing.StatusTransOut = 1;
                    outgoing.Operator = Username;
                    outgoing.OperatorTgl = DateTime.Now;

                    _context.SaveChanges();

                    foreach (StockOutgoingGJ_Product x in outgoing.StockOutgoingGJ_Products)
                    {
                        _context.Remove(x);
                    }

                    _context.SaveChanges();

                    foreach (Product x in datas.Products)
                    {
                        int substorage = _context.Substorages.SingleOrDefault(p => p.Nama == x.Substorage).Id;

                        StockOutgoingGJ_Product product = new StockOutgoingGJ_Product();

                        product.Idform = outgoing.Id;
                        product.Idproduct = x.ID;
                        product.SubStorage = substorage;

                        _context.StockOutgoingGjProducts.Add(product);
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void UpdateStockOutgoingPackaging(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockOutgoingPackaging outgoing = _context.StockOutgoingPackagings.Include(p => p.StockOutgoingPackaging_Products).SingleOrDefault(p => p.Id == datas.ID);
                    outgoing.Idbrand = datas.Brand;
                    outgoing.TipeAsal = datas.TipeAsal;
                    outgoing.TipeTujuan = datas.TipeTujuan;
                    outgoing.Idasal = datas.IDAsal;
                    outgoing.Idtujuan = datas.IDTujuan;
                    outgoing.NamaAsal = datas.NamaAsal;
                    outgoing.NamaTujuan = datas.NamaTujuan;
                    outgoing.Tgl = Convert.ToDateTime(datas.Tgl);
                    outgoing.TglEta = Convert.ToDateTime(datas.TglETA);
                    outgoing.NamaKurir = datas.NamaKurir;
                    outgoing.Keterangan = datas.Keterangan;
                    outgoing.StatusTransOut = 1;
                    outgoing.Operator = Username;
                    outgoing.OperatorTgl = DateTime.Now;

                    _context.SaveChanges();

                    foreach (StockOutgoingPackaging_Product x in outgoing.StockOutgoingPackaging_Products)
                    {
                        _context.Remove(x);
                    }

                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockOutgoingPackaging_Product product = new StockOutgoingPackaging_Product();

                        product.Idform = outgoing.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;

                        _context.StockOutgoingPackagingProducts.Add(product);
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void UpdateStockOutgoingSouvenir(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockOutgoingSouvenir outgoing = _context.StockOutgoingSouvenirs.Include(p => p.StockOutgoingSouvenir_Products).SingleOrDefault(p => p.Id == datas.ID);
                    outgoing.Idbrand = datas.Brand;
                    outgoing.TipeAsal = datas.TipeAsal;
                    outgoing.TipeTujuan = datas.TipeTujuan;
                    outgoing.Idasal = datas.IDAsal;
                    outgoing.Idtujuan = datas.IDTujuan;
                    outgoing.NamaAsal = datas.NamaAsal;
                    outgoing.NamaTujuan = datas.NamaTujuan;
                    outgoing.Tgl = Convert.ToDateTime(datas.Tgl);
                    outgoing.TglEta = Convert.ToDateTime(datas.TglETA);
                    outgoing.NamaKurir = datas.NamaKurir;
                    outgoing.Keterangan = datas.Keterangan;
                    outgoing.StatusTransOut = 1;
                    outgoing.Operator = Username;
                    outgoing.OperatorTgl = DateTime.Now;

                    _context.SaveChanges();

                    foreach (StockOutgoingSouvenir_Product x in outgoing.StockOutgoingSouvenir_Products)
                    {
                        _context.Remove(x);
                    }

                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockOutgoingSouvenir_Product product = new StockOutgoingSouvenir_Product();

                        product.Idform = outgoing.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;

                        _context.StockOutgoingSouvenirProducts.Add(product);
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void UpdateStockOutgoingCetakan(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockOutgoingCetakan outgoing = _context.StockOutgoingCetakans.Include(p => p.StockOutgoingCetakan_Products).SingleOrDefault(p => p.Id == datas.ID);
                    outgoing.Idbrand = datas.Brand;
                    outgoing.TipeAsal = datas.TipeAsal;
                    outgoing.TipeTujuan = datas.TipeTujuan;
                    outgoing.Idasal = datas.IDAsal;
                    outgoing.Idtujuan = datas.IDTujuan;
                    outgoing.NamaAsal = datas.NamaAsal;
                    outgoing.NamaTujuan = datas.NamaTujuan;
                    outgoing.Tgl = Convert.ToDateTime(datas.Tgl);
                    outgoing.TglEta = Convert.ToDateTime(datas.TglETA);
                    outgoing.NamaKurir = datas.NamaKurir;
                    outgoing.Keterangan = datas.Keterangan;
                    outgoing.StatusTransOut = 1;
                    outgoing.Operator = Username;
                    outgoing.OperatorTgl = DateTime.Now;

                    _context.SaveChanges();

                    foreach (StockOutgoingCetakan_Product x in outgoing.StockOutgoingCetakan_Products)
                    {
                        _context.Remove(x);
                    }

                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockOutgoingCetakan_Product product = new StockOutgoingCetakan_Product();

                        product.Idform = outgoing.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;

                        _context.StockOutgoingCetakanProducts.Add(product);
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }
        #endregion

        #region Delete Stock Outgoing
        public void DeleteStockOutgoingDJ(int ID)
        {
            List<CrossBrand_StockOutgoingDJ_Product> dataProduct = _context.CrossBrandStockOutgoingDJProducts.Include(p => p.StockActualDJ).Where(p => p.Idform == ID).ToList();
            foreach (CrossBrand_StockOutgoingDJ_Product x in dataProduct)
            {
                x.StockActualDJ.Substorage = x.Substorage;
                x.StockActualDJ.InHand = 1;
                _context.CrossBrandStockOutgoingDJProducts.Remove(x);
            }

            CrossBrand_StockOutgoingDJ data = _context.CrossBrandStockOutgoingDJs.FirstOrDefault(p => p.Id == ID);
            _context.CrossBrandStockOutgoingDJs.Remove(data);
            _context.SaveChanges();
        }

        public void DeleteStockOutgoingPG(int ID)
        {
            List<CrossBrand_StockOutgoingPG_Product> dataProduct = _context.CrossBrandStockOutgoingPgProducts.Include(p => p.StockActualPG).Where(p => p.Idform == ID).ToList();
            foreach (CrossBrand_StockOutgoingPG_Product x in dataProduct)
            {
                x.StockActualPG.Substorage = x.Substorage;
                x.StockActualPG.InHand = 1;
                _context.CrossBrandStockOutgoingPgProducts.Remove(x);
            }
            
            CrossBrand_StockOutgoingPG data = _context.CrossBrandStockOutgoingPgs.FirstOrDefault(p => p.Id == ID);
            _context.CrossBrandStockOutgoingPgs.Remove(data);
            _context.SaveChanges();
        }

        public void DeleteStockOutgoingLD(int ID)
        {
            List<CrossBrand_StockOutgoingLD_Product> dataProduct = _context.CrossBrandStockOutgoingLDProducts.Include(p => p.StockActualLD_Stone1B).Where(p => p.Idform == ID).ToList();
            foreach (CrossBrand_StockOutgoingLD_Product x in dataProduct)
            {
                x.StockActualLD_Stone1B.Substorage = x.Substorage;
                x.StockActualLD_Stone1B.InHand = 1;
                _context.CrossBrandStockOutgoingLDProducts.Remove(x);
            }

            CrossBrand_StockOutgoingLD data = _context.CrossBrandStockOutgoingLDs.FirstOrDefault(p => p.Id == ID);
            _context.CrossBrandStockOutgoingLDs.Remove(data);
            _context.SaveChanges();
        }

        public void DeleteStockOutgoingGJ(int ID)
        {
            List<StockOutgoingGJ_Product> dataProduct = _context.StockOutgoingGjProducts.Include(p => p.StockActualGJ).Where(p => p.Idform == ID).ToList();
            foreach (StockOutgoingGJ_Product x in dataProduct)
            {
                x.StockActualGJ.Substorage = x.SubStorage;
                x.StockActualGJ.InHand = 1;
                _context.StockOutgoingGjProducts.Remove(x);
            }

            StockOutgoingGJ_Product data = _context.StockOutgoingGjProducts.FirstOrDefault(p => p.Id == ID);
            _context.StockOutgoingGjProducts.Remove(data);
            _context.SaveChanges();
        }

        public void DeleteStockOutgoingPackaging(int ID)
        {
            List<StockOutgoingPackaging_Product> dataProduct = _context.StockOutgoingPackagingProducts.Include(p => p.StockOutgoingPackaging).Where(p => p.Idform == ID).ToList();
            foreach (StockOutgoingPackaging_Product x in dataProduct)
            {
                if (x.StockOutgoingPackaging.StatusTransOut == 2)
                {
                    StockActualPackaging actual = _context.StockActualPackagings.SingleOrDefault(p => p.Idlokasi == x.StockOutgoingPackaging.Idasal && p.TipeLokasi == x.StockOutgoingPackaging.TipeAsal && p.Idproduct == x.Idproduct);
                    actual.InHand += (decimal)x.Qty;
                    actual.InTransit -= (decimal)x.Qty;
                }
                _context.StockOutgoingPackagingProducts.Remove(x);
            }

            StockOutgoingPackaging data = _context.StockOutgoingPackagings.FirstOrDefault(p => p.Id == ID);
            _context.StockOutgoingPackagings.Remove(data);
            _context.SaveChanges();
        }

        public void DeleteStockOutgoingSouvenir(int ID)
        {
            List<StockOutgoingSouvenir_Product> dataProduct = _context.StockOutgoingSouvenirProducts.Include(p => p.StockOutgoingSouvenir).Where(p => p.Idform == ID).ToList();
            foreach (StockOutgoingSouvenir_Product x in dataProduct)
            {
                if (x.StockOutgoingSouvenir.StatusTransOut == 2)
                {
                    StockActualSouvenir actual = _context.StockActualSouvenirs.SingleOrDefault(p => p.Idlokasi == x.StockOutgoingSouvenir.Idasal && p.TipeLokasi == x.StockOutgoingSouvenir.TipeAsal && p.Idproduct == x.Idproduct);
                    actual.InHand += (decimal)x.Qty;
                    actual.InTransit -= (decimal)x.Qty;
                }
                _context.StockOutgoingSouvenirProducts.Remove(x);
            }

            StockOutgoingSouvenir data = _context.StockOutgoingSouvenirs.FirstOrDefault(p => p.Id == ID);
            _context.StockOutgoingSouvenirs.Remove(data);
            _context.SaveChanges();
        }

        public void DeleteStockOutgoingCetakan(int ID)
        {
            List<StockOutgoingCetakan_Product> dataProduct = _context.StockOutgoingCetakanProducts.Include(p => p.StockOutgoingCetakan).Where(p => p.Idform == ID).ToList();
            foreach (StockOutgoingCetakan_Product x in dataProduct)
            {
                if (x.StockOutgoingCetakan.StatusTransOut == 2)
                {
                    StockActualCetakan actual = _context.StockActualCetakans.SingleOrDefault(p => p.Idlokasi == x.StockOutgoingCetakan.Idasal && p.TipeLokasi == x.StockOutgoingCetakan.TipeAsal && p.Idproduct == x.Idproduct);
                    actual.InHand += (decimal)x.Qty;
                    actual.InTransit -= (decimal)x.Qty;
                }
                _context.StockOutgoingCetakanProducts.Remove(x);
            }

            StockOutgoingCetakan data = _context.StockOutgoingCetakans.FirstOrDefault(p => p.Id == ID);
            _context.StockOutgoingCetakans.Remove(data);
            _context.SaveChanges();
        }
        #endregion

        #region Approval Stock Outgoing
        public void ApprovalOutgoingDJ(int ID, string Username)
        {
            //Approval Outgoing
            var outgoing = _context.CrossBrandStockOutgoingDJs.SingleOrDefault(p => p.Id == ID);
            outgoing.Nomor = generateDocumentNumber("DJ");
            outgoing.StatusTransOut = 2;
            outgoing.Approval = Username;
            outgoing.ApprovalTgl = DateTime.Now;

            _context.SaveChanges();

            //Update Actual insert
            connection.Execute("EXEC sp_UpdateCrossBrandOutgoingDJ_ActualLedger " + ID, connectionStrings.ConnectionStrings.Cnn_DB);

        }

        public void ApprovalOutgoingPG(int ID, string Username)
        {
            //Approval Outgoing
            var outgoing = _context.CrossBrandStockOutgoingPgs.SingleOrDefault(p => p.Id == ID);
            outgoing.Nomor = generateDocumentNumber("PG");
            outgoing.StatusTransOut = 2;
            outgoing.Approval = Username;
            outgoing.ApprovalTgl = DateTime.Now;

            _context.SaveChanges();

            //Update Actual insert
            connection.Execute("EXEC sp_UpdateCrossBrandOutgoingPG_ActualLedger " + ID, connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void ApprovalOutgoingLD(int ID, string Username)
        {
            var outgoing = _context.CrossBrandStockOutgoingLDs.SingleOrDefault(p => p.Id == ID);
            outgoing.Nomor = generateDocumentNumber("LD");
            outgoing.StatusTransOut = 2;
            outgoing.Approval = Username;
            outgoing.ApprovalTgl = DateTime.Now;

            _context.SaveChanges();

            //Update Actual insert
            connection.Execute("EXEC sp_UpdateCrossBrandOutgoingLD_ActualLedger " + ID, connectionStrings.ConnectionStrings.Cnn_DB);
        }
        public void ApprovalOutgoingGJ(int ID, string Username)
        {
            var outgoing = _context.StockOutgoingGjs.Include(p => p.StockOutgoingGJ_Products).SingleOrDefault(p => p.Id == ID);
            outgoing.Nomor = generateDocumentNumber("GJ");
            outgoing.StatusTransOut = 2;
            outgoing.Approval = Username;
            outgoing.ApprovalTgl = DateTime.Now;

            _context.SaveChanges();

            //Update Actual insert
            connection.Execute("EXEC sp_UpdateCrossBrandOutgoingGJ_ActualLedger " + ID, connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void ApprovalOutgoingPackaging(int ID, string Username)
        {
            var outgoing = _context.StockOutgoingPackagings.Include(p => p.StockOutgoingPackaging_Products).SingleOrDefault(p => p.Id == ID);
            outgoing.Nomor = generateDocumentNumber("PC");
            outgoing.StatusTransOut = 2;
            outgoing.Approval = Username;
            outgoing.ApprovalTgl = DateTime.Now;

            _context.SaveChanges();

            //Update Actual insert
            connection.Execute("EXEC sp_UpdateOutgoingPackaging_ActualLedger " + ID, connectionStrings.ConnectionStrings.Cnn_DB);
        }
        public void ApprovalOutgoingSouvenir(int ID, string Username)
        {
            var outgoing = _context.StockOutgoingSouvenirs.Include(p => p.StockOutgoingSouvenir_Products).SingleOrDefault(p => p.Id == ID);
            outgoing.Nomor = generateDocumentNumber("SV");
            outgoing.StatusTransOut = 2;
            outgoing.Approval = Username;
            outgoing.ApprovalTgl = DateTime.Now;

            _context.SaveChanges();

            //Update Actual insert
            connection.Execute("EXEC sp_UpdateOutgoingSouvenir_ActualLedger " + ID, connectionStrings.ConnectionStrings.Cnn_DB);
        }
        public void ApprovalOutgoingCetakan(int ID, string Username)
        {
            var outgoing = _context.StockOutgoingCetakans.Include(p => p.StockOutgoingCetakan_Products).SingleOrDefault(p => p.Id == ID);
            outgoing.Nomor = generateDocumentNumber("SV");
            outgoing.StatusTransOut = 2;
            outgoing.Approval = Username;
            outgoing.ApprovalTgl = DateTime.Now;

            _context.SaveChanges();

            //Update Actual insert
            connection.Execute("EXEC sp_UpdateOutgoingCetakan_ActualLedger " + ID, connectionStrings.ConnectionStrings.Cnn_DB);
        }
        #endregion

        public object GetCertificate(int ID, bool isCrossBrand)
        {
            List<object> datas = new List<object>();
            if (isCrossBrand)
            {
                var outgoing = _context.CrossBrandStockOutgoingDJProducts.Where(p => p.Idform == ID)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_Stone1As)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_Stone1Bs)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_Stone2s)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_Stone3s)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharProductItem);


                foreach (CrossBrand_StockOutgoingDJ_Product x in outgoing)
                {
                    if (x.StockProductDJ.StockProductDJ_Stone1As.Any(p => !string.IsNullOrEmpty(p.CertificateNumber)))
                    {
                        foreach (StockProductDJ_Stone1A y in x.StockProductDJ.StockProductDJ_Stone1As.Where(p => !string.IsNullOrEmpty(p.CertificateNumber)))
                        {
                            datas.Add(new
                            {
                                PLU = x.StockProductDJ.Nomor,
                                CertificateNumber = y.CertificateNumber,
                                ProductItem = x.StockProductDJ.StockProductDJ_CharProduct.CharProductItem.Nama
                            });
                        }
                    }

                    if (x.StockProductDJ.StockProductDJ_Stone1Bs.Any(p => !string.IsNullOrEmpty(p.Gia)))
                    {
                        foreach (StockProductDJ_Stone1B y in x.StockProductDJ.StockProductDJ_Stone1Bs.Where(p => !string.IsNullOrEmpty(p.Gia)))
                        {
                            datas.Add(new
                            {
                                PLU = x.StockProductDJ.Nomor,
                                CertificateNumber = y.Gia,
                                ProductItem = x.StockProductDJ.StockProductDJ_CharProduct.CharProductItem.Nama
                            });
                        }
                    }

                    if (x.StockProductDJ.StockProductDJ_Stone2s.Any(p => !string.IsNullOrEmpty(p.Gia)))
                    {
                        foreach (StockProductDJ_Stone2 y in x.StockProductDJ.StockProductDJ_Stone2s.Where(p => !string.IsNullOrEmpty(p.Gia)))
                        {
                            datas.Add(new
                            {
                                PLU = x.StockProductDJ.Nomor,
                                CertificateNumber = y.Gia,
                                ProductItem = x.StockProductDJ.StockProductDJ_CharProduct.CharProductItem.Nama
                            });
                        }
                    }

                    if (x.StockProductDJ.StockProductDJ_Stone3s.Any(p => !string.IsNullOrEmpty(p.Gia)))
                    {
                        foreach (StockProductDJ_Stone3 y in x.StockProductDJ.StockProductDJ_Stone3s.Where(p => !string.IsNullOrEmpty(p.Gia)))
                        {
                            datas.Add(new
                            {
                                PLU = x.StockProductDJ.Nomor,
                                CertificateNumber = y.Gia,
                                ProductItem = x.StockProductDJ.StockProductDJ_CharProduct.CharProductItem.Nama
                            });
                        }
                    }
                }
            }
            else 
            {
                var outgoing = _context.StockOutgoingDjProducts.Where(p => p.Idform == ID)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_Stone1As)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_Stone1Bs)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_Stone2s)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_Stone3s)
                    .Include(p => p.StockProductDJ).ThenInclude(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharProductItem);


                foreach(StockOutgoingDJ_Product x in outgoing)
                {
                    if(x.StockProductDJ.StockProductDJ_Stone1As.Any(p => !string.IsNullOrEmpty(p.CertificateNumber)))
                    {
                        foreach(StockProductDJ_Stone1A y in x.StockProductDJ.StockProductDJ_Stone1As.Where(p => !string.IsNullOrEmpty(p.CertificateNumber)))
                        {
                            datas.Add(new
                            {
                                PLU = x.StockProductDJ.Nomor,
                                CertificateNumber = y.CertificateNumber,
                                ProductItem = x.StockProductDJ.StockProductDJ_CharProduct.CharProductItem.Nama
                            });
                        }
                    }

                    if (x.StockProductDJ.StockProductDJ_Stone1Bs.Any(p => !string.IsNullOrEmpty(p.Gia)))
                    {
                        foreach (StockProductDJ_Stone1B y in x.StockProductDJ.StockProductDJ_Stone1Bs.Where(p => !string.IsNullOrEmpty(p.Gia)))
                        {
                            datas.Add(new
                            {
                                PLU = x.StockProductDJ.Nomor,
                                CertificateNumber = y.Gia,
                                ProductItem = x.StockProductDJ.StockProductDJ_CharProduct.CharProductItem.Nama
                            });
                        }
                    }

                    if (x.StockProductDJ.StockProductDJ_Stone2s.Any(p => !string.IsNullOrEmpty(p.Gia)))
                    {
                        foreach (StockProductDJ_Stone2 y in x.StockProductDJ.StockProductDJ_Stone2s.Where(p => !string.IsNullOrEmpty(p.Gia)))
                        {
                            datas.Add(new
                            {
                                PLU = x.StockProductDJ.Nomor,
                                CertificateNumber = y.Gia,
                                ProductItem = x.StockProductDJ.StockProductDJ_CharProduct.CharProductItem.Nama
                            });
                        }
                    }

                    if (x.StockProductDJ.StockProductDJ_Stone3s.Any(p => !string.IsNullOrEmpty(p.Gia)))
                    {
                        foreach (StockProductDJ_Stone3 y in x.StockProductDJ.StockProductDJ_Stone3s.Where(p => !string.IsNullOrEmpty(p.Gia)))
                        {
                            datas.Add(new
                            {
                                PLU = x.StockProductDJ.Nomor,
                                CertificateNumber = y.Gia,
                                ProductItem = x.StockProductDJ.StockProductDJ_CharProduct.CharProductItem.Nama
                            });
                        }
                    }
                }

            }
            return datas;
        }

        private DataTable MappingOutgoing(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("IDBrandAsal", typeof(int));
            dt.Columns.Add("IDBrandTujuan", typeof(int));
            dt.Columns.Add("Nomor", typeof(string));
            dt.Columns.Add("NamaKurir", typeof(string));
            dt.Columns.Add("TglETA", typeof(DateTime));
            dt.Columns.Add("TipeAsal", typeof(int));
            dt.Columns.Add("TipeTujuan", typeof(int));
            dt.Columns.Add("NamaAsal", typeof(string));
            dt.Columns.Add("NamaTujuan", typeof(string));
            dt.Columns.Add("IDAsal", typeof(int));
            dt.Columns.Add("IDTujuan", typeof(int));
            dt.Columns.Add("Keterangan", typeof(string));
            dt.Columns.Add("Tgl", typeof(DateTime));
            dt.Columns.Add("StatusTransOut", typeof(int));
            dt.Columns.Add("Operator", typeof(string));
            dt.Columns.Add("OperatorTgl", typeof(DateTime));
            dt.Columns.Add("Approval", typeof(string));
            dt.Columns.Add("ApprovalTgl", typeof(DateTime));

            DataRow dr = dt.NewRow();

            dr["ID"] = datas.ID;
            dr["IDBrandAsal"] = datas.BrandAsal;
            dr["IDBrandTujuan"] = datas.BrandTujuan;
            dr["NamaKurir"] = datas.NamaKurir;
            dr["TglETA"] = Convert.ToDateTime(datas.TglETA);
            dr["TipeAsal"] = datas.TipeAsal;
            dr["TipeTujuan"] = datas.TipeTujuan;
            dr["NamaAsal"] = datas.NamaAsal;
            dr["NamaTujuan"] = datas.NamaTujuan;
            dr["IDAsal"] = datas.IDAsal;
            dr["IDTujuan"] = datas.IDTujuan;
            dr["Keterangan"] = datas.Keterangan;
            dr["Tgl"] = Convert.ToDateTime(datas.Tgl);
            dr["StatusTransOut"] = 1;
            dr["Operator"] = Username;
            dr["OperatorTgl"] = DateTime.Now;
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable MappingOutgoingProduct(RequestStockOutgoingBRJ datas, int IDForm)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("IDForm", typeof(int));
            dt.Columns.Add("IDProduct", typeof(int));
            dt.Columns.Add("Nomor", typeof(string));
            dt.Columns.Add("Substorage", typeof(int));

            foreach (Product x in datas.Products)
            {
                DataRow dr = dt.NewRow();

                int substorage = _context.Substorages.SingleOrDefault(p => p.Nama == x.Substorage).Id;

                dr["IDForm"] = IDForm;
                dr["IDProduct"] = x.ID;
                dr["Nomor"] = x.Nomor;
                dr["Substorage"] = substorage;

                dt.Rows.Add(dr);
            }

            return dt;
        }

        private string generateDocumentNumber(string Tipe)
        {
            string result = "";
            string v1 = "KRM/" + common.KodeBrand() + "/" + Tipe;
            string v2 = System.DateTime.Now.Year.ToString().Substring(2, 2);
            string v3 = System.DateTime.Now.Month.ToString().PadLeft(2, '0');
            string v4 = "0001";

            if (Tipe == "DJ")
            {
                var rs = _context.CrossBrandStockOutgoingDJs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "PG")
            {
                var rs = _context.CrossBrandStockOutgoingPgs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "LD")
            {
                var rs = _context.CrossBrandStockOutgoingLDs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "GJ")
            {
                var rs = _context.StockOutgoingGjs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "PC")
            {
                var rs = _context.StockOutgoingPackagings.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "SV")
            {
                var rs = _context.StockOutgoingSouvenirs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            return result;
        }


    }
}
