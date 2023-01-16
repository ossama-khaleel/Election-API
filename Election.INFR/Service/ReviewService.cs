using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class ReviewService : ISharedService<Ereview>
    {
        private readonly ISharedRepository<Ereview> _sharedRepository;

        public ReviewService(ISharedRepository<Ereview> sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public Ereview Create(Ereview ereview)
        {
            return _sharedRepository.Create(ereview);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Ereview> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Ereview GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Ereview Update(Ereview ereview)
        {
            return _sharedRepository.Update(ereview);
        }
    }
}
