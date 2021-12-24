using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Hall : BasedEntity
    {
        public string Name { get; set; }

        public uint NumberOfSeats { get; set; }

        public Guid CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public IEnumerable<Session> Sessions { get; set; }

        public IEnumerable<Row> Rows { get; set; }
    }
}