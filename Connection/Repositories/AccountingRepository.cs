using Connection.Interface;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Data;

namespace Connection.Repositories
{
    public class AccountingRepository : IAccountingRepository
    {
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        private Common _common;

        public AccountingRepository()
        {
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
            _common = new Common();
        }

        public object ReportSalesDetail(string kw, string start, string end, string location, string producttype, int item, int category, int segmen, int basic, int payment, int status, int page, int row, bool excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                producttype = string.IsNullOrEmpty(producttype) ? "" : _common.ChangeStringWildCardCharacterSQL(producttype);
                string query = "EXEC sp_report_sales_detail_accounting_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," +
                    " '" + producttype + "'," + item + "," + category + "," + segmen + "," + basic + "," + payment + "," +
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
                        nomor = dr["NO_SO"].ToString(),
                        tgl = Convert.ToDateTime(dr["TGL"]),
                        store = dr["STORE"].ToString(),
                        is_use_ppn = Convert.ToBoolean(dr["IS_USE_PPN"]),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        sales_nama = dr["SALES_NAMA"].ToString(),
                        invoice = dr["INVOICE"].ToString(),
                        proto_nomor = dr["PROTO_NOMOR"].ToString(),
                        tipe = dr["TIPE"].ToString(),
                        plu = dr["PLU"].ToString(),
                        item = dr["ITEM"].ToString(),
                        kategori = dr["KATEGORI"].ToString(),
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
                return new { message = ex.Message };
            }
        }

        public object ReportSalesDetailLEI(string kw, string start, string end, string location, int item, int level, int model, int basic, int payment, int status, int page, int row, bool excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "EXEC sp_report_sales_detail_lei_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," +
                    " '" + item + "'," + level + "," + model + "," + basic + "," + payment + "," +
                    " " + status + "," + page + "," + row + "," + (excel ? 1 : 0).ToString(); ;
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
                        tipe = dr["TIPE"].ToString(),
                        plu = dr["PLU"].ToString(),
                        item = dr["ITEM"].ToString(),
                        kategori = dr["KATEGORI"].ToString(),
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
            catch(Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object ReportSalesDetailLM()
        {
            throw new NotImplementedException();
        }

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
                return new { message = ex.Message };
            }
        }

        public object ReportTradeInDetail(string kw, string start, string end, string location, string producttype, int item, int category, int payment, int status, int page, int row, bool excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                producttype = string.IsNullOrEmpty(producttype) ? "" : _common.ChangeStringWildCardCharacterSQL(producttype);
                string query = "EXEC sp_report_tradein_detail_accounting_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," +
                    " '" + producttype + "'," + item + "," + category + "," + payment + "," +
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
                        total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                        total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                        gross_weight = Convert.ToDecimal(dr["GROSS_WEIGHT"]),
                        netto_weight = Convert.ToDecimal(dr["NETTO_WEIGHT"]),
                        harga_trade_in = Convert.ToDouble(dr["HARGA_TRADE_IN"]),
                        harga_so_baru = Convert.ToDouble(dr["HARGA_SO_BARU"]),
                        kadar_tukaran_beli = Convert.ToDouble(dr["KADAR_TUKARAN_BELI"]),
                        harga_m = Convert.ToDecimal(dr["HARGA_M"]),
                        harga_r = Convert.ToDecimal(dr["HARGA_R"])
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object ReportResellDetail(string kw, string start, string end, string location, string producttype, int item, int category, int payment, int status, int page, int row, bool excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                producttype = string.IsNullOrEmpty(producttype) ? "" : _common.ChangeStringWildCardCharacterSQL(producttype);
                string query = "EXEC sp_report_resell_detail_accounting_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," +
                    " '" + producttype + "'," + item + "," + category + "," + payment + "," +
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
                        total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                        total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                        gross_weight = Convert.ToDecimal(dr["GROSS_WEIGHT"]),
                        netto_weight = Convert.ToDecimal(dr["NETTO_WEIGHT"]),
                        harga_resell = Convert.ToDouble(dr["HARGA_RESELL"]),
                        kadar_tukaran_beli = Convert.ToDouble(dr["KADAR_TUKARAN_BELI"]),
                        harga_m = Convert.ToDecimal(dr["HARGA_M"]),
                        harga_r = Convert.ToDecimal(dr["HARGA_R"])
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }
    }
}
