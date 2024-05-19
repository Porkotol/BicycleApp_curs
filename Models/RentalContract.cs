using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("RentalContracts")]
    public class RentalContract
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Renter))]
        [Required]
        public int Renter_Id { get; set; }
        public AppUser Renter { get; set; }

        [ForeignKey(nameof(RentalOffer))]
        [Required]
        public int RenalOffer_Id { get; set; }
        public RentalOffer RentalOffer { get; set; }
        [Required]
        public DateTime RentedFromTime { get; set; }
        [Required]
        public DateTime RentedToTime { get; set; }
        [Required]
        public string RentalStatus { get; set; }
    }
}
