using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionDurationController : ControllerBase
    {
        private readonly ISharedService<Eelectionduration> _sharedService;

        public ElectionDurationController(ISharedService<Eelectionduration> sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpPost]
        public Eelectionduration Create(Eelectionduration eelectionduration)
        {
            return _sharedService.Create(eelectionduration);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        
        public List<Eelectionduration> GetAll()
        {
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Eelectionduration GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Eelectionduration Update(Eelectionduration eelectionduration)
        {
            
            if (eelectionduration.EndTime != null) 
            {
                double x = Int32.Parse(eelectionduration.EndTime.Substring(0, 2));
                double y = Int32.Parse(eelectionduration.EndTime.Substring(3));
                DateTime xx = DateTime.Parse(eelectionduration.Electionenddate.Value.ToShortDateString());
                DateTime xxx = xx.AddMinutes(y).AddHours(x);
                eelectionduration.Electionenddate = xxx;
                
            }
            if (eelectionduration.StartTime != null)
            {
                double x = Int32.Parse(eelectionduration.StartTime.Substring(0, 2));
                double y = Int32.Parse(eelectionduration.StartTime.Substring(3));
                DateTime xx = DateTime.Parse(eelectionduration.Electionstartdate.Value.ToShortDateString());
                DateTime xxx = xx.AddMinutes(y).AddHours(x);
                eelectionduration.Electionstartdate = xxx;
            }
            
            return _sharedService.Update(eelectionduration);
        }
    }
}
