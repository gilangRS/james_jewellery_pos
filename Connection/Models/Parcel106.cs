﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class Parcel106
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }
        public bool? IsBranded { get; set; }
    }
}
