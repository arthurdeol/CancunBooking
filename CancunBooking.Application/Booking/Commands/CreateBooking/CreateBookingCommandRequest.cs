using MediatR;
using System;

namespace CancunBooking.Application.Booking.Commands.CreateBooking
{
    public class CreateBookingCommandRequest : IRequest<int>
    {
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string Name { get; set; }
    }
}
