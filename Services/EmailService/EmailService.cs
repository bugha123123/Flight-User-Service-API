using BookFlight.Model.DBO;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace BookFlight.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async void SendEmail(EmailDTO request)
        {
           
            var Email = new MimeMessage();
            Email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            Email.To.Add(MailboxAddress.Parse(request.To));
            Email.Subject = "Verification Code";
            Email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = request.body };

            using var smtp = new SmtpClient();

        await    smtp.ConnectAsync(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);

            // only needed if the SMTP server requires authentication
        await    smtp.AuthenticateAsync(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);

         await   smtp.SendAsync(Email);
        await    smtp.DisconnectAsync(true);

           
        }



        // not using ver gamoviyene da frontze vagenerireb codes
        private string GenerateSecurityCode(int length)
        {
            var buffer = new byte[sizeof(UInt64)];
            var cryptoRng = new RNGCryptoServiceProvider();
            cryptoRng.GetBytes(buffer);
            var num = BitConverter.ToUInt64(buffer, 0);
            var code = num % (UInt64)Math.Pow(10, length);
            return code.ToString("D" + length);
        }




    }
}
