using ControleDeGastos.Model;
using ControleDeGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
    }
}
