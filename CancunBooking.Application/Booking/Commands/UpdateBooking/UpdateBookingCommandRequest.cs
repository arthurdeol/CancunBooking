using MediatR;
using System;

namespace CancunBooking.Application.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommandRequest : IRequest
    {
        public int CodeBooking { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Name { get; set; }
    }
}
