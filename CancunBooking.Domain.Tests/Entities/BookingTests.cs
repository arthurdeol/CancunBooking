using CancunBooking.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace CancunBooking.Domain.Tests.Entities
{
    public class BookingTests
    {
        [Test]
        public void ShouldReturnCorrectYearBooking()
        {
            var booking = new Booking(new DateTime(2022,3,24), new DateTime(2022,3,25));
            booking.CheckIn.Year.Should().Be(2022);
            booking.CheckOut.Year.Should().Be(2022);
        }

        [Test]
        public void ShouldReturnCorrectDayBooking()
        {
            var booking = new Booking(new DateTime(2022, 3, 24), new DateTime(2022, 3, 25));
            booking.CheckIn.Day.Should().Be(24);
            booking.CheckOut.Day.Should().Be(25);
        }

        [Test]
        public void ShouldReturnCorrectMonthBooking()
        {
            var booking = new Booking(new DateTime(2022, 3, 24), new DateTime(2022, 3, 25));
            booking.CheckIn.Day.Should().Be(24);
            booking.CheckOut.Day.Should().Be(25);
        }

        [Test]
        public void ShouldReturnInCorrectActiveBooking()
        {
            var booking = new Booking(new DateTime(2022, 3, 24), new DateTime(2022, 3, 25));
            booking.Active.Should().NotBe(false);
        }

        [Test]
        public void ShouldReturnCorrectBookingCancelation()
        {
            var booking = new Booking(new DateTime(2022, 3, 24), new DateTime(2022, 3, 25));
            booking.CancelBooking();
            booking.Active.Should().Be(false);
        }

        [Test]
        public void ShouldCorrectModifyBooking()
        {
            var booking = new Booking(new DateTime(2022, 3, 24), new DateTime(2022, 3, 25));
            booking.ModifyBooking(new DateTime(2022, 3, 26), new DateTime(2022, 3, 27));
            booking.CheckIn.Day.Should().Be(26);
            booking.CheckOut.Day.Should().Be(27);
        }
    }
}
