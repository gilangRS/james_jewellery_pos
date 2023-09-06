using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class IT_ErrorLog
    {
        public int PkErrorHandlingId { get; set; }
        public int ErrorNumber { get; set; }
        public string ErrorMessage { get; set; }
        public short ErrorSeverity { get; set; }
        public short ErrorState { get; set; }
        public string ErrorProcedure { get; set; }
        public int ErrorLine { get; set; }
        public string UserName { get; set; }
        public string HostName { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
