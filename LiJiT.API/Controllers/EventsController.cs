using LiJiT.Domain.DTO;
using LiJiT.Domain.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiJiT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EventsController : ControllerBase
    {

            public readonly IEventService _eventService;
            public EventsController(IEventService eventService)
            {
                _eventService = eventService;
            }
            [HttpGet]
            [Route("Upcoming")]
            public async Task<List<EventsDto>> GetAll()
            {
                var result  = await _eventService.GetAll();
                return result;
            }
            [HttpGet]
            [Route("All")]
            public async Task<List<EventsDto>> GetAllPastAndFuture()
            {
                var result = await _eventService.GetAllPastAndFuture();
                return result;
            }
            [HttpPost]
            [Route("Create")]
            public async Task<ResultDto<EventsDto>> CreateEvent(EventsDto newEvent)
            {
                return await _eventService.CreateEvent(newEvent);
            }

            [HttpPut]
            [Route("Update")]
            public async Task<ResultDto<EventsDto>> UpdateEvent(int id, EventsDto eventsDto)
            {
                return await _eventService.UpdateEvent(id, eventsDto);
            }
            [HttpDelete]
            [Route("Delete")]
            public async Task<ResultDto<EventsDto>> DeleteEvent(int id)
            {
                return await _eventService.DeleteEvent(id);
            }

    }
}
