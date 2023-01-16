using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   
        private readonly ISharedService<Euser> _sharedService;
        private readonly IRegisterService _registerService;
        
        public UserController(ISharedService<Euser> sharedService, IRegisterService registerService)
        {
            _sharedService = sharedService;
            _registerService = registerService;
           
        }
        [HttpGet]
        [Route("reg/{ssn}")]
        public Euserinformation Register(decimal ssn)
        {
            return _registerService.Register(ssn);
        }
        [HttpPost]
        public Euser Create(Euser euser)
        {
            return _sharedService.Create(euser);
        }
        [HttpPost]
        [Route("UploadImage")]
        public Euser UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("D:\\GitHubAngular\\angular\\src\\assets\\img", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Euser euser = new Euser();
                euser.Userimagepath = fileName;
                return euser;
            }
            catch (Exception e)
            {
                return null;
            }
        }




        [HttpPost]
        [Route("UploadImage1")]
        public Euser UploadImage1()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("D:\\ayman\\Tahaluf\\FINAL-PROJECT\\angular\\Base-Project\\Election\\src\\assets\\img", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Euser euser = new Euser();
                euser.Userimagepath = fileName;
                return euser;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("UploadImage2")]
        public Euser UploadImage2()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("D:\\ayman\\Tahaluf\\FINAL-PROJECT\\angular\\Base-Project\\Election\\src\\assets\\img", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Euser euser = new Euser();
                euser.Userimagepath = fileName;
                return euser;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("UploadImage3")]
        public Euser UploadImage3()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("D:\\ayman\\Tahaluf\\FINAL-PROJECT\\angular\\Base-Project\\Election\\src\\assets\\img", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Euser euser = new Euser();
                euser.Userimagepath = fileName;
                return euser;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _sharedService.Delete(id);
        }
        [HttpGet]
        public List<Euser> GetAll()
        {
            
            return _sharedService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Euser GetById(int id)
        {
            return _sharedService.GetById(id);
        }
        [HttpPut]
        public Euser Update(Euser euser)
        {
            return _sharedService.Update(euser);
        }
    }
}
