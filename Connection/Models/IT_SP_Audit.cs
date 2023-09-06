using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class IT_SP_Audit
    {
        public int Id { get; set; }
        public string StoreProcedure { get; set; }
        public bool StatusActive { get; set; }
        public string TriggerBy { get; set; }
        public DateTime TriggerDate { get; set; }
        public string LastTriggerBy { get; set; }
        public DateTime LastTriggerDate { get; set; }
        public int TotalIssue { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
    }
}
