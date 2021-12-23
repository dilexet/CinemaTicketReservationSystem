namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Seat : BasedEntity
    {
        public uint NumberSeat { get; set; }

        public SeatType SeatType { get; set; }
    }
}