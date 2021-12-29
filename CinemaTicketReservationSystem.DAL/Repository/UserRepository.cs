using System;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.DAL.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger)
            : base(context, logger)
        {
        }

        public bool CheckPassword(string hashPassword, string password)
        {
            if (string.IsNullOrEmpty(hashPassword))
            {
                throw new ArgumentNullException(nameof(hashPassword));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var result = BCrypt.Net.BCrypt.Verify(password, hashPassword);
            return result;
        }

        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashPassword;
        }
    }
}