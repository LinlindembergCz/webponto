using WebPonto.Domain.Aggregates.PersonAggregate;
using WebPonto.Domain.Aggregates.PersonAggregate.Interfaces;
using WebPonto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPonto.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Person>> FindAllAsync() =>
           await _context.Person.AsNoTracking().ToListAsync();

        //await Task.Run(() => _context.Person);

        public Person FindById(int id)
        {
            return _context.Person.First(p => p.BusinessEntityID == id);                
        }

        public void Create(Person entity)
        {
            _context.Person.Add(entity);
            _context.SaveChanges();
        }

        public void Modify(Person entity)
        {
            _context.Person.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Person entity = _context.Person.First(p => p.BusinessEntityID == id);
            _context.Person.Remove(entity);
            _context.SaveChanges();
        }

    }
}
