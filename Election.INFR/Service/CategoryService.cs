using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class CategoryService : ISharedService<Ecategory>, ICategoryService
    {
        private readonly ISharedRepository<Ecategory> _sharedRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ISharedRepository<Ecategory> sharedRepository, ICategoryRepository categoryRepository)
        {
            _sharedRepository = sharedRepository;
            _categoryRepository = categoryRepository;
        }

        public Ecategory Create(Ecategory ecategory)
        {
            return _sharedRepository.Create(ecategory); 
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);   
        }

        public List<Ecategory> GetAll()
        {
           return _sharedRepository.GetAll();
        }

        public Ecategory GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public List<Ecategory> Search(string name)
        {
            return _categoryRepository.Search(name);    
        }

        public Ecategory Update(Ecategory ecategory)
        {
            return _sharedRepository.Update(ecategory);
        }
    }
}
