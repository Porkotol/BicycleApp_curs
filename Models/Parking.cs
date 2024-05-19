using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Parkings")]
    [Index(nameof(StreetAdress), nameof(City_Id), IsUnique = true)]
    public class Parking
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string StreetAdress { get; set; }
        [Required, Range(0, int.MaxValue)]
        [DefaultValue(10)]
        public int MaxBicyclesAmount { get; set; }
        [Required, Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int CurrentBicyclesAmount { get; set; }

        [ForeignKey(nameof(City))]
        [Required, Range(1, int.MaxValue)]
        public int City_Id { get; set; }
        public City City { get; set; }

        [ForeignKey(nameof(Owner))]
        [Required, Range(1,int.MaxValue)]
        public int Owner_Id { get; set; }
        public AppUser Owner { get; set; }
    }
}
