using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CamaraDBContext : DbContext
    {
        public CamaraDBContext(DbContextOptions<CamaraDBContext> options):base(options)
        {
            
        }

        public DbSet<DCamara> DCamaras { get; set; }
    }
}
