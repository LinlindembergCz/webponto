using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using PontoEletronico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PontoEletronico.Domain.Enums;

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


        private void Create(Ponto entity)
        {
            _context.Ponto.Add(entity);
            _context.SaveChanges();
        }

        public void CreateEntrada(Ponto entity)
        {
            if (this.VerifyEntrada(entity.ColaboradorId))
            {
                entity.Indicador = IndicadorEntradaSaida.ENTRADA;
                Create(entity);
            }
            else throw new InvalidOperationException("Colaborador já registrou a Entrada do ponto!");
        }

        public void CreateSaida(Ponto entity)
        {
            if (this.VerifySaida(entity.ColaboradorId))
            {
                entity.Indicador = IndicadorEntradaSaida.SAIDA;
                Create(entity);
            }
            else throw new InvalidOperationException("Colaborador não efetuou a Entrada ou já registrou a Saída do ponto!");
        }

        private Ponto FindLastPontoOfDay(Guid colaboradorId)
        {
            Ponto ponto = _context.Ponto.OrderByDescending(p => p.DataHora).AsNoTracking().
                                         FirstOrDefault(p =>
                                        (p.ColaboradorId == colaboradorId) &&
                                        (p.DataHora.Date == DateTime.Now.Date));

            _context.Ponto.AsNoTracking().ToListAsync();
            return ponto;
        }        
        private bool VerifyEntrada(Guid colaboradorId)
        {
            Ponto ponto = FindLastPontoOfDay(colaboradorId);
            //Pode pontuar Entrada se o colaborador nÃ£o efetuou a Entrad a OU jÃ¡ efetuou a Saida
             return (ponto == null) || (ponto != null && ponto.PontuouSaida());
            
        }
        private bool VerifySaida(Guid colaboradorId)
        {
            Ponto ponto = FindLastPontoOfDay(colaboradorId);
                //Pode pontuar Saida se o colaborador ainda nÃ£o efetuou a Saida E jÃ¡ efetuou a Entrada  
                return (ponto != null && ponto.PontuouEntrada());
        }
    }
}
