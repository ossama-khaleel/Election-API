using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ISharedService<Ecategory> _sharedService;
        private readonly ICategoryService _categoryService;

        public CategoryController(ISharedService<Ecategory> sharedService, ICategoryService categoryService)
        {
            _sharedService = sharedService;
            _categoryService = categoryService;
        }
        [HttpPost]
        public Ecategory Create(Ecategory ecategory)
        {
            return _sharedService.Create(ecategory);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Ecategory> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Ecategory GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Ecategory Update(Ecategory ecategory)
        {
            return _sharedService.Update(ecategory);
        }
        [HttpGet]
        [Route("Search/{name}")]
        public List<Ecategory> Search(string name)
        {
            return _categoryService.Search(name);
        }
    }
}
