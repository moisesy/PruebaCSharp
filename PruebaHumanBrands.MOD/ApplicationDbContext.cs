using Microsoft.EntityFrameworkCore;
using PruebaHumanBrands.MOD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHumanBrands.MOD
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
