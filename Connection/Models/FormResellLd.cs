using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class FormResellLd
    {
        public int Id { get; set; }
        public int Idcustomer { get; set; }
        public int TipeLokasi { get; set; }
        public int Idlokasi { get; set; }
        public string Nomor { get; set; }
        public DateTime Tgl { get; set; }
        public int Idproduct { get; set; }
        public decimal? HargaBeliCustomer { get; set; }
        public string Gia { get; set; }
        public decimal? Carat { get; set; }
        public string Colour { get; set; }
        public string Clarity { get; set; }
        public string Cutting { get; set; }
        public decimal? Gram { get; set; }
        public string Rapaport { get; set; }
        public decimal? HargaJualCustomer { get; set; }
        public bool? Certificate { get; set; }
        public bool? OriginalInvoice { get; set; }
        public string LaserIncription { get; set; }
        public bool? KondisiFisikBatu { get; set; }
        public string Operator { get; set; }
        public string OperatorNik { get; set; }
        public bool? IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedNik { get; set; }
        public string RapaportJual { get; set; }
        public decimal? BeratPerhiasan { get; set; }
        public string Measurement { get; set; }
        public string Kategori { get; set; }
        public string Item { get; set; }
        public bool? IsRejected { get; set; }
        public string RejectedBy { get; set; }
        public string RejectedNik { get; set; }
        public string Giap { get; set; }
        public decimal? CaratP { get; set; }
        public string ColourP { get; set; }
        public string ClarityP { get; set; }
        public string CuttingP { get; set; }
        public decimal? GramP { get; set; }
        public string RapaportP { get; set; }
        public decimal? HargaJualCustomerP { get; set; }
        public bool? CertificateP { get; set; }
        public bool? OriginalInvoiceP { get; set; }
        public string LaserIncriptionP { get; set; }
        public bool? KondisiFisikBatuP { get; set; }
        public string RapaportJualP { get; set; }
        public decimal? BeratPerhiasanP { get; set; }
        public string MeasurementP { get; set; }
        public string KategoriP { get; set; }
        public string ItemP { get; set; }
        public int? IdlokasiP { get; set; }
        public int? TipeLokasiP { get; set; }
    }
}
