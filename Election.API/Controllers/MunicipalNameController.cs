using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalNameController : ControllerBase
    {
        private readonly ISharedService<Emunicipalname> _sharedService;
        private readonly IMunicipalNameService _municipalNameService;

        public MunicipalNameController(ISharedService<Emunicipalname> sharedService, IMunicipalNameService municipalNameService)
        {
            _sharedService = sharedService;
            _municipalNameService = municipalNameService;
        }
        [HttpGet]
        [Route("Search/{name}")]
        public List<Emunicipalname> Search(string name)
        {
            return _municipalNameService.Search(name);
        }
        [HttpPost]
        public Emunicipalname Create(Emunicipalname emunicipalname)
        {
            return _sharedService.Create(emunicipalname);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Emunicipalname> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Emunicipalname GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Emunicipalname Update(Emunicipalname emunicipalname)
        {
            return _sharedService.Update(emunicipalname);
        }
    }
}
