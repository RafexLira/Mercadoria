using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Context
{
    public class MercadoriaContext: DbContext
    {

        private IConfiguration _configuration;
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Saida> Saidas { get; set; }
        public DbSet<Mercadoria> Mercadorias { get; set; }

        public MercadoriaContext(DbContextOptions<MercadoriaContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbConnection"));
        }
    }
}
