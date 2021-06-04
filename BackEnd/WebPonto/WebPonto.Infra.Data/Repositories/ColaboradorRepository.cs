using WebPonto.Domain.Aggregates.ColaboradorAggregate;
using WebPonto.Domain.Aggregates.ColaboradorAggregate.Interfaces;
using WebPonto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPonto.Infra.Data.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly ExampleContext _context;

        public ColaboradorRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Colaborador>> FindAllAsync() =>
           await _context.Colaborador.AsNoTracking().ToListAsync();

        public Colaborador FindById(Guid id)
        {
            return _context.Colaborador.First(p => p.Id == id);                
        }

        public void Create(Colaborador entity)
        {
            _context.Colaborador.Add(entity);
            _context.SaveChanges();
        }

        public void Modify(Colaborador entity)
        {
            _context.Colaborador.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            Colaborador entity = _context.Colaborador.First(p => p.Id == id);
            _context.Colaborador.Remove(entity);
            _context.SaveChanges();
        }

    }
}
