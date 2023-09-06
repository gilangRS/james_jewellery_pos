using Connection.Interface;
using Connection.Models;
using Connection.RequestModels.StockTransfer;
using Connection.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Connection.Repositories
{
    public class StockIncomingRepository : IStockIncomingRepository
    {
        private readonly JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;
        private Common common;
        public StockIncomingRepository()
        {
            common = new Common();
            _context = new JAWSDbContext();
            this.connectionStrings = new ConnectionString();
        }

        #region Get Stock Incoming
        public List<object> GetStockOutgoingDJ(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor)
        {
            List<object> datas = new List<object>();

            From = "1900-01-01";

            string query = "exec sp_StockOutgoingDJ_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + BrandTujuan + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", 2";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["IsCrossBrand"]) && row["IDOutgoing"].ToString() == "")
                    {
                        datas.Add(new
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            NomorOutgoing = row["NomorOutgoing"].ToString(),
                            NamaAsal = row["NamaAsal"].ToString(),
                            NamaTujuan = row["NamaTujuan"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"])
                        });
                    }
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingPG(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor)
        {
            List<object> datas = new List<object>();
            From = "1900-01-01";

            string query = "exec sp_StockOutgoingPG_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + BrandTujuan + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", 2";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["IsCrossBrand"]) && row["IDOutgoing"].ToString() == "")
                    {
                        datas.Add(new
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            NomorOutgoing = row["NomorOutgoing"].ToString(),
                            NamaAsal = row["NamaAsal"].ToString(),
                            NamaTujuan = row["NamaTujuan"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"])
                        });
                    }
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingLD(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor)
        {
            List<object> datas = new List<object>();
            From = "1900-01-01";

            string query = "exec sp_StockOutgoingLD_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + BrandTujuan + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", 2";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["IsCrossBrand"]) && row["IDOutgoing"].ToString() == "")
                    {
                        datas.Add(new
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            NomorOutgoing = row["NomorOutgoing"].ToString(),
                            NamaAsal = row["NamaAsal"].ToString(),
                            NamaTujuan = row["NamaTujuan"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"])
                        });
                    }
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingGJ(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor)
        {
            List<object> datas = new List<object>();
            From = "1900-01-01";

            string query = "exec sp_StockOutgoingGJ_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", 2";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["IDOutgoing"].ToString() == "")
                    {
                        datas.Add(new
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            NomorOutgoing = row["NomorOutgoing"].ToString(),
                            NamaAsal = row["NamaAsal"].ToString(),
                            NamaTujuan = row["NamaTujuan"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"])
                        });
                    }
                }
            }

            return datas;
        }
        public List<object> GetStockOutgoingPackaging(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor)
        {
            List<object> datas = new List<object>();
            From = "1900-01-01";

            string query = "exec sp_StockOutgoingPackaging_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", 2";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["IDOutgoing"].ToString() == "")
                    {
                        datas.Add(new
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            NomorOutgoing = row["NomorOutgoing"].ToString(),
                            NamaAsal = row["NamaAsal"].ToString(),
                            NamaTujuan = row["NamaTujuan"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"])
                        });
                    }
                }
            }

            return datas;
        }
        public List<object> GetStockOutgoingSouvenir(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor)
        {
            List<object> datas = new List<object>();
            From = "1900-01-01";

            string query = "exec sp_StockOutgoingSouvenir_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", 2";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["IDOutgoing"].ToString() == "")
                    {
                        datas.Add(new
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            NomorOutgoing = row["NomorOutgoing"].ToString(),
                            NamaAsal = row["NamaAsal"].ToString(),
                            NamaTujuan = row["NamaTujuan"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"])
                        });
                    }
                }
            }

            return datas;
        }

        public List<object> GetStockOutgoingCetakan(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, string Nomor)
        {
            List<object> datas = new List<object>();
            From = "1900-01-01";

            string query = "exec sp_StockOutgoingCetakan_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", 2";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["IDOutgoing"].ToString() == "")
                    {
                        datas.Add(new
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            NomorOutgoing = row["NomorOutgoing"].ToString(),
                            NamaAsal = row["NamaAsal"].ToString(),
                            NamaTujuan = row["NamaTujuan"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"])
                        });
                    }
                }
            }

            return datas;
        }

        public List<object> GetStockIncomingDJ(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingDJ_List '"
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
                        NomorIncoming = row["NomorIncoming"].ToString(),
                        IsCrossBrand = Convert.ToBoolean(row["IsCrossBrand"]),
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

        public List<object> GetStockIncomingPG(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingPG_List '"
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
                        NomorIncoming = row["NomorIncoming"].ToString(),
                        IsCrossBrand = Convert.ToBoolean(row["IsCrossBrand"]),
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

        public List<object> GetStockIncomingLD(string From, string To, int BrandAsal, int BrandTujuan, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingLD_List '"
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
                        NomorIncoming = row["NomorIncoming"].ToString(),
                        IsCrossBrand = Convert.ToBoolean(row["IsCrossBrand"]),
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
        public List<object> GetStockIncomingGJ(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingGJ_List '"
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
                        NomorIncoming = row["NomorIncoming"].ToString(),
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
        public List<object> GetStockIncomingPackaging(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingPackaging_List '"
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
                        NomorIncoming = row["NomorIncoming"].ToString(),
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
        public List<object> GetStockIncomingPackagingDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, int IDProduct)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingPackagingDetail_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status + ", "
                + IDProduct;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorIncoming = row["NomorIncoming"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        IDStatus = Convert.ToInt32(row["IDStatus"]),
                        Kode = row["Kode"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Received = Convert.ToInt32(row["Received"]),
                        Damaged = Convert.ToInt32(row["Damaged"]),
                        NeverArrived = Convert.ToInt32(row["NeverArrived"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                    });
                }
            }

            return datas;
        }
        public List<object> GetStockIncomingSouvenir(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingSouvenir_List '"
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
                        NomorIncoming = row["NomorIncoming"].ToString(),
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
        public List<object> GetStockIncomingSouvenirDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, int IDProduct)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingSouvenirDetail_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status + ", "
                + IDProduct;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorIncoming = row["NomorIncoming"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        IDStatus = Convert.ToInt32(row["IDStatus"]),
                        Kode = row["Kode"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Received = Convert.ToInt32(row["Received"]),
                        Damaged = Convert.ToInt32(row["Damaged"]),
                        NeverArrived = Convert.ToInt32(row["NeverArrived"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                    });
                }
            }

            return datas;
        }
        public List<object> GetStockIncomingCetakan(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, bool IsApproval)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingCetakan_List '"
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
                        NomorIncoming = row["NomorIncoming"].ToString(),
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
        public List<object> GetStockIncomingCetakanDetailList(string From, string To, int BrandAsal, int TipeAsal, int TipeTujuan, int IDAsal, int IDTujuan, int Status, string Nomor, int IDProduct)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingCetakanDetail_List '"
                + Nomor + "', '"
                + From + "', '"
                + To + "', "
                + BrandAsal + ", "
                + IDAsal + ", "
                + IDTujuan + ", "
                + TipeAsal + ", "
                + TipeTujuan + ", "
                + Status + ", "
                + IDProduct;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NomorIncoming = row["NomorIncoming"].ToString(),
                        NamaAsal = row["NamaAsal"].ToString(),
                        NamaTujuan = row["NamaTujuan"].ToString(),
                        Status = row["Status"].ToString(),
                        IDStatus = Convert.ToInt32(row["IDStatus"]),
                        Kode = row["Kode"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Received = Convert.ToInt32(row["Received"]),
                        Damaged = Convert.ToInt32(row["Damaged"]),
                        NeverArrived = Convert.ToInt32(row["NeverArrived"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                    });
                }
            }

            return datas;
        }
        public object GetStockIncomingDJDetail(int ID, int isCrossBrand)
        {
            object data = new object();
            object incoming = new object();

            if (isCrossBrand == 1)
            {
                var singleOutgoing = _context.CrossBrandStockIncomingDJs
                    .Include(p => p.CrossBrand_StockOutgoingDJ)
                    .ThenInclude(p => p.BrandAsal)
                    .Include(p => p.CrossBrand_StockOutgoingDJ)
                    .ThenInclude(p => p.BrandTujuan)
                    .Where(p => p.Id == ID);

                incoming = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.CrossBrand_StockOutgoingDJ.BrandAsal.Nama,
                                IDBrandAsal = a.CrossBrand_StockOutgoingDJ.IdbrandAsal,
                                BrandTujuan = a.CrossBrand_StockOutgoingDJ.BrandTujuan.Nama,
                                IDBrandTujuan = a.CrossBrand_StockOutgoingDJ.IdbrandTujuan,
                                TipeAsal = a.CrossBrand_StockOutgoingDJ.TipeAsal,
                                TIpeTujuan = a.CrossBrand_StockOutgoingDJ.TipeTujuan,
                                LokasiAsal = a.CrossBrand_StockOutgoingDJ.NamaAsal,
                                IDAsal = a.CrossBrand_StockOutgoingDJ.Idasal,
                                LokasiTujuan = a.CrossBrand_StockOutgoingDJ.NamaTujuan,
                                IDTujuan = a.CrossBrand_StockOutgoingDJ.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.CrossBrand_StockOutgoingDJ.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }
            else 
            {
                var singleOutgoing = _context.StockIncomingDjs
                    .Include(p => p.StockOutgoingDJ)
                    .ThenInclude(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

                incoming = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.StockOutgoingDJ.CompanyBrand.Nama,
                                IDBrandAsal = a.StockOutgoingDJ.Idbrand,
                                BrandTujuan = a.StockOutgoingDJ.CompanyBrand.Nama,
                                IDBrandTujuan = a.StockOutgoingDJ.Idbrand,
                                TipeAsal = a.StockOutgoingDJ.TipeAsal,
                                TIpeTujuan = a.StockOutgoingDJ.TipeTujuan,
                                LokasiAsal = a.StockOutgoingDJ.NamaAsal,
                                IDAsal = a.StockOutgoingDJ.Idasal,
                                LokasiTujuan = a.StockOutgoingDJ.NamaTujuan,
                                IDTujuan = a.StockOutgoingDJ.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.StockOutgoingDJ.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }

            data = new
            {
                incoming,
                product = GetStockIncomingDJProduct(ID, isCrossBrand)
            };
            return data;
        }

        private List<object> GetStockIncomingDJProduct(int ID, int isCrossBrand)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingDJ_Detail "
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

        public object GetStockIncomingPGDetail(int ID, int isCrossBrand)
        {
            object data = new object();
            object incoming = new object();

            if (isCrossBrand == 1)
            {
                var singleOutgoing = _context.CrossBrandStockIncomingPgs
                    .Include(p => p.CrossBrand_StockOutgoingPG)
                    .ThenInclude(p => p.BrandAsal)
                    .Include(p => p.CrossBrand_StockOutgoingPG)
                    .ThenInclude(p => p.BrandTujuan)
                    .Where(p => p.Id == ID);

                incoming = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.CrossBrand_StockOutgoingPG.BrandAsal.Nama,
                                IDBrandAsal = a.CrossBrand_StockOutgoingPG.IdbrandAsal,
                                BrandTujuan = a.CrossBrand_StockOutgoingPG.BrandTujuan.Nama,
                                IDBrandTujuan = a.CrossBrand_StockOutgoingPG.IdbrandTujuan,
                                TipeAsal = a.CrossBrand_StockOutgoingPG.TipeAsal,
                                TIpeTujuan = a.CrossBrand_StockOutgoingPG.TipeTujuan,
                                LokasiAsal = a.CrossBrand_StockOutgoingPG.NamaAsal,
                                IDAsal = a.CrossBrand_StockOutgoingPG.Idasal,
                                LokasiTujuan = a.CrossBrand_StockOutgoingPG.NamaTujuan,
                                IDTujuan = a.CrossBrand_StockOutgoingPG.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.CrossBrand_StockOutgoingPG.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }
            else
            {
                var singleOutgoing = _context.StockIncomingPgs
                    .Include(p => p.StockOutgoingPG)
                    .ThenInclude(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

                incoming = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.StockOutgoingPG.CompanyBrand.Nama,
                                IDBrandAsal = a.StockOutgoingPG.Idbrand,
                                BrandTujuan = a.StockOutgoingPG.CompanyBrand.Nama,
                                IDBrandTujuan = a.StockOutgoingPG.Idbrand,
                                TipeAsal = a.StockOutgoingPG.TipeAsal,
                                TIpeTujuan = a.StockOutgoingPG.TipeTujuan,
                                LokasiAsal = a.StockOutgoingPG.NamaAsal,
                                IDAsal = a.StockOutgoingPG.Idasal,
                                LokasiTujuan = a.StockOutgoingPG.NamaTujuan,
                                IDTujuan = a.StockOutgoingPG.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.StockOutgoingPG.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }

            data = new
            {
                incoming,
                product = GetStockIncomingPGProduct(ID, isCrossBrand)
            };
            return data;
        }


        private List<object> GetStockIncomingPGProduct(int ID, int isCrossBrand)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingPG_Detail "
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

        public object GetStockIncomingLDDetail(int ID, int isCrossBrand)
        {
            object data = new object();
            object incoming = new object();

            if (isCrossBrand == 1)
            {
                var singleOutgoing = _context.CrossBrandStockIncomingLDs
                    .Include(p => p.CrossBrand_StockOutgoingLD)
                    .ThenInclude(p => p.BrandAsal)
                    .Include(p => p.CrossBrand_StockOutgoingLD)
                    .ThenInclude(p => p.BrandTujuan)
                    .Where(p => p.Id == ID);

                incoming = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.CrossBrand_StockOutgoingLD.BrandAsal.Nama,
                                IDBrandAsal = a.CrossBrand_StockOutgoingLD.IdbrandAsal,
                                BrandTujuan = a.CrossBrand_StockOutgoingLD.BrandTujuan.Nama,
                                IDBrandTujuan = a.CrossBrand_StockOutgoingLD.IdbrandTujuan,
                                TipeAsal = a.CrossBrand_StockOutgoingLD.TipeAsal,
                                TIpeTujuan = a.CrossBrand_StockOutgoingLD.TipeTujuan,
                                LokasiAsal = a.CrossBrand_StockOutgoingLD.NamaAsal,
                                IDAsal = a.CrossBrand_StockOutgoingLD.Idasal,
                                LokasiTujuan = a.CrossBrand_StockOutgoingLD.NamaTujuan,
                                IDTujuan = a.CrossBrand_StockOutgoingLD.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.CrossBrand_StockOutgoingLD.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }
            else
            {
                var singleOutgoing = _context.StockIncomingLds
                    .Include(p => p.StockOutgoingLD)
                    .ThenInclude(p => p.CompanyBrand)
                    .Where(p => p.Id == ID);

                incoming = (from a in singleOutgoing
                            select new
                            {
                                ID = a.Id,
                                BrandAsal = a.StockOutgoingLD.CompanyBrand.Nama,
                                IDBrandAsal = a.StockOutgoingLD.Idbrand,
                                BrandTujuan = a.StockOutgoingLD.CompanyBrand.Nama,
                                IDBrandTujuan = a.StockOutgoingLD.Idbrand,
                                TipeAsal = a.StockOutgoingLD.TipeAsal,
                                TIpeTujuan = a.StockOutgoingLD.TipeTujuan,
                                LokasiAsal = a.StockOutgoingLD.NamaAsal,
                                IDAsal = a.StockOutgoingLD.Idasal,
                                LokasiTujuan = a.StockOutgoingLD.NamaTujuan,
                                IDTujuan = a.StockOutgoingLD.Idtujuan,
                                Nomor = a.Nomor,
                                Kurir = a.StockOutgoingLD.NamaKurir,
                                Description = a.Keterangan,
                                ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                            }).SingleOrDefault();
            }

            data = new
            {
                incoming,
                product = GetStockIncomingLDProduct(ID, isCrossBrand)
            };
            return data;
        }

        private List<object> GetStockIncomingLDProduct(int ID, int isCrossBrand)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingLD_Detail "
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
                        TotalButir = Convert.ToDecimal(row["TotalButir"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        HargaRupiah = Convert.ToDecimal(row["HargaTotal"]),
                        Substorage = row["Substorage"].ToString()
                    });
                }
            }

            return datas;
        }

        public object GetStockIncomingGJDetail(int ID)
        {
            object data = new object();
            object incoming = new object();

            var singleOutgoing = _context.StockIncomingGjs
                .Include(p => p.StockOutgoingGJ)
                .ThenInclude(p => p.CompanyBrand)
                .Where(p => p.Id == ID);

            incoming = (from a in singleOutgoing
                        select new
                        {
                            ID = a.Id,
                            BrandAsal = a.StockOutgoingGJ.CompanyBrand.Nama,
                            IDBrandAsal = a.StockOutgoingGJ.Idbrand,
                            BrandTujuan = a.StockOutgoingGJ.CompanyBrand.Nama,
                            IDBrandTujuan = a.StockOutgoingGJ.Idbrand,
                            TipeAsal = a.StockOutgoingGJ.TipeAsal,
                            TIpeTujuan = a.StockOutgoingGJ.TipeTujuan,
                            LokasiAsal = a.StockOutgoingGJ.NamaAsal,
                            IDAsal = a.StockOutgoingGJ.Idasal,
                            LokasiTujuan = a.StockOutgoingGJ.NamaTujuan,
                            IDTujuan = a.StockOutgoingGJ.Idtujuan,
                            Nomor = a.Nomor,
                            Kurir = a.StockOutgoingGJ.NamaKurir,
                            Description = a.Keterangan,
                            ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                        }).SingleOrDefault();
            

            data = new
            {
                incoming,
                product = GetStockIncomingGJProduct(ID)
            };
            return data;
        }

        private List<object> GetStockIncomingGJProduct(int ID)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingGJ_Detail "
                + ID;

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

        public object GetStockIncomingPackagingDetail(int ID)
        {
            object data = new object();
            object incoming = new object();

            var singleOutgoing = _context.StockIncomingPackagings
                .Include(p => p.StockOutgoingPackaging)
                .ThenInclude(p => p.CompanyBrand)
                .Where(p => p.Id == ID);

            incoming = (from a in singleOutgoing
                        select new
                        {
                            ID = a.Id,
                            BrandAsal = a.StockOutgoingPackaging.CompanyBrand.Nama,
                            IDBrandAsal = a.StockOutgoingPackaging.Idbrand,
                            BrandTujuan = a.StockOutgoingPackaging.CompanyBrand.Nama,
                            IDBrandTujuan = a.StockOutgoingPackaging.Idbrand,
                            TipeAsal = a.StockOutgoingPackaging.TipeAsal,
                            TIpeTujuan = a.StockOutgoingPackaging.TipeTujuan,
                            LokasiAsal = a.StockOutgoingPackaging.NamaAsal,
                            IDAsal = a.StockOutgoingPackaging.Idasal,
                            LokasiTujuan = a.StockOutgoingPackaging.NamaTujuan,
                            IDTujuan = a.StockOutgoingPackaging.Idtujuan,
                            Nomor = a.Nomor,
                            Kurir = a.StockOutgoingPackaging.NamaKurir,
                            Description = a.Keterangan,
                            ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                        }).SingleOrDefault();

            data = new
            {
                incoming,
                product = GetStockIncomingPackagingProduct(ID)
            };
            return data;
        }

        private List<object> GetStockIncomingPackagingProduct(int ID)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingPackaging_Detail " + ID;

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
                        Qty = Convert.ToInt32(row["Qty"]),
                        Receive = Convert.ToInt32(row["Receive"]),
                        Damaged = Convert.ToInt32(row["Damaged"]),
                        NeverArrived = Convert.ToInt32(row["NeverArrived"])
                    });
                }
            }

            return datas;
        }

        public object GetStockIncomingSouvenirDetail(int ID)
        {
            object data = new object();
            object incoming = new object();

            var singleOutgoing = _context.StockIncomingSouvenirs
                .Include(p => p.StockOutgoingSouvenir)
                .ThenInclude(p => p.CompanyBrand)
                .Where(p => p.Id == ID);

            incoming = (from a in singleOutgoing
                        select new
                        {
                            ID = a.Id,
                            BrandAsal = a.StockOutgoingSouvenir.CompanyBrand.Nama,
                            IDBrandAsal = a.StockOutgoingSouvenir.Idbrand,
                            BrandTujuan = a.StockOutgoingSouvenir.CompanyBrand.Nama,
                            IDBrandTujuan = a.StockOutgoingSouvenir.Idbrand,
                            TipeAsal = a.StockOutgoingSouvenir.TipeAsal,
                            TIpeTujuan = a.StockOutgoingSouvenir.TipeTujuan,
                            LokasiAsal = a.StockOutgoingSouvenir.NamaAsal,
                            IDAsal = a.StockOutgoingSouvenir.Idasal,
                            LokasiTujuan = a.StockOutgoingSouvenir.NamaTujuan,
                            IDTujuan = a.StockOutgoingSouvenir.Idtujuan,
                            Nomor = a.Nomor,
                            Kurir = a.StockOutgoingSouvenir.NamaKurir,
                            Description = a.Keterangan,
                            ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                        }).SingleOrDefault();

            data = new
            {
                incoming,
                product = GetStockIncomingSouvenirProduct(ID)
            };
            return data;
        }

        private List<object> GetStockIncomingSouvenirProduct(int ID)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingSouvenir_Detail " + ID;

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
                        Qty = Convert.ToInt32(row["Qty"]),
                        Receive = Convert.ToInt32(row["Receive"]),
                        Damaged = Convert.ToInt32(row["Damaged"]),
                        NeverArrived = Convert.ToInt32(row["NeverArrived"])
                    });
                }
            }

            return datas;
        }

        public object GetStockIncomingCetakanDetail(int ID)
        {
            object data = new object();
            object incoming = new object();

            var singleOutgoing = _context.StockIncomingCetakans
                .Include(p => p.StockOutgoingCetakan)
                .ThenInclude(p => p.CompanyBrand)
                .Where(p => p.Id == ID);

            incoming = (from a in singleOutgoing
                        select new
                        {
                            ID = a.Id,
                            BrandAsal = a.StockOutgoingCetakan.CompanyBrand.Nama,
                            IDBrandAsal = a.StockOutgoingCetakan.Idbrand,
                            BrandTujuan = a.StockOutgoingCetakan.CompanyBrand.Nama,
                            IDBrandTujuan = a.StockOutgoingCetakan.Idbrand,
                            TipeAsal = a.StockOutgoingCetakan.TipeAsal,
                            TIpeTujuan = a.StockOutgoingCetakan.TipeTujuan,
                            LokasiAsal = a.StockOutgoingCetakan.NamaAsal,
                            IDAsal = a.StockOutgoingCetakan.Idasal,
                            LokasiTujuan = a.StockOutgoingCetakan.NamaTujuan,
                            IDTujuan = a.StockOutgoingCetakan.Idtujuan,
                            Nomor = a.Nomor,
                            Kurir = a.StockOutgoingCetakan.NamaKurir,
                            Description = a.Keterangan,
                            ApproveDate = a.ApprovalTgl.HasValue ? a.ApprovalTgl.Value.ToString("D") : ""
                        }).SingleOrDefault();

            data = new
            {
                incoming,
                product = GetStockIncomingCetakanProduct(ID)
            };
            return data;
        }

        private List<object> GetStockIncomingCetakanProduct(int ID)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockIncomingCetakan_Detail " + ID;

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
                        Qty = Convert.ToInt32(row["Qty"]),
                        Receive = Convert.ToInt32(row["Receive"]),
                        Damaged = Convert.ToInt32(row["Damaged"]),
                        NeverArrived = Convert.ToInt32(row["NeverArrived"])
                    });
                }
            }

            return datas;
        }
        #endregion

        #region Insert Stock Incoming
        public void InsertStockIncomingDJ(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = MappingIncoming(datas, Username);

            int ID = connection.SingleInteger(dt, "dbo.sp_InsertCrossBrandIncomingDJ", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingIncomingProduct(datas, ID, Username);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandIncomingDJ_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void InsertStockIncomingPG(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = MappingIncoming(datas, Username);

            int ID = connection.SingleInteger(dt, "dbo.sp_InsertCrossBrandIncomingPG", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingIncomingProduct(datas, ID, Username);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandIncomingPG_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void InsertStockIncomingLD(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = MappingIncoming(datas, Username);

            int ID = connection.SingleInteger(dt, "dbo.sp_InsertCrossBrandIncomingLD", connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dtProduct = MappingIncomingProduct(datas, ID, Username);

            connection.Execute(dtProduct, "dbo.sp_InsertCrossBrandIncomingLD_Product", connectionStrings.ConnectionStrings.Cnn_DB);
        }

        public void InsertStockIncomingGJ(RequestStockOutgoingBRJ datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockIncomingGJ incoming = new StockIncomingGJ();
                    incoming.Idoutgoing = datas.ID;
                    incoming.Keterangan = datas.Keterangan;
                    incoming.StatusTransIn = 1;
                    incoming.Operator = Username;
                    incoming.OperatorTgl = DateTime.Now;
                    incoming.Tgl = DateTime.Now;

                    _context.StockIncomingGjs.Add(incoming);
                    _context.SaveChanges();

                    foreach (Product x in datas.Products)
                    {
                        int substorage = _context.StockOutgoingGjProducts.Single(p => p.Idform == datas.ID && p.Idproduct == x.ID).SubStorage;

                        StockIncomingGJ_Product product = new StockIncomingGJ_Product();

                        product.Idform = incoming.Id;
                        product.Idproduct = x.ID;
                        product.SubStorageTo = substorage;
                        product.Operator = Username;
                        product.OperatorTgl = DateTime.Now;
                        product.Status = 1;

                        _context.StockIncomingGjProducts.Add(product);
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

        public void InsertStockIncomingPackaging(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockIncomingPackaging incoming = new StockIncomingPackaging();
                    incoming.Idoutgoing = datas.ID;
                    incoming.Keterangan = datas.Keterangan;
                    incoming.StatusTransIn = 1;
                    incoming.Operator = Username;
                    incoming.Tgl = DateTime.Now;
                    incoming.OperatorTgl = DateTime.Now;

                    _context.StockIncomingPackagings.Add(incoming);
                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockIncomingPackaging_Product product = new StockIncomingPackaging_Product();

                        product.Idform = incoming.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;
                        product.Received = x.Receive;
                        product.Damaged = x.Demaged;
                        product.NeverArrived = x.NeverArrived;
                        product.Operator = Username;
                        product.OperatorTgl = DateTime.Now;
                        product.Status = 1;

                        _context.StockIncomingPackagingProducts.Add(product);
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
        public void InsertStockIncomingSouvenir(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockIncomingSouvenir incoming = new StockIncomingSouvenir();
                    incoming.Idoutgoing = datas.ID;
                    incoming.Keterangan = datas.Keterangan;
                    incoming.StatusTransIn = 1;
                    incoming.Operator = Username;
                    incoming.Tgl = DateTime.Now;
                    incoming.OperatorTgl = DateTime.Now;

                    _context.StockIncomingSouvenirs.Add(incoming);
                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockIncomingSouvenir_Product product = new StockIncomingSouvenir_Product();

                        product.Idform = incoming.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;
                        product.Received = x.Receive;
                        product.Damaged = x.Demaged;
                        product.NeverArrived = x.NeverArrived;
                        product.Operator = Username;
                        product.OperatorTgl = DateTime.Now;
                        product.Status = 1;

                        _context.StockIncomingSouvenirProducts.Add(product);
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
        public void InsertStockIncomingCetakan(RequestStockOutgoingPS datas, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockIncomingCetakan incoming = new StockIncomingCetakan();
                    incoming.Idoutgoing = datas.ID;
                    incoming.Keterangan = datas.Keterangan;
                    incoming.StatusTransIn = 1;
                    incoming.Operator = Username;
                    incoming.Tgl = DateTime.Now;
                    incoming.OperatorTgl = DateTime.Now;

                    _context.StockIncomingCetakans.Add(incoming);
                    _context.SaveChanges();

                    foreach (PS x in datas.Products)
                    {
                        StockIncomingCetakan_Product product = new StockIncomingCetakan_Product();

                        product.Idform = incoming.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;
                        product.Received = x.Receive;
                        product.Damaged = x.Demaged;
                        product.NeverArrived = x.NeverArrived;
                        product.Operator = Username;
                        product.OperatorTgl = DateTime.Now;
                        product.Status = 1;

                        _context.StockIncomingCetakanProducts.Add(product);
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

        #region Approve Stock Incoming
        public void ApprovalIncomingDJ(int ID, string Username)
        {

            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    var incoming = _context.CrossBrandStockIncomingDJs
                        .Include(p => p.CrossBrand_StockOutgoingDJ)
                        .Include(p => p.CrossBrand_StockIncomingDJ_Products)
                        .ThenInclude(p => p.StockActualDJ).SingleOrDefault(p => p.Id == ID);

                    incoming.Nomor = generateDocumentNumber("DJ");
                    incoming.StatusTransIn = 2;
                    incoming.Approval = Username;
                    incoming.ApprovalTgl = DateTime.Now;
                    incoming.CrossBrand_StockOutgoingDJ.StatusTransOut = 4;

                    foreach (CrossBrand_StockIncomingDJ_Product x in incoming.CrossBrand_StockIncomingDJ_Products)
                    {
                        x.SubStorageResult = x.SubStorageTo;
                        x.Status = 2;
                        x.Approval = Username;
                        x.ApprovalTgl = DateTime.Now;

                        x.StockActualDJ.InHand = 1;
                        x.StockActualDJ.TipeLokasi = incoming.CrossBrand_StockOutgoingDJ.TipeTujuan;
                        x.StockActualDJ.Idlokasi = incoming.CrossBrand_StockOutgoingDJ.Idtujuan;
                        x.StockActualDJ.Substorage = x.SubStorageTo;
                        x.StockActualDJ.NamaLokasi = incoming.CrossBrand_StockOutgoingDJ.NamaTujuan;

                        StockLedgerDJ ledger = new StockLedgerDJ();
                        ledger.Idproduct = x.Idproduct;
                        ledger.Idlokasi = x.StockActualDJ.Idlokasi;
                        ledger.TipeLokasi = x.StockActualDJ.TipeLokasi;
                        ledger.NamaLokasi = x.StockActualDJ.NamaLokasi;
                        ledger.Remark = 4;
                        ledger.Keterangan = incoming.Nomor;
                        ledger.Value = 1;
                        ledger.Operator = Username;
                        ledger.OperatorTgl = DateTime.Now;

                        _context.StockLedgerDjs.Add(ledger);
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

        public void ApprovalIncomingPG(int ID, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    var incoming = _context.CrossBrandStockIncomingPgs
                        .Include(p => p.CrossBrand_StockOutgoingPG)
                        .Include(p => p.CrossBrand_StockIncomingPG_Products)
                        .ThenInclude(p => p.StockActualPG).SingleOrDefault(p => p.Id == ID);

                    incoming.Nomor = generateDocumentNumber("PG");
                    incoming.StatusTransIn = 2;
                    incoming.Approval = Username;
                    incoming.ApprovalTgl = DateTime.Now;
                    incoming.CrossBrand_StockOutgoingPG.StatusTransOut = 4;

                    foreach (CrossBrand_StockIncomingPG_Product x in incoming.CrossBrand_StockIncomingPG_Products)
                    {
                        x.SubStorageResult = x.SubStorageTo;
                        x.Status = 2;
                        x.Approval = Username;
                        x.ApprovalTgl = DateTime.Now;

                        x.StockActualPG.InHand = 1;
                        x.StockActualPG.TipeLokasi = incoming.CrossBrand_StockOutgoingPG.TipeTujuan;
                        x.StockActualPG.Idlokasi = incoming.CrossBrand_StockOutgoingPG.Idtujuan;
                        x.StockActualPG.Substorage = x.SubStorageTo;
                        x.StockActualPG.NamaLokasi = incoming.CrossBrand_StockOutgoingPG.NamaTujuan;

                        StockLedgerPg ledger = new StockLedgerPg();
                        ledger.Idproduct = x.Idproduct;
                        ledger.Idlokasi = x.StockActualPG.Idlokasi;
                        ledger.TipeLokasi = x.StockActualPG.TipeLokasi;
                        ledger.NamaLokasi = x.StockActualPG.NamaLokasi;
                        ledger.Remark = 4;
                        ledger.Keterangan = incoming.Nomor;
                        ledger.Value = 1;
                        ledger.Operator = Username;
                        ledger.OperatorTgl = DateTime.Now;

                        _context.StockLedgerPgs.Add(ledger);
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

        public void ApprovalIncomingLD(int ID, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    //Approval incoming
                    var incoming = _context.CrossBrandStockIncomingLDs
                        .Include(p => p.CrossBrand_StockOutgoingLD)
                        .Include(p => p.CrossBrand_StockIncomingLD_Products)
                        .ThenInclude(p => p.StockActualLD_Stone1B).SingleOrDefault(p => p.Id == ID);

                    incoming.Nomor = generateDocumentNumber("LD");
                    incoming.StatusTransIn = 2;
                    incoming.Approval = Username;
                    incoming.ApprovalTgl = DateTime.Now;
                    incoming.CrossBrand_StockOutgoingLD.StatusTransOut = 4;

                    foreach (CrossBrand_StockIncomingLD_Product x in incoming.CrossBrand_StockIncomingLD_Products)
                    {
                        x.SubStorageResult = x.SubStorageTo;
                        x.Status = 2;
                        x.Approval = Username;
                        x.ApprovalTgl = DateTime.Now;

                        x.StockActualLD_Stone1B.InHand = 1;
                        x.StockActualLD_Stone1B.TipeLokasi = incoming.CrossBrand_StockOutgoingLD.TipeTujuan;
                        x.StockActualLD_Stone1B.Idlokasi = incoming.CrossBrand_StockOutgoingLD.Idtujuan;
                        x.StockActualLD_Stone1B.Substorage = x.SubStorageTo;
                        x.StockActualLD_Stone1B.NamaLokasi = incoming.CrossBrand_StockOutgoingLD.NamaTujuan;

                        StockLedgerLd ledger = new StockLedgerLd();
                        ledger.Idproduct = x.Idproduct;
                        ledger.Idlokasi = x.StockActualLD_Stone1B.Idlokasi;
                        ledger.TipeLokasi = x.StockActualLD_Stone1B.TipeLokasi;
                        ledger.NamaLokasi = x.StockActualLD_Stone1B.NamaLokasi;
                        ledger.Remark = 4;
                        ledger.Keterangan = incoming.Nomor;
                        ledger.Value = 1;
                        ledger.Operator = Username;
                        ledger.OperatorTgl = DateTime.Now;

                        _context.StockLedgerLds.Add(ledger);
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

        public void ApprovalIncomingGJ(int ID, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    var incoming = _context.StockIncomingGjs
                        .Include(p => p.StockOutgoingGJ)
                        .Include(p => p.StockIncomingGJ_Products)
                        .ThenInclude(p => p.StockActualGJ).SingleOrDefault(p => p.Id == ID);

                    incoming.Nomor = generateDocumentNumber("GJ");
                    incoming.StatusTransIn = 2;
                    incoming.Approval = Username;
                    incoming.ApprovalTgl = DateTime.Now;
                    incoming.StockOutgoingGJ.StatusTransOut = 4;

                    foreach (StockIncomingGJ_Product x in incoming.StockIncomingGJ_Products)
                    {
                        x.SubStorageResult = x.SubStorageTo;
                        x.Status = 2;
                        x.Approval = Username;
                        x.ApprovalTgl = DateTime.Now;

                        x.StockActualGJ.InHand = 1;
                        x.StockActualGJ.TipeLokasi = incoming.StockOutgoingGJ.TipeTujuan;
                        x.StockActualGJ.Idlokasi = incoming.StockOutgoingGJ.Idtujuan;
                        x.StockActualGJ.Substorage = x.SubStorageTo;
                        x.StockActualGJ.NamaLokasi = incoming.StockOutgoingGJ.NamaTujuan;

                        StockLedgerGJ ledger = new StockLedgerGJ();
                        ledger.Idproduct = x.Idproduct;
                        ledger.Idlokasi = x.StockActualGJ.Idlokasi;
                        ledger.TipeLokasi = x.StockActualGJ.TipeLokasi;
                        ledger.NamaLokasi = x.StockActualGJ.NamaLokasi;
                        ledger.Remark = 4;
                        ledger.Keterangan = incoming.Nomor;
                        ledger.Value = 1;
                        ledger.Operator = Username;
                        ledger.OperatorTgl = DateTime.Now;

                        _context.StockLedgerGjs.Add(ledger);
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

        public void ApprovalIncomingPackaging(int ID, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    var incoming = _context.StockIncomingPackagings
                        .Include(p => p.StockOutgoingPackaging)
                        .Include(p => p.StockIncomingPackaging_Products).ThenInclude(p => p.Packaging).SingleOrDefault(p => p.Id == ID);


                    int tipeAsal = incoming.StockOutgoingPackaging.TipeAsal;
                    int idAsal = incoming.StockOutgoingPackaging.Idasal;
                    int tipeTujuan = incoming.StockOutgoingPackaging.TipeTujuan;
                    int idTujuan = incoming.StockOutgoingPackaging.Idtujuan;

                    incoming.Nomor = generateDocumentNumber("PC");
                    incoming.StatusTransIn = 2;
                    incoming.Approval = Username;
                    incoming.ApprovalTgl = DateTime.Now;
                    incoming.StockOutgoingPackaging.StatusTransOut = 4;

                    foreach (StockIncomingPackaging_Product x in incoming.StockIncomingPackaging_Products)
                    {
                        x.SubStorageResult = x.SubStorageTo;
                        x.Status = 2;
                        x.Approval = Username;
                        x.ApprovalTgl = DateTime.Now;

                        var actualAsal = _context.StockActualPackagings.SingleOrDefault(p => p.TipeLokasi == tipeAsal && p.Idlokasi == idAsal && p.Idproduct == x.Idproduct);

                        actualAsal.InTransit -= x.Qty;
                        actualAsal.InHand += x.NeverArrived.HasValue ? x.NeverArrived.Value : 0 ;

                        if (_context.StockActualPackagings.Any(p => p.TipeLokasi == tipeTujuan && p.Idlokasi == idTujuan && p.Idproduct == x.Idproduct))
                        {
                            var actualTujuan = _context.StockActualPackagings.SingleOrDefault(p => p.TipeLokasi == tipeTujuan && p.Idlokasi == idTujuan && p.Idproduct == x.Idproduct);

                            actualTujuan.InHand += x.Received.Value;
                            actualTujuan.Damaged += x.Damaged.Value;
                        }
                        else
                        {
                            StockActualPackaging actualTujuan = new StockActualPackaging();

                            actualTujuan.Idlokasi = incoming.StockOutgoingPackaging.Idtujuan;
                            actualTujuan.TipeLokasi = incoming.StockOutgoingPackaging.TipeTujuan;
                            actualTujuan.Idproduct = x.Idproduct;
                            actualTujuan.Nomor = x.Packaging.Kode;
                            actualTujuan.NamaLokasi = incoming.StockOutgoingPackaging.NamaTujuan;
                            actualTujuan.Substorage = 1;
                            actualTujuan.Keterangan = "";
                            actualTujuan.InHand = x.Received.Value;
                            actualTujuan.Damaged = x.Damaged.Value;
                            actualTujuan.NeverArrived = 0;
                            actualTujuan.InTransit = 0;
                            actualTujuan.Operator = Username;
                            actualTujuan.OperatorTgl = DateTime.Now;
                            actualTujuan.Tgl = DateTime.Now;

                            _context.StockActualPackagings.Add(actualTujuan);
                        }
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

        public void ApprovalIncomingSouvenir(int ID, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    var incoming = _context.StockIncomingSouvenirs
                        .Include(p => p.StockOutgoingSouvenir)
                        .Include(p => p.StockIncomingSouvenir_Products).ThenInclude(p => p.Souvenir).SingleOrDefault(p => p.Id == ID);

                    int tipeAsal = incoming.StockOutgoingSouvenir.TipeAsal;
                    int idAsal = incoming.StockOutgoingSouvenir.Idasal;
                    int tipeTujuan = incoming.StockOutgoingSouvenir.TipeTujuan;
                    int idTujuan = incoming.StockOutgoingSouvenir.Idtujuan;

                    incoming.Nomor = generateDocumentNumber("PC");
                    incoming.StatusTransIn = 2;
                    incoming.Approval = Username;
                    incoming.ApprovalTgl = DateTime.Now;
                    incoming.StockOutgoingSouvenir.StatusTransOut = 4;

                    foreach (StockIncomingSouvenir_Product x in incoming.StockIncomingSouvenir_Products)
                    {
                        x.SubStorageResult = x.SubStorageTo;
                        x.Status = 2;
                        x.Approval = Username;
                        x.ApprovalTgl = DateTime.Now;

                        var actualAsal = _context.StockActualSouvenirs.SingleOrDefault(p => p.TipeLokasi == tipeAsal && p.Idlokasi == idAsal && p.Idproduct == x.Idproduct);

                        actualAsal.InTransit -= x.Qty;
                        actualAsal.InHand += x.NeverArrived.HasValue ? x.NeverArrived.Value : 0;

                        if (_context.StockActualSouvenirs.Any(p => p.TipeLokasi == tipeTujuan && p.Idlokasi == idTujuan && p.Idproduct == x.Idproduct))
                        {
                            var actualTujuan = _context.StockActualSouvenirs.SingleOrDefault(p => p.TipeLokasi == tipeTujuan && p.Idlokasi == idTujuan && p.Idproduct == x.Idproduct);

                            actualTujuan.InHand += x.Received.Value;
                            actualTujuan.Damaged += x.Damaged.Value;
                        }
                        else
                        {
                            StockActualSouvenir actualTujuan = new StockActualSouvenir();

                            actualTujuan.Idlokasi = incoming.StockOutgoingSouvenir.Idtujuan;
                            actualTujuan.TipeLokasi = incoming.StockOutgoingSouvenir.TipeTujuan;
                            actualTujuan.Idproduct = x.Idproduct;
                            actualTujuan.Nomor = x.Souvenir.Kode;
                            actualTujuan.NamaLokasi = incoming.StockOutgoingSouvenir.NamaTujuan;
                            actualTujuan.Substorage = 1;
                            actualTujuan.Keterangan = "";
                            actualTujuan.InHand = x.Received.Value;
                            actualTujuan.Damaged = x.Damaged.Value;
                            actualTujuan.NeverArrived = 0;
                            actualTujuan.InTransit = 0;
                            actualTujuan.Operator = Username;
                            actualTujuan.OperatorTgl = DateTime.Now;
                            actualTujuan.Tgl = DateTime.Now;

                            _context.StockActualSouvenirs.Add(actualTujuan);
                        }
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

        public void ApprovalIncomingCetakan(int ID, string Username)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    var incoming = _context.StockIncomingCetakans
                        .Include(p => p.StockOutgoingCetakan)
                        .Include(p => p.StockIncomingCetakan_Products).ThenInclude(p => p.Cetakan).SingleOrDefault(p => p.Id == ID);

                    int tipeAsal = incoming.StockOutgoingCetakan.TipeAsal;
                    int idAsal = incoming.StockOutgoingCetakan.Idasal;
                    int tipeTujuan = incoming.StockOutgoingCetakan.TipeTujuan;
                    int idTujuan = incoming.StockOutgoingCetakan.Idtujuan;

                    incoming.Nomor = generateDocumentNumber("PC");
                    incoming.StatusTransIn = 2;
                    incoming.Approval = Username;
                    incoming.ApprovalTgl = DateTime.Now;
                    incoming.StockOutgoingCetakan.StatusTransOut = 4;

                    foreach (StockIncomingCetakan_Product x in incoming.StockIncomingCetakan_Products)
                    {
                        x.SubStorageResult = x.SubStorageTo;
                        x.Status = 2;
                        x.Approval = Username;
                        x.ApprovalTgl = DateTime.Now;

                        var actualAsal = _context.StockActualCetakans.SingleOrDefault(p => p.TipeLokasi == tipeAsal && p.Idlokasi == idAsal && p.Idproduct == x.Idproduct);

                        actualAsal.InTransit -= x.Qty;
                        actualAsal.InHand += x.NeverArrived.HasValue ? x.NeverArrived.Value : 0;

                        if (_context.StockActualCetakans.Any(p => p.TipeLokasi == tipeTujuan && p.Idlokasi == idTujuan && p.Idproduct == x.Idproduct))
                        {
                            var actualTujuan = _context.StockActualCetakans.SingleOrDefault(p => p.TipeLokasi == tipeTujuan && p.Idlokasi == idTujuan && p.Idproduct == x.Idproduct);

                            actualTujuan.InHand += x.Received.Value;
                            actualTujuan.Damaged += x.Damaged.Value;
                        }
                        else
                        {
                            StockActualCetakan actualTujuan = new StockActualCetakan();

                            actualTujuan.Idlokasi = incoming.StockOutgoingCetakan.Idtujuan;
                            actualTujuan.TipeLokasi = incoming.StockOutgoingCetakan.TipeTujuan;
                            actualTujuan.Idproduct = x.Idproduct;
                            actualTujuan.Nomor = x.Cetakan.Kode;
                            actualTujuan.NamaLokasi = incoming.StockOutgoingCetakan.NamaTujuan;
                            actualTujuan.Substorage = 1;
                            actualTujuan.Keterangan = "";
                            actualTujuan.InHand = x.Received.Value;
                            actualTujuan.Damaged = x.Damaged.Value;
                            actualTujuan.NeverArrived = 0;
                            actualTujuan.InTransit = 0;
                            actualTujuan.Operator = Username;
                            actualTujuan.OperatorTgl = DateTime.Now;
                            actualTujuan.Tgl = DateTime.Now;

                            _context.StockActualCetakans.Add(actualTujuan);
                        }
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

        #region Delete Stock Incoming
        public void DeleteStockIncomingDJ(int ID)
        {
            CrossBrand_StockIncomingDJ incoming = _context.CrossBrandStockIncomingDJs.Include(p => p.CrossBrand_StockIncomingDJ_Products)
                .Include(p => p.CrossBrand_StockOutgoingDJ).SingleOrDefault(p => p.Id == ID);
            foreach (CrossBrand_StockIncomingDJ_Product x in incoming.CrossBrand_StockIncomingDJ_Products)
            {
                _context.CrossBrandStockIncomingDJProducts.Remove(x);
            }
            incoming.CrossBrand_StockOutgoingDJ.StatusTransOut = 2;
            _context.CrossBrandStockIncomingDJs.Remove(incoming);
            _context.SaveChanges();
        }

        public void DeleteStockIncomingPG(int ID)
        {
            CrossBrand_StockIncomingPG incoming = _context.CrossBrandStockIncomingPgs.Include(p => p.CrossBrand_StockIncomingPG_Products)
                .Include(p => p.CrossBrand_StockOutgoingPG).SingleOrDefault(p => p.Id == ID);
            foreach (CrossBrand_StockIncomingPG_Product x in incoming.CrossBrand_StockIncomingPG_Products)
            {
                _context.CrossBrandStockIncomingPgProducts.Remove(x);
            }

            incoming.CrossBrand_StockOutgoingPG.StatusTransOut = 2;
            _context.CrossBrandStockIncomingPgs.Remove(incoming);
            _context.SaveChanges();
        }

        public void DeleteStockIncomingLD(int ID)
        {
            CrossBrand_StockIncomingLD incoming = _context.CrossBrandStockIncomingLDs.Include(p => p.CrossBrand_StockIncomingLD_Products)
                .Include(p => p.CrossBrand_StockOutgoingLD).SingleOrDefault(p => p.Id == ID);
            foreach (CrossBrand_StockIncomingLD_Product x in incoming.CrossBrand_StockIncomingLD_Products)
            {
                _context.CrossBrandStockIncomingLDProducts.Remove(x);
            }

            incoming.CrossBrand_StockOutgoingLD.StatusTransOut = 2;
            _context.CrossBrandStockIncomingLDs.Remove(incoming);
            _context.SaveChanges();
        }

        public void DeleteStockIncomingGJ(int ID)
        {
            StockIncomingGJ incoming = _context.StockIncomingGjs.Include(p => p.StockIncomingGJ_Products)
                .Include(p => p.StockOutgoingGJ).SingleOrDefault(p => p.Id == ID);
            foreach (StockIncomingGJ_Product x in incoming.StockIncomingGJ_Products)
            {
                _context.StockIncomingGjProducts.Remove(x);
            }

            incoming.StockOutgoingGJ.StatusTransOut = 2;
            _context.StockIncomingGjs.Remove(incoming);
            _context.SaveChanges();
        }

        public void DeleteStockIncomingPackaging(int ID)
        {
            StockIncomingPackaging incoming = _context.StockIncomingPackagings.Include(p => p.StockIncomingPackaging_Products)
                .Include(p => p.StockOutgoingPackaging).SingleOrDefault(p => p.Id == ID);
            foreach (StockIncomingPackaging_Product x in incoming.StockIncomingPackaging_Products)
            {
                _context.StockIncomingPackagingProducts.Remove(x);
            }

            incoming.StockOutgoingPackaging.StatusTransOut = 2;
            _context.StockIncomingPackagings.Remove(incoming);
            _context.SaveChanges();
        }

        public void DeleteStockIncomingSouvenir(int ID)
        {
            StockIncomingSouvenir incoming = _context.StockIncomingSouvenirs.Include(p => p.StockIncomingSouvenir_Products)
                .Include(p => p.StockOutgoingSouvenir).SingleOrDefault(p => p.Id == ID);
            foreach (StockIncomingSouvenir_Product x in incoming.StockIncomingSouvenir_Products)
            {
                _context.StockIncomingSouvenirProducts.Remove(x);
            }

            incoming.StockOutgoingSouvenir.StatusTransOut = 2;
            _context.StockIncomingSouvenirs.Remove(incoming);
            _context.SaveChanges();
        }

        public void DeleteStockIncomingCetakan(int ID)
        {
            StockIncomingCetakan incoming = _context.StockIncomingCetakans.Include(p => p.StockIncomingCetakan_Products)
                .Include(p => p.StockOutgoingCetakan).SingleOrDefault(p => p.Id == ID);
            foreach (StockIncomingCetakan_Product x in incoming.StockIncomingCetakan_Products)
            {
                _context.StockIncomingCetakanProducts.Remove(x);
            }

            incoming.StockOutgoingCetakan.StatusTransOut = 2;
            _context.StockIncomingCetakans.Remove(incoming);
            _context.SaveChanges();
        }
        #endregion

        public int GetIDOutgoing(int ID, bool isCrossBrand)
        {
            int IDOutgoing = 0;
            if (isCrossBrand)
            {
                IDOutgoing = _context.CrossBrandStockIncomingDJs.Include(p => p.CrossBrand_StockOutgoingDJ).SingleOrDefault(p => p.Id == ID).CrossBrand_StockOutgoingDJ.Id;  
            }
            else
            {
                IDOutgoing = _context.StockIncomingDjs.Include(p => p.StockOutgoingDJ).SingleOrDefault(p => p.Id == ID).StockOutgoingDJ.Id;
            }
            return IDOutgoing;
        }

        private DataTable MappingIncoming(RequestStockOutgoingBRJ datas, string Username)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("IDOutgoing", typeof(int));
            dt.Columns.Add("Nomor", typeof(string));
            dt.Columns.Add("Tgl", typeof(DateTime));
            dt.Columns.Add("Keterangan", typeof(string));
            dt.Columns.Add("StatusTransIn", typeof(int));
            dt.Columns.Add("Operator", typeof(string));
            dt.Columns.Add("OperatorTgl", typeof(DateTime));
            dt.Columns.Add("Approval", typeof(string));
            dt.Columns.Add("ApprovalTgl", typeof(DateTime));


            DataRow dr = dt.NewRow();
            dr["IDOutgoing"] = datas.ID;
            dr["Tgl"] = DateTime.Now;
            dr["Keterangan"] = datas.Keterangan;
            dr["StatusTransIn"] = 1;
            dr["Operator"] = Username;
            dr["OperatorTgl"] = DateTime.Now;
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable MappingIncomingProduct(RequestStockOutgoingBRJ datas, int IDForm, string Username)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("IDForm", typeof(int));
            dt.Columns.Add("IDProduct", typeof(int));
            dt.Columns.Add("Nomor", typeof(string));
            dt.Columns.Add("SubStorageTo", typeof(int));
            dt.Columns.Add("SubStorageResult", typeof(int));
            dt.Columns.Add("Status", typeof(int));
            dt.Columns.Add("Operator", typeof(string));
            dt.Columns.Add("OperatorTgl", typeof(DateTime));
            dt.Columns.Add("Approval", typeof(string));
            dt.Columns.Add("ApprovalTgl", typeof(DateTime));

            //Auto-Input List Product
            foreach (var x in datas.Products)
            { 
                DataRow dr = dt.NewRow();
                dr["IDForm"] = IDForm;
                dr["IDProduct"] = x.ID;
                dr["Nomor"] = x.Nomor;
                dr["SubStorageTo"] = 1;
                dr["Status"] = 1;
                dr["Operator"] = Username;
                dr["OperatorTgl"] = DateTime.Now;

                dt.Rows.Add(dr);
            }

            return dt;
        }

        private string generateDocumentNumber(string Tipe)
        {
            string result = "";
            string v1 = "TRM/" + common.KodeBrand() + "/" + Tipe;
            string v2 = System.DateTime.Now.Year.ToString().Substring(2, 2);
            string v3 = System.DateTime.Now.Month.ToString().PadLeft(2, '0');
            string v4 = "0001";

            if (Tipe == "DJ")
            {
                var rs = _context.CrossBrandStockIncomingDJs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "PG")
            {
                var rs = _context.CrossBrandStockIncomingPgs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "LD")
            {
                var rs = _context.CrossBrandStockIncomingLDs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "GJ")
            {
                var rs = _context.StockIncomingGjs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "PC")
            {
                var rs = _context.StockIncomingPackagings.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            else if (Tipe == "SV")
            {
                var rs = _context.StockIncomingSouvenirs.Where(p => p.Nomor.Contains(v1));
                if (rs.Count() > 0) rs = rs.Where(p => p.Nomor != null && p.Nomor.Substring(9, 2) == v2 && p.Nomor.Substring(12, 2) == v3).OrderByDescending(p => p.Nomor);

                result = rs.Count() > 0 ? v1 + "/" + v2 + "/" + v3 + "/" + ((Convert.ToInt32(rs.FirstOrDefault().Nomor.Substring(15, 4)) + 1).ToString()).PadLeft(4, '0')
                                        : v1 + "/" + v2 + "/" + v3 + "/" + v4;
            }
            return result;
        }
    }
}
