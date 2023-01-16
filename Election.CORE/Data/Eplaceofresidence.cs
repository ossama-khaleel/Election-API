using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Eplaceofresidence
    {
        public Eplaceofresidence()
        {
            Eplaceswithinthemunicipals = new HashSet<Eplaceswithinthemunicipal>();
            Euserinformations = new HashSet<Euserinformation>();
        }

        public decimal Id { get; set; }
        public string Placeofresidence { get; set; }

        public virtual ICollection<Eplaceswithinthemunicipal> Eplaceswithinthemunicipals { get; set; }
        public virtual ICollection<Euserinformation> Euserinformations { get; set; }
    }
}
