using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Emunicipalstatus
    {
        public Emunicipalstatus()
        {
            Ecandidates = new HashSet<Ecandidate>();
            Eplaceswithinthemunicipals = new HashSet<Eplaceswithinthemunicipal>();
            Euservoteds = new HashSet<Euservoted>();
        }

        public decimal Id { get; set; }
        public decimal? Municipalnameid { get; set; }
        public decimal? President { get; set; }
        public decimal? Memebers { get; set; }
        public decimal? Decentralized { get; set; }
        public decimal? Governorateid { get; set; }

        public virtual Egovernorate Governorate { get; set; }
        public virtual Emunicipalname Municipalname { get; set; }
        public virtual ICollection<Ecandidate> Ecandidates { get; set; }
        public virtual ICollection<Eplaceswithinthemunicipal> Eplaceswithinthemunicipals { get; set; }
        public virtual ICollection<Euservoted> Euservoteds { get; set; }
    }
}
