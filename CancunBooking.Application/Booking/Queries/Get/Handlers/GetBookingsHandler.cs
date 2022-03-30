using CancunBooking.Application.Booking.Queries.Get.Requests;
using CancunBooking.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CancunBooking.Application.Booking.Queries.Get.Handlers
{
    public class GetBookingsHandler : IRequestHandler<GetBookingsRequest, List<Domain.Entities.Booking>>
    {
        private readonly IApplicationDbContext _context;

        public GetBookingsHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Booking>> Handle(GetBookingsRequest request, CancellationToken cancellationToken)
        {
            return await _context.Bookings.ToListAsync();
        }
    }
}
