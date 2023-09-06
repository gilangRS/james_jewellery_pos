using Connection.Interface;
using Connection.Models;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using static Connection.Settings.StampsConfiguration;

namespace Connection.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly JAWSDbContext _context;
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        private StampsConfiguration _stampsConfiguration;
        private Common _common;

        public PaymentRepository()
        {
            _context = new JAWSDbContext();
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
            _stampsConfiguration = new StampsConfiguration();
            _common = new Common();
        }

        public List<object> GetBankIssuers()
        {
            var banks = _openConnection.Rs("EXEC sp_get_list_bank_issuer_new", _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in banks.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(item["ID"]),
                    nama = item["Nama"].ToString()
                });
            }
            return result;
        }

        public List<object> GetCards()
        {
            var cards = _openConnection.Rs("EXEC sp_get_list_card_type_new", _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in cards.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(item["ID"]),
                    nama = item["Nama"].ToString()
                });
            }
            return result;
        }

        public List<object> GetEDCs(bool islei, bool isqris)
        {
            var edcs = _openConnection.Rs("EXEC sp_get_list_edc_new " + (islei ? 1 : 0).ToString() + "," + (isqris ? 1 : 0).ToString(), _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in edcs.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(item["ID"]),
                    nama = item["Nama"].ToString()
                });
            }
            return result;
        }

        public List<object> GetJenisKartuKredits()
        {
            var jeniskartukredits = _openConnection.Rs("EXEC sp_get_list_jenis_kartu_kredit_new", _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in jeniskartukredits.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(item["ID"]),
                    nama = item["Nama"].ToString()
                });
            }
            return result;
        }

        public List<object> GetPaymentTypes()
        {
            var payments = _openConnection.Rs("EXEC sp_get_list_payment_new", _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in payments.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(item["ID"]),
                    nama = item["Nama"].ToString()
                });
            }
            return result;
        }

        public List<object> GetProgramCicilans()
        {
            var programs = _openConnection.Rs("EXEC sp_get_list_program_cicilan_new", _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in programs.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(item["ID"]),
                    nama = item["Nama"].ToString()
                });
            }
            return result;
        }

        public object ValidationAddPayment(int id)
        {
            try
            {
                string query = "EXEC sp_validation_insert_sales_order_new " + id;
                string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                if (string.IsNullOrEmpty(result))
                {
                    string query2 = "EXEC sp_validation_insert_sales_receipt_detail_new " + id;
                    string result2 = _openConnection.SingleString(query2, _connectionStrings.ConnectionStrings.Cnn_DB);
                    return new { message = result2 };
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

        public object AddPaymentToSalesOrder(RequestSalesReceipt sr)
        {
            try
            {
                object validation = ValidationAddPayment(sr.id_so);
                string errval = validation.GetType().GetProperty("message").GetValue(validation, null).ToString();
                if (errval != "")
                {
                    return new { message = errval };
                }
                else
                {
                    string querystart = "DECLARE @TABLE TABLE(ID INT, [MESSAGE] VARCHAR(1000)) ";
                    string querysr = "EXEC sp_insert_sales_receipt_new " + sr.id_so + "," + sr.total_bayar.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'" + sr.operator_nama + "' ";
                    querystart += "INSERT INTO @TABLE(ID, [MESSAGE]) " + querysr + " DECLARE @IDSR INT = (SELECT TOP 1 ID FROM @TABLE) ";
                    foreach (var item in sr.details)
                    {
                        querystart += "EXEC sp_insert_sales_receipt_detail_new @IDSR," +
                            " " + item.id_payment_type + ", " + item.id_card + ", " + item.id_program + "," +
                            " " + item.mdr + ", " + item.id_edc + ", " + item.id_bank_issuer + "," +
                            " '" + item.cc_number + "', '" + item.cc_name + "', " + item.nominal.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + item.operator_nama + "', " +
                            " " + item.id_jenis_kartu_kredit + ", '" + item.approval_code + "' " +
                            " ";
                    }

                    string queryupdateso = " EXEC sp_update_paid_unpaid_new " + sr.id_so;
                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + queryupdateso + " COMMIT TRAN DJANCUK SELECT '' [MESSAGE] END TRY BEGIN CATCH SELECT ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    string res = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    if (res == "")
                    {
                        object resultmyapps = _common.PostingSalesOrderMyapps(sr.id_so);
                        string messagemyapps = resultmyapps.GetType().GetProperty("message").GetValue(resultmyapps, null).ToString();
                        if (messagemyapps == "")
                        {
                            return PostingSalesOrderToStamps(sr.id_so, sr.is_require_email);
                        }
                        else
                        {
                            return resultmyapps;
                        }
                    }
                    else
                    {
                        return new { message = res };
                    }
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object PostingSalesOrderToStamps(int id, bool isrequireemail)
        {
            DataSet ds = _openConnection.Ds("EXEC sp_insert_stamps_transaction_new " + id, _connectionStrings.ConnectionStrings.Cnn_DB);
            DataTable dtheader = ds.Tables[0];
            DataTable dtitem = ds.Tables[1];
            DataTable dtpayment = ds.Tables[2];
            DataTable dtvoucher = ds.Tables[3];

            int rowcountheader = dtheader.Rows.Count;
            int rowcountitem = dtitem.Rows.Count;
            int rowcountpayment = dtpayment.Rows.Count;

            if (rowcountheader == 1 && rowcountitem > 0 && rowcountpayment > 0)
            {
                string user = (dtheader.Rows[0]["IDCustomerStamps"].ToString() == "102") ? "" : dtheader.Rows[0]["IDCustomerStamps"].ToString();
                long idsalesorder = Convert.ToInt32(dtheader.Rows[0]["IDSalesOrder"]);
                string nohpcustomer = dtheader.Rows[0]["NoHpCustomer"].ToString();
                long stampsstore = Convert.ToInt32(dtheader.Rows[0]["IDLokasiStamps"]);
                long stamps = 0;//Convert.ToInt32(dtheader.Rows[0][""]);
                string invoicenumber = dtheader.Rows[0]["NoSalesOrder"].ToString();
                long totalvalue = Convert.ToInt64(dtheader.Rows[0]["TotalBayar"]);
                long subtotal = Convert.ToInt64(dtheader.Rows[0]["TotalBayar"]);
                string employeecode = dtheader.Rows[0]["NIKSales"].ToString();
                long numberofpeople = 1;
                long tax = 0;
                string createdatetime = DateTime.Now.ToString("O");
                string requireemailnotif = isrequireemail.ToString();

                List<Item> items = new List<Item>();
                foreach (DataRow i in dtitem.Rows)
                {
                    items.Add(new Item
                    {
                        quantity = 1,
                        stamps_subtotal = Convert.ToInt64(i["PoinReceived"]),
                        subtotal = Convert.ToInt64(i["TotalBayar"]),
                        product_name = i["Nomor"].ToString() + " -- " +
                        i["Item"].ToString() + " -- " + i["Kategori"].ToString() + " -- " +
                        i["Level"].ToString() + " -- " + i["StoneDist"].ToString(),
                        extra_data = new ItemExtraData
                        {
                            type = i["TipeProduct"].ToString(),
                            item = i["Item"].ToString(),
                            category = i["Kategori"].ToString(),
                            level = i["Level"].ToString(),
                            stonedistribution = i["StoneDist"].ToString()
                        }
                    });
                    stamps += Convert.ToInt64(i["PoinReceived"]);
                }

                List<StampsPayment> payments = new List<StampsPayment>();
                foreach (DataRow i in dtpayment.Rows)
                {
                    payments.Add(new StampsPayment
                    {
                        payment_method = Convert.ToInt32(i["IDPaymentStamps"]),
                        value = Convert.ToInt64(i["Nominal"]),
                        eligible_for_membership = i["PaymentName"].ToString().ToUpper() == "EXCHANGE" ? false : true
                    });
                }

                string redeemvoucher = "";
                foreach (DataRow dr in dtvoucher.Rows)
                {
                    string novoucher = dr["NoVoucher"].ToString();
                    dynamic resultredeem = _stampsConfiguration.RedeemVoucherCode(nohpcustomer, novoucher, stampsstore);
                    if (resultredeem.status_code == HttpStatusCode.OK)
                    {
                        try
                        {
                            StampsResponse.ResponseRedeemVoucherCode redeem = JsonConvert.DeserializeObject<StampsResponse.ResponseRedeemVoucherCode>(resultredeem.result.ToString());
                            string queryupdateintegration = "EXEC sp_update_klaimdoc_voucher_integration_new '" + novoucher + "','" + invoicenumber + "'";
                            string queryredeem = "EXEC sp_update_stamps_redeemption_new " + idsalesorder +
                                ",'" + novoucher + "'," + redeem.redemption.id + ",'" + resultredeem + "'";
                            _openConnection.Execute(queryredeem, _connectionStrings.ConnectionStrings.Cnn_DB);
                        }
                        catch
                        {
                            StampsResponse.ResponseErrorGeneral errorredeem = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(resultredeem.result.ToString());
                            redeemvoucher += errorredeem.detail;
                            break;
                        }
                    }
                    else
                    {
                        StampsResponse.ResponseErrorGeneral error = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(resultredeem.result.ToString());
                        redeemvoucher += error.detail;
                        break;
                    }
                }

                if (redeemvoucher == "")
                {
                    dynamic result = _stampsConfiguration.AddTransaction(user, stampsstore, stamps, invoicenumber, totalvalue, subtotal, employeecode, numberofpeople, tax, createdatetime, requireemailnotif, items, new List<ExtraData>(), payments);
                    if (result.status_code == HttpStatusCode.OK)
                    {
                        try
                        {
                            var response = JsonConvert.DeserializeObject<StampsResponse.ResponseAddTransaction>(result.result.ToString());
                            if (response.transaction != null)
                            {
                                string queryupdate = "EXEC sp_update_stamps_transaction_new " + idsalesorder + "," +
                                    response.transaction.id + ",'" + result + "'";
                                _openConnection.Execute(queryupdate, _connectionStrings.ConnectionStrings.Cnn_DB);
                            }
                            return new { message = "" };
                        }
                        catch
                        {
                            StampsResponse.ResponseErrorGeneral error = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(result.result.ToString());
                            return new { message = error.detail };
                        }
                    }
                    else
                    {
                        StampsResponse.ResponseErrorGeneral error = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(result.result.ToString());
                        return new { message = error.detail };
                    }
                }
                else
                {
                    return new { message = redeemvoucher };
                }
            }
            else if (rowcountheader > 1)
            {
                return new { message = "Data Duplikasi." };
            }
            else if (rowcountitem == 0)
            {
                return new { message = "Data Item Kosong." };
            }
            else if (rowcountpayment == 0)
            {
                return new { message = "Data Pembayaran Kosong." };
            }
            else
            {
                return new { message = "Something Was Wrong." };
            }
        }

        public object CancelSalesOrderToStamps(int id, bool isrequireemail)
        {
            string query = "SELECT IDTransactionStamps FROM StampsTransaction WHERE IDSalesOrder = " + id;
            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            string queryvoucher = "SELECT NoVoucher, ISNULL(IDRedeemptionStamps,0) [IDRedeemptionStamps] FROM StampsTransaction A JOIN StampsTransactionVoucher B ON A.ID = B.IDForm WHERE IDSalesOrder = " + id;
            DataTable dtvoucher = _openConnection.Rs(queryvoucher, _connectionStrings.ConnectionStrings.Cnn_DB);

            int rowcountheader = dt.Rows.Count;
            //int rowcountvoucher = dtvoucher.Rows.Count;
            if (rowcountheader == 1)
            {
                int idtransactionstamps = Convert.ToInt32(dt.Rows[0]["IDTransactionStamps"]);
                if (idtransactionstamps > 0)
                {
                    dynamic result = _stampsConfiguration.CancelTransaction(idtransactionstamps);
                    if (result.status_code == HttpStatusCode.OK)
                    {
                        try
                        {
                            string redeemvoucher = "";
                            foreach (DataRow dr in dtvoucher.Rows)
                            {
                                long idredeemption = Convert.ToInt64(dr["IDRedeemptionStamps"]);
                                string novoucher = dr["NoVoucher"].ToString();
                                if (idredeemption > 0)
                                {
                                    dynamic resultcancelredeem = _stampsConfiguration.CancelRedemptions(idredeemption);
                                    if (resultcancelredeem.status_code == HttpStatusCode.OK)
                                    {
                                        StampsResponse.ResponseCancelRedemptions cancelredeem = JsonConvert.DeserializeObject<StampsResponse.ResponseCancelRedemptions>(resultcancelredeem.result.ToString());
                                        string queryupdateintegration = "EXEC sp_update_klaimdoc_voucher_integration_new '" + novoucher + "',''";
                                        string querycancelredeem = "EXEC sp_update_stamps_cancel_redeemption_new " + id +
                                            ",'" + novoucher + "'," + cancelredeem.redemption.id + ",'" + resultcancelredeem.result + "'";
                                        _openConnection.Execute(querycancelredeem, _connectionStrings.ConnectionStrings.Cnn_DB);
                                    }
                                    else
                                    {
                                        StampsResponse.ResponseErrorGeneral errorredeem = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(resultcancelredeem.result.ToString());
                                        redeemvoucher += errorredeem.detail;
                                        break;
                                    }
                                }
                            }
                            StampsResponse.ResponseCancelTransaction cancel = JsonConvert.DeserializeObject<StampsResponse.ResponseCancelTransaction>(result.result.ToString());
                            if (cancel.transaction != null)
                            {
                                _openConnection.Execute("EXEC sp_cancel_stamps_transaction_new " + id.ToString() + ",'" + result.result + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
                                return new { message = "" };
                            }
                            else
                            {
                                if (redeemvoucher != "")
                                {
                                    return new { message = "(STAMPS Validation) " + redeemvoucher };
                                }
                                else
                                {
                                    return new { message = "" };
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            return new { message = _common.ReturnError() };
                        }
                    }
                    else
                    {
                        StampsResponse.ResponseErrorGeneral errorredeem = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(result.result.ToString());
                        return new { message = errorredeem.detail };
                    }
                }
                else
                {
                    return new { message = "Error Void SalesOrder." };
                }
            }
            else
            {
                return new { message = "Error. Data Not Found." };
            }
        }

        public object VoidPaymentSalesOrder(int idsalesreceiptdetail, string operatorname)
        {
            try
            {
                operatorname = _common.ChangeStringWildCardCharacterSQL(operatorname);
                string query = "EXEC sp_void_sales_receipt_detail_new " + idsalesreceiptdetail + ",'" + operatorname + "'";
                string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = result };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object PostingSalesOrderToMyapps(int idso)
        {
            try
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

                        result = _openConnection.SingleString("BEGIN TRY BEGIN TRAN DJANCUK " + querypostingso + " " + querypostingtradein + " SELECT '' [MSG] COMMIT TRAN DJANCUK END TRY BEGIN CATCH SELECT ERROR_MESSAGE() [MSG] ROLLBACK TRAN DJANCUK END CATCH", _connectionStrings.ConnectionStrings.Cnn_CMK);
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

                        result = _openConnection.SingleString("BEGIN TRY BEGIN TRAN DJANCUK " + querypostingso + " SELECT '' [MSG] COMMIT TRAN DJANCUK END TRY BEGIN CATCH SELECT ERROR_MESSAGE() [MSG] ROLLBACK TRAN DJANCUK END CATCH", _connectionStrings.ConnectionStrings.Cnn_CMK);
                    }
                    return new { message = result };
                }
                else
                {
                    return new { message = "SO tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object ValidateDownPayment(string nomor, int idcustomer, string kodecustomerlama)
        {
            try
            {
                nomor = string.IsNullOrEmpty(nomor) ? "" : _common.ChangeStringWildCardCharacterSQL(nomor);
                kodecustomerlama = _common.ChangeStringWildCardCharacterSQL(kodecustomerlama);
                string query = "EXEC sp_validate_sales_receipt_dppo_new '" + nomor + "', " + idcustomer + ",'" + kodecustomerlama + "'";
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                string msg = dt.Rows[0]["MESSAGE"].ToString();
                if (msg == "")
                {
                    return new
                    {
                        message = msg,
                        data = new
                        {
                            id = Convert.ToInt32(dt.Rows[0]["ID_DP"]),
                            nomor = dt.Rows[0]["NOMOR_DP"].ToString(),
                            customer = dt.Rows[0]["CUSTOMER"].ToString(),
                            nominal = Convert.ToDouble(dt.Rows[0]["NOMINAL"]),
                            tgl_dp = Convert.ToDateTime(dt.Rows[0]["TGL_DP"]).ToString("dd-MM-yyyy"),
                            lama_dp = dt.Rows[0]["LAMA_DP"].ToString(),
                            keterangan = dt.Rows[0]["KETERANGAN"].ToString()
                        }
                    };
                }
                else
                {
                    return new { message = msg };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object ValidatePaymentVoucher(string nomor, string loccode, string customercode)
        {
            DataTable stampsstoreid = _openConnection.Rs("SELECT TOP 1 IDStamps FROM LocStampsMapping WHERE Kode = '" + loccode + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
            if (stampsstoreid.Rows.Count == 0)
            {
                return new { message = "Store ID tidak ditemukan." };
            }
            else
            {
                nomor = string.IsNullOrEmpty(nomor) ? "" : _common.ChangeStringWildCardCharacterSQL(nomor);
                loccode = string.IsNullOrEmpty(loccode) ? "" : _common.ChangeStringWildCardCharacterSQL(loccode);
                customercode = string.IsNullOrEmpty(customercode) ? "" : _common.ChangeStringWildCardCharacterSQL(customercode);
                int store = _common.GetStampsIDLocationQuery(loccode);
                dynamic responsevoucher = _stampsConfiguration.ValidateVoucherCode(nomor, store);
                if (responsevoucher.status_code == HttpStatusCode.OK)
                {
                    StampsResponse.ResponseValidateVoucherCode voucher = Newtonsoft.Json.JsonConvert.DeserializeObject<StampsResponse.ResponseValidateVoucherCode>(responsevoucher.result);
                    if (voucher.voucher != null)
                    {
                        if (voucher.voucher.extra_data.voucher_type.ToUpper() == "DISCOUNT")
                        {
                            return new { message = "(STAMPS Validation) Voucher Jenis Discount Tidak Bisa Digunakan" };
                        }
                        /*else if (Convert.ToDateTime(voucher.voucher.end_date) > Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")))
                        {
                            return new { message = "(STAMPS Validation) Voucher Expired. Tidak Bisa Digunakan" };
                        }*/
                        else
                        {
                            string queryprepost = "EXEC sp_post_voucher_integration_new " +
                                    " '" + nomor + "'," + Convert.ToInt64(voucher.voucher.extra_data.voucher_nominal) + "," +
                                    " '" + Convert.ToDateTime(voucher.voucher.start_date).ToString("yyyy-MM-dd") + "'," +
                                    " '" + Convert.ToDateTime(voucher.voucher.end_date).ToString("yyyy-MM-dd") + "'," +
                                    " '" + voucher.voucher.extra_data.voucher_type + "','" + voucher.voucher.name + "'," +
                                    " " + voucher.voucher.id + ",'PAYMENT',''";
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
                                        nominal = Convert.ToInt32(voucher.voucher.extra_data.voucher_nominal),
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
                        return new { message = "(STAMPS Validation) " + voucher.error_message };
                    }
                }
                else
                {
                    StampsResponse.ResponseErrorGeneral errorredeem = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(responsevoucher.result);
                    return new { message = "(STAMPS Validation) " + errorredeem.detail };
                }
            }
        }

        public object AddDownPayment(RequestSalesReceiptDPPO po)
        {
            try
            {
                string querypo = "EXEC sp_insert_sales_receipt_dppo_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_PO VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (po != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_PO, [MESSAGE]) " + querypo +
                        " " + po.id_customer + ",'" + po.customer_nama + "'," + po.id_sales + "," +
                        " '" + po.sales_nama + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," +
                        " '" + po.kode_lokasi + "'," + po.tipe_lokasi + "," + po.id_lokasi + "," +
                        " " + po.total_bayar + ",'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                        " '" + po.operator_nama + "'," + po.status_dp + ",'" + po.keterangan + "'," +
                        " " + po.estimasi_harga + "," + po.id_dppo_reference + "," + po.id_product_sample1 + "," +
                        " " + po.id_product_sample2 + "," + po.id_product + "," + po.tipe_product + "," +
                        " " + po.id_frame_color + "," + po.gold_weight1 + "," + po.gold_weight2 + "," +
                        " " + po.diamond_weight1 + "," + po.diamond_weight2 + "," + po.ring_size1 + "," +
                        " " + po.ring_size2 + ",'" + po.incription1 + "','" + po.incription2 + "'," +
                        " " + po.id_font_type + ",'" + po.delivery_date.ToString("yyyy-MM-dd") + "'" +
                        " DECLARE @IDPO INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMORPO VARCHAR(50) = (SELECT TOP 1 NO_PO FROM @TABLE) ";

                    string querypayment = "EXEC sp_insert_sales_receipt_dppo_detail_new";
                    foreach (var x in po.listdppo)
                    {
                        querystart += querypayment + " @IDPO," + x.id_payment + "," +
                            " " + x.id_card + "," + x.id_program + "," + x.mdr + "," +
                            " " + x.id_edc + "," + x.id_bank_issuer + ",'" + x.cc_number + "'," +
                            " '" + x.cc_nama + "'," + x.nominal + ",'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + x.operator_nama + "'," + x.id_jenis_kartu_kredit + ", '" + x.approval_code + "'";
                    }

                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_PO], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";
                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idpo = Convert.ToInt32(result.Rows[0]["ID"]);
                    string nopo = result.Rows[0]["NO_PO"].ToString();
                    return new { message = res, id = idpo, no = nopo };
                }
                else
                {
                    return new { message = "Failed. Data Not Found." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetDownPaymentByCustomer(string kw, int idcustomer, string kodecustomerlama)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                kodecustomerlama = string.IsNullOrEmpty(kodecustomerlama) ? "" : _common.ChangeStringWildCardCharacterSQL(kodecustomerlama);
                string query = "EXEC sp_get_previous_dp_by_customer_new " + idcustomer + ",'" + kodecustomerlama + "','" + kw + "'";
                DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                List<object> dp = new List<object>();
                foreach (DataRow dr in result.Rows)
                {
                    dp.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        id_customer = Convert.ToInt32(dr["IDCUSTOMER"]),
                        customer = dr["NAMACUSTOMER"].ToString(),
                        nomor_dp = dr["NOMORDP"].ToString(),
                        tgl = Convert.ToDateTime(dr["TGL"]).ToString("dd-MM-yyyy"),
                        total_bayar = Convert.ToDouble(dr["TOTALBAYAR"]),
                        is_po = Convert.ToBoolean(dr["ISPO"]),
                        estimasi_harga = Convert.ToDouble(dr["ESTIMASIHARGA"])
                    });
                }
                return new { message = "", data = dp };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetDownPaymentByID(int id)
        {
            try
            {
                string query = "EXEC sp_get_dp_by_id_new " + id;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtpayment = ds.Tables[1];

                if (dt.Rows.Count == 1)
                {
                    List<object> payment = new List<object>();
                    foreach (DataRow p in dtpayment.Rows)
                    {
                        payment.Add(new
                        {
                            id = Convert.ToInt32(p["ID"]),
                            payment_name = p["PAYMENT_NAME"].ToString(),
                            card_name = p["CARD_NAME"].ToString(),
                            program_name = p["PROGRAM_NAME"].ToString(),
                            edc_name = p["EDC_NAME"].ToString(),
                            bank_name = p["BANK_NAME"].ToString(),
                            jenis_kartu_kredit_name = p["JENIS_KARTU_KREDIT_NAME"].ToString(),
                            cc_number = p["CC_NUMBER"].ToString(),
                            cc_name = p["CC_NAME"].ToString(),
                            nominal = Convert.ToDouble(p["NOMINAL"]),
                            operator_tgl = Convert.ToDateTime(p["OPERATOR_TGL"]).ToString("dd-MM-yyyy"),
                            operator_nama = p["OPERATOR_NAMA"].ToString(),
                            approval_code = p["APPROVAL_CODE"].ToString(),
                            mdr = Convert.ToDecimal(p["MDR"]),
                        });
                    }

                    return new
                    {
                        message = "",
                        data = new
                        {
                            id = Convert.ToInt32(dt.Rows[0]["ID"]),
                            customer_nama = dt.Rows[0]["CUSTOMER_NAMA"].ToString(),
                            nama_lokasi = dt.Rows[0]["NAMA_LOKASI"].ToString(),
                            kode_lokasi = dt.Rows[0]["KODE_LOKASI"].ToString(),
                            nomor_dp = dt.Rows[0]["NOMOR_DP"].ToString(),
                            estimasi_harga = Convert.ToDouble(dt.Rows[0]["ESTIMASI_HARGA"]),
                            keterangan = dt.Rows[0]["KETERANGAN"].ToString(),
                            tgl = Convert.ToDateTime(dt.Rows[0]["TGL"]).ToString("dd-MM-yyyy"),
                            operator_tgl = Convert.ToDateTime(dt.Rows[0]["OPERATOR_TGL"]).ToString("dd-MM-yyy hh:mm:ss"),
                            operator_nama = dt.Rows[0]["OPERATOR_NAMA"].ToString(),
                            status = dt.Rows[0]["STATUS"].ToString(),
                            sales_nama = dt.Rows[0]["SALES_NAMA"].ToString(),
                            keterangan_void = dt.Rows[0]["KETERANGAN_VOID"].ToString(),
                            no_dp_referensi = dt.Rows[0]["NODP_REFERENSI"].ToString(),
                            sample1 = dt.Rows[0]["SAMPLE1"].ToString(),
                            image_sample1 = dt.Rows[0]["IMAGE1"].ToString(),
                            sample2 = dt.Rows[0]["SAMPLE2"].ToString(),
                            image_sample2 = dt.Rows[0]["IMAGE2"].ToString(),
                            jenis_dp = dt.Rows[0]["STATUS_DP"].ToString(),
                            sample_stock = dt.Rows[0]["SAMPLE_STOCK"].ToString(),
                            image_sample_stock = dt.Rows[0]["IMAGE_STOCK"].ToString(),
                            frame_color = dt.Rows[0]["FRAME_COLOR"].ToString(),
                            gold_weight1 = Convert.ToDouble(dt.Rows[0]["GOLD_WEIGHT1"]),
                            gold_weight2 = Convert.ToDouble(dt.Rows[0]["GOLD_WEIGHT2"]),
                            diamond_weight1 = Convert.ToDouble(dt.Rows[0]["DIAMOND_WEIGHT1"]),
                            diamond_weight2 = Convert.ToDouble(dt.Rows[0]["DIAMOND_WEIGHT2"]),
                            ring_size1 = Convert.ToDouble(dt.Rows[0]["RING_SIZE1"]),
                            ring_size2 = Convert.ToDouble(dt.Rows[0]["RING_SIZE2"]),
                            incription1 = dt.Rows[0]["INCRIPTION1"].ToString(),
                            incription2 = dt.Rows[0]["INCRIPTION2"].ToString(),
                            font_type = dt.Rows[0]["FONT_TYPE"].ToString(),
                            tipe_sample1 = dt.Rows[0]["TIPE_SAMPLE1"].ToString(),
                            tipe_sample2 = dt.Rows[0]["TIPE_SAMPLE2"].ToString(),
                            tipe_stock = dt.Rows[0]["TIPE_STOCK"].ToString(),
                            payment
                        }
                    };
                }
                else
                {
                    return new { message = "Down Payment Tidak Ditemukan." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object VoidDownPayment(int id, string operatornama, string keterangan)
        {
            try
            {
                operatornama = _common.ChangeStringWildCardCharacterSQL(operatornama);
                keterangan = _common.ChangeStringWildCardCharacterSQL(keterangan);
                string queryvalidation = "EXEC sp_validation_void_dp_new " + id.ToString();
                string queryvoid = "EXEC sp_void_dp_new " + id.ToString() + ",'" + operatornama + "','" + keterangan + "'";

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

        public object ReportDownPayment(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                string query = "EXEC sp_report_down_payment_new '" + kw + "','" + start + "', '" + end + "', '" + location + "'," + status + "," + page + "," + row + "," + excel;
                DataSet dtall = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = dtall.Tables[0];
                DataTable dtcount = dtall.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    List<object> payment = new List<object>();
                    DataTable dtpayment = _openConnection.Rs("SELECT A.ID, B.Nama [PAYMENTNAMA], ISNULL(A.Nominal,0) [NOMINAL] FROM SalesReceiptDPPODetail A " +
                        " JOIN PaymentType B ON A.IDPaymentType = B.ID " +
                        " WHERE IDSalesReceipt = " + Convert.ToInt32(dr["ID"]).ToString(), _connectionStrings.ConnectionStrings.Cnn_DB);
                    foreach (DataRow dr2 in dtpayment.Rows)
                    {
                        payment.Add(new
                        {
                            payment_name = dr2["PAYMENTNAMA"].ToString(),
                            nominal = Convert.ToDouble(dr2["NOMINAL"])
                        });
                    }

                    dtpayment.Dispose();

                    dtobject.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        nomor = dr["NOMORDP"].ToString(),
                        tgl = Convert.ToDateTime(dr["TGL"]).ToString("dd-MM-yyyy"),
                        store = dr["NAMALOKASI"].ToString(),
                        sales = dr["SALESNAMA"].ToString(),
                        customer = dr["CUSTOMERNAMA"].ToString(),
                        no_so = dr["NOSO"].ToString(),
                        total_bayar = Convert.ToDouble(dr["TOTALBAYAR"]),
                        estimasi_harga = Convert.ToDouble(dr["ESTIMASIHARGA"]),
                        payment,
                        keterangan = dr["KETERANGAN"].ToString(),
                        keterangan_void = dr["KETERANGANVOID"].ToString(),
                        is_po = Convert.ToBoolean(dr["ISDPPO"]),
                        id_so = Convert.ToInt32(dr["IDSO"]),
                        is_used = Convert.ToInt32(dr["IDSO"]) == 0 ? false : true,
                        cash = Convert.ToDecimal(dr["CASH"]),
                        credit_card = Convert.ToDecimal(dr["CREDIT_CARD"]),
                        transfer = Convert.ToDecimal(dr["TRANSFER"]),
                        debit_card = Convert.ToDecimal(dr["DEBIT_CARD"]),
                        voucher = Convert.ToDecimal(dr["VOUCHER"]),
                        exchange = Convert.ToDecimal(dr["EXCHANGE"]),
                        poin = Convert.ToDecimal(dr["POIN"]),
                        down_payment = Convert.ToDecimal(dr["DOWN_PAYMENT"]),
                        bridestory_pay = Convert.ToDecimal(dr["BRIDESTORY_PAY"]),
                        gift_card = Convert.ToDecimal(dr["GIFT_CARD"]),
                        laku_tukar = Convert.ToDecimal(dr["LAKU_EMAS"]),
                        qris = Convert.ToDecimal(dr["QRIS"]),
                        xendit = Convert.ToDecimal(dr["XENDIT"]),
                        qris_lei = Convert.ToDecimal(dr["QRIS_LEI"]),
                        bank = dr["BANK"].ToString(),
                        edc = dr["EDC"].ToString()
                    });
                }

                return new { message = "", data = dtobject, total = Convert.ToInt64(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object UploadImageDownPayment(IFormFile files, int id, string brand)
        {
            return _common.UploadImageSO(files, id, id.ToString(), brand, Common.ActionUpload.DownPayment);
        }

        public object ReportSummaryPaymentSalesOrder(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                string query = "EXEC sp_report_payment_new '" + kw + "','" + start + "','" + end + "','" + location + "'," + status + "," + page + "," + row + "," + excel;
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);

                List<object> dtobject = new List<object>();
                foreach (DataRow x in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        idpayment = Convert.ToInt32(x["IDPayment"]),
                        nama = x["Nama"].ToString(),
                        total_bayar = Convert.ToInt64(x["TotalBayar"]),
                        mdr = Convert.ToInt64(x["MDR"])
                    });
                }
                return new { message = "", data = dtobject };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
    }
}
