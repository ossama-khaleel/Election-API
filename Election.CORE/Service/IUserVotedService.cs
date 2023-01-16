using Election.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Service
{
    public interface IUserVotedService
    {
        public List<TotalVotes> TotalVotes();
        public List<Chart> Chart();
    }
}
