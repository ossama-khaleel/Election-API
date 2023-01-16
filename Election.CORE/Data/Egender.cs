using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Egender
    {
        public Egender()
        {
            Euserinformations = new HashSet<Euserinformation>();
        }

        public decimal Id { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Euserinformation> Euserinformations { get; set; }
    }
}
