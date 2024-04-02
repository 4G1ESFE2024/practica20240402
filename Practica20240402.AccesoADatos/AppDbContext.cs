using Microsoft.EntityFrameworkCore;
using Practica20240402.EntidadesDeNegocio;

namespace Practica20240402.AccesoADatos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
