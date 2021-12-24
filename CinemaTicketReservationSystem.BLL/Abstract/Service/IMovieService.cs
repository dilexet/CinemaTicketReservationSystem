﻿using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Results.Movie;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IMovieService
    {
        Task<MovieServiceResult> AddMovie(MovieModel movieModel);
    }
}