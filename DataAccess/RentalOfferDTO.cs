using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RentalOfferDTO
    {
        public int Id { get; set; }
        public int Bicycle_Id { get; set; }
        public int RentalTimeInMinutes { get; set; }
        public double Price { get; set; }
        public bool IsEditing { get; set; }
    }
}
