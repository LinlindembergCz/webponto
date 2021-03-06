using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pessoal.Domain.Aggregates.ColaboradorAggregate;

namespace Pessoal.Infra.Data.Configuration
{
    public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaboradores", "dbo").HasKey(t => t.Id);
            builder.HasQueryFilter(p => p.Ativo);//So consulta os colaboradores Ativos

            builder.Property(t => t.Id).
                IsRequired(true).
                HasDefaultValueSql("NEWID()");// OU poderia inicializar com Id = Guid.NewGuid();

            builder.Property(t => t.Nome).
                HasMaxLength(50).
                IsRequired(true);

            builder.Property(t => t.Matricula).
                HasMaxLength(8).
                IsRequired(true);

            builder.Property(t => t.Matricula).
                            HasMaxLength(8).
                            IsRequired(true);

            builder.HasIndex(p => new { p.Matricula })
                .HasDatabaseName("idx_Colaboradores_Matricula")
                .IsUnique();

            builder.Property(t => t.Ativo).
                    HasDefaultValueSql(Boolean.TrueString);

        }
    }
}
