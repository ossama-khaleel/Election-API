using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class ContactuService : ISharedService<Econtactu>
    {
        private readonly ISharedRepository<Econtactu> _sharedRepository;

        public ContactuService(ISharedRepository<Econtactu> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Econtactu Create(Econtactu econtactu)
        {
            return _sharedRepository.Create(econtactu);
        }

        public void Delete(int id)
        {
           _sharedRepository.Delete(id);
        }

        public List<Econtactu> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Econtactu GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Econtactu Update(Econtactu econtactu)
        {
            return _sharedRepository.Update(econtactu);
        }
    }
}
