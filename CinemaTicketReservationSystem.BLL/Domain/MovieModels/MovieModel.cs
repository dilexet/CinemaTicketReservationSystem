﻿using System;

namespace CinemaTicketReservationSystem.BLL.Domain.MovieModels
{
    public class MovieModel
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieDescriptionModel MovieDescriptionModel { get; set; }
    }
}