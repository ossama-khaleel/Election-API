using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class MunicipalNameService : ISharedService<Emunicipalname>, IMunicipalNameService
    {
        private readonly ISharedRepository<Emunicipalname> _sharedRepository;
        private readonly IMunicipalNameRepository _municipalNameRepository;

        public MunicipalNameService(ISharedRepository<Emunicipalname> sharedRepository, IMunicipalNameRepository municipalNameRepository)
        {
            _sharedRepository = sharedRepository;
            _municipalNameRepository = municipalNameRepository;
        }

        public Emunicipalname Create(Emunicipalname emunicipalname)
        {
            return _sharedRepository.Create(emunicipalname);    
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);   
        }

        public List<Emunicipalname> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Emunicipalname GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public List<Emunicipalname> Search(string name)
        {
            return _municipalNameRepository.Search(name);
        }

        public Emunicipalname Update(Emunicipalname emunicipalname)
        {
            return _sharedRepository.Update(emunicipalname);
        }
    }
}
