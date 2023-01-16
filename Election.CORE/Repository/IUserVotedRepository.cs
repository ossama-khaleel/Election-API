using Election.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Repository
{
    public interface IUserVotedRepository
    {
        public List<TotalVotes> TotalVotes();
        public List<Chart> Chart();
    }
}
