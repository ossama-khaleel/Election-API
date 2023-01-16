using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Eabout
    {
        public decimal Id { get; set; }
        public string Aboutimage1 { get; set; }
        public string Aboutimage2 { get; set; }
        public string Aboutimage3 { get; set; }
        public string Abouttitle1 { get; set; }
        public string Abouttitle2 { get; set; }
        public string Abouttitle3 { get; set; }
        public decimal? Homeid { get; set; }

        public virtual Ehome Home { get; set; }
    }
}
