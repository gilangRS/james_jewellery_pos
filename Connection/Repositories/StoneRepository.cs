using Connection.Interface;
using Connection.Models;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Repositories
{
    public class StoneRepository : IStoneRepository
    {
        private readonly JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;
        private Common common;

        public StoneRepository()
        {
            common = new Common();
            _context = new JAWSDbContext();
            this.connectionStrings = new ConnectionString();
        }

        public object GetStone1A(int Parcel01, int Parcel02, int Parcel03, int Parcel04)
        {
            if (Parcel01 >= 0 || Parcel02 >= 0 || Parcel03 >= 0 || Parcel04 >= 0)
            {
                if (Parcel01 < 0) Parcel01 = 0;
                if (Parcel02 < 0) Parcel02 = 0;
                if (Parcel03 < 0) Parcel03 = 0;
                if (Parcel04 < 0) Parcel04 = 0;
            }

            List<object> datas = new List<object>();

            string query = "exec sp_getStone1AOutlet "
                + Parcel01 + ", "
                + Parcel02 + ", "
                + Parcel03 + ", "
                + Parcel04;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Tipe = row["Tipe"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Color = row["Color"].ToString(),
                        Clarity = row["Clarity"].ToString(),
                        SizeMin = Convert.ToDecimal(row["SizeMin"]),
                        SizeMax = Convert.ToDecimal(row["SizeMax"])
                    });
                }
            }

            return datas;
        }
        public object GetStone1B(int Parcel01, int Parcel02, int Parcel03, int Parcel04, int Parcel05, int Parcel06, int Parcel07)
        {
            if (Parcel01 >= 0 || Parcel02 >= 0 || Parcel03 >= 0 || Parcel04 >= 0 || Parcel05 >= 0 || Parcel06 >= 0 || Parcel07 >= 0)
            {
                if (Parcel01 < 0) Parcel01 = 0;
                if (Parcel02 < 0) Parcel02 = 0;
                if (Parcel03 < 0) Parcel03 = 0;
                if (Parcel04 < 0) Parcel04 = 0;
                if (Parcel05 < 0) Parcel05 = 0;
                if (Parcel06 < 0) Parcel06 = 0;
                if (Parcel07 < 0) Parcel07 = 0;
            }
            List<object> datas = new List<object>();

            string query = "exec sp_getStone1BOutlet "
                + Parcel01 + ", "
                + Parcel02 + ", "
                + Parcel03 + ", "
                + Parcel04 + ", "
                + Parcel05 + ", "
                + Parcel06 + ", "
                + Parcel07; 

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Tipe = row["Tipe"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Color = row["Color"].ToString(),
                        Clarity = row["Clarity"].ToString(),
                        SizeMin = Convert.ToDecimal(row["SizeMin"]),
                        SizeMax = Convert.ToDecimal(row["SizeMax"])
                    });
                }
            }

            return datas;
        }

        public object GetStone2(int Parcel01, int Parcel02, int Parcel03, int Parcel04)
        {
            if (Parcel01 >= 0 || Parcel02 >= 0 || Parcel03 >= 0 || Parcel04 >= 0)
            {
                if (Parcel01 < 0) Parcel01 = 0;
                if (Parcel02 < 0) Parcel02 = 0;
                if (Parcel03 < 0) Parcel03 = 0;
                if (Parcel04 < 0) Parcel04 = 0;
            }

            List<object> datas = new List<object>();

            string query = "exec sp_getStone2Outlet "
                + Parcel01 + ", "
                + Parcel02 + ", "
                + Parcel03 + ", "
                + Parcel04;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Tipe = row["Tipe"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Color = row["Color"].ToString(),
                        Clarity = row["Clarity"].ToString(),
                        SizeMin = Convert.ToDecimal(row["SizeMin"]),
                        SizeMax = Convert.ToDecimal(row["SizeMax"])
                    });
                }
            }

            return datas;
        }

        public object GetStone3(int Parcel01, int Parcel02, int Parcel03, int Parcel04)
        {
            if (Parcel01 >= 0 || Parcel02 >= 0 || Parcel03 >= 0 || Parcel04 >= 0)
            {
                if (Parcel01 < 0) Parcel01 = 0;
                if (Parcel02 < 0) Parcel02 = 0;
                if (Parcel03 < 0) Parcel03 = 0;
                if (Parcel04 < 0) Parcel04 = 0;
            }

            List<object> datas = new List<object>();

            string query = "exec sp_getStone3Outlet "
                + Parcel01 + ", "
                + Parcel02 + ", "
                + Parcel03 + ", "
                + Parcel04;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Tipe = row["Tipe"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Color = row["Color"].ToString(),
                        Clarity = row["Clarity"].ToString(),
                        SizeMin = Convert.ToDecimal(row["SizeMin"]),
                        SizeMax = Convert.ToDecimal(row["SizeMax"])
                    });
                }
            }

            return datas;
        }
        public object GetStone4(int Parcel01, int Parcel02, int Parcel03)
        {
            if (Parcel01 >= 0 || Parcel02 >= 0 || Parcel03 >= 0)
            {
                if (Parcel01 < 0) Parcel01 = 0;
                if (Parcel02 < 0) Parcel02 = 0;
                if (Parcel03 < 0) Parcel03 = 0;
            }

            List<object> datas = new List<object>();

            string query = "exec sp_getStone4Outlet "
                + Parcel01 + ", "
                + Parcel02 + ", "
                + Parcel03;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Tipe = row["Tipe"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Color = row["Color"].ToString(),
                        Clarity = row["Clarity"].ToString(),
                        SizeMin = Convert.ToDecimal(row["SizeMin"]),
                        SizeMax = Convert.ToDecimal(row["SizeMax"])
                    });
                }
            }

            return datas;
        }

        public object GetStone5(int Parcel01, int Parcel02, int Parcel03, int Parcel04, int Parcel05, int Parcel06, int Parcel07, int Parcel08)
        {
            if (Parcel01 >= 0 || Parcel02 >= 0 || Parcel03 >= 0 || Parcel04 >= 0 || Parcel05 >= 0 || Parcel06 >= 0 || Parcel07 >= 0 || Parcel08 >= 0)
            {
                if (Parcel01 < 0) Parcel01 = 0;
                if (Parcel02 < 0) Parcel02 = 0;
                if (Parcel03 < 0) Parcel03 = 0;
                if (Parcel04 < 0) Parcel04 = 0;
                if (Parcel05 < 0) Parcel05 = 0;
                if (Parcel06 < 0) Parcel06 = 0;
                if (Parcel07 < 0) Parcel07 = 0;
                if (Parcel08 < 0) Parcel08 = 0;
            }

            List<object> datas = new List<object>();

            string query = "exec sp_getStone5Outlet "
                + Parcel01 + ", "
                + Parcel02 + ", "
                + Parcel03 + ", "
                + Parcel04 + ", "
                + Parcel05 + ", "
                + Parcel06 + ", "
                + Parcel07 + ", "
                + Parcel08;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Tipe = row["Tipe"].ToString(),
                        Nama = row["Nama"].ToString(),
                        Kode = row["Kode"].ToString(),
                        Source = row["Source"].ToString(),
                        Color = row["Color"].ToString(),
                        Overtone = row["Overtone"].ToString(),
                        Surface = row["Surface"].ToString(),
                        Luster = row["Luster"].ToString(),
                        SizeMin = Convert.ToDecimal(row["SizeMin"]),
                        SizeMax = Convert.ToDecimal(row["SizeMax"])
                    });
                }
            }

            return datas;
        }

        public object GetHargaTotalBatu(int Item, int StoneDist, int IDStone, string Tipe, int TotalButir, decimal TotalCarat)
        {
            object data = new();

            string query = "exec sp_getHargaStone "
                + IDStone + ", '"
                + Tipe + "', "
                + TotalCarat + ", "
                + TotalButir + ", "
                + Item + ", "
                + StoneDist;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data = new
                    {
                        IDStone = IDStone,
                        Tipe = Tipe,
                        TotalButir = TotalButir,
                        TotalCarat = TotalCarat,
                        HargaSatuan = Convert.ToDecimal(row["HargaSatuan"]),
                        HargaSatuanM = Convert.ToDecimal(row["HargaSatuanM"]),
                        HargaTotal = Convert.ToDecimal(row["HargaTotal"]),
                        HargaTotalM = Convert.ToDecimal(row["HargaTotalM"]),
                        HargaTotalRupiah = Convert.ToDecimal(row["HargaTotalRupiah"])
                    };
                }
            }

            return data;
        }
    }
}
