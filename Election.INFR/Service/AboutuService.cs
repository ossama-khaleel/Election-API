using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class AboutuService : ISharedService<Eaboutu>
    {
        private readonly ISharedRepository<Eaboutu> _sharedRepository;

        public AboutuService(ISharedRepository<Eaboutu> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Eaboutu Create(Eaboutu eaboutu)
        {
            return _sharedRepository.Create(eaboutu);
        }

        public void Delete(int id)
        {
           _sharedRepository.Delete(id);
        }

        public List<Eaboutu> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Eaboutu GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Eaboutu Update(Eaboutu eaboutu)
        {
            return _sharedRepository.Update(eaboutu);
        }
    }
}
