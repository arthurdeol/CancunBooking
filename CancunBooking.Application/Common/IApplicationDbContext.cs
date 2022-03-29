using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CancunBooking.Application.Common
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Booking> Bookings { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
