using System;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Results.Authorize;
using CinemaTicketReservationSystem.BLL.Results.Movie;
using CinemaTicketReservationSystem.BLL.Results.UserManagement;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using CinemaTicketReservationSystem.WebApi.Models.Response.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Response.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Response.UserManagement;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels;

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
        }
    }
}