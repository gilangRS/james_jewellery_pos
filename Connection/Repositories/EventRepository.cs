using Connection.Interface;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        private Common _common;

        public EventRepository()
        {
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
            _common = new Common();
        }

        public object AddPromoEvent(RequestPromoEvent rpe)
        {
            try
            {
                if (rpe != null)
                {
                    string querystart = "DECLARE @TABLE TABLE(ID INT, NAMA_PROMO_EVENT VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                    string queryinsert = "EXEC sp_insert_promo_event_so_new ";
                    querystart += "INSERT INTO @TABLE(ID, NAMA_PROMO_EVENT, MESSAGE) " + queryinsert + "'" + rpe.nama + "'," +
                    " '" + rpe.start_date.ToString("yyyy-MM-dd") + "','" + rpe.end_date.ToString("yyyy-MM-dd") + "'," +
                    " '" + rpe.keterangan + "','" + rpe.operator_nama + "' " +
                    " DECLARE @IDQC INT = (SELECT TOP 1 ID FROM @TABLE) ";

                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NAMA_PROMO_EVENT], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idqc = Convert.ToInt32(result.Rows[0]["ID"]);
                    string namaevent = result.Rows[0]["NAMA_PROMO_EVENT"].ToString();
                    return new { message = res, id = idqc, no = namaevent };
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

        public object GetPromoEvent(int id)
        {
            try
            {
                string query = "sp_get_promo_event_new " + id;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = ds.Tables[0];

                if (dtheader.Rows.Count == 1)
                {
                    return new
                    {
                        message = "",
                        data = new
                        {
                            id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                            tipe = dtheader.Rows[0]["TIPE"].ToString(),
                            nama = dtheader.Rows[0]["NAMA"].ToString(),
                            start_date = Convert.ToDateTime(dtheader.Rows[0]["START_DATE"]).ToString("dd-MM-yyyy"),
                            end_date = Convert.ToDateTime(dtheader.Rows[0]["END_DATE"]).ToString("dd-MM-yyyy"),
                            status = dtheader.Rows[0]["STATUS"].ToString(),
                            keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                            created_by = dtheader.Rows[0]["CREATED_BY"].ToString(),
                            created_date = Convert.ToDateTime(dtheader.Rows[0]["CREATED_DATE"]).ToString("dd-MM-yyyy"),
                            approved_by = (dtheader.Rows[0]["APPROVED_BY"] == DBNull.Value) ? "" : dtheader.Rows[0]["APPROVED_BY"].ToString(),
                            approved_date = (dtheader.Rows[0]["APPROVED_DATE"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVED_DATE"]).ToString("dd-MM-yyyy")
                        }
                    };
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

        public object ReportPromoEvent(string kw, string startdate, string enddate, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                string query = "EXEC sp_report_promo_event_new '" + kw + "'," +
                    " '" + startdate + "','" + enddate + "'," + status + "," +
                    " " + page + "," + row + "," + excel;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        nama = dr["NAMA"].ToString(),
                        start_date = Convert.ToDateTime(dr["START_DATE"]).ToString("dd-MM-yyyy"),
                        end_date = Convert.ToDateTime(dr["END_DATE"]).ToString("dd-MM-yyyy"),
                        status = dr["STATUS"].ToString(),
                        created_by = dr["CREATED_BY"].ToString(),
                        created_date = Convert.ToDateTime(dr["CREATED_DATE"]).ToString("dd-MM-yyyy hh:mm:ss.fff"),
                        approved_by = (dr["APPROVED_BY"] == DBNull.Value) ? "" : dr["APPROVED_BY"].ToString(),
                        approved_date = (dr["APPROVED_DATE"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVED_DATE"]).ToString("dd-MM-yyyy hh:mm:ss.fff"),
                        keterangan = dr["KETERANGAN"].ToString()
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetActivePromoEvent()
        {
            string query = "EXEC sp_get_list_active_promo_event_new";
            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(dr["ID"]),
                    nama = dr["NAMA"],
                });
            }
            return result;
        }

        public object ApprovalPromoEvent(int id, string operatornama)
        {
            try
            {
                string query = "EXEC sp_approval_promo_event_new " + id + ",'" + operatornama + "'";
                string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = result };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object DisablePromoEvent(int id, string operatornama, string keterangan)
        {
            try
            {
                string query = "EXEC sp_disable_promo_event_new " + id + ",'" + operatornama + "','" + keterangan + "'";
                string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = result };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object AddPromoBank(RequestPromoBank rpb)
        {
            try
            {
                if (rpb != null)
                {
                    string querystart = "DECLARE @TABLE TABLE(ID INT, NAMA_PROMO_BANK VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                    string queryinsert = "EXEC sp_insert_promo_bank_so_new ";
                    querystart += "INSERT INTO @TABLE(ID, NAMA_PROMO_BANK, MESSAGE) " + queryinsert + "'" + rpb.nama + "'," +
                    " '" + rpb.start_date.ToString("yyyy-MM-dd") + "','" + rpb.end_date.ToString("yyyy-MM-dd") + "'," +
                    " '" + rpb.keterangan + "','" + rpb.operator_nama + "' " +
                    " DECLARE @ID_PROMO_BANK INT = (SELECT TOP 1 ID FROM @TABLE) ";

                    foreach (var detail in rpb.details)
                    {
                        string queryinsertdetail = "EXEC sp_insert_promo_bank_detail_so_new ";
                        querystart += queryinsertdetail + "@ID_PROMO_BANK," + detail.id_payment_type + "," +
                        " " + detail.id_bank + ",'" + detail.nama + "'," + detail.max_value + "," +
                        " " + detail.min_value + "," + detail.discount + "," + detail.order_number + " ";
                    }

                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NAMA_PROMO_BANK], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idqc = Convert.ToInt32(result.Rows[0]["ID"]);
                    string namaevent = result.Rows[0]["NAMA_PROMO_BANK"].ToString();
                    return new { message = res, id = idqc, no = namaevent };
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

        public object GetPromoBank(int id)
        {
            try
            {
                string query = "sp_get_promo_bank_new " + id;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = ds.Tables[0];
                DataTable dtdetail = ds.Tables[1];

                if (dtheader.Rows.Count == 1)
                {
                    List<object> detail = new List<object>();
                    foreach (DataRow i in dtdetail.Rows)
                    {
                        detail.Add(new
                        {
                            id = Convert.ToInt32(i["ID"]),
                            payment = i["PAYMENT_NAMA"].ToString(),
                            card = i["BANK_NAMA"].ToString(),
                            min_value = Convert.ToDouble(i["MIN_VALUE"]),
                            max_value = Convert.ToDouble(i["MAX_VALUE"]),
                            discount = Convert.ToDouble(i["DISCOUNT"]),
                            order_number = Convert.ToInt32(i["ORDER_NUMBER"])
                        });
                    }
                    return new
                    {
                        message = "",
                        data = new
                        {
                            id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                            tipe = dtheader.Rows[0]["TIPE"].ToString(),
                            nama = dtheader.Rows[0]["NAMA"].ToString(),
                            start_date = Convert.ToDateTime(dtheader.Rows[0]["START_DATE"]).ToString("dd-MM-yyyy"),
                            end_date = Convert.ToDateTime(dtheader.Rows[0]["END_DATE"]).ToString("dd-MM-yyyy"),
                            status = dtheader.Rows[0]["STATUS"].ToString(),
                            keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                            created_by = dtheader.Rows[0]["CREATED_BY"].ToString(),
                            created_date = Convert.ToDateTime(dtheader.Rows[0]["CREATED_DATE"]).ToString("dd-MM-yyyy"),
                            approved_by = (dtheader.Rows[0]["APPROVED_BY"] == DBNull.Value) ? "" : dtheader.Rows[0]["APPROVED_BY"].ToString(),
                            approved_date = (dtheader.Rows[0]["APPROVED_DATE"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVED_DATE"]).ToString("dd-MM-yyyy"),
                            details = detail
                        }
                    };
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

        public object ReportPromoBank(string kw, string startdate, string enddate, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                string query = "EXEC sp_report_promo_bank_new '" + kw + "'," +
                        " '" + startdate + "','" + enddate + "'," + status + "," +
                        " " + page + "," + row + "," + excel;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        nama = dr["NAMA"].ToString(),
                        start_date = Convert.ToDateTime(dr["START_DATE"]).ToString("dd-MM-yyyy"),
                        end_date = Convert.ToDateTime(dr["END_DATE"]).ToString("dd-MM-yyyy"),
                        status = dr["STATUS"].ToString(),
                        created_by = dr["CREATED_BY"].ToString(),
                        created_date = Convert.ToDateTime(dr["CREATED_DATE"]).ToString("dd-MM-yyyy hh:mm:ss.fff"),
                        approved_by = (dr["APPROVED_BY"] == DBNull.Value) ? "" : dr["APPROVED_BY"].ToString(),
                        approved_date = (dr["APPROVED_DATE"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVED_DATE"]).ToString("dd-MM-yyyy hh:mm:ss.fff"),
                        keterangan = dr["KETERANGAN"].ToString()
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetActivePromoBank(int id, string producttype)
        {
            string query = "EXEC sp_get_list_active_promo_bank_new " + id + ",'" + producttype + "'";
            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(dr["ID"]),
                    id_form = Convert.ToInt32(dr["IDFORM"]),
                    nama = dr["NAMA"],
                    discount = Convert.ToDouble(dr["DISCOUNT"]),
                    bank = dr["BANK"]
                });
            }
            return result;
        }

        public object ApprovalPromoBank(int id, string operatornama)
        {
            try
            {
                string query = "EXEC sp_approval_promo_bank_new " + id + ",'" + operatornama + "'";
                string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = result };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object DisablePromoBank(int id, string operatornama, string keterangan)
        {
            try
            {
                string query = "EXEC sp_disable_promo_bank_new " + id + ",'" + operatornama + "','" + keterangan + "'";
                string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = result };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetRoleApproval(int iduser)
        {
            try
            {
                string query = "EXEC get_role_user_for_approval " + iduser;
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_AC);
                int rowcount = dt.Rows.Count;
                if (rowcount == 1)
                {
                    return new { message = "", role = dt.Rows[0]["ROLE"].ToString() };
                }
                else
                {
                    return new { message = "", role = "UNKNOWN" };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object ReportPemakaianPromo(string kw, string startdate, string enddate, string location, int tipe, int status, int page, int rows, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "EXEC sp_report_pemakaian_promo_bank_event_new '" + kw + "','" + startdate + "'," +
                    " '" + enddate + "','" + location + "'," + tipe + "," + status + "," + page + "," + rows + "," + excel;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id_so = Convert.ToInt32(dr["ID_TRANSACTION"]),
                        tgl_so = Convert.ToDateTime(dr["TGL_TRANSACTION"]).ToString("dd-MM-yyyy"),
                        no_so = dr["NO_TRANSACTION"].ToString(),
                        invoice = dr["NO_INVOICE"].ToString(),
                        store = dr["STORE"].ToString(),
                        customer = dr["CUSTOMER_NAME"].ToString(),
                        sales = dr["SALES_NAME"].ToString(),
                        product_type = dr["PRODUCT_TYPE"].ToString(),
                        plu = dr["PRODUCT_CODE"].ToString(),
                        item = dr["PRODUCT_ITEM"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        nett_price = Convert.ToInt64(dr["NETT_PRICE"]),
                        nama_promo = dr["NAMA_PROMO"].ToString(),
                        nominal_promo = Convert.ToInt64(dr["NOMINAL_PROMO"])

                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }
    }
}
