using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiJiT.Domain.DTO;

namespace LiJiT.Domain.IService
{
    public interface IAboutContentService
    {
        Task<List<AboutContentDto>> getAll();
        //Task<ListDto<AboutContentDto>> CreateAboutContent(AboutContentDto aboutContent);
        Task<ResultDto<AboutContentDto>> UpdateAbout(int id, AboutContentDto aboutContentDto);
        Task<ResultDto<AboutContentDto>> CreateAboutContent(AboutContentDto aboutContent);
    }
}
