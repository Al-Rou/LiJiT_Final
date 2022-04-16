using LiJiT.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiJiT.Domain.IService
{
    public interface IEventService
    {
        Task<List<EventsDto>> GetAll();
        Task<List<EventsDto>> GetAllPastAndFuture();
        Task<ResultDto<EventsDto>> CreateEvent(EventsDto newEvent);
        Task<ResultDto<EventsDto>> UpdateEvent(int id,EventsDto eventsDto);
        Task<ResultDto<EventsDto>> DeleteEvent(int id);
    }
}
