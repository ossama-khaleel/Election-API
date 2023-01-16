using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypeController : ControllerBase
    {
        private readonly ISharedService<Ebloodtype> _sharedService;
        //anood
        public BloodTypeController(ISharedService<Ebloodtype> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Ebloodtype Create(Ebloodtype ebloodtype)
        {
            return _sharedService.Create(ebloodtype);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Ebloodtype> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Ebloodtype GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Ebloodtype Update(Ebloodtype ebloodtype)
        {
            return _sharedService.Update(ebloodtype);
        }
    }
}
