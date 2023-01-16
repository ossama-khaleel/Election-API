using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ISharedService<Erole> _sharedService;

        public RoleController(ISharedService<Erole> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Erole Create(Erole erole)
        {
            return _sharedService.Create(erole);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Erole> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Erole GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Erole Update(Erole erole)
        {
            return _sharedService.Update(erole);
        }
    }
}
