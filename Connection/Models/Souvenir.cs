using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class Souvenir
    {
        public Souvenir()
        {
            AdjustmentSouvenirProducts = new HashSet<AdjustmentSouvenirProduct>();
            SalesOrderSouvenirs = new HashSet<SalesOrderSouvenir>();
            StockActualSouvenirs = new HashSet<StockActualSouvenir>();
            StockIncomingSouvenirProducts = new HashSet<StockIncomingSouvenir_Product>();
            StockOutgoingSouvenirProducts = new HashSet<StockOutgoingSouvenir_Product>();
            StockReceiveSouvenirProducts = new HashSet<StockReceiveSouvenir_Product>();
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
        public virtual ICollection<AdjustmentSouvenirProduct> AdjustmentSouvenirProducts { get; set; }
        public virtual ICollection<SalesOrderSouvenir> SalesOrderSouvenirs { get; set; }
        public virtual ICollection<StockActualSouvenir> StockActualSouvenirs { get; set; }
        public virtual ICollection<StockIncomingSouvenir_Product> StockIncomingSouvenirProducts { get; set; }
        public virtual ICollection<StockOutgoingSouvenir_Product> StockOutgoingSouvenirProducts { get; set; }
        public virtual ICollection<StockReceiveSouvenir_Product> StockReceiveSouvenirProducts { get; set; }
    }
}
