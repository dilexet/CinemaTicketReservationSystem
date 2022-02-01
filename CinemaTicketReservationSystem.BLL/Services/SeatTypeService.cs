using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Enums;
using CinemaTicketReservationSystem.BLL.Extensions;
using CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels;
using CinemaTicketReservationSystem.BLL.Models.Results.SeatType;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class SeatTypeService : ISeatTypeService
    {
        public SeatTypeServiceGetAllResult GetSeatTypes()
        {
            List<SeatTypeModel> seatTypesList = new List<SeatTypeModel>();

            foreach (var seatTypeName in Enum.GetValues(typeof(SeatTypes)).Cast<SeatTypes>()
                         .Select(seatType => seatType.GetDisplayName()).ToList())
            {
                seatTypesList.Add(new SeatTypeModel()
                {
                    Name = seatTypeName
                });
            }

            return new SeatTypeServiceGetAllResult()
            {
                Success = true,
                SeatTypesList = seatTypesList
            };
        }
    }
}