using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Models.Results.UserProfile;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IUserProfileService
    {
        Task<UserProfileResult> UpdateUserProfile(Guid id, UserProfileModel userProfileModel);

        Task<UserProfileResult> GetUserProfileById(Guid id, bool showPastTickets = false);
    }
}