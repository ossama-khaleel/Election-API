using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class UserVoteService : ISharedService<Euservote>
    {
        private readonly ISharedRepository<Euservote> _sharedRepository;

        public UserVoteService(ISharedRepository<Euservote> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Euservote Create(Euservote euservote)
        {
            return _sharedRepository.Create(euservote);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Euservote> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Euservote GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Euservote Update(Euservote euservote)
        {
            return _sharedRepository.Update(euservote);
        }
    }
}
