using CancunBooking.Application.Booking.Commands.CreateBooking;
using CancunBooking.Application.Booking.Commands.DeleteBooking;
using CancunBooking.Application.Booking.Commands.UpdateBooking;
using CancunBooking.Application.Booking.Queries.Get.Requests;
using CancunBooking.Application.Booking.Queries.GetBooking;
using CancunBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CancunBooking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetAll([FromQuery] GetBookingsRequest query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Booking>> GetByBookingCode(int code)
        {
            return await Mediator.Send(new GetBookingRequest() { BookingCode = code });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookingCommandRequest command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateBookingCommandRequest command)
        {
            await Mediator.Send(command);

            return Accepted();
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> Delete(int code)
        {
            await Mediator.Send(new DeleteBookingCommandRequest { Code = code });

            return Accepted();
        }
    }
}