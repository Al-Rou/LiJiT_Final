using System;
using LiJiT.Domain.IRepository;
using LiJiT.Model;
using LiJiT.EntityFramework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LiJiT.Persistance.Repository
{
    public class ListingDetailRepository : GenericRepository<ListingDetails, LiJiTDbContext>, IListingDetailRepository
    { 
        public ListingDetailRepository(LiJiTDbContext context) : base(context)
        {
        }
       
    }
}
