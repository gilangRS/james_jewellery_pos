using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CalculatorProductDJ
    {
        public CalculatorProductDJ()
        {
            CalculatorProductDJ_Finishings = new HashSet<CalculatorProductDJ_Finishing>();
            CalculatorProductDJ_Stone1As = new HashSet<CalculatorProductDJ_Stone1A>();
            CalculatorProductDJ_Stone1Bs = new HashSet<CalculatorProductDJ_Stone1B>();
            CalculatorProductDJ_Stone2s = new HashSet<CalculatorProductDJ_Stone2>();
            CalculatorProductDJ_Stone3s = new HashSet<CalculatorProductDJ_Stone3>();
            CalculatorProductDJ_Stone4s = new HashSet<CalculatorProductDJ_Stone4>();
            CalculatorProductDJ_Stone5s = new HashSet<CalculatorProductDJ_Stone5>();
        }

        public int Id { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }

        public virtual CalculatorProductDJ_CharProduct CalculatorProductDJ_CharProduct { get; set; }
        public virtual CalculatorProductDJ_PricingBiaya CalculatorProductDJ_PricingBiaya { get; set; }
        public virtual CalculatorProductDJ_PricingMU CalculatorProductDJ_PricingMU { get; set; }
        public virtual CalculatorProductDJPricingProduct CalculatorProductDJ_PricingProduct { get; set; }
        public virtual ICollection<CalculatorProductDJ_Finishing> CalculatorProductDJ_Finishings { get; set; }
        public virtual ICollection<CalculatorProductDJ_Stone1A> CalculatorProductDJ_Stone1As { get; set; }
        public virtual ICollection<CalculatorProductDJ_Stone1B> CalculatorProductDJ_Stone1Bs { get; set; }
        public virtual ICollection<CalculatorProductDJ_Stone2> CalculatorProductDJ_Stone2s { get; set; }
        public virtual ICollection<CalculatorProductDJ_Stone3> CalculatorProductDJ_Stone3s { get; set; }
        public virtual ICollection<CalculatorProductDJ_Stone4> CalculatorProductDJ_Stone4s { get; set; }
        public virtual ICollection<CalculatorProductDJ_Stone5> CalculatorProductDJ_Stone5s { get; set; }
    }
}
