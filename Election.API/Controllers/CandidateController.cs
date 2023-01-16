using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ISharedService<Ecandidate> _sharedService;
        private readonly ICandidateService _candidateService;
        //osamsaadsafca

        public CandidateController(ISharedService<Ecandidate> sharedService, ICandidateService candidateService)
        {
            _sharedService = sharedService;
            _candidateService = candidateService;
        }
        [HttpPost]
        public Ecandidate Create(Ecandidate ecandidate)
        {
            return _sharedService.Create(ecandidate);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
      
        public List<Ecandidate> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetCandidates/{userId}/{catId}")]
        public List<Ecandidate> GetCandidates(int userId, int catId)
        {
            return _candidateService.GetCandidates(userId, catId);
        }
        [HttpGet]
        [Route("GetCandidateForUser/{userId}/{catId}")]
        public List<Ecandidate> GetCandidatesForUser(int userId, int catId)
        {
            return _candidateService.GetCandidatesForUser(userId, catId);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Ecandidate GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Ecandidate Update(Ecandidate ecandidate)
        {
            return _sharedService.Update(ecandidate);
        }
        [HttpGet]
        [Route("ElectionDoneForCandidates")]
        public void ElectionDoneForCandidates() {
            _candidateService.ElectionDoneForCandidates();
        } 
        [HttpGet]
        [Route("ElectionDoneForUsers")]
        public void ElectionDoneForUsers() {
            _candidateService.ElectionDoneForUsers();
        }
        //[HttpGet]
        //[Route("Test/{id}")]
        //public string Test(int id)
        //{
        //    var test=  _sharedService.GetById(id);
        //    return test.Des;
        //}
    }
}
