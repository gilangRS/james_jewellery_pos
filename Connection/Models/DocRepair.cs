using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocRepair
    {
        public DocRepair()
        {
            DocRepairLog_Stone1As = new HashSet<DocRepairLog_Stone1A>();
            DocRepairLog_Stone1Bs = new HashSet<DocRepairLog_Stone1B>();
            DocRepairLog_Stone2s = new HashSet<DocRepairLog_Stone2>();
            DocRepairLog_Stone3s = new HashSet<DocRepairLog_Stone3>();
            DocRepairLog_Stone5s = new HashSet<DocRepairLog_Stone5>();
            DocRepair_Repairs = new HashSet<DocRepair_Repair>();
            DocRepairResults = new HashSet<DocRepairResult>();
            DocRepair_Stone1As = new HashSet<DocRepair_Stone1A>();
            DocRepair_Stone1Bs = new HashSet<DocRepair_Stone1B>();
            DocRepair_Stone2s = new HashSet<DocRepair_Stone2>();
            DocRepair_Stone3s = new HashSet<DocRepair_Stone3>();
            DocRepair_Stone4s = new HashSet<DocRepair_Stone4>();
            DocRepair_Stone5s = new HashSet<DocRepair_Stone5>();
            DocRepair_StoneRepairs = new HashSet<DocRepair_StoneRepair>();
        }

        public int Id { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tgl { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int? Idcustomer { get; set; }
        public int? Idsales { get; set; }
        public string SalesNama { get; set; }
        public string CustomerNama { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public DateTime? TglSelesai { get; set; }
        public string Keterangan { get; set; }
        public int? Idproduct { get; set; }
        public int? StatusRepair { get; set; }
        public string ImgPicture { get; set; }
        public int? Sumber { get; set; }
        public int? IdproductTitipan { get; set; }
        public decimal EstimasiHarga { get; set; }
        public int? Idqc { get; set; }
        public int? Idqctitipan { get; set; }
        public decimal? GrossWeightReceive { get; set; }
        public string GrossWeightReceiveOperator { get; set; }
        public DateTime? GrossWeightReceiveOperatorTgl { get; set; }
        public string ReceiveNote { get; set; }
        public string ReceiveNomor { get; set; }
        public string KodeCustomerLama { get; set; }

        public virtual DataCustomer DataCustomer { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual StockProductDJCustomer StockProductDJCustomer { get; set; }
        public virtual DataSales DataSales { get; set; }
        public virtual DocRepair_CharProduct DocRepair_CharProduct { get; set; }
        public virtual ICollection<DocRepairLog_Stone1A> DocRepairLog_Stone1As { get; set; }
        public virtual ICollection<DocRepairLog_Stone1B> DocRepairLog_Stone1Bs { get; set; }
        public virtual ICollection<DocRepairLog_Stone2> DocRepairLog_Stone2s { get; set; }
        public virtual ICollection<DocRepairLog_Stone3> DocRepairLog_Stone3s { get; set; }
        public virtual ICollection<DocRepairLog_Stone5> DocRepairLog_Stone5s { get; set; }
        public virtual ICollection<DocRepair_Repair> DocRepair_Repairs { get; set; }
        public virtual ICollection<DocRepairResult> DocRepairResults { get; set; }
        public virtual ICollection<DocRepair_Stone1A> DocRepair_Stone1As { get; set; }
        public virtual ICollection<DocRepair_Stone1B> DocRepair_Stone1Bs { get; set; }
        public virtual ICollection<DocRepair_Stone2> DocRepair_Stone2s { get; set; }
        public virtual ICollection<DocRepair_Stone3> DocRepair_Stone3s { get; set; }
        public virtual ICollection<DocRepair_Stone4> DocRepair_Stone4s { get; set; }
        public virtual ICollection<DocRepair_Stone5> DocRepair_Stone5s { get; set; }
        public virtual ICollection<DocRepair_StoneRepair> DocRepair_StoneRepairs { get; set; }
    }
}
