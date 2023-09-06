﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveCetakan_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Harga { get; set; }
        public decimal? Ongkos { get; set; }
        public decimal? OngkosPacking { get; set; }
        public decimal? Received { get; set; }
        public decimal? Damaged { get; set; }
        public decimal? NeverArrived { get; set; }

        public virtual StockReceiveCetakan StockReceiveCetakan { get; set; }
        public virtual Cetakan Cetakan { get; set; }
    }
}
