using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class PlaceOfReleaseService : ISharedService<Eplaceofrelease>
    {
        private readonly ISharedRepository<Eplaceofrelease> _sharedRepository;

        public PlaceOfReleaseService(ISharedRepository<Eplaceofrelease> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Eplaceofrelease Create(Eplaceofrelease eplaceofrelease)
        {
            return _sharedRepository.Create(eplaceofrelease);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Eplaceofrelease> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Eplaceofrelease GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Eplaceofrelease Update(Eplaceofrelease eplaceofrelease)
        {
            return _sharedRepository.Update(eplaceofrelease);
        }
    }
}
