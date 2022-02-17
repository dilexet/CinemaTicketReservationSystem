using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Role
{
    public class RoleServiceGetRolesResult : Result
    {
        public IEnumerable<RoleModel> RoleModels { get; set; }
    }
}