using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class AboutService :ISharedService<Eabout>, IAboutService
    {
        private readonly ISharedRepository<Eabout> _sharedRepository;
        private readonly IAboutRepository _aboutRepository;

        public AboutService(ISharedRepository<Eabout> sharedRepository, IAboutRepository aboutRepository)
        {
            _sharedRepository = sharedRepository;
            _aboutRepository = aboutRepository;
        }

        public Eabout Create(Eabout eabout)
        {
            return _sharedRepository.Create(eabout);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Eabout> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Eabout GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Eabout GetById1()
        {
            return _aboutRepository.GetById1();
        }
        public Eabout GetById2()
        {
            return _aboutRepository.GetById2();
        }
        public Eabout GetById3()
        {
            return _aboutRepository.GetById3();
        }
        public Eabout GetById4()
        {
            return _aboutRepository.GetById4();
        }

        public Eabout Update(Eabout eabout)
        {
            return _sharedRepository.Update(eabout);
        }
    }
}
