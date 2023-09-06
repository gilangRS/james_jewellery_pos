using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesReceiptDPPO
    {
        public SalesReceiptDPPO()
        {
            SalesReceiptDPPODetails = new HashSet<SalesReceiptDPPODetail>();
        }

        public int Id { get; set; }
        public int? Idcustomer { get; set; }
        public string CustomerNama { get; set; }
        public int? Idsales { get; set; }
        public string SalesNama { get; set; }
        public DateTime? Tgl { get; set; }
        public string NomorDp { get; set; }
        public decimal? TotalBayar { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public int? StatusDp { get; set; }
        public string Keterangan { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int? IdsalesOrder { get; set; }
        public decimal EstimasiHarga { get; set; }
        public int? Iddpporeference { get; set; }
        public int? IdproductSample1 { get; set; }
        public int? IdproductSample2 { get; set; }
        public int? Idproduct { get; set; }
        public int? IdframeColor { get; set; }
        public decimal? GoldWeight1 { get; set; }
        public decimal? GoldWeight2 { get; set; }
        public decimal? DiamondWeight1 { get; set; }
        public decimal? DiamondWeight2 { get; set; }
        public decimal? RingSize1 { get; set; }
        public decimal? RingSize2 { get; set; }
        public string Inscription1 { get; set; }
        public string Inscription2 { get; set; }
        public int? IdfontType { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string ImgSketch { get; set; }
        public int? TipeProductSample1 { get; set; }
        public int? TipeProductSample2 { get; set; }
        public int? TipeProduct { get; set; }
        public string VoucherCode { get; set; }
        public decimal? VoucherNominal { get; set; }
        public bool? VoucherIsRedeem { get; set; }

        public virtual DataCustomer DataCustomer { get; set; }
        public virtual DataSales DataSales { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual ICollection<SalesReceiptDPPODetail> SalesReceiptDPPODetails { get; set; }
    }
}
