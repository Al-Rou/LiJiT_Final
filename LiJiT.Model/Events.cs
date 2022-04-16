using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiJiT.Model
{
    public class Events : AuditableEntity<int>
    {
        [StringLength(150)]
        public string Note { get; set; }
        [StringLength(200)]
        [Required]
        public string Address { get; set; }
        [StringLength(200)]
        [Required]
        public string Address2 { get; set; }
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Location { get; set; }
      
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(200)]
        public string ShareLink { get; set; }
        [StringLength(200)]
        public string Organizer { get; set; }
        //Image could be important in this class, right?
        public byte[] ImageEvent { get; set; }



    }
}
