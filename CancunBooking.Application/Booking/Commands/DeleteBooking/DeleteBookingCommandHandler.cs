using CancunBooking.Application.Common;
using CancunBooking.Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CancunBooking.Application.Booking.Commands.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommandRequest>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBookingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookingCommandRequest request, CancellationToken cancellationToken)
        {
            var booking = await _context.Bookings.FindAsync(request.Code);

            if(booking is null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Booking), request.Code);
            }

            _context.Bookings.Remove(booking);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
