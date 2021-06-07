using Pessoal.Domain.Aggregates.ColaboradorAggregate;
using Pessoal.Domain.Aggregates.ColaboradorAggregate.Interfaces;
using Pessoal.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoal.Infra.Data.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly PessoalContext _context;

        public ColaboradorRepository(PessoalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Colaborador>> FindAllAsync() =>
           await _context.Colaborador.AsNoTracking().ToListAsync();

        public Colaborador FindById(Guid id)=> _context.Colaborador.First(p => p.Id == id);                
         public async Task<Colaborador> FindByMatricula(string matricula) =>      
             await _context.Colaborador.FirstAsync(p => p.Matricula == matricula);      

        public void Create(Colaborador entity)
        {
            _context.Colaborador.Add(entity);
            _context.SaveChanges();

            //Como tem poucas entidades, nao vejo necessidade de efetuar o Clear, 
            //sendo assim, deixo aqui de prontidão.

            // _context.ChangeTracker.Clear();
        }

        public void Modify(Colaborador entity)
        {
            _context.Colaborador.Update(entity);
            _context.SaveChanges();
           // _context.ChangeTracker.Clear();
        }
        public void Delete(Guid id)
        {
            Colaborador entity = _context.Colaborador.First(p => p.Id == id);
            _context.Colaborador.Remove(entity);
            _context.SaveChanges();
            // _context.ChangeTracker.Clear();
        }

        public void Ativar(Guid id)
        {
            //1º
            //cmd.CommandText = "update Colaboradores set...";
            //cmd.ExecuteNonQuery();

            //2º
            //db.Database.ExecuteSqlRaw("update Colaboradores set"...;

            //3º
            _context.Database.ExecuteSqlInterpolated($"update Colaboradores set Ativo=1 where id={id}");
        }

        public void Inativar(Guid id)
        {
            _context.Database.ExecuteSqlInterpolated($"update Colaboradores set Ativo=0 where id={id}");
        }

    }
}
