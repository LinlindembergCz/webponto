using Pessoal.Domain.Aggregates.ColaboradorAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Pessoal.Domain.Aggregates.ColaboradorAggregate
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }
        public async Task<List<Colaborador>> FindAllAsync() => (await _colaboradorRepository.FindAllAsync()).ToList();

        public Colaborador FindById(Guid id) => (_colaboradorRepository.FindById(id));

        public async Task<Colaborador> FindByMatricula(string matricula) => (await _colaboradorRepository.FindByMatricula(matricula));

        public void Create(Colaborador entity)
        {
            _colaboradorRepository.Create(entity);
        }
        public void Modify(Colaborador entity)
        {
            _colaboradorRepository.Modify(entity);
        }

        public void Delete(Guid id)
        {
            _colaboradorRepository.Delete(id);
        }
        public void Ativar(Guid id)
        {
            _colaboradorRepository.Ativar(id);
        }
        public void Inativar(Guid id)
        {
            _colaboradorRepository.Inativar(id);
        }

    }
}
