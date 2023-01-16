using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVoteController : ControllerBase
    {
        private readonly ISharedService<Euservote> _sharedService;

        public UserVoteController(ISharedService<Euservote> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Euservote Create(Euservote euservote)
        {
            return _sharedService.Create(euservote);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Euservote> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Euservote GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpGet]
        [Route("GetByUserId/{id}")]
        public Euservote GetByUserId(int id)
        {
            return GetAll().Where(x => x.Userid == id).FirstOrDefault();
        }
        [HttpPut]
        public Euservote Update(Euservote euservote)
        {
            return _sharedService.Update(euservote);
        }
    }
}
