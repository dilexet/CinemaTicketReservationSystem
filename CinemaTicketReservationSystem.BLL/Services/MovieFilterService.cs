using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.BLL.Models.Results.Movie;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class MovieFilterService : IMovieFilterService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Cinema> _cinemaRepository;

        public MovieFilterService(
            IMapper mapper,
            IRepository<Session> sessionRepository,
            IRepository<Movie> movieRepository,
            IRepository<Cinema> cinemaRepository)
        {
            _mapper = mapper;
            _sessionRepository = sessionRepository;
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
        }

        public async Task<MovieServiceGetMoviesResult> GetMoviesByFilter(
            MovieFilterParametersModel movieFilterParametersModel)
        {
            var movies = _movieRepository.GetBy();
            if (movieFilterParametersModel.MovieName != null)
            {
                movies =
                    movies.Where(movie =>
                        movie.Name.Contains(movieFilterParametersModel.MovieName));
            }

            if (movieFilterParametersModel.CinemaName != null)
            {
                movies =
                    movies.Where(movie =>
                        movie.Sessions.Where(x =>
                            x.Hall.Cinema.Name.Contains(movieFilterParametersModel.CinemaName)) != null);
            }

            if (movieFilterParametersModel.CityName != null)
            {
                movies =
                    movies.Where(movie =>
                        movie.Sessions.Where(x =>
                            x.Hall.Cinema.Address.CityName.Contains(movieFilterParametersModel.CityName)) != null);
            }

            if (movieFilterParametersModel.StartDate != null)
            {
                movies =
                    movies.Where(movie =>
                        movie.StartDate >= movieFilterParametersModel.StartDate);
            }

            if (movieFilterParametersModel.NumberAvailableSeats != 0)
            {
                movies =
                    movies.Where(movie =>
                        movie.Sessions.Where(x =>
                            x.SessionSeats.Count(sessionSeat => sessionSeat.TicketState == TicketState.Free) >=
                            movieFilterParametersModel.NumberAvailableSeats) != null);
            }

            if (movies == null || !movies.Any())
            {
                return new MovieServiceGetMoviesResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No movies found"
                    }
                };
            }

            var moviesModel = _mapper.Map<IEnumerable<MovieModel>>(await movies.ToListAsync());

            return new MovieServiceGetMoviesResult()
            {
                Success = true,
                MovieModels = moviesModel
            };
        }

        public async Task<SessionServiceGetAllResult> GetSessionsForMovie(Guid movieId)
        {
            var sessions = _sessionRepository.GetBy(x => x.MovieId.Equals(movieId));

            if (sessions == null || !sessions.Any())
            {
                return new SessionServiceGetAllResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No sessions found"
                    }
                };
            }

            var sessionsModel = _mapper.Map<IEnumerable<SessionModel>>(await sessions.ToListAsync());

            return new SessionServiceGetAllResult()
            {
                Success = true,
                Sessions = sessionsModel
            };
        }

        // TODO: maybe you need to take it to a individual service
        public async Task<IEnumerable<string>> GetListOfMovieTitles(string movieTitleSearchQuery)
        {
            var movies = _movieRepository.GetBy(x => x.Name.Contains(movieTitleSearchQuery));
            if (movies == null || !movies.Any())
            {
                // TODO
                return null;
            }

            var moviesTitle = await movies.Select(x => x.Name).ToListAsync();
            return moviesTitle;
        }

        public async Task<IEnumerable<string>> GetListOfCinemaNames(string cinemaTitleSearchQuery)
        {
            var cinemas = _cinemaRepository.GetBy(x => x.Name.Contains(cinemaTitleSearchQuery));
            if (cinemas == null || !cinemas.Any())
            {
                // TODO
                return null;
            }

            var cinemasName = await cinemas.Select(x => x.Name).ToListAsync();
            return cinemasName;
        }

        public async Task<IEnumerable<string>> GetListOfCityNames(string cityTitleSearchQuery)
        {
            var cinemas = _cinemaRepository.GetBy(x => x.Address.CityName.Contains(cityTitleSearchQuery));
            if (cinemas == null || !cinemas.Any())
            {
                // TODO
                return null;
            }

            var cityNames = await cinemas.Select(x => x.Address.CityName).ToListAsync();
            return cityNames;
        }
    }
}