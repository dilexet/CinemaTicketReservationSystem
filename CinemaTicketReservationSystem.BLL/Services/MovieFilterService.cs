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
using CinemaTicketReservationSystem.BLL.Models.Results.Search;
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
        private readonly IRepository<Address> _addressRepository;

        public MovieFilterService(
            IMapper mapper,
            IRepository<Session> sessionRepository,
            IRepository<Movie> movieRepository,
            IRepository<Cinema> cinemaRepository,
            IRepository<Address> addressRepository)
        {
            _mapper = mapper;
            _sessionRepository = sessionRepository;
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
            _addressRepository = addressRepository;
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

        public async Task<SearchSuggestionResult> GetListOfMovieTitles(string movieTitleSearchQuery)
        {
            var movies = _movieRepository.GetBy(x => x.Name.Contains(movieTitleSearchQuery));

            var moviesTitle = await movies.Select(x => x.Name).ToListAsync();
            return new SearchSuggestionResult()
            {
                Success = true,
                ListOfTitles = moviesTitle
            };
        }

        public async Task<SearchSuggestionResult> GetListOfCinemaNames(string cinemaNameSearchQuery)
        {
            var cinemas = _cinemaRepository.GetBy(x => x.Name.Contains(cinemaNameSearchQuery));

            var cinemasName = await cinemas.Select(x => x.Name).ToListAsync();
            return new SearchSuggestionResult()
            {
                Success = true,
                ListOfTitles = cinemasName
            };
        }

        public async Task<SearchSuggestionResult> GetListOfCityNames(string cityNameSearchQuery)
        {
            var cities = _addressRepository.GetBy(x => x.CityName.Contains(cityNameSearchQuery));

            var cityNames = await cities.Select(x => x.CityName).ToListAsync();
            return new SearchSuggestionResult()
            {
                Success = true,
                ListOfTitles = cityNames
            };
        }
    }
}