using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.AccountModels
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime InputDate { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public string Email { get; set; }
        public string Sms { get; set; }
        public string Pass { get; set; }
        public bool PassStrong { get; set; }
        public int PassInvalid { get; set; }
        public string PassResetKey { get; set; }
        public DateTime? Blokir { get; set; }
        public DateTime? LastLogin { get; set; }
        public string SessionId { get; set; }
        public bool ReadKetentuan { get; set; }
        public bool Recycle { get; set; }
        public DateTime? RecycleLast { get; set; }
        public int RecyclePolicy { get; set; }
        public string ImgAccount { get; set; }
        public string ImgPicture { get; set; }
        public string ImgSignature { get; set; }
        public string UserNumber { get; set; }
        public bool? IsFrank { get; set; }
        public bool? IsMondial { get; set; }
        public bool? IsPalace { get; set; }
        public int? IDRole { get; set; }
    }
}
