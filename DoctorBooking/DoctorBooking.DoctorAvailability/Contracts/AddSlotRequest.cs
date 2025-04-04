
using System.ComponentModel.DataAnnotations;

namespace DoctorBooking.DoctorAvailability.Contracts
{
    public class AddSlotRequest
    {
        [Required]
        public DateTime Time { get; set; }
        
        [Required]
        public Guid DoctorId { get; set; }
        
        [Required]
        public decimal Cost { get; set; }
    }
}
