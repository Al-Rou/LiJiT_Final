using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiJiT.Domain.DTO;

namespace LiJiT.Domain.IService
{
    public interface IListingTypeService
    {
        Task<List<ListingTypeDto>> getAll();
        //Task<ListDto<ListingTypeDto>> CreateListingType(ListingTypeDto listingTypeDto);
        Task<ResultDto<ListingTypeDto>> UpdateListingType(int id, ListingTypeDto listingTypeDto);
        Task<ResultDto<ListingTypeDto>> CreateListingType(ListingTypeDto newListingType);
    }
}
