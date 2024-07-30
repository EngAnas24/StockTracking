using System.Threading.Tasks;
using StockTracking.Account.Services.Interfaces;

namespace StockTracking.Account.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Implement your email sending logic here.
            // For example, using SMTP or a third-party service like SendGrid, etc.
            await Task.CompletedTask;
        }
    }
}
