using Election.CORE.Data;
using Election.CORE.DTO;
using Election.CORE.Repository;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ISharedService<Etestimonial> _sharedService;
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ISharedService<Etestimonial> sharedService, ITestimonialService testimonialService)
        {
            _sharedService = sharedService;
            _testimonialService = testimonialService;
        }
        [HttpPost]
        public Etestimonial Create(Etestimonial etestimonial)
        {
            return _sharedService.Create(etestimonial);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Etestimonial> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Etestimonial GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Etestimonial Update(Etestimonial etestimonial)
        {
            return _sharedService.Update(etestimonial);
        }
        [HttpGet]
        [Route("homeTestimonials")]
        public List<HomeTestimonial> homeTestimonials()
        {
            return _testimonialService.homeTestimonials();
        }
    }
}
