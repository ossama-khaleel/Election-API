using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOfReleaseController : ControllerBase
    {
        private readonly ISharedService<Eplaceofrelease> _sharedService;

        public PlaceOfReleaseController(ISharedService<Eplaceofrelease> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Eplaceofrelease Create(Eplaceofrelease eplaceofrelease)
        {
            return _sharedService.Create(eplaceofrelease);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Eplaceofrelease> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Eplaceofrelease GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Eplaceofrelease Update(Eplaceofrelease eplaceofrelease)
        {
            return _sharedService.Update(eplaceofrelease);
        }
    }
}
