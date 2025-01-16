using AuthAPI.Services.Dto;

namespace AuthAPI.Services.IAuthService
{
    public interface IAuth
    {
        Task<string> Register(RegisterRequestDto registerRequestDto);
    }
}
