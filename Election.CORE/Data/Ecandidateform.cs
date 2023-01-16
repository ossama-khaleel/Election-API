using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Ecandidateform
    {
        public Ecandidateform()
        {
            Ecandidates = new HashSet<Ecandidate>();
        }

        public decimal Id { get; set; }
        public string Candidatename { get; set; }
        public decimal? Acceptstatus { get; set; }
        public decimal? Categoryid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Ecategory Category { get; set; }
        public virtual Euser User { get; set; }
        public virtual ICollection<Ecandidate> Ecandidates { get; set; }
    }
}
