using CancunBooking.Application.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CancunBooking.Application.Booking.Queries.GetBooking
{
    public class GetBookingHandler : IRequestHandler<GetBookingRequest, Domain.Entities.Booking>
    {
        private readonly IApplicationDbContext _context;

        public GetBookingHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Booking> Handle(GetBookingRequest request, CancellationToken cancellationToken)
        {
            return await _context.Bookings.FindAsync(request.BookingCode);
        }

        
    }
}
