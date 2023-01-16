using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISharedService<Ehome> _sharedService;
        public HomeController(ISharedService<Ehome> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Ehome Create(Ehome ehome)
        {
            return _sharedService.Create(ehome);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Ehome> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Ehome GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Ehome Update(Ehome ehome)
        {
            return _sharedService.Update(ehome);
        }
    }
}
