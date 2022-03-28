using MediatR;

namespace CancunBooking.Application.Booking.Queries.GetBooking
{
    public class GetBookingRequest : IRequest<Domain.Entities.Booking>
    {
        public int BookingCode { get; set; }
    }
}
