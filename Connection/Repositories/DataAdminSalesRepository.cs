using Connection.Interface;
using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Connection.Repositories
{
    public class DataAdminSalesRepository : IDataAdminSalesRepository
    {
        private readonly JAWSDbContext _context;

        public DataAdminSalesRepository()
        {
            _context = new JAWSDbContext();
        }

        public object GetDataAdminSalesByKeyword(string keyword)
        {
            var dataadminsales = _context.DataAdminSales.Where(p => (p.Nama + p.Keterangan).Contains(keyword));
            List<object> result = new List<object>();
            foreach (var item in dataadminsales)
            {
                string kode = "";
                if (item.TipeLokasi == 1)
                    kode = _context.LocOutlets.SingleOrDefault(p => p.Id == item.Idlokasi).Kode;
                else
                    kode = _context.LocExhibitions.SingleOrDefault(p => p.Id == item.Idlokasi).Kode;
                result.Add(new
                {
                    id = item.Id,
                    name = item.Nama,
                    keterangan = item.Keterangan,
                    tgl = item.Tgl.ToString("dd-MM-yyyy"),
                    status = (item.Draft) ? "draft" : (item.Disable) ? "disabled" : "active",
                    store = kode
                });
            }
            return result;
        }

        public object GetDataAdminSalesByID(int id)
        {
            var dataadminsales = _context.DataAdminSales.SingleOrDefault(p => p.Id == id);
            string kode = "";
            if (dataadminsales != null)
            {
                if (dataadminsales.TipeLokasi == 1)
                    kode = _context.LocOutlets.SingleOrDefault(p => p.Id == dataadminsales.Idlokasi).Kode;
                else
                    kode = _context.LocExhibitions.SingleOrDefault(p => p.Id == dataadminsales.Idlokasi).Kode;

                return new
                {
                    message = "", 
                    data = new
                    {
                        id = dataadminsales.Id,
                        nama = dataadminsales.Nama,
                        keterangan = dataadminsales.Keterangan,
                        tgl = dataadminsales.Tgl.ToString("dd-MM-yyyy"),
                        status = (dataadminsales.Draft) ? "draft" : (dataadminsales.Disable) ? "disabled" : "active",
                        store = kode
                    }
                };
            }
            else
            {
                return new { message = "Failed. Data Not Found." };
            }
        }

        public object GetDataAdminSalesByStore(int idlokasi, int tipelokasi)
        {
            var dataadminsales = _context.DataAdminSales.Where(p => p.Idlokasi == idlokasi && p.TipeLokasi == tipelokasi);
            List<object> result = new List<object>();
            foreach (var item in dataadminsales)
            {
                string kode = "";
                if (item.TipeLokasi == 1)
                    kode = _context.LocOutlets.SingleOrDefault(p => p.Id == item.Idlokasi).Kode;
                else
                    kode = _context.LocExhibitions.SingleOrDefault(p => p.Id == item.Idlokasi).Kode;
                result.Add(new
                {
                    id = item.Id,
                    name = item.Nama,
                    keterangan = item.Keterangan,
                    tgl = item.Tgl.ToString("dd-MM-yyyy"),
                    status = (item.Draft) ? "draft" : (item.Disable) ? "disabled" : "active",
                    store = kode
                });
            }
            return result;
        }

        public List<object> GetDataAdminSalesByUserID(int UserID)
        {
            var dataadminsales = _context.DataAdminSales.Where(p => p.Iduser == UserID && p.Disable == false && p.Draft == false).ToList();
            string kode = "";
            string store = "";
            List<Object> datas = new List<object>();
            if (dataadminsales == null || dataadminsales.Count() == 0)
            {
                dataadminsales = _context.DataAdminSales.Where(p => p.Disable == false && p.Draft == false).ToList();
            }
            foreach (DataAdminSale n in dataadminsales)
            {
                if (n.TipeLokasi == 1)
                {
                    if (!_context.LocOutlets.Any(p => p.Id == n.Idlokasi && p.CompanyBrand.Disable == false && p.CompanyBrand.Draft == false)) continue;

                    kode = _context.LocOutlets.SingleOrDefault(p => p.Id == n.Idlokasi).Kode;
                    store = _context.LocOutlets.SingleOrDefault(p => p.Id == n.Idlokasi).Nama;
                }
                else
                {
                    if (!_context.LocExhibitions.Any(p => p.Id == n.Idlokasi && p.CompanyBrand.Disable == false && p.CompanyBrand.Draft == false)) continue;

                    kode = _context.LocExhibitions.SingleOrDefault(p => p.Id == n.Idlokasi).Kode;
                    store = _context.LocExhibitions.SingleOrDefault(p => p.Id == n.Idlokasi).Nama;
                }

                datas.Add(new
                {
                    id = n.Id,
                    nama = n.Nama,
                    keterangan = n.Keterangan,
                    tgl = n.Tgl.ToString("dd-MM-yyyy"),
                    status = (n.Draft) ? "draft" : (n.Disable) ? "disabled" : "active",
                    kodestore = kode,
                    store = store
                });
            }
            return datas;
        }
    }
}
