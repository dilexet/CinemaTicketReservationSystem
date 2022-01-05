using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionAdditionalService : BasedEntity
    {
        public double Price { get; set; }

        public Guid AdditionalServiceId { get; set; }

        public virtual AdditionalService AdditionalService { get; set; }

        public Guid SessionId { get; set; }

        public virtual Session Session { get; set; }

        public virtual IEnumerable<BookedOrder> BookedOrders { get; set; }
    }
}