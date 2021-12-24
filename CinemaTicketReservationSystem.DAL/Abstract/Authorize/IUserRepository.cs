using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;

namespace CinemaTicketReservationSystem.DAL.Abstract.Authorize
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckPassword(string hashPassword, string password);

        string HashPassword(string password);
    }
}