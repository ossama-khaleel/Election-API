using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Eplaceofresidencevillage
    {
        public Eplaceofresidencevillage()
        {
            Euserinformations = new HashSet<Euserinformation>();
        }

        public decimal Id { get; set; }
        public string Placeofresidencevillage { get; set; }

        public virtual Eplaceswithinthemunicipal Eplaceswithinthemunicipal { get; set; }
        public virtual ICollection<Euserinformation> Euserinformations { get; set; }
    }
}
