using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceofResidenceVillageController : ControllerBase
    {
        private readonly ISharedService<Eplaceofresidencevillage> _sharedService;

        public PlaceofResidenceVillageController(ISharedService<Eplaceofresidencevillage> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Eplaceofresidencevillage Create(Eplaceofresidencevillage eplaceofresidencevillage)
        {
            return _sharedService.Create(eplaceofresidencevillage);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Eplaceofresidencevillage> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Eplaceofresidencevillage GetById(int id)
        {
            return _sharedService.GetById(id);
        }

        [HttpPut]
        public Eplaceofresidencevillage Update(Eplaceofresidencevillage eplaceofresidencevillage)
        {
            return _sharedService.Update(eplaceofresidencevillage);
        }
    }
}
