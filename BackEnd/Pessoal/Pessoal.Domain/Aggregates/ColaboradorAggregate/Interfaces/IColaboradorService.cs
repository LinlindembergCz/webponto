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

        void Create(Colaborador entity);

        void Modify(Colaborador entity);

        void Delete(Guid id);
    }
}
