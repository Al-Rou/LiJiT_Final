using System;
using LiJiT.Domain.IRepository;
using LiJiT.EntityFramework;
using LiJiT.Model;

namespace LiJiT.Persistance.Repository
{
    public class EventsRepository : GenericRepository<Events, LiJiTDbContext>, IEventsRepository
    {
        public EventsRepository(LiJiTDbContext context) : base(context)
        {
        }
    }
}
