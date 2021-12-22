using System;
using System.Linq;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.DAL.Entity;
using Microsoft.Extensions.Options;

namespace CinemaTicketReservationSystem.BLL.Utils
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IOptions<RefreshTokenOptions> _options;

        public RefreshTokenService(IOptions<RefreshTokenOptions> options)
        {
            _options = options;
        }

        public RefreshToken Generate(string tokenId, Guid userId)
        {
            if (string.IsNullOrEmpty(tokenId))
            {
                throw new ArgumentNullException(nameof(tokenId));
            }

            if (userId.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var lifeTime = _options.Value.RefreshTokenExpirationMinutes;

            if (lifeTime.Equals(0))
            {
                throw new Exception("Token options is null or empty: " + nameof(_options.Value.RefreshTokenSecret));
            }

            var now = DateTime.Now;
            var refreshToken = new RefreshToken()
            {
                JwtId = tokenId,
                IsUsed = false,
                UserId = userId,
                AddedDate = now,
                ExpiryDate = now.AddMinutes(lifeTime),
                IsRevoked = false,
                Token = RandomString(25) + Guid.NewGuid()
            };
            return refreshToken;
        }

        // TODO: added validation checks
        // TODO: remove refresh tokens that have expired
        public bool Validate(RefreshToken refreshToken)
        {
            if (DateTime.Compare(refreshToken.ExpiryDate, DateTime.Now) <= 0)
            {
                return false;
            }

            return true;
        }

        private string RandomString(int length)
        {
            var random = new Random();
            var chars = _options.Value.RefreshTokenSecret;

            if (string.IsNullOrEmpty(chars))
            {
                throw new Exception(
                    "Refresh token options is null or empty: " + nameof(_options.Value.RefreshTokenSecret));
            }

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}