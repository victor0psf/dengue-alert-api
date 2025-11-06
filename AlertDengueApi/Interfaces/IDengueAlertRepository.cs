using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertDengueApi.Models;

namespace AlertDengueApi.Interfaces
{
    public interface IDengueAlertRepository
    {
        Task SaveAsync(List<DengueAlert> alert);
        Task<DengueAlert?> GetByWeekAsync(int week);
        Task<IEnumerable<DengueAlert>> GetAllAsync();
    }
}