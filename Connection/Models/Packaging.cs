using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class Packaging
    {
        public Packaging()
        {
            AdjustmentPackagingProducts = new HashSet<AdjustmentPackagingProduct>();
            SalesOrderPackagings = new HashSet<SalesOrderPackaging>();
            StockActualPackagings = new HashSet<StockActualPackaging>();
            StockIncomingPackagingProducts = new HashSet<StockIncomingPackaging_Product>();
            StockOutgoingPackagingProducts = new HashSet<StockOutgoingPackaging_Product>();
            StockReceivePackagingProducts = new HashSet<StockReceivePackaging_Product>();
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
        public virtual ICollection<AdjustmentPackagingProduct> AdjustmentPackagingProducts { get; set; }
        public virtual ICollection<SalesOrderPackaging> SalesOrderPackagings { get; set; }
        public virtual ICollection<StockActualPackaging> StockActualPackagings { get; set; }
        public virtual ICollection<StockIncomingPackaging_Product> StockIncomingPackagingProducts { get; set; }
        public virtual ICollection<StockOutgoingPackaging_Product> StockOutgoingPackagingProducts { get; set; }
        public virtual ICollection<StockReceivePackaging_Product> StockReceivePackagingProducts { get; set; }
    }
}
