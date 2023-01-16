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
    public class MunicipalStatusController : ControllerBase
    {
        private readonly ISharedService<Emunicipalstatus> _sharedService;
        private readonly IMunicipalStatusService _municipalStatusService;

        public MunicipalStatusController(ISharedService<Emunicipalstatus> sharedService, IMunicipalStatusService municipalStatusService)
        {
            _sharedService = sharedService;
            _municipalStatusService = municipalStatusService;
     
        }
        [HttpGet]
        [Route("Search/{name}")]
        public List<Emunicipalstatus> Search(string name)
        {
            return _municipalStatusService.Search(name);
        }
        [HttpPost]
        public Emunicipalstatus Create(Emunicipalstatus emunicipalstatus)
        {
            return _sharedService.Create(emunicipalstatus);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Emunicipalstatus> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Emunicipalstatus GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Emunicipalstatus Update(Emunicipalstatus emunicipalstatus)
        {
            return _sharedService.Update(emunicipalstatus);
        }
        [HttpGet]
        [Route("GetMuniByCatId/{id}")]
        public List<Emunicipalstatus> GetMuniByCatId(int id)
        {
            return _municipalStatusService.GetMuniByCatId((int)id);
        }
    }
}
