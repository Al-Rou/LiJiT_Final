using AutoMapper;
using LiJiT.Domain.DTO;
using LiJiT.Domain.IRepository;
using LiJiT.Domain.IService;
using LiJiT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiJiT.Domain.Service
{
    public class EventService: IEventService
    {

        private IEventsRepository _eventsRepository;
        private readonly IMapper _mapper;
        public EventService(IEventsRepository eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }
        public async Task<List<EventsDto>> GetAll()
        {
            List<EventsDto> _listDto = new List<EventsDto>();
            try
            {
                var result =  _eventsRepository.FindBy(a=>a.EndDate > DateTime.Now);
                _listDto = new List<EventsDto>();
                foreach (var item in result)
                {
                    _listDto.Add(_mapper.Map<EventsDto>(item));
                }
            }
            catch (Exception ex)
            {

            }
            return _listDto;
        }
        
        public async Task<List<EventsDto>> GetAllPastAndFuture()
        {
            List<EventsDto> _listDto = new List<EventsDto>();
            try
            {
                var result = _eventsRepository.FindBy(a => a.EndDate > DateTime.Now || a.EndDate <= DateTime.Now);
                _listDto = new List<EventsDto>();
                foreach (var item in result)
                {
                    _listDto.Add(_mapper.Map<EventsDto>(item));
                }
            }
            catch (Exception ex)
            {

            }
            return _listDto;
        }
        public async Task<ResultDto<EventsDto>> CreateEvent(EventsDto newEvent)
        {
            var finalResult = new ResultDto<EventsDto>();
            try
            {

                var result = _mapper.Map<EventsDto, Events>(newEvent);
                await _eventsRepository.Add(result);
                finalResult.ToSuccess<BaseResponse>();
                finalResult.Data = newEvent;
            }
            catch (Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();
            }
            return finalResult;
        }
        public async Task<ResultDto<EventsDto>> UpdateEvent(int id , EventsDto eventsDto)
        {
            var finalResult = new ResultDto<EventsDto>();
            try
            {
                var _event = await _eventsRepository.GetById(id);
                if (_event == null)
                {
                    finalResult.ToNotFound<BaseResponse>();
                    return finalResult;
                }
                eventsDto.Id = id;
                //eventsDto.ImageEvent = _event.ImageEvent.ToString();
               _mapper.Map<EventsDto, Events>(eventsDto,_event);
                await _eventsRepository.Update(_event);
                finalResult.ToSuccess<BaseResponse>();
                finalResult.Data = eventsDto;
                

            }
            catch (Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();
               
            }

            return finalResult;

        }
        public async Task<ResultDto<EventsDto>> DeleteEvent(int id)
        {
            var finalResult = new ResultDto<EventsDto>();
            try
            {
                var _event = await _eventsRepository.GetById(id);
                if (_event == null)
                {
                    finalResult.ToNotFound<BaseResponse>();
                    return finalResult;
                }           
                var result = _eventsRepository.Remove(_event);
                finalResult.ToSuccess<BaseResponse>();
               

            }
            catch (Exception ex)
            {
                finalResult.ToInternalError<BaseResponse>();

            }

            return finalResult;

        }



    }
}
