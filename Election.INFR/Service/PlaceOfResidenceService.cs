using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class PlaceOfResidenceService : ISharedService<Eplaceofresidence>
    {
        private readonly ISharedRepository<Eplaceofresidence> _sharedRepository;

        public PlaceOfResidenceService(ISharedRepository<Eplaceofresidence> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Eplaceofresidence Create(Eplaceofresidence eplaceofresidence)
        {
            return _sharedRepository.Create(eplaceofresidence);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Eplaceofresidence> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Eplaceofresidence GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Eplaceofresidence Update(Eplaceofresidence eplaceofresidence)
        {
            return _sharedRepository.Update(eplaceofresidence);
        }
    }
}
