﻿using System;

namespace CinemaTicketReservationSystem.DAL.Entity.CinemaEntity
{
    public class Address : BasedEntity
    {
        public string CityName { get; set; }

        public string Street { get; set; }

        public Guid CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}