using System;
using System.IdentityModel.Tokens.Jwt;

namespace SampleToken.Helpers
{

    /// <summary>
    /// Holds the JWT security token
    /// </summary>
    public sealed class JwtToken
    {
        private readonly JwtSecurityToken _token;

        internal JwtToken(JwtSecurityToken token)
        {
            _token = token;
        }

        /// <summary>
        /// Gets the valid to.
        /// </summary>
        /// <value>
        /// The valid to.
        /// </value>
        public DateTime ValidTo => _token.ValidTo;


        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value => new JwtSecurityTokenHandler().WriteToken(_token);


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this.Value instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Value;
        }
    }

}
