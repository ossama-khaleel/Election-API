using Election.CORE.Data;
using Election.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IJWTService _jWTService;

        public JWTController(IJWTService jWTService)
        {
            _jWTService = jWTService;
        }
        [HttpPost]
        [Route("Login")]
        public string Auth(Euser euser) 
        {
            var token = _jWTService.Auth(euser);
            if (token == null)
            {
                return "NotFound";
            }
            else if (token == "0")
            {
                return "0";
            }
            else {
                return token;
            }
        }
    }
}
