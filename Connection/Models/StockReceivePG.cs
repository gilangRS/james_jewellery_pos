using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceivePG
    {
        public int Id { get; set; }
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public string NomorSertifikat { get; set; }
        public DateTime Tgl { get; set; }
        public DateTime TglTjt { get; set; }
        public string NoTtb { get; set; }
        public int Idwarehouse { get; set; }
        public string Nomor { get; set; }
        public int? Idsupplier { get; set; }
        public string SupplierNama { get; set; }
        public string SupplierSj { get; set; }
        public string Keterangan { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string CatatanManager { get; set; }
        public string ImgPicture { get; set; }
        public int ProductLevel { get; set; }
        public int Model { get; set; }
        public int ProductItem { get; set; }
        public int FrameColor { get; set; }
        public int TargetAge { get; set; }
        public decimal KadarLogam { get; set; }
        public decimal KadarTukaranJual { get; set; }
        public decimal KadarTukaranBeli { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NettoWeight { get; set; }
        public decimal MountingM { get; set; }
        public decimal MountingR { get; set; }
        public decimal? MountingMusd { get; set; }
        public decimal? MountingRusd { get; set; }
        public decimal GoldRate { get; set; }
        public DateTime EfektifGold { get; set; }
        public decimal? Harga { get; set; }
        public decimal? HargaUsd { get; set; }
        public decimal TotalHarga { get; set; }
        public decimal? TotalHargaUsd { get; set; }
        public decimal? TotalHargaJual { get; set; }
        public decimal? TotalHargaJualUsd { get; set; }
        public decimal TotalHarga24 { get; set; }
        public decimal TotalRate { get; set; }
        public DateTime EfektifTotalRate { get; set; }
        public int? HumanStock { get; set; }
        public string HumanStockNama { get; set; }
        public bool? FixRate { get; set; }
        public decimal? DimensiR { get; set; }
        public int? StoneQty { get; set; }
        public decimal? StoneWeight { get; set; }
        public string NoKirimCz { get; set; }

        public virtual CharFrameColor CharFrameColor { get; set; }
        public virtual DataSupplier DataSupplier { get; set; }
        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual CharGoldModel CharGoldModel { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
        public virtual CharGoldLevel CharGoldLevel { get; set; }
        public virtual CharTargetAge CharTargetAge { get; set; }
    }
}
