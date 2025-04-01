
using DoctorBooking.DoctorAvailability.Models;
using DoctorBooking.DoctorAvailability.Services;

namespace DoctorBooking.DoctorAvailability.Controllers
{
    public class DoctorSlotController
    {
        private readonly DoctorSlotService _service;
        public DoctorSlotController(DoctorSlotService service)
        {
            _service = service;
        }
  
        public async Task<List<DoctorSlotEntity>> GetAllSlots()
        {
            return await _service.GetAllSlots();
        }
        public async Task AddSlotAsync(DoctorSlotEntity slot)
        {
            await _service.AddSlotAsync(slot);
        }
        public async Task ReserveSlotAsync(Guid slotId)
        {
            await _service.ReserveSlotAsync(slotId);
        }
    }
}
