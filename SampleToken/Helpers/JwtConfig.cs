namespace SampleToken.Helpers
{
    /// <summary>
    /// Configuration required for JWT tokern authentication.
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }


        /// <summary>
        /// Gets or sets the security key.
        /// </summary>
        /// <value>
        /// The security key.
        /// </value>
        public string SecurityKey { get; set; }


        /// <summary>
        /// Gets or sets the issuer.
        /// </summary>
        /// <value>
        /// The issuer.
        /// </value>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the audience.
        /// </summary>
        /// <value>
        /// The audience.
        /// </value>
        public string Audience { get; set; }


        /// <summary>
        /// Gets or sets the expire in minutes.
        /// </summary>
        /// <value>
        /// The expire in minutes.
        /// </value>
        public int ExpireInMinutes { get; set; }

    }
}
