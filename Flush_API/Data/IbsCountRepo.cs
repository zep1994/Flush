using Flush_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flush_API.Data
{
    public class IbsCountRepo : IIbsCountRepo
    {
        private readonly AppDbContext _context;

        public IbsCountRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateIbsCount(IbsCount ibsCount)
        {
            if (ibsCount == null)
            {
                throw new ArgumentNullException(nameof(ibsCount));
            }

            await _context.AddAsync(ibsCount);
        }

        public void DeleteIbsCount(IbsCount ibsCount)
        {
            if (ibsCount == null)
            {
                throw new ArgumentNullException(nameof(ibsCount));
            }

            _context.IbsCount.Remove(ibsCount);
        }

        public async Task<IEnumerable<IbsCount>> GetAllIbsCounts()
        {
            return await _context.IbsCount.Where(b => b.Count >= 1).ToListAsync();
        }

        public async Task<IbsCount> GetIbsCountById(int id)
        {
            return await _context.IbsCount.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
