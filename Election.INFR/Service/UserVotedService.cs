using Election.CORE.Data;
using Election.CORE.DTO;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class UserVotedService : ISharedService<Euservoted> , IUserVotedService
    {
        private readonly ISharedRepository<Euservoted> _sharedRepository;
        private readonly IUserVotedRepository _userVotedRepository;

        public UserVotedService(ISharedRepository<Euservoted> sharedRepository, IUserVotedRepository userVotedRepository)
        {
            _sharedRepository = sharedRepository;
            _userVotedRepository = userVotedRepository;
        }

        public List<Chart> Chart()
        {
            return _userVotedRepository.Chart();
        }

        public Euservoted Create(Euservoted euservoted)
        {
            return _sharedRepository.Create(euservoted);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Euservoted> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Euservoted GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public List<TotalVotes> TotalVotes()
        {
            return _userVotedRepository.TotalVotes();
        }

        public Euservoted Update(Euservoted euservoted)
        {
            return _sharedRepository.Update(euservoted);
        }
    }
}
