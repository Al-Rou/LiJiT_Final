using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ListingTypeController : ControllerBase
    {
        private IListingTypeService _listingTypeService;
        public ListingTypeController(IListingTypeService listingTypeService)
        {
            _listingTypeService = listingTypeService;
        }
        [HttpGet]
        [Route("Category")]   
        public async Task<List<ListingTypeDto>> GetAll()
        {
            return await _listingTypeService.getAll();
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ResultDto<ListingTypeDto>> UpdateListingType(int id, ListingTypeDto listingTypeDto)
        {
            return await _listingTypeService.UpdateListingType(id, listingTypeDto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ResultDto<ListingTypeDto>> CreateListingType(ListingTypeDto listingTypeDto)
        {
            return await _listingTypeService.CreateListingType(listingTypeDto);
        }

    }
}
