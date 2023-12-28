using AutoMapper;
using Eventsense.DTOs.Guest;
using Microsoft.AspNetCore.Mvc;

namespace Eventsense;

[ApiController]
[Route("[controller]")]
public class GuestsController : ControllerBase
{
    private readonly IGuestsServices guestsServices;
    private readonly IMapper mapper;
    public GuestsController(IGuestsServices guestsServices, IMapper mapper)
    {
        this.guestsServices = guestsServices;
        this.mapper = mapper;
    }

    [HttpGet("{guestId}")]
    public async Task<ActionResult<Guest>> Get(int guestId)
    {
        var guest = await this.guestsServices.Get(guestId);

        if(guest == null)
        {
            return NotFound();
        }

        return Ok(this.mapper.Map<Guest>(guest));
    }

    [HttpGet]
    public async Task<ActionResult<List<Guest>>> List()
    {
        var guests = await this.guestsServices.List();

        return Ok(this.mapper.Map<List<Guest>>(guests));
    }

    [HttpPut("{guestId}")]
    public async Task<ActionResult<Guest>> Update(int guestId, UpdateGuest guest)
    {
        if(guestId != guest.Id)
        {
            return BadRequest();
        }
        
        await this.guestsServices.Update(this.mapper.Map<Business.Model.Guest>(guest));

        var updatedGuest = await this.guestsServices.Get(guest.Id);

        return Ok(this.mapper.Map<Guest>(updatedGuest));
    }

    [HttpPost]
    public async Task<ActionResult<Guest>> Create(CreateGuest newGuest)
    {
        var guest = await this.guestsServices.Create(this.mapper.Map<Business.Model.Guest>(newGuest));

        return Ok(this.mapper.Map<Guest>(guest));
    }

    [HttpDelete("{guestId}")]
    public async Task<ActionResult<Guest>> Delete(int guestId)
    {
        await this.guestsServices.Delete(guestId);

        return Ok();
    }
}