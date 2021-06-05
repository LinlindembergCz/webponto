using Microsoft.EntityFrameworkCore;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using System.Reflection;

namespace PontoEletronico.Infra.Data.Context
{
    public class PontoContext : DbContext
    {
        //public static bool firstRun = true;

        public PontoContext(DbContextOptions<PontoContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            ///Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetAssembly(typeof(PontoContext)));
        }

        public DbSet<Ponto> Ponto { get; set; }
    }
}