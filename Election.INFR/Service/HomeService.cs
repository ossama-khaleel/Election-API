using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class HomeService : ISharedService<Ehome>
    {
        private readonly ISharedRepository<Ehome> _sharedRepository;

        public HomeService(ISharedRepository<Ehome> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Ehome Create(Ehome ehome)
        {
            return _sharedRepository.Create(ehome);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Ehome> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Ehome GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Ehome Update(Ehome ehome)
        {
            return _sharedRepository.Update(ehome);
        }
    }
}
