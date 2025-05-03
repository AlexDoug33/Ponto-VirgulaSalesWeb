using Ponto_VirgulaSalesWeb.Data;
using Ponto_VirgulaSalesWeb.Models;

namespace Ponto_VirgulaSalesWeb.Services
{
    public class DepartmentService
    {
        private readonly Ponto_VirgulaSalesWebContext _context;

        public DepartmentService(Ponto_VirgulaSalesWebContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }







    }
}
 