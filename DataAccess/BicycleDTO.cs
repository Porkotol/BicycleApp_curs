using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BicycleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public IEnumerable<RentalOfferDTO> BicycleRentalOffers{ get; set; }
    }
}
