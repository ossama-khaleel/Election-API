using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Ecandidate
    {
        public Ecandidate()
        {
            Euservoteds = new HashSet<Euservoted>();
        }

        public decimal Id { get; set; }
        public string Candidatename { get; set; }
        public string Des { get; set; }
        public string Candidateimagepath { get; set; }
        public decimal? Categoryid { get; set; }
        public decimal? Municipalstatusid { get; set; }
        public decimal? Candidateformid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Resultstatus { get; set; }

        public virtual Ecandidateform Candidateform { get; set; }
        public virtual Ecategory Category { get; set; }
        public virtual Emunicipalstatus Municipalstatus { get; set; }
        public virtual Euser User { get; set; }
        public virtual ICollection<Euservoted> Euservoteds { get; set; }
    }
}
