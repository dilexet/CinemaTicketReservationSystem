using System;
using System.Linq;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieFilter;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.BLL.Models.Results.AdditionalService;
using CinemaTicketReservationSystem.BLL.Models.Results.Authorize;
using CinemaTicketReservationSystem.BLL.Models.Results.Booking;
using CinemaTicketReservationSystem.BLL.Models.Results.Cinema;
using CinemaTicketReservationSystem.BLL.Models.Results.File;
using CinemaTicketReservationSystem.BLL.Models.Results.Hall;
using CinemaTicketReservationSystem.BLL.Models.Results.Movie;
using CinemaTicketReservationSystem.BLL.Models.Results.MovieFilter;
using CinemaTicketReservationSystem.BLL.Models.Results.Role;
using CinemaTicketReservationSystem.BLL.Models.Results.Search;
using CinemaTicketReservationSystem.BLL.Models.Results.SeatType;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;
using CinemaTicketReservationSystem.BLL.Models.Results.User;
using CinemaTicketReservationSystem.BLL.Models.Results.UserProfile;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;
using CinemaTicketReservationSystem.WebApi.Models.Filters;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Booking;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using CinemaTicketReservationSystem.WebApi.Models.Response.AdditionalService;
using CinemaTicketReservationSystem.WebApi.Models.Response.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Response.Booking;
using CinemaTicketReservationSystem.WebApi.Models.Response.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Response.File;
using CinemaTicketReservationSystem.WebApi.Models.Response.Hall;
using CinemaTicketReservationSystem.WebApi.Models.Response.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Response.MovieFilter;
using CinemaTicketReservationSystem.WebApi.Models.Response.Role;
using CinemaTicketReservationSystem.WebApi.Models.Response.Search;
using CinemaTicketReservationSystem.WebApi.Models.Response.Session;
using CinemaTicketReservationSystem.WebApi.Models.Response.UserManagement;
using CinemaTicketReservationSystem.WebApi.Models.Response.UserProfile;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Booking;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Movie;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.MovieFilter;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.User;

