using WebPonto.Domain.Aggregates.PersonAggregate;
using WebPonto.Domain.Aggregates.PersonAggregate.Interfaces;
using WebPonto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPonto.Infra.Data.Repositories
{
    public class PhoneNumberTypeRepository : IPhoneNumberTypeRepository
    {
        private readonly ExampleContext _context;

        public PhoneNumberTypeRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PhoneNumberType>> FindAllAsync() => await Task.Run(() => _context.PhoneNumberType);
    }
}
