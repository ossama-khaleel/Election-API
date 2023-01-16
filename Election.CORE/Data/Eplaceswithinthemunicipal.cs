using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Eplaceswithinthemunicipal
    {
        public Eplaceswithinthemunicipal()
        {
            Euservotes = new HashSet<Euservote>();
        }

        public decimal Id { get; set; }
        public decimal? Placeofresidenceid { get; set; }
        public decimal? Placeofresidencevillageid { get; set; }
        public decimal? Municipalstatusid { get; set; }

        public virtual Emunicipalstatus Municipalstatus { get; set; }
        public virtual Eplaceofresidence Placeofresidence { get; set; }
        public virtual Eplaceofresidencevillage Placeofresidencevillage { get; set; }
        public virtual ICollection<Euservote> Euservotes { get; set; }
    }
}
