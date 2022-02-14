using System;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.BookingEntity
{
    public class BookedService : BasedEntity
    {
        public uint NumberOfServices { get; set; }

        public Guid BookedOrderId { get; set; }

        public Guid SessionAdditionalServiceId { get; set; }

        public virtual BookedOrder BookedOrder { get; set; }

        public virtual SessionAdditionalService SelectedSessionAdditionalService { get; set; }
    }
}