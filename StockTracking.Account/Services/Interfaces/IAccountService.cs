using Microsoft.AspNetCore.Http;
using StockTracking.Account.Models;

namespace StockTracking.Account.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model, HttpRequest request);
        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        Task<AuthModel> ConfirmEmailAsync(string userId, string token);
        Task<string> GeneratePasswordResetTokenAsync(string email, HttpRequest request);
        Task<AuthModel> ResetPasswordAsync(ResetPasswordModel model);
        Task<AuthModel> LoginAsync(LoginModel loginModel);
        Task<AuthModel> LogoutAsync();
        Task<string> AddRoleAsync(AddRoleModel Rolemodel);

    }
}
