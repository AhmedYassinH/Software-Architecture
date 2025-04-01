

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

        public bool isSlotReserved(Guid slotId)
        {
            var slot = _context.DoctorSlots.Find(slotId);
            return slot.IsReserved ? true : false;

        }

        public void ReserveSlot(Guid slotId)
        {
            var slotToReserve = _context.DoctorSlots.Find(slotId);
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
