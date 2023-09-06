using Connection.Interface;
using Connection.Models;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Connection.RequestModels.PointOfSales;
using System.Collections;
using System.Net.NetworkInformation;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Connection.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly JAWSDbContext _context;
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        private StampsConfiguration _stampsConfiguration;
        private PaymentRepository _paymentRepository;
        private LakuEmasConfiguration _lakuEmasConfiguration;
        private Common _common;

        public SalesOrderRepository()
        {
            _context = new JAWSDbContext();
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
            _stampsConfiguration = new StampsConfiguration();
            _paymentRepository = new PaymentRepository();
            _lakuEmasConfiguration = new LakuEmasConfiguration();
            _common = new Common();
        }
        #region Get Sales Order By ID
        public object GetSalesOrder(int id, int tipelokasi, int idlokasi)
        {
            try
            {
                string query = "sp_report_sales_order_detail_new";
                DataSet ds = _openConnection.Ds("EXEC " + query + " " + id.ToString() + ", " + tipelokasi + "," + idlokasi + " ", _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable so = ds.Tables[0];
                DataTable item = ds.Tables[1];
                DataTable payment = ds.Tables[2];
                DataTable itemtradein = ds.Tables[3];

                if (so.Rows.Count == 1)
                {
                    List<object> itemso = new List<object>();
                    List<object> itempayment = new List<object>();
                    List<object> itemresell = new List<object>();

                    foreach (DataRow dr in item.Rows)
                    {
                        itemso.Add(new
                        {
                            plu = dr["KODE"].ToString(),
                            tipe = dr["TIPE"].ToString(),
                            item = dr["NAMA"].ToString(),
                            invoice = dr["INVOICE"].ToString(),
                            qty = Convert.ToInt32(dr["QTY"]),
                            harga_rupiah = Convert.ToDouble(dr["HARGARUPIAH"]),
                            discount_normal = Convert.ToDouble(dr["DISCOUNTNORMAL"]),
                            discount_promo = Convert.ToDouble(dr["DISCOUNTPROMO"]),
                            discount_membership = Convert.ToDouble(dr["DISCOUNTMEMBERSHIP"]),
                            discount_voucher = Convert.ToDouble(dr["DISCOUNTVOUCHER"]),
                            discount_bank = Convert.ToDouble(dr["DISCOUNTBANK"]),
                            discount_other = Convert.ToDouble(dr["DISCOUNTOTHER"]),
                            discount_round = Convert.ToDouble(dr["DISCOUNTROUND"]),
                            total_discount = Convert.ToDouble(dr["TOTALDISCOUNT"]),
                            total_bayar = Convert.ToDouble(dr["TOTALBAYAR"]),
                            kode_voucher = dr["KODEVOUCHER"].ToString(),
                            idpromo_bank = Convert.ToInt32(dr["IDPROMO_BANK"])
                        });
                    }

                    foreach (DataRow dr in payment.Rows)
                    {
                        itempayment.Add(new
                        {
                            payment = dr["PAYMENTNAME"].ToString(),
                            card = dr["CARDNAME"].ToString(),
                            program = dr["PROGRAMNAME"].ToString(),
                            edc = dr["EDCNAME"].ToString(),
                            bank = dr["BANKNAME"].ToString(),
                            jenis_cc = dr["JENISKARTUKREDITNAME"].ToString(),
                            cc_number = dr["CCNUMBER"].ToString(),
                            cc_name = dr["CCNAME"].ToString(),
                            nominal = Convert.ToDouble(dr["NOMINAL"]),
                            operator_tgl = Convert.ToDateTime(dr["OPERATORTGL"]).ToString("dd-MM-yyyy hh:mm:ss.fff"),
                            operator_name = dr["OPERATORNAMA"].ToString(),
                            void_reference = dr["VOIDREFERENCE"].ToString(),
                            mdr = Convert.ToDecimal(dr["MDR"]),
                            approval_code = dr["APPROVAL_CODE"].ToString()
                        });
                    }

                    foreach (DataRow dr in itemtradein.Rows)
                    {
                        itemresell.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            plu = dr["KODE"].ToString(),
                            tipe = dr["TIPE"].ToString(),
                            item = dr["NAMA"].ToString(),
                            qty = Convert.ToInt32(dr["QTY"]),
                            weight = Convert.ToDouble(dr["WEIGHT"]),
                            tgp = Convert.ToDouble(dr["TGP"]),
                            harga_jual = Convert.ToDouble(dr["HARGAJUAL"]),
                            harga_acuan = Convert.ToDouble(dr["HARGAACUAN"]),
                            harga_beli = Convert.ToDouble(dr["HARGARUPIAH"]),
                            selisih = dr["SELISIH"].ToString(),
                            usia = dr["USIA"].ToString()
                        });
                    }

                    return new
                    {
                        message = "",
                        data = new
                        {
                            id = Convert.ToInt32(so.Rows[0]["IDSO"]),
                            id_customer = Convert.ToInt32(so.Rows[0]["IDCUSTOMER"]),
                            id_customer_stamps = Convert.ToInt32(so.Rows[0]["IDCUSTOMERSTAMP"]),
                            nomor = so.Rows[0]["NOSO"].ToString(),
                            nomortradein = so.Rows[0]["NOTRADEIN"].ToString(),
                            customer = so.Rows[0]["CUSTOMERNAME"].ToString(),
                            customer_telp = so.Rows[0]["CUSTOMERTELP"].ToString(),
                            given_to = so.Rows[0]["CUSTOMERREFERENCENAME"].ToString(),
                            kode_customer = so.Rows[0]["CUSTOMERCODE"].ToString(),
                            membership = so.Rows[0]["CUSTOMERMEMBERSHIP"].ToString(),
                            sales = so.Rows[0]["SALESNAME"].ToString(),
                            tgl = Convert.ToDateTime(so.Rows[0]["TGLSO"]).ToString("dd-MM-yyyy"),
                            kode_lokasi = so.Rows[0]["STORECODE"].ToString(),
                            nama_lokasi = so.Rows[0]["STORENAME"].ToString(),
                            draft = Convert.ToBoolean(so.Rows[0]["DRAFT"]),
                            status_pembayaran = Convert.ToBoolean(so.Rows[0]["STATUSPEMBAYARAN"]),
                            status_void = Convert.ToBoolean(so.Rows[0]["STATUSVOID"]),
                            operator_nama = so.Rows[0]["OPERATOR"].ToString(),
                            operator_tgl = Convert.ToDateTime(so.Rows[0]["OPERATORTGL"]).ToString("dd-MM-yyyy hh:mm:ss.fff"),
                            keterangan = so.Rows[0]["KETERANGAN"].ToString(),
                            keteranganvoid = so.Rows[0]["KETERANGANVOID"].ToString(),
                            idpromo_event = Convert.ToInt32(so.Rows[0]["IDPROMO_EVENT"]),
                            rate_lei = _lakuEmasConfiguration.GetMiddleRateLEI(),
                            item = itemso,
                            itemtradein = itemresell,
                            payment = itempayment
                        }
                    };
                }
                else
                {
                    return new { message = "Sales Order Tidak Ditemukan." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Get Sales Order Item
        public object GetSalesOrderItemByStore(int tipelokasi, int idlokasi, string kw, string tipeproduct, int idcustomer)
        {
            try
            {
                tipeproduct = string.IsNullOrEmpty(tipeproduct) ? GetTipeProductQuery(kw) : tipeproduct;
                DataTable dt = GetSalesOrderItemByStoreQuery(tipelokasi, idlokasi, kw, tipeproduct, idcustomer);
                List<object> dtobject = new List<object>();
                if (tipeproduct == "PK" || tipeproduct == "SV" || tipeproduct == "CT")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtobject.Add(new
                        {
                            id_product = Convert.ToInt32(dr["ID_PRODUCT"]),
                            nomor = dr["NOMOR"].ToString(),
                            tipe_product = dr["TIPE_PRODUCT"].ToString(),
                            qty = Convert.ToInt32(dr["QTY"]),
                            item = dr["ITEM"].ToString(),
                            modal_rupiah = Convert.ToDouble(dr["MODAL_RUPIAH"]),
                            harga_rupiah = Convert.ToDouble(dr["HARGA_RUPIAH"]),
                            image_picture = _common.ImageCDN(dr["IMAGE"].ToString())
                        });
                    }
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtobject.Add(new
                        {
                            id_product = Convert.ToInt32(dr["ID_PRODUCT"]),
                            nomor = dr["NOMOR"].ToString(),
                            tipe_product = dr["TIPE_PRODUCT"].ToString(),
                            qty = Convert.ToInt32(dr["QTY"]),
                            item = dr["ITEM"].ToString(),
                            modal_rupiah = Convert.ToDouble(dr["MODAL_RUPIAH"]),
                            harga_rupiah = Convert.ToDouble(dr["HARGA_RUPIAH"]),
                            discount_normal = Convert.ToDouble(dr["DISCOUNT_NORMAL"]),
                            discount_normal_nominal = Convert.ToDouble(dr["DISCOUNT_NORMAL_NOMINAL"]),
                            discount_promo = Convert.ToDouble(dr["DISCOUNT_PROMO"]),
                            discount_membership = Convert.ToDouble(dr["DISCOUNT_MEMBERSHIP"]),
                            discount_membership_nominal = Convert.ToDouble(dr["DISCOUNT_MEMBERSHIP_NOMINAL"]),
                            discount_voucher = Convert.ToDouble(dr["DISCOUNT_VOUCHER"]),
                            discount_bank = Convert.ToDouble(dr["DISCOUNT_BANK"]),
                            discount_other = Convert.ToDouble(dr["DISCOUNT_OTHER"]),
                            discount_round = Convert.ToDouble(dr["DISCOUNT_ROUND"]),
                            total_bayar = Convert.ToDouble(dr["TOTAL_BAYAR"]),
                            total_rupiah = Convert.ToDouble(dr["TOTAL_RUPIAH"]),
                            ppn = Convert.ToDouble(dr["PPN"]),
                            ppn_percentage = Convert.ToDouble(dr["PPN_PERCENTAGE"]),
                            nama_promo = dr["NAMA_PROMO"].ToString(),
                            harga_promo = Convert.ToDouble(dr["HARGA_PROMO"]),
                            is_nett = Convert.ToBoolean(dr["IS_NETT"]),
                            gross_weight = Convert.ToDecimal(dr["GROSS_WEIGHT"])
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
        #region ValidationAddSalesOrder
        private object ValidationAddSalesOrder(RequestSalesOrder rso)
        {
            try
            {
                string listdj = ""; string listpg = ""; string listgj = ""; string listld = "";

                if ((rso.sales_order_dj.Count + rso.sales_order_gj.Count + rso.sales_order_pg.Count + rso.sales_order_ld.Count) > 0)
                {
                    foreach (var x in rso.sales_order_dj)
                    {
                        listdj += x.id_product + ",";
                    }

                    foreach (var x in rso.sales_order_pg)
                    {
                        listpg +=  x.id_product + ",";
                    }

                    foreach (var x in rso.sales_order_gj)
                    {
                        listgj += x.id_product + ",";
                    }

                    foreach (var x in rso.sales_order_ld)
                    {
                        listld += x.id_product + ",";
                    }
                    if (listdj.Length > 0) listdj.Remove(listdj.Length - 1, 1);
                    if (listpg.Length > 0) listpg.Remove(listpg.Length - 1, 1);
                    if (listgj.Length > 0) listgj.Remove(listgj.Length - 1, 1);
                    if (listld.Length > 0) listld.Remove(listld.Length - 1, 1);

                    string query = "EXEC sp_validation_insert_pre_sales_order_new " + rso.id_lokasi + ",'" + rso.tipe_lokasi + "'," +
                        " '" + listdj + "', '" + listpg + "', '" + listgj + "', '" + listld + "'";
                    string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    return new { message = result };
                }
                else
                {
                    return new { message = "Item was not found." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Add Sales Order
        public object AddSalesOrder(RequestSalesOrder rso)
        {
            try
            {
                object validation = ValidationAddSalesOrder(rso);
                string errval = validation.GetType().GetProperty("message").GetValue(validation, null).ToString();
                if (errval != "")
                {
                    return new { message = errval };
                }
                else
                {
                    string queryso = "EXEC sp_insert_sales_order_new";
                    string querystart = "DECLARE @TABLE TABLE(ID INT, NO_SO VARCHAR(50), [MESSAGE] VARCHAR(1000)) ";

                    if (rso != null)
                    {
                        querystart = querystart + " INSERT INTO @TABLE(ID, NO_SO, [MESSAGE]) " + queryso +
                            " " + rso.tipe_lokasi +
                            ", " + rso.id_lokasi + "," +
                            " '" + rso.kode_lokasi + "', " + rso.id_customer + "," +
                            " '" + rso.customer_nama + "', " + rso.id_sales + "," +
                            " '" + rso.sales_nama + "', " + rso.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + rso.harga_rupiah + ", " + rso.paid + "," +
                            " " + rso.unpaid + ", " + rso.total_bayar + "," +
                            " " + rso.total_rupiah + ", " + rso.total_bayar + "," +
                            " " + rso.total_rupiah + ", " + rso.total_resell + "," +
                            " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                            " '" + rso.keterangan + "', '" + rso.operator_nama + "'," +
                            " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                            " '" + (rso.trade_in ? 1 : 0) + "', '" + rso.customer_reference_nama + "'," +
                            " '" + rso.e_receipt_hp + "', '" + rso.e_receipt_email + "'," +
                            " '" + (rso.npwp ? 1 : 0).ToString() + "', '" + rso.membership + "'," +
                            " " + rso.id_event + " DECLARE @IDSO INT = (SELECT TOP 1 ID FROM @TABLE) " +
                            " DECLARE @NOMORSO VARCHAR(50) = (SELECT TOP 1 NO_SO FROM @TABLE) ";

                        string querydj = "EXEC sp_insert_sales_order_dj_new";
                        string querypg = "EXEC sp_insert_sales_order_pg_new";
                        string querygj = "EXEC sp_insert_sales_order_gj_new";
                        string queryld = "EXEC sp_insert_sales_order_ld_new";
                        string querypackaging = "EXEC sp_insert_sales_order_packaging_new";
                        string querysouvenir = "EXEC sp_insert_sales_order_souvenir_new";
                        string querycetakan = "EXEC sp_insert_sales_order_cetakan_new";

                        foreach (var dj in rso.sales_order_dj)
                        {
                            querystart += querydj + " @IDSO, " + dj.id_product + "," +
                                " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " " + dj.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + dj.harga_rupiah + "," +
                                " " + dj.discount + ", " + dj.discount_nominal + "," +
                                " " + dj.discount_program + ", " + dj.discount_program_nominal + "," +
                                " " + dj.discount_gift + ", " + dj.discount_round + "," +
                                " " + dj.discount_promo + ", " + dj.total_rupiah + "," +
                                " " + dj.total_bayar + ", " + dj.status_resell + "," +
                                " " + dj.total_dp + ", " + dj.discount_bank + "," +
                                " " + dj.discount_other + ", " + dj.ppn + "," +
                                " " + dj.ppn_percentage + ", " + dj.id_promo_bank + " ";

                            if (dj.sales_voucher != null)
                            {
                                DataTable dt = GetTypeVoucherID(dj.sales_voucher.nomor_voucher);
                                if (dt.Rows.Count == 1)
                                {
                                    string queryv = "EXEC sp_insert_sales_order_voucher_new @IDSO," +
                                    " '" + dj.sales_voucher.nomor_voucher + "','" + dt.Rows[0]["m_type"].ToString() + "','" + dt.Rows[0]["cnamatype"].ToString() + "'," +
                                    " 'DISCOUNT VOUCHER', " + Convert.ToInt64(dj.sales_voucher.nominal) + ",''," +
                                    " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "','" + dj.sales_voucher.operator_nama + "'," +
                                    " " + dj.sales_voucher.product_type + "," + dj.sales_voucher.product_id + " ";
                                    querystart += queryv;
                                }
                            }
                        }

                        foreach (var pg in rso.sales_order_pg)
                        {
                            querystart += querypg + " @IDSO, " + pg.id_product + "," +
                                " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + pg.modal_tgp + "," +
                                " " + pg.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + pg.harga_rupiah + "," +
                                " " + pg.discount + ", " + pg.discount_nominal + "," +
                                " " + pg.discount_program + ", " + pg.discount_program_nominal + "," +
                                " " + pg.discount_gift + ", " + pg.discount_round + "," +
                                " " + pg.discount_promo + ", " + pg.total_rupiah + "," +
                                " " + pg.total_bayar + ", " + pg.status_resell + "," +
                                " " + pg.total_dp + ", " + pg.tgp_jual + "," +
                                " " + pg.berat_timbang.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + pg.discount_bank + "," +
                                " " + pg.discount_other + ", " + pg.ppn + "," +
                                " " + pg.ppn_percentage + ", " + pg.id_promo_bank + " ";

                            if (pg.sales_voucher != null)
                            {
                                DataTable dt = GetTypeVoucherID(pg.sales_voucher.nomor_voucher);
                                if (dt.Rows.Count == 1)
                                {
                                    string queryv = "EXEC sp_insert_sales_order_voucher_new @IDSO," +
                                    " '" + pg.sales_voucher.nomor_voucher + "','" + dt.Rows[0]["m_type"].ToString() + "','" + dt.Rows[0]["cnamatype"].ToString() + "'," +
                                    " 'DISCOUNT VOUCHER', " + Convert.ToInt64(pg.sales_voucher.nominal) + ",''," +
                                    " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "','" + pg.sales_voucher.operator_nama + "'," +
                                    " " + pg.sales_voucher.product_type + "," + pg.sales_voucher.product_id + " ";
                                    querystart += queryv;
                                }
                            }
                        }

                        foreach (var gj in rso.sales_order_gj)
                        {
                            querystart += querygj + " @IDSO, " + gj.id_product + "," +
                                " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " " + gj.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + gj.harga_rupiah + "," +
                                " " + gj.discount + ", " + gj.discount_nominal + "," +
                                " " + gj.discount_program + ", " + gj.discount_program_nominal + "," +
                                " " + gj.discount_gift + ", " + gj.discount_round + "," +
                                " " + gj.discount_promo + ", " + gj.total_rupiah + "," +
                                " " + gj.total_bayar + ", " + gj.status_resell + "," +
                                " " + gj.total_dp + ", " + gj.discount_bank + "," +
                                " " + gj.discount_other + ", " + gj.ppn + "," +
                                " " + gj.ppn_percentage + ", " + gj.id_promo_bank + " ";

                            if (gj.sales_voucher != null)
                            {
                                DataTable dt = GetTypeVoucherID(gj.sales_voucher.nomor_voucher);
                                if (dt.Rows.Count == 1)
                                {
                                    string queryv = "EXEC sp_insert_sales_order_voucher_new @IDSO," +
                                    " '" + gj.sales_voucher.nomor_voucher + "','" + dt.Rows[0]["m_type"].ToString() + "','" + dt.Rows[0]["cnamatype"].ToString() + "'," +
                                    " 'DISCOUNT VOUCHER', " + Convert.ToInt64(gj.sales_voucher.nominal) + ",''," +
                                    " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "','" + gj.sales_voucher.operator_nama + "'," +
                                    " " + gj.sales_voucher.product_type + "," + gj.sales_voucher.product_id + " ";
                                    querystart += queryv;
                                }
                            }
                        }

                        foreach (var ld in rso.sales_order_ld)
                        {
                            querystart += queryld + " @IDSO, " + ld.id_product + "," +
                                " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " " + ld.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + ld.harga_rupiah + "," +
                                " " + ld.discount + ", " + ld.discount_nominal + "," +
                                " " + ld.discount_program + ", " + ld.discount_program_nominal + "," +
                                " " + ld.discount_gift + ", " + ld.discount_round + "," +
                                " " + ld.discount_promo + ", " + ld.total_rupiah + "," +
                                " " + ld.total_bayar + ", " + ld.status_resell + "," +
                                " " + ld.total_dp + ", " + ld.discount_bank + "," +
                                " " + ld.discount_other + ", " + ld.ppn + "," +
                                " " + ld.ppn_percentage + ", " + ld.id_promo_bank + " ";

                            if (ld.sales_voucher != null)
                            {
                                DataTable dt = GetTypeVoucherID(ld.sales_voucher.nomor_voucher);
                                if (dt.Rows.Count == 1)
                                {
                                    string queryv = "EXEC sp_insert_sales_order_voucher_new @IDSO," +
                                    " '" + ld.sales_voucher.nomor_voucher + "','" + dt.Rows[0]["m_type"].ToString() + "','" + dt.Rows[0]["cnamatype"].ToString() + "'," +
                                    " 'DISCOUNT VOUCHER', " + Convert.ToInt64(ld.sales_voucher.nominal) + ",''," +
                                    " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "','" + ld.sales_voucher.operator_nama + "'," +
                                    " " + ld.sales_voucher.product_type + "," + ld.sales_voucher.product_id + " ";
                                    querystart += queryv;
                                }
                            }
                        }

                        foreach (var packaging in rso.sales_order_packaging)
                        {
                            querystart += querypackaging + " @IDSO, " + packaging.id_product + "," +
                                " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " " + packaging.modal_rupiah + ", " + packaging.total_rupiah + ", " + packaging.qty + "," +
                                " " + packaging.total_modal_rupiah + ", " + packaging.id_product_dj + "," +
                                " " + packaging.id_product_pg + ", " + packaging.id_product_gj + ", " +
                                " " + packaging.id_product_ld + " ";
                        }

                        foreach (var souvenir in rso.sales_order_souvenir)
                        {
                            querystart += querysouvenir + " @IDSO, " + souvenir.id_product + "," +
                                " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " " + souvenir.modal_rupiah + ", " + souvenir.total_rupiah + ", " + souvenir.qty + "," +
                                " " + souvenir.total_modal_rupiah + ", " + souvenir.id_product_dj + "," +
                                " " + souvenir.id_product_pg + ", " + souvenir.id_product_gj + ", " +
                                " " + souvenir.id_product_ld + ", " + souvenir.tipe_product + ", " + souvenir.id_product_souvenir + " ";
                        }

                        foreach (var cetakan in rso.sales_order_cetakan)
                        {
                            querystart += querycetakan + " @IDSO, " + cetakan.id_product + "," +
                                " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " " + cetakan.modal_rupiah + ", " + cetakan.total_rupiah + ", " + cetakan.qty + "," +
                                " " + cetakan.total_modal_rupiah + " ";
                        }

                        int count = rso.resell_dj.Count + rso.resell_pg.Count + rso.resell_gj.Count + rso.resell_ld.Count;
                        string querystartresell = "";
                        if (count > 0)
                        {
                            string queryresell = "EXEC sp_insert_resell_new";
                            string queryreselldj = "EXEC sp_insert_resell_dj_new";
                            string queryresellpg = "EXEC sp_insert_resell_pg_new";
                            string queryresellgj = "EXEC sp_insert_resell_gj_new";
                            string queryresellld = "EXEC sp_insert_resell_ld_new";
                            querystartresell += "DECLARE @TABLETRADEIN TABLE(ID INT, NO_RO VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";

                            querystartresell = querystartresell + " INSERT INTO @TABLETRADEIN(ID, NO_RO, [MESSAGE]) " + queryresell +
                            " " + rso.id_customer + "," +
                            " '" + rso.customer_nama + "'," +
                            " " + rso.tipe_lokasi + "," +
                            " " + rso.id_lokasi + "," +
                            " '" + rso.kode_lokasi + "'," +
                            " " + rso.total_resell + "," +
                            " '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + rso.keterangan + "'," +
                            " '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + rso.operator_nama + "'," +
                            " " + 1.ToString() + "," +
                            " " + 0.ToString() + "," +
                            " " + rso.id_sales + "," +
                            " '" + rso.sales_nama + "'," +
                            " '" + rso.kode_customer_lama + "'," +
                            " 'CMK'" +
                            " DECLARE @IDRO INT = (SELECT TOP 1 ID FROM @TABLETRADEIN) " +
                            " DECLARE @NOMORRO VARCHAR(50) = (SELECT TOP 1 NO_RO FROM @TABLETRADEIN) ";

                            foreach (var reselldj in rso.resell_dj)
                            {
                                querystartresell += queryreselldj + " @IDRO," +
                                " " + reselldj.id_sales_order + "," +
                                " " + reselldj.id_product + "," +
                                " " + reselldj.id_doc_qc + "," +
                                " '" + reselldj.nomor + "'," +
                                " " + reselldj.harga_acuan + "," +
                                " " + reselldj.harga_rupiah + "," +
                                " " + reselldj.nilai_trade_in + "," +
                                " '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                " '" + reselldj.operator_nama + "'," +
                                " " + reselldj.modal_usd + "";
                            }

                            foreach (var resellpg in rso.resell_pg)
                            {
                                querystartresell += queryresellpg + " @IDRO," +
                                " " + resellpg.id_sales_order + "," +
                                " " + resellpg.id_product + "," +
                                " " + resellpg.id_doc_qc + "," +
                                " '" + resellpg.nomor + "'," +
                                " " + resellpg.harga_acuan + "," +
                                " " + resellpg.harga_rupiah + "," +
                                " " + resellpg.nilai_trade_in + "," +
                                " '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                " '" + resellpg.operator_nama + "'," +
                                " " + resellpg.berat_timbang + "," +
                                " " + resellpg.tgp + "";
                            }

                            foreach (var resellgj in rso.resell_gj)
                            {
                                querystartresell += queryresellgj + " @IDRO," +
                                " " + resellgj.id_sales_order + "," +
                                " " + resellgj.id_product + "," +
                                " " + resellgj.id_doc_qc + "," +
                                " '" + resellgj.nomor + "'," +
                                " " + resellgj.harga_acuan + "," +
                                " " + resellgj.harga_rupiah + "," +
                                " " + resellgj.nilai_trade_in + "," +
                                " '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                " '" + resellgj.operator_nama + "'," +
                                " " + resellgj.berat_timbang + "," +
                                " " + resellgj.tgp + "";
                            }

                            foreach (var resellld in rso.resell_ld)
                            {
                                querystartresell += queryresellld + " @IDRO," +
                                " " + resellld.id_sales_order + "," +
                                " " + resellld.id_product + "," +
                                " " + resellld.id_doc_qc + "," +
                                " '" + resellld.nomor + "'," +
                                " " + resellld.harga_acuan + "," +
                                " " + resellld.harga_rupiah + "," +
                                " " + resellld.nilai_trade_in + "," +
                                " '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                " '" + resellld.operator_nama + "'";
                            }
                            string queryupdatero = " EXEC sp_insert_trade_in_new @IDSO,@IDRO," +
                                " " + rso.tipe_lokasi + ", " + rso.id_lokasi + "," +
                                " '" + rso.kode_lokasi + "', " + rso.id_customer + "," +
                                " '" + rso.customer_nama + "', " + rso.id_sales + "," +
                                " '" + rso.sales_nama + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " '" + rso.keterangan + "','" + rso.operator_nama + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " '" + rso.kode_customer_lama + "'";
                            querystartresell += " " + queryupdatero;
                        }

                        string queryupdateso = " EXEC sp_update_total_discount_new @IDSO";
                        string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + queryupdateso + " " + querystartresell + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_SO], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                        DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                        string res = result.Rows[0]["MESSAGE"].ToString();
                        int idso = Convert.ToInt32(result.Rows[0]["ID"]);
                        string noso = result.Rows[0]["NO_SO"].ToString();
                        UpdateRateSalesOrderPG(idso);
                        return new { message = res, id = idso, no = noso };
                    }
                    else
                    {
                        return new { message = "Failed. Data Not Found" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Update Sales Order
        public object UpdateSalesOrder(RequestSalesOrder rso, int idsolama)
        {
            try
            {
                if (idsolama > 0)
                {
                    string queryvalidation = "EXEC sp_validation_update_sales_order_new " + idsolama;
                    string resultvalidation = _openConnection.SingleString(queryvalidation, _connectionStrings.ConnectionStrings.Cnn_DB);
                    if (resultvalidation != "")
                    {
                        return new { message = resultvalidation };
                    }
                    else
                    {
                        string querydeleteso = "EXEC sp_delete_sales_order_new " + idsolama;
                        string queryso = "EXEC sp_insert_sales_order_new ";
                        string querystart = "DECLARE @TABLE TABLE(ID INT, NO_SO VARCHAR(50), [MESSAGE] VARCHAR(1000)) ";

                        if (rso != null)
                        {
                            querystart = querystart + querydeleteso + " INSERT INTO @TABLE(ID, NO_SO, [MESSAGE]) " + queryso +
                                " " + rso.tipe_lokasi +
                                ", " + rso.id_lokasi + "," +
                                " '" + rso.kode_lokasi + "', " + rso.id_customer + "," +
                                " '" + rso.customer_nama + "', " + rso.id_sales + "," +
                                " '" + rso.sales_nama + "', " + rso.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                                " " + rso.harga_rupiah + ", " + rso.paid + "," +
                                " " + rso.unpaid + ", " + rso.total_bayar + "," +
                                " " + rso.total_rupiah + ", " + rso.total_bayar + "," +
                                " " + rso.total_rupiah + ", " + rso.total_resell + "," +
                                " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " '" + rso.keterangan + "', '" + rso.operator_nama + "'," +
                                " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                " '" + (rso.trade_in ? 1 : 0) + "', '" + rso.customer_reference_nama + "'," +
                                " '" + rso.e_receipt_hp + "', '" + rso.e_receipt_email + "'," +
                                " '" + (rso.npwp ? 1 : 0).ToString() + "', '" + rso.membership + "'," +
                                " '0' DECLARE @IDSO INT = (SELECT TOP 1 ID FROM @TABLE) " +
                                " DECLARE @NOMORSO VARCHAR(50) = (SELECT TOP 1 NO_SO FROM @TABLE) ";

                            string querydj = "EXEC sp_insert_sales_order_dj_new";
                            string querypg = "EXEC sp_insert_sales_order_pg_new";
                            string querygj = "EXEC sp_insert_sales_order_gj_new";
                            string queryld = "EXEC sp_insert_sales_order_ld_new";
                            string querypackaging = "EXEC sp_insert_sales_order_packaging_new";
                            string querysouvenir = "EXEC sp_insert_sales_order_souvenir_new";
                            string querycetakan = "EXEC sp_insert_sales_order_cetakan_new";

                            foreach (var dj in rso.sales_order_dj)
                            {
                                querystart += querydj + " @IDSO, " + dj.id_product + "," +
                                    " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                    " " + dj.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + dj.harga_rupiah + "," +
                                    " " + dj.discount + ", " + dj.discount_nominal + "," +
                                    " " + dj.discount_program + ", " + dj.discount_program_nominal + "," +
                                    " " + dj.discount_gift + ", " + dj.discount_round + "," +
                                    " " + dj.discount_promo + ", " + dj.total_rupiah + "," +
                                    " " + dj.total_bayar + ", " + dj.status_resell + "," +
                                    " " + dj.total_dp + ", " + dj.discount_bank + "," +
                                    " " + dj.discount_other + ", " + dj.ppn + "," +
                                    " " + dj.ppn_percentage + ", " + dj.id_promo_bank + " ";

                                if (dj.sales_voucher != null)
                                {
                                    DataTable dt = GetTypeVoucherID(dj.sales_voucher.nomor_voucher);
                                    if (dt.Rows.Count == 1)
                                    {
                                        string queryv = "EXEC sp_insert_sales_order_voucher_new @IDSO," +
                                        " '" + dj.sales_voucher.nomor_voucher + "','" + dt.Rows[0]["m_type"].ToString() + "','" + dt.Rows[0]["cnamatype"].ToString() + "'," +
                                        " 'DISCOUNT VOUCHER', " + Convert.ToInt64(dj.sales_voucher.nominal) + ",''," +
                                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "','" + dj.sales_voucher.operator_nama + "'," +
                                        " " + dj.sales_voucher.product_type + "," + dj.sales_voucher.product_id + " ";
                                        querystart += queryv;
                                    }
                                }
                            }

                            foreach (var pg in rso.sales_order_pg)
                            {
                                querystart += querypg + " @IDSO, " + pg.id_product + "," +
                                    " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + pg.modal_tgp + "," +
                                    " " + pg.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + pg.harga_rupiah + "," +
                                    " " + pg.discount + ", " + pg.discount_nominal + "," +
                                    " " + pg.discount_program + ", " + pg.discount_program_nominal + "," +
                                    " " + pg.discount_gift + ", " + pg.discount_round + "," +
                                    " " + pg.discount_promo + ", " + pg.total_rupiah + "," +
                                    " " + pg.total_bayar + ", " + pg.status_resell + "," +
                                    " " + pg.total_dp + ", " + pg.tgp_jual + "," +
                                    " " + pg.berat_timbang.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + pg.discount_bank + "," +
                                    " " + pg.discount_other + ", " + pg.ppn + "," +
                                    " " + pg.ppn_percentage + ", " + pg.id_promo_bank + " ";

                                if (pg.sales_voucher != null)
                                {
                                    DataTable dt = GetTypeVoucherID(pg.sales_voucher.nomor_voucher);
                                    if (dt.Rows.Count == 1)
                                    {
                                        string queryv = "EXEC sp_insert_sales_order_voucher_new @IDSO," +
                                        " '" + pg.sales_voucher.nomor_voucher + "','" + dt.Rows[0]["m_type"].ToString() + "','" + dt.Rows[0]["cnamatype"].ToString() + "'," +
                                        " 'DISCOUNT VOUCHER', " + Convert.ToInt64(pg.sales_voucher.nominal) + ",''," +
                                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "','" + pg.sales_voucher.operator_nama + "'," +
                                        " " + pg.sales_voucher.product_type + "," + pg.sales_voucher.product_id + " ";
                                        querystart += queryv;
                                    }
                                }
                            }

                            foreach (var gj in rso.sales_order_gj)
                            {
                                querystart += querygj + " @IDSO, " + gj.id_product + "," +
                                    " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                    " " + gj.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + gj.harga_rupiah + "," +
                                    " " + gj.discount + ", " + gj.discount_nominal + "," +
                                    " " + gj.discount_program + ", " + gj.discount_program_nominal + "," +
                                    " " + gj.discount_gift + ", " + gj.discount_round + "," +
                                    " " + gj.discount_promo + ", " + gj.total_rupiah + "," +
                                    " " + gj.total_bayar + ", " + gj.status_resell + "," +
                                    " " + gj.total_dp + ", " + gj.discount_bank + "," +
                                    " " + gj.discount_other + ", " + gj.ppn + "," +
                                    " " + gj.ppn_percentage + ", " + gj.id_promo_bank + " ";

                                if (gj.sales_voucher != null)
                                {
                                    DataTable dt = GetTypeVoucherID(gj.sales_voucher.nomor_voucher);
                                    if (dt.Rows.Count == 1)
                                    {
                                        string queryv = "EXEC sp_insert_sales_order_voucher_new @IDSO," +
                                        " '" + gj.sales_voucher.nomor_voucher + "','" + dt.Rows[0]["m_type"].ToString() + "','" + dt.Rows[0]["cnamatype"].ToString() + "'," +
                                        " 'DISCOUNT VOUCHER', " + Convert.ToInt64(gj.sales_voucher.nominal) + ",''," +
                                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "','" + gj.sales_voucher.operator_nama + "'," +
                                        " " + gj.sales_voucher.product_type + "," + gj.sales_voucher.product_id + " ";
                                        querystart += queryv;
                                    }
                                }
                            }

                            foreach (var ld in rso.sales_order_ld)
                            {
                                querystart += queryld + " @IDSO, " + ld.id_product + "," +
                                    " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                    " " + ld.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + ld.harga_rupiah + "," +
                                    " " + ld.discount + ", " + ld.discount_nominal + "," +
                                    " " + ld.discount_program + ", " + ld.discount_program_nominal + "," +
                                    " " + ld.discount_gift + ", " + ld.discount_round + "," +
                                    " " + ld.discount_promo + ", " + ld.total_rupiah + "," +
                                    " " + ld.total_bayar + ", " + ld.status_resell + "," +
                                    " " + ld.total_dp + ", " + ld.discount_bank + "," +
                                    " " + ld.discount_other + ", " + ld.ppn + "," +
                                    " " + ld.ppn_percentage + ", " + ld.id_promo_bank + " ";

                                if (ld.sales_voucher != null)
                                {
                                    DataTable dt = GetTypeVoucherID(ld.sales_voucher.nomor_voucher);
                                    if (dt.Rows.Count == 1)
                                    {
                                        string queryv = "EXEC sp_insert_sales_order_voucher_new @IDSO," +
                                        " '" + ld.sales_voucher.nomor_voucher + "','" + dt.Rows[0]["m_type"].ToString() + "','" + dt.Rows[0]["cnamatype"].ToString() + "'," +
                                        " 'DISCOUNT VOUCHER', " + Convert.ToInt64(ld.sales_voucher.nominal) + ",''," +
                                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "','" + ld.sales_voucher.operator_nama + "'," +
                                        " " + ld.sales_voucher.product_type + "," + ld.sales_voucher.product_id + " ";
                                        querystart += queryv;
                                    }
                                }
                            }

                            foreach (var packaging in rso.sales_order_packaging)
                            {
                                querystart += querypackaging + " @IDSO, " + packaging.id_product + "," +
                                    " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                    " " + packaging.modal_rupiah + ", " + packaging.total_rupiah + ", " + packaging.qty + "," +
                                    " " + packaging.total_modal_rupiah + ", " + packaging.id_product_dj + "," +
                                    " " + packaging.id_product_pg + ", " + packaging.id_product_gj + ", " +
                                    " " + packaging.id_product_ld + " ";
                            }

                            foreach (var souvenir in rso.sales_order_souvenir)
                            {
                                querystart += querysouvenir + " @IDSO, " + souvenir.id_product + "," +
                                    " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                    " " + souvenir.modal_rupiah + ", " + souvenir.total_rupiah + ", " + souvenir.qty + "," +
                                    " " + souvenir.total_modal_rupiah + ", " + souvenir.id_product_dj + "," +
                                    " " + souvenir.id_product_pg + ", " + souvenir.id_product_gj + ", " +
                                    " " + souvenir.id_product_ld + ", " + souvenir.tipe_product + ", " + souvenir.id_product_souvenir + " ";
                            }

                            foreach (var cetakan in rso.sales_order_cetakan)
                            {
                                querystart += querycetakan + " @IDSO, " + cetakan.id_product + "," +
                                    " '" + rso.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                    " " + cetakan.modal_rupiah + ", " + cetakan.total_rupiah + ", " + cetakan.qty + "," +
                                    " " + cetakan.total_modal_rupiah + " ";
                            }

                            int count = rso.resell_dj.Count + rso.resell_pg.Count + rso.resell_gj.Count + rso.resell_ld.Count;
                            string querystartresell = "";
                            if (count > 0)
                            {
                                string queryresell = "EXEC sp_insert_resell_new";
                                string queryreselldj = "EXEC sp_insert_resell_dj_new";
                                string queryresellpg = "EXEC sp_insert_resell_pg_new";
                                string queryresellgj = "EXEC sp_insert_resell_gj_new";
                                string queryresellld = "EXEC sp_insert_resell_ld_new";
                                querystartresell += "DECLARE @TABLETRADEIN TABLE(ID INT, NO_RO VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";

                                querystartresell = querystartresell + " INSERT INTO @TABLETRADEIN(ID, NO_RO, [MESSAGE]) " + queryresell +
                                " " + rso.id_customer + "," +
                                " '" + rso.customer_nama + "'," +
                                " " + rso.tipe_lokasi + "," +
                                " " + rso.id_lokasi + "," +
                                " '" + rso.kode_lokasi + "'," +
                                " " + rso.total_resell + "," +
                                " '" + rso.tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                " '" + rso.keterangan + "'," +
                                " '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                " '" + rso.operator_nama + "'," +
                                " " + 1.ToString() + "," +
                                " " + 1.ToString() + "," +
                                " " + rso.id_sales + "," +
                                " '" + rso.sales_nama + "'," +
                                " '" + rso.kode_customer_lama + "'," +
                                " 'CMK'" +
                                " DECLARE @IDRO INT = (SELECT TOP 1 ID FROM @TABLETRADEIN) " +
                                " DECLARE @NOMORRO VARCHAR(50) = (SELECT TOP 1 NO_RO FROM @TABLETRADEIN) ";

                                foreach (var reselldj in rso.resell_dj)
                                {
                                    querystartresell += queryreselldj + " @IDRO," +
                                    " " + reselldj.id_sales_order + "," +
                                    " " + reselldj.id_product + "," +
                                    " " + reselldj.id_doc_qc + "," +
                                    " '" + reselldj.nomor + "'," +
                                    " " + reselldj.harga_acuan + "," +
                                    " " + reselldj.harga_rupiah + "," +
                                    " " + reselldj.nilai_trade_in + "," +
                                    " '" + reselldj.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                    " '" + reselldj.operator_nama + "'," +
                                    " " + reselldj.modal_usd + "";
                                }

                                foreach (var resellpg in rso.resell_pg)
                                {
                                    querystartresell += queryresellpg + " @IDRO," +
                                    " " + resellpg.id_sales_order + "," +
                                    " " + resellpg.id_product + "," +
                                    " " + resellpg.id_doc_qc + "," +
                                    " '" + resellpg.nomor + "'," +
                                    " " + resellpg.harga_acuan + "," +
                                    " " + resellpg.harga_rupiah + "," +
                                    " " + resellpg.nilai_trade_in + "," +
                                    " '" + resellpg.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                    " '" + resellpg.operator_nama + "'," +
                                    " " + resellpg.berat_timbang + "," +
                                    " " + resellpg.tgp + "";
                                }

                                foreach (var resellgj in rso.resell_gj)
                                {
                                    querystartresell += queryresellgj + " @IDRO," +
                                    " " + resellgj.id_sales_order + "," +
                                    " " + resellgj.id_product + "," +
                                    " " + resellgj.id_doc_qc + "," +
                                    " '" + resellgj.nomor + "'," +
                                    " " + resellgj.harga_acuan + "," +
                                    " " + resellgj.harga_rupiah + "," +
                                    " " + resellgj.nilai_trade_in + "," +
                                    " '" + resellgj.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                    " '" + resellgj.operator_nama + "'," +
                                    " " + resellgj.berat_timbang + "," +
                                    " " + resellgj.tgp + "";
                                }

                                foreach (var resellld in rso.resell_ld)
                                {
                                    querystartresell += queryresellld + " @IDRO," +
                                    " " + resellld.id_sales_order + "," +
                                    " " + resellld.id_product + "," +
                                    " " + resellld.id_doc_qc + "," +
                                    " '" + resellld.nomor + "'," +
                                    " " + resellld.harga_acuan + "," +
                                    " " + resellld.harga_rupiah + "," +
                                    " " + resellld.nilai_trade_in + "," +
                                    " '" + resellld.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                                    " '" + resellld.operator_nama + "'";
                                }
                                string queryupdatero = " EXEC sp_insert_trade_in_new @IDSO,@IDRO," +
                                    " " + rso.tipe_lokasi + ", " + rso.id_lokasi + "," +
                                    " '" + rso.kode_lokasi + "', " + rso.id_customer + "," +
                                    " '" + rso.customer_nama + "', " + rso.id_sales + "," +
                                    " '" + rso.sales_nama + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                    " '" + rso.keterangan + "','" + rso.operator_nama + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                                    " '" + rso.kode_customer_lama + "'";
                                querystartresell += " " + queryupdatero;
                            }

                            string queryupdateso = " EXEC sp_update_total_discount_new @IDSO";
                            string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + queryupdateso + " " + querystartresell + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_SO], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                            DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                            string res = result.Rows[0]["MESSAGE"].ToString();
                            int idso = Convert.ToInt32(result.Rows[0]["ID"]);
                            string noso = result.Rows[0]["NO_SO"].ToString();
                            UpdateRateSalesOrderPG(idso);
                            return new { message = res, id = idso, no = noso };
                        }
                        else
                        {
                            return new { message = "Failed. Data Not Found" };
                        }
                    }
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
        #region Delete Sales Order
        public object DeleteSalesOrder(int id)
        {
            try
            {
                string queryvalidation = "EXEC sp_validation_delete_sales_order_new " + id;
                string result = _openConnection.SingleString(queryvalidation, _connectionStrings.ConnectionStrings.Cnn_DB);
                if (result == "")
                {
                    string querydeleteso = "EXEC sp_delete_sales_order_new " + id;
                    _openConnection.Execute(querydeleteso, _connectionStrings.ConnectionStrings.Cnn_DB);
                    return new { message = "" };
                }
                else
                {
                    return new { message = result };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Validate Discount Voucher
        public object ValidateDiscountVoucher(string nomor, string loccode)
        {
            try
            {
                nomor = string.IsNullOrEmpty(nomor) ? "" : _common.ChangeStringWildCardCharacterSQL(nomor);
                loccode = string.IsNullOrEmpty(loccode) ? "" : _common.ChangeStringWildCardCharacterSQL(loccode);
                int stampsstoreid = _common.GetStampsIDLocationQuery(loccode);
                if (stampsstoreid == 0)
                {
                    return new { message = "Store ID tidak ditemukan." };
                }
                else
                {
                    int store = stampsstoreid;
                    dynamic responsevoucher = _stampsConfiguration.ValidateVoucherCode(nomor, store);
                    StampsResponse.ResponseValidateVoucherCode voucher = Newtonsoft.Json.JsonConvert.DeserializeObject<StampsResponse.ResponseValidateVoucherCode>(responsevoucher.result.ToString());

                    if (voucher.voucher != null)
                    {
                        if (voucher.voucher.extra_data.voucher_type == "PAYMENT")
                        {
                            return new { message = "Voucher Jenis Payment Tidak Bisa Digunakan" };
                        }
                        /*else if (Convert.ToDateTime(voucher.voucher.end_date) > Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")))
                        {
                            return new { message = "Voucher Expired. Tidak Bisa Digunakan" };
                        }*/
                        else
                        {
                            string queryprepost = "EXEC sp_post_voucher_integration_new " +
                                " '" + nomor + "'," + Convert.ToInt64(voucher.voucher.extra_data.voucher_nominal) + "," +
                                " '" + Convert.ToDateTime(voucher.voucher.start_date).ToString("yyyy-MM-dd") + "'," +
                                " '" + Convert.ToDateTime(voucher.voucher.end_date).ToString("yyyy-MM-dd") + "'," +
                                " '" + voucher.voucher.extra_data.voucher_type + "','" + voucher.voucher.name + "'," +
                                " " + voucher.voucher.id + ",'DISCOUNT',''";
                            string result = _openConnection.SingleString(queryprepost, _connectionStrings.ConnectionStrings.Cnn_CMK);
                            if (!string.IsNullOrEmpty(result))
                            {
                                return new { message = result };
                            }
                            else
                            {
                                return new
                                {
                                    message = "",
                                    data = new
                                    {
                                        nomor,
                                        nama = voucher.voucher.name,
                                        isredeemable = voucher.is_redeemable,
                                        nominal = Convert.ToInt64(voucher.voucher.extra_data.voucher_nominal),
                                        startdate = voucher.voucher.start_date,
                                        enddate = voucher.voucher.end_date,
                                        type = voucher.voucher.extra_data.voucher_type
                                    }
                                };
                            }
                        }
                    }
                    else
                    {
                        return new { message = voucher.error_message + " (STAMPS Validation)" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Void Sales Order
        public object VoidSalesOrder(int id, string operatornama, string keterangan)
        {
            try
            {
                keterangan = string.IsNullOrEmpty(keterangan) ? "" : _common.ChangeStringWildCardCharacterSQL(keterangan);
                string queryvalidation = "EXEC sp_validation_void_sales_order_new " + id.ToString();
                string queryvoid = "EXEC sp_void_sales_order_new " + id.ToString() + ",'" + operatornama + "','" + keterangan + "'";

                string errorvalidation = _openConnection.SingleString(queryvalidation, _connectionStrings.ConnectionStrings.Cnn_DB);
                if (errorvalidation == "")
                {
                    object resultstamps = _paymentRepository.CancelSalesOrderToStamps(id, false);
                    string messagestamps = resultstamps.GetType().GetProperty("message").GetValue(resultstamps, null).ToString();
                    if (messagestamps == "")
                    {
                        string msg = _openConnection.SingleString(queryvoid, _connectionStrings.ConnectionStrings.Cnn_DB);
                        if (msg == "")
                        {
                            object resultmyapps = _common.PostingVoidSalesOrderMyapps(id);
                            string messagemyapps = resultmyapps.GetType().GetProperty("message").GetValue(resultmyapps, null).ToString();
                            return new { message = messagemyapps };
                        }
                        else
                        {
                            return new { message = msg };
                        }
                    }
                    else
                    {
                        return new { message = messagestamps };
                    }
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
        #region Report Sales Order
        public object ReportSalesOrder(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "EXEC sp_report_sales_order_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," + status + "," + excel + "," + page + "," + row + " ";
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        nomor = dr["NOMORSO"].ToString(),
                        tgl = Convert.ToDateTime(dr["TGLSO"]),
                        nomor_trade_in = dr["NOMORTI"].ToString(),
                        store = dr["STORE"].ToString(),
                        sales = dr["SALESNAMA"].ToString(),
                        customer = dr["CUSTNAMA"].ToString(),
                        paid = Convert.ToDouble(dr["TERBAYAR"]),
                        unpaid = Convert.ToDouble(dr["SISABAYAR"]),
                        total_bayar = Convert.ToDouble(dr["TOTALBAYAR"]),
                        qty = Convert.ToInt32(dr["QTY"]),
                        keterangan = dr["KETERANGAN"].ToString(),
                        status = dr["STATUS"].ToString()
                    });
                }

                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Report Sales Detail
        public object ReportSalesDetail(string kw, string start, string end, string location, string producttype, int status, int page, int row, bool excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                producttype = string.IsNullOrEmpty(producttype) ? "" : _common.ChangeStringWildCardCharacterSQL(producttype);
                string query = "EXEC sp_report_sales_detail_so_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," +
                    " '" + producttype + "'," + status + "," + page + "," + row + "," + (excel ? 1 : 0).ToString();
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        no = Convert.ToInt32(dr["NO"]),
                        id = Convert.ToInt32(dr["ID"]),
                        nomor = dr["NO_SO"].ToString(),
                        tgl = Convert.ToDateTime(dr["TGL"]),
                        store = dr["STORE"].ToString(),
                        is_use_ppn = Convert.ToBoolean(dr["IS_USE_PPN"]),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        sales_nama = dr["SALES_NAMA"].ToString(),
                        invoice = dr["INVOICE"].ToString(),
                        proto_nomor = dr["PROTO_NOMOR"].ToString(),
                        supplier_nomor = dr["SUPPLIER_NOMOR"].ToString(),
                        tipe = dr["TIPE"].ToString(),
                        plu = dr["PLU"].ToString(),
                        img_picture = _common.ImageCDN(dr["IMG_PICTURE"].ToString()),
                        item = dr["ITEM"].ToString(),
                        kategori = dr["KATEGORI"].ToString(),
                        level = dr["LEVEL"].ToString(),
                        frame_color = dr["FRAME_COLOUR"].ToString(),
                        harga_m = Convert.ToDecimal(dr["HARGA_M"]),
                        harga_rupiah = Convert.ToDouble(dr["HARGA_RUPIAH"]),
                        discount_normal_percentage = dr["DISCOUNT_NORMAL_PERCENT"].ToString() + " %",
                        discount_normal_nominal = Convert.ToDouble(dr["DISCOUNT_NORMAL_NOMINAL"]),
                        discount_membership_percentage = dr["DISCOUNT_MEMBERSHIP_PERCENT"].ToString() + " %",
                        discount_membership_nominal = Convert.ToDouble(dr["DISCOUNT_MEMBERSHIP_NOMINAL"]),
                        discount_promo_nominal = Convert.ToDouble(dr["DISCOUNT_PROMO"]),
                        discount_voucher_nominal = Convert.ToDouble(dr["DISCOUNT_GIFT"]),
                        discount_bank_nominal = Convert.ToDouble(dr["DISCOUNT_BANK"]),
                        discount_round_nominal = Convert.ToDouble(dr["DISCOUNT_ROUND"]),
                        discount_other_nominal = Convert.ToDouble(dr["DISCOUNT_OTHER"]),
                        total_bayar = Convert.ToDouble(dr["TOTAL_BAYAR"]),
                        price_exc_vat = Convert.ToDouble(dr["PRICE_EXC_VAT"]),
                        ppn = Convert.ToDouble(dr["PPN"]),
                        kadar_tukaran = Convert.ToDecimal(dr["KADAR_TUKARAN"]),
                        total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                        total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                        gross_weight = Convert.ToDecimal(dr["GROSS_WEIGHT"]),
                        netto_weight = Convert.ToDecimal(dr["NETTO_WEIGHT"]),
                        membership = dr["MEMBERSHIP"].ToString(),
                        cash = Convert.ToDouble(dr["CASH"]),
                        credit_card = Convert.ToDouble(dr["CREDIT_CARD"]),
                        transfer = Convert.ToDouble(dr["TRANSFER"]),
                        debit_card = Convert.ToDouble(dr["DEBIT_CARD"]),
                        voucher = Convert.ToDouble(dr["VOUCHER"]),
                        exchange = Convert.ToDouble(dr["EXCHANGE"]),
                        poin = Convert.ToDouble(dr["POIN"]),
                        down_payment = Convert.ToDouble(dr["DOWN_PAYMENT"]),
                        bridesyory_pay = Convert.ToDouble(dr["BRIDESTORY_PAY"]),
                        gift_card = Convert.ToDouble(dr["GIFT_CARD"]),
                        laku_emas = Convert.ToDouble(dr["LAKU_EMAS"]),
                        cash_lei = Convert.ToDouble(dr["CASH_LEI"]),
                        qris = Convert.ToDouble(dr["QRIS"]),
                        xendit = Convert.ToDouble(dr["XENDIT"]),
                        qris_lei = Convert.ToDouble(dr["QRIS_LEI"]),
                        bank = dr["BANK"].ToString(),
                        edc = dr["EDC"].ToString()
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Report TradeIn Detail
        public object ReportTradeInDetail(string kw, string start, string end, string location, string producttype, int item, int kategori, int status, int page, int row, bool excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                producttype = string.IsNullOrEmpty(producttype) ? "" : _common.ChangeStringWildCardCharacterSQL(producttype);
                string query = "EXEC sp_report_tradein_detail_so_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," +
                    " '" + producttype + "'," + item + "," + kategori + "," +
                    " " + status + "," + page + "," + row + "," + (excel ? 1 : 0).ToString();
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        no = Convert.ToInt32(dr["NO"]),
                        id = Convert.ToInt32(dr["ID"]),
                        tgl_pembelian = Convert.ToDateTime(dr["TGL_PEMBELIAN"]).ToString("dd-MM-yyyy"),
                        lokasi_pembelian = dr["LOKASI_PEMBELIAN"].ToString(),
                        invoice_asal = dr["INVOICE_ASAL"].ToString(),
                        harga_pembelian_asal = Convert.ToDouble(dr["HARGA_PEMBELIAN_ASAL"]),
                        keterangan_asal = dr["KETERANGAN_ASAL"].ToString(),
                        tgl_trade_in = Convert.ToDateTime(dr["TGL_TRADE_IN"]).ToString("dd-MM-yyyy"),
                        lokasi_trade_in = dr["LOKASI_TRADE_IN"].ToString(),
                        no_trade_in = dr["NO_TRADE_IN"].ToString(),
                        no_so_baru = dr["NO_SO_BARU"].ToString(),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        tipe = dr["TIPE"].ToString(),
                        plu = dr["PLU"].ToString(),
                        item = dr["ITEM"].ToString(),
                        kategori = dr["KATEGORI"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        harga_trade_in = Convert.ToDouble(dr["HARGA_TRADE_IN"]),
                        harga_so_baru = Convert.ToDouble(dr["HARGA_SO_BARU"])
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Report TradeIn
        public object ReportTradeIn(string Keyword, string Start, string End, int Lokasi, int TipeLokasi, int Status)
        {
            List<object> datas = new();

            Keyword = string.IsNullOrEmpty(Keyword) ? "" : _common.ChangeStringWildCardCharacterSQL(Keyword);
            string query = "exec sp_report_tradein '"
                + Keyword + "', '"
                + Start + "', '"
                + End + "', "
                + Status + ", "
                + TipeLokasi + ", "
                + Lokasi;

            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        ID_SO = Convert.ToInt32(row["IDSO"]),
                        Tanggal = Convert.ToDateTime(row["Tgl"]).ToString("D"),
                        CustomerName = row["CustomerNama"].ToString(),
                        SalesName = row["SalesNama"].ToString(),
                        Nomor = row["Nomor"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        StoneCarat = Convert.ToDecimal(row["StoneCarat"]),
                        StoneQty = Convert.ToDecimal(row["StoneQty"]),
                        TotalBayar = Convert.ToDecimal(row["TotalBayar"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("F"),
                        Status = row["Status"].ToString(),
                        Image = _common.ImageCDN(row["Image"].ToString())
                    });
                }
            }

            return datas;
        }
        #endregion
        #region Report Resell Detail
        public object ReportResellDetail(string kw, string start, string end, string location, string producttype, int reselltype, int item, int kategori, int status, int page, int row, bool excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                producttype = string.IsNullOrEmpty(producttype) ? "" : _common.ChangeStringWildCardCharacterSQL(producttype);
                string query = "EXEC sp_report_resell_detail_so_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," +
                    " '" + producttype + "'," + reselltype + "," + item + "," + kategori + "," +
                    " " + status + "," + page + "," + row + "," + (excel ? 1 : 0).ToString();
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        no = Convert.ToInt32(dr["NO"]),
                        id = Convert.ToInt32(dr["ID"]),
                        tgl_pembelian = Convert.ToDateTime(dr["TGL_PEMBELIAN"]).ToString("dd-MM-yyyy"),
                        lokasi_pembelian = dr["LOKASI_PEMBELIAN"].ToString(),
                        invoice_asal = dr["INVOICE_ASAL"].ToString(),
                        harga_pembelian_asal = Convert.ToDouble(dr["HARGA_PEMBELIAN_ASAL"]),
                        keterangan_asal = dr["KETERANGAN_ASAL"].ToString(),
                        tgl_resell = Convert.ToDateTime(dr["TGL_RESELL"]).ToString("dd-MM-yyyy"),
                        keterangan_void = dr["KETERANGAN_VOID"].ToString(),
                        lokasi_resell = dr["LOKASI_RESELL"].ToString(),
                        no_resell = dr["NO_RESELL"].ToString(),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        tipe = dr["TIPE"].ToString(),
                        plu = dr["PLU"].ToString(),
                        item = dr["ITEM"].ToString(),
                        kategori = dr["KATEGORI"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        harga_resell = Convert.ToDouble(dr["HARGA_RESELL"])
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Print Sales Order
        public object PrintSalesOrder(int id)
        {
            try
            {
                string query = "EXEC sp_print_sales_order_new " + id.ToString();
                DataSet dt = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = dt.Tables[0];
                DataTable dtitem = dt.Tables[1];
                DataTable dtpayment = dt.Tables[2];
                object dtobjectheader = new object();
                List<object> dtobjectitem = new List<object>();
                List<object> dtobjectpayment = new List<object>();

                foreach (DataRow dr in dtitem.Rows)
                {
                    dtobjectitem.Add(new
                    {
                        kode = dr["KODE"].ToString(),
                        tipe = dr["TIPE"].ToString(),
                        nama = dr["NAMA"].ToString(),
                        invoice = dr["INVOICE"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        harga_rupiah = Convert.ToDouble(dr["HARGARUPIAH"]),
                        total_discount = Convert.ToDouble(dr["TOTAlDISCOUNT"]),
                        total_bayar = Convert.ToDouble(dr["TOTALBAYAR"]),
                    });
                }

                foreach (DataRow dr in dtpayment.Rows)
                {
                    dtobjectpayment.Add(new
                    {
                        payment_name = dr["PAYMENTNAME"].ToString(),
                        card_name = dr["CARDNAME"].ToString(),
                        program_name = dr["PROGRAMNAME"].ToString(),
                        edc_name = dr["EDCNAME"].ToString(),
                        bank_name = dr["BANKNAME"].ToString(),
                        jenis_cc_name = dr["JENISKARTUKREDITNAME"].ToString(),
                        cc_number = dr["CCNUMBER"].ToString(),
                        cc_name = dr["CCNAME"].ToString(),
                        nominal = Convert.ToDouble(dr["NOMINAL"]),
                        void_reference = Convert.ToInt32(dr["VOIDREFERENCE"])
                    });
                }

                if (dtheader.Rows.Count == 1)
                {
                    dtobjectheader = new
                    {
                        id = Convert.ToInt32(dtheader.Rows[0]["IDSO"]),
                        nomor = dtheader.Rows[0]["NOSO"].ToString(),
                        tgl = Convert.ToDateTime(dtheader.Rows[0]["TGLSO"]).ToString("dd-MM-yyyy"),
                        store_code = dtheader.Rows[0]["STORECODE"].ToString(),
                        store_name = dtheader.Rows[0]["STORENAME"].ToString(),
                        store_addr = dtheader.Rows[0]["STOREADDR"].ToString(),
                        sales_name = dtheader.Rows[0]["SALESNAME"].ToString(),
                        customer_name = dtheader.Rows[0]["CUSTOMERNAME"].ToString(),
                        customer_code = dtheader.Rows[0]["CUSTOMERCODE"].ToString(),
                        given_to = dtheader.Rows[0]["CUSTOMERREFERENCENAME"].ToString(),
                        status_pembayaran = Convert.ToBoolean(dtheader.Rows[0]["STATUSPEMBAYARAN"]),
                        status_void = Convert.ToBoolean(dtheader.Rows[0]["STATUSVOID"]),
                        total_bayar = Convert.ToDouble(dtheader.Rows[0]["TOTALBAYAR"]),
                        brand = dtheader.Rows[0]["BRAND"].ToString(),
                        kodebrand = dtheader.Rows[0]["KODEBRAND"].ToString(),
                        item = dtobjectitem,
                        payment = dtobjectpayment
                    };
                }

                return new { message = "", data = dtobjectheader };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Print Sales Order DJ
        public object PrintSalesOrderDJ(int id)
        {
            try
            {
                string query = "EXEC sp_print_sales_detail_new " + id.ToString() + ", 'DJ' ";
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);

                if (dt.Rows.Count == 1)
                {
                    int idproduct = Convert.ToInt32(dt.Rows[0]["IDPRODUCT"]);
                    DataTable dtasp = _openConnection.Rs("EXEC sp_get_asp_new 1," + idproduct, _connectionStrings.ConnectionStrings.Cnn_DB);
                    object dtobject = new
                    {
                        nomor = dt.Rows[0]["NOSO"].ToString(),
                        invoice = dt.Rows[0]["INVOICE"].ToString(),
                        tgl = Convert.ToDateTime(dt.Rows[0]["TGLSO"]).ToString("dd-MM-yyyy"),
                        store_code = dt.Rows[0]["STORECODE"].ToString(),
                        store_name = dt.Rows[0]["STORENAME"].ToString(),
                        store_addr = dt.Rows[0]["STOREADDR"].ToString(),
                        sales_name = dt.Rows[0]["SALESNAME"].ToString(),
                        customer_name = dt.Rows[0]["CUSTOMERNAME"].ToString(),
                        customer_code = dt.Rows[0]["CUSTOMERCODE"].ToString(),
                        given_to = dt.Rows[0]["CUSTOMERREFERENCENAME"].ToString(),
                        status_pembayaran = Convert.ToBoolean(dt.Rows[0]["STATUSPEMBAYARAN"]),
                        status_void = Convert.ToBoolean(dt.Rows[0]["STATUSVOID"]),
                        total_bayar = Convert.ToDouble(dt.Rows[0]["TOTALBAYAR"]),
                        brand = dt.Rows[0]["BRAND"].ToString(),
                        kodebrand = dt.Rows[0]["KODEBRAND"].ToString(),
                        asp = new
                        {

                        }
                    };
                    return new { message = "", data = dtobject };
                }
                else
                {
                    return new { message = "Data tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Print Sales Order PG
        public object PrintSalesOrderPG(int id)
        {
            try
            {
                string query = "EXEC sp_print_sales_detail_new " + id.ToString() + ", 'PG' ";
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);

                if (dt.Rows.Count == 1)
                {
                    int idproduct = Convert.ToInt32(dt.Rows[0]["IDPRODUCT"]);
                    DataTable dtasp = _openConnection.Rs("EXEC sp_get_asp_new 2," + idproduct, _connectionStrings.ConnectionStrings.Cnn_DB);
                    object dtobject = new
                    {
                        nomor = dt.Rows[0]["NOSO"].ToString(),
                        invoice = dt.Rows[0]["INVOICE"].ToString(),
                        tgl = Convert.ToDateTime(dt.Rows[0]["TGLSO"]).ToString("dd-MM-yyyy"),
                        store_code = dt.Rows[0]["STORECODE"].ToString(),
                        store_name = dt.Rows[0]["STORENAME"].ToString(),
                        store_addr = dt.Rows[0]["STOREADDR"].ToString(),
                        sales_name = dt.Rows[0]["SALESNAME"].ToString(),
                        customer_name = dt.Rows[0]["CUSTOMERNAME"].ToString(),
                        customer_code = dt.Rows[0]["CUSTOMERCODE"].ToString(),
                        given_to = dt.Rows[0]["CUSTOMERREFERENCENAME"].ToString(),
                        status_pembayaran = Convert.ToBoolean(dt.Rows[0]["STATUSPEMBAYARAN"]),
                        status_void = Convert.ToBoolean(dt.Rows[0]["STATUSVOID"]),
                        total_bayar = Convert.ToDouble(dt.Rows[0]["TOTALBAYAR"]),
                        brand = dt.Rows[0]["BRAND"].ToString(),
                        kodebrand = dt.Rows[0]["KODEBRAND"].ToString(),
                        asp = new
                        {

                        }
                    };
                    return new { message = "", data = dtobject };
                }
                else
                {
                    return new { message = "Data tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Print Sales Order GJ
        public object PrintSalesOrderGJ(int id)
        {
            try
            {
                string query = "EXEC sp_print_sales_detail_new " + id.ToString() + ", 'GJ' ";
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);

                if (dt.Rows.Count == 1)
                {
                    int idproduct = Convert.ToInt32(dt.Rows[0]["IDPRODUCT"]);
                    DataTable dtasp = _openConnection.Rs("EXEC sp_get_asp_new 3," + idproduct, _connectionStrings.ConnectionStrings.Cnn_DB);
                    object dtobject = new
                    {
                        nomor = dt.Rows[0]["NOSO"].ToString(),
                        invoice = dt.Rows[0]["INVOICE"].ToString(),
                        tgl = Convert.ToDateTime(dt.Rows[0]["TGLSO"]).ToString("dd-MM-yyyy"),
                        store_code = dt.Rows[0]["STORECODE"].ToString(),
                        store_name = dt.Rows[0]["STORENAME"].ToString(),
                        store_addr = dt.Rows[0]["STOREADDR"].ToString(),
                        sales_name = dt.Rows[0]["SALESNAME"].ToString(),
                        customer_name = dt.Rows[0]["CUSTOMERNAME"].ToString(),
                        customer_code = dt.Rows[0]["CUSTOMERCODE"].ToString(),
                        given_to = dt.Rows[0]["CUSTOMERREFERENCENAME"].ToString(),
                        status_pembayaran = Convert.ToBoolean(dt.Rows[0]["STATUSPEMBAYARAN"]),
                        status_void = Convert.ToBoolean(dt.Rows[0]["STATUSVOID"]),
                        total_bayar = Convert.ToDouble(dt.Rows[0]["TOTALBAYAR"]),
                        brand = dt.Rows[0]["BRAND"].ToString(),
                        kodebrand = dt.Rows[0]["KODEBRAND"].ToString(),
                        asp = new
                        {

                        }
                    };
                    return new { message = "", data = dtobject };
                }
                else
                {
                    return new { message = "Data tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Print Sales Order LD
        public object PrintSalesOrderLD(int id)
        {
            try
            {
                string query = "EXEC sp_print_sales_detail_new " + id.ToString() + ", 'DJ' ";
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);

                if (dt.Rows.Count == 1)
                {
                    int idproduct = Convert.ToInt32(dt.Rows[0]["IDPRODUCT"]);
                    DataTable dtasp = _openConnection.Rs("EXEC sp_get_asp_new 4," + idproduct, _connectionStrings.ConnectionStrings.Cnn_DB);
                    object dtobject = new
                    {
                        nomor = dt.Rows[0]["NOSO"].ToString(),
                        invoice = dt.Rows[0]["INVOICE"].ToString(),
                        tgl = Convert.ToDateTime(dt.Rows[0]["TGLSO"]).ToString("dd-MM-yyyy"),
                        store_code = dt.Rows[0]["STORECODE"].ToString(),
                        store_name = dt.Rows[0]["STORENAME"].ToString(),
                        store_addr = dt.Rows[0]["STOREADDR"].ToString(),
                        sales_name = dt.Rows[0]["SALESNAME"].ToString(),
                        customer_name = dt.Rows[0]["CUSTOMERNAME"].ToString(),
                        customer_code = dt.Rows[0]["CUSTOMERCODE"].ToString(),
                        given_to = dt.Rows[0]["CUSTOMERREFERENCENAME"].ToString(),
                        status_pembayaran = Convert.ToBoolean(dt.Rows[0]["STATUSPEMBAYARAN"]),
                        status_void = Convert.ToBoolean(dt.Rows[0]["STATUSVOID"]),
                        total_bayar = Convert.ToDouble(dt.Rows[0]["TOTALBAYAR"]),
                        brand = dt.Rows[0]["BRAND"].ToString(),
                        kodebrand = dt.Rows[0]["KODEBRAND"].ToString(),
                        asp = new
                        {

                        }
                    };
                    return new { message = "", data = dtobject };
                }
                else
                {
                    return new { message = "Data tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region PrintCard
        public object PrintProductcCard(string Nomor)
        {
            object data = new();

            var single = _context.StockProductDjs.Include(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharProductItem)
                .SingleOrDefault(p => p.Nomor == Nomor);

            data = new
            {
                Nomor = single.Nomor,
                KodeKaret = single.ProtoNomor,
                Item = single.StockProductDJ_CharProduct.CharProductItem.Nama,
                NettoWeight = single.StockProductDJ_CharProduct.NettoWeight,
                Kadar = (Math.Floor(single.StockProductDJ_CharProduct.KadarLogam) == 37)
                           ? (single.StockProductDJ_CharProduct.KadarLogam).ToString("N1")
                           : Math.Floor(single.StockProductDJ_CharProduct.KadarLogam).ToString("N0"),
                Img = _common.Image(single.ImgPicture),
                Stone = PrintStoneCard(single.Nomor)

            };

            return data;
        }

        private List<object> PrintStoneCard(string Nomor)
        {
            List<object> datas = new();
            string spname = "sp_get_stone_information_for_bandroll_certificate";
            string query = " exec " + spname
                         + " 'c','" + Nomor + "','DJ'";

            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        TotalButir = Convert.ToInt32(row["TotalButir"]),
                        TotalCarat = Convert.ToInt32(row["TotalCarat"]),
                        Keterangan = row["Keterangan"].ToString()
                    });
                }
            }

            return datas;
        }
        #endregion
        #region Add Sales Packaging
        public object AddPackaging(RequestSalesPackaging rpk)
        {
            try
            {
                string querypk = "EXEC sp_insert_sales_packaging_new ";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_PK VARCHAR(50), [MESSAGE] VARCHAR(1000)) ";

                if (rpk != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_PK, [MESSAGE]) " + querypk +
                        " " + rpk.tipe_lokasi +
                        ", " + rpk.id_lokasi + "," +
                        " '" + rpk.kode_lokasi + "', " + rpk.id_customer + "," +
                        " '" + rpk.customer_nama + "', " + rpk.id_sales + "," +
                        " '" + rpk.sales_nama + "', " + rpk.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                        " " + rpk.harga_rupiah + ", " + rpk.paid + "," +
                        " " + rpk.unpaid + ", " + rpk.total_bayar + "," +
                        " " + rpk.total_rupiah + ", " + rpk.total_bayar + "," +
                        " " + rpk.total_rupiah + ", " + rpk.total_resell + "," +
                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                        " '" + rpk.keterangan + "', '" + rpk.operator_nama + "'," +
                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                        " '" + (rpk.trade_in ? 1 : 0) + "', '" + rpk.customer_reference_nama + "'," +
                        " '" + rpk.e_receipt_hp + "', '" + rpk.e_receipt_email + "'," +
                        " '" + (rpk.npwp ? 1 : 0).ToString() + "', '" + rpk.membership + "'," +
                        " " + rpk.id_event + ", '" + rpk.link_packaging_sales_order + "'," +
                        " '" + rpk.link_packaging_down_payment + "', '" + rpk.link_packaging_repair + "' " +
                        " DECLARE @IDSO INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMORSO VARCHAR(50) = (SELECT TOP 1 NO_PK FROM @TABLE) ";

                    string querypackaging = "EXEC sp_insert_sales_order_packaging_new";
                    foreach (var packaging in rpk.sales_order_packaging)
                    {
                        querystart += querypackaging + " @IDSO, " + packaging.id_product + "," +
                            " '" + rpk.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                            " " + packaging.modal_rupiah + ", " + packaging.total_rupiah + ", " + packaging.qty + "," +
                            " " + packaging.total_modal_rupiah + ", " + packaging.id_product_dj + "," +
                            " " + packaging.id_product_pg + ", " + packaging.id_product_gj + ", " +
                            " " + packaging.id_product_ld + " ";
                    }

                    string queryinsertsr = "EXEC sp_insert_sales_receipt_packaging_souvenir_new @IDSO";
                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + queryinsertsr + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_PK], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idso = Convert.ToInt32(result.Rows[0]["ID"]);
                    string noso = result.Rows[0]["NO_PK"].ToString();
                    return new { message = res, id = idso, no = noso };
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

        public object VoidPackaging(int id, string operatornama, string keterangan)
        {
            try
            {
                string queryvalidation = "EXEC sp_validation_void_sales_packaging_new " + id.ToString();
                string queryvoid = "EXEC sp_void_sales_packaging_new " + id.ToString() + ",'" + operatornama + "','" + keterangan + "'";

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

        public object ReportPackaging(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : kw;
                kw = _common.ChangeStringWildCardCharacterSQL(kw);
                string query = "EXEC sp_report_sales_packaging_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," + status + "," + page + "," + row + "," + excel;
                DataSet dtall = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = dtall.Tables[0];
                DataTable dtcount = dtall.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt64(dr["ID"]),
                        id_so = Convert.ToInt64(dr["ID_SO"]),
                        lokasi = dr["LOKASI"].ToString(),
                        tgl = Convert.ToDateTime(dr["TANGGAL"]).ToString("dd-MM-yyyy"),
                        nomor = dr["NO_SALES_ORDER"].ToString(),
                        no_reference = dr["INVOICE"].ToString(),
                        no_reference_pk = dr["NO_REFERENCE_PK"].ToString(),
                        plu = dr["PLU"].ToString(),
                        item = dr["ITEM"].ToString(),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        sales_nama = dr["SALES_NAMA"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        status = dr["STATUS"].ToString()
                    });
                }

                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetReferenceNumberPackaging(string kw, string tipe)
        {
            try
            {
                string query = "sp_get_reference_number_packaging_new '" + kw + "','" + tipe + "'";
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                List<object> listref = new List<object>();
                foreach (DataRow x in dt.Rows)
                {
                    listref.Add(new
                    {
                        tipe = x["TIPE"].ToString(),
                        nomor = x["NOMOR"].ToString(),
                        tgl = Convert.ToDateTime(x["TGL"]).ToString("dd-MM-yyyy"),
                        customer = x["CUSTOMER"].ToString(),
                        sales = x["SALES"].ToString(),
                        location = x["LOCATION"].ToString(),
                        total_bayar = Convert.ToDouble(x["TOTAL_BAYAR"])
                    });
                }
                return new { message = "", data = listref };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Add Sales Souvenir
        public object AddSouvenir(RequestSalesSouvenir rsv)
        {
            try
            {
                string querypk = "EXEC sp_insert_sales_souvenir_new ";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_SV VARCHAR(50), [MESSAGE] VARCHAR(1000)) ";

                if (rsv != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_SV, [MESSAGE]) " + querypk +
                        " " + rsv.tipe_lokasi +
                        ", " + rsv.id_lokasi + "," +
                        " '" + rsv.kode_lokasi + "', " + rsv.id_customer + "," +
                        " '" + rsv.customer_nama + "', " + rsv.id_sales + "," +
                        " '" + rsv.sales_nama + "', " + rsv.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                        " " + rsv.harga_rupiah + ", " + rsv.paid + "," +
                        " " + rsv.unpaid + ", " + rsv.total_bayar + "," +
                        " " + rsv.total_rupiah + ", " + rsv.total_bayar + "," +
                        " " + rsv.total_rupiah + ", " + rsv.total_resell + "," +
                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                        " '" + rsv.keterangan + "', '" + rsv.operator_nama + "'," +
                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                        " '" + (rsv.trade_in ? 1 : 0) + "', '" + rsv.customer_reference_nama + "'," +
                        " '" + rsv.e_receipt_hp + "', '" + rsv.e_receipt_email + "'," +
                        " '" + (rsv.npwp ? 1 : 0).ToString() + "', '" + rsv.membership + "'," +
                        " " + rsv.id_event + " DECLARE @IDSV INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMORSV VARCHAR(50) = (SELECT TOP 1 NO_SV FROM @TABLE) ";

                    string querysouvenir = "EXEC sp_insert_sales_order_souvenir_new";
                    foreach (var souvenir in rsv.sales_order_souvenir)
                    {
                        querystart += querysouvenir + " @IDSV, " + souvenir.id_product + "," +
                            " '" + rsv.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                            " " + souvenir.modal_rupiah + ", " + souvenir.total_rupiah + ", " + souvenir.qty + "," +
                            " " + souvenir.total_modal_rupiah + ", " + souvenir.id_product_dj + "," +
                            " " + souvenir.id_product_pg + ", " + souvenir.id_product_gj + ", " +
                            " " + souvenir.id_product_ld + ", " + souvenir.tipe_product + ", " + souvenir.id_product_souvenir + " ";
                    }

                    string queryinsertsr = "EXEC sp_insert_sales_receipt_packaging_souvenir_new @IDSV";
                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + queryinsertsr + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_SV], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idsv = Convert.ToInt32(result.Rows[0]["ID"]);
                    string nosv = result.Rows[0]["NO_SV"].ToString();
                    return new { message = res, id = idsv, no = nosv };
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

        public object VoidSouvenir(int id, string operatornama, string keterangan)
        {
            try
            {
                string queryvalidation = "EXEC sp_validation_void_sales_souvenir_new " + id.ToString();
                string queryvoid = "EXEC sp_void_sales_souvenir_new " + id.ToString() + ",'" + operatornama + "','" + keterangan + "'";

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

        public object ReportSouvenir(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : kw;
                kw = _common.ChangeStringWildCardCharacterSQL(kw);
                string query = "EXEC sp_report_sales_souvenir_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," + status + "," + page + "," + row + "," + excel;
                DataSet dtall = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = dtall.Tables[0];
                DataTable dtcount = dtall.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt64(dr["ID"]),
                        id_so = Convert.ToInt64(dr["ID_SO"]),
                        lokasi = dr["LOKASI"].ToString(),
                        tgl = Convert.ToDateTime(dr["TANGGAL"]).ToString("dd-MM-yyyy"),
                        nomor = dr["NO_SALES_ORDER"].ToString(),
                        no_reference = dr["INVOICE"].ToString(),
                        no_reference_pk = dr["NO_REFERENCE_PK"].ToString(),
                        plu = dr["PLU"].ToString(),
                        item = dr["ITEM"].ToString(),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        sales_nama = dr["SALES_NAMA"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        status = dr["STATUS"].ToString()
                    });
                }

                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region Add Sales Cetakan
        public object AddCetakan(RequestSalesCetakan rsc)
        {
            try
            {
                string queryct = "EXEC sp_insert_sales_cetakan_new ";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_CT VARCHAR(50), [MESSAGE] VARCHAR(1000)) ";

                if (rsc != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_CT, [MESSAGE]) " + queryct +
                        " " + rsc.tipe_lokasi +
                        ", " + rsc.id_lokasi + "," +
                        " '" + rsc.kode_lokasi + "', " + rsc.id_customer + "," +
                        " '" + rsc.customer_nama + "', " + rsc.id_sales + "," +
                        " '" + rsc.sales_nama + "', " + rsc.modal_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                        " " + rsc.harga_rupiah + ", " + rsc.paid + "," +
                        " " + rsc.unpaid + ", " + rsc.total_bayar + "," +
                        " " + rsc.total_rupiah + ", " + rsc.total_bayar + "," +
                        " " + rsc.total_rupiah + ", " + rsc.total_resell + "," +
                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                        " '" + rsc.keterangan + "', '" + rsc.operator_nama + "'," +
                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                        " '" + (rsc.trade_in ? 1 : 0) + "', '" + rsc.customer_reference_nama + "'," +
                        " '" + rsc.e_receipt_hp + "', '" + rsc.e_receipt_email + "'," +
                        " '" + (rsc.npwp ? 1 : 0).ToString() + "', '" + rsc.membership + "'," +
                        " " + rsc.id_event + " DECLARE @IDCT INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMORCT VARCHAR(50) = (SELECT TOP 1 NO_CT FROM @TABLE) ";

                    string querycetakan = "EXEC sp_insert_sales_order_cetakan_new";
                    foreach (var cetakan in rsc.sales_order_cetakan)
                    {
                        querystart += querycetakan + " @IDCT, " + cetakan.id_product + "," +
                            " '" + rsc.kode_lokasi + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," +
                            " " + cetakan.modal_rupiah + ", " + cetakan.total_rupiah + ", " + cetakan.qty + "," +
                            " " + cetakan.total_modal_rupiah + " ";
                    }

                    string queryinsertsr = "EXEC sp_insert_sales_receipt_packaging_souvenir_new @IDCT";
                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + queryinsertsr + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_CT], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idsv = Convert.ToInt32(result.Rows[0]["ID"]);
                    string nosv = result.Rows[0]["NO_CT"].ToString();
                    return new { message = res, id = idsv, no = nosv };
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

        public object VoidCetakan(int id, string operatornama, string keterangan)
        {
            try
            {
                string queryvalidation = "EXEC sp_validation_void_sales_cetakan_new " + id.ToString();
                string queryvoid = "EXEC sp_void_sales_cetakan_new " + id.ToString() + ",'" + operatornama + "','" + keterangan + "'";

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
                return new { message = ex.Message };
            }
        }

        public object ReportCetakan(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : kw;
                kw = _common.ChangeStringWildCardCharacterSQL(kw);
                string query = "EXEC sp_report_sales_cetakan_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," + status + "," + page + "," + row + "," + excel;
                DataSet dtall = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = dtall.Tables[0];
                DataTable dtcount = dtall.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt64(dr["ID"]),
                        id_so = Convert.ToInt64(dr["ID_SO"]),
                        lokasi = dr["LOKASI"].ToString(),
                        tgl = Convert.ToDateTime(dr["TANGGAL"]).ToString("dd-MM-yyyy"),
                        nomor = dr["NO_SALES_ORDER"].ToString(),
                        no_reference = dr["INVOICE"].ToString(),
                        no_reference_pk = dr["NO_REFERENCE_PK"].ToString(),
                        plu = dr["PLU"].ToString(),
                        item = dr["ITEM"].ToString(),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        sales_nama = dr["SALES_NAMA"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        status = dr["STATUS"].ToString()
                    });
                }

                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
        #endregion
        #region PostingToMyapps
        public object PostingSalesOrderToMyapps(int idso)
        {
            try
            {
                return _common.PostingSalesOrderMyapps(idso);
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object PostingVoidSalesOrderToMyapps(int idso)
        {
            try
            {
                return _common.PostingVoidSalesOrderMyapps(idso);
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object SummarySalesOrder(string location, string start, string end, int selection)
        {
            try
            {
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "EXEC sp_report_sales_order_summary_new '" + location + "'," +
                    " '" + start + "', '" + end + "'," + selection;
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                List<object> dtobject = new List<object>();

                //nettsales per day
                if (selection == 1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtobject.Add(new
                        {
                            tgl = Convert.ToDateTime(dr["TGL"]).ToString("dd-MM-yyyy"),
                            nett_sales = Convert.ToDouble(dr["VALUE"])
                        });
                    }
                }
                //nettsales per month
                else if (selection == 2)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtobject.Add(new
                        {
                            bulan = Convert.ToInt32(dr["BULAN"]),
                            tahun = Convert.ToInt32(dr["TAHUN"]),
                            nett_sales = Convert.ToDouble(dr["VALUE"])
                        });
                    }
                }
                //nettsales per item
                else if (selection == 3)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtobject.Add(new
                        {
                            tgl = Convert.ToDateTime(dr["TGL"]).ToString("dd-MM-yyyy"),
                            count_dj = Convert.ToInt64(dr["COUNTDJ"]),
                            nett_dj = Convert.ToDouble(dr["NETTDJ"]),
                            count_pg = Convert.ToInt64(dr["COUNTPG"]),
                            nett_pg = Convert.ToDouble(dr["NETTPG"]),
                            count_gj = Convert.ToInt64(dr["COUNTGJ"]),
                            nett_gj = Convert.ToDouble(dr["NETTGJ"]),
                            count_ld = Convert.ToInt64(dr["COUNTLD"]),
                            nett_ld = Convert.ToDouble(dr["NETTLD"]),
                        });
                    }
                }
                //top 5 customer
                else if (selection == 4)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtobject.Add(new
                        {
                            kode_customer = dr["KODE_CUSTOMER"].ToString(),
                            nama_customer = dr["NAMA_CUSTOMER"].ToString(),
                            total_spending = Convert.ToDouble(dr["TOTAL_SEPENDING"])
                        });
                    }
                }
                //top 5 sales
                else if (selection == 5)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtobject.Add(new
                        {
                            nik_sales = dr["NIK_SALES"].ToString(),
                            nama_sales = dr["NAMA_SALES"].ToString(),
                            total_penjualan = Convert.ToDouble(dr["TOTAL_PENJUALAN"])
                        });
                    }
                }
                return new { message = "", data = dtobject };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = _common.ReturnError()
                };
            }
        }
        #endregion
        #region QueryCustom
        private DataTable CheckPromoOrNettQuery(string PLU, string Tipe)
        {
            DataTable dt = _openConnection.Rs("EXEC sp_check_nett_or_promo_new "
                    + " '" + PLU + "',"
                    + " '" + Tipe + "'"
                    , _connectionStrings.ConnectionStrings.Cnn_DB);
            return dt;
        }

        private DataTable IsDiamondBrandedGenericQuery(string PLU, string Tipe)
        {
            DataTable dt = _openConnection.Rs("EXEC sp_check_plu_diamond_branded_generic_new "
                    + " '" + PLU + "',"
                    + " '" + Tipe + "'"
                    , _connectionStrings.ConnectionStrings.Cnn_DB);
            return dt;
        }

        private DataTable GetPromoMembershipQuery(string kodecustomer)
        {
            DataTable dt = _openConnection.Rs("EXEC sp_get_promo_membership_new "
                    + " '" + kodecustomer + "'"
                    , _connectionStrings.ConnectionStrings.Cnn_DB);
            return dt;
        }

        private DataTable GetSalesOrderItemByStoreQuery(int tipelokasi, int idlokasi, string keyword, string tipeproduct, int idcustomer)
        {
            DataTable dt = _openConnection.Rs("EXEC sp_get_sales_order_item_by_store_new "
                    + " " + idlokasi.ToString() + ","
                    + " " + tipelokasi.ToString() + ","
                    + " '" + keyword + "',"
                    + " '" + tipeproduct + "',"
                    + " " + idcustomer
                    , _connectionStrings.ConnectionStrings.Cnn_DB);
            return dt;
        }

        private decimal GetRateTgpJualQuery(int idproductpg)
        {
            string query = "EXEC sp_get_pricing_table_tgp_new " + idproductpg + ",'J'";
            decimal goldprice = _openConnection.SingleDecimal(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            return goldprice;
        }

        private decimal GetRateTgpBeliQuery(int idproductpg)
        {
            string query = "EXEC sp_get_pricing_table_tgp_new " + idproductpg + ",'B'";
            decimal goldprice = _openConnection.SingleDecimal(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            return goldprice;
        }

        private void UpdateRateSalesOrderPG(int idso)
        {
            try
            {
                var salesOrderPG = _context.SalesOrderPgs.Where(p => p.Idform == idso);
                var rateLei = _lakuEmasConfiguration.GetRateLEIs();
                foreach (SalesOrderPG x in salesOrderPG)
                {
                    string tgpjual = GetRateTgpJualQuery(x.Idproduct).ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                    string tgpbeli = GetRateTgpBeliQuery(x.Idproduct).ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                    string rateleimid = rateLei.data.mid_price.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                    string rateleisell = rateLei.data.sell_price.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                    string rateleibuy = rateLei.data.buy_price.ToString(CultureInfo.CreateSpecificCulture("en-GB"));

                    string query = "EXEC sp_update_tgp_rate_lei_new " + x.Id + "," + tgpjual + "," + tgpbeli + "," + rateleimid + "," + rateleisell + "," + rateleibuy + "," + rateleimid;
                    _openConnection.Execute(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
            catch { };
        }

        private string GetTipeProductQuery(string kw)
        {
            return _openConnection.SingleString("sp_get_tipe_product_new '" + kw + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
        }

        private DataTable GetTypeVoucherID(string kodevoucher)
        {
            string query = "SELECT TOP 100 A.m_type, B.cnamatype FROM t_voucher A JOIN tb_type_voucher B ON CAST(A.m_type AS INT) = CAST(ckodetype AS INT) WHERE A.m_nomor = '" + kodevoucher + "' ORDER BY A.m_tanggal DESC";
            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_CMK);
            return dt;
        }

        private bool CheckFixPG(int idproductpg)
        {
            string query = "SELECT TOP 1 CAST(FixRate AS BIT) FROM StockProductPG WHERE ID = " + idproductpg;
            bool isfix = _openConnection.SingleBool(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            return isfix;
        }

        #endregion
        #region Get ID Invoice
        public int GetIDInvoice(string Invoice, string tipe)
        {
            if (tipe.Equals("DJ")) return _context.SalesOrderDjs.SingleOrDefault(p => p.Invoice.Equals(Invoice)).Id;
            else if (tipe.Equals("PG")) return _context.SalesOrderPgs.SingleOrDefault(p => p.Invoice.Equals(Invoice)).Id;
            else if (tipe.Equals("LD")) return _context.SalesOrderLds.SingleOrDefault(p => p.Invoice.Equals(Invoice)).Id;
            return 0;
        }
        #endregion
    }
}
