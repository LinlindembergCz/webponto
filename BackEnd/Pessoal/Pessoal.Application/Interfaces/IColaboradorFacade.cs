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

        void CreateRequest(ColaboradorRequest entity);

        void ModifyRequest(ColaboradorRequest entity);

        void Delete(Guid id);
    }
}