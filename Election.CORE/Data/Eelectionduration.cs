using System;
using System.Collections.Generic;

#nullable disable

namespace Election.CORE.Data
{
    public partial class Eelectionduration
    {
        public decimal Id { get; set; }
        public DateTime? Electionstartdate { get; set; }
        public DateTime? Electionenddate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public decimal? Categoryid { get; set; }

        public virtual Ecategory Category { get; set; }
    }
}
