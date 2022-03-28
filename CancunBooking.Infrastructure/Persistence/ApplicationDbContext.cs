using CancunBooking.Application.Common;
using CancunBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CancunBooking.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }

    }
}
