
using DoctorBooking.DoctorAvailability.Contracts;
using DoctorBooking.DoctorAvailability.DAL.Repos;
using DoctorBooking.DoctorAvailability.Models;
using DoctorBooking.Host.Filters.Exceptions;

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

        public async Task AddSlotAsync(AddSlotRequest request)
        {
            if (request.DoctorId != new Guid("a1b2c3d4-e5f6-4a5b-9c8d-1e2f3a4b5c6d"))
            {
                throw new NotFoundException("Invalid Doctor Id")
                {
                    Code = "DoctorNotFound"
                };
            }
            var slot = new DoctorSlotEntity
            {
                Id = Guid.NewGuid(),
                DoctorId = request.DoctorId,
                Time = request.Time,
                Cost = request.Cost,
                IsReserved = false
            };
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
            else
            {
                throw new ConflictException("Slot is already reserved") { Code = "SlotConflict" };

            }
        }
    }
}
