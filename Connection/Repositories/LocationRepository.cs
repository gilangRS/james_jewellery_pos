using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Connection.Interface;
using Connection.Models;
using Connection.RequestModels.PointOfSales;
using Connection.Settings;

namespace Connection.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;

        public LocationRepository()
        {
            _context = new JAWSDbContext();
            this.connectionStrings = new ConnectionString();
        }
        public DataAdminSale GetStoreLocation(int UserID)
        {
            return _context.DataAdminSales.Single(p => p.Iduser == UserID && p.Draft == true && p.Disable == false);
        }

        #region Warehouse
        public List<LocWarehouse> GetLocWarehouses()
        {
            return _context.LocWarehouses.Where(p => p.Disable == false && p.CompanyBrand.Draft == false && p.CompanyBrand.Disable == false).ToList();
        }
        public List<LocWarehouse> GetLocWarehouses(int ID)
        {
            return _context.LocWarehouses.Where(p => p.Disable == false && p.CompanyBrand.Draft == false && p.CompanyBrand.Disable == false && p.Id.Equals(ID)).ToList();
        }
        #endregion
        #region Outlet
        public List<LocOutlet> GetLocOutlets()
        {
            return _context.LocOutlets.Where(p => p.Disable == false && p.CompanyBrand.Draft == false && p.CompanyBrand.Disable == false).ToList();
        }

        public List<LocOutlet> GetLocOutlets(string code)
        {
            return _context.LocOutlets.Where(p => p.Disable == false && p.CompanyBrand.Draft == false && p.CompanyBrand.Disable == false && p.Kode.Equals(code)).ToList();
        }
        public List<LocOutlet> GetLocOutlets(int ID)
        {
            return _context.LocOutlets.Where(p => p.Disable == false && p.CompanyBrand.Draft == false && p.CompanyBrand.Disable == false && p.Id.Equals(ID)).ToList();
        }
        #endregion
        #region Exhibition
        public List<LocExhibition> GetLocExhibitions()
        {
            return _context.LocExhibitions.Where(p => p.Disable == false && p.CompanyBrand.Draft == false && p.CompanyBrand.Disable == false).ToList();
        }
        public List<LocExhibition> GetLocExhibitions(string code)
        {
            return _context.LocExhibitions.Where(p => p.Disable == false && p.CompanyBrand.Draft == false && p.CompanyBrand.Disable == false && p.Kode.Equals(code)).ToList();
        }
        public List<LocExhibition> GetLocExhibitions(int ID)
        {
            return _context.LocExhibitions.Where(p => p.Disable == false && p.CompanyBrand.Draft == false && p.CompanyBrand.Disable == false && p.Id.Equals(ID)).ToList();
        }
        #endregion

        public List<object> SalesLocationByLogin(int UserID, int isSO)
        {
            var dataadminsales = _context.DataAdminSales.Where(p => p.IdNew == UserID && p.Disable == false && p.Draft == false).ToList();
            List<Object> datas = new List<object>();
            if (dataadminsales == null || dataadminsales.Count() == 0)
            {
                if (isSO == 0)
                {
                    var warehouse = (from p in _context.LocWarehouses.Where(q => q.Disable == false && q.Draft == false && q.CompanyBrand.Draft == false && q.CompanyBrand.Disable == false).ToList()
                                     select new
                                     {
                                         tipelokasi = 0,
                                         idlokasi = p.Id,
                                         namalokasi = p.Nama,
                                         kode = ""
                                     }).ToList();

                    datas.AddRange(warehouse);
                }
                var outlet = (from p in _context.LocOutlets.Where(q => q.Disable == false && q.Draft == false && q.CompanyBrand.Draft == false && q.CompanyBrand.Disable == false).ToList()
                             select new
                             {
                                 tipelokasi = 1,
                                 idlokasi = p.Id,
                                 namalokasi = p.Nama,
                                 kode = p.Kode
                             }).ToList();
                var exhibition = (from p in _context.LocExhibitions.Where(q => q.Disable == false && q.Draft == false && q.CompanyBrand.Draft == false && q.CompanyBrand.Disable == false).ToList()
                                 select new
                                 {
                                     tipelokasi = 2,
                                     idlokasi = p.Id,
                                     namalokasi = p.Nama,
                                     kode = p.Kode
                                 }).ToList();
                datas.AddRange(outlet);
                datas.AddRange(exhibition);
            }
            else
            {
                foreach (DataAdminSale n in dataadminsales)
                {
                    if (n.TipeLokasi == 1)
                    {
                        var location = (from p in _context.LocOutlets.Where(q => q.Disable == false && q.Draft == false && q.CompanyBrand.Draft == false && q.CompanyBrand.Disable == false && q.Id == n.Idlokasi).ToList()
                                        select new
                                        {
                                            tipelokasi = 1,
                                            idlokasi = p.Id,
                                            namalokasi = p.Nama,
                                            kode = p.Kode
                                        }).ToList();

                        datas.AddRange(location);
                    }
                    else
                    {
                        var location = (from p in _context.LocExhibitions.Where(q => q.Disable == false && q.Draft == false && q.CompanyBrand.Draft == false && q.CompanyBrand.Disable == false && q.Id == n.Idlokasi).ToList()
                                        select new
                                        {
                                            tipelokasi = 2,
                                            idlokasi = p.Id,
                                            namalokasi = p.Nama,
                                            kode = p.Kode
                                        }).ToList();

                        datas.AddRange(location);
                    }
                }
            }
            return datas;

        }

        public List<object> GetLocationAllBrand(int Brand, int Tipe, int Location)
        {
            List<object> data = new List<object>();

            string query = "exec sp_getLocationAllBrand "
                + Brand + ", "
                + Tipe + ", "
                + Location;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    data.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Tipe = Convert.ToInt32(row["Type"]),
                        NamaLokasi = row["Nama"].ToString(),
                        Kode = row["Kode"].ToString()
                    });
                }
            }

            return data;
        }

        public RequestLocation GetDataLocation(int Brand, int Tipe, int Location)
        {
            RequestLocation location = new RequestLocation();

            string query = "exec sp_getLocationAllBrand "
                + Brand + ", "
                + Tipe + ", "
                + Location;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    location.ID = Convert.ToInt32(row["ID"]);
                    location.IDBrand = Convert.ToInt32(row["IDBrand"]);
                    location.NamaLokasi = row["Nama"].ToString();
                }
            }
            return location;
        }
    }
}
