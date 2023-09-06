using Connection.Interface;
using Connection.Models;
using Connection.RequestModels.PCS;
using Connection.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Connection.Repositories
{
    public class SouvenirRepository : ISouvenirRepository
    {
        private readonly JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;
        private Common common = new Common();
        public SouvenirRepository()
        {
            _context = new JAWSDbContext();
            this.connectionStrings = new ConnectionString();
        }

        public List<object> GetStockSouvenirSummary(int Tipelokasi, int IDLokasi, int Souvenir, string From, string To, int Groupby, bool IsStore, string NIK)
        {
            List<object> datas = new List<object>();
            string query = "exec sp_summary_souvenir "
                + Tipelokasi + ", '"
                + From + "', '"
                + To + "', "
                + IDLokasi + ", "
                + Souvenir + ", "
                + Groupby + ", '"
                + NIK + "', "
                + IsStore;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                List<object> Temp = new List<object>();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Description"].ToString() == "Total")
                    {
                        Temp.Add(new
                        {
                            Description = row["Description"].ToString(),
                            Kode = row["Kode"].ToString(),
                            StockAwal = Convert.ToInt32(row["Stock"]),
                            Incoming = Convert.ToInt32(row["Incoming"]),
                            Outgoing = Convert.ToInt32(row["Outgoing"]),
                            Receiving = Convert.ToInt32(row["Receiving"]),
                            Sales = Convert.ToInt32(row["Sales"]),
                            Ongoing = Convert.ToInt32(row["Ongoing"]),
                            StockAkhir = Convert.ToInt32(row["StockReal"]),
                            Harga = IsStore ? 0 : Convert.ToDecimal(row["Harga"])
                        });
                        continue;
                    }
                    datas.Add(new
                    {
                        Description = row["Description"].ToString(),
                        Kode = row["Kode"].ToString(),
                        StockAwal = Convert.ToInt32(row["Stock"]),
                        Incoming = Convert.ToInt32(row["Incoming"]),
                        Outgoing = Convert.ToInt32(row["Outgoing"]),
                        Receiving = Convert.ToInt32(row["Receiving"]),
                        Sales = Convert.ToInt32(row["Sales"]),
                        Ongoing = Convert.ToInt32(row["Ongoing"]),
                        StockAkhir = Convert.ToInt32(row["StockReal"]),
                        Harga = IsStore ? 0 : Convert.ToDecimal(row["Harga"])
                    });
                }

                datas.Add(Temp[0]);
            }

            return datas;
        }

        public List<object> GetStockSouvenirActual(int Tipelokasi, int IDLokasi, int Souvenir)
        {
            List<object> datas = new List<object>();
            List<AllLocation> location = new List<AllLocation>();

            string query = "exec sp_getLocationAll";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    location.Add(new AllLocation
                    {
                        IDLokasi = Convert.ToInt32(row["IDLokasi"]),
                        TipeLokasi = Convert.ToInt32(row["Tipelokasi"]),
                        Nama = row["Nama"].ToString()
                    });
                }
            }

            var actual = _context.StockActualSouvenirs
                    .Include(p => p.Souvenir)
                    .Where(p => (p.TipeLokasi == Tipelokasi || (p.TipeLokasi >= 0 && Tipelokasi == 9))
                    && (p.Idlokasi == IDLokasi || (p.Idlokasi > 0 && IDLokasi == 0))
                    && (p.Idproduct == Souvenir || (p.Idproduct > 0 && Souvenir == 0))
                    && p.Souvenir.Disable == false && p.Souvenir.Draft == false).ToList();

            datas = (from a in actual
                    join b in location on a.TipeLokasi equals b.TipeLokasi
                    where a.Idlokasi == b.IDLokasi && a.TipeLokasi == b.TipeLokasi
                    select new
                    {
                        Souvenir = a.Souvenir.Nama,
                        Kode = a.Souvenir.Kode,
                        Inhand = a.InHand,
                        InTransit = a.InTransit.HasValue ? a.InTransit : 0,
                        Damaged = a.Damaged.HasValue ? a.Damaged : 0,
                        Lokasi = location.Single(p => p.IDLokasi == a.Idlokasi && p.TipeLokasi == a.TipeLokasi).Nama

                    }).ToList<object>();
        

            return datas;
        }

        public List<object> GetSouvenir()
        {
            List<object> datas = new List<object>();
            datas = (from a in _context.Souvenirs.Where(p => p.Disable == false && p.Draft == false)
                     select new
                     {
                         ID = a.Id,
                         Nama = a.Nama,
                         Kode = a.Kode
                     }).ToList<object>();

            return datas;
        }

        public object GetDetailSouvenir(int ID)
        {
            object datas = (from a in _context.Souvenirs.Where(p => p.Id == ID)
                            select new
                            {
                                ID = a.Id,
                                Nama = a.Nama,
                                Kode = a.Kode,
                                Satuan = a.Satuan,
                                Ketarangan = a.Keterangan,
                                Disable = a.Disable,
                                Harga = a.Harga,
                                Image = a.ImgPicture == null ? common.Image("") : common.Image(a.ImgPicture)
                            }).SingleOrDefault();

            return datas;
        }

        public List<object> GetListSouvenir(string Keyword, int Status)
        {
            List<object> datas = new List<object>();
            datas = (from a in _context.Souvenirs.Where(p => p.Draft == false && ((Status > 0 && p.Disable == GetStatus(Status)) || Status == 0) && (p.Nama.Contains(Keyword) || p.Kode.Contains(Keyword)))
                     select new
                     {
                         ID = a.Id,
                         Nama = a.Nama,
                         Kode = a.Kode,
                         Satuan = a.Satuan,
                         Disable = a.Disable,
                         Harga = a.Harga
                     }).ToList<object>();

            return datas;
        }

        public void InsertSouvenir(PCS data)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    Souvenir product = new Souvenir();

                    string extension = string.Empty;

                    product.Nama = data.Nama;
                    product.Kode = data.Kode;
                    product.Keterangan = data.Keterangan == null ? "" : data.Keterangan;
                    product.Satuan = data.Satuan;
                    product.Tgl = DateTime.Now;
                    product.Idbrand = connectionStrings.AppConfig.Brand;
                    product.Disable = data.Disable;
                    product.Draft = false;
                    product.ImgPicture = connectionStrings.AppConfig.DirSouvenir + data.Kode + extension;
                    product.Harga = data.Harga;

                    string filename = data.Kode;

                    if (data.files != null) common.UploadImage(data.files, connectionStrings.AppConfig.DirSouvenir, ref filename);

                    product.ImgPicture = filename;

                    _context.Souvenirs.Add(product);
                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void UpdateSouvenir(PCS data, string UserName)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    var product = _context.Souvenirs.SingleOrDefault(p => p.Id == data.ID);

                    product.Nama = data.Nama;
                    product.Kode = data.Kode;
                    product.Keterangan = data.Keterangan == null ? "" : data.Keterangan;
                    product.Satuan = data.Satuan;
                    product.Idbrand = connectionStrings.AppConfig.Brand;
                    product.Disable = data.Disable;
                    if (product.Harga != data.Harga)
                    {
                        SouvenirPriceLog log = new();

                        log.IDForm = product.Id;
                        log.HargaLama = product.Harga.HasValue ? product.Harga.Value : 0;
                        log.HargaBaru = data.Harga;
                        log.Kode = data.Kode;
                        log.Operator = UserName;
                        log.OperatorTgl = DateTime.Now;

                        _context.SouvenirPricingLogs.Add(log);
                    }
                    product.Harga = data.Harga;

                    if (data.files != null)
                    {
                        try
                        {
                            if (File.Exists(Path.GetFullPath(product.ImgPicture))) File.Delete(Path.GetFullPath(product.ImgPicture));
                        }
                        catch { }
                        string filename = data.Kode;

                        common.UploadImage(data.files, connectionStrings.AppConfig.DirSouvenir, ref filename);

                        product.ImgPicture = filename;
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        #region Receive
        public object GetReceiveSouvenir(int IDLokasi, string From, string To, bool IsApproval)
        {
            List<object> datas = new();

            string query = "exec sp_ReceivedSouvenir " +
                IDLokasi + ", " +
                "'" + From + "', " +
                "'" + To + "'";

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        NoDO = row["NoDO"].ToString(),
                        NoPO = row["NoPO"].ToString(),
                        Tgl = Convert.ToDateTime(row["Tgl"]).ToString("D"),
                        Item = Convert.ToInt32(row["Item"]),
                        Operator = row["Operator"].ToString(),
                        OperatorTgl = Convert.ToDateTime(row["OperatorTgl"]).ToString("D"),
                        Approval = row["Approval"].ToString(),
                        ApprovalTgl = Convert.ToDateTime(row["ApprovalTgl"]).ToString("D"),
                        AllowedApprove = string.IsNullOrEmpty(row["Approval"].ToString()) && !IsApproval ? false : true
                    });
                }
            }

            return datas;
        }

        public object GetDetailReceiveSouvenir(int ID, int IDLokasi, int IDProduct, string From, string To, int IsSummary, bool IsApproval)
        {
            From = String.IsNullOrEmpty(From) ? "1900-01-01" : From;
            To = String.IsNullOrEmpty(To) ? "1900-01-01" : To;

            var data = _context.StockReceiveSouvenirs.Include(p => p.LocWarehouse).Include(p => p.StockReceiveSouvenir_Products).ThenInclude(p => p.Souvenir)
                           .Where(p => (p.Id == ID)
                           || (p.LocWarehouse.Id == IDLokasi && p.Tgl >= Convert.ToDateTime(From) && p.Tgl < Convert.ToDateTime(To).AddDays(1)
                           && (p.StatusReceive == Convert.ToBoolean(IsSummary) || (IsSummary == 0 && p.Id >= 0))
                           && (p.StockReceiveSouvenir_Products.Any(q => q.Idproduct == IDProduct) || (IDProduct == 0))));

            List<object> datas = new();

            foreach (var x in data)
            {
                datas.Add(new
                {
                    ID = x.Id,
                    NoDo = x.NoDo,
                    NoPo = x.NoPo,
                    Location = x.LocWarehouse.Nama,
                    Tgl = x.Tgl,
                    StatusReceive = x.StatusReceive,
                    Operator = x.Operator,
                    OperatorTgl = x.OperatorTgl.ToString("D"),
                    Approval = x.Approval,
                    ApprovalTgl = x.ApprovalTgl.HasValue ? x.ApprovalTgl.Value.ToString("D") : null,
                    AllowedApprove = string.IsNullOrEmpty(x.Approval) && IsApproval ? true : false,
                    Detail = (from a in x.StockReceiveSouvenir_Products
                              select new
                              {
                                  ID = a.Idproduct,
                                  Nama = a.Souvenir.Nama,
                                  Kode = a.Souvenir.Kode,
                                  Qty = a.Qty,
                                  Receieved = a.Received.HasValue ? a.Received : 0,
                                  Damaged = a.Damaged.HasValue ? a.Damaged : 0,
                                  NeverArrived = a.NeverArrived.HasValue ? a.NeverArrived : 0,
                              })
                });
            }
            return datas;
        }

        private object GetReceiveProductSouvenir(int ID)
        {
            object datas = (from a in _context.StockReceiveSouvenirProducts.Include(p => p.Souvenir).Where(p => p.Idform == ID)
                            select new
                            {
                                Nama = a.Souvenir.Nama,
                                Kode = a.Souvenir.Kode,
                                Qty = a.Qty,
                                Receieved = a.Received.HasValue ? a.Received : 0,
                                Damaged = a.Damaged.HasValue ? a.Damaged : 0,
                                NeverArrived = a.NeverArrived.HasValue ? a.NeverArrived : 0,
                            });

            return datas;
        }

        public void InsertReceivingSouvenir(ReceivePCS Data, string UserName)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockReceiveSouvenir receive = new StockReceiveSouvenir();

                    receive.NoDo = Data.NoDo;
                    receive.NoPo = Data.NoPO;
                    receive.Keterangan = Data.Keterangan;
                    receive.Idwarehouse = Data.IDWarehouse;
                    receive.Operator = UserName;
                    receive.OperatorTgl = DateTime.Now;
                    receive.Draft = false;
                    receive.Tgl = Convert.ToDateTime(Data.Tgl);
                    receive.TglInput = DateTime.Now;
                    receive.StatusReceive = false;

                    _context.StockReceiveSouvenirs.Add(receive);
                    _context.SaveChanges();

                    foreach (PCS x in Data.Product)
                    {
                        StockReceiveSouvenir_Product product = new StockReceiveSouvenir_Product();
                        product.Idform = receive.Id;
                        product.Idproduct = x.ID;
                        product.Qty = x.Qty;
                        product.Harga = 0;

                        _context.StockReceiveSouvenirProducts.Add(product);
                    }


                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void ApproveReceivingSouvenir(ReceivePCS Data, string UserName)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    StockReceiveSouvenir receive = _context.StockReceiveSouvenirs.SingleOrDefault(p => p.Id == Data.ID);
                    receive.Approval = UserName;
                    receive.ApprovalTgl = DateTime.Now;
                    receive.StatusReceive = true;

                    foreach (PCS x in Data.Product)
                    {
                        StockReceiveSouvenir_Product product = _context.StockReceiveSouvenirProducts.Include(p => p.Souvenir).SingleOrDefault(p => p.Idform == Data.ID && p.Idproduct == x.ID);

                        product.Received = x.Received;
                        product.Damaged = x.Damaged;
                        product.NeverArrived = x.NeverArrived;

                        if (_context.StockActualSouvenirs.Any(p => p.TipeLokasi == 0 && p.Idlokasi == receive.Idwarehouse && p.Idproduct == x.ID))
                        {
                            StockActualSouvenir actual = _context.StockActualSouvenirs.SingleOrDefault(p => p.TipeLokasi == 0 && p.Idlokasi == receive.Idwarehouse && p.Idproduct == x.ID);

                            actual.InHand += x.Received;
                        }
                        else
                        {
                            StockActualSouvenir actual = new StockActualSouvenir();

                            actual.Idlokasi = receive.Idwarehouse;
                            actual.TipeLokasi = 0;
                            actual.Idproduct = x.ID;
                            actual.Nomor = product.Souvenir.Kode;
                            actual.NamaLokasi = _context.LocWarehouses.SingleOrDefault(p => p.Id == receive.Idwarehouse).Nama;
                            actual.Substorage = 1;
                            actual.Keterangan = "";
                            actual.InHand = x.Received;
                            actual.Damaged = x.Damaged;
                            actual.NeverArrived = 0;
                            actual.InTransit = 0;
                            actual.Operator = UserName;
                            actual.OperatorTgl = DateTime.Now;
                            actual.Tgl = DateTime.Now;

                            _context.StockActualSouvenirs.Add(actual);
                        }
                    }

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void DeleteReceivingSouvenir(int ID)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    List<StockReceiveSouvenir_Product> products = _context.StockReceiveSouvenirProducts.Where(p => p.Idform == ID).ToList();
                    _context.StockReceiveSouvenirProducts.RemoveRange(products);

                    StockReceiveSouvenir receive = _context.StockReceiveSouvenirs.SingleOrDefault(p => p.Id == ID);
                    _context.StockReceiveSouvenirs.Remove(receive);

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }

        public void DeleteReceivedSouvenir(int ID)
        {
            using (var tempContext = _context.Database.BeginTransaction())
            {
                try
                {
                    List<StockReceiveSouvenir_Product> products = _context.StockReceiveSouvenirProducts.Where(p => p.Idform == ID).ToList();
                    StockReceiveSouvenir receive = _context.StockReceiveSouvenirs.SingleOrDefault(p => p.Id == ID);

                    foreach (StockReceiveSouvenir_Product x in products)
                    {
                        StockActualSouvenir actual = _context.StockActualSouvenirs.SingleOrDefault(p => p.TipeLokasi == 0 && p.Idlokasi == receive.Idwarehouse && p.Idproduct == x.Idproduct);

                        actual.InHand -= Convert.ToInt32(x.Received);
                    }
                    _context.StockReceiveSouvenirProducts.RemoveRange(products);
                    _context.StockReceiveSouvenirs.Remove(receive);

                    _context.SaveChanges();
                    tempContext.Commit();
                }
                catch
                {
                    tempContext.Rollback();
                    connection.Execute("exec sp_ThrowError 'Terjadi kesalahan, silahkan hubungi team IT'", connectionStrings.ConnectionStrings.Cnn_DB);
                }
            }
        }
        #endregion

        public object GetPemakaianSouvenir(int Tipelokasi, int IDLokasi, int Souvenir, string From, string To, string Keyword = "")
        {
            List<object> datas = new();
            Keyword = String.IsNullOrEmpty(Keyword) ? "" : Keyword;

            var data = _context.SalesOrders.Include(p => p.SalesOrderSouvenirs)
                .ThenInclude(p => p.Souvenir)
                .Where(p => p.Nomor.Contains(Keyword) && p.Tgl >= Convert.ToDateTime(From) && p.Tgl < Convert.ToDateTime(To).AddDays(1)
                && p.StatusPembayaran == true && p.StatusVoid == false && p.Draft == false
                && (p.TipeLokasi == Tipelokasi || (Tipelokasi == 0 && p.TipeLokasi > 0))
                && (p.Idlokasi == IDLokasi || (IDLokasi == 0 && p.Idlokasi > 0))
                && p.SalesOrderSouvenirs.Any(q => q.Idproduct == Souvenir || (Souvenir == 0 && q.Idproduct > 0)));

            var Outlet = (from a in _context.LocOutlets
                          select new
                          {
                              TipeLokasi = 1,
                              ID = a.Id,
                              Lokasi = a.Nama
                          }).ToList();
            var Exhibition = (from a in _context.LocExhibitions
                              select new
                              {
                                  TipeLokasi = 2,
                                  ID = a.Id,
                                  Lokasi = a.Nama
                              }).ToList();

            foreach (var x in data)
            {
                string Lokasi = string.Empty;
                if (x.TipeLokasi == 1) Lokasi = Outlet.Single(p => p.ID == x.Idlokasi).Lokasi;
                else if (x.TipeLokasi == 2) Lokasi = Exhibition.Single(p => p.ID == x.Idlokasi).Lokasi;

                datas.Add(new
                {
                    Nomor = x.Nomor,
                    Tgl = x.Tgl.Value.ToString("D"),
                    NamaCustomer = x.CustomerNama,
                    NamaSales = x.SalesNama,
                    Lokasi = Lokasi,
                    Detail = (from a in x.SalesOrderSouvenirs
                              where (a.Idproduct == Souvenir || (Souvenir == 0 && a.Idproduct > 0))
                              select new
                              {
                                  Invoice = a.Invoice,
                                  Product = a.Souvenir.Nama,
                                  Kode = a.Souvenir.Kode,
                                  Qty = a.Qty,
                                  Harga = a.TotalModalRupiah / a.Qty,
                                  HargaTotal = a.TotalModalRupiah
                              })
                });
            }

            return datas;
        }


        private bool GetStatus(int Status)
        {
            if (Status == 1) return false;
            else return true;
        }
    }
}
