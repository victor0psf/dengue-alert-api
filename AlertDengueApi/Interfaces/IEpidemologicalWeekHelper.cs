using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertDengueApi.Interfaces
{
    public interface IEpidemologicalWeekHelper
    {
        (int ewStart, int ewEnd, int eyStart, int eyEnd) GetLastSixMonths();
    }
}