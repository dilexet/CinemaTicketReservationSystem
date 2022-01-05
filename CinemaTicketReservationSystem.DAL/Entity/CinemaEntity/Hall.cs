using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Hall : BasedEntity
    {
        public string Name { get; set; }

        public uint NumberOfSeats { get; set; }

        public string SeatTypesString { get; set; }

        public Guid CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual IEnumerable<Session> Sessions { get; set; }

        public virtual IEnumerable<Row> Rows { get; set; }

        public IEnumerable<string> SeatTypes
        {
            get => SeatTypesString.Split(',').ToList();
            set => SeatTypesString = string.Join(",", value);
        }
    }
}