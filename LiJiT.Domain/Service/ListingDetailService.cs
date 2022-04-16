using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LiJiT.Domain.DTO;
using LiJiT.Domain.IRepository;
using LiJiT.Domain.IService;
using LiJiT.Model;

namespace LiJiT.Domain.Service
{
    public class ListingDetailService : IListingDetailService
    {
        private IListingDetailRepository  _ListingDetailRepository;
        private readonly IMapper _mapper;
        public ListingDetailService(IListingDetailRepository ListingDetailRepository, IMapper mapper)
        {
            _ListingDetailRepository = ListingDetailRepository;
            _mapper = mapper;
        }
        public async Task<List<ListingDetailDto>> getAll()
        {
            List<ListingDetailDto> _listDto = new List<ListingDetailDto>();
            try
            {
                var result = await _ListingDetailRepository.GetAll();
                foreach (var item in result)
                {
                    _listDto.Add(_mapper.Map<ListingDetailDto>(item));
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
        
        public async Task<ResultDto<ListingDetailDto>> UpdateListingDetail(int id, ListingDetailDto listingDetailDto)
        {
            var finalResult = new ResultDto<ListingDetailDto>();
            try
            {
                var _listingDetail = await _ListingDetailRepository.GetById(id);
                if(_listingDetail == null)
                {
                    finalResult.ToNotFound<BaseResponse>();
                    return finalResult;
                }
                listingDetailDto.Id = _listingDetail.Id;
                _mapper.Map<ListingDetailDto, ListingDetails>(listingDetailDto, _listingDetail);
                await _ListingDetailRepository.Update(_listingDetail);
                finalResult.ToSuccess<BaseResponse>();
                finalResult.Data = listingDetailDto;

            }
            catch(Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();
            }
            return finalResult;
        }

        public async Task<ResultDto<ListingDetailDto>> CreateListingDetail(ListingDetailDto newListingDetail)
        {
            var finalResult = new ResultDto<ListingDetailDto>();
            try
            {
                var result = _mapper.Map<ListingDetailDto, ListingDetails>(newListingDetail);
                await _ListingDetailRepository.Add(result);
                finalResult.ToSuccess<BaseResponse>();
                finalResult.Data = newListingDetail;
            }
            catch (Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();
            }
            return finalResult;
        }

        public async Task<ResultDto<ListingDetailDto>> DeleteListingDetail(int id)
        {
            var finalResult = new ResultDto<ListingDetailDto>();
            try
            {
                var _listingDetail = await _ListingDetailRepository.GetById(id);
                if(_listingDetail == null)
                {
                    finalResult.ToNotFound<BaseResponse>();
                    return finalResult;
                }
                await _ListingDetailRepository.Remove(_listingDetail);
                finalResult.ToSuccess<BaseResponse>();

            }catch(Exception ex)
            {
                finalResult.ToNotFound<BaseResponse>();
            }
            return finalResult;
        }

        //public async Task<ListDto<ListingDetailDto>> CreateListingType(ListingDetailDto listingDetailDto)
        //{
            //ListDto<ListingDetailDto> _listDto = new ListDto<ListingDetailDto>();
            //try
            //{
                //if (String.IsNullOrWhiteSpace(listingDetailDto.Name))
                //{
                    //_listDto.Message = "Invalid Input";
                    //_listDto.MessageCode = "-2";
                    //_listDto.HasError = true;
                //}
                //else
                //{
                    //var result = _mapper.Map<ListingDetailDto, ListingDetails>(listingDetailDto);
                     
                    //await _ListingDetailRepository.Add(result);
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
        public async Task<List<ListingDetailDto>> getByCategoryId(int CategoryId)
        {
            List<ListingDetailDto> _listDto = new List<ListingDetailDto>();
            try
            {
                var result =  _ListingDetailRepository.FindBy(a=>a.ListingTypeId==CategoryId);
                foreach (var item in result)
                {
                    _listDto.Add(_mapper.Map<ListingDetailDto>(item));
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return _listDto;
        }
        public async Task<List<ListingDetailDto>> getHottestListingDetails()
        {
            List<ListingDetailDto> _listDto = new List<ListingDetailDto>();
            try
            {
                var result = _ListingDetailRepository.FindBy(a => a.IsHotBussiness== true);
                foreach (var item in result)
                {
                    _listDto.Add(_mapper.Map<ListingDetailDto>(item));
                }

            }
            catch (Exception ex)
            {
            }
            return _listDto;
        }
    }
    
}
