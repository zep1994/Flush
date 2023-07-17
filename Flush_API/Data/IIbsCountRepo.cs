using Flush_API.Models;

namespace Flush_API.Data
{
    public interface IIbsCountRepo
    {
        Task SaveChanges();
        Task<IbsCount> GetIbsCountById(int id);
        Task<IEnumerable<IbsCount>> GetAllIbsCounts();
        Task CreateIbsCount(IbsCount ibsCount);
        void DeleteIbsCount(IbsCount ibsCount);
    }
}
