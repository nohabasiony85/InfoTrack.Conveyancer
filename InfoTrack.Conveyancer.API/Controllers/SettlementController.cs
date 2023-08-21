using InfoTrack.Conveyancer.API.Models;
using InfoTrack.Conveyancer.Domain.Models.Settlements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Conveyancer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SettlementController : ControllerBase
{

    private readonly ILogger<SettlementController> _logger;
    private readonly IMediator _mediator;

    public SettlementController(ILogger<SettlementController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost(Name = "reservation")]
    public Task<bool> CreateReservation([FromBody] CreateReservationRequest request)
    {
        return _mediator.Send(new CreateReservationCommand(new TimeOnly(request.BookingTime.Hours, request.BookingTime.Minutes), request.Name));
    }
}