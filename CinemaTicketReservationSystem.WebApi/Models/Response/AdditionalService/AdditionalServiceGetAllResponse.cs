using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.AdditionalService
{
    public class AdditionalServiceGetAllResponse : Response
    {
        public IEnumerable<AdditionalServiceViewModel> AdditionalServices { get; set; }
    }
}