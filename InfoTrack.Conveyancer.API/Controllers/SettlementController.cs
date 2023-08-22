using InfoTrack.Conveyancer.API.Models;
using InfoTrack.Conveyancer.Domain.Models;
using InfoTrack.Conveyancer.Domain.Models.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Conveyancer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SettlementController : ControllerBase
{
    private readonly IMediator _mediator;

    public SettlementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("reservation")]
    public async Task<CreateReservationResponse> CreateReservation([FromBody] CreateReservationRequest request)
    {
        var id = await _mediator.Send(new CreateReservationCommand(
            new BookingTime() { Hour = request.BookingTime.Hour, Minute = request.BookingTime.Minute }, request.Name));

        return new CreateReservationResponse(id.ToString());
    }
}