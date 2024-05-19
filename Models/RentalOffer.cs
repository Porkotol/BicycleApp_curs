using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models
{
    [Table("RentalOffers")]
    [Index(nameof(RentalTimeInMinutes), nameof(Price), nameof(Bicycle_Id), IsUnique = true)]
    public class RentalOffer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Bicycle))]
        [Required]
        public int Bicycle_Id { get; set; }
        public Bicycle Bicycle { get; set; }
        [Required]
        public int RentalTimeInMinutes { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
