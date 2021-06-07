using Pessoal.Application.Commands.Request;
using Pessoal.Application.Commands.Response;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Pessoal.Application.Interfaces
{
    public interface IColaboradorFacade
    {
        Task<List<ColaboradorResponse>> FindAllAsync();
        ColaboradorResponse FindById(Guid id);
        Task<ColaboradorResponse> FindByMatricula(string matricula);
        void CreateRequest(ColaboradorRequest entity);
        void ModifyRequest(ColaboradorRequest entity);
        void Delete(Guid id);
        void Ativar(Guid id);
        void Inativar(Guid id);
    }
}