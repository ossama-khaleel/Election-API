using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        private readonly ISharedService<Euserinformation> _sharedService;
        private readonly ISharedService<Euser> _sharedService1;

        public UserInformationController(ISharedService<Euserinformation> sharedService, ISharedService<Euser> sharedService1)
        {
            _sharedService = sharedService;
            _sharedService1 = sharedService1;
        }
        [HttpPost]
        public Euserinformation Create(Euserinformation euserinformation)
        {
            return _sharedService.Create(euserinformation);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Euserinformation> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Euserinformation GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpGet]
        [Route("getuser/{id}")]
        public Euserinformation GetUser(int id)
        {
            var user = _sharedService1.GetById(id);
            return _sharedService.GetById((int)user.Userinfoid);
        }
        [HttpPut]
        public Euserinformation Update(Euserinformation euserinformation)
        {
            return _sharedService.Update(euserinformation);
        }
    }
}
