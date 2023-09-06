using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class UserViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NIK { get; set; }
        public bool IsFrank { get; set; }
        public bool IsMondial { get; set; }
        public bool IsPalace { get; set; }
        public List<UserViewRole> UserRole { get; set; }
        public bool FirstLogin { get; set; }
    }

    public class UserViewRole 
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Name { get; set; }
    }
}
