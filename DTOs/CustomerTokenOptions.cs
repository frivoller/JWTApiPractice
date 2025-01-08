namespace JWT_API.DTOs
{

    public sealed record CustomTokenOptions
    {

        public List<string> Audience { get; set; } = new();

        public string Issuer { get; set; } = string.Empty;

        public int AccessTokenExpiration { get; set; }

        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; } = string.Empty;

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public DateTime NotBefore { get; set; } = DateTime.UtcNow;

        public string TokenId { get; set; } = Guid.NewGuid().ToString();

        public string SecurityAlgorithm { get; set; } = "HS256";
 
        public string TokenType { get; set; } = "Bearer";

        public int RefreshTokenLength { get; set; } = 32;

        public int RefreshTokenTTL { get; set; } = 2;

        public TokenSecurityOptions SecurityOptions { get; set; } = new();
    }

    // token security
    public sealed record TokenSecurityOptions
    {
        public bool ValidateIssuer { get; set; } = true;

        public bool ValidateAudience { get; set; } = true;

        public bool ValidateLifetime { get; set; } = true;

        public bool ValidateIssuerSigningKey { get; set; } = true;

        public int ClockSkew { get; set; } = 5;
    }
}