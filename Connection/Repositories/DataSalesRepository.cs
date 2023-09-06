using Connection.Interface;
using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Connection.Settings;

namespace Connection.Repositories
{
    public class DataSalesRepository : IDataSalesRepository
    {
        private readonly JAWSDbContext _context;
        private readonly OpenConnection _openConnection;
        private ConnectionString _connectionStrings;

        public DataSalesRepository()
        {
            _context = new JAWSDbContext();
            _openConnection = new OpenConnection();
            _connectionStrings = new ConnectionString();
        }

        public object GetDataSalesByID(int id)
        {
            var datasales = _context.DataSales.SingleOrDefault(p => p.Id == id);
            if (datasales != null)
            {
                return new
                {
                    message = "",
                    data = new
                    {
                        id = datasales.Id,
                        nama = datasales.Nama,
                        keterangan = datasales.Keterangan,
                        tgl = datasales.Tgl.ToString("dd-MM-yyyy"),
                        status = (datasales.Draft) ? "draft" : (datasales.Disable) ? "disabled" : "active",
                        store = datasales.DataSalesGroup.NamaKode
                    }
                };
            }
            else
            {
                return new { message = "" };
            }
        }

        public object GetDataSalesByKeyword(string keyword, string kode)
        {
            var datasales = _context.DataSales.Include(p => p.DataSalesGroup)
                .Where(p => (p.DataSalesGroup.NamaKode.Contains(keyword) || p.Nama.Contains(keyword) || p.Keterangan.Contains(keyword)) && p.Disable == false && p.Draft == false && p.DataSalesGroup.NamaKode.Contains(kode));

            List<object> result = new List<object>();
            foreach (var item in datasales)
            {
                result.Add(new
                {
                    id = item.Id,
                    name = item.Nama,
                    keterangan = item.Keterangan,
                    tgl = item.Tgl.ToString("dd-MM-yyyy"),
                    status = (item.Draft) ? "draft" : (item.Disable) ? "disabled" : "active",
                    store = item.DataSalesGroup.Nama
                });
            }
            return result;
        }

        public object GetDataSalesByStore(int idlokasi, int tipelokasi)
        {
            string kode = "";
            if (tipelokasi == 1)
                kode = _context.LocOutlets.SingleOrDefault(p => p.Id == idlokasi).Kode;
            else
                kode = _context.LocExhibitions.SingleOrDefault(p => p.Id == idlokasi).Kode;
            var datasales = _context.DataSales
                .Include(p => p.DataSalesGroup)
                .Where(p => p.DataSalesGroup.NamaKode == kode && p.Disable == false && p.Draft == false);
            
            List<object> result = new List<object>();
            foreach(var item in datasales)
            {
                result.Add(new 
                { 
                    id = item.Id,
                    name = item.Nama,
                    keterangan = item.Keterangan,
                    tgl = item.Tgl.ToString("dd-MM-yyyy"),
                    status = (item.Draft) ? "draft" : (item.Disable) ? "disabled" : "active",
                    store = (item.DataSalesGroup == null) ? "-" : item.DataSalesGroup.NamaKode
                });
            }
            return result;
        }

        public object GetDataSalesCrossBrandByStore(string brand, string locationcode, string keyword = "")
        {
            string query = "EXEC sp_get_data_sales_cross_brand_new '" + brand + "','" + locationcode + "','" + keyword + "'";
            DataTable datasales = _openConnection.Rs(query, _connectionStrings.ConnectionStrings.Cnn_DB);
            List<object> result = new List<object>();
            foreach (DataRow item in datasales.Rows)
            {
                result.Add(new
                {
                    id = item["ID"],
                    name = item["NAMA"],
                    keterangan = item["KETERANGAN"],
                    lokasi = item["NAMA_LOCATION"],
                    kode_lokasi = item["KODE_LOCATION"],
                    brand = item["BRAND"],
                    kode_brand = item["KODE_BRAND"]
                });
            }
            return result;
        }
    }
}
