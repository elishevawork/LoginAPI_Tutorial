namespace LoginAPI_Tutorial.Interfaces
{
    public interface INotificationService
    {
        Task<bool> SendEmailAsync(string email, string password);
        //Task<bool> SendSmsAsync();
    }
}
