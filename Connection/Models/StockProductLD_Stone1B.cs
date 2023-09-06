using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductLD_Stone1B
    {
        public StockProductLD_Stone1B()
        {
            DocQCLDs = new HashSet<DocQCLD>();
            ResellLDs = new HashSet<ResellLD>();
            SaldoStockLDs = new HashSet<SaldoStockLD>();
            SalesOrderLDs = new HashSet<SalesOrderLD>();
            StockAuditItemLDs = new HashSet<StockAuditItemLD>();
            StockAuditLDDetails = new HashSet<StockAuditLDDetail>();
            StockIncomingLD_Products = new HashSet<StockIncomingLD_Product>();
            StockOutgoingLD_Products = new HashSet<StockOutgoingLD_Product>();
            StockProductDJLDs = new HashSet<StockProductDJLD>();
            StockReturnLD_Products = new HashSet<StockReturnLD_Product>();
            CrossBrand_StockIncomingLD_Products = new HashSet<CrossBrand_StockIncomingLD_Product>();
            CrossBrand_StockOutgoingLD_Products = new HashSet<CrossBrand_StockOutgoingLD_Product>();
        }

        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public string Nomor { get; set; }
        public int TotalButir { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal CaratButir { get; set; }
        public decimal DimensiP { get; set; }
        public decimal? DimensiL { get; set; }
        public decimal? DimensiT { get; set; }
        public string Gia { get; set; }
        public decimal? HargaSatuan { get; set; }
        public decimal? HargaTotal { get; set; }
        public decimal? HargaInputH { get; set; }
        public decimal? HargaSatuanM { get; set; }
        public decimal? HargaTotalM { get; set; }
        public decimal? HargaInputP { get; set; }
        public DateTime? Efektif { get; set; }
        public decimal? Setting { get; set; }
        public string ImgPicture { get; set; }
        public bool? ReturnProduct { get; set; }
        public int? StatusPenjualan { get; set; }
        public DateTime? BookExpire { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int? ProductItem { get; set; }
        public decimal? HargaMjual { get; set; }
        public decimal? DiscMjual { get; set; }
        public decimal? HargaRjual { get; set; }
        public decimal? DiscRjual { get; set; }
        public decimal? HargaMinputH { get; set; }
        public decimal? HargaMinputP { get; set; }

        public virtual StockProductLD StockProductLD { get; set; }
        public virtual StockActualLD_Stone1B StockActualLD_Stone1B { get; set; }
        public virtual StockReceiveLDLegacy StockReceiveLDLegacy { get; set; }
        public virtual ICollection<DocQCLD> DocQCLDs { get; set; }
        public virtual ICollection<ResellLD> ResellLDs { get; set; }
        public virtual ICollection<SaldoStockLD> SaldoStockLDs { get; set; }
        public virtual ICollection<SalesOrderLD> SalesOrderLDs { get; set; }
        public virtual ICollection<StockAuditItemLD> StockAuditItemLDs { get; set; }
        public virtual ICollection<StockAuditLDDetail> StockAuditLDDetails { get; set; }
        public virtual ICollection<StockIncomingLD_Product> StockIncomingLD_Products { get; set; }
        public virtual ICollection<StockOutgoingLD_Product> StockOutgoingLD_Products { get; set; }
        public virtual ICollection<StockProductDJLD> StockProductDJLDs { get; set; }
        public virtual ICollection<StockReturnLD_Product> StockReturnLD_Products { get; set; }
        public virtual ICollection<CrossBrand_StockIncomingLD_Product> CrossBrand_StockIncomingLD_Products { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingLD_Product> CrossBrand_StockOutgoingLD_Products { get; set; }
    }
}
