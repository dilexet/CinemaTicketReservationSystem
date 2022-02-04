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
using CinemaTicketReservationSystem.BLL.Models.Results.MovieFilter;
using CinemaTicketReservationSystem.BLL.Models.Results.Search;
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
            if (!string.IsNullOrEmpty(movieFilterParametersModel.MovieName))
            {
                movies =
                    movies.Where(movie =>
                        movie.Name.Contains(movieFilterParametersModel.MovieName));
            }

            if (!string.IsNullOrEmpty(movieFilterParametersModel.CinemaName))
            {
                movies =
                    movies.Where(movie =>
                        movie.Sessions.Any(x =>
                            x.Hall.Cinema.Name.Contains(movieFilterParametersModel.CinemaName)));
            }

            if (!string.IsNullOrEmpty(movieFilterParametersModel.CityName))
            {
                movies =
                    movies.Where(movie =>
                        movie.Sessions.Any(x =>
                            x.Hall.Cinema.Address.CityName.Contains(movieFilterParametersModel.CityName)));
            }

            if (movieFilterParametersModel.StartDate != null)
            {
                movies =
                    movies.Where(movie =>
                        movie.Sessions.Any(x => x.StartDate.Date == movieFilterParametersModel.StartDate.Value.Date));
            }

            if (movieFilterParametersModel.NumberAvailableSeats != null &&
                movieFilterParametersModel.NumberAvailableSeats != 0)
            {
                movies =
                    movies.Where(movie =>
                        movie.Sessions.Any(x =>
                            x.SessionSeats.Count(sessionSeat => sessionSeat.TicketState == TicketState.Free) >=
                            movieFilterParametersModel.NumberAvailableSeats));
            }

            var moviesModel = _mapper.Map<IEnumerable<MovieModel>>(await movies.ToListAsync());

            return new MovieServiceGetMoviesResult()
            {
                Success = true,
                MovieModels = moviesModel
            };
        }

        public async Task<GetSessionsResult> GetSessionsForMovie(Guid movieId)
        {
            var sessions = _sessionRepository.GetBy(x => x.MovieId.Equals(movieId))
                .Where(x => x.StartDate >= DateTime.Today);
            var movie = await _movieRepository.FindByIdAsync(movieId);

            if (!sessions.Any())
            {
                return new GetSessionsResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No sessions found"
                    }
                };
            }

            var sessionsModel = _mapper.Map<IEnumerable<SessionModel>>(await sessions.ToListAsync());
            var movieModel = _mapper.Map<MovieModel>(movie);

            return new GetSessionsResult()
            {
                Success = true,
                Sessions = sessionsModel,
                Movie = movieModel
            };
        }

        public async Task<SearchSuggestionResult> GetListOfMovieTitles(string movieTitleSearchQuery)
        {
            IQueryable<Movie> movies = string.IsNullOrEmpty(movieTitleSearchQuery)
                ? _movieRepository.GetBy()
                : _movieRepository.GetBy(x => x.Name.Contains(movieTitleSearchQuery));

            var moviesTitle = await movies.Select(x => x.Name).ToListAsync();
            return new SearchSuggestionResult()
            {
                Success = true,
                ListOfTitles = moviesTitle
            };
        }

        public async Task<SearchSuggestionResult> GetListOfCinemaNames(string cinemaNameSearchQuery)
        {
            IQueryable<Cinema> cinemas = string.IsNullOrEmpty(cinemaNameSearchQuery)
                ? _cinemaRepository.GetBy()
                : _cinemaRepository.GetBy(x => x.Name.Contains(cinemaNameSearchQuery));

            var cinemasName = await cinemas.Select(x => x.Name).ToListAsync();
            return new SearchSuggestionResult()
            {
                Success = true,
                ListOfTitles = cinemasName
            };
        }

        public async Task<SearchSuggestionResult> GetListOfCityNames(string cityNameSearchQuery)
        {
            IQueryable<Address> addresses = string.IsNullOrEmpty(cityNameSearchQuery)
                ? _addressRepository.GetBy()
                : _addressRepository.GetBy(x => x.CityName.Contains(cityNameSearchQuery));

            var cityNames = await addresses.Select(x => x.CityName).ToListAsync();
            return new SearchSuggestionResult()
            {
                Success = true,
                ListOfTitles = cityNames
            };
        }
    }
}