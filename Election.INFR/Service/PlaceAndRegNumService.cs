using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class PlaceAndRegNumService : ISharedService<Eplaceandregnum>
    {
        private readonly ISharedRepository<Eplaceandregnum> _sharedRepository;

        public PlaceAndRegNumService(ISharedRepository<Eplaceandregnum> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Eplaceandregnum Create(Eplaceandregnum eplaceandregnum)
        {
            return _sharedRepository.Create(eplaceandregnum);    
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);   
        }

        public List<Eplaceandregnum> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Eplaceandregnum GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Eplaceandregnum Update(Eplaceandregnum eplaceandregnum)
        {
            return _sharedRepository.Update(eplaceandregnum);
        }
    }
}
