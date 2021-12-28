using System;
using System.Linq;
using System.Linq.Expressions;
using CinemaTicketReservationSystem.DAL.Abstract.Cinema;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Cinema
{
    public class SeatTypeRepository : BaseRepository<SeatType>, ISeatTypeRepository
    {
        private readonly ILogger<SeatTypeRepository> _log;

        public SeatTypeRepository(ApplicationDbContext context, ILogger<SeatTypeRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override IQueryable<SeatType> GetBy(
            Expression<Func<SeatType, bool>> predicate = null)
        {
            IQueryable<SeatType> seatTypes = null;
            try
            {
                seatTypes = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return seatTypes;
        }
    }
}