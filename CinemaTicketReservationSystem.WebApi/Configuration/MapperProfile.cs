using AutoMapper;
using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Results;
using CinemaTicketReservationSystem.DAL.Entity;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using CinemaTicketReservationSystem.WebApi.Models.Response;
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
        }
    }
}