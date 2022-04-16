using System;
using LiJiT.Domain.IRepository;
using LiJiT.Model;
using LiJiT.EntityFramework;
namespace LiJiT.Persistance.Repository
{
    public class ListingDetailSocialProfilesRepository : GenericRepository<ListingDetailSocialProfiles, LiJiTDbContext>, IListingDetailSocialProfilesRepository
    {
        public ListingDetailSocialProfilesRepository(LiJiTDbContext context) : base(context)
        {
        }
    }
}
