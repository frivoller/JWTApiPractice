using System.Text.Json.Serialization;

namespace JWTApiPractice.DTOs
{

    public sealed class Token
    {


        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = string.Empty;


        [JsonPropertyName("access_token_expiration")]
        public DateTime AccessTokenExpiration { get; set; }


        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = string.Empty;


        [JsonPropertyName("refresh_token_expiration")]
        public DateTime RefreshTokenExpiration { get; set; }


        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = "Bearer";

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("refresh_count")]
        public int RefreshCount { get; set; } = 0;

        [JsonPropertyName("client_ip")]

        public string? ClientIp { get; set; }

        [JsonPropertyName("device_info")]

        public string? DeviceInfo { get; set; }

        [JsonIgnore]

        public int AccessTokenRemainingTime => (int)(AccessTokenExpiration - DateTime.UtcNow).TotalSeconds;

        [JsonIgnore]

        public int RefreshTokenRemainingTime => (int)(RefreshTokenExpiration - DateTime.UtcNow).TotalSeconds;

        [JsonIgnore]

        public bool IsAccessTokenExpired => DateTime.UtcNow >= AccessTokenExpiration;

        [JsonIgnore]

        public bool IsRefreshTokenExpired => DateTime.UtcNow >= RefreshTokenExpiration;

        [JsonPropertyName("is_refreshable")]

        public bool IsRefreshable => !IsRefreshTokenExpired && RefreshCount < MaxRefreshCount;

        [JsonIgnore]

        public static int MaxRefreshCount { get; set; } = 5;

        public string GetSummary()
        {
            return $"Access Token: {AccessToken[..10]}... " +
                   $"(Expires in {AccessTokenRemainingTime} seconds), " +
                   $"Refresh Token: {RefreshToken[..10]}... " +
                   $"(Expires in {RefreshTokenRemainingTime} seconds)";
        }
    }
}