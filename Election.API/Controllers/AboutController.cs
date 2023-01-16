
using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly ISharedService<Eabout> _sharedService;
        private readonly IAboutService _aboutService;

        public AboutController(ISharedService<Eabout> sharedService, IAboutService aboutService)
        {
            _sharedService = sharedService;
            _aboutService = aboutService;
        }

        [HttpGet]
        public Eabout Create(Eabout eabout)
        {
            return _sharedService.Create(eabout);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Eabout> GetAll()
        {
            return _sharedService.GetAll();
        }

        public Eabout GetById(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("GetByid1")]
        public Eabout GetById1()
        {
            return _aboutService.GetById1();
        }
        [HttpGet]
        [Route("GetByid2")]
        public Eabout GetById2()
        {
            return _aboutService.GetById2();
        }
        [HttpGet]
        [Route("GetByid3")]
        public Eabout GetById3()
        {
            return _aboutService.GetById3();
        }
        [HttpGet]
        [Route("GetByid4")]
        public Eabout GetById4()
        {
            return _aboutService.GetById4();
        }

        public Eabout Update(Eabout eabout)
        {
            return _sharedService.Update(eabout);
        }
    }
}
