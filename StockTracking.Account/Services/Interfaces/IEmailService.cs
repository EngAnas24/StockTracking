using Microsoft.AspNetCore.Http;

namespace StockTracking.Account.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
        string GenerateEmailConfirmationLink(string userId, string token, HttpRequest request);
        string GeneratePasswordResetLink(string email, string encodedToken, HttpRequest request);
    }
}
