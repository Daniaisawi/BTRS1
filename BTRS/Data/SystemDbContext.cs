using BTRS.Models;
using Microsoft.EntityFrameworkCore;

namespace BTRS.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Bus> buses { set; get; }
        public DbSet<BusTrip> trips { set; get; }
        public DbSet<Passenger> passengers { set; get; }
        public DbSet<Booking> booking{ set; get; }
        public DbSet<Administrator> admin { set; get; }

    }
}
