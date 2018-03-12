using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace SampleToken.Helpers
{
    /// <summary>
    /// Extensions to ease jwt token handling.
    /// </summary>
    public static class JwtHelperExtensions
    {



        /// <summary>
        /// creates jwt configuration from IConfiguration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static JwtConfig AsJwtConfig(this IConfiguration configuration)
        {
            return new JwtConfig()
            {
                Audience = configuration["jwtAudience"],
                SecurityKey = configuration["jwtSecretKey"],
                Issuer = configuration["jwtIssuer"],
                Subject = configuration["jwtSubject"],
                ExpireInMinutes = int.Parse(configuration["jwtExpireInMinutes"])
            };


        }


        /// <summary>
        /// Creates the symmetric security key from the secret
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static SymmetricSecurityKey CreateSymmetricSecurityKey(this JwtConfig config)
        {
            return CreateSymmetricSecurityKey(config.SecurityKey);
        }

        /// <summary>
        /// Creates the symmetric security key.
        /// </summary>
        /// <param name="secret">The secret.</param>
        /// <returns></returns>
        public static SymmetricSecurityKey CreateSymmetricSecurityKey(string secret)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }

        /// <summary>
        /// Builds the token.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="claims">The claims.</param>
        /// <returns></returns>
        public static JwtToken BuildToken(this JwtConfig config, Dictionary<string, string> claims)
        {

            var secitiKey = config.CreateSymmetricSecurityKey();

            var allClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, config.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }
                .Union(claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                issuer: config.Issuer,
                audience: config.Audience,
                claims: allClaims,
                expires: DateTime.UtcNow.AddMinutes(config.ExpireInMinutes),
                signingCredentials: new SigningCredentials(
                    secitiKey,
                    SecurityAlgorithms.HmacSha256));


            return new JwtToken(token);
        }

    }
}
