using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController : ControllerBase
    {
        private readonly ISharedService<Egovernorate> _sharedService;

        public GovernorateController(ISharedService<Egovernorate> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Egovernorate Create(Egovernorate egovernorate)
        {
            return _sharedService.Create(egovernorate);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Egovernorate> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Egovernorate GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Egovernorate Update(Egovernorate egovernorate)
        {
            return _sharedService.Update(egovernorate);
        }
    }
}
