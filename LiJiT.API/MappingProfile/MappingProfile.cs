using System;
using AutoMapper;
using LiJiT.Model;
using LiJiT.Domain.DTO;
using System.Collections.Generic;

namespace LiJiT.API.MappingProfile
{
    public class MappingProfile : Profile
    {
         public MappingProfile()
        {
            CreateMap<ListingTypeDto, ListingType>().
                ForMember(dest=>dest.Id , opt=>opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                  .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                      .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                        .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            CreateMap<SocialProfilesDTO, ListingDetailSocialProfiles>()
                .ForMember(dest => dest.ListingDetails, opt => opt.Ignore())
                .ForMember(dest => dest.SocialMediaType, opt => opt.Ignore());

            CreateMap<ListingDetailSocialProfiles, SocialProfilesDTO>()
                .ForMember(dest => dest.SocialMediaName, opt => opt.MapFrom(a => a.SocialMediaType.Name))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(a => a.SocialMediaType.Icon));


            CreateMap<ListingDetailDto, ListingDetails>().
              ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                  .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                      //.ForMember(dest => dest.IsHotBussiness, opt => opt.Ignore())
                      .ForMember(dest=>dest.HomeImage , opt => opt.MapFrom(a=>System.Convert.FromBase64String(a.HomeImage)));

            CreateMap<ListingType, ListingTypeDto>();
            CreateMap<List<ListingType>, List<ListingTypeDto>>().ForAllMembers(a=>a.Ignore());
            CreateMap<ListingDetails, ListingDetailDto>().ForMember(dest => dest.ListingTypeName, opt => opt.MapFrom(a => a.ListingType.Name))
                .ForMember(dest => dest.HomeImage , opt => opt.MapFrom(a => "data:image/png;base64," +
                Convert.ToBase64String(a.HomeImage)));
            CreateMap<AboutContent, AboutContentDto>()
                .ForMember(dest => dest.ImageAbout, opt => opt.MapFrom(a => "data:image/png;base64," +
                Convert.ToBase64String(a.ImageAbout)));
            CreateMap<AboutContentDto, AboutContent>()
                               .ForMember(dest => dest.ImageAbout, opt => opt.MapFrom(a => System.Convert.FromBase64String(a.ImageAbout)));
            CreateMap<EventsDto, Events>()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                  .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                      .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.ImageEvent, opt => opt.MapFrom(a => System.Convert.FromBase64String(a.ImageEvent)));
            CreateMap<Events, EventsDto>()
              .ForMember(dest => dest.ImageEvent, opt => opt.MapFrom(a => "data:image/png;base64," +
              Convert.ToBase64String(a.ImageEvent)));

        }
    }
}
