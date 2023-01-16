using Election.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.DTO
{
    public class GetUserVotes
    {
        public  Ecandidate Ecandidates { get; set; }
        public  Euservoted Euservoteds { get; set; }
    }
}
