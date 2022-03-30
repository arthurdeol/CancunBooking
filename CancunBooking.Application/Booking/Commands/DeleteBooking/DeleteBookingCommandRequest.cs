using MediatR;

namespace CancunBooking.Application.Booking.Commands.DeleteBooking
{
    public class DeleteBookingCommandRequest : IRequest
    {
        public int Code { get; set; }
    }
}
