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
    public class AboutuController : ControllerBase
    {
        private readonly ISharedService<Eaboutu> _sharedService;

        public AboutuController(ISharedService<Eaboutu> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Eaboutu Create(Eaboutu eaboutu)
        {
            return _sharedService.Create(eaboutu);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Eaboutu> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Eaboutu GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Eaboutu Update(Eaboutu eaboutu)
        {
            return _sharedService.Update(eaboutu);
        }
    }
}
