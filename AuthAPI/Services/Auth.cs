using AuthAPI.Datas;
using AuthAPI.Models;
using AuthAPI.Services.Dto;
using AuthAPI.Services.IAuthService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace AuthAPI.Services
{
    public class Auth : IAuth
    {
        private readonly Appdbcontext _appdbcontext;
        private readonly UserManager<ApplicationUser> _userManager;

        public Auth(Appdbcontext appdbcontext, UserManager<ApplicationUser> userManager)
        {
            _appdbcontext = appdbcontext;
            _userManager = userManager;
        }

        public async Task<string> Register(RegisterRequestDto registerRequestDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Email,
                BirthDate = registerRequestDto.BirthDate,
            };

            var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

            if (result.Succeeded)
            {
                var userReturn = await _appdbcontext.applicationUsers.FirstOrDefaultAsync(q => q.UserName == registerRequestDto.Username);
            }
            return "";
        }
    }
}
