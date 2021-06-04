using WebPonto.Application.Commands.Request;
using WebPonto.Application.Commands.Response;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace WebPonto.Application.Interfaces
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