using LoginAPI_Tutorial.Interfaces;
using LoginAPI_Tutorial.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace LoginAPI_Tutorial.Services
{
    public class NotificationService : INotificationService
    {
        //Send general Email
        public async Task<bool> SendEmailAsync(string email, string password)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sendinblue.com/v3/smtp/email");
                request.Headers.Add("accept", "application/json");
                request.Headers.Add("api-key", "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");

                var sender = new Sender() { Email = "fefer7010@gmail.com", Name = "Nachman" };
                List<To> tos = new List<To> { new To() { Email = email } };

                var otpEmail = new OTPEmail() { };
                otpEmail.Subject = "Login To My App";
                otpEmail.Sender = sender;
                otpEmail.To = tos;
                otpEmail.HtmlContent = $@"<html><head></head><body><p>Hello,</p>Your OTP Number Is <b>{password}</b></p></body></html>";

                var content = new StringContent(JsonConvert.SerializeObject(otpEmail), null, "application/json");

                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                return false;

                throw;
            }
            return true;
        }
    }
}
