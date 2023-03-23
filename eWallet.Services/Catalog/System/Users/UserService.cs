using eWallet.Data.Entities;
using eWallet.Services.Catalog.System.Users.Dtos;
using eWallet.Services.Dtos.Respones;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eWallet.Services.Catalog.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<AuthRespone> Authencate(LoginRequest repuest)
        {
            AuthRespone respone = new AuthRespone();
            respone.token = "";
            respone.data = new UserRes();
            respone.message = "";
            var user = await _userManager.FindByNameAsync(repuest.UserName);
            if (user == null)
            {
                respone.message = "Not found user name";
                return respone;
            }
            var result = await _signInManager.PasswordSignInAsync(user, repuest.Password, repuest.RememberMe, true);
            if (!result.Succeeded)
            {
                respone.message = "Password not correct";
                return respone;
            }
            respone.data.FirstName = user.FristName;
            respone.data.LastName = user.FristName;
            respone.data.UserName= user.UserName;
            respone.data.CreateDate = user.CreatedDate.ToString();
            respone.data.Email= user.Email;
            respone.data.Phone = user.PhoneNumber;
            var roles = await _userManager.GetRolesAsync(user);
            var fullName = user.FristName + user.LastName;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, repuest.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, fullName),
                new Claim(ClaimTypes.Role, string.Join(";", roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: creds);
            respone.token = new JwtSecurityTokenHandler().WriteToken(token);
            return respone;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            if (!request.Password.Equals(request.ConfirmPassword))
                return false;
            var user = new AppUser()
            {
                CreatedDate = request.CreatedDate,
                Email = request.Email,
                UserName = request.UserName,
                FristName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return false;
            return true;
        }
    }
}
