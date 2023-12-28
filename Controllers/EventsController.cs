using AutoMapper;
using Eventsense.DTOs.Event;
using Microsoft.AspNetCore.Mvc;

namespace Eventsense;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly IEventsService EventsServices;
    private readonly IMapper mapper;
    public EventsController(IEventsService EventsServices, IMapper mapper)
    {
        this.EventsServices = EventsServices;
        this.mapper = mapper;
    }

    [HttpGet("{eventId}")]
    public async Task<ActionResult<Event>> Get(int eventId)
    {
        var Event = await this.EventsServices.Get(eventId);

        if(Event == null)
        {
            return NotFound();
        }

        return Ok(this.mapper.Map<Event>(Event));
    }

    [HttpGet]
    public async Task<ActionResult<List<Event>>> List()
    {
        var events = await this.EventsServices.List();

        return Ok(this.mapper.Map<List<Event>>(events));
    }

    [HttpPut("{eventId}")]
    public async Task<ActionResult<Event>> Update(int eventId, UpdateEvent eventToUpdate)
    {
        if(eventId != eventToUpdate.Id)
        {
            return BadRequest();
        }
        
        await this.EventsServices.Update(this.mapper.Map<Business.Model.Event>(eventToUpdate));

        var updatedEvent = await this.EventsServices.Get(eventToUpdate.Id);

        return Ok(this.mapper.Map<Event>(updatedEvent));
    }

    [HttpPost]
    public async Task<ActionResult<Event>> Create(CreateEvent newEvent)
    {
        var Event = await this.EventsServices.Create(this.mapper.Map<Business.Model.Event>(newEvent));

        return Ok(this.mapper.Map<Event>(Event));
    }

    [HttpDelete("{eventId}")]
    public async Task<ActionResult<Event>> Delete(int eventId)
    {
        await this.EventsServices.Delete(eventId);

        return Ok();
    }
}