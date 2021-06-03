using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebPonto.Domain.Aggregates.PersonAggregate;

namespace WebPonto.Infra.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
          //  builder.Ignore(b => b.DomainEvents);

            builder.ToTable("Person", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).
                HasColumnName("Id").
                IsRequired(true).
                HasDefaultValueSql("NEWID()");

            builder.Property(t => t.Nome).HasColumnName("Nome").IsRequired(true);
            
            //builder.HasData(new Person { Id = new System.Guid(), Nome = "User One" });
        }
    }
}
