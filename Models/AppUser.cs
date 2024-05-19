using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        [Required, Range(0, 100_000)]
        public double Balance { get; set; }
    }
}
