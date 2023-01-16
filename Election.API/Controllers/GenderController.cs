using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly ISharedService<Egender> _sharedService;

        public GenderController(ISharedService<Egender> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Egender Create(Egender egender)
        {
            return _sharedService.Create(egender);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Egender> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Egender GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Egender Update(Egender egender)
        {
            return _sharedService.Update(egender);
        }
    }
}
