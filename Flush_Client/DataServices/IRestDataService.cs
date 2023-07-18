using Flush_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flush_Client.DataServices
{
    public interface IRestDataService
    {
        Task<List<IbsCount>> GetIbsCountAsync();
        Task AddIbsCountAsync(IbsCount ibsCount);
        Task UpdateIbsCountAsync(IbsCount ibsCount);
        Task DeleteIbsCountAsync(int id);

    }
}
