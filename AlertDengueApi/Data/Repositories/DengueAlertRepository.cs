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

        public async Task SaveAsync(DengueAlert alert)
        {
            await _context.DengueAlerts.AddAsync(alert);
            await _context.SaveChangesAsync();
        }

        public async Task<DengueAlert?> GetByWeekAsync(int week, int year)
        {
            return await _context.DengueAlerts
                .FirstOrDefaultAsync(a => a.EpidemiologicalWeek == week && a.EpidemiologicalYear == year);
        }

        public async Task<IEnumerable<DengueAlert>> GetAllAsync()
        {
            return await _context.DengueAlerts.ToListAsync();
        }
    }
}