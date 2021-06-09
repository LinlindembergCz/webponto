using PontoEletronico.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces
{
    public interface IPontoService
    {
        Task<List<Ponto>> FindAllAsync();
        void CreateEntrada(Ponto entity);

        void CreateSaida(Ponto entity);

        Task<List<PontosColaboradorResponse>> ListPontosColaborador(Guid colaboradorid);
        
    }
}
