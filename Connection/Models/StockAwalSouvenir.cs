﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAwalSouvenir
    {
        public int Id { get; set; }
        public int LocationType { get; set; }
        public int Idlocation { get; set; }
        public int Idsouvenir { get; set; }
        public int Qty { get; set; }
        public DateTime Periode { get; set; }
    }
}
