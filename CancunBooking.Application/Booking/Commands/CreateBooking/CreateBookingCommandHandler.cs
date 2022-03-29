using CancunBooking.Application.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CancunBooking.Application.Booking.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommandRequest, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookingCommandRequest request, CancellationToken cancellationToken)
        {
            var newBooking = new Domain.Entities.Booking(request.Checkin, request.Checkout, request.Name);

            _context.Bookings.Add(newBooking);

            await _context.SaveChangesAsync(cancellationToken);

            return newBooking.Id;
        }
    }
}