namespace CinemaTicketReservationSystem.WebApi.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, TokenUserModel>()
                .ForMember(
                    dest => dest.Role,
                    source => source.MapFrom(
                        res => res.Role.Name))
                .ForMember(
                    dest => dest.UserProfileId,
                    source => source.MapFrom(
                        res => res.UserProfile.Id));
            CreateMap<RegisterModel, User>();

            CreateMap<UserLoginRequest, LoginModel>();
            CreateMap<UserRegisterRequest, RegisterModel>();

            CreateMap<AuthorizeResult, AuthorizeResponse>();

            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, RoleViewModel>();

            CreateMap<User, UserModel>()
                .ForMember(
                    dest => dest.RoleModel,
                    source =>
                        source.MapFrom(res => res.Role));

            CreateMap<UserModel, UserViewModel>()
                .ForMember(
                    dest => dest.Role,
                    source =>
                        source.MapFrom(res => res.RoleModel));

            CreateMap<UserCreateRequest, UserModel>()
                .ForMember(
                    dest => dest.RoleModel,
                    source =>
                        source.MapFrom(res => new RoleModel()
                        {
                            Id = res.RoleId
                        }));

            CreateMap<UserUpdateRequest, UserModel>()
                .ForMember(
                    dest => dest.RoleModel,
                    source =>
                        source.MapFrom(res => new RoleModel()
                        {
                            Id = res.RoleId
                        }));

            CreateMap<UserModel, User>();

            CreateMap<RoleServiceGetRolesResult, RoleManagementGetRolesResponse>()
                .ForMember(
                    dest => dest.Roles,
                    source =>
                        source.MapFrom(res => res.RoleModels));

            CreateMap<UserServiceGetUsersResult, UserManagementGetUsersResponse>().ForMember(
                dest => dest.Users,
                source => source.MapFrom(
                    res => res.UserModels));

            CreateMap<UserServiceResult, UserManagementResponse>().ForMember(
                dest => dest.User,
                source => source.MapFrom(
                    res => res.UserModel));

            CreateMap<UserServiceRemoveResult, UserManagementRemoveResponse>();

            CreateMap<MovieRequest, MovieModel>()
                .ForMember(
                    dest => dest.MovieDescriptionModel,
                    source =>
                        source.MapFrom(res =>
                            new MovieDescriptionModel()
                            {
                                ReleaseDate = res.ReleaseDate,
                                Description = res.Description,
                                Countries = res.Countries,
                                Genres = res.Genres,
                            }))
                .ForMember(
                    dest => dest.PosterUrl,
                    source =>
                        source.MapFrom(res =>
                            new Uri(res.PosterUrl)));

            CreateMap<MovieDescription, MovieDescriptionModel>();
            CreateMap<MovieDescriptionModel, MovieDescription>();

            CreateMap<MovieModel, Movie>()
                .ForMember(
                    dest => dest.MovieDescription,
                    source =>
                        source.MapFrom(res => res.MovieDescriptionModel))
                .ForMember(
                    dest => dest.PosterUrl,
                    source =>
                        source.MapFrom(res => res.PosterUrl));

            CreateMap<Movie, MovieModel>().ForMember(
                dest => dest.MovieDescriptionModel,
                source =>
                    source.MapFrom(res => res.MovieDescription));

            CreateMap<MovieDescriptionModel, MovieDescriptionViewModel>();

            CreateMap<MovieModel, MovieViewModel>()
                .ForMember(
                    dest => dest.MovieDescription,
                    source =>
                        source.MapFrom(res => res.MovieDescriptionModel))
                .ForMember(
                    dest => dest.PosterUrl,
                    source =>
                        source.MapFrom(res => res.PosterUrl.OriginalString));

            CreateMap<MovieServiceResult, MovieResponse>().ForMember(
                dest => dest.Movie,
                source =>
                    source.MapFrom(res => res.MovieModel));

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
                    source =>
                        source.MapFrom(res => res.SeatType));

            CreateMap<RowRequest, RowModel>()
                .ForMember(
                    dest => dest.Seats,
                    source =>
                        source.MapFrom(res => res.Seats));

            CreateMap<HallRequest, HallModel>()
                .ForMember(
                    dest => dest.Rows,
                    source =>
                        source.MapFrom(res => res.Rows));

            CreateMap<CinemaRequest, CinemaModel>()
                .ForMember(
                    dest => dest.AddressModel,
                    source =>
                        source.MapFrom(res => new AddressModel()
                        {
                            CityName = res.CityName,
                            Street = res.Street
                        }));

            CreateMap<SeatModel, SeatViewModel>()
                .ForMember(
                    dest => dest.SeatType,
                    source =>
                        source.MapFrom(res => res.SeatType));

            CreateMap<RowModel, RowViewModel>()
                .ForMember(
                    dest => dest.Seats,
                    source =>
                        source.MapFrom(res => res.Seats));

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
                        source.MapFrom(res => res.AddressModel.Street));

            CreateMap<Seat, SeatModel>()
                .ForMember(
                    dest => dest.SeatType,
                    source =>
                        source.MapFrom(res => res.SeatType))
                .ForMember(
                    dest => dest.NumberRow,
                    source =>
                        source.MapFrom(res => res.Row.NumberRow));

            CreateMap<Row, RowModel>()
                .ForMember(
                    dest => dest.Seats,
                    source =>
                        source.MapFrom(res => res.Seats));

            CreateMap<Hall, HallModel>()
                .ForMember(
                    dest => dest.Rows,
                    source =>
                        source.MapFrom(res => res.Rows))
                .ForMember(
                    dest => dest.CinemaId,
                    source =>
                        source.MapFrom(res => res.CinemaId))
                .ForMember(
                    dest => dest.CinemaName,
                    source =>
                        source.MapFrom(res => res.Cinema.Name))
                .ForMember(
                    dest => dest.CityName,
                    source =>
                        source.MapFrom(res => res.Cinema.Address.CityName))
                .ForMember(
                    dest => dest.Street,
                    source =>
                        source.MapFrom(res => res.Cinema.Address.Street));

            CreateMap<AdditionalService, AdditionalServiceModel>()
                .ForMember(
                    dest => dest.CinemaName,
                    source =>
                        source.MapFrom(res => res.Cinema.Name))
                .ForMember(
                    dest => dest.CinemaId,
                    source =>
                        source.MapFrom(res => res.Cinema.Id));

            CreateMap<Address, AddressModel>();

            CreateMap<Cinema, CinemaModel>()
                .ForMember(
                    dest => dest.AddressModel,
                    source =>
                        source.MapFrom(res => res.Address));

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
                    dest => dest.Address,
                    source =>
                        source.MapFrom(res => res.AddressModel));

            CreateMap<CinemaServiceResult, CinemaResponse>().ForMember(
                dest => dest.Cinema,
                source => source.MapFrom(res => res.CinemaModel));

            CreateMap<CinemaServiceRemoveResult, CinemaRemoveResponse>();
            CreateMap<CinemaServiceGetAllResult, CinemaGetAllResponse>()
                .ForMember(
                    dest => dest.Cinemas,
                    source =>
                        source.MapFrom(res => res.CinemaModels));

            CreateMap<SeatTypeModel, SeatTypeViewModel>();

            CreateMap<SeatTypeServiceGetAllResult, SeatTypeGetAllResponse>()
                .ForMember(
                    dest => dest.SeatTypes,
                    source =>
                        source.MapFrom(res => res.SeatTypesList));

            CreateMap<AdditionalServiceGetAllResult, AdditionalServiceGetAllResponse>()
                .ForMember(
                    dest => dest.AdditionalServices,
                    source =>
                        source.MapFrom(res => res.AdditionalServices));

            CreateMap<AdditionalServiceResult, AdditionalServiceResponse>()
                .ForMember(
                    dest => dest.AdditionalService,
                    source =>
                        source.MapFrom(res => res.AdditionalServiceModel));

            CreateMap<AdditionalServiceRemoveResult, AdditionalServiceRemoveResponse>();

            CreateMap<HallServiceGetAllResult, HallGetAllResponse>()
                .ForMember(
                    dest => dest.Halls,
                    source =>
                        source.MapFrom(res => res.HallModels));

            CreateMap<HallServiceResult, HallResponse>()
                .ForMember(
                    dest => dest.Hall,
                    source =>
                        source.MapFrom(res => res.HallModel));

            CreateMap<HallServiceRemoveResult, HallRemoveResponse>();

            CreateMap<FileServiceResult, FileResponse>();

            CreateMap<SessionAdditionalServiceRequest, SessionAdditionalServiceModel>()
                .ForMember(
                    dest => dest.AdditionalService,
                    source =>
                        source.MapFrom(res => new AdditionalService()
                        {
                            Name = res.Name
                        }));

            CreateMap<SessionSeatTypeRequest, SessionSeatTypeModel>();

            CreateMap<SessionRequest, SessionRequestModel>()
                .ForMember(
                    dest => dest.SessionAdditionalServices,
                    source =>
                        source.MapFrom(res => res.SessionAdditionalServices))
                .ForMember(
                    dest => dest.SessionSeatTypes,
                    source =>
                        source.MapFrom(res => res.SessionSeatTypes));

            CreateMap<SessionSeatTypeModel, SessionSeatType>();

            CreateMap<SessionSeatModel, SessionSeat>()
                .ForMember(
                    dest => dest.TicketState,
                    source =>
                        source.MapFrom(res => res.TicketState))
                .ForMember(
                    dest => dest.Seat,
                    source =>
                        source.MapFrom(res => res.Seat))
                .ForMember(
                    dest => dest.SessionSeatType,
                    source =>
                        source.MapFrom(res => res.SessionSeatType));

            CreateMap<SessionAdditionalServiceModel, SessionAdditionalService>()
                .ForMember(
                    dest => dest.AdditionalService,
                    source =>
                        source.MapFrom(res => res.AdditionalService));

            CreateMap<SessionModel, Session>()
                .ForMember(
                    dest => dest.Movie,
                    source =>
                        source.MapFrom(res => res.Movie))
                .ForMember(
                    dest => dest.Hall,
                    source =>
                        source.MapFrom(res => res.Hall))
                .ForMember(
                    dest => dest.SessionAdditionalServices,
                    source =>
                        source.MapFrom(res => res.SessionAdditionalServices))
                .ForMember(
                    dest => dest.SessionSeats,
                    source =>
                        source.MapFrom(res => res.SessionSeats))
                .ForMember(
                    dest => dest.SessionSeatType,
                    source =>
                        source.MapFrom(res => res.SessionSeatTypes));

            CreateMap<SessionSeatType, SessionSeatTypeModel>();

            CreateMap<SessionSeat, SessionSeatModel>()
                .ForMember(
                    dest => dest.TicketState,
                    source =>
                        source.MapFrom(res => res.TicketState))
                .ForMember(
                    dest => dest.Seat,
                    source =>
                        source.MapFrom(res => res.Seat))
                .ForMember(
                    dest => dest.SessionSeatType,
                    source =>
                        source.MapFrom(res => res.SessionSeatType));

            CreateMap<SessionAdditionalService, SessionAdditionalServiceModel>()
                .ForMember(
                    dest => dest.AdditionalService,
                    source =>
                        source.MapFrom(res => res.AdditionalService));

            CreateMap<Session, SessionModel>()
                .ForMember(
                    dest => dest.Movie,
                    source =>
                        source.MapFrom(res => res.Movie))
                .ForMember(
                    dest => dest.Hall,
                    source =>
                        source.MapFrom(res => res.Hall))
                .ForMember(
                    dest => dest.SessionAdditionalServices,
                    source =>
                        source.MapFrom(res => res.SessionAdditionalServices))
                .ForMember(
                    dest => dest.SessionSeats,
                    source =>
                        source.MapFrom(res => res.SessionSeats))
                .ForMember(
                    dest => dest.SessionSeatTypes,
                    source =>
                        source.MapFrom(res => res.SessionSeatType));

            CreateMap<SessionAdditionalServiceModel, SessionAdditionalServiceViewModel>()
                .ForMember(
                    dest => dest.AdditionalService,
                    source =>
                        source.MapFrom(res => res.AdditionalService));

            CreateMap<SessionSeatTypeModel, SessionSeatTypeViewModel>();

            CreateMap<SessionSeatModel, SessionSeatViewModel>()
                .ForMember(
                    dest => dest.Seat,
                    source =>
                        source.MapFrom(res => res.Seat))
                .ForMember(
                    dest => dest.SessionSeatType,
                    source =>
                        source.MapFrom(res => res.SessionSeatType));

            CreateMap<SessionModel, SessionViewModel>()
                .ForMember(
                    dest => dest.Movie,
                    source =>
                        source.MapFrom(res => res.Movie))
                .ForMember(
                    dest => dest.Hall,
                    source =>
                        source.MapFrom(res => res.Hall))
                .ForMember(
                    dest => dest.SessionAdditionalServices,
                    source =>
                        source.MapFrom(res => res.SessionAdditionalServices))
                .ForMember(
                    dest => dest.SessionSeats,
                    source =>
                        source.MapFrom(res => res.SessionSeats));

            CreateMap<SessionServiceGetAllResult, SessionGetAllResponse>()
                .ForMember(
                    dest => dest.Sessions,
                    source =>
                        source.MapFrom(res => res.Sessions));

            CreateMap<SessionServiceResult, SessionResponse>()
                .ForMember(
                    dest => dest.Session,
                    source =>
                        source.MapFrom(res => res.Session));

            CreateMap<SessionServiceRemoveResult, SessionRemoveResponse>();

            CreateMap<SearchSuggestionResult, SearchSuggestionResponse>();
            CreateMap<MovieFilterParametersRequest, MovieFilterParametersModel>();

            CreateMap<SessionsForMovieModel, SessionsForMovieViewModel>()
                .ForMember(
                    dest => dest.Cinema,
                    source =>
                        source.MapFrom(res => res.Cinema))
                .ForMember(
                    dest => dest.Sessions,
                    source =>
                        source.MapFrom(res => res.Sessions));

            CreateMap<GetSessionsResult, GetSessionsResponse>()
                .ForMember(
                    dest => dest.Sessions,
                    source =>
                        source.MapFrom(res => res.Sessions))
                .ForMember(
                    dest => dest.Movie,
                    source =>
                        source.MapFrom(res => res.Movie));

            CreateMap<BookedOrder, BookedOrderModel>()
                .ForMember(
                    dest => dest.Session,
                    source =>
                        source.MapFrom(res => res.ReservedSessionSeats.FirstOrDefault().Session))
                .ForMember(
                    dest => dest.ReservedSessionSeats,
                    source =>
                        source.MapFrom(res => res.ReservedSessionSeats))
                .ForMember(
                    dest => dest.SelectedSessionAdditionalServices,
                    source =>
                        source.MapFrom(res => res.SelectedSessionAdditionalServices));

            CreateMap<UserProfile, UserProfileModel>();

            CreateMap<UserProfileModel, UserProfile>();

            CreateMap<UserProfileUpdateRequest, UserProfileModel>();

            CreateMap<UserProfileModel, UserProfileViewModel>()
                .ForMember(
                    dest => dest.Tickets,
                    source =>
                        source.MapFrom(res => res.TicketsModel));

            CreateMap<UserProfileResult, UserProfileResponse>()
                .ForMember(
                    dest => dest.UserProfile,
                    source =>
                        source.MapFrom(res => res.UserProfile));

            CreateMap<BookTicketsRequest, BookingModel>();

            CreateMap<BookedOrderModel, BookedOrderViewModel>()
                .ForMember(
                    dest => dest.ReservedSessionSeats,
                    source =>
                        source.MapFrom(res => res.ReservedSessionSeats))
                .ForMember(
                    dest => dest.SelectedSessionAdditionalServices,
                    source =>
                        source.MapFrom(res => res.SelectedSessionAdditionalServices));

            CreateMap<BookingServiceResult, BookTicketsResponse>()
                .ForMember(
                    dest => dest.BookedOrder,
                    source =>
                        source.MapFrom(res => res.BookedOrder));
        }
    }
}