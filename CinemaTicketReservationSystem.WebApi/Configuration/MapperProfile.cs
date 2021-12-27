using AutoMapper;
using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Domain.CinemaModels;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Filters;
using CinemaTicketReservationSystem.BLL.Results.Authorize;
using CinemaTicketReservationSystem.BLL.Results.Cinema;
using CinemaTicketReservationSystem.BLL.Results.Movie;
using CinemaTicketReservationSystem.BLL.Results.UserManagement;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.WebApi.Models.Filters;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using CinemaTicketReservationSystem.WebApi.Models.Response.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Response.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Response.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Response.UserManagement;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, TokenUserModel>().ForMember(
                dest => dest.Role,
                source => source.MapFrom(res => res.Role.Name));
            CreateMap<RegisterModel, User>();

            CreateMap<UserLoginRequest, LoginModel>();
            CreateMap<UserRegisterRequest, RegisterModel>();

            CreateMap<AuthorizeResult, AuthorizeResponse>();

            CreateMap<UserModel, UserViewModel>().ForMember(
                dest => dest.RoleName,
                source => source.MapFrom(res => res.RoleModel.Name));

            CreateMap<UserCreateRequest, UserModel>().ForMember(
                dest => dest.RoleModel,
                source => source.MapFrom(res => new RoleModel()
                {
                    Name = res.RoleName
                }));

            CreateMap<UserUpdateRequest, UserModel>().ForMember(
                dest => dest.RoleModel,
                source => source.MapFrom(res => new RoleModel()
                {
                    Name = res.RoleName
                }));

            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>().ForMember(
                dest => dest.RoleModel,
                source => source.MapFrom(res => new RoleModel()
                {
                    Name = res.Role.Name
                }));

            CreateMap<UserManagementGetUsersResult, UserManagementGetUsersResponse>().ForMember(
                dest => dest.Users,
                source => source.MapFrom(
                    res => res.UserModels));

            CreateMap<UserManagementResult, UserManagementResponse>().ForMember(
                dest => dest.User,
                source => source.MapFrom(
                    res => res.UserModel));

            CreateMap<UserManagementRemoveResult, UserManagementRemoveResponse>();

            CreateMap<MovieRequest, MovieModel>().ForMember(
                dest => dest.MovieDescriptionModel,
                source => source.MapFrom(res =>
                    new MovieDescriptionModel()
                    {
                        ReleaseDate = res.ReleaseDate,
                        Description = res.Description,
                        Countries = res.Countries,
                        Genres = res.Genres,
                    }));

            CreateMap<MovieDescription, MovieDescriptionModel>();
            CreateMap<MovieDescriptionModel, MovieDescription>();

            CreateMap<MovieModel, Movie>()
                .ForMember(
                    dest => dest.MovieDescription,
                    source =>
                        source.MapFrom(res => res.MovieDescriptionModel));

            CreateMap<Movie, MovieModel>().ForMember(
                dest => dest.MovieDescriptionModel,
                source =>
                    source.MapFrom(res => res.MovieDescription));

            CreateMap<MovieDescriptionModel, ModelDescriptionViewModel>();

            CreateMap<MovieModel, MovieViewModel>().ForMember(
                dest => dest.ModelDescriptionViewModel,
                source => source.MapFrom(res => res.MovieDescriptionModel));

            CreateMap<MovieServiceResult, MovieResponse>().ForMember(
                dest => dest.Movie,
                source => source.MapFrom(res => res.MovieModel));

            CreateMap<MovieServiceRemoveResult, MovieRemoveResponse>();
            CreateMap<MovieServiceGetMoviesResult, MovieGetAllResponse>()
                .ForMember(
                    dest => dest.Movies,
                    source =>
                        source.MapFrom(res => res.MovieModels));

            CreateMap<FilterParameters, FilterParametersModel>();

            CreateMap<AdditionalServiceRequest, AdditionalServiceModel>();

            CreateMap<SeatRequest, SeatModel>()
                .ForMember(
                    dest => dest.SeatType,
                    source => source.MapFrom(res => res.SeatType));

            CreateMap<RowRequest, RowModel>()
                .ForMember(
                    dest => dest.Seats,
                    source => source.MapFrom(res => res.Seats));

            CreateMap<HallRequest, HallModel>()
                .ForMember(
                    dest => dest.Rows,
                    source => source.MapFrom(res => res.Rows));

            CreateMap<CinemaRequest, CinemaModel>()
                .ForMember(
                    dest => dest.AddressModel,
                    source => source.MapFrom(res => new AddressModel()
                    {
                        CityName = res.CityName,
                        Street = res.Street
                    }))
                .ForMember(
                    dest => dest.Halls,
                    source => source.MapFrom(res => res.Halls))
                .ForMember(
                    dest => dest.AdditionalServices,
                    source => source.MapFrom(res => res.AdditionalServices));

            CreateMap<SeatModel, SeatViewModel>()
                .ForMember(
                    dest => dest.SeatType,
                    source => source.MapFrom(res => res.SeatType));

            CreateMap<RowModel, RowViewModel>()
                .ForMember(
                    dest => dest.Seats,
                    source => source.MapFrom(res => res.Seats));

            CreateMap<HallModel, HallViewModel>()
                .ForMember(
                    dest => dest.Rows,
                    source =>
                        source.MapFrom(res => res.Rows));

            CreateMap<AdditionalServiceModel, AdditionalServiceViewModel>();

            CreateMap<CinemaModel, CinemaViewModel>()
                .ForMember(
                    dest => dest.CityName,
                    source =>
                        source.MapFrom(res => res.AddressModel.CityName))
                .ForMember(
                    dest => dest.Street,
                    source =>
                        source.MapFrom(res => res.AddressModel.Street))
                .ForMember(
                    dest => dest.AdditionalServices,
                    source =>
                        source.MapFrom(res => res.AdditionalServices))
                .ForMember(
                    dest => dest.Halls,
                    source =>
                        source.MapFrom(res => res.Halls));

            CreateMap<Seat, SeatModel>()
                .ForMember(
                    dest => dest.SeatType,
                    source =>
                        source.MapFrom(res => res.SeatType));

            CreateMap<Row, RowModel>()
                .ForMember(
                    dest => dest.Seats,
                    source =>
                        source.MapFrom(res => res.Seats));

            CreateMap<Hall, HallModel>()
                .ForMember(
                    dest => dest.Rows,
                    source =>
                        source.MapFrom(res => res.Rows));

            CreateMap<AdditionalService, AdditionalServiceModel>();
            CreateMap<Address, AddressModel>();

            CreateMap<Cinema, CinemaModel>()
                .ForMember(
                    dest => dest.Halls,
                    source =>
                        source.MapFrom(res => res.Halls))
                .ForMember(
                    dest => dest.AddressModel,
                    source =>
                        source.MapFrom(res => res.Address))
                .ForMember(
                    dest => dest.AdditionalServices,
                    source =>
                        source.MapFrom(res => res.AdditionalServices));

            CreateMap<SeatModel, Seat>()
                .ForMember(
                    dest => dest.SeatType,
                    source =>
                        source.MapFrom(res => res.SeatType));

            CreateMap<RowModel, Row>()
                .ForMember(
                    dest => dest.Seats,
                    source =>
                        source.MapFrom(res => res.Seats));

            CreateMap<HallModel, Hall>()
                .ForMember(
                    dest => dest.Rows,
                    source =>
                        source.MapFrom(res => res.Rows));

            CreateMap<AdditionalServiceModel, AdditionalService>();
            CreateMap<AddressModel, Address>();

            CreateMap<CinemaModel, Cinema>()
                .ForMember(
                    dest => dest.Halls,
                    source =>
                        source.MapFrom(res => res.Halls))
                .ForMember(
                    dest => dest.Address,
                    source =>
                        source.MapFrom(res => res.AddressModel))
                .ForMember(
                    dest => dest.AdditionalServices,
                    source =>
                        source.MapFrom(res => res.AdditionalServices));

            CreateMap<CinemaServiceResult, CinemaResponse>().ForMember(
                dest => dest.Cinema,
                source => source.MapFrom(res => res.CinemaModel));

            CreateMap<CinemaServiceRemoveResult, CinemaRemoveResponse>();
            CreateMap<CinemaServiceGetAllResult, CinemaGetAllResponse>()
                .ForMember(
                    dest => dest.Cinemas,
                    source =>
                        source.MapFrom(res => res.CinemaModels));
        }
    }
}