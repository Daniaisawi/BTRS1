using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Bus
    {
        [Key]
        public int BusID { get; set; }
        [Required]
        public string CaptainName { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [ForeignKey("BusTripId")]
      
       
        public BusTrip Trip { get; set; }

        [ForeignKey("AdminID")]
        public Administrator Admin { get; set; }
    }
}
