using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.AccountModels
{
    public partial class UserApproval
    {
        public int Idrole { get; set; }
        public int Level { get; set; }
        public string Approval { get; set; }
    }
}
