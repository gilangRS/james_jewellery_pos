﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJCustomer_CharProduct
    {
        public int Id { get; set; }
        public int ProductItem { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal StoneCarat { get; set; }
        public decimal StoneWeight { get; set; }
        public decimal? StoneQty { get; set; }
        public decimal NettoWeight { get; set; }
        public decimal DimensiD { get; set; }
        public decimal DimensiP { get; set; }
        public decimal DimensiL { get; set; }
        public decimal? DimensiR { get; set; }

        public virtual StockProductDJCustomer StockProductDJCustomer { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
    }
}
