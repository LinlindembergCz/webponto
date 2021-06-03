using WebPonto.Domain.Aggregates.PersonAggregate;
using WebPonto.Domain.Aggregates.PersonAggregate.Interfaces;
using WebPonto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPonto.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);
    }
}
