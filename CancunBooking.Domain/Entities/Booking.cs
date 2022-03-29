using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CancunBooking.Domain.Entities
{
    [Table("Booking")]
    public class Booking
    {
        public Booking(DateTime checkIn, DateTime checkOut, string name)
        {
            Name = name;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Active = true;
        }

        public int Id { get; set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public void CancelBooking() => Active = false;
        public void ModifyBooking(DateTime checkIn, DateTime checkOut)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
    }
}
