using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity
{
    public class Role : BasedEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}