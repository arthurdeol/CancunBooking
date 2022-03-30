using CancunBooking.Application.Common;
using CancunBooking.Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CancunBooking.Application.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommandRequest>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBookingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookingCommandRequest request, CancellationToken cancellationToken)
        {
            var booking = await _context.Bookings.FindAsync(request.CodeBooking);

            if(booking is null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Booking), request.CodeBooking);
            }

            booking.ModifyBooking(request.CheckIn, request.CheckOut, request.Name);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
