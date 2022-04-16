using System;
using LiJiT.Domain.IRepository;
using LiJiT.Model;
using LiJiT.EntityFramework;

namespace LiJiT.Persistance.Repository
{
    public class ListingTypeRepository : GenericRepository<ListingType, LiJiTDbContext>, IListingTypeRepository
    {
        public ListingTypeRepository(LiJiTDbContext context) : base(context)
        {
        }
    }
}
