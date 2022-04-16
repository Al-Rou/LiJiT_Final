using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LiJiT.Model
{
    public class AboutContent : Entity<Int16>
    {
 
        [Required]
        public string Title1 { get; set; }
        [Required]
        public string Title2 { get; set; }
        [Required]
        public string Content1  { get; set; }
        [Required]
        public string Content2 { get; set; }
        [Required]
        public byte[] ImageAbout { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public static explicit operator ValueTask<object>(AboutContent v)
        {
            throw new NotImplementedException();
        }

        public string Telephon { get; set; }
        public string Email { get; set; }
        public string ShareLink { get; set; }
 
     }
}
