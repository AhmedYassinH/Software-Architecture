

using System.ComponentModel.DataAnnotations;

namespace DoctorBooking.DoctorAvailability.Models
{
    public class DoctorSlotEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Time { get; set; }
        public Guid DoctorId { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
