﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class NoteRepair_Stone3
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public string Keterangan { get; set; }
        public int TotalButir { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal CaratButir { get; set; }
        public decimal DimensiP { get; set; }
        public decimal DimensiL { get; set; }
        public decimal DimensiT { get; set; }
        public decimal HargaSatuan { get; set; }
        public decimal HargaTotal { get; set; }
        public decimal HargaSatuanM { get; set; }
        public decimal HargaTotalM { get; set; }
        public DateTime Efektif { get; set; }
        public decimal Setting { get; set; }
        public string Gia { get; set; }
        public decimal HargaTotalRupiah { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string RevisiOperator { get; set; }
        public DateTime? RevisiOperatorTgl { get; set; }
        public string RevisiKeterangan { get; set; }

        public virtual NoteRepair NoteRepair { get; set; }
        public virtual Stone3 Stone3 { get; set; }
    }
}
