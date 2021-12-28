using System.Linq;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;

namespace CinemaTicketReservationSystem.DAL.Initializers
{
    public class SeatTypesInitialize
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.SeatTypes.Any())
            {
                context.SeatTypes.AddRange(
                    new SeatType()
                    {
                        Name = "Love Seat"
                    },
                    new SeatType()
                    {
                        Name = "Rest Sofa"
                    },
                    new SeatType()
                    {
                        Name = "Premiere Sofa"
                    },
                    new SeatType()
                    {
                        Name = "Private Suite"
                    },
                    new SeatType()
                    {
                        Name = "Bag Chair"
                    },
                    new SeatType()
                    {
                        Name = "VIP"
                    },
                    new SeatType()
                    {
                        Name = "Regular"
                    });

                context.SaveChanges();
            }
        }
    }
}