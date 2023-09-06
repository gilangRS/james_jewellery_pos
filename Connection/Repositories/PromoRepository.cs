using Connection.Interface;
using Connection.Models;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Connection.Repositories
{
    public class PromoRepository : IPromoRepository
    {
        private readonly JAWSDbContext _context;
        private OpenConnection connection = new OpenConnection();
        private ConnectionString connectionStrings;
        public PromoRepository()
        {
            _context = new JAWSDbContext();
            this.connectionStrings = new ConnectionString();
        }

        public object GetPromoDJList(string Nomor, int TipeLokasi, int IDLokasi, int Status)
        {
            List<object> datas = new List<object>();


            string query = "exec sp_PromoDJ '"
                + Nomor + "', "
                + Status + ", "
                + IDLokasi + ", "
                + TipeLokasi;
            
            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new { 
                        ID = Convert.ToUInt32(row["ID"]),
                        Nama = row["Nama"].ToString(),
                        CreatedBy = row["CreatedBy"].ToString(),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                        Nomor = row["Nomor"].ToString(),
                        Status = row["Status"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        TglStart = Convert.ToDateTime(row["TglStart"]),
                        TglExpire = Convert.ToDateTime(row["TglExpire"]),
                        DayUntilExpire = Convert.ToInt32(row["DayUntilExpire"]),
                        TipePromo = row["TipePromo"].ToString(),
                        PromoHarga = Convert.ToDecimal(row["PromoHarga"]),
                        DiscountNominal = Convert.ToDecimal(row["DiscountNominal"]),
                        DiscountPersen = Convert.ToDecimal(row["DiscountPersen"]),
                        PoinReward = Convert.ToDecimal(row["PoinReward"])
                    });

                }
            }
            return datas;
        }

        public object GetPromoPGList(string Nomor, int TipeLokasi, int IDLokasi, int Status)
        {
            List<object> datas = new List<object>();


            string query = "exec sp_PromoPG '"
                + Nomor + "', "
                + Status + ", "
                + IDLokasi + ", "
                + TipeLokasi;

            DataTable dt = connection.Rs(query, connectionStrings.ConnectionStrings.Cnn_DB);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    datas.Add(new
                    {
                        ID = Convert.ToUInt32(row["ID"]),
                        Nama = row["Nama"].ToString(),
                        CreatedBy = row["CreatedBy"].ToString(),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                        Nomor = row["Nomor"].ToString(),
                        Status = row["Status"].ToString(),
                        Lokasi = row["Lokasi"].ToString(),
                        TglStart = Convert.ToDateTime(row["TglStart"]),
                        TglExpire = Convert.ToDateTime(row["TglExpire"]),
                        DayUntilExpire = Convert.ToInt32(row["DayUntilExpire"]),
                        TipePromo = row["TipePromo"].ToString(),
                        PromoHarga = Convert.ToDecimal(row["PromoHarga"]),
                        DiscountNominal = Convert.ToDecimal(row["DiscountNominal"]),
                        DiscountPersen = Convert.ToDecimal(row["DiscountPersen"]),
                        PoinReward = Convert.ToDecimal(row["PoinReward"])
                    });

                }
            }
            return datas;
        }
    }
}
