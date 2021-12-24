using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.SessionEntity
{
    public class SessionAdditionalService : BasedEntity
    {
        public AdditionalService AdditionalService { get; set; }

        public decimal Price { get; set; }
    }
}