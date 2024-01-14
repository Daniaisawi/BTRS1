using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class BusTrip
    {
        [Key]
        public int TripID { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string BusNumber { get; set; }

       
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Bus> Buses { get; set; }

        [ForeignKey("AdminID")]
        public Administrator Admin { get; set; }

    }
}
