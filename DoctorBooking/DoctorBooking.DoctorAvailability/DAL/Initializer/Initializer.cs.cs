
using DoctorBooking.DoctorAvailability.DAL.EFStructures;
using DoctorBooking.DoctorAvailability.Models;


namespace DoctorBooking.DoctorAvailability.DAL.Initializer
{
    public class Initializer
    {
        // 5 Dummy records 
        public static List<DoctorSlotEntity> Slots = new()
        {
            new ()
            {
                Id = new Guid(),
                DoctorId = Guid.Parse("a1b2c3d4-e5f6-4a5b-9c8d-1e2f3a4b5c6d"),
                Time = new DateTime(2022, 10, 10, 10, 0, 0),
                Cost = 100,
                IsReserved = false
            },
            new ()
            {
                Id = new Guid(),
                DoctorId = Guid.Parse("a1b2c3d4-e5f6-4a5b-9c8d-1e2f3a4b5c6d"),
                Time = new DateTime(2022, 10, 10, 11, 0, 0),
                Cost = 100,
                IsReserved = false
            },
            new ()
            {
                Id = new Guid(),
                DoctorId = Guid.Parse("a1b2c3d4-e5f6-4a5b-9c8d-1e2f3a4b5c6d"),
                Time = new DateTime(2022, 10, 10, 12, 0, 0),
                Cost = 100,
                IsReserved = false
            },
            new ()
            {
                Id = new Guid(),
                DoctorId = Guid.Parse("a1b2c3d4-e5f6-4a5b-9c8d-1e2f3a4b5c6d"),
                Time = new DateTime(2022, 10, 10, 13, 0, 0),
                Cost = 100,
                IsReserved = false
            },

        };

       

        public static void InitializeData(AvailabilityDbContext context)
        {
            context.Database.EnsureCreated();
            context.DoctorSlotEntities.AddRange(Slots);
            context.SaveChanges();
        }

    }
}