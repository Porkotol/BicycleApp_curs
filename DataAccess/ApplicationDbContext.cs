using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<BicycleType> BicycleTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<RentalContract> RentalContracts { get; set; }
        public DbSet<RentalOffer> RentalOffers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
