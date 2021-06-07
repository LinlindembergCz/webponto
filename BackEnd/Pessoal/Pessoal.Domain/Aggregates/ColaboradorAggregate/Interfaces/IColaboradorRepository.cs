using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Domain.Aggregates.ColaboradorAggregate.Interfaces
{ 
    public interface IColaboradorRepository
    {
        Task<ICollection<Colaborador>> FindAllAsync();

        ColaboradorAggregate.Colaborador FindById(Guid id);

        void Create(Colaborador entity);

        void Modify(Colaborador entity);

        void Delete(Guid id);

        void Ativar(Guid id);

        void Inativar(Guid id);

        Task<ColaboradorAggregate.Colaborador> FindByMatricula(string matricula);
    }
}
