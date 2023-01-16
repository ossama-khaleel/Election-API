using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class RoleService : ISharedService<Erole>
    {
        private readonly ISharedRepository<Erole> _sharedRepository;

        public RoleService(ISharedRepository<Erole> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Erole Create(Erole erole)
        {
            return _sharedRepository.Create(erole); 
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);   
        }

        public List<Erole> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Erole GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Erole Update(Erole erole)
        {
            return _sharedRepository.Update(erole);
        }
    }
}
