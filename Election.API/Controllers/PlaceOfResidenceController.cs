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
    public class PlaceOfResidenceController : ControllerBase
    {
        private readonly ISharedService<Eplaceofresidence> _sharedService;
            
        public PlaceOfResidenceController(ISharedService<Eplaceofresidence> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Eplaceofresidence Create(Eplaceofresidence eplaceofresidence)
        {
            return _sharedService.Create(eplaceofresidence);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Eplaceofresidence> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Eplaceofresidence GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Eplaceofresidence Update(Eplaceofresidence eplaceofresidence)
        {
            return _sharedService.Update(eplaceofresidence);
        }
    }
}
