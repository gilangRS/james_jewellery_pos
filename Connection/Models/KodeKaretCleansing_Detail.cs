using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class KodeKaretCleansing_Detail
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public string ProtoNomor { get; set; }
        public string KodeKaret { get; set; }
        public int Total { get; set; }
        public string ImgPictureBrj { get; set; }
        public string ImgPictureSpk { get; set; }
        public bool StatusBasic { get; set; }
        public string KodeKaretRev { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
    }
}
