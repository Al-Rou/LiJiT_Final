using System;
using Newtonsoft.Json;

namespace LiJiT.API.Models
{
    public class LoginModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
             
    }
}
