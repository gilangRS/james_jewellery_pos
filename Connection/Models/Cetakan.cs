using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class Cetakan
    {
        public Cetakan()
        {
            SalesOrderCetakans = new HashSet<SalesOrderCetakan>();
            StockActualCetakans = new HashSet<StockActualCetakan>();
            StockIncomingCetakanProducts = new HashSet<StockIncomingCetakan_Product>();
            StockOutgoingCetakanProducts = new HashSet<StockOutgoingCetakan_Product>();
            StockReceiveCetakanProducts = new HashSet<StockReceiveCetakan_Product>();
        }

        public int Id { get; set; }
        public int Idbrand { get; set; }
        public string Nama { get; set; }
        public string Kode { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public bool Disable { get; set; }
        public string Satuan { get; set; }
        public string ImgPicture { get; set; }
        public decimal? Harga { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual ICollection<SalesOrderCetakan> SalesOrderCetakans { get; set; }
        public virtual ICollection<StockActualCetakan> StockActualCetakans { get; set; }
        public virtual ICollection<StockIncomingCetakan_Product> StockIncomingCetakanProducts { get; set; }
        public virtual ICollection<StockOutgoingCetakan_Product> StockOutgoingCetakanProducts { get; set; }
        public virtual ICollection<StockReceiveCetakan_Product> StockReceiveCetakanProducts { get; set; }
    }
}
