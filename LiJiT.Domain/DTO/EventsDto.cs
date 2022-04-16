using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiJiT.Domain.DTO
{
    public class EventsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string ImageEvent { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ShareLink { get; set; }
        public string Organizer { get; set; }
    }
}
