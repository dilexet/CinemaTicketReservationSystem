using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Enums;
using CinemaTicketReservationSystem.BLL.Extensions;
using CinemaTicketReservationSystem.BLL.Results.SeatType;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class SeatTypeService : ISeatTypeService
    {
        public SeatTypeServiceGetAllResult GetSeatTypes()
        {
            List<string> seatTypesList = new List<string>();
            foreach (var seatType in Enum.GetValues(typeof(SeatTypes)).Cast<SeatTypes>())
            {
                seatTypesList.Add(seatType.GetDisplayName());
            }

            return new SeatTypeServiceGetAllResult()
            {
                Success = true,
                SeatTypesList = seatTypesList
            };
        }
    }
}