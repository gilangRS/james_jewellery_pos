using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.AccountModels
{
    public partial class RoleAccess
    {
        public int Id { get; set; }
        public int Idmenu { get; set; }
        public int Idrole { get; set; }
        public string Role { get; set; }
    }
}
