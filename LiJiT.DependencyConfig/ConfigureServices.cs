using System;
using Microsoft.Extensions.DependencyInjection;
using LiJiT.Domain.IRepository;
using LiJiT.Domain.IService;
using LiJiT.Domain.Service;
using LiJiT.Persistance.Repository;
namespace LiJiT.DependencyConfig
{
    public class ConfigureServices
    {
        public ConfigureServices(IServiceCollection  service)
        {
            service.AddTransient<IListingTypeService, ListingTypeService>();
            service.AddTransient<IListingTypeRepository, ListingTypeRepository>();
            service.AddTransient<IListingDetailRepository, ListingDetailRepository>();
            service.AddTransient<IListingDetailService, ListingDetailService>();
            service.AddTransient<IAboutContentService, AboutContentService>();
            service.AddTransient<IAboutContentRepository, AboutContentRepository>();
            service.AddTransient<IEventService, EventService>();
            service.AddTransient<IEventsRepository, EventsRepository>();
        }
    }
}
