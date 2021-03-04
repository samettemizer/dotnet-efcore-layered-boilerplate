using System.Text.Json.Serialization;

namespace TaTava.Authentication.Web.JwtBearer
{
    public class JwtTokenConfig
    {
        [JsonPropertyName("Secret")]
        public string Secret { get; set; }

        [JsonPropertyName("Issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("Audience")]
        public string Audience { get; set; }

        [JsonPropertyName("AccessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        [JsonPropertyName("RefreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}