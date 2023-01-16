using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class UserInformationService : ISharedService<Euserinformation>
    {
        private readonly ISharedRepository<Euserinformation> _sharedRepository;

        public UserInformationService(ISharedRepository<Euserinformation> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Euserinformation Create(Euserinformation euserinformation)
        {
            return _sharedRepository.Create(euserinformation);    
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);   
        }

        public List<Euserinformation> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Euserinformation GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Euserinformation Update(Euserinformation euserinformation)
        {
            return _sharedRepository.Update(euserinformation);
        }
    }
}
