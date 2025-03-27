using ControleDeGastos.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<TransacaoModel> Transacoes { get; set; }
        public DbSet<TransferenciaModel> Transferencias { get; set; }
    }
}
