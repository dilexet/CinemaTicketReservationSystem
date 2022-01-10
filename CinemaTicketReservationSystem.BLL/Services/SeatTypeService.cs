using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Enums;
using CinemaTicketReservationSystem.BLL.Extensions;
using CinemaTicketReservationSystem.BLL.Models.Results.SeatType;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class SeatTypeService : ISeatTypeService
    {
        public SeatTypeServiceGetAllResult GetSeatTypes()
        {
            List<string> seatTypesList = Enum.GetValues(typeof(SeatTypes)).Cast<SeatTypes>().Select(seatType => seatType.GetDisplayName()).ToList();

            return new SeatTypeServiceGetAllResult()
            {
                Success = true,
                SeatTypesList = seatTypesList
            };
        }
    }
}