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
    public class ListingTypeService : IListingTypeService
    {
        private IListingTypeRepository _listingTypeRepository;
        private readonly IMapper _mapper;
        public ListingTypeService(IListingTypeRepository listingTypeRepository , IMapper mapper)
        {
            _listingTypeRepository = listingTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<ListingTypeDto>> getAll()
        {
            List<ListingTypeDto> _listDto = new List<ListingTypeDto>();
            try
            {
                var result = await _listingTypeRepository.GetAll();
                _listDto = new List<ListingTypeDto>();
                foreach (var item in result)
                {
                    _listDto.Add(_mapper.Map<ListingTypeDto>(item));
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
        
        public async Task<ResultDto<ListingTypeDto>> UpdateListingType(int id, ListingTypeDto listingTypeDto)
        {
            var finalResult = new ResultDto<ListingTypeDto>();
            try
            {
                //var _listingType = await _listingTypeRepository.GetById(id);
                var _listingType = _listingTypeRepository.FindBy(a => a.Id == id).FirstOrDefault();
                if (_listingType == null)
                {
                    finalResult.ToNotFound<BaseResponse>();
                    return finalResult;
                }
                listingTypeDto.Id = _listingType.Id;
                _mapper.Map<ListingTypeDto, ListingType>(listingTypeDto, _listingType);
                await _listingTypeRepository.Update(_listingType);
                finalResult.ToSuccess<BaseResponse>();
                finalResult.Data = listingTypeDto;

            }
            catch(Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();
            }

            return finalResult;

        }
        public async Task<ResultDto<ListingTypeDto>> CreateListingType(ListingTypeDto newListingType)
        {
            var finalResult = new ResultDto<ListingTypeDto>();
            try
            {
                var result = _mapper.Map<ListingTypeDto, ListingType>(newListingType);
                await _listingTypeRepository.Add(result);
                finalResult.ToSuccess<BaseResponse>();
                finalResult.Data = newListingType;

            }catch(Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();
            }
            return finalResult;
        }

        //public async Task<ListDto<ListingTypeDto>> CreateListingType(ListingTypeDto listingTypeDto)
        //{
            //ListDto<ListingTypeDto> _listDto = new ListDto<ListingTypeDto>();
            //try
            //{
                //if (String.IsNullOrWhiteSpace(listingTypeDto.Name))
                //{
                    //_listDto.Message = "Invalid Input";
                    //_listDto.MessageCode = "-2";
                    //_listDto.HasError = true;
                //}
                //else
                //{
                    //var result = _mapper.Map<ListingTypeDto, ListingType>(listingTypeDto);
                    //result.IsActive = true;
                    //await _listingTypeRepository.Add(result);
                    //_listDto.Message = "Succcess";
                    //_listDto.MessageCode = "0";
                    //_listDto.HasError = false;
                //}

            //}
            //catch (Exception ex)
            //{
                //_listDto.Message = ex.Message.ToString();
                //_listDto.MessageCode = "-1";
                //_listDto.HasError = true;

            //}
           //return _listDto;
        //}
    }
    
}
