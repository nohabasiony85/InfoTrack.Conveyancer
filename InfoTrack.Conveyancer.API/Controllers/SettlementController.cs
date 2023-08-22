using InfoTrack.Conveyancer.API.Models;
using InfoTrack.Conveyancer.Domain.Models.Handlers;
using InfoTrack.Conveyancer.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Conveyancer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SettlementController : ControllerBase
{

    private readonly ILogger<SettlementController> _logger;
    private readonly IMediator _mediator;
    private readonly ISettlementRepository _settlementRepository;

    public SettlementController(ILogger<SettlementController> logger, IMediator mediator,ISettlementRepository settlementRepository)
    {
        _logger = logger;
        _mediator = mediator;
        _settlementRepository = settlementRepository;
    }

    [HttpPost( "reservation")]
    public async Task<CreateReservationResponse> CreateReservation([FromBody] CreateReservationRequest request)
    {
        var id = await _mediator.Send(new CreateReservationCommand(new TimeOnly(request.BookingTime.Hours, request.BookingTime.Minutes), request.Name));

        return  new CreateReservationResponse(id.ToString());
    }
}