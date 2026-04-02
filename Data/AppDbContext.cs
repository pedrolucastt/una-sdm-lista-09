using Microsoft.EntityFrameworkCore;
using una_sdm_lista_09.Models;

namespace una_sdm_lista_09.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Candidato> Candidatos { get; set; }
    }
}