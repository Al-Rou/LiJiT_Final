using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiJiT.API.Models;
using LiJiT.Domain.DTO;
using LiJiT.Domain.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiJiT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ListingDetailController : ControllerBase
    {
        private IListingDetailService  _listingDetailService;
        public ListingDetailController(IListingDetailService  listingDetailService)
        {
            _listingDetailService = listingDetailService;
        }
        [HttpGet]
        [Route("Stores")]   
        public async Task<List<ListingDetailDto>> GetAll()
        {
            return await _listingDetailService.getAll();
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ResultDto<ListingDetailDto>> UpdateListingDetail(int id, ListingDetailDto listingDetailDto)
        {
            return await _listingDetailService.UpdateListingDetail(id, listingDetailDto);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ResultDto<ListingDetailDto>> DeleteListingDetail(int id)
        {
            return await _listingDetailService.DeleteListingDetail(id);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ResultDto<ListingDetailDto>> Create(ListingDetailDto listingDetailDto)
        {
            return await _listingDetailService.CreateListingDetail(listingDetailDto);
        }
        [HttpGet]
        [Route("getByCategoryId")]
        public async Task<List<ListingDetailDto>> getByCategoryId(int categoryId)
        {
            return await _listingDetailService.getByCategoryId(categoryId);
        }
        [HttpGet]
        [Route("getHottestStores")]
        public async Task<List<ListingDetailDto>> getHottestListingDetails()
        {
            return await _listingDetailService.getHottestListingDetails();
        }
    }
}
