using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class GenderService : ISharedService<Egender>
    {
        private readonly ISharedRepository<Egender> _sharedRepository;

        public GenderService(ISharedRepository<Egender> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Egender Create(Egender egender)
        {
            return _sharedRepository.Create(egender);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Egender> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Egender GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Egender Update(Egender egender)
        {
            return _sharedRepository.Update(egender);
        }
    }
}
