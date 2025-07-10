using Application.Common.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Mail
{
    public class SMTPMailService : IMailService
    {
        private readonly SmtpSettings _settings;

        public SMTPMailService(IConfiguration configuration)
        {
            _settings = configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
        }

        public async Task SendVerificationEmail(string to, string token)
        {
            using var smtpClient = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = true
            };

            string emailTemplate = @"
                    <!DOCTYPE html>
                    <html lang='en'>
                    <head>
                      <meta charset='UTF-8'>
                      <title>Verify Your Account</title>
                      <style>
                        body {
                          background-color: #121212;
                          color: #e0e0e0;
                          font-family: Arial, sans-serif;
                          margin: 0;
                          padding: 0;
                        }
                        .container {
                          max-width: 600px;
                          margin: 40px auto;
                          background-color: #1e1e1e;
                          padding: 30px;
                          border-radius: 8px;
                          border: 2px solid #00ff88;
                        }
                        h1 {
                          color: #00ff88;
                          text-align: center;
                        }
                        p {
                          font-size: 16px;
                          line-height: 1.6;
                          color: white;
                        }

                        a {
                          color: black;
                        }

                        .button {
                          display: block;
                          width: fit-content;
                          margin: 30px auto;
                          padding: 14px 24px;
                          background-color: #00ff88;
                          color: black;
                          text-decoration: none;
                          font-weight: bold;
                          border-radius: 6px;
                        }
                        .footer {
                          text-align: center;
                          margin-top: 40px;
                          font-size: 12px;
                          color: #888;
                        }
                      </style>
                    </head>
                    <body>
                      <div class='container'>
                        <h1>Verify Your Email</h1>
                        <p>Hello,</p>
                        <p>Thank you for registering! To activate your account, please click the button below:</p>
                        <a href='https://localhost:8080/api/auth/verify/" + token + @"' class='button'>Verify Account</a>
                        <p>If you didn't create this account, you can ignore this message.</p>
                        <div class='footer'>
                          &copy; 2025 RateWise. All rights reserved.
                        </div>
                      </div>
                    </body>
                    </html>
                    ";

            var mail = new MailMessage(_settings.Username, to, "Verification", emailTemplate)
            {
                IsBodyHtml = true,
            };

            await smtpClient.SendMailAsync(mail);
        }
    }

}
