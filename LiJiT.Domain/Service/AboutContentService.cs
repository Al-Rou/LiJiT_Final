using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LiJiT.Domain.DTO;
using LiJiT.Domain.IRepository;
using LiJiT.Domain.IService;
using LiJiT.Model;
using System.Linq;

namespace LiJiT.Domain.Service
{
    public class AboutContentService : IAboutContentService
    {
        private IAboutContentRepository  _aboutContentRepository;
        private readonly IMapper _mapper;
        public AboutContentService(IAboutContentRepository aboutContentRepository, IMapper mapper)
        {
            _aboutContentRepository = aboutContentRepository;
            _mapper = mapper;
        }
        public async Task<List<AboutContentDto>> getAll()
        {
            List<AboutContentDto> _listDto = new List<AboutContentDto>();
            try
            {
                var result = await _aboutContentRepository.GetAll();
                _listDto = new List<AboutContentDto>();
                foreach (var item in result)
                {
                    _listDto.Add(_mapper.Map<AboutContentDto>(item));
                }
                //_listDto.Message = "Succcess";
                //_listDto.MessageCode = "0";
                //_listDto.HasError = false;
                //_listDto.ListCount = _listDto.List.Count;
            }
            catch (Exception ex)
            {
                //_listDto.Message = ex.Message.ToString();
                //_listDto.MessageCode = "-1";
                //_listDto.HasError = true;
          
            }
            return _listDto;
        }
        
        public async Task<ResultDto<AboutContentDto>> UpdateAbout(int id, AboutContentDto aboutContentDto)
        {
            var finalResult = new ResultDto<AboutContentDto>();
            try
            {
                //var _about = await _aboutContentRepository.GetById(id);
                var _about = _aboutContentRepository.FindBy(a => a.Id == id).FirstOrDefault();
                if (_about == null)
                {
                    finalResult.ToNotFound<BaseResponse>();
                    return finalResult;
                }
                aboutContentDto.Id = _about.Id;
                _mapper.Map<AboutContentDto, AboutContent>(aboutContentDto, _about);
                await _aboutContentRepository.Update(_about);
                finalResult.ToSuccess<BaseResponse>();
                finalResult.Data = aboutContentDto;
            }
            catch (Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();

            }

            return finalResult;
        }

        public async Task<ResultDto<AboutContentDto>> CreateAboutContent(AboutContentDto newAbout)
        {
            var finalResult = new ResultDto<AboutContentDto>();
            try
            {

                var result = _mapper.Map<AboutContentDto, AboutContent>(newAbout);
                await _aboutContentRepository.Add(result);
                finalResult.ToSuccess<BaseResponse>();
                finalResult.Data = newAbout;
            }
            catch (Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();
            }
            return finalResult;
        }

        /*public async Task<ListDto<AboutContentDto>> CreateAboutContent(AboutContentDto aboutContent)
        {
            ListDto<AboutContentDto> _listDto = new ListDto<AboutContentDto>();
            try
            {
                 
                    var result = _mapper.Map<AboutContentDto, AboutContent>(aboutContent);
                    await _aboutContentRepository.Add(result);
                    //_listDto.Message = "Succcess";
                    //_listDto.MessageCode = "0";
                    //_listDto.HasError = false;
                

            }
            catch (Exception ex)
            {
                //_listDto.Message = ex.Message.ToString();
                //_listDto.MessageCode = "-1";
                //_listDto.HasError = true;

            }
            return _listDto;
        }*/
    }
    
}
