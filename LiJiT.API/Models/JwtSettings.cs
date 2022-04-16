using System;
namespace LiJiT.API.Models
{

    public static  class JwtSettings
    {
        public  static string Secret { get; set; }
        public static int TokenLifetimeMinutes { get; set; }
        public static  string UserName { get; set; }
        public  static string Password { get; set; }
    }
}
