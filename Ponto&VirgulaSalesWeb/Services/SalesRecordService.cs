using Microsoft.EntityFrameworkCore;
using Ponto_VirgulaSalesWeb.Data;
using Ponto_VirgulaSalesWeb.Models;

namespace Ponto_VirgulaSalesWeb.Services
{
    public class SalesRecordService
    {
        private readonly Ponto_VirgulaSalesWebContext _context;
        public SalesRecordService(Ponto_VirgulaSalesWebContext context)
        {
            _context = context;
        }       
        
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in  _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }   
    }
}
