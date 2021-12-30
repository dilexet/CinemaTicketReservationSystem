using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.AdditionalService
{
    public class AdditionalServiceGetAllResult : Result
    {
        public IEnumerable<AdditionalServiceModel> AdditionalServices { get; set; }
    }
}