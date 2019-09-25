using Microsoft.EntityFrameworkCore;
using PruebaCore.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCore.Data
{
    public class CatalogosDbContext : DbContext
    {
        public CatalogosDbContext(DbContextOptions<CatalogosDbContext> options) : base(options) { }
        public DbSet<CategoriaEntity> Categoria { get; set; }
        public DbSet<SubCategoriaEntity> SubCategoria { get; set; }
    }
}
