using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionSeatType : BasedEntity
    {
        public SeatType SeatType { get; set; }

        public decimal Price { get; set; }
    }
}