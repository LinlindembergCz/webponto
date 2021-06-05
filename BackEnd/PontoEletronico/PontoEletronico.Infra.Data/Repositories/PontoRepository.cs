using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using PontoEletronico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PontoEletronico.Infra.Data.Repositories
{
    public class PontoRepository : IPontoRepository
    {
        private readonly PontoContext _context;

        public PontoRepository(PontoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Ponto>> FindAllAsync() =>
           await _context.Ponto.AsNoTracking().ToListAsync();
         

        public void CreateEntrada(Ponto entity)
        {
            entity.Indicador = IndicadorEntradaSaida.ENTRADA;

            _context.Ponto.Add(entity);

            _context.SaveChanges();
        }

        public void CreateSaida(Ponto entity)
        {
            entity.Indicador =  IndicadorEntradaSaida.SAIDA;

            _context.Ponto.Add(entity);

            _context.SaveChanges();
        }
    }
}
