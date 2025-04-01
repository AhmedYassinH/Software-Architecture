
using DoctorBooking.DoctorAvailability.DAL.Repos;
using DoctorBooking.DoctorAvailability.Models;

namespace DoctorBooking.DoctorAvailability.Services
{
    public class DoctorSlotService
    {
        private readonly DoctorSlotRepo _repo;
        public DoctorSlotService(DoctorSlotRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<DoctorSlotEntity>> GetAllSlots()
        {
            return await _repo.GetAllSlotsAsync();
        }

        public async Task AddSlotAsync(DoctorSlotEntity slot)
        {
            await _repo.AddSlotAsync(slot);
        }

        public async Task ReserveSlotAsync(Guid slotId)
        {
            // Check if the slot is reserved or not first then reserve if not 
            var isReserved = await _repo.isSlotReservedAsync(slotId);
            if (!isReserved)
            {
                await _repo.ReserveSlotAsync(slotId);
            }
            else { throw new Exception("Slot is already reserved"); }

        }
    }
}
