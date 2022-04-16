using System;
using LiJiT.Domain.IRepository;
using LiJiT.Model;
using LiJiT.EntityFramework;
using System.Threading.Tasks;
using System.Linq;

namespace LiJiT.Persistance.Repository
{
    public class AboutContentRepository : GenericRepository<AboutContent, LiJiTDbContext>, IAboutContentRepository
    {
        public AboutContentRepository(LiJiTDbContext context) : base(context)
        {
        }
        /*public override ValueTask<AboutContent> GetById(int id)
        {
            var result = from a in Context.Set<AboutContent>() where a.Id==id select a;
            return base.GetById(id);
        }*/
    }
}
