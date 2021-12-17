using System;
using CinemaTicketReservationSystem.DAL.Entity;

namespace CinemaTicketReservationSystem.DAL.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckPassword(string hashPassword, string password);
        String HasPasswordAsync(string password);
    }
}