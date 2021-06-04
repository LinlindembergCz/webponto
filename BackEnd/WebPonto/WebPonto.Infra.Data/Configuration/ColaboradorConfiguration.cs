using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebPonto.Domain.Aggregates.ColaboradorAggregate;

namespace WebPonto.Infra.Data.Configuration
{
    public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
          //  builder.Ignore(b => b.DomainEvents);

            builder.ToTable("Colaborador", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).
                HasColumnName("Id").
                IsRequired(true).
                HasDefaultValueSql("NEWID()");

            builder.Property(t => t.Nome).HasColumnName("Nome").IsRequired(true);
            
        }
    }
}
