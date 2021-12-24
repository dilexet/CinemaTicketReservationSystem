using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Cinema : BasedEntity
    {
        public string Name { get; set; }

        public string CityName { get; set; }

        public uint NumberOfHalls { get; set; }

        public IEnumerable<Session> Sessions { get; set; }

        public IEnumerable<Hall> Halls { get; set; }
    }
}