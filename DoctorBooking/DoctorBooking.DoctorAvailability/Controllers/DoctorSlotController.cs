
using DoctorBooking.DoctorAvailability.Contracts;
using DoctorBooking.DoctorAvailability.Models;
using DoctorBooking.DoctorAvailability.Services;
using DoctorBooking.Shared.Exceptions;
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
        public async Task<ActionResult> AddSlotAsync([FromBody] AddSlotRequest request)
        {
            if (!ModelState.IsValid)
            {

                Dictionary<string, string[]> errors = ModelState.ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(y => y.ErrorMessage).ToArray());

                throw new ValidationException(errors);
            }
            await _service.AddSlotAsync(request);
            return Ok();
        }

        [HttpPut("ReserveSlot")]
        public async Task<ActionResult> ReserveSlotAsync(Guid slotId)
        {
            if (!ModelState.IsValid)
            {

                Dictionary<string, string[]> errors = ModelState.ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(y => y.ErrorMessage).ToArray());

                throw new ValidationException(errors);
            }
            await _service.ReserveSlotAsync(slotId);
            return Ok();
        }
    }
}
