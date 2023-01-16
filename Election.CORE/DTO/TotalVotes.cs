using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.DTO
{
    public class TotalVotes
    {
        public decimal TotalVote { get; set; }
        public decimal CandidatesId { get; set; }
        public decimal Municipalstatusid { get; set; }
        public decimal Userid { get; set; }
        public string CategoryName { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Status { get; set; }
    }
}
