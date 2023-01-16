using Election.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.CORE.Service
{
    public interface ICandidateService
    {
        public List<Ecandidate> GetCandidates(int userId,int catId);
        public List<Ecandidate> GetCandidatesForUser(int userId, int catId);
        public void UpdateStatus(int candidateId, int status);
        public void ElectionDoneForCandidates();
        public void ElectionDoneForUsers();
    }
}
