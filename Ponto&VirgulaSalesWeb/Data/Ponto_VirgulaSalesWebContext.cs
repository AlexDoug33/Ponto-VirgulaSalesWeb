using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ponto_VirgulaSalesWeb.Models;

namespace Ponto_VirgulaSalesWeb.Data
{
    public class Ponto_VirgulaSalesWebContext : DbContext
    {
        public Ponto_VirgulaSalesWebContext (DbContextOptions<Ponto_VirgulaSalesWebContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Department { get; set; } 
        public DbSet<Seller> Seller { get; set; }   
        public DbSet<SalesRecord> SalesRecords { get; set; }    
    }
}
