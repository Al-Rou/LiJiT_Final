using System;
namespace LiJiT.Domain.DTO
{
    public class SocialProfilesDTO
    {
        public int Id { get; set; }
        public int ListingDetailsId { get; set; }
        public int SocialMediaTypeId { get; set; }
        public string SocialMediaName { get; set; }
        public byte[] Icon { get; set; }
        public int AccountId { get; set; }
    }
}
