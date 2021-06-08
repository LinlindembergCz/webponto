using PontoEletronico.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces
{ 
    public interface IPontoRepository
    {
        Task<ICollection<Ponto>> FindAllAsync();
        void Create(Ponto entity);
        Ponto FindLastPontoOfDay(Guid colaboradorId);
        Task<ICollection<PontosColaboradorResponse>> ListPontosColaborador(string matricula);
        

    }
}
