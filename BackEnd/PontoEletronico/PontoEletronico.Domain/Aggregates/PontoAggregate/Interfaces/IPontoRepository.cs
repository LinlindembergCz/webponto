using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces
{ 
    public interface IPontoRepository
    {
        Task<ICollection<Ponto>> FindAllAsync();

        void CreateEntrada(Ponto entity);
        void CreateSaida(Ponto entity);

    }
}
