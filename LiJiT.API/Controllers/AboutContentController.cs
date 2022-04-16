using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiJiT.Domain.DTO;
using LiJiT.Domain.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiJiT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AboutContentController : ControllerBase
    {
        public readonly IAboutContentService _aboutContentService;
        public AboutContentController(IAboutContentService aboutContentService)
        {
            _aboutContentService = aboutContentService;
        }
        [HttpGet]
        [Route("About")]
        public async Task<AboutContentDto> GetAll()
        {
            var temp = await _aboutContentService.getAll();
            return temp[0];
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ResultDto<AboutContentDto>> UpdateAbout(int id, AboutContentDto aboutContentDto)
        {
            return await _aboutContentService.UpdateAbout(id, aboutContentDto);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ResultDto<AboutContentDto>> CreateAboutContent(AboutContentDto  aboutContentDto)
        {
            return await _aboutContentService.CreateAboutContent(aboutContentDto);
        }
    }
}
