using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "n1038hfh8492jbuDEMO104SECURITYNDUIKEY190FC04797V";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccount;

        public JwtTokenHandler()
        {
            // Providing hard-coded demo admin user
            //      BEING THIS PROJECT ONLY FOR DEMO PURPOSES,
            //      THERE'S NO AUTHENTICATION DATA CONNECTION TO WRITE/READ ON A DB
            _userAccount = new List<UserAccount>()
            {
                new UserAccount() { UserName = "admin", Password = "AdminPassword01!", Role = "Administrator" },
                new UserAccount() { UserName = "user", Password = "UserPassword01!", Role = "User" }
            };
        }

        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return null;

            var userAccount = _userAccount.Where(x => x.UserName.Equals(request.Username, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(request.Password)).FirstOrDefault();
            if (userAccount is null)
                return null;

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, request.Username),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });

            var signignCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signignCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                Username = userAccount.UserName,
                JwtToken = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
