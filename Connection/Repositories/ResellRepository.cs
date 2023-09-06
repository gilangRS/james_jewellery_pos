using Connection.Interface;
using Connection.Models;
using Connection.RequestModels.PointOfSales;
using Connection.RequestModels.StockTransfer;
using Connection.Settings;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace Connection.Repositories
{
    public class ResellRepository : IResellRepository
    {
        private readonly JAWSDbContext _context;
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        private Common _common;

        public ResellRepository()
        {
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
            _common = new Common();
            _context = new JAWSDbContext();
        }
        #region Get Resell By ID
        public object GetResell(int id)
        {
            try
            {
                string query = "sp_get_resell_by_id_new";
                DataSet ds = _openConnection.Ds("EXEC " + query + " " + id.ToString(), _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = ds.Tables[0];
                DataTable dtitem = ds.Tables[1];

                List<object> listitem = new List<object>();

                foreach (DataRow x in dtitem.Rows)
                {
                    listitem.Add(new
                    {
                        id = Convert.ToInt32(x["ID"]),
                        id_product = Convert.ToInt32(x["ID_PRODUCT"]),
                        tipe_product = x["TIPE_PRODUCT"].ToString(),
                        id_doc_qc = Convert.ToInt32(x["ID_DOC_QC"]),
                        no_doc_qc = x["NO_DOC_QC"].ToString(),
                        no_invoice = x["NO_INVOICE"].ToString(),
                        no_so = x["NO_SO"].ToString(),
                        plu = x["NOMOR"].ToString(),
                        item = x["ITEM"].ToString(),
                        harga_jual = Convert.ToDouble(x["HARGA_JUAL"]),
                        harga_acuan = Convert.ToDouble(x["HARGA_ACUAN"]),
                        harga_beli = Convert.ToDouble(x["HARGA_RUPIAH"]),
                        selisih = x["SELISIH"].ToString(),
                        usia = x["USIA"].ToString()
                    });
                }

                return new
                {
                    message = "",
                    data = new
                    {
                        id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                        nomor = dtheader.Rows[0]["NOMOR"].ToString(),
                        customer = dtheader.Rows[0]["CUSTOMER_NAMA"].ToString(),
                        sales = dtheader.Rows[0]["SALES_NAMA"].ToString(),
                        tgl = Convert.ToDateTime(dtheader.Rows[0]["TGL"]).ToString("dd-MM-yyyy"),
                        kode_lokasi = dtheader.Rows[0]["KODE_LOKASI"].ToString(),
                        nama_lokasi = dtheader.Rows[0]["NAMA_LOKASI"].ToString(),
                        keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                        total_harga = Convert.ToDouble(dtheader.Rows[0]["TOTAL_HARGA"]),
                        status_void = Convert.ToBoolean(dtheader.Rows[0]["STATUS_VOID"]),
                        keterangan_void = dtheader.Rows[0]["KETERANGAN_VOID"].ToString(),
                        kode_customer_lama = dtheader.Rows[0]["KODE_CUSTOMER_LAMA"].ToString(),
                        operator_nama = dtheader.Rows[0]["OPERATOR_NAMA"].ToString(),
                        group_resell = dtheader.Rows[0]["GROUP_RESELL"].ToString(),
                        item = listitem
                    }
                };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Validation Add Resell
        public object ValidationAddResell(int id)
        {
            try
            {
                string query = "EXEC sp_validation_insert_resell_new " + id;
                string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = result };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Add Resell
        public object AddResell(RequestResell rr)
        {
            try
            {
                string queryro = "EXEC sp_insert_resell_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_RO VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (rr != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_RO, [MESSAGE]) " + queryro +
                        " " + rr.id_customer + "," +
                        " '" + rr.customer_nama + "'," +
                        " " + rr.tipe_lokasi + "," +
                        " " + rr.id_lokasi + "," +
                        " '" + rr.kode_lokasi + "'," +
                        " " + rr.total_harga + "," +
                        " '" + rr.tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                        " '" + rr.keterangan + "'," +
                        " '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                        " '" + rr.operator_nama + "'," +
                        " " + (rr.tradein == false ? 0 : 1) + "," +
                        " " + (rr.status_void == false ? 0 : 1) + "," +
                        " " + rr.id_sales + "," +
                        " '" + rr.sales_nama + "'," +
                        " '" + rr.kode_customer_lama + "'," +
                        " '" + rr.group_resell + "'" +
                        " DECLARE @IDRO INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMORRO VARCHAR(50) = (SELECT TOP 1 NO_RO FROM @TABLE) ";

                    string querydj = "EXEC sp_insert_resell_dj_new";
                    string querypg = "EXEC sp_insert_resell_pg_new";
                    string querygj = "EXEC sp_insert_resell_gj_new";
                    string queryld = "EXEC sp_insert_resell_ld_new";

                    foreach (var dj in rr.resell_dj)
                    {
                        querystart += querydj + " @IDRO," +
                            " " + dj.id_sales_order + "," +
                            " " + dj.id_product + "," +
                            " " + dj.id_doc_qc + "," +
                            " '" + dj.nomor + "'," +
                            " " + dj.harga_acuan + "," +
                            " " + dj.harga_rupiah + "," +
                            " " + dj.nilai_trade_in + "," +
                            " '" + dj.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + dj.operator_nama + "'," +
                            " " + dj.modal_usd + "";
                    }

                    foreach (var pg in rr.resell_pg)
                    {
                        querystart += querypg + " @IDRO," +
                            " " + pg.id_sales_order + "," +
                            " " + pg.id_product + "," +
                            " " + pg.id_doc_qc + "," +
                            " '" + pg.nomor + "'," +
                            " " + pg.harga_acuan + "," +
                            " " + pg.harga_rupiah + "," +
                            " " + pg.nilai_trade_in + "," +
                            " '" + pg.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + pg.operator_nama + "'," +
                            " " + pg.berat_timbang.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + pg.tgp + "";
                    }

                    foreach (var gj in rr.resell_gj)
                    {
                        querystart += querygj + " @IDRO," +
                            " " + gj.id_sales_order + "," +
                            " " + gj.id_product + "," +
                            " " + gj.id_doc_qc + "," +
                            " '" + gj.nomor + "'," +
                            " " + gj.harga_acuan + "," +
                            " " + gj.harga_rupiah + "," +
                            " " + gj.nilai_trade_in + "," +
                            " '" + gj.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + gj.operator_nama + "'," +
                            " " + gj.berat_timbang + "," +
                            " " + gj.tgp + "";
                    }

                    foreach (var ld in rr.resell_ld)
                    {
                        querystart += queryld + " @IDRO," +
                            " " + ld.id_sales_order + "," +
                            " " + ld.id_product + "," +
                            " " + ld.id_doc_qc + "," +
                            " '" + ld.nomor + "'," +
                            " " + ld.harga_acuan + "," +
                            " " + ld.harga_rupiah + "," +
                            " " + ld.nilai_trade_in + "," +
                            " '" + ld.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + ld.operator_nama + "'";
                    }
                    string queryupdatero = "EXEC sp_update_total_resell_new @IDRO";
                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " " + queryupdatero + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_RO], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idro = Convert.ToInt32(result.Rows[0]["ID"]);
                    string noro = result.Rows[0]["NO_RO"].ToString();
                    return new { message = res, id = idro, no = noro };
                }
                else
                {
                    return new { message = "Failed. Data Not Found" };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Void Resell
        public object VoidResell(int id, string operatornama, string keterangan)
        {
            try
            {
                string queryvalidation = "EXEC sp_validation_void_resell_new " + id.ToString();
                string queryvoid = "EXEC sp_void_resell_new " + id.ToString() + ",'" + operatornama + "','" + keterangan + "'";

                string errorvalidation = _openConnection.SingleString(queryvalidation, _connectionStrings.ConnectionStrings.Cnn_DB);
                if (errorvalidation == "")
                {
                    string msg = _openConnection.SingleString(queryvoid, _connectionStrings.ConnectionStrings.Cnn_DB);
                    return new { message = msg };
                }
                else
                {
                    return new { message = errorvalidation };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Get Resell Item By Customer
        public object GetResellItemByCustomer(int idcustomer, string custlama, string tipe_transaksi)
        {
            try
            {
                string query = "sp_get_resell_item_by_customer_new";
                DataTable dt = _openConnection.Rs("EXEC " + query + " " + idcustomer.ToString() + " ,'" + custlama + "', '" + tipe_transaksi + "', '" + _connectionStrings.AppConfig.BrandCode +"'", _connectionStrings.ConnectionStrings.Cnn_DB);
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["TIPE"].ToString().ToUpper() == "PG")
                    {
                        dtobject.Add(new
                        {
                            brand = dr["BRAND"].ToString(),
                            id_sales_order = Convert.ToInt32(dr["ID_SALES_ORDER"]),
                            id_product = Convert.ToInt32(dr["ID_PRODUCT"]),
                            tipe = dr["TIPE"].ToString(),
                            nomor = dr["NOMOR"].ToString(),
                            noso = dr["NOSO"].ToString(),
                            invoice = dr["NO_INVOICE"].ToString(),
                            harga_beli = Convert.ToDouble(dr["HARGA_BELI"]),
                            item = dr["ITEM"].ToString(),
                            store_asal = dr["STORE_ASAL"].ToString(),
                            gross_weight = Convert.ToDecimal(dr["GROSS_WEIGHT"]),
                            netto_weight = Convert.ToDecimal(dr["NETTO_WEIGHT"]),
                            total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                            total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                            tgp_beli = GetRateTgpBeliQuery(Convert.ToInt32(dr["ID_PRODUCT"])),
                            is_nyangkut = Convert.ToBoolean(dr["IS_NYANGKUT"]),
                            keterangan_nyangkut = dr["KETERANGAN_NYANGKUT"].ToString()
                        }); ;
                    }
                    else
                    {
                        dtobject.Add(new
                        {
                            brand = dr["BRAND"].ToString(),
                            id_sales_order = Convert.ToInt32(dr["ID_SALES_ORDER"]),
                            id_product = Convert.ToInt32(dr["ID_PRODUCT"]),
                            tipe = dr["TIPE"].ToString(),
                            nomor = dr["NOMOR"].ToString(),
                            noso = dr["NOSO"].ToString(),
                            invoice = dr["NO_INVOICE"].ToString(),
                            harga_beli = Convert.ToDouble(dr["HARGA_BELI"]),
                            item = dr["ITEM"].ToString(),
                            store_asal = dr["STORE_ASAL"].ToString(),
                            gross_weight = Convert.ToDecimal(dr["GROSS_WEIGHT"]),
                            netto_weight = Convert.ToDecimal(dr["NETTO_WEIGHT"]),
                            total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                            total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                            is_nyangkut = Convert.ToBoolean(dr["IS_NYANGKUT"]),
                            keterangan_nyangkut = dr["KETERANGAN_NYANGKUT"].ToString()
                        });
                    }
                }
                return new { message = "", data = dtobject };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Report Resell
        public object ReportResell(string kw, string start, string end, string location, int reselltype, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "sp_report_resell_new";
                DataSet ds = _openConnection.Ds("EXEC " + query + " '" + kw + "', '" + start + "', '" + end + "', '" + location + "'," + reselltype + ", " + status + ", " + page + ", " + row + ", " + excel, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        no_resell = dr["NO_RO"].ToString(),
                        tanggal_resell = Convert.ToDateTime(dr["TANGGAL"]).ToString("dd-MM-yyyy"),
                        store = dr["STORE"].ToString(),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        sales_nama = dr["SALES_NAMA"].ToString(),
                        total_harga = Convert.ToDouble(dr["TOTAL_HARGA"]),
                        keterangan = dr["KETERANGAN"].ToString(),
                        keterangan_void = dr["KETERANGAN_VOID"].ToString(),
                        status = dr["STATUS"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        gross_weight = Convert.ToDecimal(dr["WEIGHT"]),
                        total_butir = Convert.ToInt64(dr["BUTIR"]),
                        total_carat = Convert.ToDecimal(dr["CARAT"]),
                        resell_type = dr["RESELL_TYPE"].ToString()
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt64(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Report Resell Detail
        public object ReportResellDetail(string kw, string start, string end, string location, string producttype, int reselltype, int item, int kategori, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "sp_report_resell_detail_so_new";
                DataSet ds = _openConnection.Ds("EXEC " + query + " '" + kw + "' ,'" + start + "', '" + end + "', '" + location + "', '" + producttype + "', " + reselltype + ", " + item + ", " + kategori + ", " + status + ", " + page + ", " + row + ", " + excel, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        tgl_pembelian = Convert.ToDateTime(dr["TGL_PEMBELIAN"]).ToString("dd-MM-yyyy"),
                        lokasi_pembelian = dr["LOKASI_PEMBELIAN"].ToString(),
                        invoice_asal = dr["INVOICE_ASAL"].ToString(),
                        harga_pembelian_asal = dr["HARGA_PEMBELIAN_ASAL"].ToString(),
                        keterangan_asal = dr["KETERANGAN_ASAL"].ToString(),
                        tgl_resell = Convert.ToDateTime(dr["TGL_RESELL"]),
                        keterangan_void = dr["KETERANGAN_VOID"].ToString(),
                        lokasi_resell = dr["LOKASI_RESELL"].ToString(),
                        no_resell = dr["NO_RESELL"].ToString(),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        plu = dr["PLU"].ToString(),
                        tipe = dr["TIPE"].ToString(),
                        item = dr["ITEM"].ToString(),
                        kategori = dr["KATEGORI"].ToString(),
                        qty = Convert.ToInt32(dr["Qty"]),
                        harga_resell = Convert.ToDouble(dr["HargaResell"])
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt64(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Add Resell Cross Brand
        public object AddResellCrossBrand(RequestResell rr)
        {
            try
            {
                return new { message = "" };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Get Resell Item Cross Brand By Customer
        public object GetResellItemCrossBrandByCustomer(int idcustomer, string custlama)
        {
            try
            {
                return new { message = "" };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Check PLU

        public object CheckPLUResell(string Nomor, string Brand, string Tipe)
        {
            string message = "";
            try
            {
                if (!_context.StockProductDjs.Any(p => p.Nomor.Equals(Nomor)) && Tipe == "DJ")
                {
                    _openConnection.Execute("exec sp_CopyStockProuctDJ '" + Nomor + "', '" + Brand + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
                }
                else if (!_context.StockProductPgs.Any(p => p.Nomor.Equals(Nomor)) && Tipe == "PG")
                {
                    _openConnection.Execute("exec sp_CopyStockProuctPG '" + Nomor + "', '" + Brand + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
                }
                else if (!_context.StockProductLdStone1Bs.Any(p => p.Nomor.Equals(Nomor)) && Tipe == "LD")
                {
                    _openConnection.Execute("exec sp_CopyStockProuctLD '" + Nomor + "', '" + Brand + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return new { message };
        }
        #endregion
        #region Add PLU DJ
        public object AddPLUDJ(RequestAddPLUDJ product, string Username, int IDBrand)
        {
            string message = "";
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    if (!_context.StockProductDjs.Any(p => p.Nomor.Equals(product.Nomor)))
                    {
                        StockProductDJ dj = new StockProductDJ();

                        //User-Info
                        dj.Operator = Username;
                        dj.OperatorTgl = DateTime.Now;
                        dj.Nomor = product.Nomor;
                        dj.Draft = false;
                        dj.DraftDate = null;
                        dj.Legacy = 1;
                        dj.Sumber = 0;
                        dj.Tgl = DateTime.Today;
                        dj.Approval = Username;
                        dj.ApprovalTgl = DateTime.Now;
                        dj.ReturnProduct = false;
                        dj.StatusPenjualan = 1;
                        dj.StatusLebur = false;

                        _context.StockProductDjs.Add(dj);
                        _context.SaveChanges();

                        decimal StoneWeight = 0;
                        int StoneQty = 0;

                        #region Add Stone
                        if (product.Stone != null || product.Stone.Count > 0)
                        {
                            foreach (var x in product.Stone)
                            {
                                if (x.Type.Equals("1A"))
                                {
                                    StockProductDJ_Stone1A stone = new();

                                    stone.Idform = dj.Id;
                                    stone.Idstone = x.IDStone;

                                    stone.TotalButir = x.Butir;
                                    stone.TotalCarat = x.Carat;
                                    stone.CaratButir = stone.TotalButir > 0 ? stone.TotalCarat / stone.TotalButir : 0;

                                    stone.DimensiP = x.DimensiP;
                                    stone.DimensiL = x.DimensiL;
                                    stone.DimensiT = x.DimensiT;
                                    stone.CertificateNumber = x.GIA.ToUpper();

                                    _context.StockProductDjStone1As.Add(stone);

                                    StoneWeight += x.Carat * 0.2m;
                                    StoneQty += x.Butir;
                                }
                                else if (x.Type.Equals("1B"))
                                {
                                    StockProductDJ_Stone1B stone = new();

                                    stone.Idform = dj.Id;
                                    stone.Idstone = x.IDStone;

                                    stone.TotalButir = x.Butir;
                                    stone.TotalCarat = x.Carat;
                                    stone.CaratButir = stone.TotalButir > 0 ? stone.TotalCarat / stone.TotalButir : 0;

                                    stone.DimensiP = x.DimensiP;
                                    stone.DimensiL = x.DimensiL;
                                    stone.DimensiT = x.DimensiT;
                                    stone.Gia = x.GIA.ToUpper();

                                    _context.StockProductDjStone1Bs.Add(stone);

                                    StoneWeight += x.Carat * 0.2m;
                                    StoneQty += x.Butir;
                                }
                                else if (x.Type.Equals("2"))
                                {
                                    StockProductDJ_Stone2 stone = new();

                                    stone.Idform = dj.Id;
                                    stone.Idstone = x.IDStone;

                                    stone.TotalButir = x.Butir;
                                    stone.TotalCarat = x.Carat;
                                    stone.CaratButir = stone.TotalButir > 0 ? stone.TotalCarat / stone.TotalButir : 0;

                                    stone.DimensiP = x.DimensiP;
                                    stone.DimensiL = x.DimensiL;
                                    stone.DimensiT = x.DimensiT;
                                    stone.Gia = x.GIA.ToUpper();

                                    _context.StockProductDjStone2s.Add(stone);

                                    StoneWeight += x.Carat * 0.2m;
                                    StoneQty += x.Butir;
                                }
                                else if (x.Type.Equals("3"))
                                {
                                    StockProductDJ_Stone3 stone = new();

                                    stone.Idform = dj.Id;
                                    stone.Idstone = x.IDStone;

                                    stone.TotalButir = x.Butir;
                                    stone.TotalCarat = x.Carat;
                                    stone.CaratButir = stone.TotalButir > 0 ? stone.TotalCarat / stone.TotalButir : 0;

                                    stone.DimensiP = x.DimensiP;
                                    stone.DimensiL = x.DimensiL;
                                    stone.DimensiT = x.DimensiT;
                                    stone.Gia = x.GIA.ToUpper();

                                    _context.StockProductDjStone3s.Add(stone);

                                    StoneWeight += x.Carat * 0.2m;
                                    StoneQty += x.Butir;
                                }
                                else if (x.Type.Equals("4"))
                                {
                                    StockProductDJ_Stone4 stone = new();

                                    stone.Idform = dj.Id;
                                    stone.Idstone = x.IDStone;

                                    stone.TotalButir = x.Butir;
                                    stone.TotalCarat = x.Carat;
                                    stone.CaratButir = stone.TotalButir > 0 ? stone.TotalCarat / stone.TotalButir : 0;

                                    stone.DimensiP = x.DimensiP;
                                    stone.DimensiL = x.DimensiL;
                                    stone.DimensiT = x.DimensiT;
                                    stone.Gia = x.GIA.ToUpper();

                                    _context.StockProductDjStone4s.Add(stone);

                                    StoneWeight += x.Carat * 0.2m;
                                    StoneQty += x.Butir;
                                }
                                else if (x.Type.Equals("5"))
                                {
                                    StockProductDJ_Stone5 stone = new();

                                    stone.Idform = dj.Id;
                                    stone.Idstone = x.IDStone;

                                    stone.TotalButir = x.Butir;
                                    stone.TotalCarat = x.Carat;
                                    stone.CaratButir = stone.TotalButir > 0 ? stone.TotalCarat / stone.TotalButir : 0;

                                    stone.DimensiP = x.DimensiP;
                                    stone.DimensiL = x.DimensiL;
                                    stone.DimensiT = x.DimensiT;
                                    stone.Gia = x.GIA.ToUpper();

                                    _context.StockProductDjStone5s.Add(stone);

                                    StoneWeight += x.Carat * 0.2m;
                                    StoneQty += x.Butir;
                                }
                            }
                        }
                        #endregion

                        #region CharProduct
                        StockProductDJ_CharProduct charproduct = new StockProductDJ_CharProduct();

                        charproduct.Id = dj.Id;

                        charproduct.ProductItem = product.ProductItem;
                        charproduct.ProductCategory = product.ProductCategory;
                        charproduct.ProductLevel = product.ProductLevel;
                        charproduct.StoneDist = product.StoneDist;
                        charproduct.FrameMaterial = product.FrameMaterial;
                        charproduct.FrameFinishing = product.FrameFinishing;
                        charproduct.FrameColor = product.FrameColor;
                        charproduct.ProcessCons = product.ConsProcess;
                        charproduct.GrossWeight = product.Weight;
                        charproduct.KadarLogam = 75.5m;
                        charproduct.KadarTukaran = 84.5m;
                        charproduct.StoneWeight = StoneWeight;
                        charproduct.StoneQty = StoneQty;
                        charproduct.NettoWeight = product.Weight - StoneWeight;

                        _context.StockProductDjCharProducts.Add(charproduct);
                        _context.SaveChanges();
                        #endregion

                        #region Finishing
                        if (product.Finishing != null || product.Finishing.Count > 0)
                        {
                            foreach (var x in product.Finishing)
                            {
                                StockProductDJ_Finishing finishing = new StockProductDJ_Finishing();

                                finishing.Idform = dj.Id;
                                finishing.Idfinishing = x.ID;

                                _context.StockProductDjFinishings.Add(finishing);
                            }
                        }
                        #endregion

                        #region Pricing
                        PricingDJ(product);
                        #endregion

                        StockLedgerDJ ledger = new();
                        ledger.Idproduct = dj.Id;
                        ledger.TipeLokasi = product.TipeLokasi;
                        ledger.Idlokasi = product.IDLokasi;
                        ledger.NamaLokasi = product.NamaLokasi;
                        ledger.Value = 1;
                        ledger.Remark = 4;
                        ledger.Keterangan = product.Nomor;

                        ledger.Operator = Username;
                        ledger.OperatorTgl = DateTime.Now;

                        _context.StockLedgerDjs.Add(ledger);

                        StockActualDJ stock = new();
                        stock.Idproduct = dj.Id;
                        stock.NamaLokasi = product.NamaLokasi;
                        stock.Idbrand = IDBrand;
                        stock.TipeLokasi = product.TipeLokasi;
                        stock.Idlokasi = product.IDLokasi;
                        stock.Substorage = 1;
                        stock.Keterangan = "Barang Non JAWS";
                        stock.Tgl = dj.Tgl.Value;
                        stock.Nomor = dj.Nomor;
                        stock.InHand = 0;
                        stock.Operator = dj.Operator;
                        stock.OperatorTgl = dj.OperatorTgl.Value;

                        _context.StockActualDjs.Add(stock);
                        _context.SaveChanges();


                        SalesOrder so = new();

                        so.TipeLokasi = product.TipeLokasi;
                        so.Idlokasi = product.IDLokasi;
                        so.Idcustomer = product.IDCustomer;
                        so.CustomerNama = product.NamaCustomer;
                        so.Tgl = product.TglInvoice;
                        so.Draft = false;
                        so.DraftDate = null;
                        so.Operator = Username;
                        so.OperatorTgl = DateTime.Now;
                        so.StatusVoid = false;
                        so.StatusPembayaran = true;
                        so.TotalBayar = product.Harga;

                        _context.SalesOrders.Add(so);
                        _context.SaveChanges();

                        string NOSO = string.Empty;

                        while (string.IsNullOrEmpty(NOSO))
                        {
                            NOSO = GenerateNomorSO(so, IDBrand);
                            if (_context.SalesOrders.Any(p => p.Nomor.Equals(NOSO))) NOSO = String.Empty;
                            else
                            {
                                so.Nomor = NOSO;
                                _context.SaveChanges();
                            }
                        }

                        SalesOrderDJ sodj = new SalesOrderDJ();

                        sodj.Idform = so.Id;
                        sodj.Invoice = product.Invoice;
                        sodj.Idproduct = dj.Id;
                        sodj.ModalRupiah = 0m;
                        sodj.TotalBayar = 0m;
                        sodj.TotalRupiah = 0m;
                        sodj.HargaRupiah = 0m;
                        sodj.Discount = 0m;
                        sodj.DiscountGift = 0m;
                        sodj.DiscountNominal = 0m;
                        sodj.DiscountProgram = 0m;
                        sodj.DiscountProgramNominal = 0m;
                        sodj.DiscountPromo = 0m;
                        sodj.DiscountRound = 0m;
                        sodj.Menominal = 0m;
                        sodj.MeperiodeMax = 0;
                        sodj.MeperiodeMin = 0;
                        sodj.Merumus = 0m;
                        sodj.R1Nominal = 0m;
                        sodj.R1PeriodeMax = 0;
                        sodj.R1PeriodeMin = 0;
                        sodj.R1Rumus = 0m;
                        sodj.R2Nominal = 0m;
                        sodj.R2PeriodeMax = 0;
                        sodj.R2PeriodeMin = 0;
                        sodj.R2Rumus = 0m;
                        sodj.Ti1Nominal = 0m;
                        sodj.Ti1PeriodeMax = 0;
                        sodj.Ti1PeriodeMin = 0;
                        sodj.Ti1Rumus = 0;
                        sodj.Ti2Nominal = 0m;
                        sodj.Ti2PeriodeMax = 0;
                        sodj.Ti2PeriodeMin = 0;
                        sodj.Ti2Rumus = 0;
                        sodj.Ti3Nominal = 0m;
                        sodj.Ti3PeriodeMax = 0;
                        sodj.Ti3PeriodeMin = 0;
                        sodj.Ti3Rumus = 0;
                        sodj.StatusResell = 0;
                        sodj.TotalBayar = product.Harga;

                        _context.SalesOrderDjs.Add(sodj);
                        _context.SaveChanges();

                        int DesignCategory = _context.CharDesignCategories.SingleOrDefault(p => p.NamaKode.Equals("N")).Id;
                        int DesignConcept = _context.CharDesignConcepts.SingleOrDefault(p => p.NamaKode.Equals("N")).Id;
                        int DesignProcess = _context.CharDesignProcesses.SingleOrDefault(p => p.NamaKode.Equals("N")).Id;
                        int TargetAge = _context.CharTargetAges.SingleOrDefault(p => p.NamaKode.Equals("N")).Id;
                        int TargetGender = _context.CharTargetGenders.SingleOrDefault(p => p.NamaKode.Equals("N")).Id;

                        StockProductDJ_CharDesign design = new StockProductDJ_CharDesign();

                        design.Id = dj.Id;
                        design.DesignCategory = DesignCategory;
                        design.DesignConcept = DesignConcept;
                        design.DesignProcess = DesignProcess;
                        design.TargetAge = TargetAge;
                        design.TargetGender = TargetGender;

                        _context.StockProductDjCharDesigns.Add(design);

                        StockProductDJ_Costing costing = new StockProductDJ_Costing();

                        costing.Id = dj.Id;
                        costing.MountingNo = 0m;
                        costing.MountingRo = 0m;
                        costing.OngkosLain = 0m;
                        costing.OngkosLainCogs = 0m;
                        costing.Pembagi = 1;
                        costing.Setting = 0m;
                        costing.TotalBiaya = 0m;
                        costing.TotalRate = 1m;
                        costing.TotalRupiah = 0m;
                        costing.UnitPrice = 0m;
                        costing.Finishing = 0m;
                        costing.Frame = 0m;

                        _context.StockProductDjCostings.Add(costing);
                        _context.SaveChanges();
                    }
                    else
                    {
                        message = "PLU sudah pernah ditambahkan. Silahkan cek data Sales Order!";
                        //_openConnection.Execute("exec sp_ThrowError 'PLU sudah pernah ditambahkan. Silahkan cek data Sales Order!'", _connectionStrings.ConnectionStrings.Cnn_DB);
                    }
                    tempContext.Commit();
                }
                catch (Exception ex)
                {
                    tempContext.Rollback();
                    message = _common.ReturnError();
                    //_openConnection.Execute("exec sp_ThrowError '" + message + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
            return new { message };
        }
        #endregion
        #region Add PLU PG
        public object AddPLUPG(RequestAddPLUPG product, string Username, int IDBrand)
        {
            string message = "";
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockProductPG pg = _context.StockProductPgs.SingleOrDefault(p => p.Nomor == product.Nomor && p.Legacy == 1);
                    if (pg == null)
                    {
                        insertPG(product, Username, IDBrand);
                    }
                    else
                    {
                        _context.Remove(pg);
                        _context.SaveChanges();

                        insertPG(product, Username, IDBrand);
                    }
                    tempContext.Commit();
                }
                catch (Exception ex)
                {
                    tempContext.Rollback();
                    message = _common.ReturnError();
                }
            }
            return new { message };
        }
        #endregion
        #region Add PLU LD
        public object AddPLULD(RequestAddPLULD product, string Username, int IDBrand)
        {
            string message = "";
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockProductLD_Stone1B ld = _context.StockProductLdStone1Bs.SingleOrDefault(p => p.Nomor == product.Nomor);
                    if (ld == null)
                    {
                        insertLD(product, Username, IDBrand);
                    }
                    else
                    {
                        _context.Remove(ld);
                        _context.SaveChanges();

                        insertLD(product, Username, IDBrand);
                    }
                    tempContext.Commit();
                }
                catch (Exception ex)
                {
                    tempContext.Rollback();
                    message = _common.ReturnError();
                }
            }
            return new { message };
        }
        #endregion
        #region Delete PLU DJ
        public object DeletePLUDJ(string nomor)
        {
            string message = "";
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockProductDJ dj = _context.StockProductDjs.SingleOrDefault(p => p.Nomor == nomor);
                    if (dj == null)
                    {
                        message = "Data Not Found.";
                    }
                    else
                    {
                        deleteDJ(dj.Id);
                    }
                    tempContext.Commit();
                }
                catch (Exception ex)
                {
                    tempContext.Rollback();
                    message = _common.ReturnError();
                }
            }
            return new { message };
        }
        #endregion
        #region Delete PLU PG
        public object DeletePLUPG(string nomor)
        {
            string message = "";
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockProductPG pg = _context.StockProductPgs.SingleOrDefault(p => p.Nomor == nomor);
                    if (pg == null)
                    {
                        message = "Data Not Found.";
                    }
                    else
                    {
                        deletePG(pg.Id);
                    }
                    tempContext.Commit();
                }
                catch (Exception ex)
                {
                    tempContext.Rollback();
                    message = _common.ReturnError();
                }
            }
            return new { message };
        }
        #endregion
        #region Delete PLU LD
        public object DeletePLULD(string nomor)
        {
            string message = "";
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockProductLD_Stone1B ld = _context.StockProductLdStone1Bs.SingleOrDefault(p => p.Nomor == nomor);
                    if (ld == null)
                    {
                        message = "Anda Koplak";
                    }
                    else
                    {
                        deleteLD(ld.Id);
                    }
                    tempContext.Commit();
                }
                catch (Exception ex)
                {
                    tempContext.Rollback();
                    message = _common.ReturnError();
                }
            }
            return new { message };
        }
        #endregion
        #region Generate Nomor SO
        private string GenerateNomorSO(SalesOrder so, int IDBrand)
        {
            string prefix = "SO";
            int docnumberlength = 21;
            int Tahun = so.Tgl.Value.Year;
            int Tahun2 = Convert.ToInt32(so.Tgl.Value.Year.ToString().Substring(2, 2));
            int Bulan = so.Tgl.Value.Month;
            int Nomor = 1;
            string Brand = _context.CompanyBrands.Single(p => p.Id == IDBrand).NamaKode;

            try
            {
                var s = (from a in _context.SalesOrders.Where(p =>
                         p.Nomor.Length == docnumberlength
                         && p.Nomor.Substring(0, (prefix.Length)) == prefix
                         && p.Nomor.Substring(3, 1) == Brand
                         && !string.IsNullOrEmpty(p.Nomor)
                         && Convert.ToInt32(p.Nomor.Substring(11, 2)) == Tahun2
                         && Convert.ToInt32(p.Nomor.Substring(14, 2)) == Bulan
                         && p.Nomor.Substring(5, 1) == "" + so.TipeLokasi.Value.ToString() + ""
                         && p.Nomor.Substring(7, 3) == "" + so.Idlokasi.Value.ToString().PadLeft(3, '0') + "")
                         orderby (a.Nomor.Substring(17, 4)) descending
                         select a).FirstOrDefault();

                if (s.Nomor != null) { Nomor = Convert.ToInt32(s.Nomor.Substring(17, 4)) + 1; }
            }
            catch
            {
                return null;
            }

            return prefix + "/" + Brand + "/" + so.TipeLokasi.Value.ToString() + "/" + so.Idlokasi.Value.ToString().PadLeft(3, '0') + "/" + Tahun.ToString().Substring(2, 2) + "/" + Bulan.ToString().PadLeft(2, '0') + "/" + Nomor.ToString().PadLeft(4, '0');
        }
        #endregion
        #region Pricing DJ
        private void PricingDJ(RequestAddPLUDJ product)
        {
            StockProductDJ dj = _context.StockProductDjs.Include(p => p.StockProductDJ_Stone1As)
                .Include(p => p.StockProductDJ_Stone1Bs)
                .Include(p => p.StockProductDJ_Stone2s)
                .Include(p => p.StockProductDJ_Stone3s)
                .Include(p => p.StockProductDJ_Stone4s)
                .Include(p => p.StockProductDJ_Stone5s)
                .Include(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharProductItem)
                .Include(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharProductCategory)
                .Include(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharProductLevel)
                .Include(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharStoneDist)
                .Include(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharProcessCon)
                .Include(p => p.StockProductDJ_Finishings)
                .Include(p => p.StockProductDJ_PricingMU)
                .SingleOrDefault(p => p.Nomor.Equals(product.Nomor));

            decimal Setting = 0m;
            decimal BiayaFinishing = 0m;
            decimal TotalModal = 0m;

            #region Stone
            #region Stone1A
            foreach (var stone in dj.StockProductDJ_Stone1As)
            {
                StonePricing1A prc = _context.StonePricing1As.SingleOrDefault(p => p.Id == stone.Idstone);
                StoneCosting1A cost = _context.StoneCosting1As.SingleOrDefault(p => p.Id == stone.Idstone);
                if (prc == null || cost == null) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                else
                {
                    if (!prc.Harga.HasValue || !prc.ApprovalTgl.HasValue) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                    else
                    {
                        //Harga
                        stone.HargaSatuan = prc.Harga.Value;
                        stone.HargaTotal = stone.HargaSatuan * stone.TotalCarat;

                        stone.HargaSatuanM = cost.Harga.Value;
                        stone.HargaTotalM = stone.HargaSatuanM * stone.TotalCarat;

                        //Tgl. Efektif
                        stone.Efektif = prc.ApprovalTgl.Value;

                        //Setting
                        decimal OngkosPB = _common.GetOngkosPB(dj.StockProductDJ_CharProduct.CharProductItem.NamaKode, dj.StockProductDJ_CharProduct.CharStoneDist.NamaKode, "1A", stone.Idstone, stone.TotalButir, stone.TotalCarat);
                        stone.Setting = OngkosPB;
                        Setting += OngkosPB;

                        //Commit
                        _context.SaveChanges();
                    }
                }
            }
            #endregion
            #region Stone1B
            foreach (var stone in dj.StockProductDJ_Stone1Bs)
            {
                StonePricing1B prc = _context.StonePricing1Bs.SingleOrDefault(p => p.Id == stone.Idstone);
                StoneCosting1B cost = _context.StoneCosting1Bs.SingleOrDefault(p => p.Id == stone.Idstone);
                if (prc == null || cost == null) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                else
                {
                    if (!prc.Harga.HasValue || !prc.ApprovalTgl.HasValue) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                    else
                    {
                        //Harga
                        stone.HargaSatuan = prc.Harga.Value;
                        stone.HargaTotal = stone.HargaSatuan * stone.TotalCarat;

                        stone.HargaSatuanM = cost.Harga.Value;
                        stone.HargaTotalM = stone.HargaSatuanM * stone.TotalCarat;

                        //Tgl. Efektif
                        stone.Efektif = prc.ApprovalTgl.Value;

                        //Setting
                        decimal OngkosPB = _common.GetOngkosPB(dj.StockProductDJ_CharProduct.CharProductItem.NamaKode, dj.StockProductDJ_CharProduct.CharStoneDist.NamaKode, "1B", stone.Idstone, stone.TotalButir, stone.TotalCarat);
                        stone.Setting = OngkosPB;
                        Setting += OngkosPB;

                        //Commit
                        _context.SaveChanges();
                    }
                }
            }
            #endregion
            #region Stone2
            foreach (var stone in dj.StockProductDJ_Stone2s)
            {
                StonePricing2 prc = _context.StonePricing2s.SingleOrDefault(p => p.Id == stone.Idstone);
                StoneCosting2 cost = _context.StoneCosting2s.SingleOrDefault(p => p.Id == stone.Idstone);
                if (prc == null || cost == null) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                else
                {
                    if (!prc.Harga.HasValue || !prc.ApprovalTgl.HasValue) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                    else
                    {
                        //Harga
                        stone.HargaSatuan = prc.Harga.Value;
                        stone.HargaTotal = stone.HargaSatuan * stone.TotalCarat;

                        stone.HargaSatuanM = cost.Harga.Value;
                        stone.HargaTotalM = stone.HargaSatuanM * stone.TotalCarat;

                        //Tgl. Efektif
                        stone.Efektif = prc.ApprovalTgl.Value;

                        //Setting
                        decimal OngkosPB = _common.GetOngkosPB(dj.StockProductDJ_CharProduct.CharProductItem.NamaKode, dj.StockProductDJ_CharProduct.CharStoneDist.NamaKode, "2", stone.Idstone, stone.TotalButir, stone.TotalCarat);
                        stone.Setting = OngkosPB;
                        Setting += OngkosPB;

                        //Commit
                        _context.SaveChanges();
                    }
                }
            }
            #endregion
            #region Stone3
            foreach (var stone in dj.StockProductDJ_Stone3s)
            {
                StonePricing3 prc = _context.StonePricing3s.SingleOrDefault(p => p.Id == stone.Idstone);
                StoneCosting3 cost = _context.StoneCosting3s.SingleOrDefault(p => p.Id == stone.Idstone);
                if (prc == null || cost == null) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                else
                {
                    if (!prc.Harga.HasValue || !prc.ApprovalTgl.HasValue) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                    else
                    {
                        //Harga
                        stone.HargaSatuan = prc.Harga.Value;
                        stone.HargaTotal = stone.HargaSatuan * stone.TotalCarat;

                        stone.HargaSatuanM = cost.Harga.Value;
                        stone.HargaTotalM = stone.HargaSatuanM * stone.TotalCarat;

                        //Tgl. Efektif
                        stone.Efektif = prc.ApprovalTgl.Value;

                        //Setting
                        decimal OngkosPB = _common.GetOngkosPB(dj.StockProductDJ_CharProduct.CharProductItem.NamaKode, dj.StockProductDJ_CharProduct.CharStoneDist.NamaKode, "3", stone.Idstone, stone.TotalButir, stone.TotalCarat);
                        stone.Setting = OngkosPB;
                        Setting += OngkosPB;

                        //Commit
                        _context.SaveChanges();
                    }
                }
            }
            #endregion
            #region Stone4
            foreach (var stone in dj.StockProductDJ_Stone4s)
            {
                StonePricing4 prc = _context.StonePricing4s.SingleOrDefault(p => p.Id == stone.Idstone);
                StoneCosting4 cost = _context.StoneCosting4s.SingleOrDefault(p => p.Id == stone.Idstone);
                if (prc == null || cost == null) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                else
                {
                    if (!prc.Harga.HasValue || !prc.ApprovalTgl.HasValue) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                    else
                    {
                        //Harga
                        stone.HargaSatuan = prc.Harga.Value;
                        stone.HargaTotal = stone.HargaSatuan * stone.TotalCarat;

                        stone.HargaSatuanM = cost.Harga.Value;
                        stone.HargaTotalM = stone.HargaSatuanM * stone.TotalCarat;

                        //Tgl. Efektif
                        stone.Efektif = prc.ApprovalTgl.Value;

                        //Setting
                        decimal OngkosPB = _common.GetOngkosPB(dj.StockProductDJ_CharProduct.CharProductItem.NamaKode, dj.StockProductDJ_CharProduct.CharStoneDist.NamaKode, "4", stone.Idstone, stone.TotalButir, stone.TotalCarat);
                        stone.Setting = OngkosPB;
                        Setting += OngkosPB;

                        //Commit
                        _context.SaveChanges();
                    }
                }
            }
            #endregion
            #region Stone5
            foreach (var stone in dj.StockProductDJ_Stone5s)
            {
                StonePricing5 prc = _context.StonePricing5s.SingleOrDefault(p => p.Id == stone.Idstone);
                StoneCosting5 cost = _context.StoneCosting5s.SingleOrDefault(p => p.Id == stone.Idstone);
                if (prc == null || cost == null) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                else
                {
                    if (!prc.Harga.HasValue || !prc.ApprovalTgl.HasValue) _openConnection.Execute("exec sp_ThrowError 'Costing/Pricing batu belum terdaftar, Silahkan hubungi team IT'", _connectionStrings.ConnectionStrings.Cnn_DB);
                    else
                    {
                        //Harga
                        stone.HargaSatuan = prc.Harga.Value;
                        stone.HargaTotal = stone.HargaSatuan * stone.TotalCarat;

                        stone.HargaSatuanM = cost.Harga.Value;
                        stone.HargaTotalM = stone.HargaSatuanM * stone.TotalCarat;

                        //Tgl. Efektif
                        stone.Efektif = prc.ApprovalTgl.Value;

                        //Setting
                        decimal OngkosPB = _common.GetOngkosPB(dj.StockProductDJ_CharProduct.CharProductItem.NamaKode, dj.StockProductDJ_CharProduct.CharStoneDist.NamaKode, "5", stone.Idstone, stone.TotalButir, stone.TotalCarat);
                        stone.Setting = OngkosPB;
                        Setting += OngkosPB;

                        //Commit
                        _context.SaveChanges();
                    }
                }
            }
            #endregion
            #endregion

            #region Finishing
            foreach (var finishing in dj.StockProductDJ_Finishings)
            {
                //Pricing
                var prc_ff = _context.PricingTableFfs.SingleOrDefault(p =>
                    p.Iditem == dj.StockProductDJ_CharProduct.ProductItem &&
                    p.Idfinishing == finishing.Idfinishing &&
                    p.Biaya.HasValue &&
                    p.ApprovalTgl.HasValue
                    );

                //Pricing - Validasi
                if (prc_ff == null) _openConnection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT - Finishing Fee'", _connectionStrings.ConnectionStrings.Cnn_DB);
                else
                {
                    finishing.Biaya = prc_ff.Biaya.Value;
                    finishing.Efektif = prc_ff.ApprovalTgl.Value;
                    BiayaFinishing += prc_ff.Biaya.Value;

                    //Commit
                    _context.SaveChanges();
                }
            }
            #endregion

            #region Pricing Product
            var prc_tgM = _context.PricingTableTgs.SingleOrDefault(p => p.Id == 1 && p.Harga.HasValue && p.ApprovalTgl.HasValue);

            var prc_tg = _context.PricingTableTgs.SingleOrDefault(p => p.Id == 2 && p.Harga.HasValue && p.ApprovalTgl.HasValue);

            //Pricing - Validasi
            if (prc_tg == null || prc_tgM == null) _openConnection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT - Today Gold Price'", _connectionStrings.ConnectionStrings.Cnn_DB);
            else
            {
                StockProductDJ_PricingProduct pricing = new StockProductDJ_PricingProduct();

                pricing.Id = dj.Id;

                //Gold Price
                pricing.GoldRate = prc_tg.Harga.Value;
                pricing.EfektifGold = prc_tg.ApprovalTgl.Value;

                //Informasi Berat
                pricing.Netto = dj.StockProductDJ_CharProduct.NettoWeight;
                pricing.Kadar = dj.StockProductDJ_CharProduct.KadarTukaran;

                //Total
                pricing.TotalProduct = pricing.GoldRate * pricing.Netto * (pricing.Kadar / (decimal)100);
                pricing.TotalStone1A = Convert.ToDecimal(dj.StockProductDJ_Stone1As.Where(p => p.HargaTotal.HasValue).Sum(p => p.HargaTotal));
                pricing.TotalStone1B = Convert.ToDecimal(dj.StockProductDJ_Stone1Bs.Where(p => p.HargaTotal.HasValue).Sum(p => p.HargaTotal));
                pricing.TotalStone2 = Convert.ToDecimal(dj.StockProductDJ_Stone2s.Where(p => p.HargaTotal.HasValue).Sum(p => p.HargaTotal));
                pricing.TotalStone3 = Convert.ToDecimal(dj.StockProductDJ_Stone3s.Where(p => p.HargaTotal.HasValue).Sum(p => p.HargaTotal));
                pricing.TotalStone4 = Convert.ToDecimal(dj.StockProductDJ_Stone4s.Where(p => p.HargaTotal.HasValue).Sum(p => p.HargaTotal));
                pricing.TotalStone5 = Convert.ToDecimal(dj.StockProductDJ_Stone5s.Where(p => p.HargaTotal.HasValue).Sum(p => p.HargaTotal));
                pricing.Total = pricing.TotalProduct + Convert.ToDecimal(pricing.TotalStone1A) + Convert.ToDecimal(pricing.TotalStone1B) + Convert.ToDecimal(pricing.TotalStone2) + Convert.ToDecimal(pricing.TotalStone3) + Convert.ToDecimal(pricing.TotalStone4) + Convert.ToDecimal(pricing.TotalStone5);
                TotalModal += pricing.Total;

                //Commit
                _context.StockProductDjPricingProducts.Add(pricing);
                _context.SaveChanges();

                //Costing
                StockProductDJ_CostingProduct costing = new StockProductDJ_CostingProduct();

                costing.Id = dj.Id;

                //Gold Price
                costing.GoldRate = prc_tgM.Harga.Value;
                costing.EfektifGold = prc_tgM.ApprovalTgl.Value;

                //Informasi Berat
                costing.Netto = dj.StockProductDJ_CharProduct.NettoWeight;
                costing.Kadar = dj.StockProductDJ_CharProduct.KadarTukaran;

                //Total
                costing.TotalProduct = costing.GoldRate * costing.Netto * (costing.Kadar / (decimal)100);
                costing.TotalStone1A = Convert.ToDecimal(dj.StockProductDJ_Stone1As.Where(p => p.HargaTotalM.HasValue).Sum(p => p.HargaTotalM));
                costing.TotalStone1B = Convert.ToDecimal(dj.StockProductDJ_Stone1Bs.Where(p => p.HargaTotalM.HasValue).Sum(p => p.HargaTotalM));
                costing.TotalStone2 = Convert.ToDecimal(dj.StockProductDJ_Stone2s.Where(p => p.HargaTotalM.HasValue).Sum(p => p.HargaTotalM));
                costing.TotalStone3 = Convert.ToDecimal(dj.StockProductDJ_Stone3s.Where(p => p.HargaTotalM.HasValue).Sum(p => p.HargaTotalM));
                costing.TotalStone4 = Convert.ToDecimal(dj.StockProductDJ_Stone4s.Where(p => p.HargaTotalM.HasValue).Sum(p => p.HargaTotalM));
                costing.TotalStone5 = Convert.ToDecimal(dj.StockProductDJ_Stone5s.Where(p => p.HargaTotalM.HasValue).Sum(p => p.HargaTotalM));
                costing.Total = costing.TotalProduct + Convert.ToDecimal(costing.TotalStone1A) + Convert.ToDecimal(costing.TotalStone1B) + Convert.ToDecimal(costing.TotalStone2) + Convert.ToDecimal(costing.TotalStone3) + Convert.ToDecimal(costing.TotalStone4) + Convert.ToDecimal(costing.TotalStone5);

                //Commit
                _context.StockProductDjCostingProducts.Add(costing);
                _context.SaveChanges();
            }
            #endregion

            #region Pricing Biaya
            var prc_fm = _context.PricingTableFms.SingleOrDefault(p =>
            p.Idbrand == _connectionStrings.AppConfig.Brand &&
            p.Iditem == dj.StockProductDJ_CharProduct.ProductItem &&
            p.Idcons == dj.StockProductDJ_CharProduct.ProcessCons &&
            p.Biaya.HasValue &&
            p.Pembagi.HasValue &&
            p.ApprovalTgl.HasValue);

            var prc_fs = _context.PricingTableFs.SingleOrDefault(p => p.Id == 1 && p.Biaya.HasValue && p.ApprovalTgl.HasValue);

            var prc_us = _context.PricingTableUs.SingleOrDefault(p => p.Id == 1 && p.Harga.HasValue && p.ApprovalTgl.HasValue);

            //Pricing - Validasi
            if (prc_fm == null) _openConnection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT - Mounting Fee'", _connectionStrings.ConnectionStrings.Cnn_DB);
            if (prc_fs == null) _openConnection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT - Finishing Fee'", _connectionStrings.ConnectionStrings.Cnn_DB);
            if (prc_us == null) _openConnection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT - USD Rate Costing'", _connectionStrings.ConnectionStrings.Cnn_DB);

            if (prc_fm != null || prc_fm != null || prc_us != null)
            {
                StockProductDJ_PricingBiaya biaya = new StockProductDJ_PricingBiaya();

                biaya.Id = dj.Id;

                //Informasi
                biaya.NamaBrand = "Calculator";
                biaya.NamaItem = dj.StockProductDJ_CharProduct.CharProductItem.Nama;
                biaya.NamaCons = dj.StockProductDJ_CharProduct.CharProcessCon.Nama;

                //Mounting
                biaya.Mounting = prc_fm.Biaya.Value;
                biaya.MountingNo = prc_fm.InputNo.Value;
                biaya.MountingRo = prc_fm.InputRo.Value;
                biaya.Setting = Setting;

                //Finishing
                biaya.Finishing = BiayaFinishing;

                //Total
                biaya.TotalRupiah = biaya.Mounting + biaya.Setting + biaya.Finishing;
                biaya.TotalRate = prc_us.Harga.Value;
                biaya.Total = biaya.TotalRupiah / biaya.TotalRate;
                TotalModal += biaya.Total;

                //Tgl. Efektif
                biaya.EfektifMounting = prc_fm.ApprovalTgl.Value;
                biaya.EfektifSetting = prc_fs.ApprovalTgl.Value;
                biaya.EfektifRate = prc_us.ApprovalTgl.Value;

                //Commit
                _context.StockProductDjPricingBiayas.Add(biaya);
                _context.SaveChanges();
            }
            #endregion

            #region MarkUp
            var prc_mu = _context.PricingTableMus.SingleOrDefault(p =>
            p.Idcategory == dj.StockProductDJ_CharProduct.ProductCategory &&
            p.Idlevel == dj.StockProductDJ_CharProduct.ProductLevel &&
            p.Iddist == dj.StockProductDJ_CharProduct.StoneDist &&
            p.Persen.HasValue &&
            p.ApprovalTgl.HasValue);

            var prc_us_mu = _context.PricingTableUs.SingleOrDefault(p => p.Id == 2 && p.Harga.HasValue && p.ApprovalTgl.HasValue);

            if (prc_mu == null) _openConnection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT - MarkUp'", _connectionStrings.ConnectionStrings.Cnn_DB);
            if (prc_us == null) _openConnection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT - USD Rate Pricing'", _connectionStrings.ConnectionStrings.Cnn_DB);

            if (prc_mu != null || prc_us != null)
            {
                StockProductDJ_PricingMU mu = new StockProductDJ_PricingMU();

                mu.Id = dj.Id;

                //Informasi
                mu.NamaCategory = dj.StockProductDJ_CharProduct.CharProductCategory.Nama;
                mu.NamaLevel = dj.StockProductDJ_CharProduct.CharProductLevel.Nama;
                mu.NamaDist = dj.StockProductDJ_CharProduct.CharStoneDist.Nama;

                //Modal
                mu.ModalUsd = TotalModal;
                mu.ModalRate = prc_us.Harga.Value;
                mu.ModalRupiah = mu.ModalUsd * mu.ModalRate;

                //Mark-Up
                mu.Mu = prc_mu.Persen.Value;

                decimal OngkosLain = 0m;

                //Harga Final
                mu.HargaUsd = (TotalToMarkUp(dj.StockProductDJ_PricingProduct) * ((100m + mu.Mu) / (decimal)100)) + Convert.ToDecimal(dj.StockProductDJ_PricingProduct.TotalStone1B);
                mu.HargaRupiah = (TotalToMarkUp(dj.StockProductDJ_PricingProduct) * ((100m + mu.Mu) / (decimal)100)) + Convert.ToDecimal(dj.StockProductDJ_PricingProduct.TotalStone1B) * mu.ModalRate + OngkosLain;
                decimal HargaRupiah = (TotalToMarkUp(dj.StockProductDJ_PricingProduct) * ((100m + mu.Mu) / (decimal)100)) + Convert.ToDecimal(dj.StockProductDJ_PricingProduct.TotalStone1B) * mu.ModalRate + OngkosLain;
                mu.HargaRupiahRound = Math.Ceiling(HargaRupiah / 10000) * 10000;



                //Tgl. Efektif
                mu.EfektifRate = prc_us.ApprovalTgl.Value;

                //Commit
                _context.StockProductDjPricingMus.Add(mu);
                _context.SaveChanges();
            }
            #endregion

            #region Segmen
            bool ok = true;

            //Pricing - Validasi
            ok = checkSegmen(dj.StockProductDJ_CharProduct);

            //Process
            if (!ok) _openConnection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT - Pricing Segmen'", _connectionStrings.ConnectionStrings.Cnn_DB);
            else
            {
                //Product Value
                decimal harga = dj.StockProductDJ_PricingMU.HargaUsd;
                //decimal carat = product.StoneCarat;

                decimal carat = 0m;

                try
                {
                    carat = (from p in _context.StockProductDjStone1As where p.Idform == dj.Id select new { Carat = p.CaratButir }).Union
                                (from p in _context.StockProductDjStone1Bs where p.Idform == dj.Id select new { Carat = p.CaratButir }).Union
                                (from p in _context.StockProductDjStone2s where p.Idform == dj.Id select new { Carat = p.CaratButir }).Union
                                (from p in _context.StockProductDjStone3s where p.Idform == dj.Id select new { Carat = p.CaratButir }).Union
                                (from p in _context.StockProductDjStone4s where p.Idform == dj.Id select new { Carat = p.CaratButir }).Union
                                (from p in _context.StockProductDjStone5s where p.Idform == dj.Id select new { Carat = p.CaratButir }).Max(p => p.Carat);
                }
                catch { }

                //Parameter
                int IDSegmen = 1;
                int SegmenSistem = 0;
                decimal SegmenMinimum = 0;
                DateTime EfektifSegmen = DateTime.Now;

                //SELECT
                var rs = from p in _context.PricingTableSses
                         where
                             p.Idcategory == dj.StockProductDJ_CharProduct.ProductCategory &&
                             p.Idlevel == dj.StockProductDJ_CharProduct.ProductLevel &&
                             p.Iddist == dj.StockProductDJ_CharProduct.StoneDist && p.CharProductSegmen.NamaKode != "NN"
                         orderby p.Minimum
                         select p;

                foreach (var r in rs)
                {
                    if ((r.SegmenSistem == 0 && harga >= r.Minimum.Value) ||
                        (r.SegmenSistem == 1 && carat >= r.Minimum.Value))
                    {

                        IDSegmen = r.Idsegmen;
                        SegmenSistem = r.SegmenSistem;
                        SegmenMinimum = r.Minimum.Value;
                        EfektifSegmen = r.ApprovalTgl.Value;
                    }
                }

                StockProductDJ_PricingSegmen n = new StockProductDJ_PricingSegmen();

                n.Id = dj.Id;
                n.ProductSegmen = IDSegmen;

                //Informasi
                n.NamaCategory = dj.StockProductDJ_CharProduct.CharProductCategory.Nama;
                n.NamaLevel = dj.StockProductDJ_CharProduct.CharProductLevel.Nama;
                n.NamaDist = dj.StockProductDJ_CharProduct.CharStoneDist.Nama;

                //Segmen
                n.SegmenSistem = SegmenSistem;
                n.SegmenMinimum = SegmenMinimum;

                //Harga dan Carat
                n.HargaUsd = harga;
                n.TotalCarat = carat;

                //Tgl. Efektif
                n.EfektifSegmen = EfektifSegmen;

                ///Commit
                _context.StockProductDjPricingSegmen.Add(n);
                _context.SaveChanges();

            }
            #endregion
        }
        #endregion
        #region Total To Mark Up
        private decimal TotalToMarkUp(StockProductDJ_PricingProduct pricing)
        {
            return pricing.TotalProduct + Convert.ToDecimal(pricing.TotalStone1A) + Convert.ToDecimal(pricing.TotalStone2) + Convert.ToDecimal(pricing.TotalStone3) + Convert.ToDecimal(pricing.TotalStone4) + Convert.ToDecimal(pricing.TotalStone5);
        }
        #endregion
        #region Check Segmen
        private bool checkSegmen(StockProductDJ_CharProduct product)
        {
            bool ok = true;

            var rs = from p in _context.PricingTableSses
                     where
                         p.Idcategory == product.ProductCategory &&
                         p.Idlevel == product.ProductLevel &&
                         p.Iddist == product.StoneDist && p.CharProductSegmen.NamaKode != "NN"
                     select p;

            foreach (var r in rs)
            {
                if (!r.Minimum.HasValue || !r.ApprovalTgl.HasValue)
                {
                    ok = false;
                    break;
                }
            }

            return ok;
        }
        #endregion
        #region Insert PG
        private void insertPG(RequestAddPLUPG product, string Username, int IDBrand)
        {
            var gold = _context.PricingTableTgs.SingleOrDefault(p => p.Id == 3);
            var rate = _context.PricingTableUs.SingleOrDefault(p => p.Id == 2);

            decimal GoldPrice = gold.Harga.Value;
            decimal Rate = Convert.ToDecimal(rate.Harga);

            decimal OngkosPGFixed = 0m;
            decimal MarginPG = 0m;
            decimal KadarTukaranBeli = 82m;
            decimal KadarTukaranJual = 82m;
            decimal SelisihMargin = KadarTukaranBeli - KadarTukaranJual;

            decimal TotalBerat = 1 * product.Weight;
            decimal OngkosR = (MarginPG + SelisihMargin) / 100 * OngkosPGFixed * TotalBerat;
            decimal OngkosM = (KadarTukaranBeli - product.KadarLogam) / 100 * GoldPrice * TotalBerat * Rate;
            decimal OngkosRUSD = (MarginPG + SelisihMargin) / 100 * OngkosPGFixed * TotalBerat / Rate;
            decimal OngkosMUSD = (KadarTukaranBeli - product.KadarLogam) / 100 * GoldPrice * TotalBerat;
            decimal Harga = product.KadarLogam / 100 * GoldPrice * Rate * TotalBerat;
            decimal HargaUSD = product.KadarLogam / 100 * GoldPrice * TotalBerat;
            decimal TotalHarga = OngkosM + Harga;
            decimal TotalHargaJual = OngkosR + Harga;
            decimal TotalHargaUSD = OngkosMUSD + HargaUSD;
            decimal TotalHargaJualUSD = OngkosRUSD + HargaUSD;

            decimal TotalBerat24 = TotalBerat * (KadarTukaranBeli / 100);
            decimal TotalHarga24 = TotalBerat24 * GoldPrice * Rate;

            StockProductPG pgnew = new StockProductPG()
            {
                Idbrand = IDBrand,
                Nomor = product.Nomor,
                NomorSertifikat = product.NoCert,
                NettoWeight = TotalBerat,
                GrossWeight = TotalBerat,
                Draft = false,
                DraftDate = DateTime.Now,
                Approval = Username,
                ApprovalTgl = DateTime.Now,
                Tgl = DateTime.Now,
                TglTjt = DateTime.Now,
                Keterangan = product.Keterangan,
                ProductItem = product.ProductItem,
                ProductLevel = product.GoldLevel,
                Model = product.GoldModel,
                TargetAge = product.TargetAge,
                FrameColor = product.FrameColor,
                KadarLogam = product.KadarLogam,
                NoTtb = "",
                HumanStock = 0,
                Legacy = 1,
                FixRate = false,
                StatusLebur = false,
                ReturnProduct = false,
                Operator = Username,
                OperatorTgl = DateTime.Now,
                StatusPenjualan = 1,
                ImgPicture = "",
                HumanStockNama = "NON JAWS",
                KodeBarang = "NON JAWS",
                NamaBarang = "NON JAWS",
                SupplierNama = "",
                SupplierSj = "",
                Idsupplier = 1,
                KadarTukaranBeli = KadarTukaranBeli,
                KadarTukaranJual = KadarTukaranJual,
                MountingM = OngkosM,
                MountingR = OngkosR,
                MountingMusd = OngkosMUSD,
                MountingRusd = OngkosRUSD,
                GoldRate = GoldPrice,
                EfektifGold = Convert.ToDateTime(gold.ApprovalTgl),
                TotalRate = Convert.ToDecimal(rate.Harga),
                EfektifTotalRate = Convert.ToDateTime(rate.ApprovalTgl),
                Harga = Harga,
                HargaUsd = HargaUSD,
                TotalHarga = TotalHarga,
                TotalHargaUsd = TotalHargaUSD,
                TotalHargaJual = TotalHargaJual,
                TotalHargaJualUsd = TotalHargaJualUSD,
                TotalHarga24 = TotalHarga24,
            };
            _context.StockProductPgs.Add(pgnew);
            _context.SaveChanges();

            // Ledger 
            StockLedgerPg l = new StockLedgerPg();

            // Value (See Library DB - Ledger for Value and Remark)
            decimal Value = 1;
            int Remark = 4;
            string Keterangan = product.Nomor; // Commonly filled by document number or id 
                                               //if (Keterangan.Trim() == "") Keterangan = DL.LedgerRemark(Remark); // dont change!

            //Input
            l.Idproduct = pgnew.Id;
            l.TipeLokasi = product.TipeLokasi;
            l.Idlokasi = product.IDLokasi;
            l.NamaLokasi = product.NamaLokasi;
            l.Value = Value;
            l.Remark = Remark;
            l.Keterangan = Keterangan;
            l.Operator = Username;
            l.OperatorTgl = DateTime.Now;

            //Commit
            _context.StockLedgerPgs.Add(l);
            _context.SaveChanges();

            StockActualPG actpg = pgnew.StockActualPG;
            if (actpg == null)
            {
                StockActualPG stock = new StockActualPG();
                stock.Idproduct = pgnew.Id;
                stock.NamaLokasi = product.NamaLokasi;
                stock.Idbrand = IDBrand;
                stock.TipeLokasi = product.TipeLokasi;
                stock.Idlokasi = product.IDLokasi;
                stock.Substorage = 1;
                stock.Keterangan = "Barang Non JAWS";
                stock.Tgl = pgnew.Tgl.Value;
                stock.Nomor = pgnew.Nomor;
                stock.InHand = 1;
                stock.Operator = pgnew.Operator;
                stock.OperatorTgl = pgnew.OperatorTgl.Value;
                _context.StockActualPgs.Add(stock);
                _context.SaveChanges();
            }
            else
            {
                actpg.Idproduct = pgnew.Id;
                actpg.NamaLokasi = product.NamaLokasi;
                actpg.Idbrand = IDBrand;
                actpg.TipeLokasi = product.TipeLokasi;
                actpg.Idlokasi = product.IDLokasi;
                actpg.Substorage = 1;
                actpg.Keterangan = "Barang Non JAWS";
                actpg.Tgl = pgnew.Tgl.Value;
                actpg.Nomor = pgnew.Nomor;
                actpg.InHand = 1;
                actpg.Operator = pgnew.Operator;
                actpg.OperatorTgl = pgnew.OperatorTgl.Value;
                _context.SaveChanges();
            }

            SalesOrder so = new SalesOrder();

            //Location
            so.Idlokasi = product.IDLokasi;
            so.TipeLokasi = product.TipeLokasi;
            so.Idcustomer = product.IDCustomer;
            so.CustomerNama = product.NamaCustomer;
            so.Tgl = Convert.ToDateTime(product.TglInvoice);

            //Status
            so.Draft = false;
            so.DraftDate = null;

            //User-Info
            so.Operator = Username;
            so.OperatorTgl = DateTime.Now;
            so.StatusVoid = false;
            so.StatusPembayaran = true;
            so.TotalBayar = Convert.ToDecimal(product.Harga);

            //Commit
            _context.SalesOrders.Add(so);
            _context.SaveChanges();

            string NOSO = string.Empty;

            while (string.IsNullOrEmpty(NOSO))
            {
                NOSO = GenerateNomorSO(so, IDBrand);
                if (_context.SalesOrders.Any(p => p.Nomor.Equals(NOSO))) NOSO = string.Empty;
                else
                {
                    so.Nomor = NOSO;
                    _context.SaveChanges();
                }
            }

            SalesOrderPG nsodtl = new SalesOrderPG();

            nsodtl.Idform = so.Id;
            nsodtl.Idproduct = pgnew.Id;
            nsodtl.Invoice = string.IsNullOrEmpty(product.Invoice) ? "" : product.Invoice;
            nsodtl.ModalRupiah = 0m;
            nsodtl.TotalBayar = 0m;
            nsodtl.TotalRupiah = 0m;
            nsodtl.HargaRupiah = 0m;
            nsodtl.Discount = 0m;
            nsodtl.DiscountGift = 0m;
            nsodtl.DiscountNominal = 0m;
            nsodtl.DiscountProgram = 0m;
            nsodtl.DiscountProgramNominal = 0m;
            nsodtl.DiscountPromo = 0m;
            nsodtl.DiscountRound = 0m;
            nsodtl.MeperiodeMax = 0;
            nsodtl.MeperiodeMin = 0;
            nsodtl.Merumus = 0m;
            nsodtl.Ti1PeriodeMin = 0;
            nsodtl.Ti1Rumus = 0;
            nsodtl.Ti2PeriodeMin = 0;
            nsodtl.Ti2Rumus = 0;
            nsodtl.StatusResell = 0;
            nsodtl.TotalBayar = Convert.ToDecimal(product.Harga);
            nsodtl.BeratTimbang = Convert.ToDecimal(product.Weight);
            nsodtl.Tgpjual = Convert.ToDecimal(product.Tgp);

            _context.SalesOrderPgs.Add(nsodtl);
            _context.SaveChanges();
        }
        #endregion
        #region Insert LD
        private void insertLD(RequestAddPLULD product, string Username, int IDBrand)
        {
            StockProductLD prod = new StockProductLD()
            {
                Keterangan = "Non Jaws",
                Tgl = DateTime.Now,
                Nomor = "",
                Supplier = 0,
                SupplierNama = "",
                SupplierNomor = "",
                RequestOutlet = 0,
                RequestOutletNama = "",
                RequestCustomer = 0,
                RequestCustomerNama = "",
                HumanStock = 0,
                HumanStockNama = "",
                Operator = Username,
                OperatorTgl = DateTime.Now,
                Approval = Username,
                ApprovalTgl = DateTime.Now,
                CatatanManager = "",
                ImgPicture = "",
                ReturnProduct = false,
                StatusPenjualan = 1,
                Draft = false,
            };

            _context.StockProductLds.Add(prod);
            _context.SaveChanges();


            StockProductLD_Stone1B stone = new StockProductLD_Stone1B()
            {
                Nomor = product.Nomor,
                Idform = prod.Id,
                Idstone = product.stone1B.IDStone,
                TotalButir = product.stone1B.Butir,
                TotalCarat = product.stone1B.Carat,
                CaratButir = product.stone1B.Carat / product.stone1B.Butir,
                DimensiL = product.stone1B.DimensiL,
                DimensiP = product.stone1B.DimensiP,
                DimensiT = product.stone1B.DimensiT,
                HargaSatuan = 0m,
                HargaTotal = 0m,
                Gia = product.stone1B.GIA,
                HargaInputH = 0m,
                HargaInputP = 0m,
                HargaSatuanM = 0m,
                HargaTotalM = 0m,
                Efektif = DateTime.Now,
                Setting = 0m,
                ReturnProduct = false,
                StatusPenjualan = 1,
                ProductItem = 67
            };

            _context.StockProductLdStone1Bs.Add(stone);
            _context.SaveChanges();

            StockActualLD_Stone1B stock = new StockActualLD_Stone1B()
            {
                Idproduct = stone.Id,
                NamaLokasi = product.NamaLokasi,
                Idbrand = IDBrand,
                TipeLokasi = product.TipeLokasi,
                Idlokasi = product.IDLokasi,
                Substorage = 1,
                Keterangan = "Barang NON Jaws",
                Tgl = DateTime.Now,
                Nomor = product.Nomor,
                InHand = 0,
                Operator = Username,
                OperatorTgl = DateTime.Now,
            };

            _context.StockActualLdStone1Bs.Add(stock);
            _context.SaveChanges();

            // Ledger
            // Value (See Library DB - Ledger for Value and Remark)
            decimal Value = 1; // 1 : in , -1 : out
            int Remark = 11; // See Library DB - Ledger
            string Keterangan = product.Nomor; // Commonly filled by document number or id 

            StockLedgerLd l = new StockLedgerLd()
            {
                Idproduct = stone.Id,
                TipeLokasi = product.TipeLokasi,
                Idlokasi = product.IDLokasi,
                NamaLokasi = product.NamaLokasi,
                Value = Value,
                Remark = Remark,
                Keterangan = Keterangan,

                //User-Info
                Operator = Username,
                OperatorTgl = DateTime.Now
            };

            //Commit
            _context.StockLedgerLds.Add(l);
            _context.SaveChanges();

            SalesOrder n = new SalesOrder
            {
                //Location
                Idlokasi = product.IDLokasi,
                TipeLokasi = product.TipeLokasi,
                Idcustomer = product.IDCustomer,
                CustomerNama = product.NamaCustomer,
                Tgl = product.TglInvoice,

                //Status
                Draft = false,
                DraftDate = null,

                //User-Info
                Operator = Username,
                OperatorTgl = DateTime.Now,
                StatusVoid = false,
                StatusPembayaran = true,
                TotalBayar = product.Harga
            };

            //Commit
            _context.SalesOrders.Add(n);
            _context.SaveChanges();

            string NOSO = string.Empty;

            while (string.IsNullOrEmpty(NOSO))
            {
                NOSO = GenerateNomorSO(n, IDBrand);
                if (_context.SalesOrders.Any(p => p.Nomor.Equals(NOSO))) NOSO = String.Empty;
                else
                {
                    n.Nomor = NOSO;
                    _context.SaveChanges();
                }
            }

            SalesOrderLD nsodtl = new SalesOrderLD()
            {
                Idform = n.Id,
                Invoice = product.Invoice,
                Idproduct = stone.Id,
                ModalRupiah = 0m,
                TotalBayar = product.Harga,
                TotalRupiah = 0m,
                HargaRupiah = 0m,
                Discount = 0m,
                DiscountGift = 0m,
                DiscountNominal = 0m,
                DiscountProgram = 0m,
                DiscountProgramNominal = 0m,
                DiscountPromo = 0m,
                DiscountRound = 0m,
                MeperiodeMax = 0,
                MeperiodeMin = 0,
                Merumus = 0m,
                Ti1PeriodeMin = 0,
                Ti1Rumus = 0,
                Ti2PeriodeMin = 0,
                Ti2Rumus = 0,
                StatusResell = 0
            };

            _context.SalesOrderLds.Add(nsodtl);
            _context.SaveChanges();
        }
        #endregion
        #region Delete DJ
        private void deleteDJ(int id)
        {
            StockProductDJ dj = _context.StockProductDjs.SingleOrDefault(d => d.Id == id && d.Legacy == 1);
            if (dj != null)
            {
                List<DocQCDJ> docqcdj = _context.DocQcdjs.Where(p => p.Idproduct == dj.Id).ToList();
                List<ResellDJ> resdj = _context.ResellDjs.Where(p => p.Idproduct == dj.Id).ToList();
                List<SalesOrderDJ> sodj = _context.SalesOrderDjs.Where(p => p.Idproduct == dj.Id).ToList();

                List<StockIncomingDJ_Product> indj = _context.StockIncomingDjProducts.Where(p => p.Idproduct == dj.Id).ToList();
                List<StockIncomingDJ> ind = new List<StockIncomingDJ>();
                foreach (var y in indj)
                {
                    ind.Add(_context.StockIncomingDjs.SingleOrDefault(p => p.Id == y.Idform));
                }
                List<StockOutgoingDJ_Product> outgdj = _context.StockOutgoingDjProducts.Where(p => p.Idproduct == dj.Id).ToList();
                List<StockOutgoingDJ> outg = new List<StockOutgoingDJ>();
                foreach (var y in outgdj)
                {
                    outg.Add(_context.StockOutgoingDjs.SingleOrDefault(p => p.Id == y.Idform));
                }

                List<StockProductDJ_Stone1A> stone1As = _context.StockProductDjStone1As.Where(p => p.Idform == dj.Id).ToList();
                List<StockProductDJ_Stone1B> stone1Bs = _context.StockProductDjStone1Bs.Where(p => p.Idform == dj.Id).ToList();
                List<StockProductDJ_Stone2> stone2s = _context.StockProductDjStone2s.Where(p => p.Idform == dj.Id).ToList();
                List<StockProductDJ_Stone3> stone3s = _context.StockProductDjStone3s.Where(p => p.Idform == dj.Id).ToList();
                List<StockProductDJ_Stone4> stone4s = _context.StockProductDjStone4s.Where(p => p.Idform == dj.Id).ToList();
                List<StockProductDJ_Stone5> stone5s = _context.StockProductDjStone5s.Where(p => p.Idform == dj.Id).ToList();
                List<StockProductDJ_CharDesign> design = _context.StockProductDjCharDesigns.Where(p => p.Id == dj.Id).ToList();
                List<StockProductDJ_CharProduct> product = _context.StockProductDjCharProducts.Where(p => p.Id == dj.Id).ToList();
                List<StockProductDJ_Costing> costing = _context.StockProductDjCostings.Where(p => p.Id == dj.Id).ToList();
                List<StockProductDJ_CostingProduct> costingproduct = _context.StockProductDjCostingProducts.Where(p => p.Id == dj.Id).ToList();
                List<StockProductDJ_PricingBiaya> pricingbiaya = _context.StockProductDjPricingBiayas.Where(p => p.Id == dj.Id).ToList();
                List<StockProductDJ_PricingMU> pricingmu = _context.StockProductDjPricingMus.Where(p => p.Id == dj.Id).ToList();
                List<StockProductDJ_PricingProduct> pricingproduct = _context.StockProductDjPricingProducts.Where(p => p.Id == dj.Id).ToList();
                List<StockProductDJ_PricingSegmen> pricingsegmen = _context.StockProductDjPricingSegmen.Where(p => p.Id == dj.Id).ToList();
                List<StockActualDJ> actual = _context.StockActualDjs.Where(p => p.Idproduct == dj.Id).ToList();

                _context.DocQcdjs.RemoveRange(docqcdj);
                _context.ResellDjs.RemoveRange(resdj);
                _context.SalesOrderDjs.RemoveRange(sodj);
                _context.StockIncomingDjProducts.RemoveRange(indj);
                _context.StockIncomingDjs.RemoveRange(ind);
                _context.StockOutgoingDjProducts.RemoveRange(outgdj);
                _context.StockOutgoingDjs.RemoveRange(outg);

                _context.StockProductDjStone1As.RemoveRange(stone1As);
                _context.StockProductDjStone1Bs.RemoveRange(stone1Bs);
                _context.StockProductDjStone2s.RemoveRange(stone2s);
                _context.StockProductDjStone3s.RemoveRange(stone3s);
                _context.StockProductDjStone4s.RemoveRange(stone4s);
                _context.StockProductDjStone5s.RemoveRange(stone5s);

                _context.StockProductDjCharDesigns.RemoveRange(design);
                _context.StockProductDjCharProducts.RemoveRange(product);
                _context.StockProductDjCostings.RemoveRange(costing);

                _context.StockProductDjCostingProducts.RemoveRange(costingproduct);
                _context.StockProductDjPricingBiayas.RemoveRange(pricingbiaya);
                _context.StockProductDjPricingMus.RemoveRange(pricingmu);

                _context.StockProductDjPricingProducts.RemoveRange(pricingproduct);
                _context.StockProductDjPricingSegmen.RemoveRange(pricingsegmen);
                _context.StockActualDjs.RemoveRange(actual);
                _context.StockProductDjs.Remove(dj);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Delete PG
        private void deletePG(int id)
        {
            StockProductPG pg = _context.StockProductPgs.SingleOrDefault(d => d.Id == id && d.Legacy == 1);
            if (pg != null)
            {
                List<DocQCPG> docqcpg = _context.DocQcpgs.Where(p => p.Idproduct == pg.Id).ToList();
                List<ResellPG> respg = _context.ResellPgs.Where(p => p.Idproduct == pg.Id).ToList();
                List<SalesOrderPG> sopg = _context.SalesOrderPgs.Where(p => p.Idproduct == pg.Id).ToList();
                List<StockIncomingPG_Product> inpg = _context.StockIncomingPgProducts.Where(p => p.Idproduct == pg.Id).ToList();
                List<StockIncomingPG> ind = new List<StockIncomingPG>();
                foreach (var y in inpg)
                {
                    ind.Add(_context.StockIncomingPgs.SingleOrDefault(p => p.Id == y.Idform));
                }
                List<StockOutgoingPG_Product> outgpg = _context.StockOutgoingPgProducts.Where(p => p.Idproduct == pg.Id).ToList();
                List<StockOutgoingPG> outg = new List<StockOutgoingPG>();
                foreach (var y in outgpg)
                {
                    outg.Add(_context.StockOutgoingPgs.SingleOrDefault(p => p.Id == y.Idform));
                }
                List<StockActualPG> actual = _context.StockActualPgs.Where(p => p.Idproduct == pg.Id).ToList();

                _context.DocQcpgs.RemoveRange(docqcpg);
                _context.ResellPgs.RemoveRange(respg);
                _context.SalesOrderPgs.RemoveRange(sopg);
                _context.StockIncomingPgProducts.RemoveRange(inpg);
                _context.StockIncomingPgs.RemoveRange(ind);
                _context.StockOutgoingPgProducts.RemoveRange(outgpg);
                _context.StockOutgoingPgs.RemoveRange(outg);

                _context.StockActualPgs.RemoveRange(actual);
                _context.StockProductPgs.Remove(pg);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Delete LD
        private void deleteLD(int id)
        {
            StockProductLD_Stone1B ld = _context.StockProductLdStone1Bs.SingleOrDefault(d => d.Id == id);
            if (ld != null)
            {
                List<DocQCLD> docqcld = _context.DocQclds.Where(p => p.Idproduct == ld.Id).ToList();
                List<ResellLD> resld = _context.ResellLds.Where(p => p.Idproduct == ld.Id).ToList();
                List<SalesOrderLD> sold = _context.SalesOrderLds.Where(p => p.Idproduct == ld.Id).ToList();
                List<StockIncomingLD_Product> inld = _context.StockIncomingLdProducts.Where(p => p.Idproduct == ld.Id).ToList();
                List<StockIncomingLD> ind = new List<StockIncomingLD>();
                foreach (var y in inld)
                {
                    ind.Add(_context.StockIncomingLds.SingleOrDefault(p => p.Id == y.Idform));
                }
                List<StockOutgoingLD_Product> outgld = _context.StockOutgoingLdProducts.Where(p => p.Idproduct == ld.Id).ToList();
                List<StockOutgoingLD> outg = new List<StockOutgoingLD>();
                foreach (var y in outgld)
                {
                    outg.Add(_context.StockOutgoingLds.SingleOrDefault(p => p.Id == y.Idform));
                }
                List<StockActualLD_Stone1B> actual = _context.StockActualLdStone1Bs.Where(p => p.Idproduct == ld.Id).ToList();
                List<StockProductLD> product = _context.StockProductLds.Where(p => p.Id == ld.Idform).ToList();

                _context.DocQclds.RemoveRange(docqcld);
                _context.ResellLds.RemoveRange(resld);
                _context.SalesOrderLds.RemoveRange(sold);
                _context.StockIncomingLdProducts.RemoveRange(inld);
                _context.StockIncomingLds.RemoveRange(ind);
                _context.StockOutgoingLdProducts.RemoveRange(outgld);
                _context.StockOutgoingLds.RemoveRange(outg);

                _context.StockActualLdStone1Bs.RemoveRange(actual);
                _context.StockProductLdStone1Bs.Remove(ld);
                _context.StockProductLds.RemoveRange(product);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Get Rate Tgp Beli Query
        private decimal GetRateTgpBeliQuery(int idproductpg)
        {
            string query = "EXEC sp_get_pricing_table_tgp_new " + idproductpg + ",'B'";
            decimal goldprice = _openConnection.SingleDecimal(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            return goldprice;
        }
        #endregion
    }
}
