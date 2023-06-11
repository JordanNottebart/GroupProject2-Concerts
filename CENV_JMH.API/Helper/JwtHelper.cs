using CENV_JMH.API.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CENV_JMH.API.Helper
{
    #region JSON Web Tokens Helper
    /// <summary>
    /// Helper class for creating JSON Web Tokens (JWT) for user authentication and authorization.
    /// </summary> 
    #endregion

    public class JwtHelper
    {
        private const int EXPIRATION_MINUTES = 1;

        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Create Token
        /// <summary>
        ///  Creates a JWT token for the provided user.
        /// </summary>
        /// <param name="user">The user object for which the token is created.</param>
        /// <returns>
        /// An instance of AuthResDto containing the generated token and its expiration.
        /// </returns> 
        #endregion

        public AuthrizationDto CreateToken(IdentityUser user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return new AuthrizationDto
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expiration
            };
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
           new JwtSecurityToken(
               _configuration["Jwt:Issuer"],
               _configuration["Jwt:Audience"],
               claims,
               expires: expiration,
               signingCredentials: credentials
           );

        private Claim[] CreateClaims(IdentityUser user) =>
            new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials
            (
                new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                ),
                SecurityAlgorithms.HmacSha256
            );
    }
}
