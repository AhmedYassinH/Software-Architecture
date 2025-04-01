

using DoctorBooking.DoctorAvailability.DAL.EFStructures;
using DoctorBooking.DoctorAvailability.Models;

namespace DoctorBooking.DoctorAvailability.DAL.Repos
{
    public class DoctorSlotRepo
    {
        private readonly AvailabilityDbContext _context;
        public DoctorSlotRepo(AvailabilityDbContext context)
        {
            _context = context;
        }



        public List<DoctorSlotEntity> GetAllSlots()
        {
            return _context.DoctorSlots.ToList();
        }

        public void AddSlot(DoctorSlotEntity slot)
        {
            _context.DoctorSlots.Add(slot);
            _context.SaveChanges();
        }

        public void ReserveSlot(DoctorSlotEntity slot)
        {
            var slotToReserve = _context.DoctorSlots.Find(slot.Id);
            if (slotToReserve != null && !slotToReserve.IsReserved)
            {
                slotToReserve.IsReserved = true;
                _context.SaveChanges();
                return;

            }
            else
            {
                throw new Exception("Slot is already reserved");
            }
        }



    }
}
