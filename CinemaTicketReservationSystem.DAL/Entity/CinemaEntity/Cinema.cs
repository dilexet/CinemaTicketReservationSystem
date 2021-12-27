using System.Collections.Generic;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Cinema : BasedEntity
    {
        public string Name { get; set; }

        public uint NumberOfHalls { get; set; }

        public virtual Address Address { get; set; }

        public virtual IEnumerable<AdditionalService> AdditionalServices { get; set; }

        public virtual IEnumerable<Hall> Halls { get; set; }
    }
}