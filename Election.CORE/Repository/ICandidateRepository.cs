using Election.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Repository
{
    public  interface ICandidateRepository
    {
        public List<Ecandidate> GetUserVotes(int userId);
        public void UpdateStatus(int candidateId,int status);
    }
}
