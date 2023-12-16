using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using BookFlight.Model.DBO;

namespace BookFlight.Controllers
{
    [Route("api/sendEmail")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public SendEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }





        [HttpPost]
        public  IActionResult SendEmail(EmailDTO request)
        {

            _emailService.SendEmail(request);


            return Ok();


        }


  



    }
}
