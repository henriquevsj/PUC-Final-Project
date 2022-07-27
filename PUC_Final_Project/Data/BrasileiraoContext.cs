using Microsoft.EntityFrameworkCore;
using PUC_Final_Project.Models;

namespace PUC_Final_Project.Data
{
    public class BrasileiraoContext : DbContext
    {
        public BrasileiraoContext(DbContextOptions<BrasileiraoContext> options)
            : base(options)
        {
        }

        public DbSet<Time> Time { get; set; }
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Transferencia> Transferencia { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<Torneio> Torneio { get; set; }
        public DbSet<Evento> Evento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Password=dcrrwmp3;Persist Security Info=True;User ID=sa;Initial Catalog=Brasileirao;Data Source=HUNB1044\SQLSERVER");
        }

    }
}
