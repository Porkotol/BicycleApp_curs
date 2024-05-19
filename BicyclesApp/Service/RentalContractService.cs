using BicyclesApp.Service.IService;
using Common;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BicyclesApp.Service
{
    public class RentalContractService : IRentalContractService
    {
        private readonly ApplicationDbContext _dbContext;

        public RentalContractService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateContractsAsync()
        {
            var currentContracts = await _dbContext.RentalContracts
                .Where(c => c.RentalStatus == SD.RentalStatus_Active)
                .Include(c => c.RentalOffer.Bicycle)
                .ToListAsync();

            foreach (var currentContract in currentContracts)
            {
                if(DateTime.Now > currentContract.RentedToTime)
                {
                    currentContract.RentalStatus = SD.RentalStatus_Expired;
                    currentContract.RentalOffer.Bicycle.IsBooked = false;
                }
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
