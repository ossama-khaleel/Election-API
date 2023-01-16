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
    public class ContactuController : ControllerBase
    {
        private readonly ISharedService<Econtactu> _sharedService;
        public ContactuController(ISharedService<Econtactu> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Econtactu Create(Econtactu econtactu)
        {
            return _sharedService.Create(econtactu);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        
        public List<Econtactu> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Econtactu GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Econtactu Update(Econtactu econtactu)
        {
            return _sharedService.Update(econtactu);
        }
    }
}
