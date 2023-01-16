using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Ereview
    {
        public decimal Id { get; set; }
        public decimal? Opinion { get; set; }
        public decimal? Userid { get; set; }

        public virtual Euser User { get; set; }
    }
}
