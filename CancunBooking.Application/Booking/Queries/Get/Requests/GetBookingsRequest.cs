using MediatR;
using System.Collections.Generic;

namespace CancunBooking.Application.Booking.Queries.Get.Requests
{
    public class GetBookingsRequest : IRequest<List<Domain.Entities.Booking>>
    {
    }
}
