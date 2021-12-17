using System;

namespace CinemaTicketReservationSystem.DAL.Entity
{
    public class Role
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public User User { get; set; }
    }
}