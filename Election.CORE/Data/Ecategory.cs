using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Ecategory
    {
        public Ecategory()
        {
            Ecandidateforms = new HashSet<Ecandidateform>();
            Ecandidates = new HashSet<Ecandidate>();
            Eelectiondurations = new HashSet<Eelectionduration>();
        }

        public decimal Id { get; set; }
        public string Categoryname { get; set; }

        public virtual ICollection<Ecandidateform> Ecandidateforms { get; set; }
        public virtual ICollection<Ecandidate> Ecandidates { get; set; }
        public virtual ICollection<Eelectionduration> Eelectiondurations { get; set; }
    }
}
