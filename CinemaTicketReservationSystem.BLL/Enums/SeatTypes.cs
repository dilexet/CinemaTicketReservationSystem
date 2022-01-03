using System.ComponentModel.DataAnnotations;

namespace CinemaTicketReservationSystem.BLL.Enums
{
    public enum SeatTypes
    {
        [Display(Name = "VIP")]
        Vip,

        [Display(Name = "Rest Sofa")]
        RestSofa,

        [Display(Name = "Premiere Sofa")]
        PremiereSofa,

        [Display(Name = "Love Seat")]
        LoveSeat,

        [Display(Name = "Private Suite")]
        PrivateSuite,

        [Display(Name = "Regular")]
        Regular,

        [Display(Name = "Bag Chair")]
        BagChair
    }
}