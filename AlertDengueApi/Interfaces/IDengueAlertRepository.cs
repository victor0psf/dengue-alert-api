using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertDengueApi.Models;

namespace AlertDengueApi.Interfaces
{
    public interface IDengueAlertRepository
    {
        Task SaveAsync(DengueAlert alert);
        Task<DengueAlert?> GetByWeekAsync(int week, int year);
        Task<IEnumerable<DengueAlert>> GetAllAsync();
    }
}