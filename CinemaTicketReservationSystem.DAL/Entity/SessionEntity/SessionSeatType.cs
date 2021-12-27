namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionSeatType : BasedEntity
    {
        public double Price { get; set; }

        public string SeatType { get; set; }

        public virtual SessionSeat SessionSeat { get; set; }
    }
}