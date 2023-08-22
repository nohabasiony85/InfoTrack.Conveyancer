using FluentValidation;
using InfoTrack.Conveyancer.Domain.Models;

namespace InfoTrack.Conveyancer.Domain.Validators;

public class BookingTimeValidator : AbstractValidator<BookingTime>
{
    public BookingTimeValidator()
    {   
        RuleFor(x => x.Hour).LessThanOrEqualTo(23).WithMessage("Booking time is not valid or out of business hours.");
        RuleFor(x => x.Minute).LessThanOrEqualTo(59).WithMessage("Booking time is not valid.");
    }
}