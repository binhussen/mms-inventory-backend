using DataModel.Models.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace DataModel.Identity.Services
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<AuthenticationResponse> CreateToken();
        Task<SignInResult> Login(UserForAuthenticationDto user);
    }
}
