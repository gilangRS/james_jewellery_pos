using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveLD_CharDesign
    {
        public int Id { get; set; }
        public int DesignCategory { get; set; }
        public int DesignConcept { get; set; }
        public int DesignProcess { get; set; }
        public int TargetAge { get; set; }
        public int TargetGender { get; set; }
        public bool SetItem { get; set; }
        public bool Special { get; set; }

        public virtual CharDesignCategory DesignCategoryNavigation { get; set; }
        public virtual CharDesignConcept DesignConceptNavigation { get; set; }
        public virtual CharDesignProcess DesignProcessNavigation { get; set; }
        public virtual StockReceiveLD IdNavigation { get; set; }
        public virtual CharTargetAge TargetAgeNavigation { get; set; }
        public virtual CharTargetGender TargetGenderNavigation { get; set; }
    }
}
