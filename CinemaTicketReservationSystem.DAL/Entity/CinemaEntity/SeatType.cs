namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class SeatType : BasedEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}