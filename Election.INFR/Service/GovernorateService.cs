using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class GovernorateService : ISharedService<Egovernorate>
    {
        private readonly ISharedRepository<Egovernorate> _sharedRepository;

        public GovernorateService(ISharedRepository<Egovernorate> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Egovernorate Create(Egovernorate egovernorate)
        {
            return _sharedRepository.Create(egovernorate);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Egovernorate> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Egovernorate GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Egovernorate Update(Egovernorate egovernorate)
        {
            return _sharedRepository.Update(egovernorate);
        }
    }
}
