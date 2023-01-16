using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Euservoted
    {
        public decimal Id { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Candidatesid { get; set; }
        public decimal? Municipalstatusid { get; set; }
        public DateTime? Votedate { get; set; }

        public virtual Ecandidate Candidates { get; set; }
        public virtual Emunicipalstatus Municipalstatus { get; set; }
        public virtual Euser User { get; set; }
    }
}
