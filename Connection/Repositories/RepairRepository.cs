using Connection.Interface;
using Connection.Models;
using Connection.RequestModels.PointOfSales;
using Connection.RequestModels.StockTransfer;
using Connection.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Connection.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;
        private Common _common;

        public RepairRepository()
        {
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
            _common = new Common();
        }

        public List<object> GetCharProcessRepair()
        {
            var jeniskartukredits = _openConnection.Rs("EXEC sp_get_list_char_process_repair_new", _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in jeniskartukredits.Rows)
            {
                result.Add(new
                {
                    id = Convert.ToInt32(item["ID"]),
                    nama = item["Nama"].ToString(),
                    biaya = Convert.ToInt64(item["Biaya"])
                });
            }
            return result;
        }

        public object AddRepair(RequestRepair rr)
        {
            try
            {
                string queryrr = "EXEC sp_insert_repair_dj_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_RPR VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (rr != null && rr.char_product != "")
                {
                    RequestRepairCharProductHeader rhcp = JsonConvert.DeserializeObject<RequestRepairCharProductHeader>(rr.char_product);

                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_RPR, [MESSAGE]) " + queryrr +
                        " " + rr.id_lokasi + ", " + rr.tipe_lokasi + ", '" + rr.kode_lokasi + "'," + rr.id_customer + "," +
                        " '" + rr.customer_nama + "', " + rr.id_sales + ", '" + rr.sales_nama + "'," +
                        " '" + rr.operator_nama + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                        " '" + rr.tgl_selesai.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', '" + rr.keterangan + "'," +
                        " " + rr.id_product + ", " + rr.sumber + ", " + rr.id_product_titipan + "," +
                        " " + rr.estimasi_harga + ", " + rr.idqc + ", " + rr.idqc_titipan + "," +
                        " '" + rr.kode_customer_lama + "', '" + rr.files.Name + "'" +
                        " DECLARE @IDRPR INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMORRPR VARCHAR(50) = (SELECT TOP 1 NO_RPR FROM @TABLE) ";

                    if (rhcp.char_product_repair != null)
                    {
                        var x = rhcp.char_product_repair;
                        string query_charprod = "EXEC sp_insert_repair_dj_char_product_new";
                        querystart += query_charprod + " @IDRPR, " + x.id_product_item + "," +
                            " " + x.id_product_category + ", " + x.id_product_level + "," +
                            " " + x.id_stone_dist + ", " + x.id_frame_material + ", " + x.id_frame_finishing + "," +
                            " " + x.id_frame_color + ", " + x.id_process_cons + "," +
                            " " + x.gross_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.stone_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.stone_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.stone_qty.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.netto_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.kadar_logam.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.kadar_tukaran.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_d + ", " + x.dimensi_p + ", " + x.dimensi_l + ", " + x.dimensi_r + " ";
                    }
                    foreach (var x in rhcp.process_list_repair)
                    {
                        string query_charrepair = "EXEC sp_insert_repair_repair_dj_new";
                        querystart += query_charrepair + " @IDRPR, " + x.id_repair + "," +
                            " " + x.biaya.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + x.keterangan + "' ";
                    }

                    foreach (var x in rhcp.stone1A_repair)
                    {
                        string tipe = "1A";
                        string query_stone = "EXEC sp_insert_repair_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " 'GIA', 0, 0, 1 ";
                    }

                    foreach (var x in rhcp.stone1B_repair)
                    {
                        string tipe = "1B";
                        string query_stone = "EXEC sp_insert_repair_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', " + x.harga_input_h.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_input_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.status_terpasang + " ";
                    }

                    foreach (var x in rhcp.stone2_repair)
                    {
                        string tipe = "2";
                        string query_stone = "EXEC sp_insert_repair_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', 0, 0, 1 ";
                    }

                    foreach (var x in rhcp.stone3_repair)
                    {
                        string tipe = "3";
                        string query_stone = "EXEC sp_insert_repair_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', 0, 0, 1 ";
                    }

                    foreach (var x in rhcp.stone4_repair)
                    {
                        string tipe = "4";
                        string query_stone = "EXEC sp_insert_repair_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', 0, 0, 1 ";
                    }

                    foreach (var x in rhcp.stone5_repair)
                    {
                        string tipe = "5";
                        string query_stone = "EXEC sp_insert_repair_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', 0, 0, 1 ";
                    }
                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_RPR], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idrpr = Convert.ToInt32(result.Rows[0]["ID"]);
                    string norpr = result.Rows[0]["NO_RPR"].ToString();
                    try
                    {
                        PostingRepairToMyapps(norpr);
                    }
                    catch { }
                    try
                    {
                        var resultupload = UploadImageRepair(rr.files, idrpr, _connectionStrings.AppConfig.BrandCode);
                    }
                    catch { }
                    return new { message = res, id = idrpr, no = norpr };
                }
                else
                {
                    return new { message = "Data Not Found" };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetRepair(int id)
        {
            try
            {
                string queryrr = "EXEC sp_get_repair_dj_by_id_new " + id;
                DataSet ds = _openConnection.Ds(queryrr, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = ds.Tables[0];
                DataTable dtrepair = ds.Tables[1];
                DataTable dtstoneoriginale = ds.Tables[2];
                DataTable dtstonerepair = ds.Tables[3];

                if (dtheader.Rows.Count == 0)
                {
                    return new { message = "Data Not Found." };
                }
                else if (dtheader.Rows.Count > 1)
                {
                    return new { message = "Data Duplicated." };
                }
                else
                {
                    List<object> pr = new List<object>();
                    foreach (DataRow dr in dtrepair.Rows)
                    {
                        pr.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            id_process_repair = Convert.ToInt32(dr["ID_PROCESS_REPAIR"]),
                            item = dr["ITEM"].ToString(),
                            biaya = Convert.ToDouble(dr["BIAYA"]),
                            keterangan = dr["KETERANGAN"].ToString()
                        });
                    }

                    List<object> stoner = new List<object>();
                    foreach (DataRow dr in dtstonerepair.Rows)
                    {
                        stoner.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            tipe = dr["TIPE"].ToString(),
                            tipe_nama = dr["TIPE_NAMA"].ToString(),
                            carat_butir = Convert.ToDecimal(dr["CARAT_BUTIR"]),
                            total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                            total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                            nama = dr["NAMA"].ToString(),
                            color = dr["COLOR"].ToString(),
                            clarity = dr["CLARITY"].ToString(),
                            min_size = Convert.ToDecimal(dr["MIN_SIZE"]),
                            max_size = Convert.ToDecimal(dr["MAX_SIZE"]),
                            harga_satuan = Convert.ToDecimal(dr["HARGA_SATUAN"]),
                            harga_total = Convert.ToDecimal(dr["HARGA_TOTAL"]),
                            harga_satuan_m = Convert.ToDecimal(dr["HARGA_SATUAN_M"]),
                            harga_total_m = Convert.ToDecimal(dr["HARGA_TOTAL_M"]),
                            total_harga_rupiah = Convert.ToDouble(dr["TOTAL_HARGA_RUPIAH"])
                        });
                    }

                    List<object> stoneoriginalr = new List<object>();
                    foreach (DataRow dr in dtstoneoriginale.Rows)
                    {
                        stoneoriginalr.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            tipe = dr["TIPE"].ToString(),
                            tipe_nama = dr["TIPE_NAMA"].ToString(),
                            carat_butir = Convert.ToDecimal(dr["CARAT_BUTIR"]),
                            total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                            total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                            nama = dr["NAMA"].ToString(),
                            color = dr["COLOR"].ToString(),
                            clarity = dr["CLARITY"].ToString(),
                            min_size = Convert.ToDecimal(dr["MIN_SIZE"]),
                            max_size = Convert.ToDecimal(dr["MAX_SIZE"]),
                        });
                    }

                    return new
                    {
                        message = "",
                        data = new
                        {
                            id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                            id_qc = Convert.ToInt32(dtheader.Rows[0]["IDQC"]),
                            id_qc_titipan = Convert.ToInt32(dtheader.Rows[0]["IDQC_TITIPAN"]),
                            nomor = dtheader.Rows[0]["NOMOR"].ToString(),
                            id_customer = Convert.ToInt32(dtheader.Rows[0]["ID_CUSTOMER"]),
                            kode_customer = dtheader.Rows[0]["KODE_CUSTOMER"],
                            customer = dtheader.Rows[0]["CUSTOMER_NAMA"].ToString(),
                            id_sales = Convert.ToInt32(dtheader.Rows[0]["ID_SALES"]),
                            sales = dtheader.Rows[0]["SALES_NAMA"].ToString(),
                            tgl_masuk = Convert.ToDateTime(dtheader.Rows[0]["TGL_MASUK"]).ToString("dd-MM-yyyy"),
                            tgl_selesai = Convert.ToDateTime(dtheader.Rows[0]["TGL_SELESAI"]).ToString("dd-MM-yyyy"),
                            tipe_lokasi = Convert.ToInt32(dtheader.Rows[0]["TIPE_LOKASI"]),
                            id_lokasi = Convert.ToInt32(dtheader.Rows[0]["ID_LOKASI"]),
                            kode_lokasi = dtheader.Rows[0]["KODE_LOKASI"].ToString(),
                            nama_lokasi = dtheader.Rows[0]["NAMA_LOKASI"].ToString(),
                            keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                            estimasi_harga = Convert.ToDouble(dtheader.Rows[0]["ESTIMASI_HARGA"]),
                            id_product = Convert.ToInt32(dtheader.Rows[0]["ID_PRODUCT"]),
                            id_product_titipan = Convert.ToInt32(dtheader.Rows[0]["ID_PRODUCT_TITIPAN"]),
                            plu = dtheader.Rows[0]["PLU"].ToString(),
                            plu_titipan = dtheader.Rows[0]["PLU_TITIPAN"].ToString(),
                            no_qc = dtheader.Rows[0]["NO_QC"].ToString(),
                            no_qc_titipan = dtheader.Rows[0]["NO_QC_TITIPAN"].ToString(),
                            image_original = _common.ImageCDN(dtheader.Rows[0]["IMAGE_ORIGINAL"].ToString()),
                            image_repair = _common.ImageCDN(dtheader.Rows[0]["IMAGE_REPAIR"].ToString()),
                            gross_weight_original = Convert.ToDecimal(dtheader.Rows[0]["GROSS_WEIGHT_ORIGINAL"]),
                            gross_weight_repair = Convert.ToDecimal(dtheader.Rows[0]["GROSS_WEIGHT_REPAIR"]),
                            dimensi_d_original = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_D_ORIGINAL"]),
                            dimensi_d_repair = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_D_REPAIR"]),
                            dimensi_p_original = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_P_ORIGINAL"]),
                            dimensi_p_repair = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_P_REPAIR"]),
                            dimensi_l_original = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_L_ORIGINAL"]),
                            dimensi_l_repair = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_L_REPAIR"]),
                            dimensi_r_original = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_R_ORIGINAL"]),
                            dimensi_r_repair = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_R_REPAIR"]),
                            total_butir_original = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_BUTIR_ORIGINAL"]),
                            total_butir_repair = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_BUTIR_REPAIR"]),
                            total_carat_original = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_CARAT_ORIGINAL"]),
                            total_carat_repair = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_CARAT_REPAIR"]),
                            opeartor_nama = dtheader.Rows[0]["OPERATOR_NAMA"].ToString(),
                            operator_tanggal = Convert.ToDateTime(dtheader.Rows[0]["OPERATOR_TGL"]).ToString("dd-MM-yyyy hh:mm:ss.fff"),
                            product_item = dtheader.Rows[0]["PRODUCT_ITEM"].ToString(),
                            product_level = dtheader.Rows[0]["PRODUCT_LEVEL"].ToString(),
                            product_category = dtheader.Rows[0]["PRODUCT_CATEGORY"].ToString(),
                            stone_dist = dtheader.Rows[0]["STONE_DIST"].ToString(),
                            frame_material = dtheader.Rows[0]["FRAME_MATERIAL"].ToString(),
                            frame_color = dtheader.Rows[0]["FRAME_COLOR"].ToString(),
                            frame_finishing = dtheader.Rows[0]["FRAME_FINISHING"].ToString(),
                            process_cons = dtheader.Rows[0]["PROCESS_CONS"].ToString(),
                            stone_carat = Convert.ToDecimal(dtheader.Rows[0]["STONE_CARAT"]),
                            stone_carat_repair = Convert.ToDecimal(dtheader.Rows[0]["STONE_CARAT"]),
                            stone_weight = Convert.ToDecimal(dtheader.Rows[0]["STONE_WEIGHT"]),
                            stone_weight_repair = Convert.ToDecimal(dtheader.Rows[0]["STONE_WEIGHT"]),
                            stone_qty = Convert.ToInt32(dtheader.Rows[0]["STONE_QTY"]),
                            stone_qty_repair = Convert.ToInt32(dtheader.Rows[0]["STONE_QTY"]),
                            netto_weight = Convert.ToDecimal(dtheader.Rows[0]["NETTO_WEIGHT"]),
                            netto_weight_repair = Convert.ToDecimal(dtheader.Rows[0]["NETTO_WEIGHT"]),
                            kadar_logam = Convert.ToDecimal(dtheader.Rows[0]["KADAR_LOGAM"]),
                            kadar_tukaran = Convert.ToDecimal(dtheader.Rows[0]["KADAR_TUKARAN"]),
                            process_repair = pr,
                            stone_repair = stoner,
                            stone_originale = stoneoriginalr,
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetRepairResult(int id_repair_result)
        {
            try
            {
                string queryrr = "EXEC sp_get_repair_result_dj_by_id_new " + id_repair_result;
                DataSet ds = _openConnection.Ds(queryrr, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dtheader = ds.Tables[0];
                DataTable dtrepair = ds.Tables[1];
                DataTable dtrepairresult = ds.Tables[2];
                DataTable dtstoneoriginale = ds.Tables[3];
                DataTable dtstonerepair = ds.Tables[4];
                DataTable dtstonerepairresult = ds.Tables[5];
                DataTable dtpayment = ds.Tables[6];

                if (dtheader.Rows.Count == 0)
                {
                    return new { message = "Data Not Found." };
                }
                else if (dtheader.Rows.Count > 1)
                {
                    return new { message = "Data Duplicated." };
                }
                else
                {
                    List<object> pr = new List<object>();
                    foreach (DataRow dr in dtrepair.Rows)
                    {
                        pr.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            id_process_repair = Convert.ToInt32(dr["ID_PROCESS_REPAIR"]),
                            item = dr["ITEM"].ToString(),
                            biaya = Convert.ToDouble(dr["BIAYA"]),
                            keterangan = dr["KETERANGAN"].ToString()
                        });
                    }

                    List<object> prresult = new List<object>();
                    foreach (DataRow dr in dtrepairresult.Rows)
                    {
                        prresult.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            id_process_repair = Convert.ToInt32(dr["ID_PROCESS_REPAIR"]),
                            item = dr["ITEM"].ToString(),
                            biaya = Convert.ToDouble(dr["BIAYA"]),
                            keterangan = dr["KETERANGAN"].ToString()
                        });
                    }

                    List<object> stoner = new List<object>();
                    foreach (DataRow dr in dtstonerepair.Rows)
                    {
                        stoner.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            tipe = dr["TIPE"].ToString(),
                            tipe_nama = dr["TIPE_NAMA"].ToString(),
                            carat_butir = Convert.ToDecimal(dr["CARAT_BUTIR"]),
                            total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                            total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                            nama = dr["NAMA"].ToString(),
                            color = dr["COLOR"].ToString(),
                            clarity = dr["CLARITY"].ToString(),
                            min_size = Convert.ToDecimal(dr["MIN_SIZE"]),
                            max_size = Convert.ToDecimal(dr["MAX_SIZE"]),
                            total_harga_rupiah = Convert.ToDouble(dr["TOTAL_HARGA_RUPIAH"])
                        });
                    }

                    List<object> stoneoriginalr = new List<object>();
                    foreach (DataRow dr in dtstoneoriginale.Rows)
                    {
                        stoneoriginalr.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            tipe = dr["TIPE"].ToString(),
                            tipe_nama = dr["TIPE_NAMA"].ToString(),
                            carat_butir = Convert.ToDecimal(dr["CARAT_BUTIR"]),
                            total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                            total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                            nama = dr["NAMA"].ToString(),
                            color = dr["COLOR"].ToString(),
                            clarity = dr["CLARITY"].ToString(),
                            min_size = Convert.ToDecimal(dr["MIN_SIZE"]),
                            max_size = Convert.ToDecimal(dr["MAX_SIZE"]),
                        });
                    }

                    List<object> stonerrepairresultr = new List<object>();
                    foreach (DataRow dr in dtstonerepairresult.Rows)
                    {
                        stonerrepairresultr.Add(new
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            tipe = dr["TIPE"].ToString(),
                            tipe_nama = dr["TIPE_NAMA"].ToString(),
                            carat_butir = Convert.ToDecimal(dr["CARAT_BUTIR"]),
                            total_butir = Convert.ToInt32(dr["TOTAL_BUTIR"]),
                            total_carat = Convert.ToDecimal(dr["TOTAL_CARAT"]),
                            nama = dr["NAMA"].ToString(),
                            color = dr["COLOR"].ToString(),
                            clarity = dr["CLARITY"].ToString(),
                            min_size = Convert.ToDecimal(dr["MIN_SIZE"]),
                            max_size = Convert.ToDecimal(dr["MAX_SIZE"]),
                            total_harga_rupiah = Convert.ToDouble(dr["TOTAL_HARGA_RUPIAH"])
                        });
                    }

                    List<object> paymentrepair = new List<object>();
                    foreach (DataRow dr in dtpayment.Rows)
                    {
                        paymentrepair.Add(new
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
                            operator_name = dr["OPERATORNAMA"].ToString()
                        });
                    }

                    return new
                    {
                        message = "",
                        data = new
                        {
                            id = Convert.ToInt32(dtheader.Rows[0]["ID"]),
                            id_qc = Convert.ToInt32(dtheader.Rows[0]["IDQC"]),
                            id_qc_titipan = Convert.ToInt32(dtheader.Rows[0]["IDQC_TITIPAN"]),
                            nomor = dtheader.Rows[0]["NOMOR"],
                            nomor_so_repair = dtheader.Rows[0]["NOMOR_SO_REPAIR"].ToString(),
                            nomor_invoice_repair = dtheader.Rows[0]["NOMOR_INVOICE_REPAIR"].ToString(),
                            id_customer = Convert.ToInt32(dtheader.Rows[0]["ID_CUSTOMER"]),
                            kode_customer = dtheader.Rows[0]["KODE_CUSTOMER"],
                            customer = dtheader.Rows[0]["CUSTOMER_NAMA"],
                            id_sales = Convert.ToInt32(dtheader.Rows[0]["ID_SALES"]),
                            sales = dtheader.Rows[0]["SALES_NAMA"],
                            tgl_masuk = Convert.ToDateTime(dtheader.Rows[0]["TGL_MASUK"]).ToString("dd-MM-yyyy"),
                            tgl_selesai = Convert.ToDateTime(dtheader.Rows[0]["TGL_SELESAI"]).ToString("dd-MM-yyyy"),
                            tipe_lokasi = Convert.ToInt32(dtheader.Rows[0]["TIPE_LOKASI"]),
                            id_lokasi = Convert.ToInt32(dtheader.Rows[0]["ID_LOKASI"]),
                            kode_lokasi = dtheader.Rows[0]["KODE_LOKASI"].ToString(),
                            nama_lokasi = dtheader.Rows[0]["NAMA_LOKASI"].ToString(),
                            keterangan = dtheader.Rows[0]["KETERANGAN"].ToString(),
                            estimasi_harga = Convert.ToDouble(dtheader.Rows[0]["ESTIMASI_HARGA"]),
                            id_product = Convert.ToInt32(dtheader.Rows[0]["ID_PRODUCT"]),
                            id_product_titipan = Convert.ToInt32(dtheader.Rows[0]["ID_PRODUCT_TITIPAN"]),
                            plu = dtheader.Rows[0]["PLU"].ToString(),
                            plu_titipan = dtheader.Rows[0]["PLU_TITIPAN"].ToString(),
                            no_qc = dtheader.Rows[0]["NO_QC"].ToString(),
                            no_qc_titipan = dtheader.Rows[0]["NO_QC_TITIPAN"].ToString(),
                            image_original = _common.ImageCDN(dtheader.Rows[0]["IMAGE_ORIGINAL"].ToString()),
                            image_repair = _common.ImageCDN(dtheader.Rows[0]["IMAGE_REPAIR"].ToString()),
                            image_repair_result = _common.ImageCDN(dtheader.Rows[0]["IMAGE_REPAIR_RESULT"].ToString()),
                            gross_weight_original = Convert.ToDecimal(dtheader.Rows[0]["GROSS_WEIGHT_ORIGINAL"]),
                            gross_weight_repair = Convert.ToDecimal(dtheader.Rows[0]["GROSS_WEIGHT_REPAIR"]),
                            gross_weight_repair_result = Convert.ToDecimal(dtheader.Rows[0]["GROSS_WEIGHT_REPAIR_RESULT"]),
                            dimensi_d_original = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_D_ORIGINAL"]),
                            dimensi_d_repair = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_D_REPAIR"]),
                            dimensi_d_repair_result = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_D_REPAIR_RESULT"]),
                            dimensi_p_original = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_P_ORIGINAL"]),
                            dimensi_p_repair = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_P_REPAIR"]),
                            dimensi_p_repair_result = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_P_REPAIR_RESULT"]),
                            dimensi_l_original = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_L_ORIGINAL"]),
                            dimensi_l_repair = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_L_REPAIR"]),
                            dimensi_l_repair_result = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_L_REPAIR_RESULT"]),
                            dimensi_r_original = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_R_ORIGINAL"]),
                            dimensi_r_repair = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_R_REPAIR"]),
                            dimensi_r_repair_result = Convert.ToDecimal(dtheader.Rows[0]["DIMENSI_R_REPAIR_RESULT"]),
                            total_butir_original = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_BUTIR_ORIGINAL"]),
                            total_butir_repair = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_BUTIR_REPAIR"]),
                            total_butir_repair_result = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_BUTIR_REPAIR_RESULT"]),
                            total_carat_original = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_CARAT_ORIGINAL"]),
                            total_carat_repair = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_CARAT_REPAIR"]),
                            total_carat_repair_result = Convert.ToDecimal(dtheader.Rows[0]["TOTAL_CARAT_REPAIR"]),
                            operator_nama = dtheader.Rows[0]["OPERATOR_NAMA"].ToString(),
                            operator_tanggal = Convert.ToDateTime(dtheader.Rows[0]["OPERATOR_TGL"]).ToString("dd-MM-yyyy hh:mm:ss.fff"),
                            product_item = dtheader.Rows[0]["PRODUCT_ITEM"].ToString(),
                            product_level = dtheader.Rows[0]["PRODUCT_LEVEL"].ToString(),
                            product_category = dtheader.Rows[0]["PRODUCT_CATEGORY"].ToString(),
                            stone_dist = dtheader.Rows[0]["STONE_DIST"].ToString(),
                            frame_material = dtheader.Rows[0]["FRAME_MATERIAL"].ToString(),
                            frame_color = dtheader.Rows[0]["FRAME_COLOR"].ToString(),
                            frame_finishing = dtheader.Rows[0]["FRAME_FINISHING"].ToString(),
                            process_cons = dtheader.Rows[0]["PROCESS_CONS"].ToString(),
                            stone_carat = Convert.ToDecimal(dtheader.Rows[0]["STONE_CARAT"]),
                            stone_carat_repair = Convert.ToDecimal(dtheader.Rows[0]["STONE_CARAT_REPAIR"]),
                            stone_carat_repair_result = Convert.ToDecimal(dtheader.Rows[0]["STONE_CARAT_REPAIR_RESULT"]),
                            stone_weight = Convert.ToDecimal(dtheader.Rows[0]["STONE_WEIGHT"]),
                            stone_weight_repair = Convert.ToDecimal(dtheader.Rows[0]["STONE_WEIGHT_REPAIR"]),
                            stone_weight_repair_result = Convert.ToDecimal(dtheader.Rows[0]["STONE_WEIGHT_REPAIR_RESULT"]),
                            stone_qty = Convert.ToInt32(dtheader.Rows[0]["STONE_QTY"]),
                            stone_qty_repair = Convert.ToInt32(dtheader.Rows[0]["STONE_QTY_REPAIR"]),
                            stone_qty_repair_result = Convert.ToInt32(dtheader.Rows[0]["STONE_QTY_REPAIR_RESULT"]),
                            netto_weight = Convert.ToDecimal(dtheader.Rows[0]["NETTO_WEIGHT"]),
                            netto_weight_repair = Convert.ToDecimal(dtheader.Rows[0]["NETTO_WEIGHT_REPAIR"]),
                            netto_weight_repair_result = Convert.ToDecimal(dtheader.Rows[0]["NETTO_WEIGHT_REPAIR_RESULT"]),
                            kadar_logam = Convert.ToDecimal(dtheader.Rows[0]["KADAR_LOGAM"]),
                            kadar_tukaran = Convert.ToDecimal(dtheader.Rows[0]["KADAR_TUKARAN"]),
                            process_repair = pr,
                            process_repair_result = prresult,
                            stone_originale = stoneoriginalr,
                            stone_repair = stoner,
                            stone_repair_result = stonerrepairresultr,
                            payment_repair_result = paymentrepair
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object GetRepairItemByCustomer(int idcustomer, string custlama)
        {
            try
            {
                custlama = string.IsNullOrEmpty(custlama) ? "" : _common.ChangeStringWildCardCharacterSQL(custlama);
                string query = "sp_get_repair_item_by_customer_new";
                DataTable dt = _openConnection.Rs("EXEC " + query + " " + idcustomer.ToString() + " ,'" + custlama + "'", _connectionStrings.ConnectionStrings.Cnn_DB);
                List<object> dtobject = new List<object>();

                foreach (DataRow dr in dt.Rows)
                {
                    int id_product = Convert.ToInt32(dr["ID_PRODUCT"]);
                    int id_product_titipan = Convert.ToInt32(dr["ID_PRODUCT_TITIPAN"]);
                    List<object> stone1A = new List<object>();
                    List<object> stone1B = new List<object>();
                    List<object> stone2 = new List<object>();
                    List<object> stone3 = new List<object>();
                    List<object> stone4 = new List<object>();
                    List<object> stone5 = new List<object>();
                    using (JAWSDbContext _db = new JAWSDbContext())
                    {
                        var prc_us = _db.PricingTableUs.SingleOrDefault(p => p.Id == 2 && p.Harga.HasValue && p.ApprovalTgl.HasValue);
                        if (id_product > 0)
                        {
                            object char_product;
                            StockProductDJ dj = _db.StockProductDjs.Include(p => p.StockProductDJ_Stone1As)
                            .Include(p => p.StockProductDJ_Stone1Bs)
                            .Include(p => p.StockProductDJ_Stone2s)
                            .Include(p => p.StockProductDJ_Stone3s)
                            .Include(p => p.StockProductDJ_Stone4s)
                            .Include(p => p.StockProductDJ_Stone5s)
                            .Include(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharProductItem)
                            .Include(p => p.StockProductDJ_CharProduct).ThenInclude(p => p.CharStoneDist)
                            .SingleOrDefault(p => p.Id == id_product);

                            string item = dj.StockProductDJ_CharProduct.CharProductItem.NamaKode;
                            string stonedist = dj.StockProductDJ_CharProduct.CharStoneDist.NamaKode;

                            char_product = new
                            {
                                id_product_item = dj.StockProductDJ_CharProduct.ProductItem,
                                id_product_category = dj.StockProductDJ_CharProduct.ProductCategory,
                                id_product_level = dj.StockProductDJ_CharProduct.ProductLevel,
                                id_stone_dist = dj.StockProductDJ_CharProduct.StoneDist,
                                id_frame_material = dj.StockProductDJ_CharProduct.FrameMaterial,
                                id_frame_finishing = dj.StockProductDJ_CharProduct.FrameFinishing,
                                id_frame_color = dj.StockProductDJ_CharProduct.FrameColor,
                                id_process_cons = dj.StockProductDJ_CharProduct.ProcessCons,
                                gross_weight = dj.StockProductDJ_CharProduct.GrossWeight,
                                stone_carat = dj.StockProductDJ_CharProduct.StoneCarat,
                                stone_weight = dj.StockProductDJ_CharProduct.StoneWeight,
                                stone_qty = dj.StockProductDJ_CharProduct.StoneQty,
                                netto_weight = dj.StockProductDJ_CharProduct.NettoWeight,
                                kadar_logam = dj.StockProductDJ_CharProduct.KadarLogam,
                                kadar_tukaran = dj.StockProductDJ_CharProduct.KadarTukaran,
                                dimensi_d = dj.StockProductDJ_CharProduct.DimensiD,
                                dimensi_p = dj.StockProductDJ_CharProduct.DimensiP,
                                dimensi_l = dj.StockProductDJ_CharProduct.DimensiL,
                                dimensi_r = dj.StockProductDJ_CharProduct.DimensiR ?? 0
                            };

                            foreach (var x in dj.StockProductDJ_Stone1As)
                            {
                                var StonePring1A = _db.StonePricing1As.SingleOrDefault(p => p.Id == x.Idstone);
                                var StoneCoing1A = _db.StoneCosting1As.SingleOrDefault(p => p.Id == x.Idstone);

                                //Setting
                                string querypbongkos = "SELECT dbo.fx_pricing_ongkospb('" + item + "','" + stonedist + "', '1A', " + x.Idstone + ", " + x.TotalCarat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + x.TotalButir + ")";
                                decimal OngkosPB = _openConnection.SingleDecimal(querypbongkos, _connectionStrings.ConnectionStrings.Cnn_DB);
                                stone1A.Add(new
                                {
                                    id_stone = x.Idstone,
                                    nama = _openConnection.SingleString("SELECT dbo.fx_getStoneName(" + x.Idstone + ", '1A')", _connectionStrings.ConnectionStrings.Cnn_DB),
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = StonePring1A.Harga.Value,
                                    harga_total = StoneCoing1A.Harga,
                                    harga_satuanm = StonePring1A.Harga.Value * x.TotalCarat,
                                    harga_totalm = StoneCoing1A.Harga * x.TotalCarat,
                                    efektif = StonePring1A.ApprovalTgl.Value.ToString("dd-MM-yyyy"),
                                    setting = OngkosPB,
                                    harga_total_rupiah = (StonePring1A.Harga.Value * x.TotalCarat * prc_us.Harga * 1.9m) + OngkosPB
                                });
                            }

                            foreach (var x in dj.StockProductDJ_Stone1Bs)
                            {
                                var StonePring1B = _db.StonePricing1Bs.SingleOrDefault(p => p.Id == x.Idstone);
                                var StoneCoing1B = _db.StoneCosting1Bs.SingleOrDefault(p => p.Id == x.Idstone);
                                var Stone1B = _db.Stone1Bs.SingleOrDefault(p => p.Id == x.Idstone);

                                //Setting
                                string querypbongkos = "SELECT dbo.fx_pricing_ongkospb('" + item + "','" + stonedist + "', '1B', " + x.Idstone + ", " + x.TotalCarat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + x.TotalButir + ")";
                                decimal OngkosPB = _openConnection.SingleDecimal(querypbongkos, _connectionStrings.ConnectionStrings.Cnn_DB);
                                stone1B.Add(new
                                {
                                    id_stone = x.Idstone,
                                    nama = _openConnection.SingleString("SELECT dbo.fx_getStoneName(" + x.Idstone + ", '1B')", _connectionStrings.ConnectionStrings.Cnn_DB),
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = StonePring1B.Harga.Value,
                                    harga_total = StoneCoing1B.Harga,
                                    harga_satuanm = StonePring1B.Harga.Value * x.TotalCarat,
                                    harga_totalm = StoneCoing1B.Harga * x.TotalCarat,
                                    efektif = StonePring1B.ApprovalTgl.Value.ToString("dd-MM-yyyy"),
                                    setting = OngkosPB,
                                    harga_total_rupiah = (StonePring1B.Harga.Value * x.TotalCarat * prc_us.Harga * 1.9m) + OngkosPB
                                });
                            }

                            foreach (var x in dj.StockProductDJ_Stone2s)
                            {
                                var StonePring2 = _db.StonePricing2s.SingleOrDefault(p => p.Id == x.Idstone);
                                var StoneCoing2 = _db.StoneCosting2s.SingleOrDefault(p => p.Id == x.Idstone);
                                var Stone2 = _db.Stone2s.SingleOrDefault(p => p.Id == x.Idstone);

                                //Setting
                                string querypbongkos = "SELECT dbo.fx_pricing_ongkospb('" + item + "','" + stonedist + "', '2', " + x.Idstone + ", " + x.TotalCarat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", " + x.TotalButir + ")";
                                decimal OngkosPB = _openConnection.SingleDecimal(querypbongkos, _connectionStrings.ConnectionStrings.Cnn_DB);
                                stone2.Add(new
                                {
                                    id_stone = x.Idstone,
                                    nama = _openConnection.SingleString("SELECT dbo.fx_getStoneName(" + x.Idstone + ", '2')", _connectionStrings.ConnectionStrings.Cnn_DB),
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = StonePring2.Harga.Value,
                                    harga_total = StoneCoing2.Harga,
                                    harga_satuanm = StonePring2.Harga.Value * x.TotalCarat,
                                    harga_totalm = StoneCoing2.Harga * x.TotalCarat,
                                    efektif = StonePring2.ApprovalTgl.Value.ToString("dd-MM-yyyy"),
                                    setting = OngkosPB,
                                    harga_total_rupiah = (StonePring2.Harga.Value * x.TotalCarat * prc_us.Harga * 1.9m) + OngkosPB
                                });
                            }

                            foreach (var x in dj.StockProductDJ_Stone3s)
                            {
                                var StonePring3 = _db.StonePricing3s.SingleOrDefault(p => p.Id == x.Idstone);
                                var StoneCoing3 = _db.StoneCosting3s.SingleOrDefault(p => p.Id == x.Idstone);
                                var Stone3 = _db.Stone3s.SingleOrDefault(p => p.Id == x.Idstone);

                                //Setting
                                string querypbongkos = "SELECT dbo.fx_pricing_ongkospb('" + item + "','" + stonedist + "', '3', " + x.Idstone + ", " + x.TotalCarat + ", " + x.TotalButir + ")";
                                decimal OngkosPB = _openConnection.SingleDecimal(querypbongkos, _connectionStrings.ConnectionStrings.Cnn_DB);
                                stone3.Add(new
                                {
                                    id_stone = x.Idstone,
                                    nama = _openConnection.SingleString("SELECT dbo.fx_getStoneName(" + x.Idstone + ", '3')", _connectionStrings.ConnectionStrings.Cnn_DB),
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = StonePring3.Harga.Value,
                                    harga_total = StoneCoing3.Harga,
                                    harga_satuanm = StonePring3.Harga.Value * x.TotalCarat,
                                    harga_totalm = StoneCoing3.Harga * x.TotalCarat,
                                    efektif = StonePring3.ApprovalTgl.Value.ToString("dd-MM-yyyy"),
                                    setting = OngkosPB,
                                    harga_total_rupiah = (StonePring3.Harga.Value * x.TotalCarat * prc_us.Harga * 1.9m) + OngkosPB
                                });
                            }

                            foreach (var x in dj.StockProductDJ_Stone4s)
                            {
                                var StonePring4 = _db.StonePricing4s.SingleOrDefault(p => p.Id == x.Idstone);
                                var StoneCoing4 = _db.StoneCosting4s.SingleOrDefault(p => p.Id == x.Idstone);
                                var Stone4 = _db.Stone4s.SingleOrDefault(p => p.Id == x.Idstone);

                                //Setting
                                string querypbongkos = "SELECT dbo.fx_pricing_ongkospb('" + item + "','" + stonedist + "', '4', " + x.Idstone + ", " + x.TotalCarat + ", " + x.TotalButir + ")";
                                decimal OngkosPB = _openConnection.SingleDecimal(querypbongkos, _connectionStrings.ConnectionStrings.Cnn_DB);
                                stone4.Add(new
                                {
                                    id_stone = x.Idstone,
                                    nama = _openConnection.SingleString("SELECT dbo.fx_getStoneName(" + x.Idstone + ", '4')", _connectionStrings.ConnectionStrings.Cnn_DB),
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = StonePring4.Harga.Value,
                                    harga_total = StoneCoing4.Harga,
                                    harga_satuanm = StonePring4.Harga.Value * x.TotalCarat,
                                    harga_totalm = StoneCoing4.Harga * x.TotalCarat,
                                    efektif = StonePring4.ApprovalTgl.Value.ToString("dd-MM-yyyy"),
                                    setting = OngkosPB,
                                    harga_total_rupiah = (StonePring4.Harga.Value * x.TotalCarat * prc_us.Harga * 1.9m) + OngkosPB
                                });
                            }

                            foreach (var x in dj.StockProductDJ_Stone5s)
                            {
                                var StonePring5 = _db.StonePricing5s.SingleOrDefault(p => p.Id == x.Idstone);
                                var StoneCoing5 = _db.StoneCosting5s.SingleOrDefault(p => p.Id == x.Idstone);
                                var Stone5 = _db.Stone5s.SingleOrDefault(p => p.Id == x.Idstone);

                                //Setting
                                string querypbongkos = "SELECT dbo.fx_pricing_ongkospb('" + item + "','" + stonedist + "', '5', " + x.Idstone + ", " + x.TotalCarat + ", " + x.TotalButir + ")";
                                decimal OngkosPB = _openConnection.SingleDecimal(querypbongkos, _connectionStrings.ConnectionStrings.Cnn_DB);
                                stone5.Add(new
                                {
                                    id_stone = x.Idstone,
                                    nama = _openConnection.SingleString("SELECT dbo.fx_getStoneName(" + x.Idstone + ", '5')", _connectionStrings.ConnectionStrings.Cnn_DB),
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = StonePring5.Harga.Value,
                                    harga_total = StoneCoing5.Harga,
                                    harga_satuanm = StonePring5.Harga.Value * x.TotalCarat,
                                    harga_totalm = StoneCoing5.Harga * x.TotalCarat,
                                    efektif = StonePring5.ApprovalTgl.Value.ToString("dd-MM-yyyy"),
                                    setting = OngkosPB,
                                    harga_total_rupiah = (StonePring5.Harga.Value * x.TotalCarat * prc_us.Harga * 1.9m) + OngkosPB
                                });
                            }
                            dtobject.Add(new
                            {
                                id_product = Convert.ToInt64(dr["ID_PRODUCT"]),
                                id_product_titipan = Convert.ToInt64(dr["ID_PRODUCT_TITIPAN"]),
                                nomor = dr["NOMOR"].ToString(),
                                harga_beli = Convert.ToDouble(dr["HARGA_BELI"]),
                                item = dr["ITEM"].ToString(),
                                status_stock = Convert.ToInt32(dr["STATUSSTOCK"]),
                                char_product_repair = char_product,
                                stone1A,
                                stone1B,
                                stone2,
                                stone3,
                                stone4,
                                stone5
                            });
                        }
                        else
                        {
                            object char_product;
                            StockProductDJCustomer dj = _db.StockProductDjcustomers.Include(p => p.StockProductDJCustomer_Stone1As)
                            .Include(p => p.StockProductDJCustomer_Stone1Bs)
                            .Include(p => p.StockProductDJCustomer_Stone2s)
                            .Include(p => p.StockProductDJCustomer_Stone3s)
                            .Include(p => p.StockProductDJCustomer_Stone4s)
                            .Include(p => p.StockProductDJCustomer_Stone5s)
                            .Include(p => p.StockProductDJCustomer_CharProduct)
                            .SingleOrDefault(p => p.Id == id_product_titipan);

                            char_product = new
                            {
                                id_product_item = dj.StockProductDJCustomer_CharProduct.ProductItem,
                                id_product_category = 0,
                                id_product_level = 0,
                                id_stone_dist = 0,
                                id_frame_material = 0,
                                id_frame_finishing = 0,
                                id_frame_color = 0,
                                id_process_cons = 0,
                                gross_weight = dj.StockProductDJCustomer_CharProduct.GrossWeight,
                                stone_carat = dj.StockProductDJCustomer_CharProduct.StoneCarat,
                                stone_weight = dj.StockProductDJCustomer_CharProduct.StoneWeight,
                                stone_qty = dj.StockProductDJCustomer_CharProduct.StoneQty,
                                netto_weight = dj.StockProductDJCustomer_CharProduct.NettoWeight,
                                kadar_logam = 0,
                                kadar_tukaran = 0,
                                dimensi_d = dj.StockProductDJCustomer_CharProduct.DimensiD,
                                dimensi_p = dj.StockProductDJCustomer_CharProduct.DimensiP,
                                dimensi_l = dj.StockProductDJCustomer_CharProduct.DimensiL,
                                dimensi_r = dj.StockProductDJCustomer_CharProduct.DimensiR ?? 0
                            };

                            foreach (var x in dj.StockProductDJCustomer_Stone1As)
                            {
                                stone1A.Add(new
                                {
                                    id_stone = x.Idstone,
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = 0,
                                    harga_total = 0,
                                    harga_satuanm = 0,
                                    harga_totalm = 0,
                                    efektif = "01-01-1990",
                                    setting = 0,
                                    harga_total_rupiah = 0
                                });
                            }

                            foreach (var x in dj.StockProductDJCustomer_Stone1Bs)
                            {
                                stone1B.Add(new
                                {
                                    id_stone = x.Idstone,
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = 0,
                                    harga_total = 0,
                                    harga_satuanm = 0,
                                    harga_totalm = 0,
                                    efektif = "01-01-1990",
                                    setting = 0,
                                    harga_total_rupiah = 0
                                });
                            }

                            foreach (var x in dj.StockProductDJCustomer_Stone2s)
                            {
                                stone2.Add(new
                                {
                                    id_stone = x.Idstone,
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = 0,
                                    harga_total = 0,
                                    harga_satuanm = 0,
                                    harga_totalm = 0,
                                    efektif = "01-01-1990",
                                    setting = 0,
                                    harga_total_rupiah = 0
                                });
                            }

                            foreach (var x in dj.StockProductDJCustomer_Stone3s)
                            {
                                stone3.Add(new
                                {
                                    id_stone = x.Idstone,
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = 0,
                                    harga_total = 0,
                                    harga_satuanm = 0,
                                    harga_totalm = 0,
                                    efektif = "01-01-1990",
                                    setting = 0,
                                    harga_total_rupiah = 0
                                });
                            }

                            foreach (var x in dj.StockProductDJCustomer_Stone4s)
                            {
                                stone4.Add(new
                                {
                                    id_stone = x.Idstone,
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = 0,
                                    harga_total = 0,
                                    harga_satuanm = 0,
                                    harga_totalm = 0,
                                    efektif = "01-01-1990",
                                    setting = 0,
                                    harga_total_rupiah = 0
                                });
                            }

                            foreach (var x in dj.StockProductDJCustomer_Stone5s)
                            {
                                stone5.Add(new
                                {
                                    id_stone = x.Idstone,
                                    total_butir = x.TotalButir,
                                    total_carat = x.TotalCarat,
                                    carat_butir = x.CaratButir,
                                    dimensi_p = x.DimensiP,
                                    dimensi_l = x.DimensiL ?? 0,
                                    dimesni_t = x.DimensiT ?? 0,
                                    harga_satuan = 0,
                                    harga_total = 0,
                                    harga_satuanm = 0,
                                    harga_totalm = 0,
                                    efektif = "01-01-1990",
                                    setting = 0,
                                    harga_total_rupiah = 0
                                });
                            }

                            dtobject.Add(new
                            {
                                id_product = Convert.ToInt64(dr["ID_PRODUCT"]),
                                id_product_titipan = Convert.ToInt64(dr["ID_PRODUCT_TITIPAN"]),
                                nomor = dr["NOMOR"].ToString(),
                                harga_beli = Convert.ToDouble(dr["HARGA_BELI"]),
                                item = dr["ITEM"].ToString(),
                                status_stock = Convert.ToInt32(dr["STATUSSTOCK"]),
                                char_product_repair = char_product,
                                stone1A,
                                stone1B,
                                stone2,
                                stone3,
                                stone4,
                                stone5
                            });
                        }
                    }
                }
                return new { message = "", data = dtobject };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object ReportRepair(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "EXEC sp_report_repair_new '" + kw + "','" + start + "','" + end + "','" + location + "'," + status + "," + page + "," + row + "," + excel;
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
                        idproduct = dr["IDPRODUCT"].ToString(),
                        nomor = dr["NOMOR"].ToString(),
                        invoice = dr["INVOICE"].ToString(),
                        plu = dr["PLU"].ToString(),
                        tgl = Convert.ToDateTime(dr["TANGGAL"]).ToString("dd-MM-yyyy"),
                        customer = dr["CUSTOMER"].ToString(),
                        sales = dr["SALES"].ToString(),
                        item = dr["ITEM"].ToString(),
                        gross_weight_before = Convert.ToDecimal(dr["GROSS_WEIGHT_SEBELUM"]),
                        gross_weight_after = Convert.ToDecimal(dr["GROSS_WEIGHT_SESUDAH"]),
                        total_butir_before = Convert.ToInt32(dr["TOTAL_BUTIR_SEBELUM"]),
                        total_butir_after = Convert.ToInt32(dr["TOTAL_BUTIR_SESUDAH"]),
                        total_carat_before = Convert.ToDecimal(dr["TOTAL_CARAT_SEBELUM"]),
                        total_carat_after = Convert.ToDecimal(dr["TOTAL_CARAT_SESUDAH"]),
                        total_biaya = Convert.ToDecimal(dr["TOTAL_BIAYA"]),
                        total_discount = Convert.ToDecimal(dr["TOTAL_DISCOUNT"]),
                        total_bayar = Convert.ToDecimal(dr["TOTAL_BAYAR"])
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object ReportRepairResult(string kw, string start, string end, string location, int status, int page, int row, int excel)
        {
            try
            {
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                string query = "EXEC sp_report_repair_result_new '" + kw + "','" + start + "','" + end + "','" + location + "'," + status + "," + page + "," + row + "," + excel;
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
                        nomor = dr["NOMOR"].ToString(),
                        invoice = dr["INVOICE"].ToString(),
                        plu = dr["PLU"].ToString(),
                        tgl = Convert.ToDateTime(dr["TANGGAL"]).ToString("dd-MM-yyyy"),
                        customer = dr["CUSTOMER"].ToString(),
                        sales = dr["SALES"].ToString(),
                        item = dr["ITEM"].ToString(),
                        gross_weight_before = Convert.ToDecimal(dr["GROSS_WEIGHT_SEBELUM"]),
                        gross_weight_after = Convert.ToDecimal(dr["GROSS_WEIGHT_SESUDAH"]),
                        total_butir_before = Convert.ToInt32(dr["TOTAL_BUTIR_SEBELUM"]),
                        total_butir_after = Convert.ToInt32(dr["TOTAL_BUTIR_SESUDAH"]),
                        total_carat_before = Convert.ToDecimal(dr["TOTAL_CARAT_SEBELUM"]),
                        total_carat_after = Convert.ToDecimal(dr["TOTAL_CARAT_SESUDAH"]),
                        total_biaya = Convert.ToDecimal(dr["TOTAL_BIAYA"]),
                        total_discount = Convert.ToDecimal(dr["TOTAL_DISCOUNT"]),
                        total_bayar = Convert.ToDecimal(dr["TOTAL_BAYAR"])
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object UploadImageRepair(IFormFile files, int id, string brand)
        {
            return _common.UploadImageSO(files, id, id.ToString(), brand, Common.ActionUpload.DocRepair);
        }

        public object GetListInvoiceRepair(string kw, string location, int page, int row, int excel)
        {
            try
            {
                string query = "EXEC sp_get_list_invoice_repair_new '" + kw + "'," +
                    " '" + location + "', " + page + ", " + row + ", " + excel;
                kw = string.IsNullOrEmpty(kw) ? "" : _common.ChangeStringWildCardCharacterSQL(kw);
                location = string.IsNullOrEmpty(location) ? "" : _common.ChangeStringWildCardCharacterSQL(location);
                DataSet ds = _openConnection.Ds(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                DataTable dt = ds.Tables[0];
                DataTable dtcount = ds.Tables[1];
                List<object> dtobject = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    dtobject.Add(new
                    {
                        id = dr["ID"],
                        nomor = dr["NOMOR"],
                        tgl = dr["TGL"],
                        customer = dr["CUSTOMER"],
                        sales = dr["SALES"],
                        tipe_lokasi = dr["TIPE_LOKASI"],
                        nama_lokasi = dr["NAMA_LOKASI"]
                    });
                }
                return new { message = "", data = dtobject, total = Convert.ToInt32(dtcount.Rows[0][0]) };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object AddRepairInvoice(RequestRepairResult rr)
        {
            try
            {
                string queryrr = "EXEC sp_insert_repair_result_dj_new";
                string querystart = "DECLARE @TABLE TABLE(ID INT, NO_RPR VARCHAR(100), [MESSAGE] VARCHAR(1000)) ";
                if (rr != null)
                {
                    querystart = querystart + " INSERT INTO @TABLE(ID, NO_RPR, [MESSAGE]) " + queryrr +
                        " " + rr.id_doc_repair + ", " + rr.id_lokasi + ", " + rr.tipe_lokasi + ", '" + rr.kode_lokasi + "'," + rr.id_customer + "," +
                        " '" + rr.customer_nama + "', " + rr.id_sales + ", '" + rr.sales_nama + "'," +
                        " '" + rr.operator_nama + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                        " '" + rr.tgl_selesai.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', '" + rr.keterangan + "'," +
                        " " + rr.id_product + ", " + rr.sumber + ", " + rr.id_product_titipan + "," +
                        " " + rr.estimasi_harga + ", " + rr.idqc + ", " + rr.idqc_titipan + "," +
                        " '" + 1.ToString() + "' " +
                        " DECLARE @IDRPR INT = (SELECT TOP 1 ID FROM @TABLE) " +
                        " DECLARE @NOMORRPR VARCHAR(50) = (SELECT TOP 1 NO_RPR FROM @TABLE) ";

                    if (rr.char_product_repair != null)
                    {
                        var x = rr.char_product_repair;
                        string query_charprod = "EXEC sp_insert_repair_result_dj_char_product_new";
                        querystart += query_charprod + " @IDRPR, " +
                            " " + x.gross_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.stone_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.stone_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.stone_qty.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.netto_weight.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_d + ", " + x.dimensi_p + ", " + x.dimensi_l + ", " + x.dimensi_r + " ";
                    }
                    foreach (var x in rr.process_list_repair)
                    {
                        string query_charrepair = "EXEC sp_insert_repair_repair_result_dj_new";
                        querystart += query_charrepair + " @IDRPR, " + x.id_repair + "," +
                            " " + x.biaya.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " '" + x.keterangan + "' ";
                    }

                    foreach (var x in rr.stone1A_repair)
                    {
                        string tipe = "1A";
                        string query_stone = "EXEC sp_insert_repair_result_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " 'GIA', 0, 0, 1 ";
                    }

                    foreach (var x in rr.stone1B_repair)
                    {
                        string tipe = "1B";
                        string query_stone = "EXEC sp_insert_repair_result_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', " + x.harga_input_h.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_input_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.status_terpasang + " ";
                    }

                    foreach (var x in rr.stone2_repair)
                    {
                        string tipe = "2";
                        string query_stone = "EXEC sp_insert_repair_result_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', 0, 0, 1 ";
                    }

                    foreach (var x in rr.stone3_repair)
                    {
                        string tipe = "3";
                        string query_stone = "EXEC sp_insert_repair_result_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', 0, 0, 1 ";
                    }

                    foreach (var x in rr.stone4_repair)
                    {
                        string tipe = "4";
                        string query_stone = "EXEC sp_insert_repair_result_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', 0, 0, 1 ";
                    }

                    foreach (var x in rr.stone5_repair)
                    {
                        string tipe = "5";
                        string query_stone = "EXEC sp_insert_repair_reault_dj_stone_new";
                        querystart += query_stone + " '" + tipe + "', @IDRPR, " + x.id_stone + "," +
                            " '" + x.keterangan + "', " + x.total_butir + "," +
                            " " + x.total_carat.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.carat_butir.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_p.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimensi_l.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.dimesni_t.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_satuan_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_m.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.efektif.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'," +
                            " " + x.setting.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " " + x.harga_total_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                            " '" + x.gia + "', 0, 0, 1 ";
                    }
                    string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT * FROM @TABLE END TRY BEGIN CATCH SELECT 0[ID], '' [NO_RPR], ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                    DataTable result = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                    string res = result.Rows[0]["MESSAGE"].ToString();
                    int idrpr = Convert.ToInt32(result.Rows[0]["ID"]);
                    string norpr = result.Rows[0]["NO_RPR"].ToString();
                    return new { message = res, id = idrpr, invoice = norpr };
                }
                else
                {
                    return new { message = "Data Not Found" };
                }
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object AddPaymentRepair(RequestSalesOrderRepair rsr, string operator_nama)
        {
            try
            {
                string querystart = "DECLARE @TABLE TABLE(ID INT, [MESSAGE] VARCHAR(1000)) ";
                string querysor = "EXEC sp_insert_sales_order_repair_new " + rsr.id_repair_result + ",'" + operator_nama + "'," + rsr.harga_rupiah.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + rsr.discount.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," + rsr.total_bayar.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                string querysr = "EXEC sp_insert_sales_receipt_repair_new " + rsr.id_repair_result + "," + rsr.total_bayar.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ",'" + operator_nama + "' ";
                querystart += querysor + " INSERT INTO @TABLE(ID, [MESSAGE]) " + querysr + " DECLARE @IDSR INT = (SELECT TOP 1 ID FROM @TABLE) ";
                foreach (var item in rsr.payment)
                {
                    querystart += "EXEC sp_insert_sales_receipt_detail_new @IDSR," +
                        " " + item.id_payment_type + ", " + item.id_card + ", " + item.id_program + "," +
                        " " + item.mdr + ", " + item.id_edc + ", " + item.id_bank_issuer + "," +
                        " '" + item.cc_number + "', '" + item.cc_name + "', " + item.nominal.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                        " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + item.operator_nama + "', " +
                        " " + item.id_jenis_kartu_kredit + ", '" + item.approval_code + "' " +
                        " ";
                }
                string query = "BEGIN TRY BEGIN TRAN DJANCUK " + querystart + " COMMIT TRAN DJANCUK SELECT '' [MESSAGE] END TRY BEGIN CATCH SELECT ERROR_MESSAGE() [MESSAGE] ROLLBACK TRAN DJANCUK END CATCH";

                string res = _openConnection.SingleString(query, _connectionStrings.ConnectionStrings.Cnn_DB);
                return new { message = res };
            }
            catch (Exception ex)
            {
                return new { message = _common.ReturnError() };
            }
        }

        public object PostingRepairToMyapps(string nomor)
        {
            try
            {
                string brand = _connectionStrings.AppConfig.BrandCode;
                string brandcode = (brand == "F") ? "FC" : (brand == "P") ? "TP" : (brand == "M" || brand == "S") ? "MD" : "";
                string query = "EXEC sp_get_repair_myapps '" + brandcode + "','" + nomor + "'";
                _openConnection.Execute(query, _connectionStrings.ConnectionStrings.Cnn_CMK);
                return new { message = "" };
            }
            catch
            {
                return new { message = _common.ReturnError() };
            }
        }
    }
}
