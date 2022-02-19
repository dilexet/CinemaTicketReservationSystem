using System;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Address : BasedEntity
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public Guid CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}