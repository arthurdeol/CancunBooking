using CancunBooking.Application.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CancunBooking.Application.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommandRequest>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBookingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.CheckIn.Date)
                .NotEmpty().WithMessage("Check in is required.")
                .GreaterThanOrEqualTo(DateTime.Today.Date).WithMessage("Check in should start tomorrow.")
                .LessThan(DateTime.Today.AddDays(30)).WithMessage("Booking shouldn't be more than 30 days in advance.")
                .Must((model, field) => field <= model.CheckOut).WithMessage("Check in must be less than check out.")
                .MustAsync(BeUniqueDate).WithMessage("There's another booking on this date.");

            RuleFor(v => v.CheckOut)
                .NotEmpty().WithMessage("Check out is required")
                .Must((model, field) => field >= model.CheckIn).WithMessage("Check out must be over than check in.")
                .Must((model, field) => model.CheckIn.AddDays(4) > field).WithMessage("You can't book longer than 3 days.");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.");
        }

        public async Task<bool> BeUniqueDate(UpdateBookingCommandRequest model, DateTime checkin, CancellationToken cancellationToken)
        {
            var isAnyBoocking = await _context.Bookings
                .Where(l => (l.Id != model.CodeBooking) &&
                ((l.CheckOut.Date >= checkin.Date && l.CheckOut.Date <= model.CheckOut.Date) ||
                (l.CheckIn >= model.CheckOut.Date && l.CheckIn.Date <= model.CheckOut.Date))).AnyAsync();
            return !isAnyBoocking;
        }
    }
}
