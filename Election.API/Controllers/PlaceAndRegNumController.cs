using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceAndRegNumController : ControllerBase
    {
        private readonly ISharedService<Eplaceandregnum> _sharedService;

        public PlaceAndRegNumController(ISharedService<Eplaceandregnum> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Eplaceandregnum Create(Eplaceandregnum eplaceandregnum)
        {
            return _sharedService.Create(eplaceandregnum);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Eplaceandregnum> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Eplaceandregnum GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Eplaceandregnum Update(Eplaceandregnum eplaceandregnum)
        {
            return _sharedService.Update(eplaceandregnum);
        }
    }
}
