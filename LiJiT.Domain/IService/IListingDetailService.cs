using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiJiT.Domain.DTO;

namespace LiJiT.Domain.IService
{
    public interface IListingDetailService
    {
        Task<List<ListingDetailDto>> getAll();
        //Task<ListDto<ListingDetailDto>> CreateListingType(ListingDetailDto listingDetailDto);
        Task<List<ListingDetailDto>> getByCategoryId(int CategoryId);
        Task<List<ListingDetailDto>> getHottestListingDetails();
        Task<ResultDto<ListingDetailDto>> UpdateListingDetail(int id, ListingDetailDto listingDetailDto);
        Task<ResultDto<ListingDetailDto>> DeleteListingDetail(int id);
        Task<ResultDto<ListingDetailDto>> CreateListingDetail(ListingDetailDto newListingDetail);
    }
}
