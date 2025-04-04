

using DoctorBooking.DoctorAvailability.DAL.EFStructures;
using DoctorBooking.DoctorAvailability.Models;
using DoctorBooking.Host.Filters.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DoctorBooking.DoctorAvailability.DAL.Repos
{
    public class DoctorSlotRepo
    {
        private readonly AvailabilityDbContext _context;
        public DoctorSlotRepo(AvailabilityDbContext context)
        {
            _context = context;
        }



        public async Task<List<DoctorSlotEntity>> GetAllSlotsAsync()
        {
            var list =  await _context.DoctorSlots.ToListAsync();
            return list;
        }

        public async Task AddSlotAsync(DoctorSlotEntity slot)
        {
            await _context.DoctorSlots.AddAsync(slot);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> isSlotReservedAsync(Guid slotId)
        {
            var slot = await _context.DoctorSlots.FindAsync(slotId);
            return slot.IsReserved ? true : false;

        }

        public async Task ReserveSlotAsync(Guid slotId)
        {
            var slotToReserve = await _context.DoctorSlots.FindAsync(slotId);
            if (slotToReserve != null && !slotToReserve.IsReserved)
            {
                slotToReserve.IsReserved = true;
               await _context.SaveChangesAsync();
                return;

            }
            else
            {
                throw new ConflictException("Slot is already reserved") { Code = "SlotConflict" };

            }
        }


    }
}
