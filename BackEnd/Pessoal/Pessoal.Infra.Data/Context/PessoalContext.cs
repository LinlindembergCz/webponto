using Microsoft.EntityFrameworkCore;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using System.Reflection;

namespace Pessoal.Infra.Data.Context
{
    public class PessoalContext : DbContext
    {
        //public static bool firstRun = true;

        public PessoalContext(DbContextOptions<PessoalContext> options) : base(options)
        {
            //Database.EnsureDeleted();
           Database.EnsureCreated();
           //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetAssembly(typeof(PessoalContext)));
        }

        public DbSet<Colaborador> Colaborador { get; set; }
    }
}