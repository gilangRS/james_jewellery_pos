using Connection.Interface;
using Connection.Models;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Repositories
{
    public class TitipanRepository : ITitipanRepository
    {
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        private Common _common;

        public TitipanRepository()
        {
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
            _common = new Common();
        }

        public object AddTitipan(RequestTitipan rt)
        {
            try
            {
                string querytitipan = "EXEC sp_insert_titipan_customer_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_TK VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (rt != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_TK, [MESSAGE]) " + querytitipan +
                        " " + rt.id_lokasi + "," + rt.tipe_lokasi + "," +
                        " '" + rt.kode_lokasi + "'," + rt.id_customer + "," +
                        " '" + rt.customer_nama + "'," + rt.id_sales + "," +
                        " '" + rt.sales_nama + "','" + rt.operator_nama + "'," +
                        " '" + rt.operator_tgl.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                        " '" + rt.tgl_selesai.ToString("yyyy-MM-dd") + "'," +
                        " '" + rt.keterangan + "'," + rt.product.id_product + "," +
                        " " + rt.product.id_product_titipan + "," + rt.product.id_doc_qc + "," +
                        " " + rt.product.tipe_product + ",'" + rt.product.keterangan + "'," +
                        " '" + rt.files.FileName + "'" +
                        " DECLARE @IDTK INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMORTK VARCHAR(50) = (SELECT TOP 1 NO_TK FROM @TABLE) ";

                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_TK], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";
                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idtk = Convert.ToInt32(result.Rows[0]["ID"]);
                    string notk = result.Rows[0]["NO_TK"].ToString();
                    var resultupload = UploadImageTitipan(rt.files, idtk, _connectionStrings.AppConfig.BrandCode);
                    return new { message = res, id = idtk, no = notk };
                }
                else
                {
                    return new { message = "Failed. Data Not Found" };
                }
            }
            catch(Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetTitipan(int id)
        {
            try
            {
                string query = "EXEC sp_get_titipan_customer_by_id_new " + id;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = ds.Tables[0];
                DataTable dtitem = ds.Tables[1];
                if (dtheader.Rows.Count == 1) 
                {
                    List<object> items = new List<object>();
                    foreach(DataRow x in dtitem.Rows)
                    {
                        items.Add(new 
                        { 
                            id = Convert.ToInt32(x[0]),
                            nomor = x[1].ToString(),
                            item = x[2].ToString(),
                            image = _common.ImageCDN(x[3].ToString())
                        });
                    }
                    return new { message = "", data = new
                    {
                        id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                        nomor = dtheader.Rows[0]["NOMOR"].ToString(),
                        customer_nama = dtheader.Rows[0]["CUSTOMER"].ToString(),
                        sales_nama = dtheader.Rows[0]["SALES"].ToString(),
                        tgl = Convert.ToDateTime(dtheader.Rows[0]["TGL"]).ToString("dd-MM-yyyy"),
                        tgl_selesai = Convert.ToDateTime(dtheader.Rows[0]["TGL_SELESAI"]).ToString("dd-MM-yyyy"),
                        lokasi = dtheader.Rows[0]["LOKASI"].ToString(),
                        keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                        alamat = dtheader.Rows[0]["ALAMAT"].ToString(),
                        item = items
                    }}; 
                }
                else
                {
                    return new { message = "Titipan Tidak Ditemukan." };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetTitipanItemByCustomer(int idcustomer, string custlama)
        {
            try
            {
                string query = "sp_get_titipan_item_by_customer_new";
                DataTable dt = _openConnection.Rs("EXEC " + query + " " + idcustomer.ToString() + " ,'" + custlama + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id_sales_order = Convert.ToInt32(dr["ID_SALES_ORDER"]),
                        id_product = Convert.ToInt32(dr["ID_PRODUCT"]),
                        tipe = dr["TIPE"].ToString(),
                        nomor = dr["NOMOR"].ToString(),
                        noso = dr["NOSO"].ToString(),
                        invoice = dr["NO_INVOICE"].ToString(),
                        harga_beli = Convert.ToDouble(dr["HARGA_BELI"]),
                        item = dr["ITEM"].ToString(),
                        store_asal = dr["STORE_ASAL"].ToString(),
                        image = _common.ImageCDN(dr["IMAGE"].ToString())
                    });
                }
                return new { message = "", data = dtobject };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object ReportTitipan(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                string query = "EXEC sp_report_titipan_new '" + kw + "','" + start + "','" + end + "','" + location + "'," + status + "," + page + "," + row + "," + excel;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        lokasi = dr["LOKASI"].ToString(),
                        tgl = Convert.ToDateTime(dr["TANGGAL"]).ToString("dd-MM-yyyy"),
                        plu = dr["PLU"].ToString(),
                        tipe = dr["TIPE"].ToString(),
                        no_referensi = dr["NO_REFERENCE"].ToString(),
                        customer = dr["CUSTOMER_NAMA"].ToString(),
                        sales = dr["SALES_NAMA"].ToString(),
                        qty = Convert.ToInt32(dr["QTY"]),
                        status = dr["STATUS"].ToString()
                    });
                }
                return new { message = "", data = dtobject , total = Convert.ToUInt64(dtcount.Rows[0][0])};
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object UploadImageTitipan(IFormFile files, int id, string brand)
        {
            return _common.UploadImageSO(files, id, id.ToString(), brand, Common.ActionUpload.DocTitipan);
        }

        public object UploadImageDJCustomer(IFormFile files, int id, string brand)
        {
            return _common.UploadImageSO(files, id, id.ToString(), brand, Common.ActionUpload.StockProductDJCustomer);
        }

        public object AddNewProductTitipan(RequestStockProductDJCustomer sdjc)
        {
            try
            {
                string querynewtitipan = "EXEC sp_insert_stock_product_dj_customer_new";
                string querynewtitipanstone = "EXEC sp_insert_stock_product_stone_dj_customer_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NOMOR VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (sdjc != null && sdjc.char_product != "")
                {
                    RequestCharProductDJCustomer cpdj = JsonConvert.DeserializeObject<RequestCharProductDJCustomer>(sdjc.char_product);

                    querystart = querystart + " INSERT INTO @TABLE(ID, NOMOR, [MESSAGE]) " + querynewtitipan + " '" + sdjc.keterangan + "'," +
                        " '" + sdjc.operator_nama + "'," +
                        " ''," + cpdj.char_product.product_item + "," +
                        " " + cpdj.char_product.gross_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + cpdj.char_product.stone_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                        " " + cpdj.char_product.stone_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + Convert.ToInt64(cpdj.char_product.stone_qty) + "," +
                        " " + cpdj.char_product.netto_weight + "," + cpdj.char_product.dimensi_d + "," +
                        " " + cpdj.char_product.dimensi_p + "," + cpdj.char_product.dimensi_l + "," +
                        " " + cpdj.char_product.dimensi_r + " DECLARE @ID INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMOR VARCHAR(50) = (SELECT TOP 1 NOMOR FROM @TABLE) ";

                    foreach (var stone1A in cpdj.stone1A)
                    {
                        querystart += querynewtitipanstone + " '1A',@ID," + stone1A.id_stone + "," +
                            " " + stone1A.total_butir + "," + stone1A.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone1A.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + stone1A.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone1A.dimnesi_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'' ";
                    }

                    foreach (var stone1B in cpdj.stone1B)
                    {
                        querystart += querynewtitipanstone + " '1B',@ID," + stone1B.id_stone + "," +
                        " " + stone1B.total_butir + "," + stone1B.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone1B.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                        " " + stone1B.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone1B.dimnesi_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'" + stone1B.gia + "' ";
                    }

                    foreach (var stone2 in cpdj.stone2)
                    {
                        querystart += querynewtitipanstone + " '2',@ID," + stone2.id_stone + "," +
                            " " + stone2.total_butir + "," + stone2.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone2.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + stone2.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone2.dimnesi_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'' ";
                    }

                    foreach (var stone3 in cpdj.stone3)
                    {
                        querystart += querynewtitipanstone + " '3',@ID," + stone3.id_stone + "," +
                            " " + stone3.total_butir + "," + stone3.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone3.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + stone3.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone3.dimnesi_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'' ";
                    }

                    foreach (var stone4 in cpdj.stone4)
                    {
                        querystart += querynewtitipanstone + " '4',@ID," + stone4.id_stone + "," +
                            " " + stone4.total_butir + "," + stone4.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone4.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + stone4.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone4.dimnesi_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'' ";
                    }

                    foreach (var stone5 in cpdj.stone5)
                    {
                        querystart += querynewtitipanstone + " '5',@ID," + stone5.id_stone + "," +
                            " " + stone5.total_butir + "," + stone5.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone5.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + stone5.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + stone5.dimnesi_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'' ";
                    }

                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NOMOR], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";
                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idtk = Convert.ToInt32(result.Rows[0]["ID"]);
                    string notk = result.Rows[0]["NOMOR"].ToString();
                    var resultupload = UploadImageDJCustomer(sdjc.images, idtk, _connectionStrings.AppConfig.BrandCode);
                    return new { message = res, id = idtk, no = notk };
                }
                else
                {
                    return new { message = "Error cuk." };
                }
            }
            catch(Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetProsesTitipan()
        {
            var prosestitipan = _openConnection.Rs("EXEC sp_get_list_status_titipan_new", _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in prosestitipan.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(item["ID"]),
                    nama = item["Nama"].ToString()
                });
            }
            return result;
        }

        public object UpdateStatusTitipan(int id, int id_status_titipan)
        {
            try
            {
                string query = "EXEC sp_update_status_titipan_new " + id + "," + id_status_titipan;
                string result = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = result };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }

        }
    }
}
