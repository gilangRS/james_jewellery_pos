using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class IT_SMS_Blast
    {
        public int Id { get; set; }
        public string RequestUrl { get; set; }
        public DateTime RequestDateTime { get; set; }
        public int ExecuteAttempt { get; set; }
        public bool ExecuteStatus { get; set; }
        public DateTime ExecuteDateTime { get; set; }
        public string ResponseUrl { get; set; }
        public DateTime? ResponseDateTime { get; set; }
        public string Result { get; set; }
        public string Operator { get; set; }
        public string Module { get; set; }
        public string NoDocument { get; set; }
        public string NoCustomer { get; set; }
        public bool VoidStatus { get; set; }
        public DateTime? VoidDateTime { get; set; }
        public string VoidDescription { get; set; }
    }
}
