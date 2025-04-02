﻿
using DoctorBooking.DoctorAvailability.Models;
using DoctorBooking.DoctorAvailability.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorBooking.DoctorAvailability.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorSlotController
    {
        private readonly DoctorSlotService _service;
        public DoctorSlotController(DoctorSlotService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<List<DoctorSlotEntity>> GetAllSlots(DoctorSlotService service)
        {
            return await _service.GetAllSlots();
        }

        [HttpPost]
        public async Task AddSlotAsync(DoctorSlotEntity slot)
        {
            await _service.AddSlotAsync(slot);
        }

        [HttpPut]
        public async Task ReserveSlotAsync(Guid slotId)
        {
            await _service.ReserveSlotAsync(slotId);
        }
    }
}
