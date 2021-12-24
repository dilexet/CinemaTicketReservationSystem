using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Results.Movie;
using CinemaTicketReservationSystem.DAL.Abstract.Movie;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieServiceResult> AddMovie(MovieModel movieModel)
        {
            var movieExist = await _movieRepository.FirstOrDefaultAsync(x => x.Name == movieModel.Name);
            if (movieExist != null)
            {
                return new MovieServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Movie is exists"
                    }
                };
            }

            var movie = _mapper.Map<Movie>(movieModel);

            if (!await _movieRepository.CreateAsync(movie))
            {
                return new MovieServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            MovieModel newMovieModel = _mapper.Map<MovieModel>(movie);

            return new MovieServiceResult()
            {
                Success = true,
                MovieModel = newMovieModel
            };
        }
    }
}