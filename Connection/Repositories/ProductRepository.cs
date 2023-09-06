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
    public class ProductRepository : IProductRepository
    {
        private readonly JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;
        private Common common = new Common();
        public ProductRepository()
        {
            _context = new JAWSDbContext();
            this.connectionStrings = new ConnectionString();
        }

        public object GetProductCatalogDJ(string Keyword, int ProductItem, int ProductCategory, int ProductLevel, int StoneDist, int FrameMaterial, int FrameColor, decimal MinPrice, decimal MaxPrice, int Basic, int Stock, int StoneBrand, int Brand, int Page, int ItemPerPage, int isStore)
        {
            object data = new object();
            List<object> datas = new List<object>();

            string query = "exec sp_report_product_catalogue_allBrand "
                + Page.ToString() + ", "
                + ItemPerPage.ToString() + ", 'DJ', "
                + "'" + Keyword + "', "
                + MinPrice.ToString() + ", "
                + MaxPrice.ToString() + ", "
                + Basic.ToString() + ", "
                + ProductItem.ToString() + ", "
                + ProductCategory.ToString() + ", "
                + ProductLevel.ToString() + ", "
                + StoneDist.ToString() + ", "
                + "-1, -1, -1, -1, -1, "
                + FrameMaterial.ToString() + ", "
                + FrameColor.ToString() + ", "
                + Stock.ToString() + ", "
                + StoneBrand.ToString() + ", "
                + isStore + ", "
                + Brand.ToString();

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);
            
            if (dt.Rows.Count > 0)
            {
                
                foreach(DataRow row in dt.Rows)
                {
                    datas.Add(new { ProtoNomor = row["ProtoNomor"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        IDBrand = Convert.ToInt32(row["IDBrand"]),
                        QtyReadyToSell = Convert.ToInt32(row["QtyReadyToSell"]),
                        QtyReadyToSellWithPriceFilter = Convert.ToInt32(row["QtyReadyToSellWithPriceFilter"]),
                        Harga = Convert.ToDecimal(row["Harga"])
                    });
                }
                data = new { Product = datas, MaxPage = dt.Rows[0]["MaxPaging"] };
            }
            return data;
        }
        
        public object GetDetailProductDJ(int id)
        {
            object data = new object();
            List<object> datas = new List<object>();


            string query = "exec sp_getDetailProductDJ "
                + id.ToString();

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new 
                    {
                        ID = Convert.ToUInt32(row["ID"]),
                        Nomor = row["Nomor"].ToString(),
                        ProtoNomor = row["ProtoNomor"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        DesignCategory = row["DesignCategory"].ToString(),
                        DesignConcept = row["DesignConcept"].ToString(),
                        DesignProcess = row["DesignProcess"].ToString(),
                        TargetAge = row["TargetAge"].ToString(),
                        TargetGender = row["TargetGender"].ToString(),
                        Grafir = row["Grafir"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        ProductCategory = row["ProductCategory"].ToString(),
                        ProductLevel = row["ProductLevel"].ToString(),
                        FrameMaterial = row["FrameMaterial"].ToString(),
                        FrameFinishing = row["FrameFinishing"].ToString(),
                        FrameColor = row["FrameColor"].ToString(),
                        ProcessCons = row["ProcessCons"].ToString(),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        StoneCarat = Convert.ToDecimal(row["StoneCarat"]),
                        StoneWeight = Convert.ToDecimal(row["StoneWeight"]),
                        DimensiL = Convert.ToDecimal(row["DimensiL"]),
                        DimensiP = Convert.ToDecimal(row["DimensiP"]),
                        DimensiR = Convert.ToDecimal(row["DimensiR"]),
                        DimensiD = Convert.ToDecimal(row["DimensiD"]),
                        Harga = Convert.ToDecimal(row["HargaRupiahRound"]),
                        HargaPromo = Convert.ToDecimal(row["PromoHarga"]),
                    });
                }
            }
            return datas;
        }

        public object GetDetailCatalogDJ(string Keyword, decimal HargaMin, decimal HargaMax, int isStore, int Stone)
        {
            object data = new object();
            List<object> product = new List<object>();
            string Nomor = string.Empty;
            bool IsPLU = false;

            string query = "exec sp_getDetailCatalogDJAll '"
                + Keyword + "', " 
                + HargaMin + ", "
                + HargaMax + ", "
                + isStore + ", "
                + Stone;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    if (string.IsNullOrEmpty(Nomor)) Nomor = row["Nomor"].ToString();
                    if (row["Nomor"].ToString() == Keyword) IsPLU = true;
                    product.Add(new
                    {
                        ID = Convert.ToUInt32(row["ID"]),
                        Brand = row["Brand"].ToString(),
                        Nomor = row["Nomor"].ToString(),
                        ProtoNomor = row["ProtoNomor"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        LocationType = row["LocationType"] == null ? "" : row["LocationType"].ToString(),
                        Location = row["Location"] == null ? "" : row["Location"].ToString(),
                        SupplierNomor = row["SupplierNomor"] == null ? "" : row["SupplierNomor"].ToString(),
                        Substorage = row["Substorage"] == null ? "" : row["Substorage"].ToString(),
                        DesignCategory = row["DesignCategory"].ToString(),
                        DesignConcept = row["DesignConcept"].ToString(),
                        DesignProcess = row["DesignProcess"].ToString(),
                        TargetAge = row["TargetAge"].ToString(),
                        TargetGender = row["TargetGender"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        ProductCategory = row["ProductCategory"].ToString(),
                        ProductLevel = row["ProductLevel"].ToString(),
                        FrameMaterial = row["FrameMaterial"].ToString(),
                        FrameFinishing = row["FrameFinishing"].ToString(),
                        FrameColor = row["FrameColor"].ToString(),
                        ProcessCons = row["ProcessCons"].ToString(),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        NettoWeight = Convert.ToDecimal(row["NettoWeight"]),
                        StoneCarat = Convert.ToDecimal(row["StoneCarat"]),
                        StoneWeight = Convert.ToDecimal(row["StoneWeight"]),
                        DimensiL = Convert.ToDecimal(row["DimensiL"]),
                        DimensiP = Convert.ToDecimal(row["DimensiP"]),
                        DimensiR = Convert.ToDecimal(row["DimensiR"]),
                        DimensiD = Convert.ToDecimal(row["DimensiD"]),
                        Harga = Convert.ToDecimal(row["HargaRupiahRound"]),
                        HargaPromo = Convert.ToDecimal(row["HargaPromo"]),
                        OnFilter = row["OnFilter"] == null ? 0 : Convert.ToInt32(row["OnFilter"])
                    });
                }
            }

            data = new {
                Product = product,
                Stone = GetDataStone(Nomor),
                IsPLU = IsPLU
            };
            return data;
        }

        public object GetProductCatalogPG(string Keyword, int ProductItem, int GoldLevel, int GoldModel, int FrameColor, decimal MinPrice, decimal MaxPrice, int Basic, int Stock, int Brand, int Page, int ItemPerPage, int FixRate, decimal MinWeight, decimal MaxWeight, decimal MinSize, decimal MaxSize, int UserID)
        {
            object data = new object();
            List<object> datas = new List<object>();

            string query = "exec sp_report_product_catalogue_allBrand "
                + Page.ToString() + ", "
                + ItemPerPage.ToString() + ", 'PG', "
                + "'" + Keyword + "', "
                + MinPrice.ToString() + ", "
                + MaxPrice.ToString() + ", "
                + Basic.ToString() + ", "
                + ProductItem.ToString() + ", "
                + "-1, -1, -1, -1, -1, -1, -1, -1, -1, "
                + FrameColor.ToString() + ", "
                + Stock.ToString() + ", 0, " 
                + common.IsStore(UserID) + ", "
                + Brand.ToString() + ", "
                + GoldLevel.ToString() + ", "
                + GoldModel.ToString() + ", -1, "
                + FixRate.ToString() + ", "
                + MinWeight.ToString() + ", "
                + MaxWeight.ToString() + ", "
                + MinSize.ToString() + ", "
                + MaxSize.ToString();

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ProtoNomor = row["ProtoNomor"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),               
                        IDBrand = Convert.ToInt32(row["IDBrand"]),
                        QtyReadyToSell = Convert.ToInt32(row["QtyReadyToSell"]),
                        QtyReadyToSellWithPriceFilter = Convert.ToInt32(row["QtyReadyToSellWithPriceFilter"]),
                        Harga = Convert.ToDecimal(row["Harga"])
                    });
                }
                data = new { Product = datas, MaxPage = dt.Rows[0]["MaxPaging"] };
            }
            return data;
        }

        public object GetDetailCatalogPG(string Keyword, decimal MinSize, decimal MaxSize, decimal MinWeight, decimal MaxWeight, decimal MinPrice, decimal MaxPrice)
        {
            object data = new object();
            List<object> datas = new List<object>();
            bool IsPLU = false;

            string query = "exec sp_getDetailCatalogPGAll " +
                "'" + Keyword + "', " +
                MinSize + ", " +
                MaxSize + "," +
                MinWeight + ", " +
                MaxWeight + ", " +
                MinPrice + ", " +
                MaxPrice + "";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    if (row["Nomor"].ToString() == Keyword) IsPLU = true;
                    datas.Add(new
                    {
                        ID = Convert.ToUInt32(row["ID"]),
                        Brand = row["Brand"].ToString(),
                        Nomor = row["Nomor"].ToString(),
                        ProtoNomor = row["ProtoNomor"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        LocationType = row["LocationType"].ToString(),
                        Location = row["Location"].ToString(),
                        Substorage = row["Substorage"].ToString(),
                        ProductItem = row["ProductItem"].ToString(),
                        GoldLevel = row["GoldLevel"].ToString(),
                        FrameColor = row["FrameColor"].ToString(),
                        GoldModel = row["GoldModel"].ToString(),
                        TargetAge = row["TargetAge"].ToString(),
                        GrossWeight = Convert.ToDecimal(row["GrossWeight"]),
                        KadarLogam = Convert.ToDecimal(row["KadarLogam"]),
                        Size = Convert.ToDecimal(row["Size"]),
                        Harga = Convert.ToDecimal(row["HargaRupiah"]),
                        PromoHarga = Convert.ToDecimal(row["PromoHarga"]),
                        OnFilter = Convert.ToInt32(row["OnFilter"]),
                        IsPLU = IsPLU
                    });
                }
            }
            return datas;
        }

        public object GetTrendingProduct()
        {
            object data = new object();
            List<object> datas = new List<object>();


            string query = "exec sp_getTrendingProduct";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ProductName = row["ProductName"].ToString(),
                        ImgPicture = common.ImageCDN(row["ImgPicture"].ToString()),
                        HargaMax = Convert.ToDecimal(row["HargaMax"]),
                        HargaMin = Convert.ToDecimal(row["HargaMin"])
                    });
                }
            }
            return datas;
        }

        private object GetDataStone(string Nomor)
        {
            object data = new object();
            List<object> Stone1A = new List<object>();
            List<object> Stone1B = new List<object>();
            List<object> Stone2 = new List<object>();
            List<object> Stone3 = new List<object>();
            List<object> Stone4 = new List<object>();
            List<object> Stone5 = new List<object>();
            object DataStone;

            string query = "exec sp_getDataStone 'i', 'DJ', '" + Nomor + "'";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    if(row["StoneType"].ToString() == "1A")
                    {
                        Stone1A.Add(new
                        {
                            ShapeName = row["ShapeName"].ToString(),
                            Shape = row["Shape"].ToString(),
                            Color = row["Color"].ToString(),
                            Clarity = row["Clarity"].ToString(),
                            GIA = row["GIA"].ToString(),
                            LinkGIA = row["LinkGIA"].ToString(),
                            Sarin = row["Sarin"].ToString(),
                            GradeSarin = row["GradeSarin"].ToString(),
                            LinkSarin = row["LinkSarin"].ToString(),
                            TotalButir = Convert.ToDecimal(row["TotalButir"]),
                            CaratButir = Convert.ToDecimal(row["CaratButir"]),
                            TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        });
                    }
                    else if (row["StoneType"].ToString() == "1B")
                    {
                        Stone1B.Add(new
                        {
                            ShapeName = row["ShapeName"].ToString(),
                            Shape = row["Shape"].ToString(),
                            Color = row["Color"].ToString(),
                            Clarity = row["Clarity"].ToString(),
                            GIA = row["GIA"].ToString(),
                            LinkGIA = row["LinkGIA"].ToString(),
                            Sarin = row["Sarin"].ToString(),
                            GradeSarin = row["GradeSarin"].ToString(),
                            LinkSarin = row["LinkSarin"].ToString(),
                            TotalButir = Convert.ToDecimal(row["TotalButir"]),
                            CaratButir = Convert.ToDecimal(row["CaratButir"]),
                            TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        });
                    }
                    else if (row["StoneType"].ToString() == "2")
                    {
                        Stone2.Add(new
                        {
                            ShapeName = row["ShapeName"].ToString(),
                            Shape = row["Shape"].ToString(),
                            Color = row["Color"].ToString(),
                            Clarity = row["Clarity"].ToString(),
                            GIA = row["GIA"].ToString(),
                            LinkGIA = row["LinkGIA"].ToString(),
                            Sarin = row["Sarin"].ToString(),
                            GradeSarin = row["GradeSarin"].ToString(),
                            LinkSarin = row["LinkSarin"].ToString(),
                            TotalButir = Convert.ToDecimal(row["TotalButir"]),
                            CaratButir = Convert.ToDecimal(row["CaratButir"]),
                            TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        });
                    }
                    else if (row["StoneType"].ToString() == "3")
                    {
                        Stone3.Add(new
                        {
                            ShapeName = row["ShapeName"].ToString(),
                            Shape = row["Shape"].ToString(),
                            Color = row["Color"].ToString(),
                            Clarity = row["Clarity"].ToString(),
                            GIA = row["GIA"].ToString(),
                            LinkGIA = row["LinkGIA"].ToString(),
                            Sarin = row["Sarin"].ToString(),
                            GradeSarin = row["GradeSarin"].ToString(),
                            LinkSarin = row["LinkSarin"].ToString(),
                            TotalButir = Convert.ToDecimal(row["TotalButir"]),
                            CaratButir = Convert.ToDecimal(row["CaratButir"]),
                            TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        });
                    }
                    else if (row["StoneType"].ToString() == "4")
                    {
                        Stone4.Add(new
                        {
                            ShapeName = row["ShapeName"].ToString(),
                            Shape = row["Shape"].ToString(),
                            Color = row["Color"].ToString(),
                            Clarity = row["Clarity"].ToString(),
                            GIA = row["GIA"].ToString(),
                            LinkGIA = row["LinkGIA"].ToString(),
                            Sarin = row["Sarin"].ToString(),
                            GradeSarin = row["GradeSarin"].ToString(),
                            LinkSarin = row["LinkSarin"].ToString(),
                            TotalButir = Convert.ToDecimal(row["TotalButir"]),
                            CaratButir = Convert.ToDecimal(row["CaratButir"]),
                            TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        });
                    }
                    else if (row["StoneType"].ToString() == "5")
                    {
                        Stone5.Add(new
                        {
                            ShapeName = row["ShapeName"].ToString(),
                            Shape = row["Shape"].ToString(),
                            Color = row["Color"].ToString(),
                            Clarity = row["Clarity"].ToString(),
                            GIA = row["GIA"].ToString(),
                            LinkGIA = row["LinkGIA"].ToString(),
                            Sarin = row["Sarin"].ToString(),
                            GradeSarin = row["GradeSarin"].ToString(),
                            LinkSarin = row["LinkSarin"].ToString(),
                            TotalButir = Convert.ToDecimal(row["TotalButir"]),
                            CaratButir = Convert.ToDecimal(row["CaratButir"]),
                            TotalCarat = Convert.ToDecimal(row["TotalCarat"]),
                        });
                    }
                    
                }
            }

            DataStone = new
            {
                Stone1A = Stone1A,
                Stone1B = Stone1B,
                Stone2 = Stone2,
                Stone3 = Stone3,
                Stone4 = Stone4,
                Stone5 = Stone5
            };
            return DataStone;
        }

        private string CheckingImage (string Img, string KodeBarang, string Type)
        {
            if(!System.IO.File.Exists(Img))
            {
                if (Type == "DJ")
                {
                    var data = (from a in _context.StockProductDjs.Where(p => p.ProtoNomor.Contains(KodeBarang))
                                group a by a.ImgPicture into b
                                select new { b.Key }).ToList();
                    foreach (var x in data)
                    {
                        if (System.IO.File.Exists(x.Key))
                        {
                            Img = x.Key;
                            break;
                        }
                    }
                }
                else if (Type == "PG")
                {
                    var data = (from a in _context.StockProductPgs.Where(p => p.KodeBarang.Equals(KodeBarang))
                                group a by a.ImgPicture into b
                                select new { b.Key }).ToList();
                    foreach (var x in data)
                    {
                        if (System.IO.File.Exists(x.Key))
                        {
                            Img = x.Key;
                            break;
                        }
                    }
                }
            }
            return common.Image(Img);
        }
    }
}
