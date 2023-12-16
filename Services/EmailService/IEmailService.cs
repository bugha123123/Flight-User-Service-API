using BookFlight.Model.DBO;
using Microsoft.AspNetCore.Mvc;

namespace BookFlight.Services.EmailService
{
    public interface IEmailService
    {

        void SendEmail(EmailDTO request);

   
    }
}
