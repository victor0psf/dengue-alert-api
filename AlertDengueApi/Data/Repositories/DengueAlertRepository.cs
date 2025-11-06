using AlertDengueApi.Data;
using AlertDengueApi.Interfaces;
using AlertDengueApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlertDengueApi.Repositories
{
    public class DengueAlertRepository : IDengueAlertRepository
    {
        private readonly AppDbContext _context;

        public DengueAlertRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(List<DengueAlert> alert)
        {
            await _context.DengueAlerts.AddRangeAsync(alert);
            await _context.SaveChangesAsync();
        }

        public async Task<DengueAlert?> GetByWeekAsync(int week)
        {
            return await _context.DengueAlerts
                .FirstOrDefaultAsync(a => a.EpidemiologicalWeek == week);
        }

        public async Task<IEnumerable<DengueAlert>> GetAllAsync()
        {
            return await _context.DengueAlerts.ToListAsync();
        }
    }
}