
using DoctorBooking.DoctorAvailability.Models;
using DoctorBooking.DoctorAvailability.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorBooking.DoctorAvailability.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorSlotController : ControllerBase
    {
        private readonly DoctorSlotService _service;
        public DoctorSlotController(DoctorSlotService service)
        {
            _service = service;
        }


        [HttpGet("GetAllSlots")]
        public async Task<ActionResult<List<DoctorSlotEntity>>> GetAllSlots()
        {
            var slots = await _service.GetAllSlots();
            return Ok(slots);   
        }

        [HttpPost("AddSlot")]
        public async Task<ActionResult> AddSlotAsync(DoctorSlotEntity slot)
        {
            await _service.AddSlotAsync(slot);
            return Ok();
        }

        [HttpPut("ReserveSlot")]
        public async Task<ActionResult> ReserveSlotAsync(Guid slotId)
        {
            await _service.ReserveSlotAsync(slotId);
            return Ok();
        }
    }
}
