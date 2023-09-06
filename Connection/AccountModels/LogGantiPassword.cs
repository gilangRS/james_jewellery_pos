using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.AccountModels
{
    public partial class LogGantiPassword
    {
        public int Id { get; set; }
        public string Nik { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
