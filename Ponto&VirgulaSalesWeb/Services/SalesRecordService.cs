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
            var result = from obj in _context.SalesRecords select obj;
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
        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            //Dessa forma estava dando erro uma exceção 
            
            //return await result
            //    .Include(x => x.Seller)
            //    .Include(x => x.Seller.Department)
            //    .OrderByDescending(x => x.Date)
            //    .GroupBy(x => x.Seller.Department)
            //    .ToListAsync();

             var list = await result
            .Include(x => x.Seller)
            .ThenInclude(s => s.Department)
            .OrderByDescending(x => x.Date)
            .ToListAsync(); // executa a query no banco

            return list
                .GroupBy(x => x.Seller.Department) // faz o agrupamento na memória
                .ToList();
        }
    }
}
