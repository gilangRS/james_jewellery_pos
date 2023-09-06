using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class LetterWR
    {
        public int Id { get; set; }
        public int? IdsalesReceiptDppo { get; set; }
        public string Letter { get; set; }
    }
}
