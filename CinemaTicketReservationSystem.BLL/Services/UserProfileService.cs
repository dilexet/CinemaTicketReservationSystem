using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Models.Results.UserProfile;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IRepository<BookedOrder> _bookedOrderRepository;
        private readonly IMapper _mapper;

        public UserProfileService(
            IRepository<UserProfile> userProfileRepository,
            IRepository<BookedOrder> bookedOrderRepository,
            IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _bookedOrderRepository = bookedOrderRepository;
            _mapper = mapper;
        }

        public async Task<UserProfileResult> UpdateUserProfile(Guid id, UserProfileModel userProfileModel)
        {
            var userProfile = await _userProfileRepository.FindByIdAsync(id);

            userProfile.Name = userProfileModel.Name;
            userProfile.Surname = userProfileModel.Surname;

            if (!await _userProfileRepository.UpdateAsync(userProfile))
            {
                return new UserProfileResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            UserProfileModel newUserProfileModel = _mapper.Map<UserProfileModel>(userProfile);

            return new UserProfileResult
            {
                Success = true,
                UserProfile = newUserProfileModel
            };
        }

        public async Task<UserProfileResult> GetUserProfileById(Guid id, bool showPastTickets)
        {
            var user = await _userProfileRepository.FindByIdAsync(id);

            var tickets = _bookedOrderRepository.GetBy(x => x.UserProfileId == user.Id);

            tickets = showPastTickets
                ? tickets
                    .Where(x => x.ReservedSessionSeats.FirstOrDefault().Session.StartDate < DateTime.Now)
                : tickets
                    .Where(x => x.ReservedSessionSeats.FirstOrDefault().Session.StartDate > DateTime.Now);

            UserProfileModel userModel = _mapper.Map<UserProfileModel>(user);
            userModel.TicketsModel = _mapper.Map<IEnumerable<BookedOrderModel>>(await tickets.ToListAsync());

            return new UserProfileResult
            {
                Success = true,
                UserProfile = userModel
            };
        }
    }
}