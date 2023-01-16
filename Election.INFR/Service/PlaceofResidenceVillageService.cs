using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class PlaceofResidenceVillageService : ISharedService<Eplaceofresidencevillage>
    {
        private readonly ISharedRepository<Eplaceofresidencevillage> _sharedRepository;

        public PlaceofResidenceVillageService(ISharedRepository<Eplaceofresidencevillage> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Eplaceofresidencevillage Create(Eplaceofresidencevillage eplaceofresidencevillage)
        {
            return _sharedRepository.Create(eplaceofresidencevillage);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Eplaceofresidencevillage> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Eplaceofresidencevillage GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Eplaceofresidencevillage Update(Eplaceofresidencevillage eplaceofresidencevillage)
        {
            return _sharedRepository.Update(eplaceofresidencevillage);
        }
    }
}
