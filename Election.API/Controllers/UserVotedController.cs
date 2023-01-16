using Election.CORE.Data;
using Election.CORE.DTO;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVotedController : ControllerBase
    {
        private readonly ISharedService<Euservoted> _sharedService;
        private readonly IUserVotedService _userVotedService;

        public UserVotedController(ISharedService<Euservoted> sharedService, IUserVotedService userVotedService)
        {
            _sharedService = sharedService;
            _userVotedService = userVotedService;
        }
        [HttpPost]
        public Euservoted Create(Euservoted euservoted)
        {
            euservoted.Votedate = DateTime.Now;
            return _sharedService.Create(euservoted);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Euservoted> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Euservoted GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Euservoted Update(Euservoted euservoted)
        {
            return _sharedService.Update(euservoted);
        }
        [HttpGet]
        [Route("TotalVotes")]
        public List<TotalVotes> TotalVotes()
        {
           return _userVotedService.TotalVotes();
        }
        [HttpGet]
        [Route("Chart")]
        public List<Chart> Chart()
        {
            return _userVotedService.Chart();
        }
    }
}
