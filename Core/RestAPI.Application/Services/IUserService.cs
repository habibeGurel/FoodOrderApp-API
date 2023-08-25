using Microsoft.AspNetCore.Mvc;
using RestAPI.Application.ViewModels.Users;
using RestAPI.Core.Services;
using System.Threading.Tasks;

namespace RestAPI.Application.Services { 
public interface IUserService
{
    Task<RegistrationResult> RegisterUserAsync(RegisterViewModel model);
    Task<LoginResult> LoginUserAsync([FromBody] LoginViewModel model);
    Task<RegisterViewModel> GetUserProfileAsync(string username);

    }

    public class RegistrationResult
{
    public bool Success { get; }
    public List<string> Errors { get; }

    public RegistrationResult(bool success, List<string> errors)
    {
        Success = success;
        Errors = errors;
    }
}
}
