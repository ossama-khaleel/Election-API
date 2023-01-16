using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ISharedService<Ereview> _sharedService;

        public ReviewController(ISharedService<Ereview> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Ereview Create(Ereview ereview)
        {
            return _sharedService.Create(ereview);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Ereview> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("Getstar/{id}")]
        public Ereview Getstar(int id)
        {
            return _sharedService.GetAll().Where(x=>x.Userid == id).FirstOrDefault();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Ereview GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Ereview Update(Ereview ereview)
        {
            return _sharedService.Update(ereview);
        }
    }
}
