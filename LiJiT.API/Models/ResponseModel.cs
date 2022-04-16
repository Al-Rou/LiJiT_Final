using System;
using Newtonsoft.Json;

namespace LiJiT.API.Models
{
    public class ResponseModel<T>
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }

        public ResponseModel()
        {
            IsSuccess = true;
            Message = "";
        }
    }
}
