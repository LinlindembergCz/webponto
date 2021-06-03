﻿using Microsoft.EntityFrameworkCore;
using WebPonto.Domain.Aggregates.PersonAggregate;
using System.Reflection;

namespace WebPonto.Infra.Data.Context
{
    public class ExampleContext : DbContext
    {
        public static bool firstRun = true;

        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ExampleContext)));
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<PersonPhone> PersonPhone { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberType { get; set; }
    }
}