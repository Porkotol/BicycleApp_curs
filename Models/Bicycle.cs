using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Bicycles")]
    public class Bicycle
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Range(0, 100)]
        public double? Weight { get; set; }
        [Required, Range(10, 500)]
        public double MaxAllowedWeight { get; set; }
        [Required, Range(0, 250)]
        public double MaxSpeed { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsBooked { get; set; }
        [Required]
        [DefaultValue(0)]
        public int BookingNumber { get; set; }

        [ForeignKey(nameof(BicycleType))]
        [Required]
        public int Type_Id { get; set; }
        public BicycleType BicycleType { get; set; }

        [ForeignKey(nameof(Parking))]
        [Required]
        public int Parking_Id { get; set; }
        public Parking Parking { get; set; }

        public virtual IEnumerable<RentalOffer> BicycleRentalOffers { get; set; } = new List<RentalOffer>();

        [Required]
        public string ImageUrl { get; set; }
    }
}
