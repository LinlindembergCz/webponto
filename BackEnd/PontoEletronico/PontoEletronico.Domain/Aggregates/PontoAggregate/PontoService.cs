using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using PontoEletronico.Domain.Enums;
using PontoEletronico.Domain.Commands.Response;

namespace PontoEletronico.Domain.Aggregates.PontoAggregate
{
    public class PontoService : IPontoService
    {
        private readonly IPontoRepository _Repository;
        public PontoService(IPontoRepository Repository)
        {
            _Repository = Repository;

        }

        public async Task<List<Ponto>> FindAllAsync() 
            => (await _Repository.FindAllAsync()).ToList();

        public async Task<List<PontosColaboradorResponse>> ListPontosColaborador(string matricula)
            => (await _Repository.ListPontosColaborador(matricula)).ToList();


        private bool VerifyEntrada(Guid colaboradorId)
        {
            Ponto ponto = _Repository.FindLastPontoOfDay(colaboradorId);            
            //Pode pontuar Entrada se o colaborador nÃ£o efetuou a Entrad a OU jÃ¡ efetuou a Saida
            return (ponto == null) || (ponto != null && ponto.PontuouSaida());
        }

        private int GetLastTurno(Guid colaboradorId)
        {
            Ponto ponto = _Repository.FindLastPontoOfDay(colaboradorId);      
           
            //Incrementar a proxima sequencia a cada SAIDA
            return ponto == null ? 1 : 
                   ponto.Indicador == IndicadorEntradaSaida.SAIDA ? 
                   ponto.Turno + 1: 
                   ponto.Turno;
        }
        private bool VerifySaida(Guid colaboradorId)
        {
            Ponto ponto = _Repository.FindLastPontoOfDay(colaboradorId);
            //Pode pontuar Saida se o colaborador ainda nÃ£o efetuou a Saida E jÃ¡ efetuou a Entrada  
            return (ponto != null && ponto.PontuouEntrada());
        }

        public void CreateEntrada(Ponto entity)
        {
            if (VerifyEntrada(entity.ColaboradorId))
            {
                entity.Indicador = IndicadorEntradaSaida.ENTRADA;
                entity.Turno = GetLastTurno(entity.ColaboradorId);
                _Repository.Create(entity);
            }
            else throw new InvalidOperationException("Colaborador já registrou a Entrada do ponto!");
        }

        public void CreateSaida(Ponto entity)
        {            
            if (VerifySaida(entity.ColaboradorId))
            {
                entity.Indicador = IndicadorEntradaSaida.SAIDA;
                entity.Turno = GetLastTurno(entity.ColaboradorId);
                _Repository.Create(entity);
            }
            else throw new InvalidOperationException("Colaborador já registrou a Entrada do ponto!");
        }
    }
}
