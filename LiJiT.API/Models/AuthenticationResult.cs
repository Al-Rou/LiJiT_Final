using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LiJiT.API.Models
{
    public class TokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }

    public class AuthenticationResult : TokenModel
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
