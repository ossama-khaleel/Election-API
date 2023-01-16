using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class BloodTypeService : ISharedService<Ebloodtype>
    {
        private readonly ISharedRepository<Ebloodtype> _sharedRepository;

        public BloodTypeService(ISharedRepository<Ebloodtype> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Ebloodtype Create(Ebloodtype ebloodtype)
        {
            return _sharedRepository.Create(ebloodtype);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Ebloodtype> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Ebloodtype GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Ebloodtype Update(Ebloodtype ebloodtype)
        {
            return _sharedRepository.Update(ebloodtype);
        }
    }
}
