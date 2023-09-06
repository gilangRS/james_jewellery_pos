using Connection.Interface;
using Connection.Models;
using Connection.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Connection.Repositories
{
    public class StockInventoryRepository : IStockInventoryRepository
    {
        private readonly JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;
        private Common common = new Common();
        public StockInventoryRepository()
        {
            _context = new JAWSDbContext();
            this.connectionStrings = new ConnectionString();
        }

        #region DJ
        public List<object> GetStockDJRekapOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage, int GroupBy)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryDJ_Rekap '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + ProductItem + ", "
                + ProductCategory + ", "
                + Substorage + ", "
                + GroupBy;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        Keterangan = row["Keterangan"].ToString(),
                        Stock = Convert.ToInt32(row["Stock"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        TotalStone = Convert.ToInt32(row["StoneQty"]),
                        TotalCarat = Convert.ToDecimal(row["StoneCarat"]),
                        Harga = Convert.ToDecimal(row["Harga"])
                    });
                }
            }
            return datas;
        }

        public List<object> GetStockDJListOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryDJ_List '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + ProductItem + ", "
                + ProductCategory + ", "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProtoNomor = row["ProtoNomor"].ToString(),
                        SupplierNomor = row["SupplierNomor"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        ProductCategory = row["ProductCategory"].ToString(),
                        Segmen = row["Segmen"].ToString(),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        TotalStone = Convert.ToInt32(row["StoneQty"]),
                        TotalCarat = Convert.ToDecimal(row["StoneCarat"]),
                        Harga = Convert.ToDecimal(row["HargaRupiahRound"]),
                        HargaPromo = Convert.ToDecimal(row["HargaPromo"]),
                        Umur = row["Days"].ToString(),
                        Bunga = Convert.ToDecimal(row["Bunga"]),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString())
                    });
                }
            }
            else { connection.Execute("exec sp_ThrowError 'Data tidak ditemukan'", connectionStrings.ConnectionStrings.Cnn_DB); }
            return datas;
        }

        public List<object> GetDJOutgoing(string Nomor, int Tipelokasi, int IDLokasi, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryDJ_List '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", 0, 0, "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProtoNomor = row["ProtoNomor"].ToString(),
                        SupplierNomor = row["SupplierNomor"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        ProductCategory = row["ProductCategory"].ToString(),
                        Segmen = row["Segmen"].ToString(),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        TotalStone = Convert.ToInt32(row["StoneQty"]),
                        TotalCarat = Convert.ToDecimal(row["StoneCarat"]),
                        Harga = Convert.ToDecimal(row["HargaRupiahRound"]),
                        HargaPromo = Convert.ToDecimal(row["HargaPromo"]),
                        Umur = row["Days"].ToString(),
                        Bunga = Convert.ToDecimal(row["Bunga"]),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString())
                    });
                }
            }
            return datas;
        }

        #endregion

        #region PG
        public List<object> GetStockPGListOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int GoldLevel, int Model, int FrameColor, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryPG '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + ProductItem + ", "
                + GoldLevel + ", "
                + Model + ", "
                + FrameColor + ", "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        Tgl = Convert.ToDateTime(row["Tgl"]).ToString("D"),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        GoldLevel = row["GoldLevel"].ToString(),
                        Model = row["Model"].ToString(),
                        FrameColor = row["FrameColor"].ToString(),
                        KadarLogam = Convert.ToDecimal(row["KadarLogam"]),
                        Size = Convert.ToDecimal(row["DimensiR"]),
                        TotalBerat = Convert.ToDecimal(row["TotalBerat"]),
                        TotalWeight = Convert.ToDecimal(row["TotalWeight"]),
                        Ongkos = Convert.ToDecimal(row["Ongkos"]),
                        Harga = Convert.ToDecimal(row["Harga"]),
                        TotalHarga = Convert.ToDecimal(row["TotalHarga"]),
                        HargaJual = Convert.ToDecimal(row["HargaJual"])
                    });
                }
            }
            return datas;
        }

        public List<object> GetPGOutgoing(string Nomor, int Tipelokasi, int IDLokasi, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryPG '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", 0, 0, 0, 0, "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        Tgl = Convert.ToDateTime(row["Tgl"]).ToString("D"),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        GoldLevel = row["GoldLevel"].ToString(),
                        Model = row["Model"].ToString(),
                        FrameColor = row["FrameColor"].ToString(),
                        KadarLogam = Convert.ToDecimal(row["KadarLogam"]),
                        Size = Convert.ToDecimal(row["DimensiR"]),
                        TotalBerat = Convert.ToDecimal(row["TotalBerat"]),
                        TotalWeight = Convert.ToDecimal(row["TotalWeight"]),
                        Ongkos = Convert.ToDecimal(row["Ongkos"]),
                        Harga = Convert.ToDecimal(row["Harga"]),
                        TotalHarga = Convert.ToDecimal(row["TotalHarga"]),
                        HargaJual = Convert.ToDecimal(row["HargaJual"]),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString())
                    });
                }
            }
            return datas;
        }

        #endregion

        #region LD
        public List<object> GetStockLDListOutlet(string Nomor, int Tipelokasi, int IDLokasi, int Shape, int Size, int Color, int Clarity, int Cutting, int Brand, int Category, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryLD_List '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + Shape + ", "
                + Size + ", "
                + Color + ", "
                + Clarity + ", "
                + Cutting + ", "
                + Brand + ", "
                + Category + ", "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        Parcel = row["Parcel"].ToString(),
                        GIA = row["GIA"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        Shape = row["Shape"].ToString(),
                        Size = row["Size"].ToString(),
                        Color = row["Color"].ToString(),
                        Clarity = row["Clarity"].ToString(),
                        Cutting = row["Cutting"].ToString(),
                        Category = row["Category"].ToString(),
                        Brand = row["Brand"].ToString(),
                        HargaTotalM = Convert.ToDecimal(row["HargaTotalM"]),
                        HargaTotal = Convert.ToDecimal(row["HargaTotal"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                    });
                }
            }
            return datas;
        }

        public List<object> GetLDOutgoing(string Nomor, int Tipelokasi, int IDLokasi, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryLD_List '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", 0, 0, 0, 0, 0, 0, 0, "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        GIA = row["GIA"].ToString(),
                        TotalButir = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        HargaTotal = Convert.ToDecimal(row["HargaTotal"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                    });
                }
            }
            return datas;
        }

        public List<object> GetStockLDList(string Nomor, int Tipelokasi, int IDLokasi, int Shape, int Size, int Color, int Clarity, int Cutting, int Brand, int Category, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryLD_List '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + Shape + ", "
                + Size + ", "
                + Color + ", "
                + Clarity + ", "
                + Cutting + ", "
                + Brand + ", "
                + Category + ", "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        Parcel = row["Parcel"].ToString(),
                        GIA = row["GIA"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        Shape = row["Shape"].ToString(),
                        Size = row["Size"].ToString(),
                        Color = row["Color"].ToString(),
                        Clarity = row["Clarity"].ToString(),
                        Cutting = row["Cutting"].ToString(),
                        Category = row["Category"].ToString(),
                        Brand = row["Brand"].ToString(),
                        HargaTotalM = Convert.ToDecimal(row["HargaTotalM"]),
                        HargaTotal = Convert.ToDecimal(row["HargaTotal"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                    });
                }
            }
            return datas;
        }
        #endregion

        #region GJ
        public List<object> GetStockGJRekapOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage, int GroupBy)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryGJ_Rekap '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + ProductItem + ", "
                + ProductCategory + ", "
                + Substorage + ", "
                + GroupBy;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        Keterangan = row["Keterangan"].ToString(),
                        Stock = Convert.ToInt32(row["Stock"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        Harga = Convert.ToDecimal(row["Harga"])
                    });
                }
            }
            return datas;
        }

        public List<object> GetStockGJListOutlet(string Nomor, int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryGJ '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + ProductItem + ", "
                + ProductCategory + ", "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProtoNomor = row["ProtoNomor"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        ProductCategory = row["ProductCategory"].ToString(),
                        Segmen = row["Segmen"].ToString(),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        Harga = Convert.ToDecimal(row["HargaRupiahRound"])
                    });
                }
            }
            return datas;
        }
        public List<object> GetGJOutgoing(string Nomor, int Tipelokasi, int IDLokasi, int Substorage)
        {
            List<object> datas = new List<object>();

            string query = "exec sp_StockInventoryGJ '"
                + Nomor + "', "
                + Tipelokasi + ", "
                + IDLokasi + ", 0, 0, "
                + Substorage;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProtoNomor = row["ProtoNomor"].ToString(),
                        SupplierNomor = row["SupplierNomor"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        Status = row["Substorage"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        ProductCategory = row["ProductCategory"].ToString(),
                        Segmen = row["Segmen"].ToString(),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        TotalStone = Convert.ToInt32(row["StoneQty"]),
                        TotalCarat = Convert.ToDecimal(row["StoneCarat"]),
                        Harga = Convert.ToDecimal(row["HargaRupiahRound"]),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString())
                    });
                }
            }
            return datas;
        }
        #endregion
        public object GetStockSummary(int Tipelokasi, int IDLokasi, int ProductItem, int ProductCategory, int Substorage)
        {
            List<object> Summmary = new List<object>();
            List<object> Detail = new List<object>();
            object data = new object();

            string query = "exec sp_StockInventorySummary '', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + ProductItem + ", "
                + ProductCategory + ", "
                + Substorage + ", 0";

            DataSet ds = connection.Ds(query, connectionStrings.ConnectionStrings.Cnn_DB);

            DataTable dt = ds.Tables["data"];

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    Summmary.Add(new
                    {
                        Keterangan = row["Keterangan"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        TotalHarga = Convert.ToDecimal(row["TotalHarga"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        TotalButir = Convert.ToDecimal(row["TotalButir"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"])
                    });
                }
            }

            DataTable dt1 = ds.Tables["data1"];

            if (dt1.Rows.Count > 0)
            {

                foreach (DataRow row in dt1.Rows)
                {
                    Detail.Add(new
                    {
                        Keterangan = row["Keterangan"].ToString(),
                        Jual = Convert.ToInt32(row["Jual"]),
                        Resell = Convert.ToInt32(row["Resell"]),
                        TradeIn = Convert.ToInt32(row["TradeIn"]),
                        Titipan = Convert.ToInt32(row["TitipanCustomer"]),
                        Reparasi = Convert.ToInt32(row["Reparasi"]),
                        Lebur = Convert.ToInt32(row["Lebur"]),
                        Hadiah = Convert.ToInt32(row["Hadiah"]),
                        OngoingLebur = Convert.ToInt32(row["OngoingLebur"]),
                        Broken = Convert.ToInt32(row["Broken"]),
                        Ongoing = Convert.ToInt32(row["Ongoing"]),
                        Lost = Convert.ToInt32(row["Lost"]),
                        Total = Convert.ToInt32(row["Total"])
                    });
                }
            }

            data = new
            {
                Summary = Summmary,
                Detail = Detail
            };

            return data;
        }

        public List<object> GetStockLedger(string Nomor)
        {
            List<object> datas = new List<object>();
            string Type = string.Empty;

            if (_context.StockProductDjs.Any(p => p.Nomor.Equals(Nomor) && p.Draft == false)) Type = "DJ";
            else if (_context.StockProductGjs.Any(p => p.Nomor.Equals(Nomor) && p.Draft == false)) Type = "GJ";
            else if (_context.StockProductPgs.Any(p => p.Nomor.Equals(Nomor) && p.Draft == false)) Type = "PG";
            else if (_context.StockProductLdStone1Bs.Any(p => p.Nomor.Equals(Nomor))) Type = "LD";

            string query = "exec sp_StockLedger '" + Nomor + "', '" + Type + "'";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        Nomor = row["Nomor"].ToString(),
                        Tanggal = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        TipeLokasi = row["Type"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        Value = Convert.ToInt32(row["Value"]),
                        Remark = row["Remark"].ToString(),
                        Keterangan = row["Keterangan"].ToString()
                    });
                }
            }
            return datas;
        }

        public object GetItemRekap(int Tipelokasi, int IDLokasi, int ProductItem, int Substorage)
        {
            List<object> data = new List<object>();

            string query = "exec sp_StockInventoryItemRekap '', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + ProductItem + ", 0, "
                + Substorage + ", 0";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    data.Add(new
                    {
                        ProductItem = row["ProductItem"].ToString(),
                        Qty = Convert.ToInt32(row["Qty"]),
                        TotalHarga = Convert.ToDecimal(row["TotalHarga"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        TotalButir = Convert.ToDecimal(row["TotalButir"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"])
                    });
                }
            }

            return data;
        }

        public object GetItemDetail(int Tipelokasi, int IDLokasi, int ProductItem, int Substorage)
        {
            List<object> data = new List<object>();

            string query = "exec sp_StockInventoryItemRekap '', "
                + Tipelokasi + ", "
                + IDLokasi + ", "
                + ProductItem + ", 0, "
                + Substorage + ", 1";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    data.Add(new
                    {
                        Nomor = row["Nomor"].ToString(),
                        KodeKaret = row["KodeKaret"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        Tipe = row["Tipe"].ToString(),
                        Substorage = row["Substorage"].ToString(),
                        TotalHarga = Convert.ToDecimal(row["TotalHarga"]),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        TotalButir = Convert.ToDecimal(row["TotalButir"]),
                        TotalCarat = Convert.ToDecimal(row["TotalCarat"])
                    });
                }
            }

            return data;
        }

    }
}
