using BicyclesApp.Service.IService;
using Common;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BicyclesApp.Service
{

    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public async Task Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
                if (!(await _roleManager.RoleExistsAsync(SD.Role_Admin)))
                {
                    await _roleManager.CreateAsync(new AppRole(SD.Role_Admin));
                }
                if (!(await _roleManager.RoleExistsAsync(SD.Role_Manager)))
                {
                    await _roleManager.CreateAsync(new AppRole(SD.Role_Manager));
                }
                if (!(await _roleManager.RoleExistsAsync(SD.Role_Customer)))
                {
                    await _roleManager.CreateAsync(new AppRole(SD.Role_Customer));
                }
                if(await _userManager.FindByEmailAsync("Admin@gmail.com") == null)
                {
                    AppUser user = new AppUser()
                    {
                        Name = "Admin Porkotol",
                        UserName = "Admin@gmail.com",
                        Email = "Admin@gmail.com",
                        EmailConfirmed = true
                    };
                    await _userManager.CreateAsync(user, "123456"); 
                    if(!await _userManager.IsInRoleAsync(user, SD.Role_Admin))
                    {
                        await _userManager.AddToRoleAsync(user, SD.Role_Admin);
                    }
                }
                if (await _userManager.FindByEmailAsync("Manager@gmail.com") == null)
                {
                    AppUser user = new AppUser()
                    {
                        Name = "Manager Porkotol",
                        UserName = "Manager@gmail.com",
                        Email = "Manager@gmail.com",
                        EmailConfirmed = true
                    };
                    await _userManager.CreateAsync(user, "123456");
                    if (!await _userManager.IsInRoleAsync(user, SD.Role_Manager))
                    {
                        await _userManager.AddToRoleAsync(user, SD.Role_Manager);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
