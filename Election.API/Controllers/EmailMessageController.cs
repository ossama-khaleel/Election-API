using Election.CORE.Data;
using Election.CORE.Service;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Election.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailMessageController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly IEmailVerifyingService _emailVerifyingService;

        public EmailMessageController(IEmailSender emailSender, IEmailVerifyingService emailVerifyingService)
        {
            _emailSender = emailSender;
            _emailVerifyingService = emailVerifyingService;
        }
        [HttpGet]
        [Route("Emailverifying/{id}")]
        public void Emailverifying(int id)
        {
            _emailVerifyingService.Verifying(id);
        }
        [HttpPost]
        [Route("EmailSender")]
        public void EmailSender(IdWithEmail idWithEmail) 
        {
            var message = new Message(new string[] { $"{idWithEmail.Email}" }, "Please Enter The Link To Verify Your Account", $"https://localhost:44383/api/EmailMessage/Emailverifying/{idWithEmail.Id}");
            _emailSender.SendEmail(message);
        }
    }
}
