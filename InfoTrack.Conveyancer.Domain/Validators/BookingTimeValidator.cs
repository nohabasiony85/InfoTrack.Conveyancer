using FluentValidation;

namespace InfoTrack.Conveyancer.Domain.Validators;

public class BookingTimeValidator : AbstractValidator<TimeOnly>
{
    public BookingTimeValidator()
    {
        RuleFor(x => x).Must(x => x.IsBetween(new TimeOnly(09, 00), new TimeOnly(16, 00)))
            .WithMessage("Booking time is out of business hours");
    }
}