
using DoctorBooking.DoctorAvailability.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorBooking.DoctorAvailability.DAL.EFStructures
{
    public class AvailabilityDbContext : DbContext
    {
        public AvailabilityDbContext(DbContextOptions<AvailabilityDbContext> options) : base(options)
        {
        }

        public DbSet<DoctorSlotEntity> DoctorSlotEntities { get; set; }
    }
}
