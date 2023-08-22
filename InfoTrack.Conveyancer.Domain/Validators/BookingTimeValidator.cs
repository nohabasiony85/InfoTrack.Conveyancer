using FluentValidation;
using InfoTrack.Conveyancer.Domain.Models;

namespace InfoTrack.Conveyancer.Domain.Validators;

public class BookingTimeValidator : AbstractValidator<BookingTime>
{
    public BookingTimeValidator()
    {   
        RuleFor(x => x.Hour).LessThanOrEqualTo(17).WithMessage("Booking time is out of business hours.");
        RuleFor(x => x.Hour).LessThanOrEqualTo(23).WithMessage("Booking time is not valid.");
        RuleFor(x => x.Minute).LessThanOrEqualTo(59).WithMessage("Booking time is not valid.");
    }
}