using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace PontoEletronico.Domain.Aggregates.PontoAggregate
{
    public class PontoService : IPontoService
    {
        private readonly IPontoRepository _Repository;
        public PontoService(IPontoRepository Repository)
        {
            _Repository = Repository;

        }

        public async Task<List<Ponto>> FindAllAsync() => (await _Repository.FindAllAsync()).ToList();
        public void CreateEntrada(Ponto entity)
        {
            _Repository.CreateEntrada(entity);
        }

        public void CreateSaida(Ponto entity)
        {
            _Repository.CreateSaida(entity);
        }
    }
}
