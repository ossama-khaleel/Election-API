using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Eplaceandregnum
    {
        public Eplaceandregnum()
        {
            Euserinformations = new HashSet<Euserinformation>();
        }

        public decimal Id { get; set; }
        public string Placeandregnum { get; set; }

        public virtual ICollection<Euserinformation> Euserinformations { get; set; }
    }
}
