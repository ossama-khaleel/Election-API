using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Eplaceofrelease
    {
        public Eplaceofrelease()
        {
            Euserinformations = new HashSet<Euserinformation>();
        }

        public decimal Id { get; set; }
        public string Placeofrelease { get; set; }

        public virtual ICollection<Euserinformation> Euserinformations { get; set; }
    }
}
