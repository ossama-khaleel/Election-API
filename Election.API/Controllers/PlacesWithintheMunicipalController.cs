using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesWithintheMunicipalController : ControllerBase
    {
        private readonly ISharedService<Eplaceswithinthemunicipal> _sharedService;
        private readonly ISharedService<Emunicipalstatus> _municipalstatus;
        private readonly IPlacesWithInTheMunicipalService _placesWithInTheMunicipalService;
        public PlacesWithintheMunicipalController(ISharedService<Eplaceswithinthemunicipal> sharedService, IPlacesWithInTheMunicipalService placesWithInTheMunicipalService, ISharedService<Emunicipalstatus> municipalstatus)
        {
            _sharedService = sharedService;
            _placesWithInTheMunicipalService = placesWithInTheMunicipalService;
            _municipalstatus = municipalstatus;
        }
        [HttpGet]
        [Route("UserMunicipal/{id}")]
        public Emunicipalstatus UserMunicipal(int id)
        {
            try { 
            var mini = _placesWithInTheMunicipalService.UserMunicipal(id);
            return _municipalstatus.GetById((int)mini.Municipalstatusid);
            }
            catch
            {
                return null;
            }
        }
        [HttpPost]
        public Eplaceswithinthemunicipal Create(Eplaceswithinthemunicipal eplaceswithinthemunicipal)
        {
            return _sharedService.Create(eplaceswithinthemunicipal);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Eplaceswithinthemunicipal> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Eplaceswithinthemunicipal GetById(int id)
        {
            return _sharedService.GetById(id);
        }

        [HttpPut]
        public Eplaceswithinthemunicipal Update(Eplaceswithinthemunicipal eplaceswithinthemunicipal)
        {
            return _sharedService.Update(eplaceswithinthemunicipal);
        }
    }
}
