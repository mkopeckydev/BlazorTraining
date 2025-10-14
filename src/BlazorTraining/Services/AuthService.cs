using BlazorTraining.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BlazorTraining.Services
{
    public class AuthService
    {
        public const string RoleAdmin = "admin";
        public const string RoleUser = "user";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> Login(string username, string password)
        {
            await Task.Delay(50);

            var user = new User()
            {
                UserName = username
            };

            if (username.Equals("admin"))
            {
                user.Roles.Add(RoleAdmin);
            }
            
            if (password.Equals("heslo"))
            {
                user.Roles.Add(RoleUser);
            }

            if (user.Roles.Count > 0)
            {
                user.Token = Guid.NewGuid().ToString();
                UserLoginList.Add(user);
            }

            return user;
        }

        //static simple storage for login requests, in production it should be in db
        public static List<User> UserLoginList {  get; set; } = new List<User>();

        public async Task<string> SignInAsync(User user)
        {
            try
            {
                if (_httpContextAccessor == null) return "_httpContextAccessor je null";
                if (_httpContextAccessor.HttpContext == null) return "_httpContextAccessor.HttpContext je null";

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));

                foreach (var r in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, r));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync(principal);

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> SignOutAsync()
        {
            try
            {
                if (_httpContextAccessor == null) return "_httpContextAccessor je null";
                if (_httpContextAccessor.HttpContext == null) return "_httpContextAccessor.HttpContext je null";

                var identity = _httpContextAccessor.HttpContext.User.Identity;

                if ((identity != null) && (identity.IsAuthenticated))
                {
                    await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
