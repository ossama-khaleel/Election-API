using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Election.INFR.Service
{
    public class MunicipalStatusService : ISharedService<Emunicipalstatus>, IMunicipalStatusService
    {
        private readonly ISharedRepository<Emunicipalstatus> _sharedRepository;
        private readonly IMunicipalStatusRepository _municipalStatusRepository;

        public MunicipalStatusService(ISharedRepository<Emunicipalstatus> sharedRepository, IMunicipalStatusRepository municipalStatusRepository)
        {
            _sharedRepository = sharedRepository;
            _municipalStatusRepository = municipalStatusRepository;
        }

        public Emunicipalstatus Create(Emunicipalstatus emunicipalstatus)
        {
            return _sharedRepository.Create(emunicipalstatus);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Emunicipalstatus> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Emunicipalstatus GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public List<Emunicipalstatus> GetMuniByCatId(int id)
        {
            return this.GetAll().Where(x => x.Governorateid == id).ToList();
        }

        public List<Emunicipalstatus> Search(string name)
        {
           return  _municipalStatusRepository.Search(name);
        }

        public Emunicipalstatus Update(Emunicipalstatus emunicipalstatus)
        {
            return _sharedRepository.Update(emunicipalstatus);
        }

        
    }
}
