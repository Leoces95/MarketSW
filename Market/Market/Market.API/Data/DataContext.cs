
using Microsoft.EntityFrameworkCore;

using Market.Share.Entities;

namespace Market.API.Data
{
    public class DataContext: DbContext
    {
        // Utilizar las propiedades de DbContext
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }
        // se hace un DbSet por cada entidad/tabla creada
        public DbSet <Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
