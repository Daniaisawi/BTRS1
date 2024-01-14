using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }


        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }

        [ForeignKey("BusTripId")]
        public BusTrip Trip { get; set; }
    }
}
