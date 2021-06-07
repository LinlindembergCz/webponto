using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Domain.Aggregates.ColaboradorAggregate.Interfaces
{
    public interface IColaboradorService
    {
        Task<List<Colaborador>> FindAllAsync();

        Colaborador FindById(Guid id);

        Task<Colaborador> FindByMatricula(string matricula);

        void Create(Colaborador entity);

        void Modify(Colaborador entity);

        void Delete(Guid id);

        void Ativar(Guid id);

        void Inativar(Guid id);
    }
}
