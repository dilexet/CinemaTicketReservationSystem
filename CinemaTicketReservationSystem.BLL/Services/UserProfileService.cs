﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Models.Results.UserProfile;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileService(IRepository<UserProfile> userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<UserProfileResult> UpdateUserProfile(Guid id, UserProfileModel userProfileModel)
        {
            var userProfile = await _userProfileRepository.FindByIdAsync(id);

            userProfile.Name = userProfileModel.Name;
            userProfile.Surname = userProfileModel.Surname;

            if (!await _userProfileRepository.UpdateAsync(userProfile))
            {
                return new UserProfileResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            UserProfileModel newUserProfileModel = _mapper.Map<UserProfileModel>(userProfile);

            return new UserProfileResult()
            {
                Success = true,
                UserProfile = newUserProfileModel
            };
        }

        public async Task<UserProfileResult> GetUserProfileById(Guid id, bool showPastTickets)
        {
            var user = await _userProfileRepository.FindByIdAsync(id);

            var tickets = showPastTickets
                ? user.Tickets.Where(x => x.ReservedSessionSeats.Last().Session.StartDate < DateTime.Now)
                : user.Tickets.Where(x => x.ReservedSessionSeats.Last().Session.StartDate > DateTime.Now);

            UserProfileModel userModel = _mapper.Map<UserProfileModel>(user);
            userModel.Tickets = _mapper.Map<IEnumerable<BookedOrderModel>>(tickets);

            return new UserProfileResult()
            {
                Success = true,
                UserProfile = userModel
            };
        }
    }
}