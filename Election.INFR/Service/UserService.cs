using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class UserService : ISharedService<Euser>, IRegisterService
    {
        private readonly ISharedRepository<Euser> _sharedRepository;
        private readonly IRegisterRepository _registerRepository;

        public UserService(ISharedRepository<Euser> sharedRepository, IRegisterRepository registerRepository)
        {
            _sharedRepository = sharedRepository;
            _registerRepository = registerRepository;
        }
        public Euserinformation Register(decimal ssn)
        {
            return _registerRepository.Register(ssn);
        }


        public Euser Create(Euser euser)
        {
            return _sharedRepository.Create(euser);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Euser> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Euser GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Euser Update(Euser euser)
        {
            return _sharedRepository.Update(euser);
        }
    }
}
