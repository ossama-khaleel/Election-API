using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateFormController : ControllerBase
    {
        private readonly ISharedService<Ecandidateform> _sharedService;

        public CandidateFormController(ISharedService<Ecandidateform> sharedService)
        {
            _sharedService = sharedService;
        }

        [HttpPost]
        public Ecandidateform Create(Ecandidateform ecandidateform)
        {
            return _sharedService.Create(ecandidateform);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        
        public List<Ecandidateform> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Ecandidateform GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Ecandidateform Update(Ecandidateform ecandidateform)
        {
            return _sharedService.Update(ecandidateform);
        }
    }
}
