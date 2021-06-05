using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Infra.Data.Conversores;
using System;

namespace PontoEletronico.Infra.Data.Configuration
{
    public class PontoConfiguration : IEntityTypeConfiguration<Ponto>
    {
        public void Configure(EntityTypeBuilder<Ponto> builder)
        {
          //  builder.Ignore(b => b.DomainEvents);

            builder.ToTable("Apontamentos", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).
                    HasColumnName("Id").
                    IsRequired(true).
                    HasDefaultValueSql("NEWID()");

            builder.Property(t => t.ColaboradorId).
            HasColumnName("ColaboradorId").
            IsRequired(true);

            builder.Property(t => t.Nome).
                    HasColumnName("Nome").
                    IsRequired(true);

            builder.Property(p => p.Indicador).
                    HasConversion(new ConversorIndicadorEntradaSaida()); //Ler e escever Entrada <=> E e Saida <=> S

            builder.Property(p => p.DataHora).
                    HasDefaultValueSql("GETDATE()");




        }
    }
}
