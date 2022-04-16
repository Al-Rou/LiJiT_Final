using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace LiJiT.Domain.DTO
{
    [DataContract(Name = "Stores")]
    public class ListingDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public string Website { get; set; }
        public float Rate { get; set; }
        public Int16 ListingTypeId { get; set; }
        public string ListingTypeName { get; set; }
        public bool IsHotBussiness { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string ShareLink { get; set; }
        [JsonIgnore]
        public string  HomeImage { get; set; }
        public string OrderLink { get; set; }


    }
}
