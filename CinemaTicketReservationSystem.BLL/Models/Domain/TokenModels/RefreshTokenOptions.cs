﻿namespace CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels
{
    public class RefreshTokenOptions
    {
        public string RefreshTokenSecret { get; set; }

        public int RefreshTokenExpirationHours { get; set; }
    }
}