using Connection.Interface;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Connection.Repositories
{
    public class DocQCRepository : IDocQCRepository
    {
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        private Common _common;

        public DocQCRepository()
        {
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
            _common = new Common();
        }

        public object AddQCDJ(RequestDocQCDJ dj, string operatornama)
        {
            try
            {
                string querydj = "EXEC sp_insert_qc_dj_new";
                string querystone = "EXEC sp_insert_qc_dj_stone_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_QC VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (dj != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_QC, [MESSAGE]) " + querydj +
                        " '" + dj.qc_nama + "','" + dj.kode_lokasi + "'," +
                        " " + dj.id_product + ", '" + dj.logo + "'," +
                        " '" + dj.kadar_emas + "', '" + dj.gross_weight.ToString("N2") + "'," +
                        " '" + dj.warna_emas + "', '" + dj.fisik_keseluruhan + "'," +
                        " '" + operatornama + "', " + " '" + dj.keterangan + "'," + 
                        " " + dj.gross_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) +
                        " DECLARE @IDQC INT = (SELECT TOP 1 ID FROM @TABLE) ";

                    foreach (var stone1A in dj.stone1A)
                    {
                        querystart += querystone + " @IDQC, " + stone1A.id_stone + "," +
                            "'1A', '" + stone1A.keterangan + "', " + stone1A.total_butir_actual + "," +
                            " " + stone1A.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone1A.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone1B in dj.stone1B)
                    {
                        querystart += querystone + " @IDQC, " + stone1B.id_stone + "," +
                            "'1B', '" + stone1B.keterangan + "', " + stone1B.total_butir_actual + "," +
                            " " + stone1B.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone1B.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone2 in dj.stone2)
                    {
                        querystart += querystone + " @IDQC, " + stone2.id_stone + "," +
                            "'2', '" + stone2.keterangan + "', " + stone2.total_butir_actual + "," +
                            " " + stone2.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone2.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone3 in dj.stone3)
                    {
                        querystart += querystone + " @IDQC, " + stone3.id_stone + "," +
                            "'3', '" + stone3.keterangan + "', " + stone3.total_butir_actual + "," +
                            " " + stone3.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone3.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone4 in dj.stone4)
                    {
                        querystart += querystone + " @IDQC, " + stone4.id_stone + "," +
                            "'4', '" + stone4.keterangan + "', " + stone4.total_butir_actual + "," +
                            " " + stone4.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone4.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone5 in dj.stone5)
                    {
                        querystart += querystone + " @IDQC, " + stone5.id_stone + "," +
                            "'5', '" + stone5.keterangan + "', " + stone5.total_butir_actual + "," +
                            " " + stone5.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone5.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_QC], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idqc = Convert.ToInt32(result.Rows[0]["ID"]);
                    string noqc = result.Rows[0]["NO_QC"].ToString();
                    return new { message = res, id = idqc, no = noqc };
                }
                else
                {
                    return new { message = "Failed. Data Not Found" };
                }
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object AddQCGJ(RequestDocQCGJ gj, string operatornama)
        {
            try
            {
                string querygj = "EXEC sp_insert_qc_gj_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_QC VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (gj != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_QC, [MESSAGE]) " + querygj +
                        " '" + gj.qc_nama + "','" + gj.kode_lokasi + "'," +
                        " " + gj.id_product + ", '" + gj.logo + "'," +
                        " '" + gj.kadar_emas + "', '" + gj.gross_weight.ToString("N2") + "'," +
                        " '" + gj.warna_emas + "', '" + gj.fisik_keseluruhan + "'," +
                        " '" + operatornama + "', '" + gj.keterangan + "'," + 
                        " " + gj.gross_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) +
                        " DECLARE @IDQC INT = (SELECT TOP 1 ID FROM @TABLE) ";
                }

                string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_QC], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                string res = result.Rows[0]["MESSAGE"].ToString();
                int idqc = Convert.ToInt32(result.Rows[0]["ID"]);
                string noqc = result.Rows[0]["NO_QC"].ToString();
                return new { message = res, id = idqc, no = noqc };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object AddQCLD(RequestDocQCLD ld, string operatornama)
        {
            try
            {
                string queryld = "EXEC sp_insert_qc_ld_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_QC VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (ld != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_QC, [MESSAGE]) " + queryld +
                        " '" + ld.qc_nama + "','" + ld.kode_lokasi + "'," +
                        " " + ld.id_product + ",'" + ld.jumlah_butir.ToString() + "','" + ld.sertifikat + "', '" + ld.logo + "'," +
                        " '" + ld.kadar_emas + "', '" + ld.gross_weight.ToString("N2") + "'," +
                        " '" + ld.warna_emas + "', '" + ld.fisik_keseluruhan + "'," +
                        " '" + operatornama + "', '" + ld.keterangan + "'," + ld.gross_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                        " " + ld.carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'" + ld.colour + "'," +
                        " '" + ld.clarity + "', '" + ld.cutting + "', " + ld.harga_jual_customer.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                        " '" + ld.item + "', '" + ld.shape + "', '" + ld.brand + "', '" + ld.check_sertifikat + "'," +
                        " '" + ld.check_invoice + "', '" + ld.check_laser_incription + "', '" + ld.check_measurement + "'," +
                        " '" + ld.check_kondisi_batu + "', '" + Newtonsoft.Json.JsonConvert.SerializeObject(ld.extension_ld) + "'," +
                        " '" + ld.tradein_or_resell + "' " +
                        " DECLARE @IDQC INT = (SELECT TOP 1 ID FROM @TABLE) ";
                }

                string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_QC], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                string res = result.Rows[0]["MESSAGE"].ToString();
                int idqc = Convert.ToInt32(result.Rows[0]["ID"]);
                string noqc = result.Rows[0]["NO_QC"].ToString();
                return new { message = res, id = idqc, no = noqc };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object AddQCPG(RequestDocQCPG pg, string operatornama)
        {
            try
            {
                string querypg = "EXEC sp_insert_qc_pg_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_QC VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (pg != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_QC, [MESSAGE]) " + querypg +
                        " '" + pg.qc_nama + "','" + pg.kode_lokasi + "'," +
                        " " + pg.id_product + ", '" + pg.logo + "'," +
                        " '" + pg.kadar_logam + "', '" + pg.gross_weight.ToString("N2") + "'," +
                        " '" + pg.warna_emas + "', '" + pg.fisik_keseluruhan + "'," +
                        " '" + operatornama + "', '" + pg.keterangan + "'," + 
                        " " + pg.gross_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'" + pg.kadar_karatimeter + "'" +
                        " DECLARE @IDQC INT = (SELECT TOP 1 ID FROM @TABLE) ";
                }

                string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_QC], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                string res = result.Rows[0]["MESSAGE"].ToString();
                int idqc = Convert.ToInt32(result.Rows[0]["ID"]);
                string noqc = result.Rows[0]["NO_QC"].ToString();
                return new { message = res, id = idqc, no = noqc };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object AddQCDJTitipan(RequestDocQCDJCustomer dj, string operatornama)
        {
            try
            {
                string querydj = "EXEC sp_insert_qc_titipan_dj_new";
                string querystone = "EXEC sp_insert_qc_titipan_dj_stone_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_QC VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (dj != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_QC, [MESSAGE]) " + querydj +
                        " '" + dj.qc_nama + "','" + dj.kode_lokasi + "'," +
                        " " + dj.id_product + ", '" + dj.logo + "'," +
                        " '" + dj.kadar_emas + "', '" + dj.gross_weight.ToString("N2") + "'," +
                        " '" + dj.warna_emas + "', '" + dj.fisik_keseluruhan + "'," +
                        " '" + operatornama + "', '" + dj.keterangan + "'," + dj.gross_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) +
                        " DECLARE @IDQC INT = (SELECT TOP 1 ID FROM @TABLE) ";

                    foreach (var stone1A in dj.stone1A)
                    {
                        querystart += querystone + " @IDQC, " + stone1A.id_stone + "," +
                            "'1A', '" + stone1A.keterangan + "', " + stone1A.total_butir_actual + "," +
                            " " + stone1A.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone1A.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone1B in dj.stone1B)
                    {
                        querystart += querystone + " @IDQC, " + stone1B.id_stone + "," +
                            "'1B', '" + stone1B.keterangan + "', " + stone1B.total_butir_actual + "," +
                            " " + stone1B.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone1B.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone2 in dj.stone2)
                    {
                        querystart += querystone + " @IDQC, " + stone2.id_stone + "," +
                            "'2', '" + stone2.keterangan + "', " + stone2.total_butir_actual + "," +
                            " " + stone2.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone2.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone3 in dj.stone3)
                    {
                        querystart += querystone + " @IDQC, " + stone3.id_stone + "," +
                            "'3', '" + stone3.keterangan + "', " + stone3.total_butir_actual + "," +
                            " " + stone3.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone3.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone4 in dj.stone4)
                    {
                        querystart += querystone + " @IDQC, " + stone4.id_stone + "," +
                            "'4', '" + stone4.keterangan + "', " + stone4.total_butir_actual + "," +
                            " " + stone4.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone4.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    foreach (var stone5 in dj.stone5)
                    {
                        querystart += querystone + " @IDQC, " + stone5.id_stone + "," +
                            "'5', '" + stone5.keterangan + "', " + stone5.total_butir_actual + "," +
                            " " + stone5.total_carat_actual.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + (stone5.sesuai_sertifikat ? 1 : 0).ToString() + " ";
                    }

                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_QC], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idqc = Convert.ToInt32(result.Rows[0]["ID"]);
                    string noqc = result.Rows[0]["NO_QC"].ToString();
                    return new { message = res, id = idqc, no = noqc };
                }
                else
                {
                    return new { message = "Failed. Data Not Found" };
                }
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object ApprovalQCLD(int id, decimal harga, string keterangan, string approvalname, int iduser)
        {
            try
            {
                string query = "EXEC sp_approval_qc_ld_new " + id + "," +
                    " " + harga.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                    " '" + keterangan + "','" + _common.GetModeApprovalQCLD(iduser) + "'," + 
                    " '" + approvalname + "'";
                _openConnection.Execute(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = "" };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object GetRoleApprovalQCLD(int iduser)
        {
            try
            {
                string query = "EXEC sp_get_role_user_for_approval_qc_ld " + iduser;
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_AC);
                int rowcount = dt.Rows.Count;
                if(rowcount == 1)
                {
                    return new { message = "", role = dt.Rows[0]["ROLE"].ToString() };
                }
                else
                {
                    return new { message = "", role = "UNKNOWN" };
                }
            }
            catch(Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object GetListQCLDNotApproved(string kw, string start, string end, int iduser, int excel, int page, int row)
        {
            try
            {
                string query = "EXEC sp_get_list_qc_ld_not_approved_new '" + kw + "'," +
                    " '" + start + "','" + end + "','" + _common.GetModeApprovalQCLD(iduser) + "'," + excel + "," +
                    " " + page + "," + row;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> listqc = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    listqc.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        id_product = Convert.ToInt32(dr["ID_PRODUCT"]),
                        tipe = dr["TIPE"].ToString(),
                        nomor = dr["NOMOR"].ToString(),
                        item = dr["ITEM"].ToString(),
                        no_qc = dr["NOQC"].ToString(),
                        qc_nama = dr["QC_NAMA"].ToString(),
                        operator_nama = dr["OPERATOR_NAMA"].ToString(),
                        operator_tgl = Convert.ToDateTime(dr["OPERATOR_TGL"]).ToString("dd-MM-yyyy")
                    });
                }
                return new { message = "", data = listqc, total = Convert.ToInt64(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object ReportQC(string kw, string start, string end, string location, string tipe, int excel, int page, int row)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "EXEC sp_report_qc_new '" + kw + "','" + start + "','" +
                    end + "','" + location + "','" + tipe + "'," + excel + "," + page + "," + row;
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> listqc = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    listqc.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        id_product = Convert.ToInt32(dr["ID_PRODUCT"]),
                        tipe = dr["TIPE"].ToString(),
                        nomor = dr["NOMOR"].ToString(),
                        item = dr["ITEM"].ToString(),
                        no_qc = dr["NOQC"].ToString(),
                        qc_nama = dr["QC_NAMA"].ToString(),
                        operator_nama = dr["OPERATOR_NAMA"].ToString(),
                        operator_tgl = Convert.ToDateTime(dr["OPERATOR_TGL"]).ToString("dd-MM-yyyy"),
                        approval_sm = dr["APPROVALSM"].ToString(),
                        approval_sm_tgl = (dr["APPROVALSMTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVALSMTGL"]).ToString("dd-MM-yyyy"),
                        approval_sm_time = (dr["APPROVALSMTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVALSMTGL"]).ToString("HH:mm:ss"),
                        approval_am = dr["APPROVALAM"].ToString(),
                        approval_am_tgl = (dr["APPROVALSMTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVALAMTGL"]).ToString("dd-MM-yyyy"),
                        approval_am_time = (dr["APPROVALSMTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVALAMTGL"]).ToString("HH:mm:ss"),
                        approval_procurement = dr["APPROVALPROCUREMENT"].ToString(),
                        approval_procurement_tgl = (dr["APPROVALPROCUREMENTTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVALPROCUREMENTTGL"]).ToString("dd-MM-yyyy"),
                        approval_procurement_time = (dr["APPROVALPROCUREMENTTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVALPROCUREMENTTGL"]).ToString("HH:mm:ss"),
                        approval_final = dr["APPROVALFINAL"].ToString(),
                        approval_final_tgl = (dr["APPROVALFINALTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVALFINALTGL"]).ToString("dd-MM-yyyy"),
                        approval_final_time = (dr["APPROVALFINALTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dr["APPROVALFINALTGL"]).ToString("HH:mm:ss"),
                        customer_nama = dr["CUSTOMER_NAMA"].ToString(),
                        store = dr["NAMA_TOKO"].ToString(),
                        tipe_qc = dr["TIPE_QC"].ToString(),
                    });
                }
                return new { message = "", data = listqc, total = Convert.ToInt64(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object GetQC(int id, string tipe)
        {
            try
            {
                string query = "EXEC sp_get_qc_by_id_new";
                DataSet ds = _openConnection.Ds(query + " " + id + ",'" + tipe + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = ds.Tables[0];

                if (dtheader.Rows.Count == 0)
                {
                    return new { message = "Data Tidak Ditemukan." };
                }
                else if (dtheader.Rows.Count == 1)
                {
                    List<object> stones = new List<object>();
                    if (tipe == "DJ" || tipe == "TI")
                    {
                        DataTable dtstone = ds.Tables[1];
                        foreach (DataRow dr in dtstone.Rows)
                        {
                            stones.Add(new
                            {
                                id = Convert.ToInt32(dr["ID"]),
                                stone_type = dr["STONETYPE"].ToString(),
                                stone = dr["STONE"].ToString(),
                                total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                                total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                                total_butir_qc = Convert.ToInt32(dr["TOTAL_BUTIR_QC"]),
                                total_carat_qc = Convert.ToDecimal(dr["TOTAL_CARAT_QC"]),
                                gia = dr["GIA"].ToString(),
                                brand_stone = dr["BRAND_STONE"].ToString(),
                                sesuai_sertifikat = Convert.ToBoolean(dr["SESUAI_SERTIFIKAT"]),
                                keterangan = dr["KETERANGAN"].ToString()
                            });
                        }
                        return new
                        {
                            message = "",
                            data = new
                            {
                                id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                                tipe = dtheader.Rows[0]["TIPE"].ToString(),
                                plu = dtheader.Rows[0]["NOMOR"].ToString(),
                                no_qc = dtheader.Rows[0]["NOQC"].ToString(),
                                item = dtheader.Rows[0]["ITEM"].ToString(),
                                nama_qc = dtheader.Rows[0]["QC_NAMA"].ToString(),
                                weight = Convert.ToDecimal(dtheader.Rows[0]["WEIGHT"]),
                                harga_beli_customer = Convert.ToDouble(dtheader.Rows[0]["HARGA_BELI_CUSTOMER"]),
                                operator_nama = dtheader.Rows[0]["OPERATOR_NAMA"].ToString(),
                                operator_tgl = Convert.ToDateTime(dtheader.Rows[0]["OPERATOR_TGL"]).ToString("dd-MM-yy HH:mm:ss"),
                                logo = dtheader.Rows[0]["LOGO"].ToString(),
                                kadar_emas = dtheader.Rows[0]["KADAR_EMAS"].ToString(),
                                warna_emas = dtheader.Rows[0]["WARNA_EMAS"].ToString(),
                                fisik_keseluruhan = dtheader.Rows[0]["FISIK_KESELURUHAN"].ToString(),
                                keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                                alamat = dtheader.Rows[0]["ALAMAT"].ToString(),
                                brand = dtheader.Rows[0]["BRAND"].ToString(),
                                customer_nama = dtheader.Rows[0]["CUSTOMER_NAMA"].ToString()
                            },
                            stone = stones
                        };
                    }
                    else if (tipe == "LD")
                    {
                        DataTable dtstone = ds.Tables[1];
                        foreach (DataRow dr in dtstone.Rows)
                        {
                            stones.Add(new
                            {
                                id = Convert.ToInt32(dr["ID"]),
                                stone_type = dr["STONETYPE"].ToString(),
                                stone = dr["STONE"].ToString(),
                                total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                                total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                                total_butir_qc = Convert.ToInt32(dr["TOTAL_BUTIR_QC"]),
                                total_carat_qc = Convert.ToDecimal(dr["TOTAL_CARAT_QC"]),
                                gia = dr["GIA"].ToString(),
                                brand_stone = dr["BRAND_STONE"].ToString(),
                                colour = dr["COLOUR"].ToString(),
                                clarity = dr["CLARITY"].ToString(),
                                cutting = dr["CUTTING"].ToString(),
                                harga_jual = Convert.ToDouble(dr["HARGA_JUAL"]),
                                shape = dr["SHAPE"].ToString(),
                                check_sertifikat_sm = dr["CHECK_SERTIFIKAT_SM"].ToString(),
                                check_invoice_sm = dr["CHECK_INVOICE_SM"].ToString(),
                                check_laser_incription_sm = dr["CHECK_LASER_INCRIPTION_SM"].ToString(),
                                check_measurement_sm = dr["CHECK_MEASUREMENT_SM"].ToString(),
                                check_kondisi_batu = dr["CHECK_KONDISI_BATU"].ToString(),
                                sesuai_sertifikat = dr["SESUAI_SERTIFIKAT"].ToString(),
                                keterangan = dr["KETERANGAN"].ToString()
                            });
                        }
                        return new
                        {
                            message = "",
                            data = new
                            {
                                id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                                tipe = dtheader.Rows[0]["TIPE"].ToString(),
                                plu = dtheader.Rows[0]["NOMOR"].ToString(),
                                no_qc = dtheader.Rows[0]["NOQC"].ToString(),
                                item = dtheader.Rows[0]["ITEM"].ToString(),
                                nama_qc = dtheader.Rows[0]["QC_NAMA"].ToString(),
                                weight = Convert.ToDecimal(dtheader.Rows[0]["WEIGHT"]),
                                harga_beli_customer = Convert.ToDouble(dtheader.Rows[0]["HARGA_BELI_CUSTOMER"]),
                                operator_nama = dtheader.Rows[0]["OPERATOR_NAMA"].ToString(),
                                operator_tgl = Convert.ToDateTime(dtheader.Rows[0]["OPERATOR_TGL"]).ToString("dd-MM-yy HH:mm:ss"),
                                logo = dtheader.Rows[0]["LOGO"].ToString(),
                                kadar_emas = dtheader.Rows[0]["KADAR_EMAS"].ToString(),
                                warna_emas = dtheader.Rows[0]["WARNA_EMAS"].ToString(),
                                fisik_keseluruhan = dtheader.Rows[0]["FISIK_KESELURUHAN"].ToString(),
                                keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                                alamat = dtheader.Rows[0]["ALAMAT"].ToString(),
                                brand = dtheader.Rows[0]["BRAND"].ToString(),
                                kode_store_asal = dtheader.Rows[0]["KODE_STORE_ASAL"].ToString(),
                                invoice_asal = dtheader.Rows[0]["INVOICE_ASAL"].ToString(),
                                customer_nama = dtheader.Rows[0]["CUSTOMER_NAMA"].ToString(),
                                ekstensi = System.Text.Json.JsonSerializer.Deserialize<dynamic>(dtheader.Rows[0]["EXTENSION"].ToString()),
                                harga_procurement = Convert.ToDecimal(dtheader.Rows[0]["HARGA_PROCUREMENT"]),
                                approval_sm = dtheader.Rows[0]["APPROVALSM"].ToString(),
                                approval_sm_tgl = (dtheader.Rows[0]["APPROVALSMTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVALSMTGL"]).ToString("dd-MM-yy"),
                                approval_sm_time = (dtheader.Rows[0]["APPROVALSMTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVALSMTGL"]).ToString("hh-mm-ss"),
                                approval_am = dtheader.Rows[0]["APPROVALAM"].ToString(),
                                approval_am_tgl = (dtheader.Rows[0]["APPROVALAMTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVALAMTGL"]).ToString("dd-MM-yy"),
                                approval_am_time = (dtheader.Rows[0]["APPROVALAMTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVALAMTGL"]).ToString("hh-mm-ss"),
                                approval_procurement = dtheader.Rows[0]["APPROVALPROCUREMENT"].ToString(),
                                approval_procurement_tgl = (dtheader.Rows[0]["APPROVALPROCUREMENTTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVALPROCUREMENTTGL"]).ToString("dd-MM-yy"),
                                approval_procurement_time = (dtheader.Rows[0]["APPROVALPROCUREMENTTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVALPROCUREMENTTGL"]).ToString("hh-mm-ss"),
                                approval_final = dtheader.Rows[0]["APPROVALFINAL"].ToString(),
                                approval_final_tgl = (dtheader.Rows[0]["APPROVALFINALTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVALFINALTGL"]).ToString("dd-MM-yy"),
                                approval_final_time = (dtheader.Rows[0]["APPROVALFINALTGL"] == DBNull.Value) ? "" : Convert.ToDateTime(dtheader.Rows[0]["APPROVALFINALTGL"]).ToString("hh-mm-ss"),
                                tradein_or_resell = dtheader.Rows[0]["TRADEINORRESELL"].ToString()
                            },
                            stone = stones
                        };
                    }
                    else
                    {
                        return new
                        {
                            message = "",
                            data = new
                            {
                                id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                                tipe = dtheader.Rows[0]["TIPE"].ToString(),
                                plu = dtheader.Rows[0]["NOMOR"].ToString(),
                                no_qc = dtheader.Rows[0]["NOQC"].ToString(),
                                item = dtheader.Rows[0]["ITEM"].ToString(),
                                nama_qc = dtheader.Rows[0]["QC_NAMA"].ToString(),
                                weight = Convert.ToDecimal(dtheader.Rows[0]["WEIGHT"]),
                                harga_beli_customer = Convert.ToDouble(dtheader.Rows[0]["HARGA_BELI_CUSTOMER"]),
                                operator_nama = dtheader.Rows[0]["OPERATOR_NAMA"].ToString(),
                                operator_tgl = Convert.ToDateTime(dtheader.Rows[0]["OPERATOR_TGL"]).ToString("dd-MM-yy HH:mm:ss"),
                                logo = dtheader.Rows[0]["LOGO"].ToString(),
                                kadar_emas = dtheader.Rows[0]["KADAR_EMAS"].ToString(),
                                warna_emas = dtheader.Rows[0]["WARNA_EMAS"].ToString(),
                                fisik_keseluruhan = dtheader.Rows[0]["FISIK_KESELURUHAN"].ToString(),
                                keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                                kadar_karatimeter = dtheader.Rows[0]["KADAR_KARATIMETER"].ToString(),
                                alamat = dtheader.Rows[0]["ALAMAT"].ToString(),
                                brand = dtheader.Rows[0]["BRAND"].ToString(),
                                customer_nama = dtheader.Rows[0]["CUSTOMER_NAMA"].ToString()
                            }
                        };
                    }
                }
                else
                {
                    return new { message = "Data Error." };
                }
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object GetQCByProduct(int id, string tipe)
        {
            try
            {
                string query = "EXEC sp_get_list_qc_by_product_new " + id + ",'" + tipe + "'";
                DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                List<object> listqc = new List<object>();
                foreach (DataRow dr in result.Rows)
                {
                    listqc.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        id_product = Convert.ToInt32(dr["ID_PRODUCT"]),
                        tipe = dr["TIPE"].ToString(),
                        nomor = dr["NOMOR"].ToString(),
                        item = dr["ITEM"].ToString(),
                        no_qc = dr["NOQC"].ToString(),
                        qc_nama = dr["QC_NAMA"].ToString(),
                        operator_nama = dr["OPERATOR_NAMA"].ToString(),
                        operator_tgl = Convert.ToDateTime(dr["OPERATOR_TGL"]).ToString("dd-MM-yyyy")
                    });
                }
                return new { message = "", data = listqc };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object GetProductList(string kw, string tipe)
        {
            try
            {
                kw = _common.ChangeStringWildCardCharacterSQL(kw);
                string query = "sp_get_list_product_qc_new '" + kw + "','" + tipe + "'";
                DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);

                List<object> dtproduct = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtproduct.Add(new
                    {
                        id = Convert.ToInt32(dr["ID"]),
                        tipe = dr["TIPE"].ToString(),
                        nomor = dr["NOMOR"].ToString(),
                        item = dr["ITEM"].ToString(),
                        status = dr["STATUS"].ToString(),
                        invoice = dr["INVOICE"].ToString()
                    });
                }
                return new { message = "", data = dtproduct };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public object GetProductDetail(int id, string tipe)
        {
            try
            {
                string query = "EXEC sp_get_list_product_detail_qc_new " + id + ",'" + tipe + "'";
                DataSet dt = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = dt.Tables[0];
                if (dtheader.Rows.Count == 0)
                {
                    return new { message = "Data Tidak Ditemukan." };
                }
                else if (dtheader.Rows.Count == 1)
                {
                    List<object> stones = new List<object>();
                    if (tipe == "DJ")
                    {
                        DataTable dtstone = dt.Tables[1];
                        foreach (DataRow s in dtstone.Rows)
                        {
                            stones.Add(new
                            {
                                id = Convert.ToInt32(s["ID"]),
                                stone_type = s["STONETYPE"].ToString(),
                                stone_name = s["STONE"].ToString(),
                                tgl_efektif = (s["TGL"] == DBNull.Value) ? "" : Convert.ToDateTime(s["Tgl"]).ToString("dd-MM-yyyy"),
                                total_butir = Convert.ToInt32(s["TOTAL_BUTIR"]),
                                total_carat = Convert.ToDecimal(s["TOTAL_CARAT"]).ToString("N3"),
                                gia = s["GIA"].ToString(),
                                brand_stone = s["BRANDSTONE"].ToString(),
                                stone_type_map = s["STONETYPEMAP"].ToString()
                            });
                        }

                        return new
                        {
                            message = "",
                            data = new
                            {
                                idproduct = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                                nomor = dtheader.Rows[0]["NOMOR"].ToString(),
                                tipe,
                                image = _common.ImageCDN(dtheader.Rows[0]["IMAGE"].ToString()),
                                item = dtheader.Rows[0]["ITEM"].ToString(),
                                item_id = Convert.ToInt32(dtheader.Rows[0]["ITEMID"]),
                                frame_color = dtheader.Rows[0]["FRAME_COLOR"].ToString(),
                                frame_color_id = Convert.ToInt32(dtheader.Rows[0]["FRAME_COLOR_ID"]),
                                gross_weight = Convert.ToDouble(dtheader.Rows[0]["GROSS_WEIGHT"]),
                                stone = stones
                            }
                        };
                    }
                    else if (tipe == "LD")
                    {
                        DataTable dtstone = dt.Tables[1];
                        foreach (DataRow s in dtstone.Rows)
                        {
                            stones.Add(new
                            {
                                id = Convert.ToInt32(s["ID"]),
                                stone_type = s["STONETYPE"].ToString(),
                                stone_name = s["STONE"].ToString(),
                                tgl_efektif = (s["TGL"] == DBNull.Value) ? "" : Convert.ToDateTime(s["Tgl"]).ToString("dd-MM-yyyy"),
                                total_butir = Convert.ToInt32(s["TOTAL_BUTIR"]),
                                total_carat = Convert.ToDecimal(s["TOTAL_CARAT"]).ToString("N3"),
                                gia = s["GIA"].ToString(),
                                brand_stone = s["BRANDSTONE"].ToString(),
                                stone_type_map = s["STONETYPEMAP"].ToString(),
                                shape = s["SHAPE"].ToString(),
                                colour = s["COLOR"].ToString(),
                                clarity = s["CLARITY"].ToString(),
                                cutting = s["CUTTING"].ToString(),
                            });
                        }

                        return new
                        {
                            message = "",
                            data = new
                            {
                                idproduct = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                                nomor = dtheader.Rows[0]["NOMOR"].ToString(),
                                tipe,
                                image = _common.ImageCDN(dtheader.Rows[0]["IMAGE"].ToString()),
                                item = dtheader.Rows[0]["ITEM"].ToString(),
                                item_id = Convert.ToInt32(dtheader.Rows[0]["ITEMID"]),
                                frame_color = dtheader.Rows[0]["FRAME_COLOR"].ToString(),
                                frame_color_id = Convert.ToInt32(dtheader.Rows[0]["FRAME_COLOR_ID"]),
                                gross_weight = Convert.ToDouble(dtheader.Rows[0]["GROSS_WEIGHT"]),
                                stone = stones
                            }
                        };
                    }
                    else if (tipe == "PG")
                    {
                        return new
                        {
                            message = "",
                            data = new
                            {
                                idproduct = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                                nomor = dtheader.Rows[0]["NOMOR"].ToString(),
                                tipe,
                                image = _common.ImageCDN(dtheader.Rows[0]["IMAGE"].ToString()),
                                item = dtheader.Rows[0]["ITEM"].ToString(),
                                item_id = Convert.ToInt32(dtheader.Rows[0]["ITEMID"]),
                                frame_color = dtheader.Rows[0]["FRAME_COLOR"].ToString(),
                                frame_color_id = Convert.ToInt32(dtheader.Rows[0]["FRAME_COLOR_ID"]),
                                gross_weight = Convert.ToDouble(dtheader.Rows[0]["GROSS_WEIGHT"])
                            }
                        };
                    }
                    else if (tipe == "TI")//TITIPAN
                    {
                        DataTable dtstone = dt.Tables[1];
                        foreach (DataRow s in dtstone.Rows)
                        {
                            stones.Add(new
                            {
                                id = Convert.ToInt32(s["ID"]),
                                stone_type = s["STONETYPE"].ToString(),
                                stone_name = s["STONE"].ToString(),
                                total_butir = Convert.ToInt32(s["TOTAL_BUTIR"]),
                                total_carat = Convert.ToDecimal(s["TOTAL_CARAT"]).ToString("N3"),
                                gia = s["GIA"].ToString(),
                                brand_stone = s["BRANDSTONE"].ToString(),
                                stone_type_map = s["STONETYPEMAP"].ToString()
                            });
                        }
                        return new
                        {
                            message = "",
                            data = new
                            {
                                idproduct = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                                nomor = dtheader.Rows[0]["NOMOR"].ToString(),
                                tipe,
                                image = _common.ImageCDN(dtheader.Rows[0]["IMAGE"].ToString()),
                                item = dtheader.Rows[0]["ITEM"].ToString(),
                                item_id = Convert.ToInt32(dtheader.Rows[0]["ITEMID"]),
                                gross_weight = Convert.ToDouble(dtheader.Rows[0]["GROSS_WEIGHT"]),
                                stone = stones
                            }
                        };
                    }
                    else
                    {
                        return new
                        {
                            message = "",
                            data = new
                            {
                                idproduct = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                                nomor = dtheader.Rows[0]["NOMOR"].ToString(),
                                tipe,
                                image = _common.ImageCDN(dtheader.Rows[0]["IMAGE"].ToString()),
                                item = dtheader.Rows[0]["ITEM"].ToString(),
                                item_id = Convert.ToInt32(dtheader.Rows[0]["ITEMID"]),
                                frame_color = dtheader.Rows[0]["FRAME_COLOR"].ToString(),
                                frame_color_id = Convert.ToInt32(dtheader.Rows[0]["FRAME_COLOR_ID"]),
                                gross_weight = Convert.ToDouble(dtheader.Rows[0]["GROSS_WEIGHT"])
                            }
                        };
                    }
                }
                else
                {
                    return new { message = "Data Error." };
                }
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }

        public List<object> GetListPositionLD()
        {
            string query = "SELECT ID id, Nama nama From PositionLD";
            DataTable dt = _openConnection.Rs(query,_connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> list = new List<object>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new
                {
                    id = Convert.ToInt32(dr["id"]),
                    nama = dr["nama"].ToString()
                });
            }
            return list;
        }

        public List<object> GetListClarityCharLD()
        {
            string query = "SELECT ID id, Nama nama From ClarityCharacteristicLD";
            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> list = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new
                {
                    id = Convert.ToInt32(dr["id"]),
                    nama = dr["nama"].ToString()
                });
            }
            return list;
        }

        public List<object> GetListSizeLD()
        {
            string query = "SELECT ID id, Nama nama From SizeLD";
            DataTable dt = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> list = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new
                {
                    id = Convert.ToInt32(dr["id"]),
                    nama = dr["nama"].ToString()
                });
            }
            return list;
        }
    }
}
