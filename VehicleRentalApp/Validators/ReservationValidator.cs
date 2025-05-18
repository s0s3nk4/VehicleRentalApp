using FluentValidation;
using VehicleRentalApp.ViewModels;

namespace VehicleRentalApp.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Data rozpoczęcia jest wymagana")
                .GreaterThan(DateTime.Now).WithMessage("Data rozpoczęcia musi być w przyszłości");
            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("Data zakończenia jest wymagana")
                .GreaterThan(x => x.StartDate).WithMessage("Data zakończenia musi być późniejsza niż data rozpoczęcia");
        }
    }
}
