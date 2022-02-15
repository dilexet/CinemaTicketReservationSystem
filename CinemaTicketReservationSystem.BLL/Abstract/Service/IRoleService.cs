using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Results.Role;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IRoleService
    {
        Task<RoleServiceGetRolesResult> GetRoles();
    }
}