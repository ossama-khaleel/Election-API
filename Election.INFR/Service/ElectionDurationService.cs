using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class ElectionDurationService : ISharedService<Eelectionduration>
    {
        private readonly ISharedRepository<Eelectionduration> _sharedRepository;

        public ElectionDurationService(ISharedRepository<Eelectionduration> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Eelectionduration Create(Eelectionduration eelectionduration)
        {
            return _sharedRepository.Create(eelectionduration);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Eelectionduration> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Eelectionduration GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Eelectionduration Update(Eelectionduration eelectionduration)
        {
            return _sharedRepository.Update(eelectionduration);
        }
    }
}
