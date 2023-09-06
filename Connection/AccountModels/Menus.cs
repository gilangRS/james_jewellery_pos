using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.AccountModels
{
    public partial class Menus
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Menu { get; set; }
        public string Url { get; set; }
        public virtual List<Menus> ChildMenu { get; set; }
        public virtual bool? IsChecked { get; set; }
    }
}
