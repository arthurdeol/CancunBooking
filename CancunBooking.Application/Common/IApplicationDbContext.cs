using Microsoft.EntityFrameworkCore;

namespace CancunBooking.Application.Common
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Booking> Bookings { get; }
    }
}
